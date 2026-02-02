using System.Text.RegularExpressions;

namespace Kokomija.Services;

public class BlogImageService : IBlogImageService
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<BlogImageService> _logger;
    private readonly string _tempFolder;
    private readonly string _permanentFolder;
    private readonly long _maxFileSize = 10 * 1024 * 1024;
    private readonly string[] _allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

    public BlogImageService(IWebHostEnvironment environment, ILogger<BlogImageService> logger)
    {
        _environment = environment;
        _logger = logger;
        _tempFolder = Path.Combine(_environment.WebRootPath, "img", "Blog", "Temp");
        _permanentFolder = Path.Combine(_environment.WebRootPath, "img", "Blog");
        Directory.CreateDirectory(_tempFolder);
        Directory.CreateDirectory(_permanentFolder);
    }

    public async Task<(bool Success, string? TempFileName, string? TempUrl, string? Message)> UploadToTempAsync(IFormFile file)
    {
        var validation = ValidateFile(file);
        if (!validation.IsValid) return (false, null, null, validation.Message);

        var fileName = $"blog_{DateTime.UtcNow:yyyyMMddHHmmss}_{Guid.NewGuid():N}"[..40] + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_tempFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        return (true, fileName, $"/img/Blog/Temp/{fileName}", "Upload successful");
    }

    public async Task<(bool Success, string? PermanentUrl, string? Message)> UploadCKEditorImageAsync(IFormFile file)
    {
        var validation = ValidateFile(file);
        if (!validation.IsValid) return (false, null, validation.Message);

        var fileName = $"blog_{DateTime.UtcNow:yyyyMMddHHmmss}_{Guid.NewGuid():N}"[..40] + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(_permanentFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
            await file.CopyToAsync(stream);

        return (true, $"/img/Blog/{fileName}", "Upload successful");
    }

    public async Task<(bool Success, string? PermanentUrl, string? Message)> ProcessAndMoveFromTempAsync(string tempFileName)
    {
        if (string.IsNullOrEmpty(tempFileName)) return (false, null, "Temp filename required");

        var tempPath = Path.Combine(_tempFolder, tempFileName);
        if (!File.Exists(tempPath)) return (false, null, "Temp file not found");

        var permanentFileName = $"{Guid.NewGuid():N}{Path.GetExtension(tempFileName)}";
        var permanentPath = Path.Combine(_permanentFolder, permanentFileName);

        await Task.Run(() => File.Move(tempPath, permanentPath));
        return (true, $"/img/Blog/{permanentFileName}", "File processed");
    }

    public async Task<bool> CancelUploadAsync(string tempFileName)
    {
        if (string.IsNullOrEmpty(tempFileName)) return false;
        
        var filePath = Path.Combine(_tempFolder, tempFileName);
        if (File.Exists(filePath))
        {
            await Task.Run(() => File.Delete(filePath));
            return true;
        }
        return false;
    }

    public async Task<bool> DeleteImageAsync(string imageUrl)
    {
        if (string.IsNullOrEmpty(imageUrl)) return false;

        var fileName = Path.GetFileName(imageUrl);
        var filePath = imageUrl.Contains("/Temp/", StringComparison.OrdinalIgnoreCase) ?
            Path.Combine(_tempFolder, fileName) :
            Path.Combine(_permanentFolder, fileName);

        if (File.Exists(filePath))
        {
            await Task.Run(() => File.Delete(filePath));
            return true;
        }
        return false;
    }

    public async Task ClearOldTempFilesAsync(int olderThanHours = 24)
    {
        var cutoff = DateTime.UtcNow.AddHours(-olderThanHours);
        var files = Directory.GetFiles(_tempFolder);
        
        foreach (var file in files.Where(f => new FileInfo(f).CreationTimeUtc < cutoff))
            await Task.Run(() => File.Delete(file));
    }

    private (bool IsValid, string? Message) ValidateFile(IFormFile file)
    {
        if (file == null || file.Length == 0) return (false, "No file provided");
        if (file.Length > _maxFileSize) return (false, $"File exceeds {_maxFileSize / 1024 / 1024}MB limit");
        
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!_allowedExtensions.Contains(ext)) 
            return (false, $"Invalid file type. Allowed: {string.Join(", ", _allowedExtensions)}");
        
        return (true, null);
    }
}