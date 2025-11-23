using Kokomija.Data.Abstract;
using Kokomija.Data;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Checkout;
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
            ILogger<CheckoutController> logger)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _userManager = userManager;
            _stripeService = stripeService;
            _localizationService = localizationService;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new CheckoutViewModel();

            // Get current user
            var user = await _userManager.GetUserAsync(User);
            model.IsGuest = user == null;

            if (user != null)
            {
                model.StripeCustomerId = user.StripeCustomerId;
                model.UserEmail = user.Email;
                model.UserFirstName = user.FirstName;
                model.UserLastName = user.LastName;
                model.UserPhone = user.PhoneNumber;

                // Pre-fill shipping address from user profile
                model.ShippingAddress = new ShippingAddressViewModel
                {
                    FirstName = user.FirstName ?? string.Empty,
                    LastName = user.LastName ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    Phone = user.PhoneNumber ?? string.Empty,
                    AddressLine1 = string.Empty // User address not stored in ApplicationUser
                };

                // Load saved payment methods
                if (!string.IsNullOrEmpty(user.StripeCustomerId))
                {
                    try
                    {
                        var paymentMethods = await _stripeService.ListCustomerPaymentMethodsAsync(user.StripeCustomerId);
                        model.SavedPaymentMethods = paymentMethods.Select(pm => new SavedPaymentMethodViewModel
                        {
                            PaymentMethodId = pm.Id,
                            Brand = pm.Card.Brand,
                            Last4 = pm.Card.Last4,
                            ExpMonth = (int)pm.Card.ExpMonth,
                            ExpYear = (int)pm.Card.ExpYear,
                            IsDefault = pm.Id == user.DefaultPaymentMethodId
                        }).ToList();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to load payment methods for customer: {CustomerId}", user.StripeCustomerId);
                    }
                }
            }

            // Get cart items
            List<Cart> cartItems;
            if (user != null)
            {
                cartItems = (await _unitOfWork.Carts.FindAsync(c => c.UserId == user.Id)).ToList();
            }
            else
            {
                // For guest users, we would get from session/cookie
                // For now, redirect to login
                return RedirectToAction("Login", "Account", new { returnUrl = "/Checkout" });
            }

            if (!cartItems.Any())
            {
                TempData["Error"] = _localizationService["Cart_Empty"];
                return RedirectToAction("Index", "Cart");
            }

            // Build checkout items
            foreach (var cartItem in cartItems)
            {
                var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductId);
                if (product == null) continue;

                // Find the variant based on ProductId, SizeId, ColorId
                var variants = await _unitOfWork.ProductVariants.GetAllAsync(v => 
                    v.ProductId == cartItem.ProductId && 
                    v.SizeId == cartItem.SizeId && 
                    v.ColorId == cartItem.ColorId);
                var variant = variants.FirstOrDefault();
                
                if (variant == null) continue;

                var size = cartItem.SizeId.HasValue ? await _unitOfWork.Sizes.GetByIdAsync(cartItem.SizeId.Value) : null;
                var color = cartItem.ColorId.HasValue ? await _unitOfWork.Colors.GetByIdAsync(cartItem.ColorId.Value) : null;

                var productImages = await _unitOfWork.Repository<ProductImage>()
                    .GetAllAsync(pi => pi.ProductId == product.Id && pi.IsPrimary);
                var productImage = productImages.FirstOrDefault();

                model.Items.Add(new CheckoutItemViewModel
                {
                    CartId = cartItem.Id,
                    ProductId = product.Id,
                    VariantId = variant.Id,
                    ProductName = product.Name,
                    ProductImage = productImage?.ImageUrl ?? "placeholder.jpg",
                    ColorName = color?.Name ?? "N/A",
                    SizeName = size?.Name ?? "N/A",
                    Quantity = cartItem.Quantity,
                    Price = variant.Price,
                    Subtotal = variant.Price * cartItem.Quantity,
                    StripePriceId = variant.StripePriceId
                });
            }

            // Calculate totals
            model.Subtotal = model.Items.Sum(i => i.Subtotal);

            // Check for applied coupon
            var couponCode = HttpContext.Session.GetString("AppliedCouponCode");
            if (!string.IsNullOrEmpty(couponCode))
            {
                var coupon = (await _unitOfWork.Coupons.GetAllAsync(c => c.Code == couponCode && c.IsActive)).FirstOrDefault();
                if (coupon != null && coupon.ValidUntil >= DateTime.Now)
                {
                    model.HasCoupon = true;
                    model.CouponCode = couponCode;

                    if (coupon.DiscountType == "percentage")
                    {
                        model.Discount = model.Subtotal * (coupon.DiscountValue / 100);
                        if (coupon.MaximumDiscountAmount.HasValue)
                        {
                            model.Discount = Math.Min(model.Discount, coupon.MaximumDiscountAmount.Value);
                        }
                    }
                    else if (coupon.DiscountType == "fixed_amount")
                    {
                        model.Discount = coupon.DiscountValue;
                    }
                }
            }

            // Shipping cost (free if over 100 PLN or VIP member)
            decimal freeShippingThreshold = 100;
            var subtotalAfterDiscount = model.Subtotal - model.Discount;
            
            model.FreeShippingThreshold = freeShippingThreshold;
            model.QualifiesForFreeShipping = subtotalAfterDiscount >= freeShippingThreshold;
            
            // Build shipping options
            model.ShippingOptions = new List<ShippingOptionViewModel>
            {
                new ShippingOptionViewModel
                {
                    Id = "standard",
                    Name = _localizationService["Shipping_Standard"],
                    Description = _localizationService["Shipping_Standard_Desc"],
                    Cost = model.QualifiesForFreeShipping ? 0 : 9.99m,
                    DeliveryTime = "3-7 " + _localizationService["Shipping_BusinessDays"],
                    IsDefault = true
                },
                new ShippingOptionViewModel
                {
                    Id = "express",
                    Name = _localizationService["Shipping_Express"],
                    Description = _localizationService["Shipping_Express_Desc"],
                    Cost = model.QualifiesForFreeShipping ? 5m : 19.99m,
                    DeliveryTime = "1-2 " + _localizationService["Shipping_BusinessDays"],
                    IsDefault = false
                }
            };
            
            if (user != null)
            {
                // Check VIP status
                var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(user.Id);
                var totalSpent = orders.Sum(o => o.TotalAmount);
                
                // VIP members get free shipping at Silver tier and above ($500+)
                if (totalSpent >= 500)
                {
                    model.ShippingCost = 0;
                    model.QualifiesForFreeShipping = true;
                    foreach (var option in model.ShippingOptions)
                    {
                        option.Cost = 0;
                    }
                }
                else
                {
                    model.ShippingCost = model.ShippingOptions.First(o => o.IsDefault).Cost;
                }
            }
            else
            {
                model.ShippingCost = model.ShippingOptions.First(o => o.IsDefault).Cost;
            }

            // Tax (23% VAT for Poland - INCLUSIVE, meaning it's already in the price)
            // To calculate inclusive tax: price * (tax_rate / (100 + tax_rate))
            // For 23% VAT: price * (23 / 123) = price * 0.1869918699...
            var taxableAmount = subtotalAfterDiscount + model.ShippingCost;
            model.Tax = taxableAmount * (23m / 123m); // Tax component that's already included in price

            // Total (tax is already included in prices, so total = subtotal after discount + shipping)
            model.Total = subtotalAfterDiscount + model.ShippingCost;

            // Stripe publishable key
            model.StripePublishableKey = _configuration["Stripe:PublishableKey"];

            ViewData["Title"] = _localizationService["Checkout_Title"];
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCheckoutSession([FromBody] CreateCheckoutSessionRequest? request)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                // Get selected shipping option
                var shippingOption = request?.ShippingOption ?? "standard";

                // Get cart items
                var cartItems = (await _unitOfWork.Carts.FindAsync(c => c.UserId == user.Id)).ToList();
                if (!cartItems.Any())
                {
                    return Json(new { success = false, message = _localizationService["Cart_Empty"] });
                }

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
                var couponCode = HttpContext.Session.GetString("AppliedCouponCode");

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

                    // Apply VIP discount to the price (Stripe will handle coupon separately)
                    decimal originalPrice = variant.Price;
                    decimal discountedPrice = originalPrice * (1 - (vipDiscountPercentage / 100));
                    
                    // Convert to grosze (cents) for Stripe
                    long priceInGrosze = (long)(discountedPrice * 100);

                    _logger.LogInformation($"Product {product.Name}: Original {originalPrice} PLN, VIP Discounted {discountedPrice} PLN ({vipDiscountPercentage}% off)");

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
                
                // Check if user qualifies for free shipping
                var subtotalAfterDiscount = cartItems.Sum(c => _unitOfWork.Products.GetByIdAsync(c.ProductId).Result?.Price ?? 0) * (1 - (vipDiscountPercentage / 100));
                var freeShippingThreshold = 100m;
                var qualifiesForFreeShipping = subtotalAfterDiscount >= freeShippingThreshold;
                
                // Check VIP status for free shipping
                var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(user.Id);
                var totalSpent = orders.Sum(o => o.TotalAmount);
                if (totalSpent >= 500)
                {
                    qualifiesForFreeShipping = true;
                }

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
                    Metadata = metadata,
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
                if (shippingOption == "express")
                {
                    var expressCost = qualifiesForFreeShipping ? 500 : 1999; // 5 PLN or 19.99 PLN
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
                            DisplayName = qualifiesForFreeShipping ? "Express Shipping (Discounted)" : "Express Shipping",
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
                else // standard
                {
                    var standardCost = qualifiesForFreeShipping ? 0 : 999; // Free or 9.99 PLN
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
                            DisplayName = qualifiesForFreeShipping ? "Standard Shipping (Free)" : "Standard Shipping",
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
                
                // Set customer or email (not both)
                if (!string.IsNullOrEmpty(user.StripeCustomerId))
                {
                    options.Customer = user.StripeCustomerId;
                }
                else if (!string.IsNullOrEmpty(user.Email))
                {
                    options.CustomerEmail = user.Email;
                }
                
                // Apply coupon discount if exists, otherwise allow promotion codes
                if (!string.IsNullOrEmpty(couponCode))
                {
                    var coupon = await _unitOfWork.Coupons.GetByCodeAsync(couponCode);
                    if (coupon != null && coupon.IsActive && !string.IsNullOrEmpty(coupon.StripePromotionCodeId))
                    {
                        options.Discounts = new List<SessionDiscountOptions>
                        {
                            new SessionDiscountOptions { PromotionCode = coupon.StripePromotionCodeId }
                        };
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
                return RedirectToAction("Index", "Home");
            }

            try
            {
                // Retrieve the session
                var session = await _stripeService.GetCheckoutSessionAsync(session_id);

                if (session.PaymentStatus == "paid")
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        // Create order from cart
                        var cartItems = (await _unitOfWork.Carts.FindAsync(c => c.UserId == user.Id)).ToList();

                        // Extract currency and country from session metadata
                        var currency = session.Metadata?.ContainsKey("currency") == true ? session.Metadata["currency"] : "pln";
                        var country = session.Metadata?.ContainsKey("country") == true ? session.Metadata["country"] : "PL";

                        var order = new Order
                        {
                            UserId = user.Id,
                            OrderNumber = GenerateOrderNumber(),
                            TotalAmount = (session.AmountTotal ?? 0) / 100m, // Convert from cents
                            SubtotalAmount = (session.AmountSubtotal ?? 0) / 100m,
                            TaxAmount = (session.TotalDetails?.AmountTax ?? 0) / 100m,
                            ShippingCost = (session.TotalDetails?.AmountShipping ?? 0) / 100m,
                            OrderStatus = "processing",
                            PaymentStatus = "paid",
                            Currency = currency,
                            SessionStatus = "complete",
                            CustomerCountry = country,
                            CustomerEmail = user.Email ?? string.Empty,
                            CustomerName = $"{user.FirstName} {user.LastName}",
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
                            var variants = await _unitOfWork.ProductVariants.GetAllAsync(v =>
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

                        // Clear cart
                        await _unitOfWork.Carts.ClearCartAsync(user.Id);

                        // Clear coupon session
                        HttpContext.Session.Remove("AppliedCouponCode");

                        await _unitOfWork.SaveChangesAsync();

                        ViewBag.OrderNumber = order.OrderNumber;
                        ViewBag.OrderTotal = order.TotalAmount;
                    }
                }

                ViewData["Title"] = _localizationService["Checkout_Success_Title"];
                return View();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing successful checkout");
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cancel(string session_id)
        {
            // Track cancelled session
            if (!string.IsNullOrEmpty(session_id))
            {
                try
                {
                    var session = await _stripeService.GetCheckoutSessionAsync(session_id);
                    var user = await _userManager.GetUserAsync(User);
                    
                    if (user != null && session != null)
                    {
                        var currency = session.Metadata?.ContainsKey("currency") == true ? session.Metadata["currency"] : "pln";
                        var country = session.Metadata?.ContainsKey("country") == true ? session.Metadata["country"] : "PL";

                        // Create order record for cancelled session
                        var order = new Order
                        {
                            UserId = user.Id,
                            OrderNumber = GenerateOrderNumber(),
                            TotalAmount = (session.AmountTotal ?? 0) / 100m,
                            SubtotalAmount = (session.AmountSubtotal ?? 0) / 100m,
                            OrderStatus = "cancelled",
                            PaymentStatus = "cancelled",
                            Currency = currency,
                            SessionStatus = "cancelled",
                            CustomerCountry = country,
                            CustomerEmail = user.Email ?? string.Empty,
                            CustomerName = $"{user.FirstName} {user.LastName}",
                            StripeCheckoutSessionId = session.Id,
                            CreatedAt = DateTime.UtcNow
                        };

                        await _unitOfWork.Orders.AddAsync(order);
                        await _unitOfWork.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error tracking cancelled session");
                }
            }

            TempData["Info"] = _localizationService["Checkout_Cancelled"];
            return RedirectToAction("Index", "Cart");
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
