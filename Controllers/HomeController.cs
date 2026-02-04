using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Kokomija.Models;
using Kokomija.Models.ViewModels;
using Kokomija.Data.Abstract;
using Kokomija.Services;
using Microsoft.AspNetCore.Identity;
using Kokomija.Entity;

namespace Kokomija.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILocalizationService _localizationService;
    private readonly IStripeService _stripeService;
    private readonly UserManager<ApplicationUser> _userManager;

    public HomeController(
        ILogger<HomeController> logger, 
        IUnitOfWork unitOfWork,
        ILocalizationService localizationService,
        IStripeService stripeService,
        UserManager<ApplicationUser> userManager)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _localizationService = localizationService;
        _stripeService = stripeService;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index(string? culture = null)
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
        
        // Example: Using localization service in controller
        var welcomeMessage = _localizationService["Home.Welcome"];
        ViewBag.WelcomeMessage = welcomeMessage;

        // Build canonical URL with language prefix for SEO
        var currentCulture = culture ?? Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
        var canonicalPath = currentCulture switch
        {
            "pl" => "/pl/strona-glowna",
            "tr" => "/tr/anasayfa",
            _ => "/en/home"
        };

        var model = new HomeIndexViewModel
        {
            MetaTitle = _localizationService["Home.MetaTitle"],
            MetaDescription = _localizationService["Home.MetaDescription"],
            MetaKeywords = "clothing, fashion, textiles, men's clothing, women's clothing, online shop",
            CanonicalUrl = $"{Request.Scheme}://{Request.Host}{canonicalPath}"
        };

        // Get featured categories with subcategories and translations
        var allCategories = await _unitOfWork.Categories.GetAllAsync(
            "SubCategories",
            "Translations"
        );
        
        // Filter and map categories with translated names
        var currentCultureCode = currentCulture == "pl" ? "pl-PL" : currentCulture == "tr" ? "tr-TR" : "en-US";
        var categories = allCategories
            .Where(c => c.IsActive && c.ParentCategoryId == null)
            .OrderBy(c => c.DisplayOrder)
            .ToList();
        
        // Apply translations to categories and subcategories (in-memory)
        foreach (var category in categories)
        {
            // Apply translation to main category
            var translation = category.Translations?.FirstOrDefault(t => t.CultureCode == currentCultureCode)
                           ?? category.Translations?.FirstOrDefault(t => t.CultureCode == "pl-PL");
            
            if (translation != null)
            {
                category.Name = translation.Name ?? category.Name;
                category.Description = translation.Description ?? category.Description;
            }

            // Apply translations to subcategories
            if (category.SubCategories != null)
            {
                foreach (var subcategory in category.SubCategories)
                {
                    var subTranslation = subcategory.Translations?.FirstOrDefault(t => t.CultureCode == currentCultureCode)
                                      ?? subcategory.Translations?.FirstOrDefault(t => t.CultureCode == "pl-PL");
                    
                    if (subTranslation != null)
                    {
                        subcategory.Name = subTranslation.Name ?? subcategory.Name;
                        subcategory.Description = subTranslation.Description ?? subcategory.Description;
                    }
                }
            }
        }
        
        model.FeaturedCategories = categories;

        // Get featured products (newest, active only)
        var allProducts = await _unitOfWork.Products.GetAllAsync(
            "Images",
            "Variants",
            "Translations"
        );
        
        var featuredProducts = allProducts
            .Where(p => p.IsActive)
            .OrderByDescending(p => p.CreatedAt)
            .Take(8)
            .ToList();

        // Use the same culture code as categories (already defined above)
        model.FeaturedProducts = featuredProducts.Select(p =>
        {
            // Get translation for current culture, fallback to default if not found
            var translation = p.Translations?.FirstOrDefault(t => t.CultureCode == currentCultureCode)
                           ?? p.Translations?.FirstOrDefault(t => t.CultureCode == "pl-PL");
            
            return new ProductCardViewModel
            {
                Id = p.Id,
                Name = translation?.Name ?? p.Name,
                Slug = translation?.Slug ?? p.StripeProductId, // Use translated slug
                Description = translation?.Description ?? p.Description,
                BasePrice = p.Price,
                DiscountedPrice = null,
                MainImagePath = p.Images?.FirstOrDefault()?.ImageUrl,
                IsNew = p.CreatedAt >= DateTime.UtcNow.AddDays(-30),
                IsOnSale = false,
                StockQuantity = p.Variants?.Sum(pv => pv.StockQuantity),
                AvailableColors = new List<string>(),
                AvailableSizes = new List<string>()
            };
        }).ToList();

        // Hero Ad (sample - you can make this dynamic from database)
        model.HeroAd = new HeroAdViewModel
        {
            Title = _localizationService.GetString("Hero_Title", "Home"),
            Subtitle = _localizationService.GetString("Hero_Subtitle", "Home"),
            ButtonText = _localizationService.GetString("Hero_Button", "Home"),
            ButtonUrl = "/products",
            ImageUrl = "/img/hero-banner.jpg",
            BackgroundColor = "#2C5F7E"
        };

        // Get active coupons with usage history
        var allCoupons = await _unitOfWork.Coupons.GetAllAsync(
            "CouponUsages"
        );
        var now = DateTime.UtcNow;
        var userId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        
        var baseCoupons = allCoupons
            .Where(c => c.IsActive && 
                       (!c.ValidFrom.HasValue || c.ValidFrom.Value <= now) && 
                       c.ValidUntil.HasValue &&
                       c.ValidUntil.Value >= now &&
                       (!c.UsageLimit.HasValue || c.UsageCount < c.UsageLimit.Value) &&
                       (c.UserId == null || c.UserId == userId)) // Only user-specific coupons or general coupons
            .ToList();

        // If user is logged in, exclude coupons they've already used (check both local DB and Stripe)
        if (!string.IsNullOrEmpty(userId))
        {
            // Get the user to check their Stripe customer ID
            var user = await _userManager.FindByIdAsync(userId);
            var stripeUsedPromotionCodes = new List<string>();
            
            // If user has a Stripe customer ID, get their used promotion codes from Stripe
            if (user != null && !string.IsNullOrEmpty(user.StripeCustomerId))
            {
                try
                {
                    stripeUsedPromotionCodes = await _stripeService.GetCustomerUsedPromotionCodesAsync(user.StripeCustomerId);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to get Stripe used promotion codes for user {UserId}", userId);
                }
            }
            
            // Exclude coupons that were used either in local DB or in Stripe
            baseCoupons = baseCoupons
                .Where(c => !c.CouponUsages.Any(cu => cu.UserId == userId) && 
                           (string.IsNullOrEmpty(c.StripePromotionCodeId) || !stripeUsedPromotionCodes.Contains(c.StripePromotionCodeId)))
                .ToList();
        }
        else
        {
            // If not logged in, show only new user coupons
            baseCoupons = baseCoupons
                .Where(c => c.CouponType == "new_user")
                .ToList();
        }

        model.ActiveCoupons = baseCoupons
            .Select(c => new CouponBannerViewModel
            {
                Id = c.Id,
                Code = c.Code,
                Description = c.Description ?? string.Empty,
                DiscountType = c.DiscountType,
                DiscountValue = c.DiscountValue,
                MinimumOrderAmount = c.MinimumOrderAmount,
                ValidUntil = c.ValidUntil!.Value,
                IsNew = c.CreatedAt >= DateTime.UtcNow.AddDays(-7),
                DaysUntilExpiry = (int)(c.ValidUntil!.Value - now).TotalDays
            })
            .OrderByDescending(c => c.IsNew)
            .ThenBy(c => c.DaysUntilExpiry)
            .ToList();

        return View(model);
    }

        // Localized privacy policy routes
        [Route("{culture}/polityka-prywatnosci")]
        [Route("{culture}/privacy-policy")]
        [Route("{culture}/gizlilik-politikasi")]
        public IActionResult Privacy(string? culture = null)
        {
            // Set culture if provided
            if (!string.IsNullOrEmpty(culture))
            {
                var cultureCode = culture switch
                {
                    "pl" => "pl-PL",
                    "tr" => "tr-TR",
                    _ => "en-US"
                };
                var cultureInfo = new System.Globalization.CultureInfo(cultureCode);
                System.Globalization.CultureInfo.CurrentCulture = cultureInfo;
                System.Globalization.CultureInfo.CurrentUICulture = cultureInfo;
            }

            var currentCulture = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            var routePath = currentCulture switch
            {
                "pl" => "polityka-prywatnosci",
                "tr" => "gizlilik-politikasi",
                _ => "privacy-policy"
            };
            
            var model = new PrivacyViewModel
            {
                MetaTitle = _localizationService.GetString("Privacy_MetaTitle"),
                MetaDescription = _localizationService.GetString("Privacy_MetaDescription"),
                MetaKeywords = _localizationService.GetString("Privacy_MetaKeywords"),
                CanonicalUrl = $"{Request.Scheme}://{Request.Host}/{currentCulture}/{routePath}"
            };
            return View(model);
        }    
        public IActionResult FAQ()
    {
        var model = new FAQViewModel
        {
            MetaTitle = "FAQ - Frequently Asked Questions | Kokomija",
            MetaDescription = "Find answers to common questions about ordering, shipping, returns, payments, and more.",
            MetaKeywords = "FAQ, help, support, questions, shipping, returns, payment methods",
            CanonicalUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}"
        };

        return View(model);
    }

    public IActionResult Contact()
    {
        var model = new ContactViewModel
        {
            MetaTitle = "Contact Us - Kokomija",
            MetaDescription = "Get in touch with Kokomija. Contact us for any questions about our products, orders, or services.",
            MetaKeywords = "contact, customer service, support, kokomija",
            CanonicalUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}"
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(ContactViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            // Here you would typically send an email or save to database
            // For now, we'll just log it and show a success message
            _logger.LogInformation("Contact form submitted: {Name} - {Email} - {Subject}", 
                model.Name, model.Email, model.Subject);

            TempData["SuccessMessage"] = _localizationService["Contact_SuccessMessage"];
            return RedirectToAction(nameof(Contact));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing contact form");
            ModelState.AddModelError("", _localizationService["Contact_ErrorMessage"]);
            return View(model);
        }
    }

    /// <summary>
    /// Localization example page - demonstrates all ways to use ILocalizationService
    /// </summary>
    public IActionResult LocalizationExample()
    {
        return View();
    }

    [HttpGet]
    public IActionResult SetLanguage(string culture, string returnUrl)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1),
                IsEssential = true,
                Path = "/",
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.Lax
            }
        );

        // Get the localized URL based on the current page and new culture
        var localizedUrl = GetLocalizedUrl(returnUrl, culture);
        return LocalRedirect(localizedUrl);
    }
    
    /// <summary>
    /// Converts a URL to its localized equivalent based on the culture
    /// </summary>
    private string GetLocalizedUrl(string? url, string culture)
    {
        if (string.IsNullOrEmpty(url))
            url = "/";
            
        // Get culture code (pl, en, tr)
        var cultureCode = culture.Split('-')[0].ToLowerInvariant();
        
        // Check if this is a product detail page - handle special case for localized product slugs
        var productDetailMatch = System.Text.RegularExpressions.Regex.Match(
            url, 
            @"^/(pl|en|tr)/(produkt|product|urun)/(.+)$", 
            System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        
        if (productDetailMatch.Success)
        {
            var slug = productDetailMatch.Groups[3].Value;
            // Try to find product by slug and get the correct localized slug
            var localizedSlug = GetLocalizedProductSlug(slug, cultureCode);
            var productPath = cultureCode switch
            {
                "pl" => "produkt",
                "tr" => "urun",
                _ => "product"
            };
            return $"/{cultureCode}/{productPath}/{localizedSlug}";
        }
            
        // Normalize the URL - remove existing culture prefixes
        var normalizedUrl = url.ToLowerInvariant()
            .Replace("/pl/strona-glowna", "/")
            .Replace("/pl/logowanie", "/account/login")
            .Replace("/pl/rejestracja", "/account/register")
            .Replace("/pl/produkty", "/product")
            .Replace("/en/home", "/")
            .Replace("/en/login", "/account/login")
            .Replace("/en/sign-up", "/account/register")
            .Replace("/en/products", "/product")
            .Replace("/tr/anasayfa", "/")
            .Replace("/tr/giris", "/account/login")
            .Replace("/tr/kayit-ol", "/account/register")
            .Replace("/tr/urunler", "/product");
        
        // Map to localized URLs
        return cultureCode switch
        {
            "pl" => normalizedUrl switch
            {
                "/" => "/pl/strona-glowna",
                "/account/login" => "/pl/logowanie",
                "/account/register" => "/pl/rejestracja",
                var p when p.StartsWith("/product") => "/pl/produkty" + p.Replace("/product", ""),
                _ => url // Keep original URL for pages without localized routes
            },
            "tr" => normalizedUrl switch
            {
                "/" => "/tr/anasayfa",
                "/account/login" => "/tr/giris",
                "/account/register" => "/tr/kayit-ol",
                var p when p.StartsWith("/product") => "/tr/urunler" + p.Replace("/product", ""),
                _ => url
            },
            _ => normalizedUrl switch // English (default)
            {
                "/" => "/en/home",
                "/account/login" => "/en/login",
                "/account/register" => "/en/sign-up",
                var p when p.StartsWith("/product") => "/en/products" + p.Replace("/product", ""),
                _ => url
            }
        };
    }
    
    /// <summary>
    /// Gets the localized product slug for the target culture
    /// </summary>
    private string GetLocalizedProductSlug(string currentSlug, string targetCulture)
    {
        try
        {
            // Try to find product by any of its slugs
            var product = _unitOfWork.Products.GetProductBySlugAsync(currentSlug, string.Empty).Result;
            if (product == null)
                return currentSlug;
            
            // Find translation for target culture
            var targetCultureFull = targetCulture switch
            {
                "pl" => "pl-PL",
                "tr" => "tr-TR",
                _ => "en-US"
            };
            
            var translation = product.Translations?.FirstOrDefault(t => 
                t.CultureCode.Equals(targetCultureFull, StringComparison.OrdinalIgnoreCase) ||
                t.CultureCode.StartsWith(targetCulture, StringComparison.OrdinalIgnoreCase));
            
            if (translation != null && !string.IsNullOrEmpty(translation.Slug))
                return translation.Slug;
            
            // Fallback to default slug
            return product.Slug ?? currentSlug;
        }
        catch
        {
            return currentSlug;
        }
    }

    /// <summary>
    /// Invalidate localization cache - useful during development
    /// In production, you should secure this endpoint (require admin role)
    /// </summary>
    [HttpPost]
    public IActionResult InvalidateLocalizationCache()
    {
        try
        {
            _localizationService.InvalidateCache();
            _logger.LogInformation("Localization cache invalidated successfully");
            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = true, message = "Cache invalidated successfully" });
            }
            
            TempData["SuccessMessage"] = "Localization cache has been invalidated and reloaded.";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error invalidating localization cache");
            
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(new { success = false, message = "Error invalidating cache" });
            }
            
            TempData["ErrorMessage"] = "Failed to invalidate cache.";
            return RedirectToAction("Index");
        }
    }

    /// <summary>
    /// Maintenance mode page
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public async Task<IActionResult> Maintenance()
    {
        // If user is Admin or Root, redirect them to admin panel or home
        // They should never see the maintenance page
        if (User?.Identity?.IsAuthenticated == true && 
            (User.IsInRole("Admin") || User.IsInRole("Root")))
        {
            return RedirectToAction("Index", "Admin");
        }
        
        var closures = await _unitOfWork.SiteClosures.GetAllAsync();
        var closure = closures.FirstOrDefault(c => c.IsClosed);
        
        if (closure != null)
        {
            ViewBag.Reason = closure.Reason;
            ViewBag.ScheduledReopen = closure.ScheduledReopenAt?.ToString("MMMM dd, yyyy 'at' hh:mm tt");
        }
        
        ViewBag.ReturnUrl = Request.Query["returnUrl"].ToString();
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
