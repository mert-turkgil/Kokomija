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

        public CartController(
            IUnitOfWork unitOfWork,
            ILocalizationService localizationService,
            ILogger<CartController> logger,
            UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _localizationService = localizationService;
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
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

                if (coupon.ValidUntil.HasValue && coupon.ValidUntil.Value < DateTime.UtcNow)
                {
                    return Json(new { success = false, message = _localizationService["Cart_Coupon_Expired"] });
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

                // Apply coupon - recalculate cart with discount
                var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(userId);
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

        private async Task<CartIndexViewModel> BuildCartViewModel(
            IEnumerable<Cart> cartItems,
            Coupon? appliedCoupon = null)
        {
            var items = new List<CartItemViewModel>();
            decimal subtotal = 0;

            foreach (var cartItem in cartItems)
            {
                // Get product variant for stock check
                var variant = await _unitOfWork.ProductVariants.GetVariantAsync(
                    cartItem.ProductId,
                    cartItem.SizeId,
                    cartItem.ColorId);

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
                    UnitPrice = variant?.Price ?? cartItem.Product.Price,
                    TotalPrice = (variant?.Price ?? cartItem.Product.Price) * cartItem.Quantity,
                    StockQuantity = variant?.StockQuantity ?? 0,
                    IsInStock = variant != null && variant.StockQuantity >= cartItem.Quantity,
                    MaxQuantity = variant?.StockQuantity ?? 10,
                    PackSize = cartItem.Product.PackSize
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

            // Calculate shipping
            const decimal freeShippingThreshold = 200.00m; // PLN
            const decimal standardShippingCost = 15.00m; // PLN
            decimal shippingCost = subtotal >= freeShippingThreshold ? 0 : standardShippingCost;
            bool hasFreeShipping = subtotal >= freeShippingThreshold;
            decimal remainingForFreeShipping = hasFreeShipping ? 0 : freeShippingThreshold - subtotal;

            // Calculate tax (23% VAT in Poland)
            decimal subtotalAfterDiscount = subtotal - totalDiscountAmount;
           

            // Calculate total
            decimal total = subtotalAfterDiscount + shippingCost;
            decimal taxAmount = total * (0.23m / 1.23m); // VAT included in total
            // Get available coupons for user
            var availableCoupons = await GetAvailableCouponsForUser();

            return new CartIndexViewModel
            {
                Items = items,
                Subtotal = subtotal,
                ShippingCost = shippingCost,
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
                FreeShippingThreshold = freeShippingThreshold,
                RemainingForFreeShipping = remainingForFreeShipping,
                AvailableCoupons = availableCoupons
            };
        }

        private async Task<IEnumerable<string>> GetAvailableCouponsForUser()
        {
            // Get all active coupons - show them all to users
            var activeCoupons = await _unitOfWork.Coupons.GetActiveCouponsAsync();

            var couponCodes = activeCoupons
                .Select(c => c.Code)
                .ToList();

            return couponCodes;
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

    #endregion
}
