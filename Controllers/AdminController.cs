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
    private readonly ILocalizationService _localizationService;

    public AdminController(
        IUnitOfWork unitOfWork, 
        ILogger<AdminController> logger,
        ICarouselImageService carouselImageService,
        ICarouselService carouselService,
        ILocalizationService localizationService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _carouselImageService = carouselImageService;
        _carouselService = carouselService;
        _localizationService = localizationService;
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

    public async Task<IActionResult> Settings()
    {
        _logger.LogInformation("Admin accessed site settings");

        var viewModel = new SiteSettingsViewModel();

        try
        {
            // Get carousel slides
            var carouselSlides = await _unitOfWork.CarouselSlides.GetAllAsync();
            viewModel.CarouselSlides = carouselSlides.Select(c => new CarouselSlideItemViewModel
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

            viewModel.TotalCarouselSlides = carouselSlides.Count();
            viewModel.ActiveCarouselSlides = carouselSlides.Count(c => c.IsActive);

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

            // Translation keys (placeholder - showing structure only)
            viewModel.TranslationKeys = new List<TranslationKeyViewModel>
            {
                new TranslationKeyViewModel
                {
                    Key = "Nav_Home",
                    Category = "Navigation",
                    Values = new Dictionary<string, string>
                    {
                        { "en-US", "Home" },
                        { "pl-PL", "Strona główna" }
                    }
                },
                new TranslationKeyViewModel
                {
                    Key = "Nav_Products",
                    Category = "Navigation",
                    Values = new Dictionary<string, string>
                    {
                        { "en-US", "Products" },
                        { "pl-PL", "Produkty" }
                    }
                }
            };
            viewModel.TotalTranslationKeys = 170; // Approximate count from your resx files
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
                TempData["Error"] = "Carousel slide not found";
                return RedirectToAction(nameof(Settings));
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system";
            await _carouselService.DeleteSlideAsync(id, userId);

            _logger.LogInformation("Carousel slide deleted successfully: {SlideId}", id);
            TempData["Success"] = _localizationService["Admin_Carousel_SuccessDeleted"];
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting carousel slide");
            TempData["Error"] = "Error deleting carousel slide";
        }

        return RedirectToAction(nameof(Settings));
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
}
