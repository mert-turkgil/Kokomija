namespace Kokomija.Services;

public class BlogImageService : IBlogImageService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<BlogImageService> _logger;
    private readonly string _tempFolder;
    private readonly string _blogFolder;
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
    private const long MaxFileSize = 10 * 1024 * 1024; // 10MB

    public BlogImageService(IWebHostEnvironment environment, ILogger<BlogImageService> logger)
    {
        _environment = environment;
        _logger = logger;
        _tempFolder = Path.Combine(_environment.WebRootPath, "img", "Blog", "temp");
        _blogFolder = Path.Combine(_environment.WebRootPath, "img", "Blog");

        // Ensure directories exist
        Directory.CreateDirectory(_tempFolder);
        Directory.CreateDirectory(_blogFolder);
    }

    public async Task<(bool Success, string? TempFileName, string? TempUrl, string? Message)> UploadToTempAsync(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return (false, null, null, "No file uploaded");
            }

            // Validate file size
            if (file.Length > MaxFileSize)
            {
                return (false, null, null, $"File size exceeds maximum allowed size of {MaxFileSize / 1024 / 1024}MB");
            }

            // Validate file extension
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
            {
                return (false, null, null, $"Invalid file type. Allowed types: {string.Join(", ", _allowedExtensions)}");
            }

            // Validate MIME type
            var allowedMimeTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/webp" };
            if (!allowedMimeTypes.Contains(file.ContentType.ToLowerInvariant()))
            {
                return (false, null, null, "Invalid image file");
            }

            // Generate unique filename
            var uniqueFileName = $"{Guid.NewGuid()}{extension}";
            var tempFilePath = Path.Combine(_tempFolder, uniqueFileName);

            // Save file to temp folder
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var tempUrl = $"/img/Blog/temp/{uniqueFileName}";
            _logger.LogInformation("Blog image uploaded to temp: {FileName}", uniqueFileName);

            return (true, uniqueFileName, tempUrl, "File uploaded successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading blog image to temp");
            return (false, null, null, "Error uploading file");
        }
    }

    public async Task<(bool Success, string? PermanentUrl, string? Message)> UploadCKEditorImageAsync(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return (false, null, "No file uploaded");
            }

            // Validate file size
            if (file.Length > MaxFileSize)
            {
                return (false, null, $"File size exceeds maximum allowed size of {MaxFileSize / 1024 / 1024}MB");
            }

            // Validate file extension
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(extension))
            {
                return (false, null, $"Invalid file type. Allowed types: {string.Join(", ", _allowedExtensions)}");
            }

            // Validate MIME type
            var allowedMimeTypes = new[] { "image/jpeg", "image/png", "image/gif", "image/webp" };
            if (!allowedMimeTypes.Contains(file.ContentType.ToLowerInvariant()))
            {
                return (false, null, "Invalid image file");
            }

            // Generate permanent filename with timestamp for CKEditor images
            var permanentFileName = $"ckeditor_{DateTime.UtcNow:yyyyMMdd_HHmmss}_{Guid.NewGuid()}{extension}";
            var permanentFilePath = Path.Combine(_blogFolder, permanentFileName);

            // Save file directly to permanent folder
            using (var stream = new FileStream(permanentFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var permanentUrl = $"/img/Blog/{permanentFileName}";
            _logger.LogInformation("CKEditor image uploaded to permanent: {FileName}", permanentFileName);

            return (true, permanentUrl, "File uploaded successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading CKEditor image");
            return (false, null, "Error uploading file");
        }
    }

    public async Task<(bool Success, string? PermanentUrl, string? Message)> ProcessAndMoveFromTempAsync(string tempFileName)
    {
        try
        {
            if (string.IsNullOrEmpty(tempFileName))
            {
                return (false, null, "No temp file specified");
            }

            var tempFilePath = Path.Combine(_tempFolder, tempFileName);
            if (!File.Exists(tempFilePath))
            {
                return (false, null, "Temp file not found");
            }

            // Generate permanent filename with timestamp
            var extension = Path.GetExtension(tempFileName);
            var permanentFileName = $"{DateTime.UtcNow:yyyyMMdd_HHmmss}_{Guid.NewGuid()}{extension}";
            var permanentFilePath = Path.Combine(_blogFolder, permanentFileName);

            // Move file from temp to permanent folder
            await Task.Run(() => File.Move(tempFilePath, permanentFilePath, overwrite: false));

            var permanentUrl = $"/img/Blog/{permanentFileName}";
            _logger.LogInformation("Blog image moved from temp to permanent: {FileName}", permanentFileName);

            return (true, permanentUrl, "File processed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error moving blog image from temp to permanent: {TempFileName}", tempFileName);
            return (false, null, "Error processing file");
        }
    }

    public async Task<bool> CancelUploadAsync(string tempFileName)
    {
        try
        {
            if (string.IsNullOrEmpty(tempFileName))
            {
                return false;
            }

            var tempFilePath = Path.Combine(_tempFolder, tempFileName);
            if (File.Exists(tempFilePath))
            {
                await Task.Run(() => File.Delete(tempFilePath));
                _logger.LogInformation("Temp blog image deleted: {FileName}", tempFileName);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting temp blog image: {TempFileName}", tempFileName);
            return false;
        }
    }

    public async Task<bool> DeleteImageAsync(string imageUrl)
    {
        try
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return false;
            }

            // Extract filename from URL (e.g., "/img/Blog/image.jpg" -> "image.jpg")
            var fileName = Path.GetFileName(imageUrl);
            if (string.IsNullOrEmpty(fileName))
            {
                return false;
            }

            var filePath = Path.Combine(_blogFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
                _logger.LogInformation("Blog image deleted: {FileName}", fileName);
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting blog image: {ImageUrl}", imageUrl);
            return false;
        }
    }

    public async Task ClearOldTempFilesAsync(int olderThanHours = 24)
    {
        try
        {
            var cutoffTime = DateTime.UtcNow.AddHours(-olderThanHours);
            var tempFiles = Directory.GetFiles(_tempFolder);

            foreach (var filePath in tempFiles)
            {
                var fileInfo = new FileInfo(filePath);
                if (fileInfo.CreationTimeUtc < cutoffTime)
                {
                    await Task.Run(() => File.Delete(filePath));
                    _logger.LogInformation("Old temp blog image deleted: {FileName}", fileInfo.Name);
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error clearing old temp blog files");
        }
    }
}
