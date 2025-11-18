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
                    case Events.CheckoutSessionCompleted:
                        await HandleCheckoutSessionCompleted(stripeEvent);
                        break;

                    case Events.CheckoutSessionAsyncPaymentSucceeded:
                        await HandleCheckoutSessionAsyncPaymentSucceeded(stripeEvent);
                        break;

                    case Events.CheckoutSessionAsyncPaymentFailed:
                        await HandleCheckoutSessionAsyncPaymentFailed(stripeEvent);
                        break;

                    case Events.PaymentIntentSucceeded:
                        await HandlePaymentIntentSucceeded(stripeEvent);
                        break;

                    case Events.PaymentIntentPaymentFailed:
                        await HandlePaymentIntentFailed(stripeEvent);
                        break;

                    case Events.ChargeRefunded:
                        await HandleChargeRefunded(stripeEvent);
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
                if (session.ShippingDetails?.Address != null)
                {
                    order.ShippingAddress = session.ShippingDetails.Address.Line1;
                    order.ShippingCity = session.ShippingDetails.Address.City;
                    order.ShippingState = session.ShippingDetails.Address.State;
                    order.ShippingPostalCode = session.ShippingDetails.Address.PostalCode;
                    order.ShippingCountry = session.ShippingDetails.Address.Country;
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
                    order.PaymentStatus = "refunded";
                    order.OrderStatus = "cancelled";
                    await _unitOfWork.SaveChangesAsync();
                    _logger.LogInformation($"Order {order.OrderNumber} marked as refunded");
                }
            }
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
