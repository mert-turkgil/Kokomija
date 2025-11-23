using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Kokomija.Models;
using Kokomija.Models.ViewModels;
using Kokomija.Data.Abstract;
using Kokomija.Services;

namespace Kokomija.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILocalizationService _localizationService;

    public HomeController(
        ILogger<HomeController> logger, 
        IUnitOfWork unitOfWork,
        ILocalizationService localizationService)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
        _localizationService = localizationService;
    }

    public async Task<IActionResult> Index()
    {
        // Example: Using localization service in controller
        var welcomeMessage = _localizationService["Home.Welcome"];
        ViewBag.WelcomeMessage = welcomeMessage;

        var model = new HomeIndexViewModel
        {
            MetaTitle = _localizationService["Home.MetaTitle"],
            MetaDescription = _localizationService["Home.MetaDescription"],
            MetaKeywords = "clothing, fashion, textiles, men's clothing, women's clothing, online shop",
            CanonicalUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}"
        };

        // Get featured categories with subcategories
        var allCategories = await _unitOfWork.Categories.GetAllAsync(c => c.SubCategories);
        model.FeaturedCategories = allCategories
            .Where(c => c.IsActive && c.ParentCategoryId == null)
            .OrderBy(c => c.DisplayOrder)
            .ToList();

        // Get featured products (newest, active only)
        var allProducts = await _unitOfWork.Products.GetAllAsync(
            p => p.Images,
            p => p.Variants
        );
        
        var featuredProducts = allProducts
            .Where(p => p.IsActive)
            .OrderByDescending(p => p.CreatedAt)
            .Take(8)
            .ToList();

        model.FeaturedProducts = featuredProducts.Select(p => new ProductCardViewModel
        {
            Id = p.Id,
            Name = p.Name,
            Slug = p.StripeProductId, // Using StripeProductId as slug for now
            Description = p.Description,
            BasePrice = p.Price,
            DiscountedPrice = null,
            MainImagePath = p.Images?.FirstOrDefault()?.ImageUrl,
            IsNew = p.CreatedAt >= DateTime.UtcNow.AddDays(-30),
            IsOnSale = false,
            StockQuantity = p.Variants?.Sum(pv => pv.StockQuantity),
            AvailableColors = new List<string>(),
            AvailableSizes = new List<string>()
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

        // Get active coupons
        var allCoupons = await _unitOfWork.Coupons.GetAllAsync();
        var now = DateTime.UtcNow;
        model.ActiveCoupons = allCoupons
            .Where(c => c.IsActive && 
                       c.ValidFrom <= now && 
                       c.ValidUntil.HasValue &&
                       c.ValidUntil.Value >= now)
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

        public IActionResult Privacy()
        {
            var model = new PrivacyViewModel
            {
                MetaTitle = _localizationService.GetString("Privacy_MetaTitle"),
                MetaDescription = _localizationService.GetString("Privacy_MetaDescription"),
                MetaKeywords = _localizationService.GetString("Privacy_MetaKeywords"),
                CanonicalUrl = Url.Action("Privacy", "Home", null, Request.Scheme) ?? string.Empty
            };
            return View(model);
        }    public IActionResult FAQ()
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

        return LocalRedirect(returnUrl ?? "/");
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
