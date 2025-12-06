using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using Kokomija.Data.Abstract;
using Microsoft.Extensions.Caching.Memory;

namespace Kokomija.Services;

/// <summary>
/// Tracks CKEditor images uploaded during blog creation/editing
/// Allows cleanup of unused images if blog creation is cancelled
/// Uses IMemoryCache to persist across requests
/// </summary>
public class CKEditorImageTrackingService : ICKEditorImageTrackingService
{
    private readonly IMemoryCache _cache;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CKEditorImageTrackingService> _logger;
    private const string CacheKeyPrefix = "CKEditorSession_";
    
    public CKEditorImageTrackingService(
        IMemoryCache cache,
        IServiceProvider serviceProvider,
        ILogger<CKEditorImageTrackingService> logger)
    {
        _cache = cache;
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public void TrackImage(string sessionId, string imageUrl)
    {
        if (string.IsNullOrEmpty(sessionId) || string.IsNullOrEmpty(imageUrl))
            return;

        var cacheKey = CacheKeyPrefix + sessionId;
        var images = _cache.GetOrCreate(cacheKey, entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24);
            return new HashSet<string>();
        });

        if (images != null)
        {
            images.Add(imageUrl);
            _cache.Set(cacheKey, images, TimeSpan.FromHours(24));
            _logger.LogInformation("Tracked CKEditor image for session {SessionId}: {ImageUrl}", sessionId, imageUrl);
        }
    }

    public List<string> GetTrackedImages(string sessionId)
    {
        if (string.IsNullOrEmpty(sessionId))
            return new List<string>();

        var cacheKey = CacheKeyPrefix + sessionId;
        if (_cache.TryGetValue<HashSet<string>>(cacheKey, out var images) && images != null)
        {
            return images.ToList();
        }

        return new List<string>();
    }

    public void CommitImages(string sessionId)
    {
        if (string.IsNullOrEmpty(sessionId))
            return;

        var cacheKey = CacheKeyPrefix + sessionId;
        if (_cache.TryGetValue<HashSet<string>>(cacheKey, out var images) && images != null)
        {
            _cache.Remove(cacheKey);
            _logger.LogInformation("Committed {Count} CKEditor images for session {SessionId}", images.Count, sessionId);
        }
    }

    public async Task RollbackImagesAsync(string sessionId)
    {
        if (string.IsNullOrEmpty(sessionId))
            return;

        var cacheKey = CacheKeyPrefix + sessionId;
        if (_cache.TryGetValue<HashSet<string>>(cacheKey, out var images) && images != null)
        {
            _logger.LogInformation("Rolling back {Count} CKEditor images for session {SessionId}", images.Count, sessionId);
            
            // Create a scope to get the scoped service
            using var scope = _serviceProvider.CreateScope();
            var blogImageService = scope.ServiceProvider.GetRequiredService<IBlogImageService>();
            
            foreach (var imageUrl in images)
            {
                try
                {
                    await blogImageService.DeleteImageAsync(imageUrl);
                    _logger.LogInformation("Deleted unused CKEditor image: {ImageUrl}", imageUrl);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error deleting CKEditor image during rollback: {ImageUrl}", imageUrl);
                }
            }
            
            _cache.Remove(cacheKey);
        }
    }

    public void ClearSession(string sessionId)
    {
        if (string.IsNullOrEmpty(sessionId))
            return;

        var cacheKey = CacheKeyPrefix + sessionId;
        _cache.Remove(cacheKey);
        _logger.LogDebug("Cleared CKEditor tracking for session {SessionId}", sessionId);
    }

    public List<string> ExtractImageUrls(string htmlContent)
    {
        if (string.IsNullOrEmpty(htmlContent))
            return new List<string>();

        var imageUrls = new HashSet<string>();
        
        // Match img tags with src attributes
        var imgRegex = new Regex(@"<img[^>]+src=[""']([^""']+)[""']", RegexOptions.IgnoreCase);
        var matches = imgRegex.Matches(htmlContent);
        
        foreach (Match match in matches)
        {
            if (match.Groups.Count > 1)
            {
                var src = match.Groups[1].Value;
                // Only track our blog images
                if (src.Contains("/img/Blog/") && !src.Contains("/temp/"))
                {
                    imageUrls.Add(src);
                }
            }
        }

        return imageUrls.ToList();
    }

    public async Task CleanupOrphanedImagesAsync()
    {
        try
        {
            _logger.LogInformation("Starting cleanup of orphaned CKEditor images");

            // Create a scope to get the scoped services
            using var scope = _serviceProvider.CreateScope();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            // Get all blog posts with translations
            var blogs = await unitOfWork.Blogs.GetAllAsync();
            var allTranslations = await unitOfWork.Repository<Entity.BlogTranslation>().GetAllAsync();

            // Extract all referenced images from blog content
            var referencedImages = new HashSet<string>();
            
            foreach (var translation in allTranslations)
            {
                var urls = ExtractImageUrls(translation.Content);
                foreach (var url in urls)
                {
                    referencedImages.Add(url);
                }
            }

            // Add featured images
            foreach (var blog in blogs)
            {
                if (!string.IsNullOrEmpty(blog.FeaturedImage))
                {
                    referencedImages.Add(blog.FeaturedImage);
                }
            }

            _logger.LogInformation("Found {Count} referenced images in database", referencedImages.Count);

            // TODO: Scan file system for orphaned images and delete them
            // This would require additional file system scanning logic
            
            _logger.LogInformation("Cleanup completed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during orphaned image cleanup");
        }
    }
}
