using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Kokomija.Models;
using Kokomija.Models.ViewModels;
using Kokomija.Data.Abstract;

namespace Kokomija.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeIndexViewModel
        {
            MetaTitle = "Kokomija - Premium Textile & Fashion",
            MetaDescription = "Discover high-quality clothing and textiles. Shop men's and women's fashion with free shipping on orders over 200 PLN.",
            MetaKeywords = "clothing, fashion, textiles, men's clothing, women's clothing, online shop",
            CanonicalUrl = $"{Request.Scheme}://{Request.Host}{Request.Path}"
        };

        // Get featured categories (top-level only, active)
        var allCategories = await _unitOfWork.Categories.GetAllAsync();
        model.FeaturedCategories = allCategories
            .Where(c => c.IsActive && c.ParentCategoryId == null)
            .OrderBy(c => c.DisplayOrder)
            .Take(6)
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
            Title = "Nowa Kolekcja Jesień 2025",
            Subtitle = "Odkryj najnowsze trendy w modzie",
            ButtonText = "Zobacz Kolekcję",
            ButtonUrl = "/products",
            ImageUrl = "/img/hero-banner.jpg",
            BackgroundColor = "#2C5F7E"
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
