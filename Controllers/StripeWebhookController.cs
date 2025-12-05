using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace Kokomija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeWebhookController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<StripeWebhookController> _logger;
        private readonly IConfiguration _configuration;

        public StripeWebhookController(
            IUnitOfWork unitOfWork,
            ILogger<StripeWebhookController> logger,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> HandleWebhook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var stripeSignature = Request.Headers["Stripe-Signature"].ToString();
            var webhookSecret = _configuration["Stripe:WebhookSecret"];

            if (string.IsNullOrEmpty(webhookSecret))
            {
                _logger.LogError("Stripe webhook secret not configured");
                return BadRequest("Webhook secret not configured");
            }

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    stripeSignature,
                    webhookSecret
                );

                _logger.LogInformation($"Received Stripe webhook: {stripeEvent.Type}");

                // Handle the event
                switch (stripeEvent.Type)
                {
                    case "checkout.session.completed":
                        await HandleCheckoutSessionCompleted(stripeEvent);
                        break;

                    case "checkout.session.async_payment_succeeded":
                        await HandleCheckoutSessionAsyncPaymentSucceeded(stripeEvent);
                        break;

                    case "checkout.session.async_payment_failed":
                        await HandleCheckoutSessionAsyncPaymentFailed(stripeEvent);
                        break;

                    case "payment_intent.succeeded":
                        await HandlePaymentIntentSucceeded(stripeEvent);
                        break;

                    case "payment_intent.payment_failed":
                        await HandlePaymentIntentFailed(stripeEvent);
                        break;

                    case "charge.refunded":
                        await HandleChargeRefunded(stripeEvent);
                        break;

                    case "charge.succeeded":
                        await HandleChargeSucceeded(stripeEvent);
                        break;

                    case "payout.created":
                        await HandlePayoutCreated(stripeEvent);
                        break;

                    case "payout.failed":
                        await HandlePayoutFailed(stripeEvent);
                        break;

                    case "payout.paid":
                        await HandlePayoutPaid(stripeEvent);
                        break;

                    default:
                        _logger.LogInformation($"Unhandled event type: {stripeEvent.Type}");
                        break;
                }

                return Ok();
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe webhook signature verification failed");
                return BadRequest("Invalid signature");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing webhook");
                return StatusCode(500, "Webhook processing error");
            }
        }

        private async Task HandleCheckoutSessionCompleted(Event stripeEvent)
        {
            var session = stripeEvent.Data.Object as Session;
            if (session == null) return;

            _logger.LogInformation($"Checkout session completed: {session.Id}");

            // Find order by session ID
            var orders = await _unitOfWork.Orders.GetAllAsync(o => o.StripeCheckoutSessionId == session.Id);
            var order = orders.FirstOrDefault();

            if (order != null)
            {
                order.PaymentStatus = "paid";
                order.OrderStatus = "processing";
                order.PaidAt = DateTime.UtcNow;
                order.SessionStatus = "complete";
                
                if (!string.IsNullOrEmpty(session.PaymentIntentId))
                {
                    order.StripePaymentIntentId = session.PaymentIntentId;
                }

                // Update currency and country from session metadata
                if (session.Metadata != null)
                {
                    if (session.Metadata.ContainsKey("currency"))
                    {
                        order.Currency = session.Metadata["currency"];
                    }
                    if (session.Metadata.ContainsKey("country"))
                    {
                        order.CustomerCountry = session.Metadata["country"];
                    }
                }

                // Update shipping address if available
                if (session.CustomerDetails?.Address != null)
                {
                    order.ShippingAddress = session.CustomerDetails.Address.Line1;
                    order.ShippingCity = session.CustomerDetails.Address.City;
                    order.ShippingState = session.CustomerDetails.Address.State;
                    order.ShippingPostalCode = session.CustomerDetails.Address.PostalCode;
                    order.ShippingCountry = session.CustomerDetails.Address.Country;
                }

                // Update user's total spent and VIP tier
                var userManager = HttpContext.RequestServices.GetRequiredService<UserManager<Entity.ApplicationUser>>();
                if (!string.IsNullOrEmpty(order.UserId))
                {
                    var user = await userManager.FindByIdAsync(order.UserId);
                    if (user != null)
                    {
                        user.TotalSpent += order.TotalAmount;
                        
                        // Calculate and update VIP tier
                        var newTier = CalculateVIPTier(user.TotalSpent);
                        if (user.VipTier != newTier)
                        {
                            user.VipTier = newTier;
                        }
                        
                        await userManager.UpdateAsync(user);
                        
                        // Update VIP role
                        await UpdateUserVIPRoleAsync(userManager, user, newTier);
                        
                        _logger.LogInformation($"Updated user {user.Email} total spent to {user.TotalSpent:C}, VIP tier: {user.VipTier}");
                    }
                }

                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Order {order.OrderNumber} marked as paid");
            }
            else
            {
                _logger.LogWarning($"Order not found for session: {session.Id}");
            }
        }

        private async Task HandleCheckoutSessionAsyncPaymentSucceeded(Event stripeEvent)
        {
            var session = stripeEvent.Data.Object as Session;
            if (session == null) return;

            _logger.LogInformation($"Async payment succeeded for session: {session.Id}");

            var orders = await _unitOfWork.Orders.GetAllAsync(o => o.StripeCheckoutSessionId == session.Id);
            var order = orders.FirstOrDefault();

            if (order != null)
            {
                order.PaymentStatus = "paid";
                order.OrderStatus = "processing";
                order.PaidAt = DateTime.UtcNow;
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task HandleCheckoutSessionAsyncPaymentFailed(Event stripeEvent)
        {
            var session = stripeEvent.Data.Object as Session;
            if (session == null) return;

            _logger.LogWarning($"Async payment failed for session: {session.Id}");

            var orders = await _unitOfWork.Orders.GetAllAsync(o => o.StripeCheckoutSessionId == session.Id);
            var order = orders.FirstOrDefault();

            if (order != null)
            {
                order.PaymentStatus = "failed";
                order.OrderStatus = "cancelled";
                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task HandlePaymentIntentSucceeded(Event stripeEvent)
        {
            var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
            if (paymentIntent == null) return;

            _logger.LogInformation($"Payment intent succeeded: {paymentIntent.Id}");

            var orders = await _unitOfWork.Orders.GetAllAsync(o => o.StripePaymentIntentId == paymentIntent.Id);
            var order = orders.FirstOrDefault();

            if (order != null)
            {
                order.PaymentStatus = "paid";
                order.PaidAt = DateTime.UtcNow;
                
                if (order.OrderStatus == "pending")
                {
                    order.OrderStatus = "processing";
                }

                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Order {order.OrderNumber} payment confirmed");
            }
        }

        private async Task HandlePaymentIntentFailed(Event stripeEvent)
        {
            var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
            if (paymentIntent == null) return;

            _logger.LogWarning($"Payment intent failed: {paymentIntent.Id}");

            var orders = await _unitOfWork.Orders.GetAllAsync(o => o.StripePaymentIntentId == paymentIntent.Id);
            var order = orders.FirstOrDefault();

            if (order != null)
            {
                order.PaymentStatus = "failed";
                
                // Add error message if available
                if (paymentIntent.LastPaymentError != null)
                {
                    _logger.LogError($"Payment error for order {order.OrderNumber}: {paymentIntent.LastPaymentError.Message}");
                }

                await _unitOfWork.SaveChangesAsync();
            }
        }

        private async Task HandleChargeRefunded(Event stripeEvent)
        {
            var charge = stripeEvent.Data.Object as Charge;
            if (charge == null) return;

            _logger.LogInformation($"Charge refunded: {charge.Id}");

            // Find order by payment intent
            if (!string.IsNullOrEmpty(charge.PaymentIntentId))
            {
                var orders = await _unitOfWork.Orders.GetAllAsync(o => o.StripePaymentIntentId == charge.PaymentIntentId);
                var order = orders.FirstOrDefault();

                if (order != null)
                {
                    // Update order status
                    order.PaymentStatus = "refunded";
                    order.OrderStatus = "cancelled";

                    // Check if there's a return request associated
                    var returnRequests = await _unitOfWork.ReturnRequests.GetAllAsync(r => r.OrderId == order.Id);
                    var returnRequest = returnRequests.FirstOrDefault(r => r.Status == Entity.ReturnRequestStatus.Approved);

                    if (returnRequest != null && string.IsNullOrEmpty(returnRequest.StripeRefundId))
                    {
                        // Update return request with refund info
                        returnRequest.StripeRefundId = charge.Id;
                        returnRequest.RefundedAmount = (decimal)(charge.AmountRefunded / 100.0);
                        returnRequest.RefundedAt = DateTime.UtcNow;
                        returnRequest.Status = Entity.ReturnRequestStatus.Completed;
                    }

                    await _unitOfWork.SaveChangesAsync();
                    _logger.LogInformation($"Order {order.OrderNumber} marked as refunded");
                }
            }
        }

        private async Task HandleChargeSucceeded(Event stripeEvent)
        {
            var charge = stripeEvent.Data.Object as Charge;
            if (charge == null) return;

            _logger.LogInformation($"Charge succeeded: {charge.Id}, Amount: {charge.Amount}");

            // Find order by payment intent
            if (!string.IsNullOrEmpty(charge.PaymentIntentId))
            {
                var orders = await _unitOfWork.Orders.GetAllAsync(o => o.StripePaymentIntentId == charge.PaymentIntentId);
                var order = orders.FirstOrDefault();

                if (order != null)
                {
                    // Calculate commissions and fees
                    await CalculateAndRecordCommissions(order, charge);
                }
            }
        }

        private async Task CalculateAndRecordCommissions(Entity.Order order, Charge charge)
        {
            try
            {
                // Get commission settings
                var commissionSettings = (await _unitOfWork.CommissionSettings.GetAllAsync()).FirstOrDefault();
                if (commissionSettings == null)
                {
                    _logger.LogWarning("Commission settings not found. Skipping commission calculation.");
                    return;
                }

                var grossAmount = order.TotalAmount;
                
                // Calculate Stripe processing fee (actual from charge)
                var stripeProcessingFee = (decimal)(charge.BalanceTransaction != null ? 
                    (await GetBalanceTransaction(charge.BalanceTransactionId))?.Fee / 100.0 ?? 0 : 0);

                // If we can't get actual fee, estimate it
                if (stripeProcessingFee == 0)
                {
                    stripeProcessingFee = (grossAmount * commissionSettings.StripeCommissionRate / 100) + commissionSettings.StripeFixedFee;
                }

                // Calculate developer commission (root's cut)
                var developerCommission = grossAmount * commissionSettings.DeveloperCommissionRate / 100;

                // Net amount after Stripe fees and developer commission
                var netAmount = grossAmount - stripeProcessingFee - developerCommission;

                // Record developer earnings
                var developerEarning = new Entity.DeveloperEarnings
                {
                    OrderId = order.Id,
                    GrossAmount = grossAmount,
                    StripeProcessingFee = stripeProcessingFee,
                    DeveloperCommission = developerCommission,
                    NetAmount = netAmount,
                    EarnedAt = DateTime.UtcNow,
                    PayoutStatus = Entity.PayoutStatus.Pending
                };

                await _unitOfWork.DeveloperEarnings.AddAsync(developerEarning);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation($"Recorded commissions for order {order.OrderNumber}: Gross={grossAmount:C}, StripeFee={stripeProcessingFee:C}, DevCommission={developerCommission:C}, Net={netAmount:C}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error calculating commissions for order {order.Id}");
            }
        }

        private async Task<Stripe.BalanceTransaction?> GetBalanceTransaction(string balanceTransactionId)
        {
            try
            {
                var service = new Stripe.BalanceTransactionService();
                return await service.GetAsync(balanceTransactionId);
            }
            catch
            {
                return null;
            }
        }

        private Task HandlePayoutCreated(Event stripeEvent)
        {
            var payout = stripeEvent.Data.Object as Payout;
            if (payout == null) return Task.CompletedTask;

            _logger.LogInformation($"Payout created: {payout.Id}, Amount: {payout.Amount}, Status: {payout.Status}");
            return Task.CompletedTask;

            // Log payout creation - you can extend this to track in database
            // This is useful for audit trail
        }

        private async Task HandlePayoutFailed(Event stripeEvent)
        {
            var payout = stripeEvent.Data.Object as Payout;
            if (payout == null) return;

            _logger.LogError($"Payout failed: {payout.Id}, Amount: {payout.Amount}, Failure: {payout.FailureMessage}");

            // Update DeveloperEarnings payout status to failed
            var developerEarnings = await _unitOfWork.DeveloperEarnings.GetAllAsync(
                de => de.PayoutId == payout.Id && de.PayoutStatus == Entity.PayoutStatus.Processed
            );

            foreach (var earning in developerEarnings)
            {
                earning.PayoutStatus = Entity.PayoutStatus.Failed;
                earning.PayoutDate = null;
            }

            if (developerEarnings.Any())
            {
                await _unitOfWork.SaveChangesAsync();
            }

            // TODO: Send email notification to root admin about payout failure
        }

        private async Task HandlePayoutPaid(Event stripeEvent)
        {
            var payout = stripeEvent.Data.Object as Payout;
            if (payout == null) return;

            _logger.LogInformation($"Payout paid: {payout.Id}, Amount: {payout.Amount}");

            // Update DeveloperEarnings payout status to processed
            var developerEarnings = await _unitOfWork.DeveloperEarnings.GetAllAsync(
                de => de.PayoutId == payout.Id
            );

            foreach (var earning in developerEarnings)
            {
                earning.PayoutStatus = Entity.PayoutStatus.Processed;
                earning.PayoutDate = DateTime.UtcNow;
            }

            if (developerEarnings.Any())
            {
                await _unitOfWork.SaveChangesAsync();
            }

            // TODO: Send email notification to root admin about successful payout
        }

        private string CalculateVIPTier(decimal totalSpent)
        {
            if (totalSpent >= 5000) return "Platinum";
            if (totalSpent >= 1500) return "Gold";
            if (totalSpent >= 500) return "Silver";
            if (totalSpent > 0) return "Bronze";
            return "None";
        }

        private async Task UpdateUserVIPRoleAsync(UserManager<Entity.ApplicationUser> userManager, Entity.ApplicationUser user, string tierName)
        {
            // Remove all existing VIP roles
            var vipRoles = new[] { "VIPBronze", "VIPSilver", "VIPGold", "VIPPlatinum" };
            var currentRoles = await userManager.GetRolesAsync(user);
            var currentVipRoles = currentRoles.Where(r => vipRoles.Contains(r)).ToList();
            
            if (currentVipRoles.Any())
            {
                await userManager.RemoveFromRolesAsync(user, currentVipRoles);
            }

            // Add new VIP role based on tier (skip if None)
            if (tierName != "None")
            {
                var newRole = $"VIP{tierName}";
                if (!await userManager.IsInRoleAsync(user, newRole))
                {
                    await userManager.AddToRoleAsync(user, newRole);
                }
            }
        }
    }
}
