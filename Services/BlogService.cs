using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Admin;
using System.Text.RegularExpressions;

namespace Kokomija.Services;

public class BlogService : IBlogService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBlogImageService _imageService;
    private readonly ILogger<BlogService> _logger;

    public BlogService(IUnitOfWork unitOfWork, IBlogImageService imageService, ILogger<BlogService> logger)
    {
        _unitOfWork = unitOfWork;
        _imageService = imageService;
        _logger = logger;
    }

    public async Task<Blog?> GetByIdAsync(int id, bool includeDeleted = false)
    {
        var blogs = await _unitOfWork.Blogs.FindAsync(b => b.Id == id);
        var blog = blogs.FirstOrDefault();
        
        if (blog == null || (!includeDeleted && blog.IsDeleted)) return null;
        
        blog.Translations = (await _unitOfWork.Repository<BlogTranslation>().FindAsync(t => t.BlogId == id)).ToList();
        blog.Category = await _unitOfWork.BlogCategories.GetByIdAsync(blog.CategoryId);
        if (blog.ProductId.HasValue) blog.Product = await _unitOfWork.Products.GetByIdAsync(blog.ProductId.Value);
        
        return blog;
    }

    public async Task<Blog?> GetBySlugAsync(string slug, string cultureCode) => 
        await _unitOfWork.Blogs.GetBySlugAsync(slug);

    public async Task<IEnumerable<Blog>> GetAllAsync(bool includeDeleted = false)
    {
        var blogs = (await _unitOfWork.Blogs.GetAllAsync()).Where(b => includeDeleted || !b.IsDeleted).ToList();
        foreach (var blog in blogs)
        {
            blog.Translations = (await _unitOfWork.Repository<BlogTranslation>().FindAsync(t => t.BlogId == blog.Id)).ToList();
            blog.Category = await _unitOfWork.BlogCategories.GetByIdAsync(blog.CategoryId);
        }
        return blogs.OrderByDescending(b => b.CreatedAt);
    }

    public async Task<IEnumerable<Blog>> GetPublishedBlogsAsync() => await _unitOfWork.Blogs.GetPublishedBlogsAsync();
    public async Task<IEnumerable<Blog>> GetBlogsByCategoryAsync(int categoryId) => await _unitOfWork.Blogs.GetBlogsByCategoryAsync(categoryId);
    
    public async Task<IEnumerable<Blog>> GetBlogsByAuthorAsync(string authorId)
    {
        var blogs = (await _unitOfWork.Blogs.FindAsync(b => b.AuthorId == authorId && !b.IsDeleted)).OrderByDescending(b => b.CreatedAt).ToList();
        foreach (var blog in blogs)
        {
            blog.Translations = (await _unitOfWork.Repository<BlogTranslation>().FindAsync(t => t.BlogId == blog.Id)).ToList();
            blog.Category = await _unitOfWork.BlogCategories.GetByIdAsync(blog.CategoryId);
        }
        return blogs;
    }

    public async Task<(bool Success, int? BlogId, string Message)> CreateBlogAsync(BlogCreateDto dto, string authorId)
    {
        var (isValid, errors) = await ValidateBlogDataAsync(dto);
        if (!isValid) return (false, null, string.Join(", ", errors));

        var blog = new Blog
        {
            CategoryId = dto.CategoryId,
            ProductId = dto.ProductId,
            AuthorId = authorId,
            IsPublished = dto.IsPublished,
            PublishedDate = dto.IsPublished ? (dto.PublishedDate ?? DateTime.UtcNow) : null,
            AllowComments = dto.AllowComments,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // Handle image from DTO.FeaturedImage (temp upload) or DTO.FeaturedImageFile
        if (!string.IsNullOrEmpty(dto.FeaturedImage))
            blog.FeaturedImage = dto.FeaturedImage;
        else if (dto.FeaturedImageFile != null)
        {
            var upload = await _imageService.UploadToTempAsync(dto.FeaturedImageFile);
            if (upload.Success && upload.TempFileName != null)
            {
                var move = await _imageService.ProcessAndMoveFromTempAsync(upload.TempFileName);
                if (move.Success) blog.FeaturedImage = move.PermanentUrl;
            }
        }

        await _unitOfWork.Blogs.AddAsync(blog);
        await _unitOfWork.SaveChangesAsync();
        
        if (dto.Translations?.Any() == true)
            await SaveTranslationsAsync(blog.Id, dto.Translations);

        return (true, blog.Id, "Blog created successfully");
    }

    public async Task<(bool Success, string Message)> UpdateBlogAsync(int id, BlogUpdateDto dto)
    {
        var blog = await GetByIdAsync(id);
        if (blog == null) return (false, "Blog not found");

        var (isValid, errors) = await ValidateBlogDataAsync(dto);
        if (!isValid) return (false, string.Join(", ", errors));

        blog.CategoryId = dto.CategoryId;
        blog.ProductId = dto.ProductId;
        blog.IsPublished = dto.IsPublished;
        blog.PublishedDate = dto.IsPublished ? (dto.PublishedDate ?? blog.PublishedDate ?? DateTime.UtcNow) : null;
        blog.AllowComments = dto.AllowComments;
        blog.UpdatedAt = DateTime.UtcNow;

        // Handle image updates
        if (dto.FeaturedImageFile != null)
        {
            if (!string.IsNullOrEmpty(blog.FeaturedImage))
                await _imageService.DeleteImageAsync(blog.FeaturedImage);
            
            var upload = await _imageService.UploadToTempAsync(dto.FeaturedImageFile);
            if (upload.Success && upload.TempFileName != null)
            {
                var move = await _imageService.ProcessAndMoveFromTempAsync(upload.TempFileName);
                if (move.Success) blog.FeaturedImage = move.PermanentUrl;
            }
        }
        else if (!string.IsNullOrEmpty(dto.FeaturedImage) && dto.FeaturedImage != blog.FeaturedImage)
        {
            if (!string.IsNullOrEmpty(blog.FeaturedImage))
                await _imageService.DeleteImageAsync(blog.FeaturedImage);
            blog.FeaturedImage = dto.FeaturedImage;
        }
        else if (string.IsNullOrEmpty(dto.FeaturedImage) && !string.IsNullOrEmpty(blog.FeaturedImage))
        {
            await _imageService.DeleteImageAsync(blog.FeaturedImage);
            blog.FeaturedImage = null;
        }

        _unitOfWork.Blogs.Update(blog);
        await _unitOfWork.SaveChangesAsync();

        if (dto.Translations?.Any() == true)
            await SaveTranslationsAsync(blog.Id, dto.Translations);

        return (true, "Blog updated successfully");
    }

    public async Task<(bool Success, string Message)> DeleteBlogAsync(int id, bool hardDelete = false)
    {
        var blog = await GetByIdAsync(id, true);
        if (blog == null) return (false, "Blog not found");

        if (hardDelete)
        {
            await DeleteBlogImagesAsync(id);
            var translations = await _unitOfWork.Repository<BlogTranslation>().FindAsync(t => t.BlogId == id);
            foreach (var t in translations) _unitOfWork.Repository<BlogTranslation>().Remove(t);
            _unitOfWork.Blogs.Remove(blog);
        }
        else
        {
            blog.IsDeleted = true;
            blog.UpdatedAt = DateTime.UtcNow;
            _unitOfWork.Blogs.Update(blog);
        }

        await _unitOfWork.SaveChangesAsync();
        return (true, hardDelete ? "Blog permanently deleted" : "Blog deleted successfully");
    }

    public async Task<(bool Success, string Message)> TogglePublishAsync(int id)
    {
        var blog = await GetByIdAsync(id);
        if (blog == null) return (false, "Blog not found");

        blog.IsPublished = !blog.IsPublished;
        blog.PublishedDate = blog.IsPublished ? (blog.PublishedDate ?? DateTime.UtcNow) : null;
        blog.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Blogs.Update(blog);
        await _unitOfWork.SaveChangesAsync();

        return (true, blog.IsPublished ? "Blog published" : "Blog unpublished");
    }

    public async Task<BlogTranslation?> GetTranslationAsync(int blogId, string cultureCode) =>
        (await _unitOfWork.Repository<BlogTranslation>().FindAsync(t => t.BlogId == blogId && t.CultureCode == cultureCode)).FirstOrDefault();

    public async Task<IEnumerable<BlogTranslation>> GetAllTranslationsAsync(int blogId) =>
        await _unitOfWork.Repository<BlogTranslation>().FindAsync(t => t.BlogId == blogId);

    public async Task<(bool Success, string Message)> SaveTranslationsAsync(int blogId, IEnumerable<BlogTranslationDto> translations)
    {
        var count = 0;
        foreach (var dto in translations.Where(t => !string.IsNullOrWhiteSpace(t.Title)))
        {
            var existing = (await _unitOfWork.Repository<BlogTranslation>()
                .FindAsync(t => t.BlogId == blogId && t.CultureCode == dto.CultureCode)).FirstOrDefault();

            var slug = !string.IsNullOrWhiteSpace(dto.Slug) ? dto.Slug : GenerateUniqueSlug(dto.Title, dto.CultureCode);

            if (existing != null)
            {
                existing.Title = dto.Title;
                existing.Slug = slug;
                existing.Content = dto.Content;
                existing.Excerpt = dto.Excerpt;
                existing.MetaDescription = dto.MetaDescription;
                existing.MetaKeywords = dto.MetaKeywords;
                existing.Tags = dto.Tags;
                existing.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.Repository<BlogTranslation>().Update(existing);
            }
            else
            {
                await _unitOfWork.Repository<BlogTranslation>().AddAsync(new BlogTranslation
                {
                    BlogId = blogId,
                    CultureCode = dto.CultureCode,
                    Title = dto.Title,
                    Slug = slug,
                    Content = dto.Content,
                    Excerpt = dto.Excerpt,
                    MetaDescription = dto.MetaDescription,
                    MetaKeywords = dto.MetaKeywords,
                    Tags = dto.Tags,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                });
            }
            count++;
        }

        await _unitOfWork.SaveChangesAsync();
        return (true, $"Saved {count} translations");
    }

    public async Task<(bool Success, string? Url, string Message)> UpdateFeaturedImageAsync(int blogId, string? newImageUrl)
    {
        var blog = await GetByIdAsync(blogId);
        if (blog == null) return (false, null, "Blog not found");

        if (!string.IsNullOrEmpty(blog.FeaturedImage))
            await _imageService.DeleteImageAsync(blog.FeaturedImage);

        blog.FeaturedImage = newImageUrl;
        blog.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.Blogs.Update(blog);
        await _unitOfWork.SaveChangesAsync();

        return (true, newImageUrl, "Image updated");
    }

    public Task<List<string>> ExtractImagesFromContentAsync(string htmlContent)
    {
        var images = new List<string>();
        if (string.IsNullOrWhiteSpace(htmlContent)) return Task.FromResult(images);

        var matches = Regex.Matches(htmlContent, @"<img[^>]+src=[""']([^""']+)[""'][^>]*>", RegexOptions.IgnoreCase);
        foreach (Match m in matches)
        {
            if (m.Groups[1].Value.Contains("/img/Blog/", StringComparison.OrdinalIgnoreCase))
                images.Add(m.Groups[1].Value);
        }
        return Task.FromResult(images.Distinct().ToList());
    }

    public Task CleanupOrphanedImagesAsync(int blogId, List<string> currentContentImages) => Task.CompletedTask;

    public async Task<(bool Success, string Message)> DeleteBlogImagesAsync(int blogId)
    {
        var blog = await GetByIdAsync(blogId, true);
        if (blog == null) return (false, "Blog not found");

        var count = 0;
        if (!string.IsNullOrEmpty(blog.FeaturedImage) && await _imageService.DeleteImageAsync(blog.FeaturedImage))
            count++;

        if (blog.Translations != null)
        {
            foreach (var t in blog.Translations)
            {
                var images = await ExtractImagesFromContentAsync(t.Content);
                foreach (var img in images)
                    if (await _imageService.DeleteImageAsync(img)) count++;
            }
        }

        return (true, $"Deleted {count} images");
    }

    public async Task<int> IncrementViewCountAsync(int blogId)
    {
        await _unitOfWork.Blogs.IncrementViewsAsync(blogId);
        var blog = await GetByIdAsync(blogId);
        return blog?.Views ?? 0;
    }

    public async Task<Dictionary<string, int>> GetBlogStatisticsAsync()
    {
        var all = (await _unitOfWork.Blogs.GetAllAsync()).ToList();
        return new Dictionary<string, int>
        {
            { "Total", all.Count(b => !b.IsDeleted) },
            { "Published", all.Count(b => !b.IsDeleted && b.IsPublished) },
            { "Draft", all.Count(b => !b.IsDeleted && !b.IsPublished) },
            { "TotalViews", all.Where(b => !b.IsDeleted).Sum(b => b.Views) }
        };
    }

    public async Task<IEnumerable<Blog>> GetRecentBlogsAsync(int count = 5) =>
        await _unitOfWork.Blogs.GetRecentBlogsAsync(count);

    public async Task<IEnumerable<Blog>> GetRelatedBlogsAsync(int blogId, int count = 3) =>
        await _unitOfWork.Blogs.GetRelatedBlogsAsync(blogId, count);

    public async Task<bool> SlugExistsAsync(string slug, string cultureCode, int? excludeBlogId = null)
    {
        var trans = await _unitOfWork.Repository<BlogTranslation>().FindAsync(t => t.Slug == slug && t.CultureCode == cultureCode);
        return excludeBlogId.HasValue ? trans.Any(t => t.BlogId != excludeBlogId.Value) : trans.Any();
    }

    public string GenerateUniqueSlug(string title, string cultureCode)
    {
        if (string.IsNullOrWhiteSpace(title)) return Guid.NewGuid().ToString("N")[..8];
        
        var slug = GenerateSlug(title);
        var counter = 1;
        var original = slug;
        
        while (SlugExistsAsync(slug, cultureCode).Result)
            slug = $"{original}-{counter++}";
        
        return slug;
    }

    private string GenerateSlug(string title)
    {
        var slug = title.ToLowerInvariant();
        slug = ReplaceDiacritics(slug);
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
        slug = Regex.Replace(slug, @"\s+", "-");
        slug = Regex.Replace(slug, @"-+", "-");
        return slug.Trim('-');
    }

    private string ReplaceDiacritics(string text)
    {
        var map = new Dictionary<char, char>
        {
            {'ą','a'},{'ć','c'},{'ę','e'},{'ł','l'},{'ń','n'},{'ó','o'},{'ś','s'},{'ź','z'},{'ż','z'}
        };
        var chars = text.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
            if (map.ContainsKey(chars[i])) chars[i] = map[chars[i]];
        return new string(chars);
    }

    public async Task<(bool IsValid, List<string> Errors)> ValidateBlogDataAsync(BlogCreateDto dto)
    {
        var errors = new List<string>();
        var cat = await _unitOfWork.BlogCategories.GetByIdAsync(dto.CategoryId);
        if (cat == null || cat.IsDeleted) errors.Add("Invalid category");
        
        if (dto.ProductId.HasValue)
        {
            var prod = await _unitOfWork.Products.GetByIdAsync(dto.ProductId.Value);
            if (prod == null || !prod.IsActive) errors.Add("Invalid product");
        }
        
        if (dto.Translations?.Any(t => !string.IsNullOrWhiteSpace(t.Title)) != true)
            errors.Add("At least one translation required");
        
        return (errors.Count == 0, errors);
    }

    public async Task<(bool IsValid, List<string> Errors)> ValidateBlogDataAsync(BlogUpdateDto dto)
    {
        var errors = new List<string>();
        var cat = await _unitOfWork.BlogCategories.GetByIdAsync(dto.CategoryId);
        if (cat == null || cat.IsDeleted) errors.Add("Invalid category");
        
        if (dto.ProductId.HasValue)
        {
            var prod = await _unitOfWork.Products.GetByIdAsync(dto.ProductId.Value);
            if (prod == null || !prod.IsActive) errors.Add("Invalid product");
        }
        
        if (dto.Translations?.Any(t => !string.IsNullOrWhiteSpace(t.Title)) != true)
            errors.Add("At least one translation required");
        
        return (errors.Count == 0, errors);
    }

    public async Task<(bool Success, int? BlogId, string Message)> AutoSaveDraftAsync(BlogUpdateDto dto, string authorId)
    {
        try
        {
            if (dto.Id > 0)
            {
                // Update existing draft
                var result = await UpdateBlogAsync(dto.Id, dto);
                return (result.Success, dto.Id, result.Message);
            }
            else
            {
                // Create new draft
                var createDto = new BlogCreateDto
                {
                    CategoryId = dto.CategoryId,
                    ProductId = dto.ProductId,
                    FeaturedImage = dto.FeaturedImage,
                    IsPublished = false,
                    AllowComments = dto.AllowComments,
                    Translations = dto.Translations
                };
                
                var result = await CreateBlogAsync(createDto, authorId);
                return result;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Auto-save failed for blog {BlogId}", dto.Id);
            return (false, null, "Auto-save failed");
        }
    }

    public async Task<(bool Success, string Message)> ValidateSlugUniquenessAsync(string slug, string cultureCode, int? blogId = null)
    {
        if (string.IsNullOrWhiteSpace(slug))
            return (true, "Slug is empty");
            
        var exists = await SlugExistsAsync(slug, cultureCode, blogId);
        return (!exists, exists ? "This slug is already in use" : "Slug is available");
    }

    public Dictionary<string, object> AnalyzeSEOAsync(string title, string content, string metaDescription, string keywords)
    {
        var result = new Dictionary<string, object>();
        var score = 0;
        var suggestions = new List<string>();

        // Title analysis
        if (!string.IsNullOrWhiteSpace(title))
        {
            var titleLength = title.Length;
            if (titleLength >= 30 && titleLength <= 60)
                score += 20;
            else
                suggestions.Add(titleLength < 30 ? "Title is too short (aim for 30-60 characters)" : "Title is too long (aim for 30-60 characters)");
        }
        else
        {
            suggestions.Add("Title is required");
        }

        // Content analysis
        if (!string.IsNullOrWhiteSpace(content))
        {
            var plainText = Regex.Replace(content, "<.*?>", string.Empty);
            var wordCount = plainText.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            
            result["wordCount"] = wordCount;
            result["readingTime"] = Math.Max(1, (int)Math.Ceiling(wordCount / 200.0));

            if (wordCount >= 300)
                score += 30;
            else
                suggestions.Add($"Content is short ({wordCount} words). Aim for at least 300 words for better SEO.");
        }
        else
        {
            suggestions.Add("Content is required");
            result["wordCount"] = 0;
            result["readingTime"] = 0;
        }

        // Meta description analysis
        if (!string.IsNullOrWhiteSpace(metaDescription))
        {
            var metaLength = metaDescription.Length;
            if (metaLength >= 120 && metaLength <= 160)
                score += 25;
            else
                suggestions.Add(metaLength < 120 ? "Meta description is too short (aim for 120-160 characters)" : "Meta description is too long (aim for 120-160 characters)");
        }
        else
        {
            suggestions.Add("Meta description is recommended for SEO");
        }

        // Keywords analysis
        if (!string.IsNullOrWhiteSpace(keywords))
        {
            var keywordList = keywords.Split(',').Select(k => k.Trim()).Where(k => !string.IsNullOrEmpty(k)).ToList();
            if (keywordList.Count >= 3 && keywordList.Count <= 10)
                score += 25;
            else
                suggestions.Add(keywordList.Count < 3 ? "Add more keywords (aim for 3-10)" : "Too many keywords (aim for 3-10)");
        }
        else
        {
            suggestions.Add("Keywords are recommended for SEO");
        }

        result["score"] = score;
        result["maxScore"] = 100;
        result["percentage"] = score;
        result["suggestions"] = suggestions;
        
        if (score >= 80)
            result["rating"] = "excellent";
        else if (score >= 60)
            result["rating"] = "good";
        else
            result["rating"] = "needs-improvement";

        return result;
    }
}
