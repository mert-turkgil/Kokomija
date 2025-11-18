using Kokomija.Services;

namespace Kokomija.BackgroundServices;

public class WishlistNotificationWorker : BackgroundService
{
    private readonly ILogger<WishlistNotificationWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly TimeSpan _checkInterval = TimeSpan.FromHours(6); // Check every 6 hours

    public WishlistNotificationWorker(
        ILogger<WishlistNotificationWorker> logger,
        IServiceProvider serviceProvider)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Wishlist Notification Worker started");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("Running wishlist notification checks at: {time}", DateTimeOffset.Now);

                using (var scope = _serviceProvider.CreateScope())
                {
                    var notificationService = scope.ServiceProvider
                        .GetRequiredService<IWishlistNotificationService>();

                    // Check for price changes
                    await notificationService.CheckPriceChangesAsync();
                }

                _logger.LogInformation("Wishlist notification checks completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while running wishlist notification checks");
            }

            await Task.Delay(_checkInterval, stoppingToken);
        }

        _logger.LogInformation("Wishlist Notification Worker stopped");
    }
}
