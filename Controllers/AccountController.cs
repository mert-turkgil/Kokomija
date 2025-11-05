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

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IStripeCustomerService stripeCustomerService,
            IUnitOfWork unitOfWork,
            ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _stripeCustomerService = stripeCustomerService;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        #region Login

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null)
        {
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
        public IActionResult Register(string? returnUrl = null)
        {
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
                    _logger.LogInformation("Stripe customer {StripeCustomerId} created for user {UserId}", stripeCustomerId, user.Id);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Failed to create Stripe customer for user {UserId}", user.Id);
                    // Continue with registration even if Stripe customer creation fails
                }

                // Send email confirmation (optional - implement if needed)
                // var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                // await _emailService.SendEmailConfirmationAsync(user.Email, code);

                // Auto sign-in after registration
                await _signInManager.SignInAsync(user, isPersistent: false);

                TempData["SuccessMessage"] = "Account created successfully! Welcome to Kokomija.";

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
            
            // TODO: Send email with reset link
            // var callbackUrl = Url.Action("ResetPassword", "Account", 
            //     new { code, email = user.Email }, Request.Scheme);
            // await _emailService.SendPasswordResetAsync(user.Email, callbackUrl);

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
            var vipStatus = CalculateVIPStatus(totalSpent, totalOrders);

            // Map orders to view models
            var orderViewModels = recentOrders.Select(o => new Models.ViewModels.Account.OrderViewModel
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                OrderDate = o.CreatedAt,
                TotalAmount = o.TotalAmount,
                OrderStatus = o.OrderStatus,
                PaymentStatus = o.PaymentStatus,
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

        private Models.ViewModels.Account.VIPStatusViewModel CalculateVIPStatus(decimal totalSpent, int totalOrders)
        {
            string tierName;
            int tierLevel;
            decimal nextTierThreshold;
            decimal discountPercentage;
            bool hasFreeShipping;
            bool hasEarlyAccess;
            bool hasBirthdayGift;

            // VIP Tiers: Bronze (0-500), Silver (500-1500), Gold (1500-5000), Platinum (5000+)
            if (totalSpent >= 5000)
            {
                tierName = "Platinum";
                tierLevel = 4;
                nextTierThreshold = 0; // Max tier
                discountPercentage = 20;
                hasFreeShipping = true;
                hasEarlyAccess = true;
                hasBirthdayGift = true;
            }
            else if (totalSpent >= 1500)
            {
                tierName = "Gold";
                tierLevel = 3;
                nextTierThreshold = 5000;
                discountPercentage = 15;
                hasFreeShipping = true;
                hasEarlyAccess = true;
                hasBirthdayGift = true;
            }
            else if (totalSpent >= 500)
            {
                tierName = "Silver";
                tierLevel = 2;
                nextTierThreshold = 1500;
                discountPercentage = 10;
                hasFreeShipping = true;
                hasEarlyAccess = false;
                hasBirthdayGift = true;
            }
            else
            {
                tierName = "Bronze";
                tierLevel = 1;
                nextTierThreshold = 500;
                discountPercentage = 5;
                hasFreeShipping = false;
                hasEarlyAccess = false;
                hasBirthdayGift = false;
            }

            var progressPercentage = nextTierThreshold > 0 
                ? (int)((totalSpent / nextTierThreshold) * 100) 
                : 100;

            var benefits = new List<Models.ViewModels.Account.VIPBenefitViewModel>
            {
                new() { Icon = "fas fa-percent", Title = $"{discountPercentage}% Discount", Description = "On all products", IsUnlocked = true },
                new() { Icon = "fas fa-shipping-fast", Title = "Free Shipping", Description = "On all orders", IsUnlocked = hasFreeShipping },
                new() { Icon = "fas fa-clock", Title = "Early Access", Description = "New collections", IsUnlocked = hasEarlyAccess },
                new() { Icon = "fas fa-gift", Title = "Birthday Gift", Description = "Special surprise", IsUnlocked = hasBirthdayGift },
                new() { Icon = "fas fa-undo", Title = "Extended Returns", Description = "60 days return window", IsUnlocked = tierLevel >= 3 },
                new() { Icon = "fas fa-headset", Title = "Priority Support", Description = "24/7 dedicated support", IsUnlocked = tierLevel >= 4 }
            };

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
                AvailableCoupons = 0, // TODO: Implement coupon counting
                Benefits = benefits
            };
        }

        [HttpGet]
        public IActionResult AccessDenied(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        #endregion

        #region External Authentication (Google, Facebook, Apple)

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string? returnUrl = null)
        {
            // Request a redirect to the external login provider
            var redirectUrl = Url.Action(nameof(ExternalLoginCallback), "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string? returnUrl = null, string? remoteError = null)
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

                return LocalRedirect(returnUrl);
            }

            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out during external login");
                return View("Lockout");
            }
            else
            {
                // If the user does not have an account, create one
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                if (string.IsNullOrEmpty(email))
                {
                    _logger.LogError("Email claim not received from external provider");
                    TempData["ErrorMessage"] = "Email not provided by the external login provider.";
                    return RedirectToAction(nameof(Login));
                }

                // Extract user information from claims
                var firstName = info.Principal.FindFirstValue(ClaimTypes.GivenName) ?? "";
                var lastName = info.Principal.FindFirstValue(ClaimTypes.Surname) ?? "";
                var name = info.Principal.FindFirstValue(ClaimTypes.Name) ?? "";

                // If first/last name not available, try to split the full name
                if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(name))
                {
                    var nameParts = name.Split(' ', 2);
                    firstName = nameParts[0];
                    lastName = nameParts.Length > 1 ? nameParts[1] : "";
                }

                var user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true, // Email is confirmed by the external provider
                    FirstName = firstName,
                    LastName = lastName,
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
                            
                            _logger.LogInformation("Stripe customer created for external login user: {CustomerId}", stripeCustomerId);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Failed to create Stripe customer for external login user");
                            // Continue - don't block login if Stripe fails
                        }

                        // Sign in the user
                        await _signInManager.SignInAsync(user, isPersistent: false, info.LoginProvider);

                        // Check if admin role
                        var roles = await _userManager.GetRolesAsync(user);
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index", "Admin");
                        }

                        return LocalRedirect(returnUrl);
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

        #endregion
    }
}
