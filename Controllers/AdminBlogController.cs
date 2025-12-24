using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Admin;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;

namespace Kokomija.Controllers;

[Authorize(Roles = "Root,Admin")]
public class AdminBlogController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AdminBlogController> _logger;
    private readonly IBlogImageService _blogImageService;
    private readonly ILocalizationService _localizationService;
    private readonly IConfiguration _configuration;

    public AdminBlogController(
        IUnitOfWork unitOfWork,
        ILogger<AdminBlogController> logger,
        IBlogImageService blogImageService,
        ILocalizationService localizationService,
        IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _blogImageService = blogImageService;
        _localizationService = localizationService;
        _configuration = configuration;
    }

    /// <summary>
    /// GET: Blog Settings / List
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Index()
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
                var translations = (await _unitOfWork.Repository<BlogTranslation>()
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

    /// <summary>
    /// GET: Create new blog post form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> Create()
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
    public async Task<IActionResult> Create(BlogCreateDto model)
    {
        if (!ModelState.IsValid)
        {
            // Cleanup CKEditor images on validation failure
            if (!string.IsNullOrEmpty(model.SessionId))
            {
                var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
                if (trackingService != null)
                {
                    await trackingService.RollbackImagesAsync(model.SessionId);
                }
            }
            
            // Cleanup temp featured image on validation failure
            if (!string.IsNullOrEmpty(model.ImageTempFileName))
            {
                await _blogImageService.CancelUploadAsync(model.ImageTempFileName);
            }
            
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Create blog entity
            var blog = new Blog
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
            var translations = new List<BlogTranslation>();
            foreach (var translationDto in model.Translations)
            {
                if (string.IsNullOrWhiteSpace(translationDto.Title)) continue;

                var translation = new BlogTranslation
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
                    await _unitOfWork.Repository<BlogTranslation>().AddAsync(trans);
                }
                await _unitOfWork.SaveChangesAsync();
            }

            // Commit CKEditor images after successful save
            if (!string.IsNullOrEmpty(model.SessionId))
            {
                var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
                if (trackingService != null)
                {
                    trackingService.CommitImages(model.SessionId);
                }
            }

            _logger.LogInformation("Blog post created: {BlogId} by user {UserId}", blog.Id, userId);
            TempData["Success"] = _localizationService["Admin_Blog_CreateSuccess"];
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating blog post");
            TempData["Error"] = _localizationService["Admin_Blog_ErrorSave"];
            
            // Cleanup temp featured image
            if (tempFilesToCleanup.Length > 0)
            {
                foreach (var tempFile in tempFilesToCleanup)
                {
                    await _blogImageService.CancelUploadAsync(tempFile);
                }
            }
            
            // Cleanup CKEditor images if session exists
            if (!string.IsNullOrEmpty(model.SessionId))
            {
                var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
                if (trackingService != null)
                {
                    await trackingService.RollbackImagesAsync(model.SessionId);
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
    public async Task<IActionResult> Edit(int id)
    {
        var blog = await _unitOfWork.Blogs.GetByIdAsync(id);
        if (blog == null)
        {
            TempData["Error"] = "Blog post not found";
            return RedirectToAction(nameof(Index));
        }

        // Load translations
        var translations = (await _unitOfWork.Repository<BlogTranslation>()
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
    public async Task<IActionResult> Edit(BlogUpdateDto model)
    {
        if (!ModelState.IsValid)
        {
            // Cleanup CKEditor images on validation failure
            if (!string.IsNullOrEmpty(model.SessionId))
            {
                var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
                if (trackingService != null)
                {
                    await trackingService.RollbackImagesAsync(model.SessionId);
                }
            }
            
            // Cleanup temp featured image on validation failure
            if (!string.IsNullOrEmpty(model.NewImageTempFileName))
            {
                await _blogImageService.CancelUploadAsync(model.NewImageTempFileName);
            }
            
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
                return RedirectToAction(nameof(Index));
            }

            // Update blog properties
            blog.CategoryId = model.CategoryId;
            blog.ProductId = model.ProductId;
            blog.IsPublished = model.IsPublished;
            blog.PublishedDate = model.IsPublished ? (model.PublishedDate ?? DateTime.UtcNow) : null;
            blog.AllowComments = model.AllowComments;

            // Process new featured image if uploaded
            if (!string.IsNullOrEmpty(model.NewImageTempFileName))
            {
                tempFilesToCleanup = new[] { model.NewImageTempFileName };
                
                // Delete old image first
                if (!string.IsNullOrEmpty(blog.FeaturedImage))
                {
                    await _blogImageService.DeleteImageAsync(blog.FeaturedImage);
                }
                
                // Move new image from temp to permanent
                var result = await _blogImageService.ProcessAndMoveFromTempAsync(model.NewImageTempFileName);
                if (result.Success)
                {
                    blog.FeaturedImage = result.PermanentUrl;
                }
            }
            
            blog.UpdatedAt = DateTime.UtcNow;

            _unitOfWork.Blogs.Update(blog);

            // Update translations
            var existingTranslations = (await _unitOfWork.Repository<BlogTranslation>()
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

                    _unitOfWork.Repository<BlogTranslation>().Update(existingTranslation);
                }
                else
                {
                    // Add new translation
                    var newTranslation = new BlogTranslation
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

                    await _unitOfWork.Repository<BlogTranslation>().AddAsync(newTranslation);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            // Commit CKEditor images after successful update
            if (!string.IsNullOrEmpty(model.SessionId))
            {
                var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
                if (trackingService != null)
                {
                    trackingService.CommitImages(model.SessionId);
                }
            }

            _logger.LogInformation("Blog post updated: {BlogId}", blog.Id);
            TempData["Success"] = _localizationService["Admin_Blog_UpdateSuccess"];
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating blog post {BlogId}", model.Id);
            TempData["Error"] = _localizationService["Admin_Blog_ErrorSave"];
            
            // Cleanup temp featured image
            if (tempFilesToCleanup.Length > 0)
            {
                foreach (var tempFile in tempFilesToCleanup)
                {
                    await _blogImageService.CancelUploadAsync(tempFile);
                }
            }
            
            // Cleanup CKEditor images if session exists
            if (!string.IsNullOrEmpty(model.SessionId))
            {
                var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
                if (trackingService != null)
                {
                    await trackingService.RollbackImagesAsync(model.SessionId);
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
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var blog = await _unitOfWork.Blogs.GetByIdAsync(id);
            if (blog == null)
            {
                TempData["Error"] = "Blog post not found";
                return RedirectToAction(nameof(Index));
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

        return RedirectToAction(nameof(Index));
    }

    /// <summary>
    /// GET: Get products by category (AJAX)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetProductsByCategory(int categoryId)
    {
        try
        {
            var category = await _unitOfWork.BlogCategories.GetByIdAsync(categoryId);
            if (category == null)
            {
                return Json(new { success = false, products = new List<object>() });
            }

            // Get products from the associated product category if exists
            var products = await _unitOfWork.Products.GetAllAsync();
            var filteredProducts = products
                .Where(p => p.IsActive && category.ProductCategoryId.HasValue && p.CategoryId == category.ProductCategoryId.Value)
                .Select(p => new { id = p.Id, name = p.Name })
                .OrderBy(p => p.name)
                .ToList();

            return Json(new { success = true, products = filteredProducts });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting products by category");
            return Json(new { success = false, products = new List<object>() });
        }
    }

    /// <summary>
    /// POST: Upload blog image to temp folder (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
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
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> CancelUpload([FromBody] BlogCancelUploadDto? model)
    {
        try
        {
            // Handle both JSON body and sendBeacon requests
            string? tempFileName = model?.ImageTempFileName;
            
            // If model is null, try reading from request body directly
            if (string.IsNullOrEmpty(tempFileName))
            {
                using var reader = new StreamReader(Request.Body);
                var body = await reader.ReadToEndAsync();
                
                if (!string.IsNullOrEmpty(body))
                {
                    try
                    {
                        var jsonDoc = System.Text.Json.JsonDocument.Parse(body);
                        if (jsonDoc.RootElement.TryGetProperty("imageTempFileName", out var fileNameElement))
                        {
                            tempFileName = fileNameElement.GetString();
                        }
                    }
                    catch
                    {
                        // Ignore JSON parse errors
                    }
                }
            }
            
            if (!string.IsNullOrEmpty(tempFileName))
            {
                var result = await _blogImageService.CancelUploadAsync(tempFileName);
                _logger.LogInformation("Temp file cleanup: {FileName}, Success: {Success}", tempFileName, result);
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
    /// POST: Upload image for CKEditor content (inline images/GIFs)
    /// Uploads directly to permanent folder and tracks for cleanup if blog is not saved
    /// </summary>
    [HttpPost]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> UploadCKEditorImage(IFormFile upload, [FromForm] string? sessionId)
    {
        try
        {
            if (upload == null || upload.Length == 0)
            {
                return Json(new { uploaded = false, error = new { message = "No file uploaded" } });
            }

            // Upload directly to permanent location for CKEditor images (GIFs, inline images)
            var result = await _blogImageService.UploadCKEditorImageAsync(upload);
            
            if (!result.Success)
            {
                return Json(new { uploaded = false, error = new { message = result.Message } });
            }

            // Track the image for potential cleanup if blog creation is cancelled
            if (!string.IsNullOrEmpty(sessionId))
            {
                var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
                trackingService?.TrackImage(sessionId, result.PermanentUrl!);
            }

            // CKEditor expects this specific JSON structure
            return Json(new 
            { 
                uploaded = true, 
                url = result.PermanentUrl 
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading CKEditor image");
            return Json(new { uploaded = false, error = new { message = "Error uploading image" } });
        }
    }

    /// <summary>
    /// POST: Toggle blog publish status (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> TogglePublish([FromBody] BlogTogglePublishDto dto)
    {
        try
        {
            var blog = await _unitOfWork.Blogs.GetByIdAsync(dto.Id);
            
            if (blog != null)
            {
                blog.IsPublished = !blog.IsPublished;
                blog.PublishedDate = blog.IsPublished ? DateTime.UtcNow : null;
                blog.UpdatedAt = DateTime.UtcNow;
                
                _unitOfWork.Blogs.Update(blog);
                await _unitOfWork.SaveChangesAsync();

                var statusMessage = blog.IsPublished ? "Blog post published successfully" : "Blog post unpublished (now private)";
                return Json(new { success = true, isPublished = blog.IsPublished, message = statusMessage });
            }
            else
            {
                return Json(new { success = false, message = "Blog post not found" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling blog publish status {BlogId}", dto.Id);
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

    /// <summary>
    /// POST: Commit CKEditor images when blog is successfully saved
    /// </summary>
    [HttpPost]
    public IActionResult CommitCKEditorImages([FromBody] BlogSessionDto dto)
    {
        try
        {
            if (string.IsNullOrEmpty(dto.SessionId))
            {
                return Json(new { success = false, message = "Session ID required" });
            }

            var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
            trackingService?.CommitImages(dto.SessionId);
            
            _logger.LogInformation("CKEditor images committed for session {SessionId}", dto.SessionId);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error committing CKEditor images");
            return Json(new { success = false, message = "Error committing images" });
        }
    }

    /// <summary>
    /// POST: Rollback CKEditor images when blog creation is cancelled
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> RollbackCKEditorImages([FromBody] BlogSessionDto dto)
    {
        try
        {
            if (string.IsNullOrEmpty(dto.SessionId))
            {
                return Json(new { success = false, message = "Session ID required" });
            }

            var trackingService = HttpContext.RequestServices.GetService<ICKEditorImageTrackingService>();
            if (trackingService != null)
            {
                await trackingService.RollbackImagesAsync(dto.SessionId);
            }
            
            _logger.LogInformation("CKEditor images rolled back for session {SessionId}", dto.SessionId);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error rolling back CKEditor images");
            return Json(new { success = false, message = "Error rolling back images" });
        }
    }
}
