namespace Kokomija.Services;

/// <summary>
/// Service to track CKEditor images uploaded during blog creation/editing
/// </summary>
public interface ICKEditorImageTrackingService
{
    /// <summary>
    /// Track a CKEditor image upload for a session
    /// </summary>
    void TrackImage(string sessionId, string imageUrl);

    /// <summary>
    /// Get all tracked images for a session
    /// </summary>
    List<string> GetTrackedImages(string sessionId);

    /// <summary>
    /// Commit images - mark them as permanent (keep them)
    /// </summary>
    void CommitImages(string sessionId);

    /// <summary>
    /// Rollback images - delete all tracked images for the session
    /// </summary>
    Task RollbackImagesAsync(string sessionId);

    /// <summary>
    /// Clear tracking for a session
    /// </summary>
    void ClearSession(string sessionId);

    /// <summary>
    /// Extract image URLs from HTML content
    /// </summary>
    List<string> ExtractImageUrls(string htmlContent);

    /// <summary>
    /// Clean up orphaned images not referenced in any blog content
    /// </summary>
    Task CleanupOrphanedImagesAsync();
}
