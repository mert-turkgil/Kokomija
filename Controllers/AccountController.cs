using Kokomija.Data;
using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Account;
using Kokomija.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kokomija.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IStripeCustomerService _stripeCustomerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;
        private readonly IReturnRequestService _returnRequestService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IStripeCustomerService stripeCustomerService,
            IUnitOfWork unitOfWork,
            ILogger<AccountController> logger,
            IReturnRequestService returnRequestService,
            IEmailService emailService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _stripeCustomerService = stripeCustomerService;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _returnRequestService = returnRequestService;
            _emailService = emailService;
            _configuration = configuration;
        }

        #region Login

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null, string? culture = null)
        {
            // Set culture if provided via route
            if (!string.IsNullOrEmpty(culture))
            {
                Response.Cookies.Append(
                    Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.DefaultCookieName,
                    Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.MakeCookieValue(
                        new Microsoft.AspNetCore.Localization.RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            }
            
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            ViewData["ReturnUrl"] = model.ReturnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(model);
            }

            // Check if user is active
            if (!user.IsActive)
            {
                ModelState.AddModelError(string.Empty, "Your account has been deactivated. Please contact support.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName ?? user.Email ?? string.Empty,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true);

            if (result.Succeeded)
            {
                // Update last login
                user.LastLoginAt = DateTime.UtcNow;
                await _userManager.UpdateAsync(user);

                _logger.LogInformation("User {Email} logged in.", model.Email);

                // Store user ID for guest cart merge (will be handled by JavaScript on client side)
                HttpContext.Session.SetString("JustLoggedIn", "true");

                // Check if user is admin and redirect accordingly
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Admin");
                }

                // Redirect to return URL or home
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("User {Email} account locked out.", model.Email);
                return View("Lockout");
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToAction("LoginWith2fa", new { model.ReturnUrl, model.RememberMe });
            }

            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return View(model);
        }

        #endregion

        #region Register

        [HttpGet]
        public IActionResult Register(string? returnUrl = null, string? culture = null)
        {
            // Set culture if provided via route
            if (!string.IsNullOrEmpty(culture))
            {
                Response.Cookies.Append(
                    Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.DefaultCookieName,
                    Microsoft.AspNetCore.Localization.CookieRequestCultureProvider.MakeCookieValue(
                        new Microsoft.AspNetCore.Localization.RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );
            }
            
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(new RegisterViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewData["ReturnUrl"] = model.ReturnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Email", "This email is already registered.");
                return View(model);
            }

            // Create the user
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                EmailConfirmed = false, // Will be confirmed via email
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("User {Email} created a new account.", model.Email);

                // Assign Customer role by default
                await _userManager.AddToRoleAsync(user, "Customer");

                // Create Stripe customer
                try
                {
                    var stripeCustomerId = await _stripeCustomerService.CreateCustomerAsync(user);
                    user.StripeCustomerId = stripeCustomerId;
                    await _userManager.UpdateAsync(user);
                    _logger.LogInformation("Stripe customer {StripeCustomerId} created/updated for user {UserId}", stripeCustomerId, user.Id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to create Stripe customer for user {UserId}", user.Id);
                    // Continue with registration even if Stripe customer creation fails
                }

                // Handle newsletter subscription
                if (model.SubscribeToNewsletter)
                {
                    try
                    {
                        var existingSubscription = await _unitOfWork.Repository<Kokomija.Entity.NewsletterSubscription>()
                            .FirstOrDefaultAsync(ns => ns.Email == model.Email);
                        
                        if (existingSubscription == null)
                        {
                            var confirmationToken = Guid.NewGuid().ToString("N");
                            var subscription = new Kokomija.Entity.NewsletterSubscription
                            {
                                Email = model.Email,
                                IsActive = false, // Pending confirmation
                                SubscribedAt = DateTime.UtcNow,
                                UnsubscribeToken = Guid.NewGuid().ToString("N"),
                                ConfirmationToken = confirmationToken,
                                ConfirmationTokenExpiry = DateTime.UtcNow.AddHours(24),
                                UserId = user.Id,
                                Source = "Registration"
                            };
                            
                            await _unitOfWork.Repository<Kokomija.Entity.NewsletterSubscription>().AddAsync(subscription);
                            await _unitOfWork.SaveChangesAsync();
                            
                            // Send confirmation email
                            var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                            var confirmationUrl = $"{baseUrl}/Newsletter/Confirm?token={confirmationToken}&email={Uri.EscapeDataString(model.Email)}";
                            await _emailService.SendNewsletterConfirmationAsync(model.Email, confirmationUrl);
                            
                            _logger.LogInformation("Newsletter subscription created for user {Email}, confirmation email sent", model.Email);
                        }
                        else if (!existingSubscription.IsActive)
                        {
                            // Reactivate and send new confirmation
                            existingSubscription.ConfirmationToken = Guid.NewGuid().ToString("N");
                            existingSubscription.ConfirmationTokenExpiry = DateTime.UtcNow.AddHours(24);
                            existingSubscription.UserId = user.Id;
                            await _unitOfWork.SaveChangesAsync();
                            
                            var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                            var confirmationUrl = $"{baseUrl}/Newsletter/Confirm?token={existingSubscription.ConfirmationToken}&email={Uri.EscapeDataString(model.Email)}";
                            await _emailService.SendNewsletterConfirmationAsync(model.Email, confirmationUrl);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to process newsletter subscription for user {Email}", model.Email);
                        // Continue with registration even if newsletter subscription fails
                    }
                }

                // Auto sign-in after registration
                await _signInManager.SignInAsync(user, isPersistent: false);

                TempData["SuccessMessage"] = "Account created successfully! Welcome to Kokomija.";
                
                if (model.SubscribeToNewsletter)
                {
                    TempData["SuccessMessage"] += " Please check your email to confirm your newsletter subscription.";
                }

                // Redirect to return URL or home
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            // If we got here, something went wrong
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        #endregion

        #region Logout

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Forgot Password

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                return RedirectToAction("ForgotPasswordConfirmation");
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            
            var callbackUrl = Url.Action("ResetPassword", "Account", 
                new { code, email = user.Email }, Request.Scheme);
            
            if (!string.IsNullOrEmpty(callbackUrl))
            {
                await _emailService.SendPasswordResetAsync(user.Email!, callbackUrl);
            }

            _logger.LogInformation("Password reset requested for user {Email}", model.Email);
            return RedirectToAction("ForgotPasswordConfirmation");
        }

        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        #endregion

        #region Reset Password

        [HttpGet]
        public IActionResult ResetPassword(string? code = null, string? email = null)
        {
            if (code == null || email == null)
            {
                return BadRequest("A code and email must be supplied for password reset.");
            }

            var model = new ResetPasswordViewModel
            {
                Code = code,
                Email = email
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                _logger.LogInformation("Password reset successful for user {Email}", model.Email);
                return RedirectToAction("ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        #endregion

        #region Account Management

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            // Get user roles
            var roles = await _userManager.GetRolesAsync(user);
            var isAdmin = roles.Contains("Admin");

            // Get user orders
            var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(user.Id);
            var recentOrders = orders.OrderByDescending(o => o.CreatedAt).Take(5);

            // Calculate statistics
            var totalOrders = orders.Count();
            var pendingOrders = orders.Count(o => o.OrderStatus == "Pending" || o.OrderStatus == "Processing");
            var completedOrders = orders.Count(o => o.OrderStatus == "Completed" || o.OrderStatus == "Delivered");
            var totalSpent = orders.Where(o => o.OrderStatus != "Cancelled").Sum(o => o.TotalAmount);

            // Get cart and wishlist counts
            var cartItemsCount = await _unitOfWork.Carts.GetCartItemCountAsync(user.Id);
            var wishlistCount = await _unitOfWork.Wishlists.GetWishlistCountAsync(user.Id);

            // Calculate VIP tier based on total spending
            var vipStatus = await CalculateVIPStatusAsync(totalSpent, totalOrders, user.Id);

            // Update user's VIP role to match current tier
            await UpdateUserVIPRoleAsync(user, vipStatus.TierName);

            // Update user's VIP tier in database if changed
            if (user.VipTier != vipStatus.TierName)
            {
                user.VipTier = vipStatus.TierName;
                await _userManager.UpdateAsync(user);
            }

            // Map orders to view models
            var orderViewModels = recentOrders.Select(o => new Models.ViewModels.Account.OrderViewModel
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                OrderDate = o.CreatedAt,
                TotalAmount = o.TotalAmount,
                OrderStatus = o.OrderStatus,
                PaymentStatus = o.PaymentStatus,
                Currency = o.Currency,
                SessionStatus = o.SessionStatus,
                CustomerCountry = o.CustomerCountry,
                ItemCount = o.OrderItems?.Count ?? 0,
                CanCancel = o.OrderStatus == "Pending" || o.OrderStatus == "Processing",
                CanReturn = o.OrderStatus == "Delivered" && o.DeliveredAt.HasValue && (DateTime.UtcNow - o.DeliveredAt.Value).TotalDays <= 30,
                Items = o.OrderItems?.Select(oi => new Models.ViewModels.Account.OrderItemViewModel
                {
                    Id = oi.Id,
                    ProductId = oi.ProductVariant?.ProductId ?? 0,
                    ProductName = oi.ProductName,
                    ProductImage = oi.ProductVariant?.Product?.Images?.FirstOrDefault()?.ImageUrl,
                    ColorName = oi.ProductVariant?.Color?.Name ?? oi.Color,
                    SizeName = oi.ProductVariant?.Size?.Name ?? oi.Size,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }) ?? Enumerable.Empty<Models.ViewModels.Account.OrderItemViewModel>()
            });

            var viewModel = new Models.ViewModels.Account.AccountIndexViewModel
            {
                UserId = user.Id,
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName ?? string.Empty,
                LastName = user.LastName ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                StripeCustomerId = user.StripeCustomerId,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt,
                IsAdmin = isAdmin,
                RecentOrders = orderViewModels,
                TotalOrders = totalOrders,
                PendingOrders = pendingOrders,
                CompletedOrders = completedOrders,
                TotalSpent = totalSpent,
                WishlistCount = wishlistCount,
                CartItemsCount = cartItemsCount,
                VIPStatus = vipStatus
            };

            return View(viewModel);
        }

        private async Task<Models.ViewModels.Account.VIPStatusViewModel> CalculateVIPStatusAsync(decimal totalSpent, int totalOrders, string userId)
        {
            string tierName;
            int tierLevel;
            decimal nextTierThreshold;
            decimal discountPercentage;
            bool hasFreeShipping;
            bool hasEarlyAccess;
            bool hasBirthdayGift;

            // VIP Tiers matching database: Bronze (2%), Silver (5%), Gold (8%), Platinum (12%)
            // Thresholds: Bronze (0), Silver (500), Gold (1500), Platinum (5000)
            if (totalSpent >= 5000)
            {
                tierName = "Platinum";
                tierLevel = 4;
                nextTierThreshold = 0; // Max tier
                discountPercentage = 12;
                hasFreeShipping = true;
                hasEarlyAccess = true;
                hasBirthdayGift = true;
            }
            else if (totalSpent >= 1500)
            {
                tierName = "Gold";
                tierLevel = 3;
                nextTierThreshold = 5000;
                discountPercentage = 8;
                hasFreeShipping = true;
                hasEarlyAccess = true;
                hasBirthdayGift = true;
            }
            else if (totalSpent >= 500)
            {
                tierName = "Silver";
                tierLevel = 2;
                nextTierThreshold = 1500;
                discountPercentage = 5;
                hasFreeShipping = true;
                hasEarlyAccess = false;
                hasBirthdayGift = true;
            }
            else if (totalSpent > 0)
            {
                tierName = "Bronze";
                tierLevel = 1;
                nextTierThreshold = 500;
                discountPercentage = 2;
                hasFreeShipping = false;
                hasEarlyAccess = false;
                hasBirthdayGift = false;
            }
            else
            {
                // Not a VIP member yet
                tierName = "None";
                tierLevel = 0;
                nextTierThreshold = 500; // To reach Bronze
                discountPercentage = 0;
                hasFreeShipping = false;
                hasEarlyAccess = false;
                hasBirthdayGift = false;
            }

            var progressPercentage = nextTierThreshold > 0 
                ? (int)((totalSpent / nextTierThreshold) * 100) 
                : 100;

            var benefits = new List<Models.ViewModels.Account.VIPBenefitViewModel>
            {
                new() { Icon = "percent", Title = $"{discountPercentage}% Discount", Description = "On all products", IsUnlocked = tierLevel >= 1 },
                new() { Icon = "truck", Title = "Free Shipping", Description = "On all orders", IsUnlocked = hasFreeShipping },
                new() { Icon = "clock", Title = "Early Access", Description = "New collections", IsUnlocked = hasEarlyAccess },
                new() { Icon = "gift", Title = "Birthday Gift", Description = "Special surprise", IsUnlocked = hasBirthdayGift },
                new() { Icon = "arrow-repeat", Title = "Extended Returns", Description = "60 days return window", IsUnlocked = tierLevel >= 3 },
                new() { Icon = "headset", Title = "Priority Support", Description = "24/7 dedicated support", IsUnlocked = tierLevel >= 4 }
            };

            // Count available coupons for the user (using Repository<T> since no CouponUsage repository exists)
            var couponUsageRepo = _unitOfWork.Repository<CouponUsage>();
            var now = DateTime.UtcNow;
            
            var allCoupons = await _unitOfWork.Coupons.FindAsync(c => 
                c.IsActive && 
                (!c.ValidFrom.HasValue || c.ValidFrom.Value <= now) &&
                (!c.ValidUntil.HasValue || c.ValidUntil.Value >= now));
            
            var usedCouponIds = (await couponUsageRepo.FindAsync(cu => cu.UserId == userId))
                .Select(cu => cu.CouponId)
                .ToList();
            
            var availableCoupons = allCoupons.Count(c => !usedCouponIds.Contains(c.Id));

            return new Models.ViewModels.Account.VIPStatusViewModel
            {
                TierName = tierName,
                TierLevel = tierLevel,
                CurrentSpending = totalSpent,
                NextTierThreshold = nextTierThreshold,
                ProgressPercentage = progressPercentage,
                DiscountPercentage = discountPercentage,
                HasFreeShipping = hasFreeShipping,
                HasEarlyAccess = hasEarlyAccess,
                HasBirthdayGift = hasBirthdayGift,
                AvailableCoupons = availableCoupons,
                Benefits = benefits
            };
        }

        private async Task UpdateUserVIPRoleAsync(ApplicationUser user, string tierName)
        {
            // Remove all existing VIP roles
            var vipRoles = new[] { "VIPBronze", "VIPSilver", "VIPGold", "VIPPlatinum" };
            var currentRoles = await _userManager.GetRolesAsync(user);
            var currentVipRoles = currentRoles.Where(r => vipRoles.Contains(r)).ToList();
            
            if (currentVipRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, currentVipRoles);
            }

            // Add new VIP role based on tier (skip if None)
            if (tierName != "None")
            {
                var newRole = $"VIP{tierName}";
                if (!await _userManager.IsInRoleAsync(user, newRole))
                {
                    await _userManager.AddToRoleAsync(user, newRole);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", new { returnUrl = "/Account/Orders" });
            }

            // Get orders by user ID using the specialized repository method
            var orders = await _unitOfWork.Orders.GetOrdersByUserIdAsync(user.Id);

            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> CancelOrder(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "User not authenticated" });
            }

            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null || order.UserId != user.Id)
            {
                return Json(new { success = false, message = "Order not found" });
            }

            // Can only cancel pending or processing orders
            if (order.OrderStatus == "pending" || order.OrderStatus == "processing")
            {
                order.OrderStatus = "cancelled";
                _unitOfWork.Orders.Update(order);
                await _unitOfWork.SaveChangesAsync();

                return Json(new { success = true, message = "Order cancelled successfully" });
            }

            return Json(new { success = false, message = "Cannot cancel order at this stage" });
        }

        [HttpGet]
        public IActionResult AccessDenied(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Invalid profile data";
                return RedirectToAction("Index");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                _logger.LogInformation("User {UserId} updated profile", user.Id);
                TempData["SuccessMessage"] = "Profile updated successfully";
            }
            else
            {
                _logger.LogError("Failed to update profile for user {UserId}", user.Id);
                TempData["ErrorMessage"] = "Failed to update profile";
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                _logger.LogInformation("User {UserId} changed password", user.Id);
                TempData["SuccessMessage"] = "Password changed successfully";
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            try
            {
                // Delete user's cart items
                var cartItems = await _unitOfWork.Carts.GetByUserIdAsync(user.Id);
                foreach (var item in cartItems)
                {
                    _unitOfWork.Carts.Remove(item);
                }

                // Delete user's wishlist items
                var wishlistItems = await _unitOfWork.Wishlists.GetByUserIdAsync(user.Id);
                foreach (var item in wishlistItems)
                {
                    _unitOfWork.Wishlists.Remove(item);
                }

                await _unitOfWork.SaveChangesAsync();

                // Sign out the user
                await _signInManager.SignOutAsync();

                // Delete the user account
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User {UserId} deleted their account", user.Id);
                    return Json(new { success = true, message = "Account deleted successfully", redirectUrl = "/" });
                }
                else
                {
                    _logger.LogError("Failed to delete account for user {UserId}: {Errors}", user.Id, string.Join(", ", result.Errors.Select(e => e.Description)));
                    return Json(new { success = false, message = "Failed to delete account" });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting account for user {UserId}", user.Id);
                return Json(new { success = false, message = "An error occurred while deleting account" });
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> OrderDetails(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", new { returnUrl = $"/Account/OrderDetails/{id}" });
            }

            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null || order.UserId != user.Id)
            {
                return NotFound();
            }
            
            // Get shipment info if available
            var shipment = await _unitOfWork.Repository<OrderShipment>()
                .FirstOrDefaultAsync(s => s.OrderId == order.Id, s => s.ShippingRate);

            var orderViewModel = new Models.ViewModels.Account.OrderViewModel
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                OrderDate = order.CreatedAt,
                TotalAmount = order.TotalAmount,
                SubtotalAmount = order.SubtotalAmount,
                ShippingCost = order.ShippingCost,
                DiscountAmount = order.DiscountAmount,
                TaxAmount = order.TaxAmount,
                OrderStatus = order.OrderStatus,
                PaymentStatus = order.PaymentStatus,
                Currency = order.Currency,
                SessionStatus = order.SessionStatus,
                CustomerCountry = order.CustomerCountry,
                ItemCount = order.OrderItems?.Count ?? 0,
                CanCancel = order.OrderStatus == "pending" || order.OrderStatus == "processing",
                CanReturn = order.OrderStatus == "delivered" && order.DeliveredAt.HasValue && (DateTime.UtcNow - order.DeliveredAt.Value).TotalDays <= 30,
                
                // Shipping details
                ShippingMethod = shipment?.ShippingRate?.Name,
                TrackingNumber = shipment?.TrackingNumber,
                ShippedAt = order.ShippedAt,
                DeliveredAt = order.DeliveredAt,
                
                // Address details
                ShippingAddress = order.ShippingAddress,
                ShippingCity = order.ShippingCity,
                ShippingPostalCode = order.ShippingPostalCode,
                ShippingCountry = order.ShippingCountry,
                CustomerEmail = order.CustomerEmail,
                CustomerPhone = order.CustomerPhone,
                
                // Payment details
                PaymentMethod = "Stripe",
                StripePaymentIntentId = order.StripePaymentIntentId,
                PaidAt = order.PaidAt,
                
                // Coupon
                CouponCode = order.Coupon?.Code,
                
                Items = order.OrderItems?.Select(oi => new Models.ViewModels.Account.OrderItemViewModel
                {
                    Id = oi.Id,
                    ProductId = oi.ProductVariant?.ProductId ?? 0,
                    ProductName = oi.ProductName,
                    ProductImage = oi.ProductVariant?.Product?.Images?.FirstOrDefault()?.ImageUrl,
                    ColorName = oi.ProductVariant?.Color?.Name ?? oi.Color,
                    SizeName = oi.ProductVariant?.Size?.Name ?? oi.Size,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }) ?? Enumerable.Empty<Models.ViewModels.Account.OrderItemViewModel>()
            };

            return View(orderViewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ReturnRequest(int orderId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", new { returnUrl = $"/Account/ReturnRequest?orderId={orderId}" });
            }

            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null || order.UserId != user.Id)
            {
                return NotFound();
            }

            // Check if order is eligible for return (delivered within 30 days)
            if (order.OrderStatus != "Delivered" || !order.DeliveredAt.HasValue || (DateTime.UtcNow - order.DeliveredAt.Value).TotalDays > 30)
            {
                TempData["ErrorMessage"] = "This order is not eligible for return";
                return RedirectToAction("Index");
            }

            var model = new ReturnRequestViewModel
            {
                OrderId = order.Id,
                OrderNumber = order.OrderNumber,
                OrderItems = order.OrderItems?.Select(oi => new Models.ViewModels.Account.OrderItemViewModel
                {
                    Id = oi.Id,
                    ProductId = oi.ProductVariant?.ProductId ?? 0,
                    ProductName = oi.ProductName,
                    ProductImage = oi.ProductVariant?.Product?.Images?.FirstOrDefault()?.ImageUrl,
                    ColorName = oi.ProductVariant?.Color?.Name ?? oi.Color,
                    SizeName = oi.ProductVariant?.Size?.Name ?? oi.Size,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice
                }) ?? Enumerable.Empty<Models.ViewModels.Account.OrderItemViewModel>()
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReturnRequest(ReturnRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var order = await _unitOfWork.Orders.GetByIdAsync(model.OrderId);
                if (order != null)
                {
                    model.OrderNumber = order.OrderNumber;
                    model.OrderItems = order.OrderItems?.Select(oi => new Models.ViewModels.Account.OrderItemViewModel
                    {
                        Id = oi.Id,
                        ProductId = oi.ProductVariant?.ProductId ?? 0,
                        ProductName = oi.ProductName,
                        ProductImage = oi.ProductVariant?.Product?.Images?.FirstOrDefault()?.ImageUrl,
                        ColorName = oi.ProductVariant?.Color?.Name ?? oi.Color,
                        SizeName = oi.ProductVariant?.Size?.Name ?? oi.Size,
                        Quantity = oi.Quantity,
                        UnitPrice = oi.UnitPrice,
                        TotalPrice = oi.TotalPrice
                    }) ?? Enumerable.Empty<Models.ViewModels.Account.OrderItemViewModel>();
                }
                return View(model);
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var orderToReturn = await _unitOfWork.Orders.GetByIdAsync(model.OrderId);
            if (orderToReturn == null || orderToReturn.UserId != user.Id)
            {
                TempData["ErrorMessage"] = "Order not found";
                return RedirectToAction("Index");
            }

            // Check if order is eligible for return
            if (orderToReturn.OrderStatus != "Delivered" || !orderToReturn.DeliveredAt.HasValue)
            {
                TempData["ErrorMessage"] = "This order is not eligible for return";
                return RedirectToAction("Index");
            }

            if (!model.SelectedItemIds.Any())
            {
                TempData["ErrorMessage"] = "Please select at least one item to return";
                return RedirectToAction("ReturnRequest", new { orderId = model.OrderId });
            }

            // Create return requests for each selected item
            int successCount = 0;
            foreach (var orderItemId in model.SelectedItemIds)
            {
                var orderItem = orderToReturn.OrderItems?.FirstOrDefault(oi => oi.Id == orderItemId);
                if (orderItem == null) continue;

                try
                {
                    var createDto = new Models.ViewModels.ReturnRequest.CreateReturnRequestDto
                    {
                        OrderId = model.OrderId,
                        OrderItemId = orderItemId,
                        Reason = model.Reason,
                        Description = model.Details,
                        RequestedAmount = orderItem.TotalPrice,
                        Images = null // File upload not implemented in current view
                    };

                    var (success, message, requestId) = await _returnRequestService.CreateReturnRequestAsync(createDto, user.Id);
                    if (success) successCount++;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to create return request for order item {OrderItemId}", orderItemId);
                }
            }

            if (successCount > 0)
            {
                TempData["SuccessMessage"] = $"Return request(s) submitted successfully for {successCount} item(s). We will review and contact you shortly.";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to submit return request(s). Please try again or contact support.";
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region External Authentication (Google, Facebook, Apple)
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string? returnUrl = null, bool popupMode = false)
        {
            _logger.LogInformation("ExternalLogin called with provider: {Provider}, returnUrl: {ReturnUrl}, popupMode: {PopupMode}", provider, returnUrl, popupMode);
            
            // Request a redirect to the external login provider - pass popupMode in state
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { ReturnUrl = returnUrl, popupMode });
            _logger.LogInformation("Redirect URL: {RedirectUrl}", redirectUrl);
            
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            _logger.LogInformation("Configured external authentication properties for {Provider}", provider);
            _logger.LogInformation("About to return Challenge for provider: {Provider}", provider);
            
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null, bool popupMode = false)
        {
            returnUrl ??= Url.Content("~/");

            if (remoteError != null)
            {
                _logger.LogError("Error from external provider: {Error}", remoteError);
                TempData["ErrorMessage"] = $"Error from external provider: {remoteError}";
                return RedirectToAction(nameof(Login), new { ReturnUrl = returnUrl });
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                _logger.LogWarning("External login info not available");
                TempData["ErrorMessage"] = "External login information not available.";
                return RedirectToAction(nameof(Login), new { ReturnUrl = returnUrl });
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
            
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in with {Provider} provider", info.LoginProvider);
                
                // Update last login time
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
                if (user != null)
                {
                    user.LastLoginAt = DateTime.UtcNow;
                    await _unitOfWork.SaveChangesAsync();
                }

                return HandleLoginSuccess(returnUrl, popupMode);
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out during external login");
                return View("Lockout");
            }
            else
            {
                // Get email from external provider
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrEmpty(email))
                {
                    _logger.LogError("Email claim not received from external provider");
                    TempData["ErrorMessage"] = "Email not provided by the external login provider.";
                    return RedirectToAction(nameof(Login));
                }

                // Check if a user with this email already exists
                var existingUser = await _userManager.FindByEmailAsync(email);
                
                if (existingUser != null)
                {
                    // User exists - link the external login to the existing account
                    var addLoginResult = await _userManager.AddLoginAsync(existingUser, info);
                    
                    if (addLoginResult.Succeeded)
                    {
                        _logger.LogInformation("Linked {Provider} login to existing account for {Email}", info.LoginProvider, email);
                        
                        // Update user info from external provider if missing
                        var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName);
                        var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname);
                        var name = info.Principal.FindFirstValue(ClaimTypes.Name);
                        
                        // Extract birthday from claims (different providers use different claim types)
                        var birthdayClaim = info.Principal.FindFirstValue(ClaimTypes.DateOfBirth) 
                            ?? info.Principal.FindFirstValue("urn:google:birthday")
                            ?? info.Principal.FindFirstValue("birthday");
                        
                        bool needsUpdate = false;
                        
                        // Update birthday if not set and available from provider
                        if (!existingUser.Birthday.HasValue && !string.IsNullOrEmpty(birthdayClaim))
                        {
                            if (DateTime.TryParse(birthdayClaim, out var birthday))
                            {
                                existingUser.Birthday = birthday;
                                needsUpdate = true;
                                _logger.LogInformation("Updated birthday for existing user from {Provider}", info.LoginProvider);
                            }
                        }
                        
                        // Update first name if empty
                        if (string.IsNullOrEmpty(existingUser.FirstName) && !string.IsNullOrEmpty(firstName))
                        {
                            existingUser.FirstName = firstName;
                            needsUpdate = true;
                        }
                        
                        // Update last name if empty
                        if (string.IsNullOrEmpty(existingUser.LastName) && !string.IsNullOrEmpty(lastName))
                        {
                            existingUser.LastName = lastName;
                            needsUpdate = true;
                        }
                        
                        // If first/last name still empty, try to split full name
                        if (string.IsNullOrEmpty(existingUser.FirstName) && !string.IsNullOrEmpty(name))
                        {
                            var nameParts = name.Split(' ', 2);
                            existingUser.FirstName = nameParts[0];
                            existingUser.LastName = nameParts.Length > 1 ? nameParts[1] : "";
                            needsUpdate = true;
                        }
                        
                        // Mark email as confirmed (since external provider verified it)
                        if (!existingUser.EmailConfirmed)
                        {
                            existingUser.EmailConfirmed = true;
                            needsUpdate = true;
                        }
                        
                        // Update last login time
                        existingUser.LastLoginAt = DateTime.UtcNow;
                        needsUpdate = true;
                        
                        if (needsUpdate)
                        {
                            await _userManager.UpdateAsync(existingUser);
                        }
                        
                        // Sign in the user
                        await _signInManager.SignInAsync(existingUser, isPersistent: false, info.LoginProvider);
                        
                        TempData["SuccessMessage"] = $"Your {info.LoginProvider} account has been linked successfully!";
                        
                        // Check if admin role
                        var roles = await _userManager.GetRolesAsync(existingUser);
                        if (roles.Contains("Admin"))
                        {
                            return popupMode ? HandleLoginSuccess(Url.Action("Index", "Admin")!, popupMode) : RedirectToAction("Index", "Admin");
                        }
                        
                        return HandleLoginSuccess(returnUrl, popupMode);
                    }
                    else
                    {
                        // External login might already be linked to another account
                        _logger.LogWarning("Failed to link {Provider} to existing account: {Errors}", 
                            info.LoginProvider, string.Join(", ", addLoginResult.Errors.Select(e => e.Description)));
                        
                        // If it's already linked, just sign them in
                        if (addLoginResult.Errors.Any(e => e.Code == "LoginAlreadyAssociated"))
                        {
                            await _signInManager.SignInAsync(existingUser, isPersistent: false, info.LoginProvider);
                            existingUser.LastLoginAt = DateTime.UtcNow;
                            await _userManager.UpdateAsync(existingUser);
                            return HandleLoginSuccess(returnUrl, popupMode);
                        }
                        
                        TempData["ErrorMessage"] = "Failed to link your account. Please try again.";
                        return RedirectToAction(nameof(Login));
                    }
                }

                // No existing user - create a new account
                // Extract user information from claims
                var newFirstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "";
                var newLastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? "";
                var newName = info.Principal.FindFirstValue(ClaimTypes.Name) ?? "";
                
                // Extract birthday from claims
                var newBirthdayClaim = info.Principal.FindFirstValue(ClaimTypes.DateOfBirth) 
                    ?? info.Principal.FindFirstValue("urn:google:birthday")
                    ?? info.Principal.FindFirstValue("birthday");
                DateTime? newBirthday = null;
                if (!string.IsNullOrEmpty(newBirthdayClaim) && DateTime.TryParse(newBirthdayClaim, out var parsedBirthday))
                {
                    newBirthday = parsedBirthday;
                    _logger.LogInformation("Extracted birthday from {Provider}: {Birthday}", info.LoginProvider, newBirthday);
                }

                // If first/last name not available, try to split the full name
                if (string.IsNullOrEmpty(newFirstName) && !string.IsNullOrEmpty(newName))
                {
                    var nameParts = newName.Split(' ', 2);
                    newFirstName = nameParts[0];
                    newLastName = nameParts.Length > 1 ? nameParts[1] : "";
                }

                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true, // Email is confirmed by the external provider
                    FirstName = newFirstName,
                    LastName = newLastName,
                    Birthday = newBirthday,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };

                var createResult = await _userManager.CreateAsync(user);
                if (createResult.Succeeded)
                {
                    // Add the external login
                    createResult = await _userManager.AddLoginAsync(user, info);
                    if (createResult.Succeeded)
                    {
                        _logger.LogInformation("User created an account using {Provider} provider", info.LoginProvider);

                        // Assign Customer role
                        await _userManager.AddToRoleAsync(user, "Customer");

                        // Create Stripe customer
                        try
                        {
                            var stripeCustomerId = await _stripeCustomerService.CreateCustomerAsync(user);
                            user.StripeCustomerId = stripeCustomerId;
                            await _unitOfWork.SaveChangesAsync();
                            
                            _logger.LogInformation("Stripe customer created/updated for external login user: {CustomerId}", stripeCustomerId);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Failed to create Stripe customer for external login user");
                            // Continue - don't block login if Stripe fails
                        }

                        // Sign in the user
                        await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);

                        TempData["SuccessMessage"] = $"Welcome! Your account has been created with {info.LoginProvider}.";

                        // Check if admin role
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                            return popupMode ? HandleLoginSuccess(Url.Action("Index", "Admin")!, popupMode) : RedirectToAction("Index", "Admin");
                        }

                        return HandleLoginSuccess(returnUrl, popupMode);
                    }
                }

                foreach (var error in createResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                    _logger.LogError("Error creating user from external login: {Error}", error.Description);
                }

                TempData["ErrorMessage"] = "Failed to create account. Please try again or use a different login method.";
                return RedirectToAction(nameof(Login));
            }
        }

        /// <summary>
        /// Handle successful login - either redirect or show success page for popup mode
        /// </summary>
        private IActionResult HandleLoginSuccess(string returnUrl, bool popupMode)
        {
            if (popupMode)
            {
                // Show success page that will close popup and notify parent window
                ViewData["RedirectUrl"] = returnUrl;
                ViewData["IsPopup"] = true;
                return View("LoginSuccess");
            }
            
            return LocalRedirect(returnUrl);
        }

        #endregion
    }
}
