using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Admin;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Kokomija.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AdminController> _logger;
    private readonly ICarouselImageService _carouselImageService;
    private readonly ICarouselService _carouselService;
    private readonly ICategoryImageService _categoryImageService;
    private readonly ILocalizationService _localizationService;
    private readonly ITranslationManagementService _translationManagementService;
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;
    private readonly IBlogImageService _blogImageService;
    private readonly IProductImageService _productImageService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IShippingService _shippingService;
    private readonly ITaxService _taxService;
    private readonly IReturnRequestService _returnRequestService;

    public AdminController(
        IUnitOfWork unitOfWork, 
        ILogger<AdminController> logger,
        ICarouselImageService carouselImageService,
        ICarouselService carouselService,
        ICategoryImageService categoryImageService,
        ILocalizationService localizationService,
        ITranslationManagementService translationManagementService,
        IWebHostEnvironment environment,
        IConfiguration configuration,
        IBlogImageService blogImageService,
        IProductImageService productImageService,
        UserManager<ApplicationUser> userManager,
        IShippingService shippingService,
        ITaxService taxService,
        IReturnRequestService returnRequestService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _carouselImageService = carouselImageService;
        _carouselService = carouselService;
        _categoryImageService = categoryImageService;
        _localizationService = localizationService;
        _translationManagementService = translationManagementService;
        _environment = environment;
        _configuration = configuration;
        _blogImageService = blogImageService;
        _productImageService = productImageService;
        _userManager = userManager;
        _shippingService = shippingService;
        _taxService = taxService;
        _returnRequestService = returnRequestService;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Admin accessed dashboard");

        var viewModel = new AdminDashboardViewModel();

        try
        {
            // Get all users
            var allUsers = await _unitOfWork.Users.GetAllUsersAsync();
            viewModel.TotalUsers = allUsers.Count();
            viewModel.ActiveUsers = allUsers.Count(u => u.IsActive);

            // Get all orders
            var allOrders = await _unitOfWork.Orders.GetAllAsync();
            viewModel.TotalOrders = allOrders.Count();
            viewModel.PendingOrders = allOrders.Count(o => o.OrderStatus == "pending" || o.OrderStatus == "processing");
            viewModel.CompletedOrders = allOrders.Count(o => o.OrderStatus == "delivered");
            viewModel.TotalRevenue = allOrders.Where(o => o.PaymentStatus == "paid").Sum(o => o.TotalAmount);
            viewModel.PlatformCommission = allOrders.Where(o => o.PaymentStatus == "paid").Sum(o => o.CommissionAmount);

            // Calculate monthly revenue
            var firstDayOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            viewModel.MonthlyRevenue = allOrders
                .Where(o => o.PaymentStatus == "paid" && o.CreatedAt >= firstDayOfMonth)
                .Sum(o => o.TotalAmount);

            // Get all products
            var allProducts = await _unitOfWork.Products.GetAllAsync();
            viewModel.TotalProducts = allProducts.Count();
            viewModel.ActiveProducts = allProducts.Count(p => p.IsActive);

            // Calculate out of stock products
            var productsWithStock = await _unitOfWork.Products.GetProductsWithVariantsAsync();
            viewModel.OutOfStockProducts = productsWithStock
                .Count(p => p.Variants.All(v => v.StockQuantity == 0));

            // Get recent orders (last 5)
            var recentOrders = allOrders
                .OrderByDescending(o => o.CreatedAt)
                .Take(5)
                .ToList();

            viewModel.RecentOrders = recentOrders.Select(o => new RecentOrderViewModel
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                CustomerName = o.CustomerName ?? "Guest",
                CustomerEmail = o.CustomerEmail,
                TotalAmount = o.TotalAmount,
                OrderStatus = o.OrderStatus,
                PaymentStatus = o.PaymentStatus,
                CreatedAt = o.CreatedAt,
                Currency = o.Currency.ToUpper()
            }).ToList();

            // Get recent users (last 5)
            var recentUsers = allUsers
                .OrderByDescending(u => u.CreatedAt)
                .Take(5)
                .ToList();

            viewModel.RecentUsers = recentUsers.Select(u => new RecentUserViewModel
            {
                Id = u.Id,
                Email = u.Email ?? string.Empty,
                FirstName = u.FirstName,
                LastName = u.LastName,
                VipTier = u.VipTier,
                TotalSpent = u.TotalSpent,
                CreatedAt = u.CreatedAt,
                LastLoginAt = u.LastLoginAt
            }).ToList();

            // Get low stock products (stock < 10)
            var lowStockProducts = productsWithStock
                .Where(p => p.Variants.Sum(v => v.StockQuantity) < 10 && p.IsActive)
                .OrderBy(p => p.Variants.Sum(v => v.StockQuantity))
                .Take(5)
                .ToList();

            viewModel.LowStockProducts = lowStockProducts.Select(p => new LowStockProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                TotalStock = p.Variants.Sum(v => v.StockQuantity),
                ImageUrl = p.Images.FirstOrDefault()?.ImageUrl,
                Price = p.Price,
                IsActive = p.IsActive
            }).ToList();

            // Get recent reviews (last 5)
            var allReviews = await _unitOfWork.ProductReviews.GetAllAsync();
            var recentReviewsList = allReviews
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .ToList();
            
            viewModel.RecentReviews = recentReviewsList.Select(r => new RecentReviewViewModel
            {
                Id = r.Id,
                ProductName = r.Product?.Name ?? "Unknown",
                UserName = r.User?.Email ?? "Anonymous",
                Rating = r.Rating,
                Comment = r.Comment.Length > 100 ? r.Comment.Substring(0, 100) + "..." : r.Comment,
                IsVisible = r.IsVisible,
                CreatedAt = r.CreatedAt
            }).ToList();

            // Blog statistics
            var allBlogs = await _unitOfWork.Blogs.GetAllAsync();
            viewModel.TotalBlogs = allBlogs.Count();
            viewModel.PublishedBlogs = allBlogs.Count(b => b.IsPublished);
            viewModel.DraftBlogs = allBlogs.Count(b => !b.IsPublished);

            // Additional metrics
            var newsletterSubs = await _unitOfWork.Repository<Kokomija.Entity.NewsletterSubscription>().GetAllAsync();
            viewModel.NewsletterSubscribers = newsletterSubs.Count(n => n.IsActive);

            var coupons = await _unitOfWork.Coupons.GetAllAsync();
            viewModel.ActiveCoupons = coupons.Count(c => c.IsActive);

            viewModel.PendingReviews = allReviews.Count(r => !r.IsVisible);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading admin dashboard data");
            // Continue with empty viewModel - UI will show zeros
        }

        return View(viewModel);
    }

    public IActionResult Users()
    {
        // Future: User management
        return View();
    }

    /// <summary>
    /// GET: Product Management page
    /// </summary>
    public async Task<IActionResult> Products()
    {
        _logger.LogInformation("Admin accessed product management");

        var productsList = await _unitOfWork.Repository<Product>()
            .FindAsync(p => true, p => p.Category!.ParentCategory!);
        
        var productDtos = new List<ProductListItemDto>();
        
        foreach (var product in productsList)
        {
            var variants = (await _unitOfWork.Repository<ProductVariant>()
                .FindAsync(v => v.ProductId == product.Id)).ToList();
            
            var reviews = (await _unitOfWork.Repository<ProductReview>()
                .FindAsync(r => r.ProductId == product.Id && r.IsVisible)).ToList();
            
            var images = (await _unitOfWork.Repository<ProductImage>()
                .FindAsync(i => i.ProductId == product.Id)).OrderBy(i => i.DisplayOrder).ToList();

            productDtos.Add(new ProductListItemDto
            {
                Id = product.Id,
                Name = product.Name,
                CategoryName = product.Category?.Name,
                ParentCategoryName = product.Category?.ParentCategory?.Name,
                Price = product.Price,
                PackSize = product.PackSize,
                IsActive = product.IsActive,
                TotalStock = variants.Sum(v => v.StockQuantity),
                TotalVariants = variants.Count,
                ReviewCount = reviews.Count,
                AverageRating = reviews.Any() ? reviews.Average(r => r.Rating) : 0,
                FeaturedImage = images.FirstOrDefault()?.ImageUrl,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                StripeProductId = product.StripeProductId,
                StripePriceId = product.StripePriceId
            });
        }

        var productsArray = productsList.ToList();

        var viewModel = new ProductManagementViewModel
        {
            Products = productDtos.OrderByDescending(p => p.CreatedAt).ToList(),
            TotalProducts = productsArray.Count,
            ActiveProducts = productsArray.Count(p => p.IsActive),
            InactiveProducts = productsArray.Count(p => !p.IsActive),
            OutOfStockProducts = productDtos.Count(p => p.TotalStock == 0),
            TotalInventoryValue = productDtos.Sum(p => p.Price * p.TotalStock)
        };

        ViewData["Title"] = "Product Management";
        return View(viewModel);
    }

    public IActionResult Orders()
    {
        // Future: Order management
        return View();
    }

    public async Task<IActionResult> Settings(string? tab = null)
    {
        _logger.LogInformation("Admin accessed site settings");
        
        // Pass tab parameter to view for active tab selection
        if (!string.IsNullOrEmpty(tab))
        {
            ViewBag.ActiveTab = tab;
        }

        var viewModel = new SiteSettingsViewModel();

        try
        {
            // Get carousel slides (exclude soft-deleted)
            var carouselSlides = await _unitOfWork.CarouselSlides.GetAllAsync();
            var activeCarouselSlides = carouselSlides.Where(c => !c.IsDeleted).ToList();
            viewModel.CarouselSlides = activeCarouselSlides.Select(c => new CarouselSlideItemViewModel
            {
                Id = c.Id,
                Title = c.Title,
                Subtitle = c.Subtitle,
                ImagePath = c.ImagePath,
                LinkUrl = c.LinkUrl,
                ButtonText = c.ButtonText,
                DisplayOrder = c.DisplayOrder,
                IsActive = c.IsActive,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Location = c.Location,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy
            }).OrderBy(c => c.DisplayOrder).ToList();

            viewModel.TotalCarouselSlides = activeCarouselSlides.Count();
            viewModel.ActiveCarouselSlides = activeCarouselSlides.Count(c => c.IsActive);

            // Get categories
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var categoryViewModels = new List<CategoryItemViewModel>();

            foreach (var category in categories.Where(c => c.ParentCategoryId == null).OrderBy(c => c.DisplayOrder))
            {
                var categoryVm = new CategoryItemViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    NameKey = category.NameKey,
                    Slug = category.Slug,
                    ParentCategoryId = category.ParentCategoryId,
                    DisplayOrder = category.DisplayOrder,
                    ShowInNavbar = category.ShowInNavbar,
                    IsActive = category.IsActive,
                    IconCssClass = category.IconCssClass,
                    ImageUrl = category.ImageUrl,
                    ProductCount = category.Products.Count,
                    SubcategoryCount = categories.Count(c => c.ParentCategoryId == category.Id)
                };

                // Get subcategories
                categoryVm.Subcategories = categories
                    .Where(c => c.ParentCategoryId == category.Id)
                    .OrderBy(c => c.DisplayOrder)
                    .Select(sub => new CategoryItemViewModel
                    {
                        Id = sub.Id,
                        Name = sub.Name,
                        NameKey = sub.NameKey,
                        Slug = sub.Slug,
                        ParentCategoryId = sub.ParentCategoryId,
                        ParentCategoryName = category.Name,
                        DisplayOrder = sub.DisplayOrder,
                        ShowInNavbar = sub.ShowInNavbar,
                        IsActive = sub.IsActive,
                        IconCssClass = sub.IconCssClass,
                        ImageUrl = sub.ImageUrl,
                        ProductCount = sub.Products.Count,
                        SubcategoryCount = 0
                    }).ToList();

                categoryViewModels.Add(categoryVm);
            }

            viewModel.Categories = categoryViewModels;
            viewModel.TotalCategories = categories.Count(c => c.ParentCategoryId == null);
            viewModel.ActiveCategories = categories.Count(c => c.IsActive && c.ParentCategoryId == null);
            viewModel.TotalSubcategories = categories.Count(c => c.ParentCategoryId != null);

            // Get blog posts
            var blogs = await _unitOfWork.Blogs.GetAllAsync();
            var currentCulture = System.Globalization.CultureInfo.CurrentCulture.Name;
            
            viewModel.BlogPosts = new List<BlogItemViewModel>();
            foreach (var blog in blogs.Where(b => !b.IsDeleted).OrderByDescending(b => b.CreatedAt))
            {
                var translations = (await _unitOfWork.Repository<Entity.BlogTranslation>()
                    .FindAsync(t => t.BlogId == blog.Id)).ToList();
                
                var translation = translations.FirstOrDefault(t => t.CultureCode == currentCulture)
                                ?? translations.FirstOrDefault(t => t.CultureCode == "pl-PL");

                if (translation != null)
                {
                    viewModel.BlogPosts.Add(new BlogItemViewModel
                    {
                        Id = blog.Id,
                        Title = translation.Title,
                        Slug = translation.Slug,
                        FeaturedImage = blog.FeaturedImage,
                        AuthorName = blog.Author?.UserName ?? "Unknown",
                        CategoryName = blog.Category?.Name ?? "Uncategorized",
                        IsPublished = blog.IsPublished,
                        PublishedDate = blog.PublishedDate,
                        Views = blog.Views,
                        CreatedAt = blog.CreatedAt,
                        UpdatedAt = blog.UpdatedAt
                    });
                }
            }
            
            viewModel.TotalBlogs = blogs.Count(b => !b.IsDeleted);
            viewModel.PublishedBlogs = blogs.Count(b => !b.IsDeleted && b.IsPublished);
            viewModel.DraftBlogs = blogs.Count(b => !b.IsDeleted && !b.IsPublished);

            // Supported Languages (placeholder - you can implement database storage later)
            viewModel.SupportedLanguages = new List<LanguageViewModel>
            {
                new LanguageViewModel
                {
                    Id = 1,
                    CultureCode = "en-US",
                    DisplayName = "English",
                    NativeName = "English",
                    FlagIcon = "🇺🇸",
                    IsEnabled = true,
                    IsDefault = false,
                    DisplayOrder = 1
                },
                new LanguageViewModel
                {
                    Id = 2,
                    CultureCode = "pl-PL",
                    DisplayName = "Polish",
                    NativeName = "Polski",
                    FlagIcon = "🇵🇱",
                    IsEnabled = true,
                    IsDefault = true,
                    DisplayOrder = 2
                }
            };

            // Translation keys - no longer showing placeholder data, 
            // will be loaded via AJAX in the UI
            viewModel.TranslationKeys = new List<TranslationKeyViewModel>();
            
            // Count resource file pairs (each category has en-US and pl-PL)
            var resourceFolders = await _translationManagementService.GetAllTranslationFilesAsync();
            viewModel.TotalTranslationKeys = resourceFolders.Sum(f => f.KeyCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading site settings");
        }

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> BlogSettings()
    {
        _logger.LogInformation("Admin accessed blog settings");

        var viewModel = new SiteSettingsViewModel();

        try
        {
            // Get all blogs with their translations
            var blogs = (await _unitOfWork.Blogs.GetAllAsync()).ToList();
            var currentCulture = CultureInfo.CurrentCulture.Name;

            viewModel.BlogPosts = new List<BlogItemViewModel>();

            foreach (var blog in blogs.Where(b => !b.IsDeleted))
            {
                var translations = (await _unitOfWork.Repository<Entity.BlogTranslation>()
                    .FindAsync(t => t.BlogId == blog.Id)).ToList();
                
                var translation = translations.FirstOrDefault(t => t.CultureCode == currentCulture)
                                ?? translations.FirstOrDefault(t => t.CultureCode == "pl-PL");

                if (translation != null)
                {
                    viewModel.BlogPosts.Add(new BlogItemViewModel
                    {
                        Id = blog.Id,
                        Title = translation.Title,
                        Slug = translation.Slug,
                        FeaturedImage = blog.FeaturedImage,
                        AuthorName = blog.Author?.UserName ?? "Unknown",
                        CategoryName = blog.Category?.Name ?? "Uncategorized",
                        IsPublished = blog.IsPublished,
                        PublishedDate = blog.PublishedDate,
                        Views = blog.Views,
                        CreatedAt = blog.CreatedAt,
                        UpdatedAt = blog.UpdatedAt
                    });
                }
            }
            
            viewModel.TotalBlogs = blogs.Count(b => !b.IsDeleted);
            viewModel.PublishedBlogs = blogs.Count(b => !b.IsDeleted && b.IsPublished);
            viewModel.DraftBlogs = blogs.Count(b => !b.IsDeleted && !b.IsPublished);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading blog settings");
        }

        // Load blog categories for filter dropdown
        var blogCategories = await _unitOfWork.BlogCategories.GetActiveCategoriesAsync();
        ViewBag.BlogCategories = blogCategories.OrderBy(c => c.DisplayOrder).ToList();

        return View(viewModel);
    }

    #region Carousel Slide Management

    /// <summary>
    /// GET: Create new carousel slide form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> CarouselCreate()
    {
        ViewData["Title"] = _localizationService["Admin_Carousel_CreateNew"];
        
        var viewModel = new CarouselSlideCreateDto
        {
            DisplayOrder = 0,
            IsActive = true,
            Location = "Home",
            TextAlign = "center",
            AnimationType = "fade",
            Duration = 5000,
            ButtonClass = "btn-primary",
            Translations = new List<CarouselSlideTranslationDto>
            {
                new CarouselSlideTranslationDto 
                { 
                    CultureCode = "en-US",
                    Title = "",
                    Subtitle = "",
                    ButtonText = "",
                    ImageAlt = ""
                },
                new CarouselSlideTranslationDto 
                { 
                    CultureCode = "pl-PL",
                    Title = "",
                    Subtitle = "",
                    ButtonText = "",
                    ImageAlt = ""
                }
            }
        };

        // Load categories for dropdown
        var categories = await _unitOfWork.Categories.GetAllAsync();
        ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();

        return View(viewModel);
    }

    /// <summary>
    /// POST: Create new carousel slide
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CarouselCreate(CarouselSlideCreateDto model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorSave"];
            return View(model);
        }

        try
        {
            // Process images from temp folder to permanent location
            var (desktopPath, tabletPath, mobilePath) = await _carouselImageService.ProcessAndMoveFromTempAsync(
                model.DesktopImageTempFileName,
                model.TabletImageTempFileName,
                model.MobileImageTempFileName
            );

            // Create the carousel slide entity
            var slide = new CarouselSlide
            {
                ImagePath = desktopPath,
                TabletImagePath = !string.IsNullOrEmpty(tabletPath) ? tabletPath : desktopPath,
                MobileImagePath = !string.IsNullOrEmpty(mobilePath) ? mobilePath : (!string.IsNullOrEmpty(tabletPath) ? tabletPath : desktopPath),
                DisplayOrder = model.DisplayOrder,
                IsActive = model.IsActive,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Location = model.Location,
                CategoryId = model.CategoryId,
                BackgroundColor = model.BackgroundColor,
                TextColor = model.TextColor,
                TextAlign = model.TextAlign,
                AnimationType = model.AnimationType,
                Duration = model.Duration,
                CustomCssClass = model.CustomCssClass,
                ButtonClass = model.ButtonClass ?? "btn-primary",
                
                // Temporary values from first translation (will be replaced by translation entity)
                Title = model.Translations.FirstOrDefault()?.Title ?? "Untitled",
                ImageAlt = model.Translations.FirstOrDefault()?.ImageAlt ?? "Carousel slide"
            };

            // Save slide to get ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system";
            var createdSlide = await _carouselService.CreateSlideAsync(slide, userId);

            // Create translations for each language
            foreach (var translationDto in model.Translations)
            {
                var translation = new CarouselSlideTranslation
                {
                    CarouselSlideId = createdSlide.Id,
                    CultureCode = translationDto.CultureCode,
                    Title = translationDto.Title,
                    Subtitle = translationDto.Subtitle,
                    ButtonText = translationDto.ButtonText,
                    ImageAlt = translationDto.ImageAlt ?? translationDto.Title,
                    LinkUrl = translationDto.LinkUrl,
                    ControllerName = translationDto.ControllerName,
                    ActionName = translationDto.ActionName,
                    AreaName = translationDto.AreaName,
                    RouteParameters = translationDto.RouteParameters
                };

                await _unitOfWork.CarouselSlideTranslations.AddAsync(translation);
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Carousel slide created successfully: {SlideId}", createdSlide.Id);
            TempData["Success"] = _localizationService["Admin_Carousel_SuccessCreated"];
            
            return RedirectToAction(nameof(Settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating carousel slide");
            
            // Clean up temp files on error
            var tempFilesToCleanup = new[] 
            { 
                model.DesktopImageTempFileName, 
                model.TabletImageTempFileName, 
                model.MobileImageTempFileName 
            }
            .Where(f => !string.IsNullOrEmpty(f))
            .Select(f => f!)
            .ToArray();
            
            if (tempFilesToCleanup.Length > 0)
            {
                await _carouselImageService.DeleteTempFilesAsync(tempFilesToCleanup);
            }

            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorSave"];
            return View(model);
        }
    }

    /// <summary>
    /// GET: Edit carousel slide form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> CarouselEdit(int id)
    {
        var slide = await _unitOfWork.CarouselSlides.GetByIdAsync(id);
        if (slide == null)
        {
            TempData["Error"] = "Carousel slide not found";
            return RedirectToAction(nameof(Settings));
        }

        // Load translations
        var translations = (await _unitOfWork.CarouselSlideTranslations.FindAsync(t => t.CarouselSlideId == id)).ToList();

        var viewModel = new CarouselSlideUpdateDto
        {
            Id = slide.Id,
            DisplayOrder = slide.DisplayOrder,
            IsActive = slide.IsActive,
            StartDate = slide.StartDate,
            EndDate = slide.EndDate,
            Location = slide.Location,
            CategoryId = slide.CategoryId,
            BackgroundColor = slide.BackgroundColor,
            TextColor = slide.TextColor,
            TextAlign = slide.TextAlign,
            AnimationType = slide.AnimationType,
            Duration = slide.Duration,
            CustomCssClass = slide.CustomCssClass,
            ButtonClass = slide.ButtonClass,
            Translations = translations.Select(t => new CarouselSlideTranslationDto
            {
                Id = t.Id,
                CultureCode = t.CultureCode,
                Title = t.Title,
                Subtitle = t.Subtitle,
                ButtonText = t.ButtonText,
                ImageAlt = t.ImageAlt,
                LinkUrl = t.LinkUrl,
                ControllerName = t.ControllerName,
                ActionName = t.ActionName,
                AreaName = t.AreaName,
                RouteParameters = t.RouteParameters
            }).ToList()
        };

        // Ensure we have translations for both languages
        if (!viewModel.Translations.Any(t => t.CultureCode == "en-US"))
        {
            viewModel.Translations.Add(new CarouselSlideTranslationDto { CultureCode = "en-US" });
        }
        if (!viewModel.Translations.Any(t => t.CultureCode == "pl-PL"))
        {
            viewModel.Translations.Add(new CarouselSlideTranslationDto { CultureCode = "pl-PL" });
        }

        // Load current images for preview
        ViewBag.CurrentDesktopImage = slide.ImagePath;
        ViewBag.CurrentTabletImage = slide.TabletImagePath;
        ViewBag.CurrentMobileImage = slide.MobileImagePath;

        // Load categories for dropdown
        var categories = await _unitOfWork.Categories.GetAllAsync();
        ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();

        ViewData["Title"] = _localizationService["Admin_Carousel_EditSlide"];
        return View(viewModel);
    }

    /// <summary>
    /// POST: Update carousel slide
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CarouselEdit(CarouselSlideUpdateDto model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorSave"];
            return View(model);
        }

        try
        {
            var slide = await _unitOfWork.CarouselSlides.GetByIdAsync(model.Id);
            if (slide == null)
            {
                TempData["Error"] = "Carousel slide not found";
                return RedirectToAction(nameof(Settings));
            }

            // Process new images if provided
            if (!string.IsNullOrEmpty(model.NewDesktopImageTempFileName) ||
                !string.IsNullOrEmpty(model.NewTabletImageTempFileName) ||
                !string.IsNullOrEmpty(model.NewMobileImageTempFileName))
            {
                var (desktopPath, tabletPath, mobilePath) = await _carouselImageService.ProcessAndMoveFromTempAsync(
                    model.NewDesktopImageTempFileName ?? null,
                    model.NewTabletImageTempFileName ?? null,
                    model.NewMobileImageTempFileName ?? null
                );

                // Delete old images
                if (!string.IsNullOrEmpty(desktopPath))
                {
                    await _carouselImageService.DeletePermanentImagesAsync(slide.ImagePath);
                    slide.ImagePath = desktopPath;
                }

                if (!string.IsNullOrEmpty(tabletPath))
                {
                    if (!string.IsNullOrEmpty(slide.TabletImagePath))
                    {
                        await _carouselImageService.DeletePermanentImagesAsync(slide.TabletImagePath);
                    }
                    slide.TabletImagePath = tabletPath;
                }

                if (!string.IsNullOrEmpty(mobilePath))
                {
                    if (!string.IsNullOrEmpty(slide.MobileImagePath))
                    {
                        await _carouselImageService.DeletePermanentImagesAsync(slide.MobileImagePath);
                    }
                    slide.MobileImagePath = mobilePath;
                }
            }

            // Update slide properties
            slide.DisplayOrder = model.DisplayOrder;
            slide.IsActive = model.IsActive;
            slide.StartDate = model.StartDate;
            slide.EndDate = model.EndDate;
            slide.Location = model.Location;
            slide.CategoryId = model.CategoryId;
            slide.BackgroundColor = model.BackgroundColor;
            slide.TextColor = model.TextColor;
            slide.TextAlign = model.TextAlign;
            slide.AnimationType = model.AnimationType;
            slide.Duration = model.Duration;
            slide.CustomCssClass = model.CustomCssClass;
            slide.ButtonClass = model.ButtonClass;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system";
            await _carouselService.UpdateSlideAsync(slide, userId);

            // Update or create translations
            foreach (var translationDto in model.Translations)
            {
                if (translationDto.Id.HasValue)
                {
                    // Update existing translation
                    var existingTranslation = await _unitOfWork.CarouselSlideTranslations.GetByIdAsync(translationDto.Id.Value);
                    if (existingTranslation != null)
                    {
                        existingTranslation.Title = translationDto.Title;
                        existingTranslation.Subtitle = translationDto.Subtitle;
                        existingTranslation.ButtonText = translationDto.ButtonText;
                        existingTranslation.ImageAlt = translationDto.ImageAlt ?? translationDto.Title;
                        existingTranslation.LinkUrl = translationDto.LinkUrl;
                        existingTranslation.ControllerName = translationDto.ControllerName;
                        existingTranslation.ActionName = translationDto.ActionName;
                        existingTranslation.AreaName = translationDto.AreaName;
                        existingTranslation.RouteParameters = translationDto.RouteParameters;
                        existingTranslation.UpdatedAt = DateTime.UtcNow;

                        _unitOfWork.CarouselSlideTranslations.Update(existingTranslation);
                    }
                }
                else
                {
                    // Create new translation
                    var newTranslation = new CarouselSlideTranslation
                    {
                        CarouselSlideId = slide.Id,
                        CultureCode = translationDto.CultureCode,
                        Title = translationDto.Title,
                        Subtitle = translationDto.Subtitle,
                        ButtonText = translationDto.ButtonText,
                        ImageAlt = translationDto.ImageAlt ?? translationDto.Title,
                        LinkUrl = translationDto.LinkUrl,
                        ControllerName = translationDto.ControllerName,
                        ActionName = translationDto.ActionName,
                        AreaName = translationDto.AreaName,
                        RouteParameters = translationDto.RouteParameters
                    };

                    await _unitOfWork.CarouselSlideTranslations.AddAsync(newTranslation);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Carousel slide updated successfully: {SlideId}", slide.Id);
            TempData["Success"] = _localizationService["Admin_Carousel_SuccessUpdated"];

            return RedirectToAction(nameof(Settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating carousel slide");

            // Clean up temp files on error
            var tempFilesToCleanup = new[] 
            { 
                model.NewDesktopImageTempFileName, 
                model.NewTabletImageTempFileName, 
                model.NewMobileImageTempFileName 
            }
            .Where(f => !string.IsNullOrEmpty(f))
            .Select(f => f!)
            .ToArray();
            
            if (tempFilesToCleanup.Length > 0)
            {
                await _carouselImageService.DeleteTempFilesAsync(tempFilesToCleanup);
            }

            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorSave"];
            return View(model);
        }
    }

    /// <summary>
    /// POST: Delete carousel slide
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CarouselDelete(int id)
    {
        try
        {
            var slide = await _unitOfWork.CarouselSlides.GetByIdAsync(id);
            if (slide == null)
            {
                TempData["Error"] = _localizationService["Admin_Carousel_NotFound"];
                return RedirectToAction(nameof(Settings), new { tab = "carousel" });
            }

            _logger.LogInformation("Deleting carousel slide {SlideId}: Desktop={Desktop}, Tablet={Tablet}, Mobile={Mobile}", 
                id, slide.ImagePath, slide.TabletImagePath, slide.MobileImagePath);

            // Delete physical image files FIRST before soft delete
            var imagesToDelete = new List<string>();
            if (!string.IsNullOrEmpty(slide.ImagePath)) imagesToDelete.Add(slide.ImagePath);
            if (!string.IsNullOrEmpty(slide.TabletImagePath)) imagesToDelete.Add(slide.TabletImagePath);
            if (!string.IsNullOrEmpty(slide.MobileImagePath)) imagesToDelete.Add(slide.MobileImagePath);

            foreach (var imagePath in imagesToDelete)
            {
                try
                {
                    await _carouselImageService.DeletePermanentImagesAsync(imagePath);
                    _logger.LogInformation("Successfully deleted image: {ImagePath}", imagePath);
                }
                catch (Exception imgEx)
                {
                    _logger.LogError(imgEx, "Failed to delete image: {ImagePath}", imagePath);
                    // Continue with other deletions even if one fails
                }
            }

            // Delete from database (soft delete)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system";
            await _carouselService.DeleteSlideAsync(id, userId);

            _logger.LogInformation("Carousel slide deleted successfully: {SlideId} by user {UserId}", id, userId);
            TempData["Success"] = _localizationService["Admin_Carousel_SuccessDeleted"];
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting carousel slide {SlideId}", id);
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorDeleted"];
        }

        return RedirectToAction(nameof(Settings), new { tab = "carousel" });
    }

    /// <summary>
    /// POST: Upload image to temp folder (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CarouselUploadImage(IFormFile file, string imageType)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return Json(new { success = false, message = "No file provided" });
            }

            var tempFileName = await _carouselImageService.UploadToTempAsync(file, imageType);

            return Json(new
            {
                success = true,
                tempFileName = tempFileName,
                tempPath = $"/img/Carousel/temp/{tempFileName}",
                message = "Image uploaded successfully"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading carousel image");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Delete temp files (AJAX) - called when user cancels
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CarouselCancelUpload([FromBody] CarouselCancelUploadDto model)
    {
        try
        {
            await _carouselImageService.DeleteTempFilesAsync(model.TempFileNames.ToArray());

            return Json(new { success = true, message = "Temp files deleted" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting temp files");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Toggle carousel slide active status (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CarouselToggleActive(int id)
    {
        try
        {
            var result = await _carouselService.ToggleActiveStatusAsync(id);

            if (result)
            {
                return Json(new { success = true, message = "Status toggled successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Slide not found" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling carousel slide status");
            return Json(new { success = false, message = ex.Message });
        }
    }

    #endregion

    #region Category Management

    /// <summary>
    /// GET: Create new category form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> CategoryCreate()
    {
        ViewData["Title"] = _localizationService["Admin_Category_CreateNew"];
        
        var viewModel = new CategoryCreateDto
        {
            DisplayOrder = 0,
            IsActive = true,
            ShowInNavbar = true,
            Translations = new List<CategoryTranslationDto>
            {
                new CategoryTranslationDto 
                { 
                    CultureCode = "en-US",
                    Name = "",
                    Slug = "",
                    Description = ""
                },
                new CategoryTranslationDto 
                { 
                    CultureCode = "pl-PL",
                    Name = "",
                    Slug = "",
                    Description = ""
                }
            }
        };

        // Load parent categories for dropdown
        var categories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
        ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();

        return View(viewModel);
    }

    /// <summary>
    /// POST: Create new category
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CategoryCreate(CategoryCreateDto model)
    {
        // Prevent subcategories from having parent categories (no sub-subcategories)
        if (model.ParentCategoryId.HasValue)
        {
            var parentCategory = await _unitOfWork.Categories.GetByIdAsync(model.ParentCategoryId.Value);
            if (parentCategory != null && parentCategory.ParentCategoryId.HasValue)
            {
                ModelState.AddModelError("ParentCategoryId", "Cannot create a subcategory under another subcategory. Only 2 levels are supported.");
            }
        }

        if (!ModelState.IsValid)
        {
            var categories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Category_ErrorSave"];
            return View(model);
        }

        var tempFilesToCleanup = new string[] { };

        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Create the category entity
            var category = new Category
            {
                Name = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US")?.Name ?? "Unnamed",
                Slug = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US")?.Slug ?? "unnamed",
                Description = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US")?.Description,
                ParentCategoryId = model.ParentCategoryId,
                DisplayOrder = model.DisplayOrder,
                IsActive = model.IsActive,
                ShowInNavbar = model.ShowInNavbar,
                IconCssClass = model.IconCssClass,
                CreatedBy = userId,
                CreatedAt = DateTime.UtcNow
            };

            // Handle image upload for main categories
            if (!string.IsNullOrEmpty(model.ImageTempFileName))
            {
                tempFilesToCleanup = new[] { model.ImageTempFileName };
                var imageUrl = await _categoryImageService.MoveTempImageToPermanentAsync(
                    model.ImageTempFileName, 
                    category.Slug);
                category.ImageUrl = imageUrl;
            }

            // Add category to database
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            // Add translations
            foreach (var translationDto in model.Translations)
            {
                var translation = new CategoryTranslation
                {
                    CategoryId = category.Id,
                    CultureCode = translationDto.CultureCode,
                    Name = translationDto.Name,
                    Slug = translationDto.Slug,
                    Description = translationDto.Description,
                    MetaDescription = translationDto.MetaDescription,
                    MetaKeywords = translationDto.MetaKeywords,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.CategoryTranslations.AddAsync(translation);
            }

            await _unitOfWork.SaveChangesAsync();

            TempData["Success"] = _localizationService["Admin_Category_SuccessCreate"];
            _logger.LogInformation("Category created: {CategoryId} by {UserId}", category.Id, userId);

            return RedirectToAction(nameof(Settings), new { tab = "categories" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating category");
            TempData["Error"] = _localizationService["Admin_Category_ErrorSave"];
            
            if (tempFilesToCleanup.Length > 0)
            {
                await _categoryImageService.CleanupTempFilesAsync(tempFilesToCleanup.ToList());
            }

            var categories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
            ViewBag.ParentCategories = categories.OrderBy(c => c.DisplayOrder).ToList();
            return View(model);
        }
    }

    /// <summary>
    /// GET: Edit category form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> CategoryEdit(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdWithTranslationsAsync(id);
        if (category == null)
        {
            TempData["Error"] = "Category not found";
            return RedirectToAction(nameof(Settings));
        }

        var viewModel = new CategoryUpdateDto
        {
            Id = category.Id,
            ParentCategoryId = category.ParentCategoryId,
            DisplayOrder = category.DisplayOrder,
            IsActive = category.IsActive,
            ShowInNavbar = category.ShowInNavbar,
            IconCssClass = category.IconCssClass,
            Translations = category.Translations.Select(t => new CategoryTranslationDto
            {
                Id = t.Id,
                CultureCode = t.CultureCode,
                Name = t.Name,
                Slug = t.Slug,
                Description = t.Description,
                MetaDescription = t.MetaDescription,
                MetaKeywords = t.MetaKeywords
            }).ToList()
        };

        // Ensure we have translations for both languages
        if (!viewModel.Translations.Any(t => t.CultureCode == "en-US"))
        {
            viewModel.Translations.Add(new CategoryTranslationDto { CultureCode = "en-US" });
        }
        if (!viewModel.Translations.Any(t => t.CultureCode == "pl-PL"))
        {
            viewModel.Translations.Add(new CategoryTranslationDto { CultureCode = "pl-PL" });
        }

        // Load current image for preview
        ViewBag.CurrentImage = category.ImageUrl;

        // Only show top-level categories as parent options (no subcategories)
        // Exclude current category to prevent self-parenting
        var allCategories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
        ViewBag.Categories = allCategories
            .Where(c => c.Id != id)
            .OrderBy(c => c.DisplayOrder)
            .ToList();

        ViewData["Title"] = _localizationService["Admin_Category_Edit"];
        return View(viewModel);
    }

    /// <summary>
    /// POST: Update category
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CategoryEdit(CategoryUpdateDto model)
    {
        // Prevent subcategories from having parent categories (no sub-subcategories)
        if (model.ParentCategoryId.HasValue)
        {
            var parentCategory = await _unitOfWork.Categories.GetByIdAsync(model.ParentCategoryId.Value);
            if (parentCategory != null && parentCategory.ParentCategoryId.HasValue)
            {
                ModelState.AddModelError("ParentCategoryId", "Cannot set parent to a subcategory. Only 2 levels are supported.");
            }

            // Prevent category from being its own parent
            if (model.ParentCategoryId.Value == model.Id)
            {
                ModelState.AddModelError("ParentCategoryId", "A category cannot be its own parent.");
            }
        }

        if (!ModelState.IsValid)
        {
            // Only show top-level categories as parent options (no subcategories)
            var allCategories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
            ViewBag.Categories = allCategories
                .Where(c => c.Id != model.Id)
                .OrderBy(c => c.DisplayOrder)
                .ToList();
            TempData["Error"] = _localizationService["Admin_Category_ErrorSave"];
            return View(model);
        }

        var tempFilesToCleanup = new string[] { };

        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var category = await _unitOfWork.Categories.GetByIdWithTranslationsAsync(model.Id);
            
            if (category == null)
            {
                TempData["Error"] = "Category not found";
                return RedirectToAction(nameof(Settings));
            }

            // Handle new image upload
            if (!string.IsNullOrEmpty(model.NewImageTempFileName))
            {
                tempFilesToCleanup = new[] { model.NewImageTempFileName };
                
                // Delete old image
                if (!string.IsNullOrEmpty(category.ImageUrl))
                {
                    await _categoryImageService.DeleteCategoryImageAsync(category.ImageUrl);
                }

                // Move new image to permanent location
                var newSlug = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US")?.Slug ?? category.Slug;
                var imageUrl = await _categoryImageService.MoveTempImageToPermanentAsync(
                    model.NewImageTempFileName,
                    newSlug);
                category.ImageUrl = imageUrl;
            }

            // Update category properties
            category.ParentCategoryId = model.ParentCategoryId;
            category.DisplayOrder = model.DisplayOrder;
            category.IsActive = model.IsActive;
            category.ShowInNavbar = model.ShowInNavbar;
            category.IconCssClass = model.IconCssClass;
            category.UpdatedBy = userId;
            category.UpdatedAt = DateTime.UtcNow;

            // Update default name and slug from English translation
            var enTranslation = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US");
            if (enTranslation != null)
            {
                category.Name = enTranslation.Name;
                category.Slug = enTranslation.Slug;
                category.Description = enTranslation.Description;
            }

            // Update translations
            foreach (var translationDto in model.Translations)
            {
                var existingTranslation = category.Translations
                    .FirstOrDefault(t => t.CultureCode == translationDto.CultureCode);

                if (existingTranslation != null)
                {
                    // Update existing translation
                    existingTranslation.Name = translationDto.Name;
                    existingTranslation.Slug = translationDto.Slug;
                    existingTranslation.Description = translationDto.Description;
                    existingTranslation.MetaDescription = translationDto.MetaDescription;
                    existingTranslation.MetaKeywords = translationDto.MetaKeywords;
                    existingTranslation.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    // Add new translation
                    var newTranslation = new CategoryTranslation
                    {
                        CategoryId = category.Id,
                        CultureCode = translationDto.CultureCode,
                        Name = translationDto.Name,
                        Slug = translationDto.Slug,
                        Description = translationDto.Description,
                        MetaDescription = translationDto.MetaDescription,
                        MetaKeywords = translationDto.MetaKeywords,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _unitOfWork.CategoryTranslations.AddAsync(newTranslation);
                }
            }

            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync();

            TempData["Success"] = _localizationService["Admin_Category_SuccessUpdate"];
            _logger.LogInformation("Category updated: {CategoryId} by {UserId}", category.Id, userId);

            return RedirectToAction(nameof(Settings), new { tab = "categories" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating category");
            TempData["Error"] = _localizationService["Admin_Category_ErrorSave"];
            
            if (tempFilesToCleanup.Length > 0)
            {
                await _categoryImageService.CleanupTempFilesAsync(tempFilesToCleanup.ToList());
            }

            // Only show top-level categories as parent options (no subcategories)
            var allCategories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
            ViewBag.Categories = allCategories
                .Where(c => c.Id != model.Id)
                .OrderBy(c => c.DisplayOrder)
                .ToList();
            return View(model);
        }
    }

    /// <summary>
    /// POST: Delete category
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CategoryDelete(int id)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetByIdWithTranslationsAsync(id);
            if (category == null)
            {
                TempData["Error"] = "Category not found";
                return RedirectToAction(nameof(Settings));
            }

            // Delete category image if exists
            if (!string.IsNullOrEmpty(category.ImageUrl))
            {
                await _categoryImageService.DeleteCategoryImageAsync(category.ImageUrl);
            }

            // Delete category (translations will cascade)
            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.SaveChangesAsync();

            TempData["Success"] = _localizationService["Admin_Category_SuccessDelete"];
            _logger.LogInformation("Category deleted: {CategoryId}", id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting category: {CategoryId}", id);
            TempData["Error"] = _localizationService["Admin_Category_ErrorDelete"];
        }

        return RedirectToAction(nameof(Settings), new { tab = "categories" });
    }

    /// <summary>
    /// POST: Upload category image to temp folder (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CategoryUploadImage(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return Json(new { success = false, message = "No file uploaded" });
            }

            var tempFileName = await _categoryImageService.UploadCategoryImageAsync(file, "img/temp");
            var tempPath = $"/img/temp/{tempFileName}";

            return Json(new { 
                success = true, 
                tempFileName = tempFileName,
                tempPath = tempPath
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading category image");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Delete temp files (AJAX) - called when user cancels
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CategoryCancelUpload([FromBody] CategoryCancelUploadDto model)
    {
        try
        {
            await _categoryImageService.CleanupTempFilesAsync(model.TempFileNames);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error cleaning up temp files");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Toggle category active status (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CategoryToggleActive(int id)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            
            if (category != null)
            {
                category.IsActive = !category.IsActive;
                category.UpdatedAt = DateTime.UtcNow;
                category.UpdatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.SaveChangesAsync();
                
                var status = category.IsActive ? "activated" : "deactivated";
                return Json(new { success = true, message = $"Category {status} successfully", isActive = category.IsActive });
            }
            else
            {
                return Json(new { success = false, message = "Category not found" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling category status");
            return Json(new { success = false, message = ex.Message });
        }
    }

    #endregion

    #region Blog Management

    /// <summary>
    /// GET: Create new blog post form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> BlogCreate()
    {
        ViewData["Title"] = _localizationService["Admin_Blog_CreateNew"];
        
        var viewModel = new BlogCreateDto
        {
            IsPublished = false,
            AllowComments = true,
            PublishedDate = DateTime.UtcNow,
            Translations = new List<BlogTranslationDto>
            {
                new BlogTranslationDto 
                { 
                    CultureCode = "en-US",
                    Title = "",
                    Slug = "",
                    Content = "",
                    Excerpt = "",
                    Tags = "",
                    MetaDescription = "",
                    MetaKeywords = ""
                },
                new BlogTranslationDto 
                { 
                    CultureCode = "pl-PL",
                    Title = "",
                    Slug = "",
                    Content = "",
                    Excerpt = "",
                    Tags = "",
                    MetaDescription = "",
                    MetaKeywords = ""
                }
            }
        };

        // Load categories and products for dropdowns
        var categories = await _unitOfWork.BlogCategories.GetActiveCategoriesAsync();
        var products = await _unitOfWork.Products.GetAllAsync();
        ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
        ViewBag.Products = products.Where(p => p.IsActive).OrderBy(p => p.Name).ToList();
        ViewBag.CKEditorLicenseKey = _configuration["CKEditor:LicenseKey"];

        return View(viewModel);
    }

    /// <summary>
    /// POST: Create new blog post
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BlogCreate(BlogCreateDto model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _unitOfWork.BlogCategories.GetActiveCategoriesAsync();
            var products = await _unitOfWork.Products.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            ViewBag.Products = products.Where(p => p.IsActive).OrderBy(p => p.Name).ToList();
            TempData["Error"] = _localizationService["Admin_Blog_ErrorSave"];
            return View(model);
        }

        var tempFilesToCleanup = new string[] { };

        try
        {
            // Get current user ID
            var userId = User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);

            // Create blog entity
            var blog = new Entity.Blog
            {
                CategoryId = model.CategoryId,
                ProductId = model.ProductId,
                AuthorId = userId, // Nullable - will be null if user is not authenticated
                IsPublished = model.IsPublished,
                PublishedDate = model.IsPublished ? (model.PublishedDate ?? DateTime.UtcNow) : null,
                AllowComments = model.AllowComments,
                Views = 0,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsDeleted = false
            };

            // Process featured image if uploaded
            if (!string.IsNullOrEmpty(model.ImageTempFileName))
            {
                tempFilesToCleanup = new[] { model.ImageTempFileName };
                var result = await _blogImageService.ProcessAndMoveFromTempAsync(model.ImageTempFileName);
                if (result.Success)
                {
                    blog.FeaturedImage = result.PermanentUrl;
                }
            }

            // Add blog to context
            await _unitOfWork.Blogs.AddAsync(blog);
            await _unitOfWork.SaveChangesAsync();

            // Create translations
            var translations = new List<Entity.BlogTranslation>();
            foreach (var translationDto in model.Translations)
            {
                if (string.IsNullOrWhiteSpace(translationDto.Title)) continue;

                var translation = new Entity.BlogTranslation
                {
                    BlogId = blog.Id,
                    CultureCode = translationDto.CultureCode,
                    Title = translationDto.Title,
                    Slug = GenerateSlug(translationDto.Title),
                    Content = translationDto.Content,
                    Excerpt = translationDto.Excerpt,
                    Tags = translationDto.Tags,
                    MetaDescription = translationDto.MetaDescription,
                    MetaKeywords = translationDto.MetaKeywords,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                translations.Add(translation);
            }

            if (translations.Any())
            {
                foreach (var trans in translations)
                {
                    await _unitOfWork.Repository<Entity.BlogTranslation>().AddAsync(trans);
                }
                await _unitOfWork.SaveChangesAsync();
            }

            _logger.LogInformation("Blog post created: {BlogId} by user {UserId}", blog.Id, userId);
            TempData["Success"] = _localizationService["Admin_Blog_CreateSuccess"];
            return RedirectToAction(nameof(BlogSettings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating blog post");
            TempData["Error"] = _localizationService["Admin_Blog_ErrorSave"];
            
            if (tempFilesToCleanup.Length > 0)
            {
                foreach (var tempFile in tempFilesToCleanup)
                {
                    await _blogImageService.CancelUploadAsync(tempFile);
                }
            }

            var categories = await _unitOfWork.BlogCategories.GetActiveCategoriesAsync();
            var products = await _unitOfWork.Products.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            ViewBag.Products = products.Where(p => p.IsActive).OrderBy(p => p.Name).ToList();
            return View(model);
        }
    }

    /// <summary>
    /// GET: Edit blog post form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> BlogEdit(int id)
    {
        var blog = await _unitOfWork.Blogs.GetByIdAsync(id);
        if (blog == null)
        {
            TempData["Error"] = "Blog post not found";
            return RedirectToAction(nameof(Settings));
        }

        // Load translations
        var translations = (await _unitOfWork.Repository<Entity.BlogTranslation>()
            .FindAsync(t => t.BlogId == id)).ToList();

        var viewModel = new BlogUpdateDto
        {
            Id = blog.Id,
            CategoryId = blog.CategoryId,
            ProductId = blog.ProductId,
            FeaturedImage = blog.FeaturedImage,
            IsPublished = blog.IsPublished,
            PublishedDate = blog.PublishedDate,
            AllowComments = blog.AllowComments,
            Translations = translations.Select(t => new BlogTranslationDto
            {
                Id = t.Id,
                CultureCode = t.CultureCode,
                Title = t.Title,
                Slug = t.Slug,
                Content = t.Content,
                Excerpt = t.Excerpt,
                Tags = t.Tags,
                MetaDescription = t.MetaDescription,
                MetaKeywords = t.MetaKeywords
            }).ToList()
        };

        // Ensure we have translations for both languages
        if (!viewModel.Translations.Any(t => t.CultureCode == "en-US"))
        {
            viewModel.Translations.Add(new BlogTranslationDto { CultureCode = "en-US" });
        }
        if (!viewModel.Translations.Any(t => t.CultureCode == "pl-PL"))
        {
            viewModel.Translations.Add(new BlogTranslationDto { CultureCode = "pl-PL" });
        }

        // Load current image for preview
        ViewBag.CurrentImage = blog.FeaturedImage;

        // Load categories and products for dropdowns
        var categories = await _unitOfWork.BlogCategories.GetActiveCategoriesAsync();
        var products = await _unitOfWork.Products.GetAllAsync();
        ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
        ViewBag.Products = products.Where(p => p.IsActive).OrderBy(p => p.Name).ToList();
        ViewBag.CKEditorLicenseKey = _configuration["CKEditor:LicenseKey"];

        ViewData["Title"] = _localizationService["Admin_Blog_Edit"];
        return View(viewModel);
    }

    /// <summary>
    /// POST: Update blog post
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BlogEdit(BlogUpdateDto model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _unitOfWork.BlogCategories.GetActiveCategoriesAsync();
            var products = await _unitOfWork.Products.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            ViewBag.Products = products.Where(p => p.IsActive).OrderBy(p => p.Name).ToList();
            TempData["Error"] = _localizationService["Admin_Blog_ErrorSave"];
            return View(model);
        }

        var tempFilesToCleanup = new string[] { };

        try
        {
            var blog = await _unitOfWork.Blogs.GetByIdAsync(model.Id);
            
            if (blog == null)
            {
                TempData["Error"] = "Blog post not found";
                return RedirectToAction(nameof(Settings), new { tab = "blogs" });
            }

            // Update blog properties
            blog.CategoryId = model.CategoryId;
            blog.ProductId = model.ProductId;
            blog.IsPublished = model.IsPublished;
            blog.PublishedDate = model.IsPublished ? (model.PublishedDate ?? DateTime.UtcNow) : null;
            blog.AllowComments = model.AllowComments;
            blog.UpdatedAt = DateTime.UtcNow;

            // Process new featured image if uploaded
            if (!string.IsNullOrEmpty(model.NewImageTempFileName))
            {
                tempFilesToCleanup = new[] { model.NewImageTempFileName };
                
                // Delete old image
                if (!string.IsNullOrEmpty(blog.FeaturedImage))
                {
                    await _blogImageService.DeleteImageAsync(blog.FeaturedImage);
                }
                
                // Move new image to permanent location
                var result = await _blogImageService.ProcessAndMoveFromTempAsync(model.NewImageTempFileName);
                if (result.Success)
                {
                    blog.FeaturedImage = result.PermanentUrl;
                }
            }

            _unitOfWork.Blogs.Update(blog);

            // Update translations
            var existingTranslations = (await _unitOfWork.Repository<Entity.BlogTranslation>()
                .FindAsync(t => t.BlogId == model.Id)).ToList();

            foreach (var translationDto in model.Translations)
            {
                if (string.IsNullOrWhiteSpace(translationDto.Title)) continue;

                var existingTranslation = existingTranslations
                    .FirstOrDefault(t => t.CultureCode == translationDto.CultureCode);

                if (existingTranslation != null)
                {
                    // Update existing translation
                    existingTranslation.Title = translationDto.Title;
                    existingTranslation.Slug = GenerateSlug(translationDto.Title);
                    existingTranslation.Content = translationDto.Content;
                    existingTranslation.Excerpt = translationDto.Excerpt;
                    existingTranslation.Tags = translationDto.Tags;
                    existingTranslation.MetaDescription = translationDto.MetaDescription;
                    existingTranslation.MetaKeywords = translationDto.MetaKeywords;
                    existingTranslation.UpdatedAt = DateTime.UtcNow;

                    _unitOfWork.Repository<Entity.BlogTranslation>().Update(existingTranslation);
                }
                else
                {
                    // Add new translation
                    var newTranslation = new Entity.BlogTranslation
                    {
                        BlogId = blog.Id,
                        CultureCode = translationDto.CultureCode,
                        Title = translationDto.Title,
                        Slug = GenerateSlug(translationDto.Title),
                        Content = translationDto.Content,
                        Excerpt = translationDto.Excerpt,
                        Tags = translationDto.Tags,
                        MetaDescription = translationDto.MetaDescription,
                        MetaKeywords = translationDto.MetaKeywords,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    await _unitOfWork.Repository<Entity.BlogTranslation>().AddAsync(newTranslation);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Blog post updated: {BlogId}", blog.Id);
            TempData["Success"] = _localizationService["Admin_Blog_UpdateSuccess"];
            return RedirectToAction(nameof(BlogSettings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating blog post {BlogId}", model.Id);
            TempData["Error"] = _localizationService["Admin_Blog_ErrorSave"];
            
            if (tempFilesToCleanup.Length > 0)
            {
                foreach (var tempFile in tempFilesToCleanup)
                {
                    await _blogImageService.CancelUploadAsync(tempFile);
                }
            }

            var categories = await _unitOfWork.BlogCategories.GetActiveCategoriesAsync();
            var products = await _unitOfWork.Products.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            ViewBag.Products = products.Where(p => p.IsActive).OrderBy(p => p.Name).ToList();
            ViewBag.CurrentImage = model.FeaturedImage;
            return View(model);
        }
    }

    /// <summary>
    /// POST: Delete blog post
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BlogDelete(int id)
    {
        try
        {
            var blog = await _unitOfWork.Blogs.GetByIdAsync(id);
            if (blog == null)
            {
                TempData["Error"] = "Blog post not found";
                return RedirectToAction(nameof(BlogSettings));
            }

            // Delete featured image if exists
            if (!string.IsNullOrEmpty(blog.FeaturedImage))
            {
                await _blogImageService.DeleteImageAsync(blog.FeaturedImage);
            }

            // Soft delete
            blog.IsDeleted = true;
            blog.UpdatedAt = DateTime.UtcNow;
            
            _unitOfWork.Blogs.Update(blog);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Blog post soft deleted: {BlogId}", blog.Id);
            TempData["Success"] = _localizationService["Admin_Blog_DeleteSuccess"];
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting blog post {BlogId}", id);
            TempData["Error"] = _localizationService["Admin_Blog_ErrorDelete"];
        }

        return RedirectToAction(nameof(BlogSettings));
    }

    /// <summary>
    /// POST: Upload blog image to temp folder (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> BlogUploadImage(IFormFile file)
    {
        var result = await _blogImageService.UploadToTempAsync(file);
        
        if (result.Success)
        {
            return Json(new { success = true, tempFileName = result.TempFileName, tempUrl = result.TempUrl });
        }
        
        return Json(new { success = false, message = result.Message });
    }

    /// <summary>
    /// POST: Delete temp files (AJAX) - called when user cancels
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> BlogCancelUpload([FromBody] BlogCancelUploadDto model)
    {
        try
        {
            if (!string.IsNullOrEmpty(model.ImageTempFileName))
            {
                await _blogImageService.CancelUploadAsync(model.ImageTempFileName);
            }
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error canceling blog upload");
            return Json(new { success = false });
        }
    }

    /// <summary>
    /// POST: Toggle blog publish status (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> BlogTogglePublish(int id)
    {
        try
        {
            var blog = await _unitOfWork.Blogs.GetByIdAsync(id);
            
            if (blog != null)
            {
                blog.IsPublished = !blog.IsPublished;
                blog.PublishedDate = blog.IsPublished ? DateTime.UtcNow : null;
                blog.UpdatedAt = DateTime.UtcNow;
                
                _unitOfWork.Blogs.Update(blog);
                await _unitOfWork.SaveChangesAsync();

                return Json(new { success = true, isPublished = blog.IsPublished });
            }
            else
            {
                return Json(new { success = false, message = "Blog post not found" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling blog publish status {BlogId}", id);
            return Json(new { success = false, message = "Error updating status" });
        }
    }

    /// <summary>
    /// Helper method to generate URL-friendly slug
    /// </summary>
    private string GenerateSlug(string title)
    {
        if (string.IsNullOrWhiteSpace(title)) return "";

        // Convert to lowercase
        string slug = title.ToLower();
        
        // Replace Polish characters
        slug = slug.Replace("ą", "a").Replace("ć", "c").Replace("ę", "e")
                   .Replace("ł", "l").Replace("ń", "n").Replace("ó", "o")
                   .Replace("ś", "s").Replace("ź", "z").Replace("ż", "z");
        
        // Remove special characters
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9\s-]", "");
        
        // Replace spaces and multiple dashes
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s+", "-");
        slug = System.Text.RegularExpressions.Regex.Replace(slug, @"-+", "-");
        
        return slug.Trim('-');
    }

    #endregion

    #region Translation Management

    /// <summary>
    /// GET: Get all translation files (AJAX)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllTranslationFiles()
    {
        try
        {
            var files = await _translationManagementService.GetAllTranslationFilesAsync();
            return Json(new { success = true, data = files });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting translation files");
            return Json(new { success = false, message = "Error loading translation files" });
        }
    }

    /// <summary>
    /// GET: Get translations by file (AJAX)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetTranslationsByFile(string fileName)
    {
        try
        {
            var translations = await _translationManagementService.GetTranslationsByFileAsync(fileName);
            return Json(new { success = true, data = translations });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting translations for file: {FileName}", fileName);
            return Json(new { success = false, message = "Error loading translations" });
        }
    }

    /// <summary>
    /// POST: Search translations (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> SearchTranslations([FromBody] TranslationSearchDto model)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                return Json(new { success = true, data = new List<object>() });
            }

            var results = await _translationManagementService.SearchTranslationsAsync(
                model.SearchTerm, 
                model.FileName
            );

            return Json(new { success = true, data = results, count = results.Count });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching translations");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Update translation (AJAX - Live update)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateTranslation([FromBody] TranslationUpdateDto model)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(model.FileName) || 
                string.IsNullOrWhiteSpace(model.Key) || 
                string.IsNullOrWhiteSpace(model.CultureCode))
            {
                return Json(new { success = false, message = "Invalid translation data" });
            }

            // Only allow en-US and pl-PL
            if (model.CultureCode != "en-US" && model.CultureCode != "pl-PL")
            {
                return Json(new { success = false, message = "Only English (en-US) and Polish (pl-PL) translations are supported" });
            }

            var success = await _translationManagementService.UpdateTranslationAsync(
                model.FileName, 
                model.Key, 
                model.CultureCode, 
                model.Value);

            if (success)
            {
                _logger.LogInformation("Translation updated: {File}.{Key} ({Culture}) = {Value}", 
                    model.FileName, model.Key, model.CultureCode, model.Value);
                
                // Force browser to not cache responses
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                Response.Headers["Pragma"] = "no-cache";
                Response.Headers["Expires"] = "0";
                
                return Json(new { 
                    success = true, 
                    message = "Translation updated successfully. Changes will appear immediately on page refresh." 
                });
            }
            else
            {
                return Json(new { success = false, message = "Failed to update translation" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating translation");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Update translation comment (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateTranslationComment([FromBody] TranslationCommentUpdateDto model)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(model.FileName) || string.IsNullOrWhiteSpace(model.Key))
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            var success = await _translationManagementService.UpdateCommentAsync(
                model.FileName, 
                model.Key, 
                model.Comment ?? string.Empty);

            if (success)
            {
                _logger.LogInformation("Translation comment updated: {File}.{Key}", model.FileName, model.Key);
                
                // Force browser to not cache responses
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                Response.Headers["Pragma"] = "no-cache";
                Response.Headers["Expires"] = "0";
                
                return Json(new { success = true, message = "Comment updated successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Failed to update comment" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating translation comment");
            return Json(new { success = false, message = ex.Message });
        }
    }

    #endregion

    #region User Management

    /// <summary>
    /// GET: User Management page
    /// </summary>
    public async Task<IActionResult> UserManagement()
    {
        _logger.LogInformation("Admin accessed user management");

        var users = await _userManager.Users.ToListAsync();
        var totalUsers = users.Count;
        var activeUsers = users.Count(u => !u.LockoutEnd.HasValue || u.LockoutEnd <= DateTimeOffset.UtcNow);
        var bannedUsers = users.Count(u => u.LockoutEnd.HasValue && u.LockoutEnd > DateTimeOffset.UtcNow);

        // Get all orders and reviews for counting
        var allOrders = await _unitOfWork.Orders.GetAllAsync();
        var allReviews = await _unitOfWork.Repository<ProductReview>().GetAllAsync();

        // Get current user to check if Root
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var currentUser = await _userManager.FindByIdAsync(currentUserId!);
        var isCurrentUserRoot = currentUser != null && await _userManager.IsInRoleAsync(currentUser, "Root");
        ViewBag.IsCurrentUserRoot = isCurrentUserRoot;

        // Build user list with role information
        var userDtos = new List<Models.ViewModels.Admin.UserListItemDto>();
        foreach (var u in users)
        {
            var isRoot = await _userManager.IsInRoleAsync(u, "Root");
            userDtos.Add(new Models.ViewModels.Admin.UserListItemDto
            {
                Id = u.Id,
                Email = u.Email ?? "",
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                EmailConfirmed = u.EmailConfirmed,
                IsBanned = u.LockoutEnd.HasValue && u.LockoutEnd > DateTimeOffset.UtcNow,
                BannedUntil = u.LockoutEnd,
                CreatedAt = u.CreatedAt,
                LastLogin = u.LastLoginAt,
                TotalOrders = allOrders.Count(o => o.UserId == u.Id),
                TotalReviews = allReviews.Count(r => r.UserId == u.Id),
                IsRoot = isRoot
            });
        }

        var viewModel = new Models.ViewModels.Admin.UserManagementViewModel
        {
            Users = userDtos.OrderByDescending(u => u.CreatedAt).ToList(),
            TotalUsers = totalUsers,
            ActiveUsers = activeUsers,
            BannedUsers = bannedUsers,
            NewUsersThisMonth = users.Count(u => u.CreatedAt >= DateTime.UtcNow.AddMonths(-1))
        };

        ViewData["Title"] = "User Management";
        return View(viewModel);
    }

    /// <summary>
    /// GET: Edit user
    /// </summary>
    public async Task<IActionResult> UserEdit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user == null)
        {
            TempData["Error"] = "User not found";
            return RedirectToAction(nameof(UserManagement));
        }

        // Check if editing user is Root and current user is not Root
        var isUserRoot = await _userManager.IsInRoleAsync(user, "Root");
        var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var currentUser = await _userManager.FindByIdAsync(currentUserId!);
        var isCurrentUserRoot = currentUser != null && await _userManager.IsInRoleAsync(currentUser, "Root");

        if (isUserRoot && !isCurrentUserRoot)
        {
            TempData["Error"] = "Only Root users can edit Root accounts";
            return RedirectToAction(nameof(UserManagement));
        }

        ViewBag.IsUserRoot = isUserRoot;
        ViewBag.IsCurrentUserRoot = isCurrentUserRoot;

        // Get user's reviews
        var reviews = await _unitOfWork.Repository<ProductReview>()
            .FindAsync(r => r.UserId == id);

        var viewModel = new Models.ViewModels.Admin.UserEditDto
        {
            Id = user.Id,
            Email = user.Email ?? "",
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            EmailConfirmed = user.EmailConfirmed,
            IsBanned = user.LockoutEnd.HasValue && user.LockoutEnd > DateTimeOffset.UtcNow,
            BannedUntil = user.LockoutEnd,
            CreatedAt = user.CreatedAt,
            LastLogin = user.LastLoginAt,
            Reviews = reviews.Select(r => new Models.ViewModels.Admin.UserReviewDto
            {
                Id = r.Id,
                ProductId = r.ProductId,
                ProductName = r.Product?.Name ?? "Unknown Product",
                Rating = r.Rating,
                Comment = r.Comment,
                IsVisible = r.IsVisible,
                CreatedAt = r.CreatedAt,
                AdminReply = r.AdminReply,
                AdminReplyAt = r.AdminReplyAt
            }).OrderByDescending(r => r.CreatedAt).ToList()
        };

        ViewData["Title"] = $"Edit User: {user.Email}";
        return View(viewModel);
    }

    /// <summary>
    /// POST: Update user
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UserEdit(Models.ViewModels.Admin.UserEditDto model)
    {
        if (!ModelState.IsValid)
        {
            TempData["Error"] = "Invalid data";
            return View(model);
        }

        try
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                TempData["Error"] = "User not found";
                return RedirectToAction(nameof(UserManagement));
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.EmailConfirmed = model.EmailConfirmed;

            var result = await _userManager.UpdateAsync(user);
            
            if (result.Succeeded)
            {
                _logger.LogInformation("User updated: {UserId}", user.Id);
                TempData["Success"] = "User updated successfully";
                return RedirectToAction(nameof(UserManagement));
            }
            else
            {
                TempData["Error"] = string.Join(", ", result.Errors.Select(e => e.Description));
                return View(model);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating user {UserId}", model.Id);
            TempData["Error"] = "Error updating user";
            return View(model);
        }
    }

    /// <summary>
    /// POST: Ban user
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UserBan(string id, int days)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            // Protect Root users from being banned
            var isRoot = await _userManager.IsInRoleAsync(user, "Root");
            if (isRoot)
            {
                return Json(new { success = false, message = "Root users cannot be banned" });
            }

            // Ban user for specified days
            user.LockoutEnd = DateTimeOffset.UtcNow.AddDays(days);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("User banned: {UserId} for {Days} days", id, days);
                return Json(new { success = true, message = $"User banned for {days} days" });
            }
            else
            {
                return Json(new { success = false, message = string.Join(", ", result.Errors.Select(e => e.Description)) });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error banning user {UserId}", id);
            return Json(new { success = false, message = "Error banning user" });
        }
    }

    /// <summary>
    /// POST: Unban user
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UserUnban(string id)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            user.LockoutEnd = null;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _logger.LogInformation("User unbanned: {UserId}", id);
                return Json(new { success = true, message = "User unbanned successfully" });
            }
            else
            {
                return Json(new { success = false, message = string.Join(", ", result.Errors.Select(e => e.Description)) });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error unbanning user {UserId}", id);
            return Json(new { success = false, message = "Error unbanning user" });
        }
    }

    /// <summary>
    /// POST: Delete user
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UserDelete(string id)
    {
        try
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return Json(new { success = false, message = "User not found" });
            }

            // Protect Root users from being deleted
            var isRoot = await _userManager.IsInRoleAsync(user, "Root");
            if (isRoot)
            {
                return Json(new { success = false, message = "Root users cannot be deleted" });
            }

            var result = await _userManager.DeleteAsync(user);
            
            if (result.Succeeded)
            {
                _logger.LogInformation("User deleted: {UserId}", id);
                return Json(new { success = true, message = "User deleted successfully" });
            }
            else
            {
                return Json(new { success = false, message = string.Join(", ", result.Errors.Select(e => e.Description)) });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting user {UserId}", id);
            return Json(new { success = false, message = "Error deleting user" });
        }
    }

    /// <summary>
    /// POST: Update review visibility
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReviewToggleVisibility(int id)
    {
        try
        {
            var review = await _unitOfWork.Repository<ProductReview>().GetByIdAsync(id);
            if (review == null)
            {
                return Json(new { success = false, message = "Review not found" });
            }

            review.IsVisible = !review.IsVisible;
            review.UpdatedAt = DateTime.UtcNow;
            
            _unitOfWork.Repository<ProductReview>().Update(review);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Review visibility toggled: {ReviewId} to {IsVisible}", id, review.IsVisible);
            return Json(new { success = true, isVisible = review.IsVisible });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling review visibility {ReviewId}", id);
            return Json(new { success = false, message = "Error updating review" });
        }
    }

    /// <summary>
    /// POST: Edit review content
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReviewEdit(int id, string comment)
    {
        try
        {
            var review = await _unitOfWork.Repository<ProductReview>().GetByIdAsync(id);
            if (review == null)
            {
                return Json(new { success = false, message = "Review not found" });
            }

            review.Comment = comment;
            review.UpdatedAt = DateTime.UtcNow;
            
            _unitOfWork.Repository<ProductReview>().Update(review);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Review edited: {ReviewId}", id);
            return Json(new { success = true, message = "Review updated successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error editing review {ReviewId}", id);
            return Json(new { success = false, message = "Error updating review" });
        }
    }

    /// <summary>
    /// POST: Delete review
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ReviewDelete(int id)
    {
        try
        {
            var review = await _unitOfWork.Repository<ProductReview>().GetByIdAsync(id);
            if (review == null)
            {
                return Json(new { success = false, message = "Review not found" });
            }

            _unitOfWork.Repository<ProductReview>().Remove(review);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Review deleted: {ReviewId}", id);
            return Json(new { success = true, message = "Review deleted successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting review {ReviewId}", id);
            return Json(new { success = false, message = "Error deleting review" });
        }
    }

    #endregion

    #region Product Management

    /// <summary>
    /// POST: Upload product image to temp (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ProductUploadImage(IFormFile file)
    {
        var result = await _productImageService.UploadToTempAsync(file);
        
        if (result.Success)
        {
            return Json(new { success = true, tempFileName = result.TempFileName, tempUrl = result.TempUrl });
        }
        
        return Json(new { success = false, message = result.Message });
    }

    /// <summary>
    /// POST: Cancel product image upload (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ProductCancelUpload([FromBody] ProductImageCancelDto model)
    {
        try
        {
            await _productImageService.CancelUploadAsync(model.TempFileNames.ToArray());
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error canceling product upload");
            return Json(new { success = false });
        }
    }

    /// <summary>
    /// POST: Toggle product active status (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ProductToggleActive([FromForm] int id)
    {
        try
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            product.IsActive = !product.IsActive;
            product.UpdatedAt = DateTime.UtcNow;
            
            // Update or archive Stripe product
            var stripeProductService = new Stripe.ProductService();
            
            if (!product.IsActive)
            {
                // Archive (deactivate) in Stripe when making inactive
                await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
                {
                    Active = false
                });

                // Deactivate all variant prices
                var variants = await _unitOfWork.Repository<ProductVariant>()
                    .FindAsync(v => v.ProductId == product.Id);
                
                var stripePriceService = new Stripe.PriceService();
                foreach (var variant in variants)
                {
                    if (!string.IsNullOrEmpty(variant.StripePriceId))
                    {
                        await stripePriceService.UpdateAsync(variant.StripePriceId, new Stripe.PriceUpdateOptions
                        {
                            Active = false
                        });
                    }
                }

                // Deactivate base price
                if (!string.IsNullOrEmpty(product.StripePriceId))
                {
                    await stripePriceService.UpdateAsync(product.StripePriceId, new Stripe.PriceUpdateOptions
                    {
                        Active = false
                    });
                }

                // Remove from all carts
                var cartItems = await _unitOfWork.Repository<Cart>()
                    .FindAsync(c => c.ProductId == product.Id);
                
                foreach (var cartItem in cartItems)
                {
                    _unitOfWork.Repository<Cart>().Remove(cartItem);
                }
            }
            else
            {
                // Reactivate in Stripe
                await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
                {
                    Active = true
                });

                // Reactivate prices
                var stripePriceService = new Stripe.PriceService();
                if (!string.IsNullOrEmpty(product.StripePriceId))
                {
                    await stripePriceService.UpdateAsync(product.StripePriceId, new Stripe.PriceUpdateOptions
                    {
                        Active = true
                    });
                }

                var variants = await _unitOfWork.Repository<ProductVariant>()
                    .FindAsync(v => v.ProductId == product.Id);
                
                foreach (var variant in variants)
                {
                    if (!string.IsNullOrEmpty(variant.StripePriceId))
                    {
                        await stripePriceService.UpdateAsync(variant.StripePriceId, new Stripe.PriceUpdateOptions
                        {
                            Active = true
                        });
                    }
                }
            }
            
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Product {ProductId} {Action}. Carts cleared: {CartsCleared}", 
                product.Id, 
                product.IsActive ? "activated" : "deactivated",
                !product.IsActive);

            return Json(new { success = true, isActive = product.IsActive });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling product status {ProductId}", id);
            return Json(new { success = false, message = $"Error updating status: {ex.Message}" });
        }
    }

    /// <summary>
    /// GET: Create new product
    /// </summary>
    public async Task<IActionResult> ProductCreate()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        var sizes = await _unitOfWork.Sizes.GetAllAsync();
        var colors = await _unitOfWork.Colors.GetAllAsync();

        var model = new ProductCreateDto
        {
            Categories = new SelectList(categories, "Id", "Name"),
            AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList(),
            AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList()
        };

        return View(model);
    }

    /// <summary>
    /// POST: Create new product
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductCreate(ProductCreateDto model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                // Reload dropdowns
                var categories = await _unitOfWork.Categories.GetAllAsync();
                var sizes = await _unitOfWork.Sizes.GetAllAsync();
                var colors = await _unitOfWork.Colors.GetAllAsync();
                
                model.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                model.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
                model.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                
                return View(model);
            }

            // Create Stripe product
            var stripeProductService = new Stripe.ProductService();
            var stripeProduct = await stripeProductService.CreateAsync(new Stripe.ProductCreateOptions
            {
                Name = model.Name,
                Description = model.Description,
                Active = model.IsActive,
                Metadata = new Dictionary<string, string>
                {
                    { "category_id", model.CategoryId.ToString() },
                    { "pack_size", model.PackSize.ToString() }
                }
            });

            // Create Stripe price (base price)
            var stripePriceService = new Stripe.PriceService();
            var stripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
            {
                Product = stripeProduct.Id,
                UnitAmount = (long)(model.BasePrice * 100), // Convert to cents
                Currency = "try",
                Active = true
            });

            // Create product entity
            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.BasePrice,
                PackSize = model.PackSize,
                CategoryId = model.CategoryId,
                StripeProductId = stripeProduct.Id,
                StripePriceId = stripePrice.Id,
                StripeTaxCode = "txcd_99999999", // General product tax code
                IsActive = model.IsActive,
                CreatedAt = DateTime.UtcNow
            };

            // Add to database to get ID
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            // Add product translations
            if (model.Translations != null && model.Translations.Any())
            {
                foreach (var translationDto in model.Translations)
                {
                    // Skip empty translations
                    if (string.IsNullOrWhiteSpace(translationDto.Name))
                        continue;

                    var translation = new ProductTranslation
                    {
                        ProductId = product.Id,
                        CultureCode = translationDto.CultureCode,
                        Name = translationDto.Name,
                        Description = translationDto.Description ?? string.Empty,
                        Slug = translationDto.Slug ?? string.Empty,
                        MetaDescription = translationDto.MetaDescription ?? string.Empty,
                        MetaKeywords = translationDto.MetaKeywords ?? string.Empty
                    };
                    await _unitOfWork.Repository<ProductTranslation>().AddAsync(translation);
                }
                await _unitOfWork.SaveChangesAsync();
            }

            // Process uploaded images
            if (model.TempImageFileNames != null && model.TempImageFileNames.Any())
            {
                foreach (var tempFileName in model.TempImageFileNames)
                {
                    var moveResult = await _productImageService.MoveTempToPermanentAsync(tempFileName, product.Id);
                    if (moveResult.Success)
                    {
                        var productImage = new ProductImage
                        {
                            ProductId = product.Id,
                            ImageUrl = moveResult.PermanentUrl!,
                            DisplayOrder = model.TempImageFileNames.IndexOf(tempFileName),
                            CreatedAt = DateTime.UtcNow
                        };
                        await _unitOfWork.Repository<ProductImage>().AddAsync(productImage);
                    }
                }
                await _unitOfWork.SaveChangesAsync();
            }

            // Add product sizes
            if (model.SelectedSizeIds != null && model.SelectedSizeIds.Any())
            {
                foreach (var sizeId in model.SelectedSizeIds)
                {
                    var productSize = new ProductSize
                    {
                        ProductId = product.Id,
                        SizeId = sizeId
                    };
                    await _unitOfWork.Repository<ProductSize>().AddAsync(productSize);
                }
            }

            // Add product colors
            if (model.SelectedColorIds != null && model.SelectedColorIds.Any())
            {
                foreach (var colorId in model.SelectedColorIds)
                {
                    var productColor = new ProductColor
                    {
                        ProductId = product.Id,
                        ColorId = colorId
                    };
                    await _unitOfWork.Repository<ProductColor>().AddAsync(productColor);
                }
            }

            // Add variants
            if (model.Variants != null && model.Variants.Any())
            {
                foreach (var variantDto in model.Variants)
                {
                    // Create Stripe price for this variant
                    var variantStripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
                    {
                        Product = stripeProduct.Id,
                        UnitAmount = (long)(variantDto.Price * 100),
                        Currency = "try",
                        Active = true,
                        Metadata = new Dictionary<string, string>
                        {
                            { "size_id", variantDto.SizeId?.ToString() ?? "" },
                            { "color_id", variantDto.ColorId?.ToString() ?? "" },
                            { "sku", variantDto.SKU }
                        }
                    });

                    var variant = new ProductVariant
                    {
                        ProductId = product.Id,
                        SizeId = variantDto.SizeId,
                        ColorId = variantDto.ColorId,
                        SKU = variantDto.SKU,
                        Price = variantDto.Price,
                        StockQuantity = variantDto.StockQuantity,
                        StripePriceId = variantStripePrice.Id,
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _unitOfWork.Repository<ProductVariant>().AddAsync(variant);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Product created: {ProductId} - {ProductName}", product.Id, product.Name);
            return RedirectToAction(nameof(Products));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating product");
            ModelState.AddModelError("", "Error creating product. Please try again.");
            
            // Reload dropdowns
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var sizes = await _unitOfWork.Sizes.GetAllAsync();
            var colors = await _unitOfWork.Colors.GetAllAsync();
            
            model.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
            model.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
            model.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            
            return View(model);
        }
    }

    /// <summary>
    /// GET: Edit product
    /// </summary>
    public async Task<IActionResult> ProductEdit(int id)
    {
        var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
        
        if (product == null)
        {
            return NotFound();
        }

        var categories = await _unitOfWork.Categories.GetAllAsync();
        var sizes = await _unitOfWork.Sizes.GetAllAsync();
        var colors = await _unitOfWork.Colors.GetAllAsync();

        // Get existing variants
        var variants = await _unitOfWork.Repository<ProductVariant>()
            .FindAsync(v => v.ProductId == id, v => v.Size!, v => v.Color!);

        // Get existing reviews with user info
        var reviews = (await _unitOfWork.Repository<ProductReview>()
            .FindAsync(r => r.ProductId == id, r => r.User!))
            .OrderByDescending(r => r.CreatedAt)
            .ToList();

        // Get translations
        var translations = await _unitOfWork.Repository<ProductTranslation>()
            .FindAsync(t => t.ProductId == id);

        // Get price history
        var priceHistory = await _unitOfWork.Repository<ProductPriceHistory>()
            .FindAsync(h => h.ProductId == id);

        var model = new ProductUpdateDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Translations = translations.Select(t => new ProductTranslationDto
            {
                Id = t.Id,
                CultureCode = t.CultureCode,
                Name = t.Name,
                Description = t.Description,
                Slug = t.Slug,
                MetaDescription = t.MetaDescription,
                MetaKeywords = t.MetaKeywords
            }).ToList(),
            Price = product.Price,
            PackSize = product.PackSize,
            CategoryId = product.CategoryId,
            ProductGroupId = product.ProductGroupId,
            StripeTaxCode = product.StripeTaxCode,
            IsActive = product.IsActive,
            StripeProductId = product.StripeProductId,
            StripePriceId = product.StripePriceId,
            ExistingImageUrls = product.Images.OrderBy(i => i.DisplayOrder).Select(i => i.ImageUrl).ToList(),
            Variants = variants.Select(v => new ProductVariantDto
            {
                Id = v.Id,
                ColorId = v.ColorId,
                ColorName = v.Color?.Name,
                SizeId = v.SizeId,
                SizeName = v.Size?.Name,
                SKU = v.SKU,
                Price = v.Price,
                StockQuantity = v.StockQuantity
            }).ToList(),
            Reviews = reviews.Select(r => new ProductReviewManagementDto
            {
                Id = r.Id,
                UserId = r.UserId,
                UserName = r.User?.UserName ?? "Unknown",
                UserEmail = r.User?.Email ?? "",
                Rating = r.Rating,
                Comment = r.Comment,
                IsVisible = r.IsVisible,
                IsVerifiedPurchase = r.IsVerifiedPurchase,
                AdminReply = r.AdminReply,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt,
                UserIsBanned = r.User?.LockoutEnd > DateTimeOffset.UtcNow
            }).ToList(),
            PriceHistory = priceHistory.Select(h => new ProductPriceHistoryDto
            {
                Id = h.Id,
                OldPrice = h.OldPrice,
                NewPrice = h.NewPrice,
                Reason = h.Reason,
                ChangedAt = h.ChangedAt,
                ChangedBy = h.ChangedBy
            }).ToList()
        };

        // Populate dropdowns
        ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
        ViewBag.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
        ViewBag.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();

        return View(model);
    }

    /// <summary>
    /// POST: Edit product
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ProductEdit(ProductUpdateDto model)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                // Reload data
                var categories = await _unitOfWork.Categories.GetAllAsync();
                var sizes = await _unitOfWork.Sizes.GetAllAsync();
                var colors = await _unitOfWork.Colors.GetAllAsync();
                
                ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
                ViewBag.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
                ViewBag.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
                
                return View(model);
            }

            var product = await _unitOfWork.Products.GetByIdAsync(model.Id);
            if (product == null)
            {
                return NotFound();
            }

            // Track price change for history
            bool priceChanged = product.Price != model.Price;
            decimal oldPrice = product.Price;

            // Update product
            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.PackSize = model.PackSize;
            product.CategoryId = model.CategoryId;
            product.ProductGroupId = model.ProductGroupId;
            product.StripeTaxCode = model.StripeTaxCode;
            product.IsActive = model.IsActive;
            product.UpdatedAt = DateTime.UtcNow;

            // Update Stripe product
            var stripeProductService = new Stripe.ProductService();
            await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
            {
                Name = model.Name,
                Description = model.Description,
                Active = model.IsActive
            });

            // If base price changed, create new Stripe price and update
            if (priceChanged)
            {
                var stripePriceService = new Stripe.PriceService();
                
                // Deactivate old price
                await stripePriceService.UpdateAsync(product.StripePriceId, new Stripe.PriceUpdateOptions
                {
                    Active = false
                });

                // Create new price
                var newStripePrice = await stripePriceService.CreateAsync(new Stripe.PriceCreateOptions
                {
                    Product = product.StripeProductId,
                    UnitAmount = (long)(model.Price * 100),
                    Currency = "try",
                    Active = true
                });

                product.StripePriceId = newStripePrice.Id;

                // Log price change
                await _unitOfWork.Repository<ProductPriceHistory>().AddAsync(new ProductPriceHistory
                {
                    ProductId = product.Id,
                    OldPrice = oldPrice,
                    NewPrice = model.Price,
                    Reason = "Manual Update",
                    ChangedBy = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    ChangedAt = DateTime.UtcNow
                });
            }

            _unitOfWork.Products.Update(product);

            // Update translations
            if (model.Translations != null && model.Translations.Any())
            {
                // Get existing translations
                var existingTranslations = await _unitOfWork.Repository<ProductTranslation>()
                    .FindAsync(t => t.ProductId == product.Id);
                
                foreach (var translationDto in model.Translations)
                {
                    // Skip empty translations
                    if (string.IsNullOrWhiteSpace(translationDto.Name))
                        continue;

                    var existingTranslation = existingTranslations
                        .FirstOrDefault(t => t.CultureCode == translationDto.CultureCode);

                    if (existingTranslation != null)
                    {
                        // Update existing translation
                        existingTranslation.Name = translationDto.Name;
                        existingTranslation.Description = translationDto.Description ?? string.Empty;
                        existingTranslation.Slug = translationDto.Slug ?? string.Empty;
                        existingTranslation.MetaDescription = translationDto.MetaDescription ?? string.Empty;
                        existingTranslation.MetaKeywords = translationDto.MetaKeywords ?? string.Empty;
                        _unitOfWork.Repository<ProductTranslation>().Update(existingTranslation);
                    }
                    else
                    {
                        // Create new translation
                        var newTranslation = new ProductTranslation
                        {
                            ProductId = product.Id,
                            CultureCode = translationDto.CultureCode,
                            Name = translationDto.Name,
                            Description = translationDto.Description ?? string.Empty,
                            Slug = translationDto.Slug ?? string.Empty,
                            MetaDescription = translationDto.MetaDescription ?? string.Empty,
                            MetaKeywords = translationDto.MetaKeywords ?? string.Empty
                        };
                        await _unitOfWork.Repository<ProductTranslation>().AddAsync(newTranslation);
                    }
                }
            }

            // Handle image deletions
            if (model.ImagesToDelete != null && model.ImagesToDelete.Any())
            {
                var imagesToDelete = await _unitOfWork.Repository<ProductImage>()
                    .FindAsync(img => model.ImagesToDelete.Contains(img.ImageUrl));
                
                foreach (var img in imagesToDelete)
                {
                    await _productImageService.DeleteProductImageAsync(img.ImageUrl);
                    _unitOfWork.Repository<ProductImage>().Remove(img);
                }
            }

            // Handle new image uploads
            if (model.NewImageTempFileNames != null && model.NewImageTempFileNames.Any())
            {
                var currentMaxOrder = product.Images.Any() ? product.Images.Max(i => i.DisplayOrder) : 0;
                
                foreach (var tempFileName in model.NewImageTempFileNames)
                {
                    var moveResult = await _productImageService.MoveTempToPermanentAsync(tempFileName, product.Id);
                    if (moveResult.Success)
                    {
                        var productImage = new ProductImage
                        {
                            ProductId = product.Id,
                            ImageUrl = moveResult.PermanentUrl!,
                            DisplayOrder = ++currentMaxOrder,
                            CreatedAt = DateTime.UtcNow
                        };
                        await _unitOfWork.Repository<ProductImage>().AddAsync(productImage);
                    }
                }
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Product updated: {ProductId} - {ProductName}", product.Id, product.Name);
            return RedirectToAction(nameof(Products));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating product {ProductId}", model.Id);
            ModelState.AddModelError("", "Error updating product. Please try again.");
            
            // Reload data
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var sizes = await _unitOfWork.Sizes.GetAllAsync();
            var colors = await _unitOfWork.Colors.GetAllAsync();
            
            ViewBag.Categories = new SelectList(categories, "Id", "Name", model.CategoryId);
            ViewBag.AvailableSizes = sizes.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
            ViewBag.AvailableColors = colors.Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name }).ToList();
            
            return View(model);
        }
    }

    /// <summary>
    /// POST: Delete product
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> ProductDelete(int id)
    {
        try
        {
            var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
            
            if (product == null)
            {
                return Json(new { success = false, message = "Product not found" });
            }

            // Deactivate Stripe product and prices
            try
            {
                var stripeProductService = new Stripe.ProductService();
                await stripeProductService.UpdateAsync(product.StripeProductId, new Stripe.ProductUpdateOptions
                {
                    Active = false
                });

                var stripePriceService = new Stripe.PriceService();
                await stripePriceService.UpdateAsync(product.StripePriceId, new Stripe.PriceUpdateOptions
                {
                    Active = false
                });

                // Deactivate all variant prices
                foreach (var variant in product.Variants)
                {
                    await stripePriceService.UpdateAsync(variant.StripePriceId, new Stripe.PriceUpdateOptions
                    {
                        Active = false
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error deactivating Stripe resources for product {ProductId}", id);
            }

            // Remove from all carts
            var cartItems = await _unitOfWork.Repository<Cart>()
                .FindAsync(c => c.ProductId == product.Id);
            
            foreach (var cartItem in cartItems)
            {
                _unitOfWork.Repository<Cart>().Remove(cartItem);
            }

            // Remove from all wishlists
            var wishlistItems = await _unitOfWork.Repository<Wishlist>()
                .FindAsync(w => w.ProductId == product.Id);
            
            foreach (var wishlistItem in wishlistItems)
            {
                _unitOfWork.Repository<Wishlist>().Remove(wishlistItem);
            }

            // Delete product images from filesystem
            foreach (var image in product.Images)
            {
                await _productImageService.DeleteProductImageAsync(image.ImageUrl);
            }

            // Soft delete: just mark as inactive instead of hard delete
            product.IsActive = false;
            product.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Products.Update(product);

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Product deleted: {ProductId} - {ProductName}", product.Id, product.Name);
            return Json(new { success = true, message = "Product deleted successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting product {ProductId}", id);
            return Json(new { success = false, message = "Error deleting product" });
        }
    }

    #endregion

    #region Shipping Management

    // GET: /Admin/ShippingProviders
    public async Task<IActionResult> ShippingProviders()
    {
        var providers = await _shippingService.GetAllProvidersAsync();
        var viewModel = new Kokomija.Models.ViewModels.ShippingProvidersViewModel
        {
            Providers = providers,
            TotalProviders = providers.Count,
            ActiveProviders = providers.Count(p => p.IsActive)
        };
        return View(viewModel);
    }

    // GET: /Admin/ShippingRates
    public async Task<IActionResult> ShippingRates()
    {
        var rates = await _shippingService.GetAllRatesAsync();
        var providers = await _shippingService.GetAllProvidersAsync();
        var viewModel = new Kokomija.Models.ViewModels.ShippingRatesViewModel
        {
            Rates = rates,
            Providers = providers,
            TotalRates = rates.Count,
            ActiveRates = rates.Count(r => r.IsActive)
        };
        return View(viewModel);
    }

    // POST: /Admin/CreateShippingProvider
    [HttpPost]
    public async Task<IActionResult> CreateShippingProvider([FromBody] Kokomija.Models.ViewModels.CreateShippingProviderDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _shippingService.CreateProviderAsync(dto);
        return Json(new { success = result.Success, message = result.Message, providerId = result.ProviderId });
    }

    // POST: /Admin/UpdateShippingProvider
    [HttpPost]
    public async Task<IActionResult> UpdateShippingProvider(int id, [FromBody] Kokomija.Models.ViewModels.UpdateShippingProviderDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _shippingService.UpdateProviderAsync(id, dto);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/DeleteShippingProvider
    [HttpPost]
    public async Task<IActionResult> DeleteShippingProvider(int id)
    {
        var result = await _shippingService.DeleteProviderAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/ToggleShippingProvider
    [HttpPost]
    public async Task<IActionResult> ToggleShippingProvider(int id)
    {
        var result = await _shippingService.ToggleProviderStatusAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/CreateShippingRate
    [HttpPost]
    public async Task<IActionResult> CreateShippingRate([FromBody] Kokomija.Models.ViewModels.CreateShippingRateDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _shippingService.CreateRateAsync(dto);
        return Json(new { success = result.Success, message = result.Message, rateId = result.RateId });
    }

    // POST: /Admin/UpdateShippingRate
    [HttpPost]
    public async Task<IActionResult> UpdateShippingRate(int id, [FromBody] Kokomija.Models.ViewModels.UpdateShippingRateDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _shippingService.UpdateRateAsync(id, dto);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/DeleteShippingRate
    [HttpPost]
    public async Task<IActionResult> DeleteShippingRate(int id)
    {
        var result = await _shippingService.DeleteRateAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/ToggleShippingRate
    [HttpPost]
    public async Task<IActionResult> ToggleShippingRate(int id)
    {
        var result = await _shippingService.ToggleRateStatusAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    #endregion

    #region Tax Management

    // GET: /Admin/TaxRates
    public async Task<IActionResult> TaxRates()
    {
        var taxRates = await _taxService.GetAllTaxRatesAsync();
        var defaultTaxRate = await _taxService.GetDefaultTaxRateAsync();
        
        var viewModel = new Kokomija.Models.ViewModels.TaxRatesViewModel
        {
            TaxRates = taxRates,
            TotalTaxRates = taxRates.Count,
            ActiveTaxRates = taxRates.Count(tr => tr.IsActive),
            DefaultTaxRate = defaultTaxRate
        };
        
        return View(viewModel);
    }

    // POST: /Admin/CreateTaxRate
    [HttpPost]
    public async Task<IActionResult> CreateTaxRate([FromBody] Kokomija.Models.ViewModels.CreateTaxRateDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _taxService.CreateTaxRateAsync(dto);
        return Json(new { success = result.Success, message = result.Message, taxRateId = result.TaxRateId });
    }

    // POST: /Admin/UpdateTaxRate
    [HttpPost]
    public async Task<IActionResult> UpdateTaxRate(int id, [FromBody] Kokomija.Models.ViewModels.UpdateTaxRateDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _taxService.UpdateTaxRateAsync(id, dto);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/DeleteTaxRate
    [HttpPost]
    public async Task<IActionResult> DeleteTaxRate(int id)
    {
        var result = await _taxService.DeleteTaxRateAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/ToggleTaxRate
    [HttpPost]
    public async Task<IActionResult> ToggleTaxRate(int id)
    {
        var result = await _taxService.ToggleTaxRateStatusAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/SetDefaultTaxRate
    [HttpPost]
    public async Task<IActionResult> SetDefaultTaxRate(int id)
    {
        var result = await _taxService.SetDefaultTaxRateAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/SyncTaxRateWithStripe
    [HttpPost]
    public async Task<IActionResult> SyncTaxRateWithStripe(int id)
    {
        var result = await _taxService.SyncTaxRateWithStripeAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    #endregion

    #region Commission Settings (ROOT Only)

    // GET: /Admin/CommissionSettings
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> CommissionSettings()
    {
        var settings = (await _unitOfWork.CommissionSettings.GetAllAsync()).FirstOrDefault();
        var activeClosure = (await _unitOfWork.SiteClosures.GetAllAsync(sc => sc.IsClosed)).FirstOrDefault();

        // Calculate earnings summary
        var today = DateTime.UtcNow.Date;
        var weekStart = today.AddDays(-(int)today.DayOfWeek);
        var monthStart = new DateTime(today.Year, today.Month, 1);
        var yearStart = new DateTime(today.Year, 1, 1);

        var allEarnings = await _unitOfWork.DeveloperEarnings.GetAllAsync();

        var summary = new Kokomija.Models.ViewModels.DeveloperEarningsSummaryDto
        {
            TodayEarnings = allEarnings.Where(e => e.EarnedAt.Date == today).Sum(e => e.DeveloperCommission),
            WeekEarnings = allEarnings.Where(e => e.EarnedAt.Date >= weekStart).Sum(e => e.DeveloperCommission),
            MonthEarnings = allEarnings.Where(e => e.EarnedAt >= monthStart).Sum(e => e.DeveloperCommission),
            YearEarnings = allEarnings.Where(e => e.EarnedAt >= yearStart).Sum(e => e.DeveloperCommission),
            AllTimeEarnings = allEarnings.Sum(e => e.DeveloperCommission),
            PendingPayout = allEarnings.Where(e => e.PayoutStatus == Entity.PayoutStatus.Pending).Sum(e => e.DeveloperCommission),
            TotalOrders = allEarnings.Count(),
            AverageCommissionPerOrder = allEarnings.Any() ? allEarnings.Average(e => e.DeveloperCommission) : 0
        };

        // Calculate next payout date based on frequency
        if (settings != null && settings.AutoPayoutEnabled)
        {
            summary.NextPayoutDate = settings.PayoutFrequency switch
            {
                Entity.PayoutFrequency.Daily => DateTime.UtcNow.Date.AddDays(1),
                Entity.PayoutFrequency.Weekly => weekStart.AddDays(7),
                Entity.PayoutFrequency.BiWeekly => weekStart.AddDays(14),
                Entity.PayoutFrequency.Monthly => monthStart.AddMonths(1),
                _ => null
            };
        }

        var recentEarnings = allEarnings
            .OrderByDescending(e => e.EarnedAt)
            .Take(10)
            .Select(e => new Kokomija.Models.ViewModels.DeveloperEarningDto
            {
                Id = e.Id,
                OrderId = e.OrderId,
                OrderNumber = $"ORD-{e.OrderId}",
                GrossAmount = e.GrossAmount,
                StripeProcessingFee = e.StripeProcessingFee,
                DeveloperCommission = e.DeveloperCommission,
                NetAmount = e.NetAmount,
                EarnedAt = e.EarnedAt,
                PayoutStatus = e.PayoutStatus.ToString(),
                PayoutId = e.PayoutId,
                PayoutDate = e.PayoutDate
            })
            .ToList();

        var viewModel = new Kokomija.Models.ViewModels.CommissionSettingsViewModel
        {
            Settings = settings == null ? null : new Kokomija.Models.ViewModels.CommissionSettingsDto
            {
                Id = settings.Id,
                DeveloperCommissionRate = settings.DeveloperCommissionRate,
                PlatformCommissionRate = settings.PlatformCommissionRate,
                StripeCommissionRate = settings.StripeCommissionRate,
                StripeFixedFee = settings.StripeFixedFee,
                MinimumPayoutAmount = settings.MinimumPayoutAmount,
                PayoutFrequency = settings.PayoutFrequency.ToString(),
                AutoPayoutEnabled = settings.AutoPayoutEnabled,
                LastModifiedAt = settings.LastModifiedAt,
                LastModifiedBy = settings.LastModifiedBy
            },
            EarningsSummary = summary,
            RecentEarnings = recentEarnings,
            ActiveSiteClosure = activeClosure == null ? null : new Kokomija.Models.ViewModels.SiteClosureDto
            {
                Id = activeClosure.Id,
                Reason = activeClosure.Reason ?? string.Empty,
                Message = string.Empty,
                IsActive = activeClosure.IsClosed,
                StartDate = activeClosure.ClosedAt,
                EndDate = activeClosure.ScheduledReopenAt,
                CreatedAt = activeClosure.ClosedAt ?? DateTime.UtcNow
            }
        };

        return View(viewModel);
    }

    // POST: /Admin/UpdateCommissionSettings
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> UpdateCommissionSettings([FromBody] Kokomija.Models.ViewModels.UpdateCommissionSettingsDto dto)
    {
        try
        {
            // Validate commission rates
            if (dto.DeveloperCommissionRate < 0 || dto.DeveloperCommissionRate > 100)
            {
                return Json(new { success = false, message = "Developer commission rate must be between 0 and 100" });
            }

            if (dto.PlatformCommissionRate < 0 || dto.PlatformCommissionRate > 100)
            {
                return Json(new { success = false, message = "Platform commission rate must be between 0 and 100" });
            }

            var settings = (await _unitOfWork.CommissionSettings.GetAllAsync()).FirstOrDefault();

            if (settings == null)
            {
                // Create new settings
                settings = new Entity.CommissionSettings
                {
                    DeveloperCommissionRate = dto.DeveloperCommissionRate,
                    PlatformCommissionRate = dto.PlatformCommissionRate,
                    StripeCommissionRate = dto.StripeCommissionRate,
                    StripeFixedFee = dto.StripeFixedFee,
                    MinimumPayoutAmount = dto.MinimumPayoutAmount,
                    PayoutFrequency = Enum.Parse<Entity.PayoutFrequency>(dto.PayoutFrequency),
                    AutoPayoutEnabled = dto.AutoPayoutEnabled,
                    LastModifiedBy = User.Identity?.Name ?? "Unknown",
                    LastModifiedAt = DateTime.UtcNow
                };
                await _unitOfWork.CommissionSettings.AddAsync(settings);
            }
            else
            {
                // Update existing settings
                settings.DeveloperCommissionRate = dto.DeveloperCommissionRate;
                settings.PlatformCommissionRate = dto.PlatformCommissionRate;
                settings.StripeCommissionRate = dto.StripeCommissionRate;
                settings.StripeFixedFee = dto.StripeFixedFee;
                settings.MinimumPayoutAmount = dto.MinimumPayoutAmount;
                settings.PayoutFrequency = Enum.Parse<Entity.PayoutFrequency>(dto.PayoutFrequency);
                settings.AutoPayoutEnabled = dto.AutoPayoutEnabled;
                settings.LastModifiedBy = User.Identity?.Name ?? "Unknown";
                settings.LastModifiedAt = DateTime.UtcNow;
            }

            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Commission settings updated by {User}", User.Identity?.Name);

            return Json(new { success = true, message = "Commission settings updated successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating commission settings");
            return Json(new { success = false, message = "Error updating commission settings" });
        }
    }

    // GET: /Admin/DeveloperEarnings
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> DeveloperEarnings(int page = 1, int pageSize = 50)
    {
        var today = DateTime.UtcNow.Date;
        var weekStart = today.AddDays(-(int)today.DayOfWeek);
        var monthStart = new DateTime(today.Year, today.Month, 1);
        var yearStart = new DateTime(today.Year, 1, 1);

        var allEarnings = await _unitOfWork.DeveloperEarnings.GetAllAsync();

        var summary = new Kokomija.Models.ViewModels.DeveloperEarningsSummaryDto
        {
            TodayEarnings = allEarnings.Where(e => e.EarnedAt.Date == today).Sum(e => e.DeveloperCommission),
            WeekEarnings = allEarnings.Where(e => e.EarnedAt.Date >= weekStart).Sum(e => e.DeveloperCommission),
            MonthEarnings = allEarnings.Where(e => e.EarnedAt >= monthStart).Sum(e => e.DeveloperCommission),
            YearEarnings = allEarnings.Where(e => e.EarnedAt >= yearStart).Sum(e => e.DeveloperCommission),
            AllTimeEarnings = allEarnings.Sum(e => e.DeveloperCommission),
            PendingPayout = allEarnings.Where(e => e.PayoutStatus == Entity.PayoutStatus.Pending).Sum(e => e.DeveloperCommission),
            TotalOrders = allEarnings.Count(),
            AverageCommissionPerOrder = allEarnings.Any() ? allEarnings.Average(e => e.DeveloperCommission) : 0
        };

        var pagedEarnings = allEarnings
            .OrderByDescending(e => e.EarnedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(e => new Kokomija.Models.ViewModels.DeveloperEarningDto
            {
                Id = e.Id,
                OrderId = e.OrderId,
                OrderNumber = $"ORD-{e.OrderId}",
                GrossAmount = e.GrossAmount,
                StripeProcessingFee = e.StripeProcessingFee,
                DeveloperCommission = e.DeveloperCommission,
                NetAmount = e.NetAmount,
                EarnedAt = e.EarnedAt,
                PayoutStatus = e.PayoutStatus.ToString(),
                PayoutId = e.PayoutId,
                PayoutDate = e.PayoutDate
            })
            .ToList();

        var viewModel = new Kokomija.Models.ViewModels.DeveloperEarningsViewModel
        {
            Summary = summary,
            Earnings = pagedEarnings,
            TotalRecords = allEarnings.Count(),
            PageNumber = page,
            PageSize = pageSize
        };

        return View(viewModel);
    }

    // POST: /Admin/BlockSite
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> BlockSite([FromBody] Kokomija.Models.ViewModels.CreateSiteClosureDto dto)
    {
        try
        {
            // Deactivate any existing active closures
            var activeClosures = await _unitOfWork.SiteClosures.GetAllAsync(sc => sc.IsClosed);
            foreach (var closure in activeClosures)
            {
                closure.IsClosed = false;
            }

            // Create new site closure
            var siteClosure = new Entity.SiteClosure
            {
                Reason = dto.Reason,
                IsClosed = true,
                ClosedBy = User.Identity?.Name ?? "System",
                ClosedAt = dto.StartDate ?? DateTime.UtcNow,
                ScheduledReopenAt = dto.EndDate
            };

            await _unitOfWork.SiteClosures.AddAsync(siteClosure);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogWarning("Site blocked by {User}. Reason: {Reason}", User.Identity?.Name, dto.Reason);

            return Json(new { success = true, message = "Site blocked successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error blocking site");
            return Json(new { success = false, message = "Error blocking site" });
        }
    }

    // POST: /Admin/UnblockSite
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> UnblockSite(int id)
    {
        try
        {
            var closure = await _unitOfWork.SiteClosures.GetByIdAsync(id);
            if (closure == null)
            {
                return Json(new { success = false, message = "Site closure not found" });
            }

            closure.IsClosed = false;
            closure.ScheduledReopenAt = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Site unblocked by {User}", User.Identity?.Name);

            return Json(new { success = true, message = "Site unblocked successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error unblocking site");
            return Json(new { success = false, message = "Error unblocking site" });
        }
    }

    #endregion

    #region Return Management

    // GET: /Admin/ReturnRequests
    public async Task<IActionResult> ReturnRequests()
    {
        var statistics = await _returnRequestService.GetReturnRequestsStatisticsAsync();
        return View(statistics);
    }

    // GET: /Admin/ReturnRequestDetails
    public async Task<IActionResult> ReturnRequestDetails(int id)
    {
        var returnRequest = await _returnRequestService.GetReturnRequestDetailsAsync(id);
        if (returnRequest == null)
        {
            return NotFound();
        }
        return View(returnRequest);
    }

    // POST: /Admin/ReviewReturnRequest
    [HttpPost]
    public async Task<IActionResult> ReviewReturnRequest([FromBody] Kokomija.Models.ViewModels.ReturnRequest.ReviewReturnRequestDto dto)
    {
        try
        {
            var reviewerId = User.Identity?.Name ?? "Admin";
            var result = await _returnRequestService.ReviewReturnRequestAsync(dto, reviewerId);

            return Json(new { success = result.Success, message = result.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reviewing return request");
            return Json(new { success = false, message = "An error occurred while reviewing the return request" });
        }
    }

    #endregion
}

