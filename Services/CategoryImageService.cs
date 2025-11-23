using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace Kokomija.Services
{
    public interface ICategoryImageService
    {
        Task<string> UploadCategoryImageAsync(IFormFile file, string tempFolder);
        Task<string> MoveTempImageToPermanentAsync(string tempFileName, string categorySlug);
        Task DeleteCategoryImageAsync(string imageUrl);
        Task CleanupTempFilesAsync(List<string> tempFileNames);
        Task<bool> ValidateImageAsync(IFormFile file);
    }

    public class CategoryImageService : ICategoryImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<CategoryImageService> _logger;
        private const long MaxFileSize = 5 * 1024 * 1024; // 5MB
        private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
        private const int MaxWidth = 1200;
        private const int MaxHeight = 800;

        public CategoryImageService(IWebHostEnvironment environment, ILogger<CategoryImageService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public Task<bool> ValidateImageAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return Task.FromResult(false);
            }

            if (file.Length > MaxFileSize)
            {
                _logger.LogWarning("File size {Size} exceeds maximum {MaxSize}", file.Length, MaxFileSize);
                return Task.FromResult(false);
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
            {
                _logger.LogWarning("File extension {Extension} not allowed", extension);
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }

        public async Task<string> UploadCategoryImageAsync(IFormFile file, string tempFolder)
        {
            if (!await ValidateImageAsync(file))
            {
                throw new InvalidOperationException("Invalid image file");
            }

            var tempPath = Path.Combine(_environment.WebRootPath, tempFolder);
            if (!Directory.Exists(tempPath))
            {
                Directory.CreateDirectory(tempPath);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var fullPath = Path.Combine(tempPath, fileName);

            try
            {
                using var image = await Image.LoadAsync(file.OpenReadStream());
                
                // Resize if needed
                if (image.Width > MaxWidth || image.Height > MaxHeight)
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(MaxWidth, MaxHeight),
                        Mode = ResizeMode.Max
                    }));
                }

                // Save as JPEG with quality 85
                var encoder = new JpegEncoder { Quality = 85 };
                await image.SaveAsync(fullPath, encoder);

                _logger.LogInformation("Category image uploaded to temp: {FileName}", fileName);
                return fileName;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading category image");
                throw;
            }
        }

        public async Task<string> MoveTempImageToPermanentAsync(string tempFileName, string categorySlug)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var tempPath = Path.Combine(_environment.WebRootPath, "img", "temp", tempFileName);
                    if (!File.Exists(tempPath))
                    {
                        _logger.LogWarning("Temp file not found: {TempPath}", tempPath);
                        return string.Empty;
                    }

                    var categoriesFolder = Path.Combine(_environment.WebRootPath, "img", "categories");
                    if (!Directory.Exists(categoriesFolder))
                    {
                        Directory.CreateDirectory(categoriesFolder);
                    }

                    var extension = Path.GetExtension(tempFileName);
                    var permanentFileName = $"{categorySlug}{extension}";
                    var permanentPath = Path.Combine(categoriesFolder, permanentFileName);

                    // Delete existing file if it exists
                    if (File.Exists(permanentPath))
                    {
                        File.Delete(permanentPath);
                    }

                    File.Move(tempPath, permanentPath);

                    _logger.LogInformation("Moved temp image to permanent: {PermanentFileName}", permanentFileName);
                    return $"/img/categories/{permanentFileName}";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error moving temp image to permanent");
                    throw;
                }
            });
        }

        public async Task DeleteCategoryImageAsync(string imageUrl)
        {
            try
            {
                if (string.IsNullOrEmpty(imageUrl))
                {
                    return;
                }

                var relativePath = imageUrl.TrimStart('/');
                var fullPath = Path.Combine(_environment.WebRootPath, relativePath);

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    _logger.LogInformation("Deleted category image: {ImageUrl}", imageUrl);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting category image: {ImageUrl}", imageUrl);
            }

            await Task.CompletedTask;
        }

        public async Task CleanupTempFilesAsync(List<string> tempFileNames)
        {
            foreach (var tempFileName in tempFileNames)
            {
                try
                {
                    var tempPath = Path.Combine(_environment.WebRootPath, "img", "temp", tempFileName);
                    if (File.Exists(tempPath))
                    {
                        File.Delete(tempPath);
                        _logger.LogInformation("Cleaned up temp file: {TempFileName}", tempFileName);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error cleaning up temp file: {TempFileName}", tempFileName);
                }
            }

            await Task.CompletedTask;
        }
    }
}
