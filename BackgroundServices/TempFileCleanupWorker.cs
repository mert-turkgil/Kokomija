using Kokomija.Services;

namespace Kokomija.BackgroundServices;

/// <summary>
/// Background service that periodically cleans up old temporary carousel image files
/// Runs every 24 hours to remove files older than 24 hours
/// </summary>
public class TempFileCleanupWorker : BackgroundService
{
    private readonly ILogger<TempFileCleanupWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly TimeSpan _cleanupInterval = TimeSpan.FromHours(24); // Run every 24 hours

    public TempFileCleanupWorker(
        ILogger<TempFileCleanupWorker> logger,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Temp File Cleanup Worker started - will run every {Hours} hours", _cleanupInterval.TotalHours);

        // Wait a bit before first run to let the app fully start
        await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("Running temp file cleanup at: {Time}", DateTimeOffset.Now);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var carouselImageService = scope.ServiceProvider
                        .GetRequiredService<ICarouselImageService>();

                    // Clean up old temp files (older than 24 hours)
                    await carouselImageService.CleanupOldTempFilesAsync();
                }

                _logger.LogInformation("Temp file cleanup completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while running temp file cleanup");
            }

            // Wait 24 hours before next run
            await Task.Delay(_cleanupInterval, stoppingToken);
        }

        _logger.LogInformation("Temp File Cleanup Worker stopped");
    }
}
