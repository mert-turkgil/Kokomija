namespace Kokomija.Services;

public class BlogCleanupService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<BlogCleanupService> _logger;
    private readonly TimeSpan _interval = TimeSpan.FromHours(6);

    public BlogCleanupService(IServiceScopeFactory scopeFactory, ILogger<BlogCleanupService> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var imageService = scope.ServiceProvider.GetRequiredService<IBlogImageService>();
                await imageService.ClearOldTempFilesAsync(24);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Blog cleanup error");
            }

            await Task.Delay(_interval, stoppingToken);
        }
    }
}