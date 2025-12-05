using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kokomija.Services
{
    public interface IProductImageService
    {
        Task<(bool Success, string? TempFileName, string? TempUrl, string Message)> UploadToTempAsync(IFormFile file);
        Task<(bool Success, string? PermanentUrl, string Message)> MoveTempToPermanentAsync(string tempFileName, int productId);
        Task<bool> DeleteProductImageAsync(string imageUrl);
        Task CancelUploadAsync(params string[] tempFileNames);
        Task CleanupOldTempFilesAsync(int olderThanHours = 24);
    }
}