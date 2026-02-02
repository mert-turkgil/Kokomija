using Kokomija.Data.Abstract;
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
    private readonly IBlogService _blogService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBlogImageService _blogImageService;
    private readonly ILocalizationService _localizationService;
    private readonly ILogger<AdminBlogController> _logger;
    private readonly IConfiguration _configuration;

    public AdminBlogController(IBlogService blogService, IUnitOfWork unitOfWork, IBlogImageService blogImageService, 
        ILocalizationService localizationService, ILogger<AdminBlogController> logger, IConfiguration configuration)
    {
        _blogService = blogService;
        _unitOfWork = unitOfWork;
        _blogImageService = blogImageService;
        _localizationService = localizationService;
        _logger = logger;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> Index(string? category, string? status, string? search)
    {
        var viewModel = new SiteSettingsViewModel();
        var currentCulture = CultureInfo.CurrentCulture.Name;
        var blogs = (await _blogService.GetAllAsync()).ToList();

        if (!string.IsNullOrEmpty(category) && int.TryParse(category, out int categoryId))
            blogs = blogs.Where(b => b.CategoryId == categoryId).ToList();

        if (!string.IsNullOrEmpty(status))
            blogs = status.ToLower() == "published" ? blogs.Where(b => b.IsPublished).ToList() : 
                   status.ToLower() == "draft" ? blogs.Where(b => !b.IsPublished).ToList() : blogs;

        viewModel.BlogPosts = blogs.Select(blog =>
        {
            var trans = blog.Translations?.FirstOrDefault(t => t.CultureCode == currentCulture) ?? 
                       blog.Translations?.FirstOrDefault(t => t.CultureCode == "pl-PL") ?? 
                       blog.Translations?.FirstOrDefault();
            
            if (trans == null || (!string.IsNullOrEmpty(search) && !trans.Title.Contains(search, StringComparison.OrdinalIgnoreCase)))
                return null;

            return new BlogItemViewModel
            {
                Id = blog.Id,
                Title = trans.Title,
                Slug = trans.Slug,
                FeaturedImage = blog.FeaturedImage,
                AuthorName = blog.Author?.UserName ?? "Unknown",
                CategoryName = blog.Category?.Name ?? "Uncategorized",
                IsPublished = blog.IsPublished,
                PublishedDate = blog.PublishedDate,
                Views = blog.Views,
                CreatedAt = blog.CreatedAt,
                UpdatedAt = blog.UpdatedAt
            };
        }).Where(x => x != null).ToList()!;

        var stats = await _blogService.GetBlogStatisticsAsync();
        viewModel.TotalBlogs = stats.GetValueOrDefault("Total", 0);
        viewModel.PublishedBlogs = stats.GetValueOrDefault("Published", 0);
        viewModel.DraftBlogs = stats.GetValueOrDefault("Draft", 0);

        ViewBag.BlogCategories = (await _unitOfWork.BlogCategories.GetActiveCategoriesAsync()).OrderBy(c => c.DisplayOrder).ToList();
        ViewBag.CurrentCategory = category;
        ViewBag.CurrentStatus = status;
        ViewBag.CurrentSearch = search;

        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await LoadFormDataAsync();
        return View(new BlogCreateDto
        {
            AllowComments = true,
            PublishedDate = DateTime.UtcNow,
            Translations = new List<BlogTranslationDto>
            {
                new() { CultureCode = "en-US" },
                new() { CultureCode = "pl-PL" }
            }
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BlogCreateDto model)
    {
        if (!ModelState.IsValid)
        {
            await LoadFormDataAsync();
            TempData["Error"] = "Validation error";
            return View(model);
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            TempData["Error"] = "User not authenticated";
            return RedirectToAction(nameof(Index));
        }

        var result = await _blogService.CreateBlogAsync(model, userId);
        if (result.Success)
        {
            TempData["Success"] = "Blog created successfully";
            return RedirectToAction(nameof(Edit), new { id = result.BlogId });
        }

        TempData["Error"] = result.Message;
        await LoadFormDataAsync();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var blog = await _blogService.GetByIdAsync(id);
        if (blog == null)
        {
            TempData["Error"] = "Blog not found";
            return RedirectToAction(nameof(Index));
        }

        var model = new BlogUpdateDto
        {
            Id = blog.Id,
            CategoryId = blog.CategoryId,
            ProductId = blog.ProductId,
            IsPublished = blog.IsPublished,
            PublishedDate = blog.PublishedDate,
            AllowComments = blog.AllowComments,
            FeaturedImage = blog.FeaturedImage,
            Translations = blog.Translations?.Select(t => new BlogTranslationDto
            {
                Id = t.Id,
                CultureCode = t.CultureCode,
                Title = t.Title,
                Slug = t.Slug,
                Content = t.Content,
                Excerpt = t.Excerpt,
                MetaDescription = t.MetaDescription,
                MetaKeywords = t.MetaKeywords,
                Tags = t.Tags
            }).ToList() ?? new()
        };

        if (!model.Translations.Any(t => t.CultureCode == "en-US"))
            model.Translations.Add(new() { CultureCode = "en-US" });
        if (!model.Translations.Any(t => t.CultureCode == "pl-PL"))
            model.Translations.Add(new() { CultureCode = "pl-PL" });

        await LoadFormDataAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, BlogUpdateDto model)
    {
        if (id != model.Id)
        {
            TempData["Error"] = "Invalid blog ID";
            return RedirectToAction(nameof(Index));
        }

        if (!ModelState.IsValid)
        {
            await LoadFormDataAsync();
            TempData["Error"] = "Validation error";
            return View(model);
        }

        var result = await _blogService.UpdateBlogAsync(id, model);
        if (result.Success)
        {
            TempData["Success"] = "Blog updated successfully";
            return RedirectToAction(nameof(Edit), new { id });
        }

        TempData["Error"] = result.Message;
        await LoadFormDataAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id, bool hardDelete = false)
    {
        var result = await _blogService.DeleteBlogAsync(id, hardDelete);
        TempData[result.Success ? "Success" : "Error"] = result.Message;
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> TogglePublish([FromBody] BlogTogglePublishDto dto)
    {
        var result = await _blogService.TogglePublishAsync(dto.Id);
        if (result.Success)
        {
            var blog = await _blogService.GetByIdAsync(dto.Id);
            return Json(new { success = true, isPublished = blog?.IsPublished ?? false, message = result.Message });
        }
        return Json(new { success = false, message = result.Message });
    }

    [HttpGet]
    public async Task<IActionResult> GetProductsByCategory(int categoryId)
    {
        var category = await _unitOfWork.BlogCategories.GetByIdAsync(categoryId);
        if (category?.ProductCategoryId == null)
            return Json(new { success = true, products = new List<object>() });

        var products = (await _unitOfWork.Products.GetAllAsync())
            .Where(p => p.IsActive && p.CategoryId == category.ProductCategoryId.Value)
            .Select(p => new { id = p.Id, name = p.Name })
            .OrderBy(p => p.name)
            .ToList();

        return Json(new { success = true, products });
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        var result = await _blogImageService.UploadToTempAsync(file);
        return result.Success ? 
            Json(new { success = true, tempFileName = result.TempFileName, tempUrl = result.TempUrl }) :
            Json(new { success = false, message = result.Message });
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> UploadCKEditorImage(IFormFile upload)
    {
        if (upload == null || upload.Length == 0)
            return Json(new { uploaded = false, error = new { message = "No file uploaded" } });

        var result = await _blogImageService.UploadCKEditorImageAsync(upload);
        return result.Success ?
            Json(new { uploaded = true, url = result.PermanentUrl }) :
            Json(new { uploaded = false, error = new { message = result.Message } });
    }

    [HttpPost]
    [IgnoreAntiforgeryToken]
    public async Task<IActionResult> CancelUpload([FromBody] BlogCancelUploadDto? model)
    {
        var tempFileName = model?.ImageTempFileName;
        
        if (string.IsNullOrEmpty(tempFileName))
        {
            using var reader = new StreamReader(Request.Body);
            var body = await reader.ReadToEndAsync();
            if (!string.IsNullOrEmpty(body))
            {
                try
                {
                    var jsonDoc = System.Text.Json.JsonDocument.Parse(body);
                    if (jsonDoc.RootElement.TryGetProperty("imageTempFileName", out var elem))
                        tempFileName = elem.GetString();
                }
                catch { }
            }
        }
        
        if (!string.IsNullOrEmpty(tempFileName))
            await _blogImageService.CancelUploadAsync(tempFileName);
        
        return Json(new { success = true });
    }

    [HttpPost]
    public async Task<IActionResult> AutoSaveDraft([FromBody] BlogUpdateDto model)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Json(new { success = false, message = "User not authenticated" });

        var result = await _blogService.AutoSaveDraftAsync(model, userId);
        return Json(new { 
            success = result.Success, 
            blogId = result.BlogId,
            message = result.Message,
            timestamp = DateTime.UtcNow
        });
    }

    [HttpPost]
    public async Task<IActionResult> ValidateSlug([FromBody] SlugValidationDto dto)
    {
        var result = await _blogService.ValidateSlugUniquenessAsync(dto.Slug, dto.CultureCode, dto.BlogId);
        return Json(new { 
            success = result.Success,
            message = result.Message,
            isAvailable = result.Success
        });
    }

    [HttpPost]
    public IActionResult AnalyzeSEO([FromBody] SEOAnalysisDto dto)
    {
        var result = _blogService.AnalyzeSEOAsync(dto.Title, dto.Content, dto.MetaDescription, dto.Keywords);
        return Json(new { 
            success = true,
            data = result
        });
    }

    private async Task LoadFormDataAsync()
    {
        ViewBag.Categories = (await _unitOfWork.BlogCategories.GetActiveCategoriesAsync()).OrderBy(c => c.DisplayOrder).ToList();
        ViewBag.Products = (await _unitOfWork.Products.GetAllAsync()).Where(p => p.IsActive).OrderBy(p => p.Name).ToList();
        ViewBag.CKEditorLicenseKey = _configuration["CKEditor:LicenseKey"];
    }
}

// Additional DTO Classes (not in BlogDtos.cs)
public class BlogTogglePublishDto 
{ 
    public int Id { get; set; } 
}

public class SlugValidationDto 
{ 
    public string Slug { get; set; } = string.Empty;
    public string CultureCode { get; set; } = string.Empty;
    public int? BlogId { get; set; }
}

public class SEOAnalysisDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string MetaDescription { get; set; } = string.Empty;
    public string Keywords { get; set; } = string.Empty;
}