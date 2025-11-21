using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Kokomija.Services
{
    /// <summary>
    /// Service for handling carousel image uploads, processing, and cleanup
    /// Manages responsive images (desktop, tablet, mobile) with temp folder support
    /// </summary>
    public interface ICarouselImageService
    {
        /// <summary>
        /// Upload image to temp folder, returns temp filename
        /// </summary>
        Task<string> UploadToTempAsync(IFormFile file, string imageType);

        /// <summary>
        /// Move images from temp folder to permanent carousel folder
        /// Returns tuple of (desktopPath, tabletPath, mobilePath)
        /// </summary>
        Task<(string desktop, string tablet, string mobile)> ProcessAndMoveFromTempAsync(
            string? desktopTempFile, string? tabletTempFile, string? mobileTempFile);

        /// <summary>
        /// Delete temp files (called when user cancels or on cleanup)
        /// </summary>
        Task DeleteTempFilesAsync(params string[] tempFileNames);

        /// <summary>
        /// Delete permanent carousel images
        /// </summary>
        Task DeletePermanentImagesAsync(params string[] imagePaths);

        /// <summary>
        /// Clean up old temp files (older than 24 hours)
        /// </summary>
        Task CleanupOldTempFilesAsync();

        /// <summary>
        /// Get image dimensions
        /// </summary>
        Task<(int width, int height)> GetImageDimensionsAsync(string imagePath);
    }

    public class CarouselImageService : ICarouselImageService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<CarouselImageService> _logger;
        private const string CAROUSEL_FOLDER = "img/Carousel";
        private const string TEMP_FOLDER = "img/Carousel/temp";
        private const long MAX_FILE_SIZE = 5 * 1024 * 1024; // 5MB
        private static readonly string[] ALLOWED_EXTENSIONS = { ".jpg", ".jpeg", ".png", ".webp" };

        // Recommended dimensions
        private const int DESKTOP_WIDTH = 1920;
        private const int DESKTOP_HEIGHT = 800;
        private const int TABLET_WIDTH = 1024;
        private const int TABLET_HEIGHT = 600;
        private const int MOBILE_WIDTH = 768;
        private const int MOBILE_HEIGHT = 600;

        public CarouselImageService(IWebHostEnvironment environment, ILogger<CarouselImageService> logger)
        {
            _environment = environment;
            _logger = logger;
        }

        public async Task<string> UploadToTempAsync(IFormFile file, string imageType)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No file provided");
            }

            // Validate file size
            if (file.Length > MAX_FILE_SIZE)
            {
                throw new ArgumentException($"File size exceeds {MAX_FILE_SIZE / 1024 / 1024}MB limit");
            }

            // Validate file extension
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!ALLOWED_EXTENSIONS.Contains(extension))
            {
                throw new ArgumentException($"Invalid file type. Allowed: {string.Join(", ", ALLOWED_EXTENSIONS)}");
            }

            // Generate unique temp filename with imageType prefix
            var tempFileName = $"{imageType}_{Guid.NewGuid()}{extension}";
            var tempFolderPath = Path.Combine(_environment.WebRootPath, TEMP_FOLDER.Replace('/', Path.DirectorySeparatorChar));

            // Ensure temp directory exists
            if (!Directory.Exists(tempFolderPath))
            {
                Directory.CreateDirectory(tempFolderPath);
            }

            var tempFilePath = Path.Combine(tempFolderPath, tempFileName);

            // Save to temp folder
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            _logger.LogInformation("Image uploaded to temp: {FileName} ({Type})", tempFileName, imageType);

            return tempFileName;
        }

        public async Task<(string desktop, string tablet, string mobile)> ProcessAndMoveFromTempAsync(
            string? desktopTempFile, string? tabletTempFile, string? mobileTempFile)
        {
            var tempFolderPath = Path.Combine(_environment.WebRootPath, TEMP_FOLDER.Replace('/', Path.DirectorySeparatorChar));
            var carouselFolderPath = Path.Combine(_environment.WebRootPath, CAROUSEL_FOLDER.Replace('/', Path.DirectorySeparatorChar));

            // Ensure carousel directory exists
            if (!Directory.Exists(carouselFolderPath))
            {
                Directory.CreateDirectory(carouselFolderPath);
            }

            string desktopPath = string.Empty;
            string tabletPath = string.Empty;
            string mobilePath = string.Empty;

            try
            {
                // Process desktop image (required)
                if (!string.IsNullOrEmpty(desktopTempFile))
                {
                    var desktopTempPath = Path.Combine(tempFolderPath, desktopTempFile);
                    if (File.Exists(desktopTempPath))
                    {
                        var desktopFileName = $"desktop_{Guid.NewGuid()}{Path.GetExtension(desktopTempFile)}";
                        var desktopPermanentPath = Path.Combine(carouselFolderPath, desktopFileName);

                        // Resize and optimize for desktop
                        await ResizeAndSaveImageAsync(desktopTempPath, desktopPermanentPath, DESKTOP_WIDTH, DESKTOP_HEIGHT);

                        desktopPath = $"/{CAROUSEL_FOLDER}/{desktopFileName}";
                        _logger.LogInformation("Desktop image processed: {Path}", desktopPath);
                    }
                    else
                    {
                        throw new FileNotFoundException($"Desktop temp file not found: {desktopTempFile}");
                    }
                }
                else
                {
                    throw new ArgumentException("Desktop image is required");
                }

                // Process tablet image (optional - will use desktop if not provided)
                if (!string.IsNullOrEmpty(tabletTempFile))
                {
                    var tabletTempPath = Path.Combine(tempFolderPath, tabletTempFile);
                    if (File.Exists(tabletTempPath))
                    {
                        var tabletFileName = $"tablet_{Guid.NewGuid()}{Path.GetExtension(tabletTempFile)}";
                        var tabletPermanentPath = Path.Combine(carouselFolderPath, tabletFileName);

                        await ResizeAndSaveImageAsync(tabletTempPath, tabletPermanentPath, TABLET_WIDTH, TABLET_HEIGHT);

                        tabletPath = $"/{CAROUSEL_FOLDER}/{tabletFileName}";
                        _logger.LogInformation("Tablet image processed: {Path}", tabletPath);
                    }
                }

                // Process mobile image (optional - will use tablet if not provided)
                if (!string.IsNullOrEmpty(mobileTempFile))
                {
                    var mobileTempPath = Path.Combine(tempFolderPath, mobileTempFile);
                    if (File.Exists(mobileTempPath))
                    {
                        var mobileFileName = $"mobile_{Guid.NewGuid()}{Path.GetExtension(mobileTempFile)}";
                        var mobilePermanentPath = Path.Combine(carouselFolderPath, mobileFileName);

                        await ResizeAndSaveImageAsync(mobileTempPath, mobilePermanentPath, MOBILE_WIDTH, MOBILE_HEIGHT);

                        mobilePath = $"/{CAROUSEL_FOLDER}/{mobileFileName}";
                        _logger.LogInformation("Mobile image processed: {Path}", mobilePath);
                    }
                }

                // Clean up temp files after successful processing
                var filesToDelete = new[] { desktopTempFile, tabletTempFile, mobileTempFile }
                    .Where(f => !string.IsNullOrEmpty(f))
                    .Select(f => f!)
                    .ToArray();
                if (filesToDelete.Length > 0)
                {
                    await DeleteTempFilesAsync(filesToDelete);
                }

                return (desktopPath, tabletPath, mobilePath);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing carousel images from temp");
                
                // Clean up any permanent files created during failed processing
                if (!string.IsNullOrEmpty(desktopPath)) await DeletePermanentImagesAsync(desktopPath);
                if (!string.IsNullOrEmpty(tabletPath)) await DeletePermanentImagesAsync(tabletPath);
                if (!string.IsNullOrEmpty(mobilePath)) await DeletePermanentImagesAsync(mobilePath);
                
                throw;
            }
        }

        public async Task DeleteTempFilesAsync(params string[] tempFileNames)
        {
            var tempFolderPath = Path.Combine(_environment.WebRootPath, TEMP_FOLDER.Replace('/', Path.DirectorySeparatorChar));

            foreach (var fileName in tempFileNames)
            {
                if (string.IsNullOrEmpty(fileName)) continue;

                try
                {
                    var filePath = Path.Combine(tempFolderPath, fileName);
                    if (File.Exists(filePath))
                    {
                        await Task.Run(() => File.Delete(filePath));
                        _logger.LogInformation("Deleted temp file: {FileName}", fileName);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error deleting temp file: {FileName}", fileName);
                }
            }
        }

        public async Task DeletePermanentImagesAsync(params string[] imagePaths)
        {
            foreach (var imagePath in imagePaths)
            {
                if (string.IsNullOrEmpty(imagePath)) continue;

                try
                {
                    var fullPath = Path.Combine(_environment.WebRootPath, imagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (File.Exists(fullPath))
                    {
                        await Task.Run(() => File.Delete(fullPath));
                        _logger.LogInformation("Deleted permanent image: {Path}", imagePath);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error deleting permanent image: {Path}", imagePath);
                }
            }
        }

        public async Task CleanupOldTempFilesAsync()
        {
            var tempFolderPath = Path.Combine(_environment.WebRootPath, TEMP_FOLDER.Replace('/', Path.DirectorySeparatorChar));

            if (!Directory.Exists(tempFolderPath))
            {
                return;
            }

            try
            {
                var cutoffTime = DateTime.UtcNow.AddHours(-24);
                var files = Directory.GetFiles(tempFolderPath);
                var deletedCount = 0;

                foreach (var filePath in files)
                {
                    var fileInfo = new FileInfo(filePath);
                    if (fileInfo.CreationTimeUtc < cutoffTime)
                    {
                        await Task.Run(() => File.Delete(filePath));
                        deletedCount++;
                    }
                }

                if (deletedCount > 0)
                {
                    _logger.LogInformation("Cleaned up {Count} old temp files", deletedCount);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cleaning up old temp files");
            }
        }

        public async Task<(int width, int height)> GetImageDimensionsAsync(string imagePath)
        {
            var fullPath = Path.Combine(_environment.WebRootPath, imagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException($"Image not found: {imagePath}");
            }

            using var image = await Image.LoadAsync(fullPath);
            return (image.Width, image.Height);
        }

        private async Task ResizeAndSaveImageAsync(string sourcePath, string destinationPath, int maxWidth, int maxHeight)
        {
            using var image = await Image.LoadAsync(sourcePath);

            // Calculate aspect ratio
            var aspectRatio = (double)image.Width / image.Height;
            var targetAspectRatio = (double)maxWidth / maxHeight;

            int targetWidth = maxWidth;
            int targetHeight = maxHeight;

            // Adjust dimensions to maintain aspect ratio
            if (aspectRatio > targetAspectRatio)
            {
                // Image is wider - fit to width
                targetHeight = (int)(maxWidth / aspectRatio);
            }
            else if (aspectRatio < targetAspectRatio)
            {
                // Image is taller - fit to height
                targetWidth = (int)(maxHeight * aspectRatio);
            }

            // Resize image
            image.Mutate(x => x.Resize(new ResizeOptions
            {
                Size = new Size(targetWidth, targetHeight),
                Mode = ResizeMode.Max,
                Sampler = KnownResamplers.Lanczos3
            }));

            // Save with optimization
            await image.SaveAsJpegAsync(destinationPath);
        }
    }
}
