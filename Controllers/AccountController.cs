using Kokomija.Data;
using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Account;
using Kokomija.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Kokomija.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IStripeCustomerService _stripeCustomerService;
        private readonly IStripeService _stripeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountController> _logger;
        private readonly IReturnRequestService _returnRequestService;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;
        private readonly INIPValidationService _nipValidationService;
        private readonly ApplicationDbContext _dbContext;
        private readonly ILocalizationService _localizationService;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IStripeCustomerService stripeCustomerService,
            IStripeService stripeService,
            IUnitOfWork unitOfWork,
            ILogger<AccountController> logger,
            IReturnRequestService returnRequestService,
            IEmailService emailService,
            IConfiguration configuration,
            INIPValidationService nipValidationService,
            ApplicationDbContext dbContext,
            ILocalizationService localizationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _stripeCustomerService = stripeCustomerService;
            _stripeService = stripeService;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _returnRequestService = returnRequestService;
            _emailService = emailService;
            _configuration = configuration;
            _nipValidationService = nipValidationService;
            _dbContext = dbContext;
            _localizationService = localizationService;
        }

        #region Login

        [HttpGet]
        public async Task<IActionResult> Login(string? returnUrl = null, string? culture = null, string? error = null)
        {
            // Handle OAuth error messages
            if (!string.IsNullOrEmpty(error))
            {
                TempData["ErrorMessage"] = $"Authentication failed: {error}";
                _logger.LogWarning("OAuth authentication error displayed: {Error}", error);
            }
            
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

        /// <summary>
        /// POST: Admin login during maintenance mode
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MaintenanceLogin(string email, string password, string? returnUrl = null)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                TempData["Error"] = "Email and password are required.";
                return RedirectToAction("Maintenance", "Home", new { returnUrl });
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                TempData["Error"] = "Invalid credentials or insufficient permissions.";
                return RedirectToAction("Maintenance", "Home", new { returnUrl });
            }

            // Check if user is admin or root
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Admin") && !roles.Contains("Root"))
            {
                TempData["Error"] = "Only administrators can access during maintenance mode.";
                _logger.LogWarning("Non-admin user {Email} attempted to login during maintenance", email);
                return RedirectToAction("Maintenance", "Home", new { returnUrl });
            }

            // Verify password
            var result = await _signInManager.PasswordSignInAsync(
                user.UserName ?? user.Email ?? string.Empty,
                password,
                isPersistent: true,
                lockoutOnFailure: false);

            if (result.Succeeded)
            {
                _logger.LogInformation("Admin {Email} logged in during maintenance mode", email);
                
                // Clear all cart items (maintenance mode requirement)
                await ClearAllCartsAsync();
                
                // Redirect to admin panel
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                
                return RedirectToAction("Index", "Admin");
            }

            TempData["Error"] = "Invalid credentials or insufficient permissions.";
            return RedirectToAction("Maintenance", "Home", new { returnUrl });
        }

        /// <summary>
        /// Clear all cart items (called when maintenance mode is activated)
        /// </summary>
        private async Task ClearAllCartsAsync()
        {
            try
            {
                var allCarts = await _unitOfWork.Carts.GetAllAsync();
                var cartsList = allCarts.ToList();
                
                if (cartsList.Any())
                {
                    _unitOfWork.Repository<Cart>().RemoveRange(cartsList);
                    await _unitOfWork.SaveChangesAsync();
                    _logger.LogInformation("All {Count} cart items cleared during maintenance mode activation", cartsList.Count);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error clearing cart items during maintenance mode");
            }
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
                Birthday = model.DateOfBirth,
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
                            
                            // Send newsletter confirmation email
                            var baseUrlNews = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                            var newsConfirmationUrl = $"{baseUrlNews}/Newsletter/Confirm?token={confirmationToken}&email={Uri.EscapeDataString(model.Email)}";
                            await _emailService.SendNewsletterConfirmationAsync(model.Email, newsConfirmationUrl);
                            
                            _logger.LogInformation("Newsletter subscription created for user {Email}, confirmation email sent", model.Email);
                        }
                        else if (!existingSubscription.IsActive)
                        {
                            // Reactivate and send new confirmation
                            existingSubscription.ConfirmationToken = Guid.NewGuid().ToString("N");
                            existingSubscription.ConfirmationTokenExpiry = DateTime.UtcNow.AddHours(24);
                            existingSubscription.UserId = user.Id;
                            await _unitOfWork.SaveChangesAsync();
                            
                            var baseUrlNews = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                            var newsConfirmationUrl = $"{baseUrlNews}/Newsletter/Confirm?token={existingSubscription.ConfirmationToken}&email={Uri.EscapeDataString(model.Email)}";
                            await _emailService.SendNewsletterConfirmationAsync(model.Email, newsConfirmationUrl);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Failed to process newsletter subscription for user {Email}", model.Email);
                        // Continue with registration even if newsletter subscription fails
                    }
                }

                // Generate email confirmation token and send verification email
                var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                var verificationUrl = Url.Action("ConfirmEmail", "Account", 
                    new { userId = user.Id, code = emailConfirmationToken }, Request.Scheme);
                
                // Detect user's language preference
                var culture = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
                
                if (!string.IsNullOrEmpty(verificationUrl))
                {
                    await _emailService.SendEmailVerificationAsync(model.Email, verificationUrl, culture);
                    _logger.LogInformation("Email verification sent to {Email}", model.Email);
                }

                // Do NOT auto sign-in - user must confirm email first
                TempData["SuccessMessage"] = _localizationService["Register_ConfirmEmailSent"];
                
                if (model.SubscribeToNewsletter)
                {
                    TempData["InfoMessage"] = _localizationService["Register_NewsletterConfirmationSent"];
                }

                // Redirect to registration confirmation page
                return RedirectToAction("RegisterConfirmation", new { email = model.Email });
            }

            // If we got here, something went wrong
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterConfirmation(string? email = null)
        {
            ViewData["Email"] = email;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(code))
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                _logger.LogWarning("Email confirmation failed: user {UserId} not found", userId);
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                _logger.LogInformation("Email confirmed for user {Email}", user.Email);
                TempData["SuccessMessage"] = _localizationService["ConfirmEmail_Success"];
                
                // Sign in the user after email confirmation
                await _signInManager.SignInAsync(user, isPersistent: false);
                
                return RedirectToAction("Index", "Home");
            }

            _logger.LogWarning("Email confirmation failed for user {Email}", user.Email);
            TempData["ErrorMessage"] = _localizationService["ConfirmEmail_Failed"];
            return View("ConfirmEmailError");
        }

        [HttpGet]
        public async Task<IActionResult> ResendEmailConfirmation(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Email is required.";
                return RedirectToAction("Login");
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                TempData["SuccessMessage"] = _localizationService["ResendConfirmation_Sent"];
                return RedirectToAction("RegisterConfirmation", new { email });
            }

            if (await _userManager.IsEmailConfirmedAsync(user))
            {
                TempData["InfoMessage"] = _localizationService["ResendConfirmation_AlreadyConfirmed"];
                return RedirectToAction("Login");
            }

            // Generate new confirmation token and send email
            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var verificationUrl = Url.Action("ConfirmEmail", "Account", 
                new { userId = user.Id, code = emailConfirmationToken }, Request.Scheme);
            
            var culture = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName;
            
            if (!string.IsNullOrEmpty(verificationUrl))
            {
                await _emailService.SendEmailVerificationAsync(email, verificationUrl, culture);
                _logger.LogInformation("Email verification resent to {Email}", email);
            }

            TempData["SuccessMessage"] = _localizationService["ResendConfirmation_Sent"];
            return RedirectToAction("RegisterConfirmation", new { email });
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
        public async Task<IActionResult> Index(string? tab = null)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            // Pass active tab to view
            if (!string.IsNullOrEmpty(tab))
            {
                ViewBag.ActiveTab = tab;
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

            // Get business profile
            var businessProfile = await _nipValidationService.GetBusinessProfileAsync(user.Id);
            var businessProfileViewModel = businessProfile != null ? new Models.ViewModels.Account.BusinessProfileViewModel
            {
                Id = businessProfile.Id,
                NIP = businessProfile.NIP,
                CompanyName = businessProfile.CompanyName,
                REGON = businessProfile.REGON,
                KRS = businessProfile.KRS,
                VATStatus = businessProfile.VATStatus,
                ResidenceAddress = businessProfile.ResidenceAddress,
                WorkingAddress = businessProfile.WorkingAddress,
                Phone = businessProfile.Phone,
                CompanyEmail = businessProfile.CompanyEmail,
                ContactPerson = businessProfile.ContactPerson,
                Position = businessProfile.Position,
                IsVerified = businessProfile.IsVerified,
                IsBusinessModeActive = businessProfile.IsBusinessModeActive,
                VerifiedAt = businessProfile.VerifiedAt,
                CreatedAt = businessProfile.CreatedAt
            } : null;
            
            // Get return requests for user
            var returnRequests = await _dbContext.ReturnRequests
                .Where(rr => rr.UserId == user.Id)
                .OrderByDescending(rr => rr.RequestedAt)
                .Take(5)
                .Include(rr => rr.Order)
                .Include(rr => rr.OrderItem)
                    .ThenInclude(oi => oi.ProductVariant)
                        .ThenInclude(pv => pv!.Product)
                .ToListAsync();
            
            var returnRequestViewModels = returnRequests.Select(rr => new Models.ViewModels.Account.ReturnRequestSummaryViewModel
            {
                Id = rr.Id,
                OrderNumber = rr.Order.OrderNumber,
                ProductName = rr.OrderItem?.ProductName ?? "Unknown",
                Status = rr.Status.ToString(),
                RequestedAmount = rr.RequestedAmount,
                RefundedAmount = rr.RefundedAmount,
                RequestedAt = rr.RequestedAt,
                ReviewedAt = rr.ReviewedAt
            }).ToList();
            
            var pendingReturnRequests = await _dbContext.ReturnRequests
                .CountAsync(rr => rr.UserId == user.Id && 
                    (rr.Status == Entity.ReturnRequestStatus.Pending || 
                     rr.Status == Entity.ReturnRequestStatus.UnderReview));

            // Get external logins for the user
            var userLogins = await _userManager.GetLoginsAsync(user);
            var externalLogins = userLogins.Select(l => new Models.ViewModels.Account.ExternalLoginViewModel
            {
                LoginProvider = l.LoginProvider,
                ProviderDisplayName = l.ProviderDisplayName ?? l.LoginProvider,
                ProviderKey = l.ProviderKey
            }).ToList();
            
            // Get available authentication schemes (providers)
            var schemes = await _signInManager.GetExternalAuthenticationSchemesAsync();
            var currentProviders = userLogins.Select(l => l.LoginProvider).ToList();
            var availableProviders = schemes
                .Where(s => !currentProviders.Contains(s.Name))
                .Select(s => s.DisplayName ?? s.Name)
                .ToList();
            
            // Check if user has a password set
            var hasPassword = await _userManager.HasPasswordAsync(user);

            // Load coupons - check both local DB and Stripe for used coupons
            var now = DateTime.UtcNow;
            var allCoupons = await _unitOfWork.Coupons.GetAllAsync("CouponUsages");
            
            // Get used promotion codes from Stripe
            var stripeUsedPromotionCodes = new List<string>();
            if (!string.IsNullOrEmpty(user.StripeCustomerId))
            {
                try
                {
                    stripeUsedPromotionCodes = await _stripeService.GetCustomerUsedPromotionCodesAsync(user.StripeCustomerId);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to get Stripe used promotion codes for user {UserId}", user.Id);
                }
            }
            
            // Get locally tracked coupon usages
            var localUsedCouponIds = allCoupons
                .SelectMany(c => c.CouponUsages)
                .Where(cu => cu.UserId == user.Id)
                .Select(cu => cu.CouponId)
                .ToList();
            
            // Available coupons: active, valid dates, not used locally AND not used in Stripe
            var availableCoupons = allCoupons
                .Where(c => c.IsActive && 
                           (!c.ValidFrom.HasValue || c.ValidFrom.Value <= now) &&
                           (!c.ValidUntil.HasValue || c.ValidUntil.Value >= now) &&
                           (!c.UsageLimit.HasValue || c.UsageCount < c.UsageLimit.Value) &&
                           (c.UserId == null || c.UserId == user.Id) &&
                           !localUsedCouponIds.Contains(c.Id) &&
                           (string.IsNullOrEmpty(c.StripePromotionCodeId) || !stripeUsedPromotionCodes.Contains(c.StripePromotionCodeId)))
                .Select(c => new AccountCouponViewModel
                {
                    Id = c.Id,
                    Code = c.Code,
                    Description = c.Description ?? string.Empty,
                    DiscountType = c.DiscountType,
                    DiscountValue = c.DiscountValue,
                    MinimumOrderAmount = c.MinimumOrderAmount,
                    ValidUntil = c.ValidUntil,
                    IsNew = c.CreatedAt >= DateTime.UtcNow.AddDays(-7)
                })
                .ToList();
            
            // Used coupons: from local database (CouponUsages)
            var usedCouponsFromDb = allCoupons
                .SelectMany(c => c.CouponUsages.Where(cu => cu.UserId == user.Id).Select(cu => new { Coupon = c, Usage = cu }))
                .Select(x => new UsedCouponViewModel
                {
                    Id = x.Coupon.Id,
                    Code = x.Coupon.Code,
                    Description = x.Coupon.Description ?? string.Empty,
                    DiscountAmount = x.Usage.DiscountAmount,
                    UsedAt = x.Usage.UsedAt,
                    OrderId = x.Usage.OrderId,
                    OrderNumber = x.Usage.Order?.OrderNumber ?? $"#{x.Usage.OrderId}"
                })
                .ToList();
            
            // Also include coupons used in Stripe but not in local DB (for cases where DB was rebuilt)
            var stripOnlyUsedCoupons = allCoupons
                .Where(c => !string.IsNullOrEmpty(c.StripePromotionCodeId) && 
                           stripeUsedPromotionCodes.Contains(c.StripePromotionCodeId) &&
                           !localUsedCouponIds.Contains(c.Id))
                .Select(c => new UsedCouponViewModel
                {
                    Id = c.Id,
                    Code = c.Code,
                    Description = c.Description ?? string.Empty,
                    DiscountAmount = c.DiscountType == "percentage" ? 0 : c.DiscountValue, // We don't know exact amount
                    UsedAt = DateTime.UtcNow, // We don't know exact date from Stripe in this call
                    OrderId = 0,
                    OrderNumber = "(Used via Stripe)"
                })
                .ToList();
            
            var allUsedCoupons = usedCouponsFromDb.Concat(stripOnlyUsedCoupons).ToList();

            var viewModel = new Models.ViewModels.Account.AccountIndexViewModel
            {
                UserId = user.Id,
                Email = user.Email ?? string.Empty,
                FirstName = user.FirstName ?? string.Empty,
                LastName = user.LastName ?? string.Empty,
                PhoneNumber = user.PhoneNumber,
                Birthday = user.Birthday,
                StripeCustomerId = user.StripeCustomerId,
                CreatedAt = user.CreatedAt,
                LastLoginAt = user.LastLoginAt,
                IsAdmin = isAdmin,
                DefaultAddress = user.DefaultAddress,
                DefaultCity = user.DefaultCity,
                DefaultPostalCode = user.DefaultPostalCode,
                DefaultCountry = user.DefaultCountry,
                RecentOrders = orderViewModels,
                RecentReturnRequests = returnRequestViewModels,
                TotalOrders = totalOrders,
                PendingOrders = pendingOrders,
                CompletedOrders = completedOrders,
                TotalSpent = totalSpent,
                WishlistCount = wishlistCount,
                CartItemsCount = cartItemsCount,
                PendingReturnRequests = pendingReturnRequests,
                VIPStatus = vipStatus,
                BusinessProfile = businessProfileViewModel,
                ExternalLogins = externalLogins,
                AvailableProviders = availableProviders,
                HasPassword = hasPassword,
                AvailableCoupons = availableCoupons,
                UsedCoupons = allUsedCoupons
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
        public IActionResult Orders()
        {
            // Redirect to Index with orders tab active (no separate Orders view exists)
            return RedirectToAction("Index", new { tab = "orders" });
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
            user.Birthday = model.Birthday;
            user.DefaultAddress = model.DefaultAddress;
            user.DefaultCity = model.DefaultCity;
            user.DefaultPostalCode = model.DefaultPostalCode;
            user.DefaultCountry = model.DefaultCountry;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                _logger.LogInformation("User {UserId} updated profile", user.Id);
                TempData["SuccessMessage"] = _localizationService["Account_ProfileUpdatedSuccess"];
            }
            else
            {
                _logger.LogError("Failed to update profile for user {UserId}", user.Id);
                TempData["ErrorMessage"] = _localizationService["Account_ProfileUpdateError"];
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

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ReturnRequestDetails(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", new { returnUrl = $"/Account/ReturnRequestDetails?id={id}" });
            }

            var returnRequest = await _dbContext.ReturnRequests
                .Include(rr => rr.Order)
                .Include(rr => rr.OrderItem)
                    .ThenInclude(oi => oi!.ProductVariant)
                        .ThenInclude(pv => pv!.Product)
                            .ThenInclude(p => p!.Images)
                .Include(rr => rr.OrderItem)
                    .ThenInclude(oi => oi!.ProductVariant)
                        .ThenInclude(pv => pv!.Color)
                .Include(rr => rr.OrderItem)
                    .ThenInclude(oi => oi!.ProductVariant)
                        .ThenInclude(pv => pv!.Size)
                .Include(rr => rr.StatusHistory)
                .Include(rr => rr.Images)
                .FirstOrDefaultAsync(rr => rr.Id == id && rr.UserId == user.Id);

            if (returnRequest == null)
            {
                TempData["ErrorMessage"] = _localizationService["return_request_not_found"];
                return RedirectToAction("Index");
            }

            var viewModel = new Models.ViewModels.Account.ReturnRequestDetailsViewModel
            {
                Id = returnRequest.Id,
                OrderId = returnRequest.OrderId,
                OrderNumber = returnRequest.Order?.OrderNumber ?? "N/A",
                Status = returnRequest.Status.ToString(),
                Reason = returnRequest.Reason ?? "Not specified",
                Description = returnRequest.Description,
                RequestedAmount = returnRequest.RequestedAmount,
                RefundedAmount = returnRequest.RefundedAmount,
                RefundTransactionId = returnRequest.StripeRefundId,
                RequestedAt = returnRequest.RequestedAt,
                ReviewedAt = returnRequest.ReviewedAt,
                ReviewedBy = returnRequest.ReviewedBy,
                ReviewNotes = returnRequest.ReviewNotes,
                CompletedAt = returnRequest.RefundedAt,
                OrderItem = returnRequest.OrderItem != null ? new Models.ViewModels.Account.OrderItemViewModel
                {
                    Id = returnRequest.OrderItem.Id,
                    ProductId = returnRequest.OrderItem.ProductVariant?.ProductId ?? 0,
                    ProductName = returnRequest.OrderItem.ProductName,
                    ProductImage = returnRequest.OrderItem.ProductVariant?.Product?.Images?.FirstOrDefault()?.ImageUrl,
                    ColorName = returnRequest.OrderItem.ProductVariant?.Color?.Name ?? returnRequest.OrderItem.Color,
                    SizeName = returnRequest.OrderItem.ProductVariant?.Size?.Name ?? returnRequest.OrderItem.Size,
                    Quantity = returnRequest.OrderItem.Quantity,
                    UnitPrice = returnRequest.OrderItem.UnitPrice,
                    TotalPrice = returnRequest.OrderItem.TotalPrice
                } : null,
                StatusHistory = returnRequest.StatusHistory?
                    .OrderByDescending(sh => sh.ChangedAt)
                    .Select(sh => new Models.ViewModels.Account.ReturnStatusHistoryViewModel
                    {
                        Id = sh.Id,
                        PreviousStatus = null, // StatusHistory tracks current status only
                        NewStatus = sh.Status.ToString(),
                        ChangedAt = sh.ChangedAt,
                        ChangedBy = sh.ChangedBy,
                        Notes = sh.Notes
                    }).ToList() ?? new List<Models.ViewModels.Account.ReturnStatusHistoryViewModel>(),
                Images = returnRequest.Images?.Select(img => img.ImageUrl).ToList() ?? new List<string>()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CancelReturnRequest(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            var returnRequest = await _dbContext.ReturnRequests
                .FirstOrDefaultAsync(rr => rr.Id == id && rr.UserId == user.Id);

            if (returnRequest == null)
            {
                TempData["ErrorMessage"] = _localizationService["return_request_not_found"];
                return RedirectToAction("Index");
            }

            // Only allow cancellation if status is Pending or UnderReview
            if (returnRequest.Status != Entity.ReturnRequestStatus.Pending && returnRequest.Status != Entity.ReturnRequestStatus.UnderReview)
            {
                TempData["ErrorMessage"] = _localizationService["cannot_cancel_return_request"];
                return RedirectToAction("ReturnRequestDetails", new { id });
            }

            returnRequest.Status = Entity.ReturnRequestStatus.Cancelled;

            // Add status history
            var statusHistory = new Entity.ReturnStatusHistory
            {
                ReturnRequestId = returnRequest.Id,
                Status = Entity.ReturnRequestStatus.Cancelled,
                ChangedAt = DateTime.UtcNow,
                ChangedBy = user.Id,
                Notes = "Cancelled by customer"
            };

            _dbContext.Add(statusHistory);
            await _dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = _localizationService["return_request_cancelled"];
            return RedirectToAction("Index");
        }

        #endregion

        #region Business Profile

        /// <summary>
        /// Checks if the current user can attempt NIP verification (rate limiting)
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CanVerifyNIP()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            var (canAttempt, waitTime) = await _nipValidationService.CanAttemptVerificationAsync(user.Id);
            
            return Json(new 
            { 
                success = true,
                canAttempt,
                waitMinutes = waitTime?.TotalMinutes,
                waitMessage = waitTime.HasValue 
                    ? $"Please wait {(int)waitTime.Value.TotalMinutes} minutes before trying again" 
                    : null
            });
        }

        /// <summary>
        /// Verifies the Polish NIP number with the government API
        /// </summary>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyNIP([FromBody] Models.ViewModels.Account.NIPVerificationRequestModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            if (string.IsNullOrWhiteSpace(model?.NIP))
            {
                return Json(new { success = false, message = "NIP number is required" });
            }

            // Require phone number for business registration
            if (string.IsNullOrWhiteSpace(model.Phone))
            {
                return Json(new { success = false, message = "Company phone number is required for business registration." });
            }

            // Get client IP for logging
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            // Check rate limiting
            var (canAttempt, waitTime) = await _nipValidationService.CanAttemptVerificationAsync(user.Id);
            if (!canAttempt)
            {
                return Json(new 
                { 
                    success = false, 
                    message = $"Too many verification attempts. Please wait {(int)(waitTime?.TotalMinutes ?? 60)} minutes before trying again.",
                    rateLimited = true,
                    waitMinutes = waitTime?.TotalMinutes
                });
            }

            // Validate NIP with government API
            var result = await _nipValidationService.ValidateNIPAsync(model.NIP, user.Id, ipAddress);

            if (result.IsValid && result.BusinessProfile != null)
            {
                _logger.LogInformation("User {UserId} successfully verified NIP {NIP}", user.Id, model.NIP);
                
                // Save additional user-provided company contact fields
                if (!string.IsNullOrWhiteSpace(model.Phone))
                {
                    result.BusinessProfile.Phone = model.Phone;
                }
                if (!string.IsNullOrWhiteSpace(model.CompanyEmail))
                {
                    result.BusinessProfile.CompanyEmail = model.CompanyEmail;
                }
                if (!string.IsNullOrWhiteSpace(model.ContactPerson))
                {
                    result.BusinessProfile.ContactPerson = model.ContactPerson;
                }
                if (!string.IsNullOrWhiteSpace(model.Position))
                {
                    result.BusinessProfile.Position = model.Position;
                }
                await _unitOfWork.SaveChangesAsync();

                return Json(new 
                { 
                    success = true, 
                    message = "NIP verified successfully! Your business profile has been created.",
                    profile = new
                    {
                        nip = result.BusinessProfile.NIP,
                        companyName = result.BusinessProfile.CompanyName,
                        regon = result.BusinessProfile.REGON,
                        krs = result.BusinessProfile.KRS,
                        vatStatus = result.BusinessProfile.VATStatus,
                        residenceAddress = result.BusinessProfile.ResidenceAddress,
                        workingAddress = result.BusinessProfile.WorkingAddress,
                        phone = result.BusinessProfile.Phone,
                        isVerified = result.BusinessProfile.IsVerified,
                        verifiedAt = result.BusinessProfile.VerifiedAt
                    }
                });
            }
            else
            {
                _logger.LogWarning("User {UserId} failed to verify NIP {NIP}: {Error}", user.Id, model.NIP, result.ErrorMessage);
                
                return Json(new 
                { 
                    success = false, 
                    message = result.ErrorMessage ?? "Failed to verify NIP. Please check the number and try again."
                });
            }
        }

        /// <summary>
        /// Gets the current user's business profile
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetBusinessProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            var profile = await _nipValidationService.GetBusinessProfileAsync(user.Id);
            
            if (profile == null)
            {
                return Json(new { success = true, hasProfile = false });
            }

            return Json(new 
            { 
                success = true, 
                hasProfile = true,
                profile = new
                {
                    id = profile.Id,
                    nip = profile.NIP,
                    companyName = profile.CompanyName,
                    regon = profile.REGON,
                    krs = profile.KRS,
                    vatStatus = profile.VATStatus,
                    residenceAddress = profile.ResidenceAddress,
                    workingAddress = profile.WorkingAddress,
                    isVerified = profile.IsVerified,
                    isBusinessModeActive = profile.IsBusinessModeActive,
                    verifiedAt = profile.VerifiedAt,
                    createdAt = profile.CreatedAt
                }
            });
        }

        /// <summary>
        /// Toggles business mode for shopping (switches between retail and B2B mode)
        /// </summary>
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleBusinessMode()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            var profile = await _nipValidationService.GetBusinessProfileAsync(user.Id);
            if (profile == null || !profile.IsVerified)
            {
                return Json(new { success = false, message = "You must have a verified business profile to switch to business mode." });
            }

            var newStatus = await _nipValidationService.ToggleBusinessModeAsync(user.Id);
            
            _logger.LogInformation("User {UserId} toggled business mode to {Status}", user.Id, newStatus);

            return Json(new 
            { 
                success = true, 
                isBusinessModeActive = newStatus,
                message = newStatus 
                    ? "Business mode activated! You can now see business-only products and prices." 
                    : "Retail mode activated! You are now shopping as a regular customer."
            });
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

            try
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    _logger.LogWarning("External login info not available. Check OAuth configuration and callback URL.");
                    _logger.LogWarning("Current request URL: {RequestUrl}", $"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
                    _logger.LogWarning("Available cookies: {Cookies}", string.Join(", ", Request.Cookies.Keys));
                    TempData["ErrorMessage"] = "External login information not available. Please ensure your OAuth callback URL is correctly configured.";
                    return RedirectToAction(nameof(Login), new { ReturnUrl = returnUrl });
                }

                _logger.LogInformation("External login info retrieved for provider: {Provider}, key: {ProviderKey}", info.LoginProvider, info.ProviderKey);

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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception during external login callback: {Message}", ex.Message);
                TempData["ErrorMessage"] = $"Authentication failed: {ex.Message}. Please try again.";
                return RedirectToAction(nameof(Login), new { ReturnUrl = returnUrl });
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

        #region Link/Unlink External Logins

        /// <summary>
        /// Link a new external login provider to the current user's account
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult LinkLogin(string provider)
        {
            // Request a redirect to the external login provider to link a login for the current user
            var redirectUrl = Url.Action(nameof(LinkLoginCallback), "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, _userManager.GetUserId(User));
            return new ChallengeResult(provider, properties);
        }

        /// <summary>
        /// Callback after linking external login
        /// </summary>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LinkLoginCallback()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            var info = await _signInManager.GetExternalLoginInfoAsync(user.Id);
            if (info == null)
            {
                TempData["ErrorMessage"] = "Error loading external login information.";
                return RedirectToAction(nameof(Index));
            }

            var result = await _userManager.AddLoginAsync(user, info);
            if (!result.Succeeded)
            {
                TempData["ErrorMessage"] = $"Failed to link {info.ProviderDisplayName}. It may already be linked to another account.";
                return RedirectToAction(nameof(Index));
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            TempData["SuccessMessage"] = $"Successfully linked {info.ProviderDisplayName} to your account!";
            _logger.LogInformation("User {UserId} linked {Provider} login.", user.Id, info.LoginProvider);
            
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Unlink an external login provider from the current user's account
        /// </summary>
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnlinkLogin(string loginProvider, string providerKey)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user.");
            }

            // Check if user has a password or another login method
            var hasPassword = await _userManager.HasPasswordAsync(user);
            var logins = await _userManager.GetLoginsAsync(user);
            
            if (!hasPassword && logins.Count <= 1)
            {
                TempData["ErrorMessage"] = "You cannot remove your only login method. Please set a password first or link another account.";
                return RedirectToAction(nameof(Index));
            }

            var result = await _userManager.RemoveLoginAsync(user, loginProvider, providerKey);
            if (!result.Succeeded)
            {
                TempData["ErrorMessage"] = $"Failed to unlink {loginProvider}.";
                return RedirectToAction(nameof(Index));
            }

            await _signInManager.RefreshSignInAsync(user);
            TempData["SuccessMessage"] = $"Successfully unlinked {loginProvider} from your account.";
            _logger.LogInformation("User {UserId} unlinked {Provider} login.", user.Id, loginProvider);
            
            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
