using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Cart;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Kokomija.Controllers
{
    [Route("Cart")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<CartController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IShippingService _shippingService;
        private readonly INIPValidationService _nipValidationService;
        private readonly IStripeService _stripeService;

        public CartController(
            IUnitOfWork unitOfWork,
            ILocalizationService localizationService,
            ILogger<CartController> logger,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration,
            IShippingService shippingService,
            INIPValidationService nipValidationService,
            IStripeService stripeService)
        {
            _unitOfWork = unitOfWork;
            _localizationService = localizationService;
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            _shippingService = shippingService;
            _nipValidationService = nipValidationService;
            _stripeService = stripeService;
        }

        #region View Actions

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            // Redirect to login if not authenticated
            if (User.Identity?.IsAuthenticated != true)
            {
                // Store the return URL so user can continue after login
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Cart") });
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Index", "Cart") });
            }

            var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(userId);
            
            // Check for applied coupon in session
            Coupon? appliedCoupon = null;
            var couponCode = HttpContext.Session.GetString("AppliedCouponCode");
            if (!string.IsNullOrEmpty(couponCode))
            {
                appliedCoupon = await _unitOfWork.Coupons.GetByCodeAsync(couponCode);
            }
            
            var viewModel = await BuildCartViewModel(cartItems, appliedCoupon);

            ViewData["Title"] = _localizationService["Cart_Title"];
            ViewBag.StripePublishableKey = _configuration["Stripe:PublishableKey"];
            return View(viewModel);
        }

        #endregion

        #region API Actions - Cart Management

        [HttpPost("api/add")]
        public async Task<IActionResult> AddToCart([FromBody] CartAddRequest request)
        {
            // If not authenticated, return unauthorized - client will redirect to login
            if (User.Identity?.IsAuthenticated != true)
            {
                return Json(new { success = false, message = "Please login to add items to cart", requiresLogin = true });
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Json(new { success = false, message = "Unauthorized", requiresLogin = true });

            try
            {
                // Check if item already exists in cart
                var existingItem = await _unitOfWork.Carts.GetCartItemAsync(
                    userId,
                    request.ProductId,
                    request.ColorId,
                    request.SizeId);

                if (existingItem != null)
                {
                    // Update quantity
                    existingItem.Quantity += request.Quantity;
                }
                else
                {
                    // Add new item
                    var cartItem = new Cart
                    {
                        UserId = userId,
                        ProductId = request.ProductId,
                        ColorId = request.ColorId,
                        SizeId = request.SizeId,
                        Quantity = request.Quantity,
                        AddedAt = DateTime.UtcNow
                    };

                    await _unitOfWork.Carts.AddAsync(cartItem);
                }

                await _unitOfWork.SaveChangesAsync();

                var count = await _unitOfWork.Carts.GetCartCountAsync(userId);
                return Json(new { success = true, count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding to cart");
                return Json(new { success = false, message = "An error occurred" });
            }
        }

        [Authorize]
        [HttpPost("api/update-quantity")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateCartItemRequest request)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Unauthorized" });
            }

            try
            {
                var cartItem = await _unitOfWork.Carts.GetCartItemAsync(
                    userId,
                    request.ProductId,
                    request.ColorId,
                    request.SizeId);

                if (cartItem == null)
                {
                    return Json(new { success = false, message = "Item not found in cart" });
                }

                if (request.Quantity <= 0)
                {
                    _unitOfWork.Carts.Remove(cartItem);
                }
                else
                {
                    cartItem.Quantity = request.Quantity;
                }

                await _unitOfWork.SaveChangesAsync();

                // Recalculate cart totals
                var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(userId);
                var updatedViewModel = await BuildCartViewModel(cartItems);

                return Json(new
                {
                    success = true,
                    subtotal = updatedViewModel.Subtotal,
                    shippingCost = updatedViewModel.ShippingCost,
                    discountAmount = updatedViewModel.DiscountAmount,
                    taxAmount = updatedViewModel.TaxAmount,
                    total = updatedViewModel.Total,
                    itemCount = cartItems.Count(),
                    hasFreeShipping = updatedViewModel.HasFreeShipping,
                    remainingForFreeShipping = updatedViewModel.RemainingForFreeShipping
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cart quantity");
                return Json(new { success = false, message = "An error occurred" });
            }
        }

        [Authorize]
        [HttpPost("api/remove")]
        public async Task<IActionResult> RemoveItem([FromBody] RemoveCartItemRequest request)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Unauthorized" });
            }

            try
            {
                var cartItem = await _unitOfWork.Carts.GetCartItemAsync(
                    userId,
                    request.ProductId,
                    request.ColorId,
                    request.SizeId);

                if (cartItem != null)
                {
                    _unitOfWork.Carts.Remove(cartItem);
                    await _unitOfWork.SaveChangesAsync();
                }

                // Recalculate cart totals
                var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(userId);
                var updatedViewModel = await BuildCartViewModel(cartItems);

                return Json(new
                {
                    success = true,
                    subtotal = updatedViewModel.Subtotal,
                    shippingCost = updatedViewModel.ShippingCost,
                    discountAmount = updatedViewModel.DiscountAmount,
                    taxAmount = updatedViewModel.TaxAmount,
                    total = updatedViewModel.Total,
                    itemCount = cartItems.Count(),
                    hasFreeShipping = updatedViewModel.HasFreeShipping,
                    remainingForFreeShipping = updatedViewModel.RemainingForFreeShipping
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing cart item");
                return Json(new { success = false, message = "An error occurred" });
            }
        }

        [AllowAnonymous]
        [HttpGet("api/items")]
        public async Task<IActionResult> GetCartItems()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Json(new List<object>());

            var items = await _unitOfWork.Carts.GetByUserIdAsync(userId);

            var cartItems = items.Select(c => new
            {
                productId = c.ProductId,
                productName = c.Product.Name,
                colorId = c.ColorId,
                colorName = c.Color?.DisplayName,
                sizeId = c.SizeId,
                sizeName = c.Size?.DisplayName,
                quantity = c.Quantity,
                price = c.Product.Price,
                imageUrl = c.Product.Images.FirstOrDefault()?.ImageUrl ?? "logo_black.png"
            });

            return Json(cartItems);
        }

        [Authorize]
        [HttpGet("api/count")]
        public async Task<IActionResult> GetCartCount()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Json(new { count = 0 });

            var count = await _unitOfWork.Carts.GetCartCountAsync(userId);
            return Json(new { count });
        }

        [Authorize]
        [HttpPost("api/merge")]
        public async Task<IActionResult> MergeGuestCart([FromBody] List<GuestCartItem> guestItems)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Json(new { success = false, message = "Unauthorized" });

            try
            {
                foreach (var guestItem in guestItems)
                {
                    var existingItem = await _unitOfWork.Carts.GetCartItemAsync(
                        userId,
                        guestItem.ProductId,
                        guestItem.ColorId,
                        guestItem.SizeId);

                    if (existingItem != null)
                    {
                        existingItem.Quantity += guestItem.Quantity;
                    }
                    else
                    {
                        var cartItem = new Cart
                        {
                            UserId = userId,
                            ProductId = guestItem.ProductId,
                            ColorId = guestItem.ColorId,
                            SizeId = guestItem.SizeId,
                            Quantity = guestItem.Quantity,
                            AddedAt = DateTime.UtcNow
                        };

                        await _unitOfWork.Carts.AddAsync(cartItem);
                    }
                }

                await _unitOfWork.SaveChangesAsync();
                var count = await _unitOfWork.Carts.GetCartCountAsync(userId);

                return Json(new { success = true, count });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error merging guest cart");
                return Json(new { success = false, message = "An error occurred" });
            }
        }

        #endregion

        #region Coupon Management

        [Authorize]
        [HttpPost("api/apply-coupon")]
        public async Task<IActionResult> ApplyCoupon([FromBody] ApplyCouponRequest request)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Unauthorized" });
            }

            try
            {
                // Validate coupon code
                var coupon = await _unitOfWork.Coupons.GetByCodeAsync(request.CouponCode);

                if (coupon == null)
                {
                    return Json(new { success = false, message = _localizationService["Cart_Coupon_Invalid"] });
                }

                if (!coupon.IsActive)
                {
                    return Json(new { success = false, message = _localizationService["Cart_Coupon_Inactive"] });
                }

                // Verify coupon still exists on Stripe — if deleted there, remove locally
                if (!string.IsNullOrEmpty(coupon.StripeCouponId))
                {
                    var validOnStripe = await _stripeService.IsCouponValidOnStripeAsync(coupon.StripeCouponId);
                    if (!validOnStripe)
                    {
                        _logger.LogWarning("Coupon {Code} no longer valid on Stripe, removing from database", coupon.Code);
                        _unitOfWork.Repository<Coupon>().Remove(coupon);
                        await _unitOfWork.SaveChangesAsync();
                        return Json(new { success = false, message = _localizationService["Cart_Coupon_Invalid"] });
                    }
                }

                if (coupon.ValidUntil.HasValue && coupon.ValidUntil.Value < DateTime.UtcNow)
                {
                    var expiredDate = coupon.ValidUntil.Value.ToString("dd/MM/yyyy");
                    return Json(new { success = false, message = $"{_localizationService["Cart_Coupon_Expired"]} ({expiredDate})" });
                }

                if (coupon.UsageLimit.HasValue && coupon.UsageCount >= coupon.UsageLimit.Value)
                {
                    return Json(new { success = false, message = _localizationService["Cart_Coupon_LimitReached"] });
                }

                // Check if user has already used this coupon (check per-user limit)
                var usageCount = await _unitOfWork.Repository<CouponUsage>()
                    .CountAsync(cu => cu.CouponId == coupon.Id && cu.UserId == userId);

                if (coupon.UsageLimitPerUser.HasValue && usageCount >= coupon.UsageLimitPerUser.Value)
                {
                    return Json(new { success = false, message = _localizationService["Cart_Coupon_AlreadyUsed"] });
                }

                // Birthday coupon eligibility check
                if (coupon.CouponType == "birthday")
                {
                    var currentUser = await _userManager.FindByIdAsync(userId);
                    if (currentUser?.Birthday == null)
                    {
                        return Json(new { success = false, message = "This coupon is only valid around your birthday. Please set your birthday in your account settings." });
                    }

                    var today = DateTime.UtcNow.Date;
                    var birthday = currentUser.Birthday.Value;
                    // Build this year's birthday date
                    var thisYearBirthday = new DateTime(today.Year, birthday.Month, birthday.Day);
                    
                    var daysBefore = coupon.DaysBeforeBirthday ?? 7;
                    var daysAfter = coupon.DaysAfterBirthday ?? 7;
                    var windowStart = thisYearBirthday.AddDays(-daysBefore);
                    var windowEnd = thisYearBirthday.AddDays(daysAfter);

                    if (today < windowStart || today > windowEnd)
                    {
                        return Json(new { success = false, message = "This birthday coupon is only valid around your birthday." });
                    }
                }

                // New user coupon eligibility check
                if (coupon.CouponType == "new_user")
                {
                    var currentUser = await _userManager.FindByIdAsync(userId);
                    if (currentUser != null && coupon.AccountAgeDays.HasValue)
                    {
                        var accountAge = (DateTime.UtcNow - currentUser.CreatedAt).TotalDays;
                        if (accountAge > coupon.AccountAgeDays.Value)
                        {
                            return Json(new { success = false, message = $"This coupon is only valid for accounts created within the last {coupon.AccountAgeDays.Value} days." });
                        }
                    }
                }

                // First purchase coupon eligibility check
                if (coupon.CouponType == "first_purchase")
                {
                    var userOrders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
                    if (userOrders.Any())
                    {
                        return Json(new { success = false, message = "This coupon is only valid for your first purchase." });
                    }
                }

                // VIP tier coupon eligibility check
                if (!string.IsNullOrEmpty(coupon.VipTierRequired))
                {
                    var currentUser = await _userManager.FindByIdAsync(userId);
                    var userTier = currentUser?.VipTier ?? "None";
                    var tierOrder = new Dictionary<string, int> { { "None", 0 }, { "Bronze", 1 }, { "Silver", 2 }, { "Gold", 3 }, { "Platinum", 4 } };
                    var userTierLevel = tierOrder.GetValueOrDefault(userTier, 0);
                    var requiredTierLevel = tierOrder.GetValueOrDefault(coupon.VipTierRequired, 0);

                    if (userTierLevel < requiredTierLevel)
                    {
                        return Json(new { success = false, message = $"This coupon requires {coupon.VipTierRequired} VIP tier or higher." });
                    }
                }

                // Category restriction check
                if (coupon.CategoryId.HasValue)
                {
                    var cartItemsForCheck = await _unitOfWork.Carts.GetByUserIdAsync(userId);
                    var hasMatchingCategory = cartItemsForCheck.Any(ci => ci.Product?.CategoryId == coupon.CategoryId.Value);
                    if (!hasMatchingCategory)
                    {
                        var category = await _unitOfWork.Categories.GetByIdAsync(coupon.CategoryId.Value);
                        var categoryName = category?.Name ?? "the required category";
                        return Json(new { success = false, message = $"This coupon is only valid for products in the '{categoryName}' category." });
                    }
                }

                // Product restriction check
                if (coupon.ProductId.HasValue)
                {
                    var cartItemsForCheck = await _unitOfWork.Carts.GetByUserIdAsync(userId);
                    var hasMatchingProduct = cartItemsForCheck.Any(ci => ci.ProductId == coupon.ProductId.Value);
                    if (!hasMatchingProduct)
                    {
                        var product = await _unitOfWork.Products.GetByIdAsync(coupon.ProductId.Value);
                        var productName = product?.Name ?? "the required product";
                        return Json(new { success = false, message = $"This coupon is only valid for '{productName}'." });
                    }
                }

                // Check minimum order amount
                var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(userId);
                decimal subtotal = cartItems.Sum(c => c.Product.Price * c.Quantity);

                if (coupon.MinimumOrderAmount.HasValue && subtotal < coupon.MinimumOrderAmount.Value)
                {
                    var minimumAmount = coupon.MinimumOrderAmount.Value.ToString("C", new System.Globalization.CultureInfo("pl-PL"));
                    return Json(new { success = false, message = $"{_localizationService["Cart_Coupon_MinimumAmount"]} {minimumAmount}" });
                }

                // Apply coupon - recalculate cart with discount
                var updatedViewModel = await BuildCartViewModel(cartItems, coupon);

                // Store coupon in session
                HttpContext.Session.SetString("AppliedCouponCode", coupon.Code);

                return Json(new
                {
                    success = true,
                    message = _localizationService["Cart_Coupon_Applied"],
                    couponCode = coupon.Code,
                    discountValue = coupon.DiscountValue,
                    discountType = coupon.DiscountType,
                    subtotal = updatedViewModel.Subtotal,
                    discountAmount = updatedViewModel.DiscountAmount,
                    shippingCost = updatedViewModel.ShippingCost,
                    taxAmount = updatedViewModel.TaxAmount,
                    total = updatedViewModel.Total
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error applying coupon");
                return Json(new { success = false, message = "An error occurred" });
            }
        }

        [Authorize]
        [HttpPost("api/remove-coupon")]
        public async Task<IActionResult> RemoveCoupon()
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Unauthorized" });
            }

            try
            {
                // Remove coupon from session
                HttpContext.Session.Remove("AppliedCouponCode");

                // Recalculate cart without discount
                var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(userId);
                var updatedViewModel = await BuildCartViewModel(cartItems);

                return Json(new
                {
                    success = true,
                    subtotal = updatedViewModel.Subtotal,
                    discountAmount = updatedViewModel.DiscountAmount,
                    shippingCost = updatedViewModel.ShippingCost,
                    taxAmount = updatedViewModel.TaxAmount,
                    total = updatedViewModel.Total
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing coupon");
                return Json(new { success = false, message = "An error occurred" });
            }
        }

        #endregion

        #region Private Helper Methods

        private async Task<bool> IsBusinessModeActiveAsync()
        {
            if (User.Identity?.IsAuthenticated != true) return false;
            
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId)) return false;
            
            var businessProfile = await _nipValidationService.GetBusinessProfileAsync(userId);
            return businessProfile?.IsVerified == true && businessProfile?.IsBusinessModeActive == true;
        }

        private async Task<CartIndexViewModel> BuildCartViewModel(
            IEnumerable<Cart> cartItems,
            Coupon? appliedCoupon = null)
        {
            var items = new List<CartItemViewModel>();
            decimal subtotal = 0;
            
            // Check if user is in business mode
            bool isBusinessMode = await IsBusinessModeActiveAsync();

            foreach (var cartItem in cartItems)
            {
                // Get product variant for stock check
                var variant = await _unitOfWork.ProductVariants.GetVariantAsync(
                    cartItem.ProductId,
                    cartItem.SizeId,
                    cartItem.ColorId);

                // Get base price (from variant or product)
                decimal basePrice = variant?.Price ?? cartItem.Product.Price;
                
                // Apply business price if in business mode and product has business price
                decimal effectivePrice = basePrice;
                bool isBusinessPrice = false;
                
                if (isBusinessMode && cartItem.Product.IsAvailableForBusiness)
                {
                    // Use business price if available, otherwise use regular price
                    if (cartItem.Product.BusinessPrice.HasValue)
                    {
                        effectivePrice = cartItem.Product.BusinessPrice.Value;
                        isBusinessPrice = true;
                    }
                }

                var itemViewModel = new CartItemViewModel
                {
                    Id = cartItem.Id,
                    ProductId = cartItem.ProductId,
                    ProductName = cartItem.Product.Name,
                    ProductImage = cartItem.Product.Images.FirstOrDefault()?.ImageUrl,
                    ProductSlug = cartItem.Product.Category?.Slug ?? "product",
                    ColorId = cartItem.ColorId,
                    ColorName = cartItem.Color?.DisplayName,
                    ColorHex = cartItem.Color?.HexCode,
                    SizeId = cartItem.SizeId,
                    SizeName = cartItem.Size?.DisplayName,
                    Quantity = cartItem.Quantity,
                    UnitPrice = effectivePrice,
                    TotalPrice = effectivePrice * cartItem.Quantity,
                    StockQuantity = variant?.StockQuantity ?? 0,
                    IsInStock = variant != null && variant.StockQuantity >= cartItem.Quantity,
                    MaxQuantity = variant?.StockQuantity ?? 10,
                    PackSize = cartItem.Product.PackSize,
                    IsBusinessPrice = isBusinessPrice,
                    OriginalPrice = isBusinessPrice ? basePrice : null,
                    MinBusinessQuantity = cartItem.Product.MinBusinessQuantity,
                    IsAvailableForBusiness = cartItem.Product.IsAvailableForBusiness
                };

                items.Add(itemViewModel);
                subtotal += itemViewModel.TotalPrice;
            }

            // Get VIP discount if user is authenticated
            decimal vipDiscountPercentage = 0;
            string vipTier = "None";
            if (User.Identity?.IsAuthenticated == true)
            {
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                {
                    var currentUser = await _userManager.FindByIdAsync(userId);
                    if (currentUser != null)
                    {
                        vipTier = currentUser.VipTier ?? "None";
                        vipDiscountPercentage = vipTier switch
                        {
                            "Bronze" => 2m,    // 2% discount
                            "Silver" => 5m,    // 5% discount
                            "Gold" => 8m,      // 8% discount
                            "Platinum" => 12m, // 12% discount
                            _ => 0m
                        };
                        
                        // Log VIP status for debugging
                        _logger.LogInformation($"User {userId} has VIP tier: {vipTier}, discount: {vipDiscountPercentage}%");
                    }
                }
            }

            // Calculate VIP discount (applied to subtotal first)
            decimal vipDiscountAmount = subtotal * (vipDiscountPercentage / 100);
            decimal subtotalAfterVip = subtotal - vipDiscountAmount;
            
            _logger.LogInformation($"Subtotal: {subtotal}, VIP Discount: {vipDiscountAmount}, After VIP: {subtotalAfterVip}");

            // Calculate coupon discount (applied to VIP-discounted price)
            decimal couponDiscountAmount = 0;
            decimal? couponDiscountPercentage = null;
            string? appliedCouponCode = null;

            if (appliedCoupon != null)
            {
                // Apply coupon to subtotal after VIP discount has been applied
                decimal amountToDiscount = subtotalAfterVip;
                
                // Check minimum order requirement (should check against original subtotal)
                if (appliedCoupon.MinimumOrderAmount.HasValue && subtotal < appliedCoupon.MinimumOrderAmount.Value)
                {
                    // Coupon not applicable, but don't fail - just don't apply it
                    appliedCouponCode = null;
                }
                else
                {
                    if (appliedCoupon.DiscountType == "percentage")
                    {
                        couponDiscountAmount = amountToDiscount * (appliedCoupon.DiscountValue / 100);
                        couponDiscountPercentage = appliedCoupon.DiscountValue;
                    }
                    else // fixed_amount
                    {
                        couponDiscountAmount = appliedCoupon.DiscountValue;
                    }

                    // Apply maximum discount limit if set
                    if (appliedCoupon.MaximumDiscountAmount.HasValue && couponDiscountAmount > appliedCoupon.MaximumDiscountAmount.Value)
                    {
                        couponDiscountAmount = appliedCoupon.MaximumDiscountAmount.Value;
                    }

                    // Don't let discount exceed the discounted subtotal
                    if (couponDiscountAmount > amountToDiscount)
                    {
                        couponDiscountAmount = amountToDiscount;
                    }

                    appliedCouponCode = appliedCoupon.Code;
                }
            }

            // Total discount (VIP + Coupon)
            decimal totalDiscountAmount = vipDiscountAmount + couponDiscountAmount;

            // Get dynamic shipping rates from database
            var availableRates = await _shippingService.GetAvailableRatesForOrderAsync("PL", subtotal);
            
            // Determine free shipping threshold from rates (use highest threshold)
            decimal freeShippingThreshold = availableRates
                .Where(r => r.FreeShippingThreshold.HasValue)
                .Select(r => r.FreeShippingThreshold!.Value)
                .DefaultIfEmpty(200.00m)
                .Max();
            
            // Check if user qualifies for free shipping via VIP status
            bool isFreeShippingVip = vipTier is "Silver" or "Gold" or "Platinum";
            bool hasFreeShippingByThreshold = subtotal >= freeShippingThreshold;
            bool hasFreeShipping = isFreeShippingVip || hasFreeShippingByThreshold;
            
            decimal remainingForFreeShipping = hasFreeShipping ? 0 : freeShippingThreshold - subtotal;
            
            // Get selected shipping option from session (default to first rate or "standard")
            var selectedShippingOption = HttpContext.Session.GetString("SelectedShippingOption") ?? 
                (availableRates.Any() ? availableRates.First().Id.ToString() : "standard");
            
            // Build shipping options from database rates
            var shippingOptions = new List<ShippingOptionModel>();
            
            if (availableRates.Any())
            {
                foreach (var rate in availableRates)
                {
                    // Calculate cost based on free shipping eligibility
                    decimal originalCost = rate.Rate;
                    decimal actualCost = originalCost;
                    bool isFree = false;
                    
                    // Check if this rate qualifies for free shipping
                    if (rate.FreeShippingThreshold.HasValue && subtotal >= rate.FreeShippingThreshold.Value)
                    {
                        actualCost = 0;
                        isFree = true;
                    }
                    else if (hasFreeShipping && rate.Zone?.ToLower().Contains("standard") == true)
                    {
                        // VIP free shipping applies to standard rates
                        actualCost = 0;
                        isFree = true;
                    }
                    else if (hasFreeShipping && rate.Zone?.ToLower().Contains("express") == true)
                    {
                        // VIP gets discounted express (e.g., 50% off)
                        actualCost = originalCost * 0.5m;
                    }
                    
                    // Calculate estimated delivery date (business days)
                    var maxDays = rate.EstimatedDaysMax > 0 ? rate.EstimatedDaysMax : 5;
                    var minDays = rate.EstimatedDaysMin > 0 ? rate.EstimatedDaysMin : 3;
                    var estimatedDeliveryDate = AddBusinessDays(DateTime.UtcNow, maxDays);
                    
                    shippingOptions.Add(new ShippingOptionModel
                    {
                        Id = rate.Id.ToString(),
                        Name = rate.Zone ?? rate.ProviderName,
                        ProviderName = rate.ProviderName,
                        Description = $"{rate.ProviderName}",
                        OriginalCost = originalCost,
                        Cost = actualCost,
                        DeliveryEstimate = minDays == maxDays 
                            ? $"{minDays}" 
                            : $"{minDays}-{maxDays}",
                        MinDays = minDays,
                        MaxDays = maxDays,
                        EstimatedDeliveryDate = estimatedDeliveryDate,
                        IsFree = isFree,
                        IsSelected = selectedShippingOption == rate.Id.ToString()
                    });
                }
            }
            else
            {
                // Fallback to default shipping options if no rates configured
                shippingOptions.Add(new ShippingOptionModel
                {
                    Id = "standard",
                    Name = _localizationService["Shipping_Standard"],
                    ProviderName = "Standard Shipping",
                    Description = _localizationService["Shipping_Standard_Desc"],
                    OriginalCost = 15.00m,
                    Cost = hasFreeShipping ? 0 : 15.00m,
                    DeliveryEstimate = "3-7",
                    MinDays = 3,
                    MaxDays = 7,
                    EstimatedDeliveryDate = AddBusinessDays(DateTime.UtcNow, 7),
                    IsFree = hasFreeShipping,
                    IsSelected = selectedShippingOption == "standard"
                });
                shippingOptions.Add(new ShippingOptionModel
                {
                    Id = "express",
                    Name = _localizationService["Shipping_Express"],
                    ProviderName = "Express Shipping",
                    Description = _localizationService["Shipping_Express_Desc"],
                    OriginalCost = 29.99m,
                    Cost = hasFreeShipping ? 14.99m : 29.99m,
                    DeliveryEstimate = "1-2",
                    MinDays = 1,
                    MaxDays = 2,
                    EstimatedDeliveryDate = AddBusinessDays(DateTime.UtcNow, 2),
                    IsFree = false,
                    IsSelected = selectedShippingOption == "express"
                });
            }
            
            // Ensure at least one option is selected
            if (!shippingOptions.Any(o => o.IsSelected) && shippingOptions.Any())
            {
                shippingOptions.First().IsSelected = true;
            }
            
            // Get shipping cost based on selected option
            var selectedOption = shippingOptions.FirstOrDefault(o => o.IsSelected) ?? shippingOptions.First();
            decimal shippingCost = selectedOption.Cost;
            decimal originalShippingCost = selectedOption.OriginalCost;

            // Calculate tax (23% VAT in Poland)
            decimal subtotalAfterDiscount = subtotal - totalDiscountAmount;
           

            // Calculate total
            decimal total = subtotalAfterDiscount + shippingCost;
            decimal taxAmount = total * (0.23m / 1.23m); // VAT included in total
            // Get available coupons for user
            var availableCoupons = await GetAvailableCouponsForUser();
            var availableCouponCards = await GetAvailableCouponCardsForUser();

            return new CartIndexViewModel
            {
                Items = items,
                Subtotal = subtotal,
                ShippingCost = shippingCost,
                OriginalShippingCost = originalShippingCost,
                DiscountAmount = totalDiscountAmount,
                VipDiscountAmount = vipDiscountAmount,
                CouponDiscountAmount = couponDiscountAmount,
                TaxAmount = taxAmount,
                Total = total,
                AppliedCouponCode = appliedCouponCode,
                CouponDiscountPercentage = couponDiscountPercentage,
                VipTier = vipTier,
                VipDiscountPercentage = vipDiscountPercentage,
                HasFreeShipping = hasFreeShipping,
                IsFreeShippingVip = isFreeShippingVip,
                FreeShippingThreshold = freeShippingThreshold,
                RemainingForFreeShipping = remainingForFreeShipping,
                AvailableCoupons = availableCoupons,
                AvailableCouponCards = availableCouponCards,
                SelectedShippingOption = selectedShippingOption,
                ShippingOptions = shippingOptions,
                IsBusinessMode = isBusinessMode
            };
        }

        [Authorize]
        [HttpPost("api/update-shipping")]
        public async Task<IActionResult> UpdateShipping([FromBody] UpdateShippingRequest request)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "Unauthorized" });
            }

            try
            {
                // Validate shipping option - accept database rate IDs or fallback "standard"/"express"
                if (string.IsNullOrWhiteSpace(request.ShippingOption))
                {
                    return Json(new { success = false, message = "Invalid shipping option" });
                }
                
                // Try to parse as database ID, otherwise accept standard/express for fallback
                bool isValidOption = int.TryParse(request.ShippingOption, out int rateId) || 
                                     request.ShippingOption == "standard" || 
                                     request.ShippingOption == "express";
                
                if (!isValidOption)
                {
                    return Json(new { success = false, message = "Invalid shipping option" });
                }

                // Store in session
                HttpContext.Session.SetString("SelectedShippingOption", request.ShippingOption);

                // Recalculate cart
                var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(userId);
                
                Coupon? appliedCoupon = null;
                var couponCode = HttpContext.Session.GetString("AppliedCouponCode");
                if (!string.IsNullOrEmpty(couponCode))
                {
                    appliedCoupon = await _unitOfWork.Coupons.GetByCodeAsync(couponCode);
                }
                
                var updatedViewModel = await BuildCartViewModel(cartItems, appliedCoupon);

                return Json(new
                {
                    success = true,
                    shippingCost = updatedViewModel.ShippingCost,
                    originalShippingCost = updatedViewModel.OriginalShippingCost,
                    total = updatedViewModel.Total,
                    taxAmount = updatedViewModel.TaxAmount,
                    hasFreeShipping = updatedViewModel.HasFreeShipping,
                    selectedOption = request.ShippingOption
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating shipping option");
                return Json(new { success = false, message = "An error occurred" });
            }
        }

        private async Task<IEnumerable<string>> GetAvailableCouponsForUser()
        {
            // Get all active coupons
            var activeCoupons = await _unitOfWork.Coupons.GetActiveCouponsAsync();
            
            // Get current user ID if authenticated
            string? userId = null;
            ApplicationUser? currentUser = null;
            if (User.Identity?.IsAuthenticated == true)
            {
                userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                    currentUser = await _userManager.FindByIdAsync(userId);
            }

            var availableCouponCodes = new List<string>();

            foreach (var coupon in activeCoupons)
            {
                // Check if coupon is for a specific user
                if (coupon.UserId != null)
                {
                    // Only show if it's for this specific user
                    if (userId != coupon.UserId)
                        continue;
                }

                // Check per-user usage limit
                if (!string.IsNullOrEmpty(userId) && coupon.UsageLimitPerUser.HasValue)
                {
                    var userUsageCount = await _unitOfWork.Coupons.GetUserUsageCountAsync(coupon.Id, userId);
                    if (userUsageCount >= coupon.UsageLimitPerUser.Value)
                        continue;
                }

                // Check global usage limit
                if (coupon.UsageLimit.HasValue && coupon.UsageCount >= coupon.UsageLimit.Value)
                    continue;

                // Skip type-specific coupons user isn't eligible for
                if (!await IsUserEligibleForCouponAsync(coupon, userId, currentUser))
                    continue;

                // Coupon is available for this user
                availableCouponCodes.Add(coupon.Code);
            }

            return availableCouponCodes;
        }
        
        private async Task<List<Models.ViewModels.CouponCardViewModel>> GetAvailableCouponCardsForUser()
        {
            var activeCoupons = await _unitOfWork.Coupons.GetActiveCouponsAsync();
            string? userId = null;
            ApplicationUser? currentUser = null;
            if (User.Identity?.IsAuthenticated == true)
            {
                userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(userId))
                    currentUser = await _userManager.FindByIdAsync(userId);
            }

            var cards = new List<Models.ViewModels.CouponCardViewModel>();
            foreach (var coupon in activeCoupons)
            {
                if (coupon.UserId != null && userId != coupon.UserId) continue;
                if (!string.IsNullOrEmpty(userId) && coupon.UsageLimitPerUser.HasValue)
                {
                    var usage = await _unitOfWork.Coupons.GetUserUsageCountAsync(coupon.Id, userId);
                    if (usage >= coupon.UsageLimitPerUser.Value) continue;
                }
                if (coupon.UsageLimit.HasValue && coupon.UsageCount >= coupon.UsageLimit.Value) continue;

                // Skip type-specific coupons user isn't eligible for
                if (!await IsUserEligibleForCouponAsync(coupon, userId, currentUser))
                    continue;

                cards.Add(new Models.ViewModels.CouponCardViewModel
                {
                    Id = coupon.Id,
                    Code = coupon.Code,
                    Description = coupon.Description,
                    DiscountType = coupon.DiscountType,
                    DiscountValue = coupon.DiscountValue,
                    CouponType = coupon.CouponType,
                    MinimumOrderAmount = coupon.MinimumOrderAmount,
                    MaximumDiscountAmount = coupon.MaximumDiscountAmount,
                    ValidUntil = coupon.ValidUntil,
                    IsNew = coupon.CreatedAt >= DateTime.UtcNow.AddDays(-7),
                    CategoryName = coupon.Category?.Name,
                    ProductName = coupon.Product?.Name
                });
            }
            return cards;
        }

        /// <summary>
        /// Checks if user is eligible for a coupon based on its type (birthday, new_user, first_purchase, vip)
        /// </summary>
        private async Task<bool> IsUserEligibleForCouponAsync(Coupon coupon, string? userId, ApplicationUser? user)
        {
            // Birthday: only show during birthday window
            if (coupon.CouponType == "birthday")
            {
                if (user?.Birthday == null) return false;
                var today = DateTime.UtcNow.Date;
                var thisYearBirthday = new DateTime(today.Year, user.Birthday.Value.Month, user.Birthday.Value.Day);
                var daysBefore = coupon.DaysBeforeBirthday ?? 7;
                var daysAfter = coupon.DaysAfterBirthday ?? 7;
                if (today < thisYearBirthday.AddDays(-daysBefore) || today > thisYearBirthday.AddDays(daysAfter))
                    return false;
            }

            // New user: only show if account is young enough
            if (coupon.CouponType == "new_user" && coupon.AccountAgeDays.HasValue)
            {
                if (user == null) return false;
                if ((DateTime.UtcNow - user.CreatedAt).TotalDays > coupon.AccountAgeDays.Value)
                    return false;
            }

            // First purchase: only show if user has no orders
            if (coupon.CouponType == "first_purchase")
            {
                if (string.IsNullOrEmpty(userId)) return false;
                var userOrders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
                if (userOrders.Any()) return false;
            }

            // VIP tier: only show if user meets tier requirement
            if (!string.IsNullOrEmpty(coupon.VipTierRequired))
            {
                var userTier = user?.VipTier ?? "None";
                var tierOrder = new Dictionary<string, int> { { "None", 0 }, { "Bronze", 1 }, { "Silver", 2 }, { "Gold", 3 }, { "Platinum", 4 } };
                if (tierOrder.GetValueOrDefault(userTier, 0) < tierOrder.GetValueOrDefault(coupon.VipTierRequired, 0))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Adds business days to a date, skipping weekends
        /// </summary>
        private DateTime AddBusinessDays(DateTime startDate, int businessDays)
        {
            var currentDate = startDate;
            var daysAdded = 0;

            while (daysAdded < businessDays)
            {
                currentDate = currentDate.AddDays(1);
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysAdded++;
                }
            }

            return currentDate;
        }

        #endregion
    }

    #region Request Models

    public class CartAddRequest
    {
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int Quantity { get; set; } = 1;
    }

    public class UpdateCartItemRequest
    {
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int Quantity { get; set; }
    }

    public class RemoveCartItemRequest
    {
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
    }

    public class ApplyCouponRequest
    {
        public string CouponCode { get; set; } = string.Empty;
    }

    public class GuestCartItem
    {
        public int ProductId { get; set; }
        public int? ColorId { get; set; }
        public int? SizeId { get; set; }
        public int Quantity { get; set; }
    }

    public class UpdateShippingRequest
    {
        public string ShippingOption { get; set; } = "standard";
    }

    #endregion
}
