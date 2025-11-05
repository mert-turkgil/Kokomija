using Kokomija.Data.Abstract;
using Kokomija.Models.ViewModels.Cart;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kokomija.Controllers
{
    [Route("Cart")]
    public class CartViewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILocalizationService _localizationService;
        private readonly ILogger<CartViewController> _logger;

        public CartViewController(
            IUnitOfWork unitOfWork,
            ILocalizationService localizationService,
            ILogger<CartViewController> logger)
        {
            _unitOfWork = unitOfWork;
            _localizationService = localizationService;
            _logger = logger;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            CartIndexViewModel viewModel;

            if (User.Identity?.IsAuthenticated == true)
            {
                // Get authenticated user's cart from database
                var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(userId);
                viewModel = await BuildCartViewModel(cartItems);
            }
            else
            {
                // Guest cart will be loaded from localStorage via JavaScript
                viewModel = new CartIndexViewModel
                {
                    FreeShippingThreshold = 200.00m // PLN
                };
            }

            ViewData["Title"] = _localizationService["Cart_Title"];
            return View(viewModel);
        }

        [Authorize]
        [HttpPost("UpdateQuantity")]
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
                    // Remove item if quantity is 0 or less
                    _unitOfWork.Carts.Remove(cartItem);
                }
                else
                {
                    // Update quantity (EF Core will track this change automatically)
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
        [HttpPost("RemoveItem")]
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

        [Authorize]
        [HttpPost("ApplyCoupon")]
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
                var usageCount = await _unitOfWork.Repository<Entity.CouponUsage>()
                    .GetAllAsync(cu => cu.CouponId == coupon.Id && cu.UserId == userId);

                if (coupon.UsageLimitPerUser.HasValue && usageCount.Count() >= coupon.UsageLimitPerUser.Value)
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
        [HttpPost("RemoveCoupon")]
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

        private async Task<CartIndexViewModel> BuildCartViewModel(
            IEnumerable<Entity.Cart> cartItems,
            Entity.Coupon? appliedCoupon = null)
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
                    MaxQuantity = variant?.StockQuantity ?? 10
                };

                items.Add(itemViewModel);
                subtotal += itemViewModel.TotalPrice;
            }

            // Calculate discount
            decimal discountAmount = 0;
            decimal? couponDiscountPercentage = null;
            string? appliedCouponCode = null;

            if (appliedCoupon != null)
            {
                if (appliedCoupon.DiscountType == "percentage")
                {
                    discountAmount = subtotal * (appliedCoupon.DiscountValue / 100);
                    couponDiscountPercentage = appliedCoupon.DiscountValue;
                }
                else // fixed_amount
                {
                    discountAmount = appliedCoupon.DiscountValue;
                }
                
                // Apply maximum discount limit if set
                if (appliedCoupon.MaximumDiscountAmount.HasValue && discountAmount > appliedCoupon.MaximumDiscountAmount.Value)
                {
                    discountAmount = appliedCoupon.MaximumDiscountAmount.Value;
                }
                
                appliedCouponCode = appliedCoupon.Code;
            }

            // Calculate shipping
            const decimal freeShippingThreshold = 200.00m; // PLN
            const decimal standardShippingCost = 15.00m; // PLN
            decimal shippingCost = subtotal >= freeShippingThreshold ? 0 : standardShippingCost;
            bool hasFreeShipping = subtotal >= freeShippingThreshold;
            decimal remainingForFreeShipping = hasFreeShipping ? 0 : freeShippingThreshold - subtotal;

            // Calculate tax (23% VAT in Poland)
            decimal subtotalAfterDiscount = subtotal - discountAmount;
            decimal taxAmount = (subtotalAfterDiscount + shippingCost) * 0.23m;

            // Calculate total
            decimal total = subtotalAfterDiscount + shippingCost + taxAmount;

            // Get available coupons for user (VIP coupons, etc.)
            var availableCoupons = await GetAvailableCouponsForUser();

            return new CartIndexViewModel
            {
                Items = items,
                Subtotal = subtotal,
                ShippingCost = shippingCost,
                DiscountAmount = discountAmount,
                TaxAmount = taxAmount,
                Total = total,
                AppliedCouponCode = appliedCouponCode,
                CouponDiscountPercentage = couponDiscountPercentage,
                HasFreeShipping = hasFreeShipping,
                FreeShippingThreshold = freeShippingThreshold,
                RemainingForFreeShipping = remainingForFreeShipping,
                AvailableCoupons = availableCoupons
            };
        }

        private async Task<IEnumerable<string>> GetAvailableCouponsForUser()
        {
            if (User.Identity?.IsAuthenticated != true)
            {
                return Enumerable.Empty<string>();
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Enumerable.Empty<string>();
            }

            // Get user's order history to calculate VIP tier
            var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(userId);
            var totalSpent = orders.Where(o => o.OrderStatus != "Cancelled").Sum(o => o.TotalAmount);

            // Get active coupons based on VIP tier
            var activeCoupons = await _unitOfWork.Coupons.GetActiveCouponsAsync();
            
            var userCoupons = activeCoupons
                .Where(c => c.MinimumOrderAmount <= totalSpent)
                .Select(c => c.Code)
                .ToList();

            return userCoupons;
        }
    }
}
