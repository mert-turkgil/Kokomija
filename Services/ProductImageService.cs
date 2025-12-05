namespace Kokomija.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ProductImageService> _logger;
        private const int MaxFileSizeBytes = 5 * 1024 * 1024; // 5MB
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };

        public ProductImageService(IWebHostEnvironment environment, ILogger<ProductImageService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<(bool Success, string? TempFileName, string? TempUrl, string Message)> UploadToTempAsync(IFormFile file)
        {
            try
            {
                // Validate file
                if (file == null || file.Length == 0)
                {
                    return (false, null, null, "No file uploaded");
                }

                if (file.Length > MaxFileSizeBytes)
                {
                    return (false, null, null, $"File size exceeds {MaxFileSizeBytes / 1024 / 1024}MB limit");
                }

                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!AllowedExtensions.Contains(extension))
                {
                    return (false, null, null, $"Invalid file type. Allowed: {string.Join(", ", AllowedExtensions)}");
                }

                // Create temp directory if it doesn't exist
                var tempDir = Path.Combine(_environment.WebRootPath, "img", "Products", "temp");
                Directory.CreateDirectory(tempDir);

                // Generate unique filename
                var tempFileName = $"{Guid.NewGuid()}{extension}";
                var tempFilePath = Path.Combine(tempDir, tempFileName);

                // Save file
                using (var stream = new FileStream(tempFilePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var tempUrl = $"/img/Products/temp/{tempFileName}";
                _logger.LogInformation("Product image uploaded to temp: {TempFileName}", tempFileName);

                return (true, tempFileName, tempUrl, "Image uploaded successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading product image to temp");
                return (false, null, null, $"Error uploading image: {ex.Message}");
            }
        }

        public async Task<(bool Success, string? PermanentUrl, string Message)> MoveTempToPermanentAsync(string tempFileName, int productId)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var tempFilePath = Path.Combine(_environment.WebRootPath, "img", "Products", "temp", tempFileName);
                    
                    if (!File.Exists(tempFilePath))
                    {
                        return (false, string.Empty, "Temp file not found");
                    }

                    // Create permanent directory
                    var permanentDir = Path.Combine(_environment.WebRootPath, "img", "Products", productId.ToString());
                    Directory.CreateDirectory(permanentDir);

                    // Generate permanent filename (keep original extension)
                    var extension = Path.GetExtension(tempFileName);
                    var permanentFileName = $"{Guid.NewGuid()}{extension}";
                    var permanentFilePath = Path.Combine(permanentDir, permanentFileName);

                    // Move file
                    File.Move(tempFilePath, permanentFilePath);

                    var permanentUrl = $"/img/Products/{productId}/{permanentFileName}";
                    _logger.LogInformation("Moved product image from temp to permanent: {PermanentUrl}", permanentUrl);

                    return (true, permanentUrl, "Image moved successfully");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error moving product image to permanent location");
                    return (false, string.Empty, $"Error moving image: {ex.Message}");
                }
            });
        }

        public async Task<bool> DeleteProductImageAsync(string imageUrl)
        {
            return await Task.Run(() =>
            {
                try
                {
                    if (string.IsNullOrEmpty(imageUrl))
                        return false;

                    var filePath = Path.Combine(_environment.WebRootPath, imageUrl.TrimStart('/'));
                    
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        _logger.LogInformation("Deleted product image: {ImageUrl}", imageUrl);
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error deleting product image: {ImageUrl}", imageUrl);
                    return false;
                }
            });
        }

        public async Task CancelUploadAsync(params string[] tempFileNames)
        {
            await Task.Run(() =>
            {
                foreach (var tempFileName in tempFileNames)
                {
                    try
                    {
                        var tempFilePath = Path.Combine(_environment.WebRootPath, "img", "Products", "temp", tempFileName);
                        
                        if (File.Exists(tempFilePath))
                        {
                            File.Delete(tempFilePath);
                            _logger.LogInformation("Deleted temp product image: {TempFileName}", tempFileName);
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error deleting temp product image: {TempFileName}", tempFileName);
                    }
                }
            });
        }

        public async Task CleanupOldTempFilesAsync(int olderThanHours = 24)
        {
            await Task.Run(() =>
            {
                try
                {
                    var tempDir = Path.Combine(_environment.WebRootPath, "img", "Products", "temp");
                    
                    if (!Directory.Exists(tempDir))
                        return;

                    var cutoffTime = DateTime.Now.AddHours(-olderThanHours);
                    var files = Directory.GetFiles(tempDir);
                    var deletedCount = 0;

                    foreach (var file in files)
                    {
                        var fileInfo = new FileInfo(file);
                        if (fileInfo.CreationTime < cutoffTime)
                        {
                            File.Delete(file);
                            deletedCount++;
                        }
                    }

                    if (deletedCount > 0)
                    {
                        _logger.LogInformation("Cleaned up {Count} old temp product images", deletedCount);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error cleaning up old temp product images");
                }
            });
        }
    }
}
