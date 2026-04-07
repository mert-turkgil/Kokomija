using Kokomija.Data;
using Kokomija.Entity;
using Kokomija.Services;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.BackgroundServices;

/// <summary>
/// Background service that runs monthly to clean up:
/// 1. Return request images from resolved returns (Completed, Rejected, Cancelled)
/// 2. Orphaned return request images not linked to any active return 
/// 3. Orphaned files in general /img/temp/ folder
/// 4. Sends a cleanup report via email
/// </summary>
public class ReturnRequestCleanupWorker : BackgroundService
{
    private readonly ILogger<ReturnRequestCleanupWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public ReturnRequestCleanupWorker(
        ILogger<ReturnRequestCleanupWorker> logger,
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Return Request Cleanup Worker starting — runs monthly");

        // Initial delay (15 minutes after startup)
        await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await PerformCleanupAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during return request cleanup");
            }

            // Run monthly (30 days)
            _logger.LogInformation("Next return request cleanup in 30 days");
            await Task.Delay(TimeSpan.FromDays(30), stoppingToken);
        }
    }

    private async Task PerformCleanupAsync()
    {
        _logger.LogInformation("Starting return request image cleanup at {Time}", DateTime.UtcNow);

        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

        var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        var returnImagesPath = Path.Combine(wwwrootPath, "img", "ReturnRequests");
        var generalTempPath = Path.Combine(wwwrootPath, "img", "temp");

        int resolvedImagesDeleted = 0;
        int orphanedFilesDeleted = 0;
        int generalTempFilesDeleted = 0;
        long totalBytesFreed = 0;
        var errors = new List<string>();

        // === 1. Clean images from resolved returns (Completed, Rejected, Cancelled) ===
        try
        {
            var resolvedStatuses = new[]
            {
                ReturnRequestStatus.Completed,
                ReturnRequestStatus.Rejected,
                ReturnRequestStatus.Cancelled
            };

            var resolvedReturnImages = await dbContext.ReturnRequestImages
                .Include(ri => ri.ReturnRequest)
                .Where(ri => resolvedStatuses.Contains(ri.ReturnRequest.Status))
                .ToListAsync();

            foreach (var image in resolvedReturnImages)
            {
                try
                {
                    var filePath = Path.Combine(wwwrootPath, image.ImageUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                    if (File.Exists(filePath))
                    {
                        var fileInfo = new FileInfo(filePath);
                        totalBytesFreed += fileInfo.Length;
                        File.Delete(filePath);
                        resolvedImagesDeleted++;
                        _logger.LogDebug("Deleted resolved return image: {Path}", filePath);
                    }

                    // Also clean inline images referenced in description HTML
                }
                catch (Exception ex)
                {
                    errors.Add($"Failed to delete file for image ID {image.Id}: {ex.Message}");
                    _logger.LogWarning(ex, "Failed to delete return image file: {ImageUrl}", image.ImageUrl);
                }
            }

            // Remove DB records for resolved return images
            if (resolvedReturnImages.Any())
            {
                dbContext.ReturnRequestImages.RemoveRange(resolvedReturnImages);
                await dbContext.SaveChangesAsync();
                _logger.LogInformation("Removed {Count} resolved return image records from database", resolvedReturnImages.Count);
            }

            // Also clean inline images from resolved return descriptions
            var resolvedReturns = await dbContext.ReturnRequests
                .Where(rr => resolvedStatuses.Contains(rr.Status) && rr.Description != null)
                .Select(rr => rr.Description)
                .ToListAsync();

            foreach (var description in resolvedReturns)
            {
                if (string.IsNullOrEmpty(description)) continue;
                var imgMatches = System.Text.RegularExpressions.Regex.Matches(
                    description, @"src=""(/img/ReturnRequests/[^""]+)""",
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase);

                foreach (System.Text.RegularExpressions.Match match in imgMatches)
                {
                    try
                    {
                        var imgUrl = match.Groups[1].Value;
                        var filePath = Path.Combine(wwwrootPath, imgUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                        if (File.Exists(filePath))
                        {
                            var fileInfo = new FileInfo(filePath);
                            totalBytesFreed += fileInfo.Length;
                            File.Delete(filePath);
                            resolvedImagesDeleted++;
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to delete inline return image");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errors.Add($"Error cleaning resolved return images: {ex.Message}");
            _logger.LogError(ex, "Error cleaning resolved return images");
        }

        // === 2. Clean orphaned files in /img/ReturnRequests/ not linked to any active return ===
        try
        {
            if (Directory.Exists(returnImagesPath))
            {
                // Get all image URLs still referenced by active (non-resolved) returns
                var activeImageUrls = await dbContext.ReturnRequestImages
                    .Include(ri => ri.ReturnRequest)
                    .Where(ri => ri.ReturnRequest.Status == ReturnRequestStatus.Pending ||
                                 ri.ReturnRequest.Status == ReturnRequestStatus.UnderReview ||
                                 ri.ReturnRequest.Status == ReturnRequestStatus.Approved)
                    .Select(ri => ri.ImageUrl)
                    .ToListAsync();

                // Also gather inline image URLs from active return descriptions
                var activeDescriptions = await dbContext.ReturnRequests
                    .Where(rr => rr.Status == ReturnRequestStatus.Pending ||
                                 rr.Status == ReturnRequestStatus.UnderReview ||
                                 rr.Status == ReturnRequestStatus.Approved)
                    .Where(rr => rr.Description != null)
                    .Select(rr => rr.Description)
                    .ToListAsync();

                var activeInlineUrls = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                foreach (var desc in activeDescriptions)
                {
                    if (string.IsNullOrEmpty(desc)) continue;
                    var imgMatches = System.Text.RegularExpressions.Regex.Matches(
                        desc, @"src=""(/img/ReturnRequests/[^""]+)""",
                        System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                    foreach (System.Text.RegularExpressions.Match match in imgMatches)
                        activeInlineUrls.Add(match.Groups[1].Value);
                }

                var allActiveUrls = new HashSet<string>(activeImageUrls, StringComparer.OrdinalIgnoreCase);
                foreach (var url in activeInlineUrls)
                    allActiveUrls.Add(url);

                // Scan all files in the folder
                var allFiles = Directory.GetFiles(returnImagesPath, "*.*", SearchOption.TopDirectoryOnly);
                foreach (var file in allFiles)
                {
                    var relativePath = "/img/ReturnRequests/" + Path.GetFileName(file);
                    if (!allActiveUrls.Contains(relativePath))
                    {
                        // File is not referenced by any active return — check if it's older than 24 hours
                        var fileInfo = new FileInfo(file);
                        if (fileInfo.CreationTimeUtc < DateTime.UtcNow.AddHours(-24))
                        {
                            totalBytesFreed += fileInfo.Length;
                            File.Delete(file);
                            orphanedFilesDeleted++;
                            _logger.LogDebug("Deleted orphaned return image: {File}", file);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errors.Add($"Error cleaning orphaned return images: {ex.Message}");
            _logger.LogError(ex, "Error cleaning orphaned return images");
        }

        // === 3. Clean general /img/temp/ folder (files older than 24 hours) ===
        try
        {
            if (Directory.Exists(generalTempPath))
            {
                var tempFiles = Directory.GetFiles(generalTempPath, "*.*", SearchOption.AllDirectories);
                foreach (var file in tempFiles)
                {
                    var fileInfo = new FileInfo(file);
                    if (fileInfo.CreationTimeUtc < DateTime.UtcNow.AddHours(-24))
                    {
                        totalBytesFreed += fileInfo.Length;
                        File.Delete(file);
                        generalTempFilesDeleted++;
                        _logger.LogDebug("Deleted temp file: {File}", file);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            errors.Add($"Error cleaning general temp files: {ex.Message}");
            _logger.LogError(ex, "Error cleaning general temp files");
        }

        // === 4. Send cleanup report email ===
        var totalDeleted = resolvedImagesDeleted + orphanedFilesDeleted + generalTempFilesDeleted;
        _logger.LogInformation(
            "Return request cleanup complete: {Resolved} resolved images, {Orphaned} orphans, {Temp} temp files deleted. {Bytes} bytes freed",
            resolvedImagesDeleted, orphanedFilesDeleted, generalTempFilesDeleted, totalBytesFreed);

        await SendCleanupReportAsync(emailService, resolvedImagesDeleted, orphanedFilesDeleted,
            generalTempFilesDeleted, totalBytesFreed, errors);
    }

    private async Task SendCleanupReportAsync(IEmailService emailService, int resolvedImages,
        int orphanedFiles, int generalTempFiles, long bytesFreed, List<string> errors)
    {
        var totalDeleted = resolvedImages + orphanedFiles + generalTempFiles;
        var freedMb = bytesFreed / (1024.0 * 1024.0);
        var hasErrors = errors.Any();
        var statusIcon = hasErrors ? "⚠️" : "🧹";
        var statusColor = hasErrors ? "#f59e0b" : "#8b5cf6";

        var errorsHtml = "";
        if (hasErrors)
        {
            var errorRows = string.Join("", errors.Select(e =>
                $"<li style='color: #991b1b; font-size: 13px;'>{System.Net.WebUtility.HtmlEncode(e)}</li>"));
            errorsHtml = $@"
                <div style='margin-top: 15px; padding: 12px; background: #fef2f2; border-radius: 6px; border-left: 4px solid #ef4444;'>
                    <strong style='color: #991b1b;'>⚠️ Errors encountered:</strong>
                    <ul style='margin: 8px 0 0;'>{errorRows}</ul>
                </div>";
        }

        var subject = $"{statusIcon} Kokomija Cleanup Report — {totalDeleted} files removed ({freedMb:N2} MB freed)";
        var body = $@"
            <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                <div style='background: linear-gradient(135deg, {statusColor} 0%, #1e293b 100%); padding: 30px; text-align: center; border-radius: 8px 8px 0 0;'>
                    <h1 style='color: white; margin: 0;'>{statusIcon} Monthly Cleanup Report</h1>
                    <p style='color: rgba(255,255,255,0.85); margin: 8px 0 0;'>Return Request Images &amp; Temp Files</p>
                </div>
                <div style='padding: 25px; background-color: #f8fafc;'>
                    <table style='width: 100%; border-collapse: collapse; font-size: 14px;'>
                        <tr style='background-color: #f0fdf4;'>
                            <td style='padding: 12px; border-bottom: 1px solid #e2e8f0;'><strong>🗑️ Resolved Return Images</strong><br><small style='color: #64748b;'>From completed, rejected, cancelled returns</small></td>
                            <td style='padding: 12px; border-bottom: 1px solid #e2e8f0; text-align: right; font-weight: bold;'>{resolvedImages} files</td>
                        </tr>
                        <tr>
                            <td style='padding: 12px; border-bottom: 1px solid #e2e8f0;'><strong>👻 Orphaned Return Images</strong><br><small style='color: #64748b;'>Files not linked to any active return</small></td>
                            <td style='padding: 12px; border-bottom: 1px solid #e2e8f0; text-align: right; font-weight: bold;'>{orphanedFiles} files</td>
                        </tr>
                        <tr style='background-color: #f0fdf4;'>
                            <td style='padding: 12px; border-bottom: 1px solid #e2e8f0;'><strong>📁 General Temp Files</strong><br><small style='color: #64748b;'>/img/temp/ folder cleanup</small></td>
                            <td style='padding: 12px; border-bottom: 1px solid #e2e8f0; text-align: right; font-weight: bold;'>{generalTempFiles} files</td>
                        </tr>
                        <tr>
                            <td style='padding: 12px; border-bottom: 2px solid #1e293b;'><strong>📊 Total</strong></td>
                            <td style='padding: 12px; border-bottom: 2px solid #1e293b; text-align: right; font-weight: bold; font-size: 16px;'>{totalDeleted} files | {freedMb:N2} MB</td>
                        </tr>
                    </table>
                    {errorsHtml}
                    <div style='margin-top: 15px; padding: 12px; background: #e0f2fe; border-radius: 6px; font-size: 13px;'>
                        <strong>🕐 Cleanup run at:</strong> {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC<br>
                        <strong>📅 Next cleanup:</strong> ~{DateTime.UtcNow.AddDays(30):MMM dd, yyyy}
                    </div>
                </div>
                <div style='padding: 15px; text-align: center; background-color: #e2e8f0; border-radius: 0 0 8px 8px;'>
                    <p style='margin: 0; color: #64748b; font-size: 12px;'>
                        Automated monthly cleanup — Kokomija System Maintenance
                    </p>
                </div>
            </div>";

        var recipientEmail = _configuration["Email:HealthCheck:RecipientEmail"] ?? "notrespond@kokomija.com";

        try
        {
            await emailService.SendEmailAsync(recipientEmail, subject, body, SmtpProviderType.Developer, isHtml: true);
            _logger.LogInformation("Cleanup report email sent to {Email}", recipientEmail);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send cleanup report email");
        }
    }
}
