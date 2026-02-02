using Kokomija.Entity;
using Kokomija.Models.ViewModels.Admin;

namespace Kokomija.Services;

public interface IBlogService
{
    // CRUD Operations
    Task<Blog?> GetByIdAsync(int id, bool includeDeleted = false);
    Task<Blog?> GetBySlugAsync(string slug, string cultureCode);
    Task<IEnumerable<Blog>> GetAllAsync(bool includeDeleted = false);
    Task<IEnumerable<Blog>> GetPublishedBlogsAsync();
    Task<IEnumerable<Blog>> GetBlogsByCategoryAsync(int categoryId);
    Task<IEnumerable<Blog>> GetBlogsByAuthorAsync(string authorId);
    Task<(bool Success, int? BlogId, string Message)> CreateBlogAsync(BlogCreateDto dto, string authorId);
    Task<(bool Success, string Message)> UpdateBlogAsync(int id, BlogUpdateDto dto);
    Task<(bool Success, string Message)> DeleteBlogAsync(int id, bool hardDelete = false);
    Task<(bool Success, string Message)> TogglePublishAsync(int id);
    
    // Translation Operations
    Task<BlogTranslation?> GetTranslationAsync(int blogId, string cultureCode);
    Task<IEnumerable<BlogTranslation>> GetAllTranslationsAsync(int blogId);
    Task<(bool Success, string Message)> SaveTranslationsAsync(int blogId, IEnumerable<BlogTranslationDto> translations);
    
    // Image Management
    Task<(bool Success, string? Url, string Message)> UpdateFeaturedImageAsync(int blogId, string? newImageUrl);
    Task<List<string>> ExtractImagesFromContentAsync(string htmlContent);
    Task CleanupOrphanedImagesAsync(int blogId, List<string> currentContentImages);
    Task<(bool Success, string Message)> DeleteBlogImagesAsync(int blogId);
    
    // Statistics & Utilities
    Task<int> IncrementViewCountAsync(int blogId);
    Task<Dictionary<string, int>> GetBlogStatisticsAsync();
    Task<IEnumerable<Blog>> GetRecentBlogsAsync(int count = 5);
    Task<IEnumerable<Blog>> GetRelatedBlogsAsync(int blogId, int count = 3);
    Task<bool> SlugExistsAsync(string slug, string cultureCode, int? excludeBlogId = null);
    string GenerateUniqueSlug(string title, string cultureCode);
    
    // Validation
    Task<(bool IsValid, List<string> Errors)> ValidateBlogDataAsync(BlogCreateDto dto);
    Task<(bool IsValid, List<string> Errors)> ValidateBlogDataAsync(BlogUpdateDto dto);
    
    // Auto-save Draft
    Task<(bool Success, int? BlogId, string Message)> AutoSaveDraftAsync(BlogUpdateDto dto, string authorId);
    Task<(bool Success, string Message)> ValidateSlugUniquenessAsync(string slug, string cultureCode, int? blogId = null);
    
    // SEO Analysis
    Dictionary<string, object> AnalyzeSEOAsync(string title, string content, string metaDescription, string keywords);
}