using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Checkout;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace Kokomija.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStripeService _stripeService;
        private readonly ILocalizationService _localizationService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> userManager,
            IStripeService stripeService,
            ILocalizationService localizationService,
            IConfiguration configuration,
            ILogger<CheckoutController> logger)
        {
            _unitOfWork = unitOfWork;
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
                cartItems = (await _unitOfWork.Carts.GetAllAsync(c => c.UserId == user.Id)).ToList();
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
            var couponCode = HttpContext.Session.GetString("CouponCode");
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
            
            if (user != null)
            {
                // Check VIP status
                var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(user.Id);
                var totalSpent = orders.Sum(o => o.TotalAmount);
                
                // VIP members get free shipping at Silver tier and above ($500+)
                if (totalSpent >= 500)
                {
                    model.ShippingCost = 0;
                }
                else if (subtotalAfterDiscount >= freeShippingThreshold)
                {
                    model.ShippingCost = 0;
                }
                else
                {
                    model.ShippingCost = 15; // 15 PLN standard shipping
                }
            }
            else
            {
                model.ShippingCost = subtotalAfterDiscount >= freeShippingThreshold ? 0 : 15;
            }

            // Tax (23% VAT for Poland)
            model.Tax = (subtotalAfterDiscount + model.ShippingCost) * 0.23m;

            // Total
            model.Total = subtotalAfterDiscount + model.ShippingCost + model.Tax;

            // Stripe publishable key
            model.StripePublishableKey = _configuration["Stripe:PublishableKey"];

            ViewData["Title"] = _localizationService["Checkout_Title"];
            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCheckoutSession()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Json(new { success = false, message = "User not found" });
                }

                // Get cart items
                var cartItems = (await _unitOfWork.Carts.GetAllAsync(c => c.UserId == user.Id)).ToList();
                if (!cartItems.Any())
                {
                    return Json(new { success = false, message = _localizationService["Cart_Empty"] });
                }

                // Build Stripe line items
                var lineItems = new List<SessionLineItemOptions>();

                foreach (var cartItem in cartItems)
                {
                    var product = await _unitOfWork.Products.GetByIdAsync(cartItem.ProductId);
                    if (product == null) continue;

                    // Find variant based on ProductId, SizeId, ColorId
                    var variants = await _unitOfWork.ProductVariants.GetAllAsync(v =>
                        v.ProductId == cartItem.ProductId &&
                        v.SizeId == cartItem.SizeId &&
                        v.ColorId == cartItem.ColorId);
                    var variant = variants.FirstOrDefault();
                    
                    if (variant == null) continue;

                    // Use variant's Stripe Price ID
                    if (!string.IsNullOrEmpty(variant.StripePriceId))
                    {
                        lineItems.Add(new SessionLineItemOptions
                        {
                            Price = variant.StripePriceId,
                            Quantity = cartItem.Quantity
                        });
                    }
                    else
                    {
                        // Fallback: create price on the fly (not recommended for production)
                        _logger.LogWarning($"Variant {variant.SKU} missing StripePriceId, using fallback");
                        
                        lineItems.Add(new SessionLineItemOptions
                        {
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                Currency = "pln",
                                UnitAmount = (long)(variant.Price * 100),
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = $"{product.Name} ({variant.SKU})",
                                    Description = product.Description
                                }
                            },
                            Quantity = cartItem.Quantity
                        });
                    }
                }

                // Create metadata
                var metadata = new Dictionary<string, string>
                {
                    { "user_id", user.Id },
                    { "cart_items_count", cartItems.Count.ToString() }
                };

                // Add coupon if applied
                var couponCode = HttpContext.Session.GetString("CouponCode");
                if (!string.IsNullOrEmpty(couponCode))
                {
                    metadata.Add("coupon_code", couponCode);
                }

                // Create Stripe Checkout Session
                var domain = $"{Request.Scheme}://{Request.Host}";
                var session = await _stripeService.CreateCheckoutSessionAsync(
                    lineItems,
                    $"{domain}/Checkout/Success?session_id={{CHECKOUT_SESSION_ID}}",
                    $"{domain}/Checkout/Cancel",
                    user.StripeCustomerId,
                    metadata
                );

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
                        var cartItems = (await _unitOfWork.Carts.GetAllAsync(c => c.UserId == user.Id)).ToList();

                        var order = new Order
                        {
                            UserId = user.Id,
                            OrderNumber = GenerateOrderNumber(),
                            TotalAmount = (session.AmountTotal ?? 0) / 100m, // Convert from cents
                            SubtotalAmount = (session.AmountSubtotal ?? 0) / 100m,
                            TaxAmount = (session.TotalDetails?.AmountTax ?? 0) / 100m,
                            OrderStatus = "processing",
                            PaymentStatus = "paid",
                            CustomerEmail = user.Email ?? string.Empty,
                            CustomerName = $"{user.FirstName} {user.LastName}",
                            CustomerPhone = user.PhoneNumber,
                            ShippingAddress = session.ShippingDetails?.Address?.Line1,
                            ShippingCity = session.ShippingDetails?.Address?.City,
                            ShippingState = session.ShippingDetails?.Address?.State,
                            ShippingPostalCode = session.ShippingDetails?.Address?.PostalCode,
                            ShippingCountry = session.ShippingDetails?.Address?.Country,
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
                        HttpContext.Session.Remove("CouponCode");

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
        public IActionResult Cancel()
        {
            TempData["Info"] = _localizationService["Checkout_Cancelled"];
            return RedirectToAction("Index", "Cart");
        }

        private string GenerateOrderNumber()
        {
            return $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}-{new Random().Next(1000, 9999)}";
        }
    }
}
