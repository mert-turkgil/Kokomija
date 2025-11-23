using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Admin;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

    public AdminController(
        IUnitOfWork unitOfWork, 
        ILogger<AdminController> logger,
        ICarouselImageService carouselImageService,
        ICarouselService carouselService,
        ICategoryImageService categoryImageService,
        ILocalizationService localizationService,
        ITranslationManagementService translationManagementService,
        IWebHostEnvironment environment)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _carouselImageService = carouselImageService;
        _carouselService = carouselService;
        _categoryImageService = categoryImageService;
        _localizationService = localizationService;
        _translationManagementService = translationManagementService;
        _environment = environment;
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

    public IActionResult Products()
    {
        // Future: Product management
        return View();
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
    /// POST: Delete carousel slide (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CarouselDeleteAjax(int id)
    {
        try
        {
            // Get slide including soft-deleted ones to allow re-deletion
            var allSlides = await _unitOfWork.CarouselSlides.GetAllAsync();
            var slide = allSlides.FirstOrDefault(s => s.Id == id);

            if (slide == null)
            {
                _logger.LogWarning("CarouselDeleteAjax: Slide {SlideId} not found in database", id);
                return Json(new { success = false, message = _localizationService["Admin_Carousel_NotFound"], slideId = id });
            }

            // Check if already deleted
            if (slide.IsDeleted)
            {
                _logger.LogWarning("CarouselDeleteAjax: Slide {SlideId} is already deleted", id);
                return Json(new { success = false, message = "This slide has already been deleted", slideId = id });
            }

            _logger.LogInformation("CarouselDeleteAjax: Deleting slide {SlideId}: Desktop={Desktop}, Tablet={Tablet}, Mobile={Mobile}",
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
                    _logger.LogInformation("CarouselDeleteAjax: Successfully deleted image: {ImagePath}", imagePath);
                }
                catch (Exception imgEx)
                {
                    _logger.LogError(imgEx, "CarouselDeleteAjax: Failed to delete image: {ImagePath}", imagePath);
                    // Continue with other deletions even if one fails
                }
            }

            // Delete from database (soft delete)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system";
            await _carouselService.DeleteSlideAsync(id, userId);

            _logger.LogInformation("CarouselDeleteAjax: Slide deleted via AJAX: {SlideId} by user {UserId}", id, userId);

            return Json(new {
                success = true,
                message = _localizationService["Admin_Carousel_SuccessDeleted"],
                slideId = id
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "CarouselDeleteAjax: Error deleting carousel slide {SlideId}", id);
            return Json(new { success = false, message = _localizationService["Admin_Carousel_ErrorDeleted"], slideId = id });
        }
        // Fallback: should never hit this, but just in case
        _logger.LogError("CarouselDeleteAjax: Unexpected exit for slide {SlideId}", id);
        return Json(new { success = false, message = "Unexpected error occurred.", slideId = id });
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
}
