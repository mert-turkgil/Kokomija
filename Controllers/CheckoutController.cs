using Kokomija.Data.Abstract;
using Kokomija.Data;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Checkout;
using Kokomija.Models.ViewModels;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStripeService _stripeService;
        private readonly ILocalizationService _localizationService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CheckoutController> _logger;
        private readonly IShippingService _shippingService;
        private readonly INIPValidationService _nipValidationService;

        private readonly Dictionary<string, string> _currencyMap = new Dictionary<string, string>
        {
            { "PL", "pln" }, // Poland
            { "AT", "eur" }, { "BE", "eur" }, { "HR", "eur" }, { "CY", "eur" },
            { "EE", "eur" }, { "FI", "eur" }, { "FR", "eur" }, { "DE", "eur" },
            { "GR", "eur" }, { "IE", "eur" }, { "IT", "eur" }, { "LV", "eur" },
            { "LT", "eur" }, { "LU", "eur" }, { "MT", "eur" }, { "NL", "eur" },
            { "PT", "eur" }, { "SK", "eur" }, { "SI", "eur" }, { "ES", "eur" }
        };

        public CheckoutController(
            IUnitOfWork unitOfWork,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IStripeService stripeService,
            ILocalizationService localizationService,
            IConfiguration configuration,
            ILogger<CheckoutController> logger,
            IShippingService shippingService,
            INIPValidationService nipValidationService)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
            _stripeService = stripeService;
            _localizationService = localizationService;
            _configuration = configuration;
            _logger = logger;
            _shippingService = shippingService;
            _nipValidationService = nipValidationService;
        }

        private async Task<bool> IsBusinessModeActiveAsync(string userId)
        {
            var businessProfile = await _nipValidationService.GetBusinessProfileAsync(userId);
            return businessProfile?.IsVerified == true && businessProfile?.IsBusinessModeActive == true;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest? request)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            // Get selected shipping option from session or request
            var shippingOption = request?.ShippingOption 
                ?? HttpContext.Session.GetString("SelectedShippingOption") 
                ?? "standard";
            
            var couponCode = request?.CouponCode;

            try
            {

                // Get cart items
                var cartItems = (await _unitOfWork.Carts.FindAsync(c => c.UserId == user.Id)).ToList();
                if (!cartItems.Any())
                {
                    return Json(new { success = false, message = _localizationService["Cart_Empty"] });
                }

                // Check if user is in business mode
                bool isBusinessMode = await IsBusinessModeActiveAsync(user.Id);
                _logger.LogInformation($"Checkout for user {user.Id}: Business Mode = {isBusinessMode}");

                // Calculate VIP discount
                var vipTier = user.VipTier ?? "None";
                decimal vipDiscountPercentage = vipTier switch
                {
                    "Bronze" => 2m,
                    "Silver" => 5m,
                    "Gold" => 8m,
                    "Platinum" => 12m,
                    _ => 0m
                };

                // Store coupon code for Stripe (don't apply to price, let Stripe handle it)
                couponCode = couponCode ?? HttpContext.Session.GetString("AppliedCouponCode");

                _logger.LogInformation($"Checkout for user {user.Id}: VIP {vipDiscountPercentage}%");

                // Build Stripe line items
                var lineItems = new List<SessionLineItemOptions>();
                var packSizeInfo = new List<string>();
                var baseUrl = $"{Request.Scheme}://{Request.Host}";
                
                // Get the VAT 23% tax rate from Stripe
                var taxRateService = new Stripe.TaxRateService();
                var taxRates = await taxRateService.ListAsync(new Stripe.TaxRateListOptions
                {
                    Active = true,
                    Limit = 10
                });
                var vat23TaxRate = taxRates.Data.FirstOrDefault(t => 
                    t.Percentage == 23.0m && 
                    t.Jurisdiction == "PL" && 
                    t.DisplayName == "VAT");
                
                var taxRateIds = new List<string>();
                if (vat23TaxRate != null)
                {
                    taxRateIds.Add(vat23TaxRate.Id);
                    _logger.LogInformation($"Using tax rate: {vat23TaxRate.Id} (23% VAT)");
                }

                foreach (var cartItem in cartItems)
                {
                    var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductId);
                    if (product == null) continue;

                    var packSize = product.PackSize;
                    var totalItems = packSize * cartItem.Quantity;
                    packSizeInfo.Add($"{product.Name}|PackSize:{packSize}|Qty:{cartItem.Quantity}|Total:{totalItems}");

                    // Get product image
                    var firstImage = await _context.ProductImages
                        .Where(pi => pi.ProductId == product.Id)
                        .FirstOrDefaultAsync();
                    
                    string? imageUrl = null;
                    if (firstImage != null && !string.IsNullOrEmpty(firstImage.ImageUrl))
                    {
                        if (baseUrl.StartsWith("https://") && !baseUrl.Contains("localhost") && !baseUrl.Contains("127.0.0.1"))
                        {
                            imageUrl = $"{baseUrl}/img/ProductImage/{firstImage.ImageUrl}";
                        }
                    }
                    
                    if (imageUrl == null && baseUrl.StartsWith("https://") && !baseUrl.Contains("localhost") && !baseUrl.Contains("127.0.0.1"))
                    {
                        imageUrl = $"{baseUrl}/img/logo_black.png";
                    }

                    // Find variant
                    var variants = await _unitOfWork.ProductVariants.FindAsync(v =>
                        v.ProductId == cartItem.ProductId &&
                        v.SizeId == cartItem.SizeId &&
                        v.ColorId == cartItem.ColorId);
                    var variant = variants.FirstOrDefault();
                    
                    if (variant == null) continue;

                    // Apply business pricing if in business mode and product has business price
                    decimal basePrice = variant.Price;
                    bool isBusinessPrice = false;
                    
                    if (isBusinessMode && product.IsAvailableForBusiness && product.BusinessPrice.HasValue)
                    {
                        basePrice = product.BusinessPrice.Value;
                        isBusinessPrice = true;
                        _logger.LogInformation($"Product {product.Name}: Using B2B price {basePrice} PLN instead of retail {variant.Price} PLN");
                    }

                    // Apply VIP discount to the price (Stripe will handle coupon separately)
                    decimal originalPrice = basePrice;
                    decimal discountedPrice = originalPrice * (1 - (vipDiscountPercentage / 100));
                    
                    // Convert to grosze (cents) for Stripe
                    long priceInGrosze = (long)(discountedPrice * 100);

                    _logger.LogInformation($"Product {product.Name}: Base {originalPrice} PLN{(isBusinessPrice ? " (B2B)" : "")}, VIP Discounted {discountedPrice} PLN ({vipDiscountPercentage}% off)");

                    // Always use PriceData with PLN currency
                    var lineItem = new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "pln", // Always PLN
                            UnitAmount = priceInGrosze,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = packSize > 1 
                                    ? $"{product.Name} ({packSize} items per pack)"
                                    : $"{product.Name} ({variant.SKU})",
                                Description = packSize > 1 
                                    ? $"{product.Description} - {packSize} items per pack, {totalItems} total items"
                                    : product.Description
                            }
                        },
                        Quantity = cartItem.Quantity
                    };
                    
                    // Apply tax rates if available
                    if (taxRateIds.Any())
                    {
                        lineItem.TaxRates = taxRateIds;
                    }

                    // Only add images if we have a valid public URL
                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        lineItem.PriceData.ProductData.Images = new List<string> { imageUrl };
                    }

                    lineItems.Add(lineItem);
                }

                // Detect user's country and currency
                var country = DetectCountry();
                var currency = "pln"; // Always use PLN
                
                // Calculate subtotal for shipping rate determination
                var subtotalAfterDiscount = cartItems.Sum(c => _unitOfWork.Products.GetByIdAsync(c.ProductId).Result?.Price ?? 0) * (1 - (vipDiscountPercentage / 100));
                
                // Get available shipping rates from database
                var availableShippingRates = await _shippingService.GetAvailableRatesForOrderAsync(country, subtotalAfterDiscount);
                
                // Check if user is VIP for shipping discounts
                var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(user.Id);
                var totalSpent = orders.Sum(o => o.TotalAmount);
                var isVipCustomer = totalSpent >= 500 || vipDiscountPercentage > 0;

                // Create metadata
                var metadata = new Dictionary<string, string>
                {
                    { "user_id", user.Id },
                    { "cart_items_count", cartItems.Count.ToString() },
                    { "currency", currency },
                    { "country", country },
                    { "pack_info", string.Join(";", packSizeInfo) },
                    { "vip_tier", vipTier },
                    { "vip_discount_percentage", vipDiscountPercentage.ToString("F2") }
                };

                // Add coupon if applied
                if (!string.IsNullOrEmpty(couponCode))
                {
                    metadata.Add("coupon_code", couponCode);
                }

                // Create Stripe Checkout Session with shipping options
                var domain = $"{Request.Scheme}://{Request.Host}";
                
                var options = new SessionCreateOptions
                {
                    LineItems = lineItems,
                    Mode = "payment",
                    SuccessUrl = $"{domain}/Checkout/Success?session_id={{CHECKOUT_SESSION_ID}}",
                    CancelUrl = $"{domain}/Checkout/Cancel",
                    ClientReferenceId = user.Id, // Set user ID for order creation
                    Metadata = metadata,
                    PhoneNumberCollection = new SessionPhoneNumberCollectionOptions
                    {
                        Enabled = true
                    },
                    ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                    {
                        AllowedCountries = new List<string> { "PL", "DE", "FR", "IT", "ES", "NL", "BE", "AT" }
                    },
                    CustomerUpdate = new SessionCustomerUpdateOptions
                    {
                        Shipping = "auto"
                    },
                    ShippingOptions = new List<SessionShippingOptionOptions>()
                };
                
                // Add shipping options based on selection
                if (availableShippingRates.Any())
                {
                    // Find the selected shipping rate from database
                    // First try to match by ID (when user selected a database rate)
                    ShippingRateDto? selectedRate = null;
                    
                    if (int.TryParse(shippingOption, out int rateId))
                    {
                        selectedRate = availableShippingRates.FirstOrDefault(r => r.Id == rateId);
                    }
                    
                    // If not found by ID, try to match by type (express/standard)
                    selectedRate ??= availableShippingRates.FirstOrDefault(r => 
                        (shippingOption == "express" && (r.Zone?.Contains("Express", StringComparison.OrdinalIgnoreCase) == true || r.ProviderName.Contains("Express", StringComparison.OrdinalIgnoreCase))) ||
                        (shippingOption == "standard" && r.Zone?.Contains("Standard", StringComparison.OrdinalIgnoreCase) == true));
                    
                    // Fallback to first available rate if not found
                    selectedRate ??= availableShippingRates.First();
                    
                    // Determine if this is an express-type shipping
                    bool isExpressShipping = selectedRate.Zone?.Contains("Express", StringComparison.OrdinalIgnoreCase) == true || 
                                             selectedRate.ProviderName.Contains("Express", StringComparison.OrdinalIgnoreCase);
                    
                    // Determine if free shipping applies
                    var qualifiesForFreeShipping = (selectedRate.FreeShippingThreshold.HasValue && subtotalAfterDiscount >= selectedRate.FreeShippingThreshold.Value) || isVipCustomer;
                    
                    // Calculate final shipping cost
                    decimal shippingCost = selectedRate.Rate;
                    string displayName = selectedRate.Zone ?? selectedRate.ProviderName;
                    
                    if (qualifiesForFreeShipping)
                    {
                        // VIP gets discounted express, free standard
                        if (isExpressShipping)
                        {
                            shippingCost = Math.Round(shippingCost * 0.5m, 2); // 50% of express for VIP
                            displayName = $"{displayName} (VIP Discount)";
                        }
                        else
                        {
                            shippingCost = 0;
                            displayName = $"{displayName} (Free)";
                        }
                    }
                    
                    // Convert to grosze for Stripe
                    var shippingCostInGrosze = (long)(shippingCost * 100);
                    
                    // Use pre-created Stripe shipping rate if available, otherwise create on the fly
                    if (!string.IsNullOrEmpty(selectedRate.StripeShippingRateId) && !qualifiesForFreeShipping)
                    {
                        // Use the pre-created Stripe shipping rate ID
                        options.ShippingOptions.Add(new SessionShippingOptionOptions
                        {
                            ShippingRate = selectedRate.StripeShippingRateId
                        });
                    }
                    else
                    {
                        // Create shipping rate data on the fly (for discounted/free shipping)
                        options.ShippingOptions.Add(new SessionShippingOptionOptions
                        {
                            ShippingRateData = new SessionShippingOptionShippingRateDataOptions
                            {
                                Type = "fixed_amount",
                                FixedAmount = new SessionShippingOptionShippingRateDataFixedAmountOptions
                                {
                                    Amount = shippingCostInGrosze,
                                    Currency = "pln"
                                },
                                DisplayName = displayName,
                                DeliveryEstimate = new SessionShippingOptionShippingRateDataDeliveryEstimateOptions
                                {
                                    Minimum = new SessionShippingOptionShippingRateDataDeliveryEstimateMinimumOptions
                                    {
                                        Unit = "business_day",
                                        Value = selectedRate.EstimatedDaysMin > 0 ? selectedRate.EstimatedDaysMin : 3
                                    },
                                    Maximum = new SessionShippingOptionShippingRateDataDeliveryEstimateMaximumOptions
                                    {
                                        Unit = "business_day",
                                        Value = selectedRate.EstimatedDaysMax > 0 ? selectedRate.EstimatedDaysMax : 7
                                    }
                                }
                            }
                        });
                    }
                }
                else
                {
                    // Fallback to hardcoded values if no rates configured in database
                    var fallbackFreeShipping = subtotalAfterDiscount >= 100m || isVipCustomer;
                    
                    if (shippingOption == "express")
                    {
                        var expressCost = fallbackFreeShipping ? 999 : 2999;
                        options.ShippingOptions.Add(new SessionShippingOptionOptions
                        {
                            ShippingRateData = new SessionShippingOptionShippingRateDataOptions
                            {
                                Type = "fixed_amount",
                                FixedAmount = new SessionShippingOptionShippingRateDataFixedAmountOptions
                                {
                                    Amount = expressCost,
                                    Currency = "pln"
                                },
                                DisplayName = fallbackFreeShipping ? "Express Shipping (VIP Discount)" : "Express Shipping",
                                DeliveryEstimate = new SessionShippingOptionShippingRateDataDeliveryEstimateOptions
                                {
                                    Minimum = new SessionShippingOptionShippingRateDataDeliveryEstimateMinimumOptions
                                    {
                                        Unit = "business_day",
                                        Value = 1
                                    },
                                    Maximum = new SessionShippingOptionShippingRateDataDeliveryEstimateMaximumOptions
                                    {
                                        Unit = "business_day",
                                        Value = 2
                                    }
                                }
                            }
                        });
                    }
                    else
                    {
                        var standardCost = fallbackFreeShipping ? 0 : 1500;
                        options.ShippingOptions.Add(new SessionShippingOptionOptions
                        {
                            ShippingRateData = new SessionShippingOptionShippingRateDataOptions
                            {
                                Type = "fixed_amount",
                                FixedAmount = new SessionShippingOptionShippingRateDataFixedAmountOptions
                                {
                                    Amount = standardCost,
                                    Currency = "pln"
                                },
                                DisplayName = fallbackFreeShipping ? "Standard Shipping (Free)" : "Standard Shipping",
                                DeliveryEstimate = new SessionShippingOptionShippingRateDataDeliveryEstimateOptions
                                {
                                    Minimum = new SessionShippingOptionShippingRateDataDeliveryEstimateMinimumOptions
                                    {
                                        Unit = "business_day",
                                        Value = 3
                                    },
                                    Maximum = new SessionShippingOptionShippingRateDataDeliveryEstimateMaximumOptions
                                    {
                                        Unit = "business_day",
                                        Value = 7
                                    }
                                }
                            }
                        });
                    }
                }
                
                // Set customer or email (not both)
                if (!string.IsNullOrEmpty(user.StripeCustomerId))
                {
                    options.Customer = user.StripeCustomerId;
                }
                else if (!string.IsNullOrEmpty(user.Email))
                {
                    options.CustomerEmail = user.Email;
                }
                
                // Set receipt email for automatic Stripe receipts
                options.PaymentIntentData = new SessionPaymentIntentDataOptions
                {
                    ReceiptEmail = user.Email
                };
                
                // Apply coupon discount if exists, otherwise allow promotion codes
                if (!string.IsNullOrEmpty(couponCode))
                {
                    var coupon = await _unitOfWork.Coupons.GetByCodeAsync(couponCode);
                    if (coupon != null && coupon.IsActive && !string.IsNullOrEmpty(coupon.StripePromotionCodeId))
                    {
                        // Check if user has prior orders (to avoid "first-time customer only" restrictions)
                        var userOrders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(user.Id);
                        var hasPriorOrders = userOrders.Any();
                        
                        // Check if coupon has customer restrictions (FirstTimeTransaction)
                        var stripeCoupon = await _stripeService.GetStripeCouponAsync(coupon.StripeCouponId ?? "");
                        var hasFirstTimeRestriction = stripeCoupon?.AppliesTo?.Products != null || 
                                                     coupon.UsageLimitPerUser == 1;
                        
                        // Only apply if user qualifies
                        if (!hasPriorOrders || !hasFirstTimeRestriction)
                        {
                            options.Discounts = new List<SessionDiscountOptions>
                            {
                                new SessionDiscountOptions { PromotionCode = coupon.StripePromotionCodeId }
                            };
                            _logger.LogInformation("Applied promotion code {Code} for customer {Email}", couponCode, user.Email);
                        }
                        else
                        {
                            _logger.LogWarning("Skipping promotion code {Code} for customer {Email} due to prior orders restriction", 
                                couponCode, user.Email);
                            // Clear the coupon from session since it can't be used
                            HttpContext.Session.Remove("AppliedCouponCode");
                            options.AllowPromotionCodes = true;
                        }
                    }
                }
                else
                {
                    // If no coupon applied, allow users to enter promotion codes at checkout
                    options.AllowPromotionCodes = true;
                }

                var sessionService = new SessionService();
                var session = await sessionService.CreateAsync(options);

                return Json(new { success = true, sessionId = session.Id, url = session.Url });
            }
            catch (Stripe.StripeException stripeEx) when (stripeEx.Message.Contains("promotion code cannot be redeemed"))
            {
                _logger.LogWarning(stripeEx, "Promotion code cannot be used for customer {Email}. This may be due to customer restrictions.", user.Email);
                // Clear the invalid coupon from session
                HttpContext.Session.Remove("AppliedCouponCode");
                return Json(new 
                { 
                    success = false, 
                    message = "The promotion code you entered cannot be used with your account. It has been removed from your cart.",
                    redirectUrl = Url.Action("Index", "Cart")
                });
            }
            catch (Stripe.StripeException stripeEx)
            {
                _logger.LogError(stripeEx, "Stripe error creating checkout session: {Error}", stripeEx.Message);
                return Json(new 
                { 
                    success = false, 
                    message = $"Payment error: {stripeEx.Message}",
                    redirectUrl = Url.Action("Index", "Cart")
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create checkout session");
                return Json(new { success = false, message = "An error occurred while creating checkout session" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Success(string session_id)
        {
            if (string.IsNullOrEmpty(session_id))
            {
                TempData["Error"] = _localizationService["Checkout_InvalidSession"];
                return RedirectToAction("Index", "Cart");
            }

            try
            {
                // Retrieve the session from Stripe
                var session = await _stripeService.GetCheckoutSessionAsync(session_id);
                
                if (session == null)
                {
                    _logger.LogWarning("Checkout session not found: {SessionId}", session_id);
                    TempData["Error"] = _localizationService["Checkout_SessionNotFound"];
                    return RedirectToAction("Index", "Cart");
                }

                // Check if order already exists (created by webhook or previous visit)
                var existingOrders = await _unitOfWork.Orders.FindAsync(o => o.StripeCheckoutSessionId == session_id);
                var existingOrder = existingOrders.FirstOrDefault();
                
                if (existingOrder != null)
                {
                    // Order already processed, show success page with existing order
                    return await BuildSuccessView(existingOrder, session);
                }

                // Payment must be successful
                if (session.PaymentStatus != "paid")
                {
                    _logger.LogWarning("Checkout session {SessionId} not paid. Status: {Status}", session_id, session.PaymentStatus);
                    return RedirectToAction("Failure", new { session_id, reason = "payment_pending" });
                }

                // Try to get user from session or from Stripe customer metadata
                var user = await _userManager.GetUserAsync(User);
                if (user == null && !string.IsNullOrEmpty(session.ClientReferenceId))
                {
                    user = await _userManager.FindByIdAsync(session.ClientReferenceId);
                }
                
                if (user == null)
                {
                    _logger.LogWarning("User not found during checkout success for session: {SessionId}", session_id);
                    TempData["Error"] = _localizationService["Error_UserNotFound"];
                    return RedirectToAction("Index", "Cart");
                }

                // Create order from cart
                var cartItems = (await _unitOfWork.Carts.FindAsync(c => c.UserId == user.Id)).ToList();
                
                if (!cartItems.Any())
                {
                    _logger.LogInformation("Cart empty for session {SessionId}, order may have been processed already", session_id);
                    // Try to find order by payment intent
                    if (!string.IsNullOrEmpty(session.PaymentIntentId))
                    {
                        var ordersByPayment = await _unitOfWork.Orders.FindAsync(o => o.StripePaymentIntentId == session.PaymentIntentId);
                        var orderByPayment = ordersByPayment.FirstOrDefault();
                        if (orderByPayment != null)
                        {
                            return await BuildSuccessView(orderByPayment, session);
                        }
                    }
                    TempData["Success"] = _localizationService["Checkout_OrderAlreadyProcessed"];
                    return RedirectToAction("Orders", "Account");
                }

                // Extract metadata
                var currency = session.Metadata?.GetValueOrDefault("currency") ?? "pln";
                var country = session.Metadata?.GetValueOrDefault("country") ?? "PL";
                var vipTier = session.Metadata?.GetValueOrDefault("vip_tier") ?? "None";
                var couponCode = session.Metadata?.GetValueOrDefault("coupon_code");

                // Calculate discount amount if coupon was applied
                decimal discountAmount = 0;
                int? couponId = null;
                if (!string.IsNullOrEmpty(couponCode))
                {
                    var coupon = await _unitOfWork.Coupons.GetByCodeAsync(couponCode);
                    if (coupon != null)
                    {
                        couponId = coupon.Id;
                        discountAmount = (session.TotalDetails?.AmountDiscount ?? 0) / 100m;
                    }
                }

                // Get commission settings for calculating commission
                var commissionSettings = (await _unitOfWork.CommissionSettings.GetAllAsync()).FirstOrDefault();
                var commissionRate = commissionSettings?.DeveloperCommissionRate ?? 1.5m;

                // Create the order
                var order = new Order
                {
                    UserId = user.Id,
                    OrderNumber = GenerateOrderNumber(),
                    TotalAmount = (session.AmountTotal ?? 0) / 100m,
                    SubtotalAmount = (session.AmountSubtotal ?? 0) / 100m,
                    TaxAmount = (session.TotalDetails?.AmountTax ?? 0) / 100m,
                    ShippingCost = (session.TotalDetails?.AmountShipping ?? 0) / 100m,
                    DiscountAmount = discountAmount,
                    CouponId = couponId,
                    CommissionRate = commissionRate / 100m,
                    CommissionAmount = ((session.AmountTotal ?? 0) / 100m) * (commissionRate / 100m),
                    OrderStatus = "processing",
                    PaymentStatus = "paid",
                    Currency = currency.ToUpper(),
                    SessionStatus = "complete",
                    CustomerCountry = country,
                    CustomerEmail = user.Email ?? string.Empty,
                    CustomerName = $"{user.FirstName} {user.LastName}".Trim(),
                    CustomerPhone = user.PhoneNumber,
                    ShippingAddress = session.CustomerDetails?.Address?.Line1,
                    ShippingCity = session.CustomerDetails?.Address?.City,
                    ShippingState = session.CustomerDetails?.Address?.State,
                    ShippingPostalCode = session.CustomerDetails?.Address?.PostalCode,
                    ShippingCountry = session.CustomerDetails?.Address?.Country,
                    StripePaymentIntentId = session.PaymentIntentId ?? string.Empty,
                    StripeCheckoutSessionId = session.Id,
                    PaidAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.Orders.AddAsync(order);
                await _unitOfWork.SaveChangesAsync();

                // Create order items
                foreach (var cartItem in cartItems)
                {
                    var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductId);
                    if (product == null) continue;

                    // Find variant
                    var variants = await _unitOfWork.ProductVariants.FindAsync(v =>
                        v.ProductId == cartItem.ProductId &&
                        v.SizeId == cartItem.SizeId &&
                        v.ColorId == cartItem.ColorId);
                    var variant = variants.FirstOrDefault();
                    
                    if (variant == null) continue;

                    var size = cartItem.SizeId.HasValue ? await _unitOfWork.Sizes.GetByIdAsync(cartItem.SizeId.Value) : null;
                    var color = cartItem.ColorId.HasValue ? await _unitOfWork.Colors.GetByIdAsync(cartItem.ColorId.Value) : null;

                    var orderItem = new OrderItem
                    {
                        OrderId = order.Id,
                        ProductVariantId = variant.Id,
                        ProductName = product.Name,
                        Size = size?.Name,
                        Color = color?.Name,
                        Quantity = cartItem.Quantity,
                        UnitPrice = variant.Price,
                        TotalPrice = variant.Price * cartItem.Quantity,
                        CreatedAt = DateTime.UtcNow
                    };

                    await _unitOfWork.Repository<OrderItem>().AddAsync(orderItem);

                    // Decrease stock
                    variant.StockQuantity -= cartItem.Quantity;
                }

                // Update user's total spent and VIP tier
                user.TotalSpent += order.TotalAmount;
                var newTier = CalculateVIPTier(user.TotalSpent);
                if (user.VipTier != newTier)
                {
                    user.VipTier = newTier;
                }
                await _userManager.UpdateAsync(user);

                // Clear cart
                await _unitOfWork.Carts.ClearCartAsync(user.Id);

                // Clear coupon session
                HttpContext.Session.Remove("AppliedCouponCode");

                await _unitOfWork.SaveChangesAsync();
                
                _logger.LogInformation("Order {OrderNumber} created successfully for user {UserId}", order.OrderNumber, user.Id);

                return await BuildSuccessView(order, session);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing successful checkout for session {SessionId}", session_id);
                TempData["Error"] = _localizationService["Checkout_ProcessingError"];
                return RedirectToAction("Failure", new { session_id, reason = "processing_error" });
            }
        }

        /// <summary>
        /// Builds the success view with order and payment details
        /// </summary>
        private async Task<IActionResult> BuildSuccessView(Order order, Stripe.Checkout.Session? session)
        {
            // Get order items with product details
            var orderItems = await _unitOfWork.Repository<OrderItem>().FindAsync(oi => oi.OrderId == order.Id);
            
            var items = new List<Models.ViewModels.Checkout.CheckoutOrderItemViewModel>();
            foreach (var item in orderItems)
            {
                var variant = await _unitOfWork.ProductVariants.GetByIdAsync(item.ProductVariantId);
                var product = variant != null ? await _unitOfWork.Products.GetByIdAsync(variant.ProductId) : null;
                var productImage = product?.Images?.FirstOrDefault()?.ImageUrl;
                
                items.Add(new Models.ViewModels.Checkout.CheckoutOrderItemViewModel
                {
                    ProductId = product?.Id ?? 0,
                    ProductName = item.ProductName,
                    ProductImage = productImage != null ? $"/img/ProductImage/{productImage}" : null,
                    Size = item.Size,
                    Color = item.Color,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    TotalPrice = item.TotalPrice,
                    PackSize = product?.PackSize ?? 1
                });
            }

            // Try to get payment method info from Stripe
            string? paymentMethod = null;
            string? last4 = null;
            if (!string.IsNullOrEmpty(order.StripePaymentIntentId))
            {
                try
                {
                    var paymentIntentService = new Stripe.PaymentIntentService();
                    var paymentIntent = await paymentIntentService.GetAsync(order.StripePaymentIntentId, new Stripe.PaymentIntentGetOptions
                    {
                        Expand = new List<string> { "payment_method" }
                    });
                    
                    if (paymentIntent.PaymentMethod?.Card != null)
                    {
                        paymentMethod = paymentIntent.PaymentMethod.Card.Brand;
                        last4 = paymentIntent.PaymentMethod.Card.Last4;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Could not retrieve payment method details for order {OrderNumber}", order.OrderNumber);
                }
            }

            var viewModel = new Models.ViewModels.Checkout.CheckoutSuccessViewModel
            {
                OrderNumber = order.OrderNumber,
                OrderId = order.Id,
                OrderDate = order.CreatedAt,
                SubtotalAmount = order.SubtotalAmount,
                ShippingCost = order.ShippingCost,
                TaxAmount = order.TaxAmount,
                DiscountAmount = order.DiscountAmount,
                TotalAmount = order.TotalAmount,
                Currency = order.Currency,
                PaymentStatus = order.PaymentStatus,
                OrderStatus = order.OrderStatus,
                CustomerEmail = order.CustomerEmail,
                CustomerName = order.CustomerName,
                ShippingAddress = order.ShippingAddress,
                ShippingCity = order.ShippingCity,
                ShippingState = order.ShippingState,
                ShippingPostalCode = order.ShippingPostalCode,
                ShippingCountry = order.ShippingCountry,
                Items = items,
                VipTier = session?.Metadata?.GetValueOrDefault("vip_tier"),
                VipDiscount = decimal.TryParse(session?.Metadata?.GetValueOrDefault("vip_discount_percentage"), out var vipDisc) ? vipDisc : 0,
                PaymentIntentId = order.StripePaymentIntentId,
                PaymentMethod = paymentMethod,
                Last4 = last4
            };

            ViewData["Title"] = _localizationService["Checkout_Success_Title"];
            return View("Success", viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Failure(string? session_id, string? reason)
        {
            var viewModel = new Models.ViewModels.Checkout.CheckoutFailureViewModel
            {
                SessionId = session_id,
                FailureReason = reason ?? "unknown",
                CanRetry = true
            };

            // Get cart item count for retry button
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                var cartItems = await _unitOfWork.Carts.FindAsync(c => c.UserId == user.Id);
                viewModel.CartItemCount = cartItems.Count();
            }

            // Try to get session details if available
            if (!string.IsNullOrEmpty(session_id))
            {
                try
                {
                    var session = await _stripeService.GetCheckoutSessionAsync(session_id);
                    if (session != null)
                    {
                        viewModel.AttemptedAmount = (session.AmountTotal ?? 0) / 100m;
                        viewModel.Currency = session.Metadata?.GetValueOrDefault("currency")?.ToUpper() ?? "PLN";
                        viewModel.WasPaymentAttempted = session.PaymentStatus != "unpaid";
                        viewModel.AttemptedAt = DateTime.UtcNow;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Could not retrieve session details for failure page");
                }
            }

            // Set appropriate error message based on reason
            viewModel.ErrorMessage = reason switch
            {
                "payment_failed" => _localizationService["Checkout_PaymentFailed"],
                "payment_pending" => _localizationService["Checkout_PaymentPending"],
                "expired" => _localizationService["Checkout_SessionExpired"],
                "processing_error" => _localizationService["Checkout_ProcessingError"],
                _ => _localizationService["Checkout_Cancelled"]
            };

            ViewData["Title"] = _localizationService["Checkout_Failure_Title"];
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Cancel(string? session_id)
        {
            _logger.LogInformation("Checkout cancelled for session: {SessionId}", session_id);
            
            // Don't create cancelled order records - just redirect to failure page
            // The webhook will handle any necessary cleanup
            
            return RedirectToAction("Failure", new { session_id, reason = "cancelled" });
        }

        private string CalculateVIPTier(decimal totalSpent)
        {
            if (totalSpent >= 5000) return "Platinum";
            if (totalSpent >= 1500) return "Gold";
            if (totalSpent >= 500) return "Silver";
            if (totalSpent > 0) return "Bronze";
            return "None";
        }

        private string DetectCountry()
        {
            // Try to get country from request headers (CloudFlare, AWS, etc.)
            if (Request.Headers.ContainsKey("CF-IPCountry"))
            {
                return Request.Headers["CF-IPCountry"].ToString();
            }
            
            // Try Accept-Language header as fallback
            var languages = Request.Headers["Accept-Language"].ToString().Split(',');
            if (languages.Length > 0)
            {
                var primaryLanguage = languages[0].Split(';')[0].Trim();
                if (primaryLanguage.Contains("-"))
                {
                    var countryCode = primaryLanguage.Split('-')[1].ToUpper();
                    return countryCode;
                }
            }
            
            // Default to Poland
            return "PL";
        }

        private string DetectCurrency()
        {
            var country = DetectCountry();
            
            // Check if country uses specific currency
            if (_currencyMap.ContainsKey(country))
            {
                return _currencyMap[country];
            }
            
            // Default to PLN for Poland and unknown countries
            return "pln";
        }

        private decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            if (fromCurrency == toCurrency)
                return amount;

            // Simple conversion rates (in production, use real-time rates API)
            var rates = new Dictionary<string, decimal>
            {
                { "pln", 1.0m },
                { "eur", 0.22m }, // 1 PLN ≈ 0.22 EUR
                { "usd", 0.24m }  // 1 PLN ≈ 0.24 USD
            };

            if (!rates.ContainsKey(fromCurrency.ToLower()) || !rates.ContainsKey(toCurrency.ToLower()))
                return amount;

            // Convert to base (PLN) then to target currency
            var baseAmount = amount / rates[fromCurrency.ToLower()];
            return baseAmount * rates[toCurrency.ToLower()];
        }

        private string GenerateOrderNumber()
        {
            return $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
        }
    }
}
