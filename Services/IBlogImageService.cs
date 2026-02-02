using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kokomija.Services
{
public interface IBlogImageService
{
    /// <summary>
    /// Upload blog image to temp folder
    /// Supported formats: jpg, jpeg, png, gif, webp
    /// </summary>
    Task<(bool Success, string? TempFileName, string? TempUrl, string? Message)> UploadToTempAsync(IFormFile file);

    /// <summary>
    /// Upload CKEditor image directly to permanent folder (for inline images/GIFs)
    /// </summary>
    Task<(bool Success, string? PermanentUrl, string? Message)> UploadCKEditorImageAsync(IFormFile file);

    /// <summary>
    /// Move image from temp to permanent Blog folder
    /// </summary>
    Task<(bool Success, string? PermanentUrl, string? Message)> ProcessAndMoveFromTempAsync(string tempFileName);

    /// <summary>
    /// Cancel upload and delete temp file
    /// </summary>
    Task<bool> CancelUploadAsync(string tempFileName);

    /// <summary>
    /// Delete blog image from permanent folder
    /// </summary>
    Task<bool> DeleteImageAsync(string imageUrl);

    /// <summary>
    /// Clear all temp files older than specified hours
    /// </summary>
    Task ClearOldTempFilesAsync(int olderThanHours = 24);
}
}