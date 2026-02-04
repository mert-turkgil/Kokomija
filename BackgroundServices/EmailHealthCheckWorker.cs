using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Kokomija.BackgroundServices
{
    /// <summary>
    /// Background service for periodic email system health checks.
    /// Sends a health check email every 30 days to confirm the email system is operational.
    /// </summary>
    public class EmailHealthCheckWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EmailHealthCheckWorker> _logger;
        private readonly IConfiguration _configuration;

        public EmailHealthCheckWorker(
            IServiceProvider serviceProvider,
            ILogger<EmailHealthCheckWorker> logger,
            IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Email Health Check Worker starting...");

            // Check if health check is enabled
            var isEnabled = _configuration.GetValue<bool>("Email:HealthCheck:Enabled", true);
            if (!isEnabled)
            {
                _logger.LogInformation("Email Health Check Worker is disabled in configuration");
                return;
            }

            // Initial delay before first check (5 minutes after startup)
            await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await PerformHealthCheckAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during email health check");
                }

                // Wait for the configured interval (default: 30 days)
                var intervalDays = _configuration.GetValue<int>("Email:HealthCheck:IntervalDays", 30);
                _logger.LogInformation("Next email health check in {Days} days", intervalDays);
                await Task.Delay(TimeSpan.FromDays(intervalDays), stoppingToken);
            }
        }

        private async Task PerformHealthCheckAsync()
        {
            _logger.LogInformation("Performing email system health check at {Time}", DateTime.UtcNow);

            using var scope = _serviceProvider.CreateScope();
            var emailService = scope.ServiceProvider.GetRequiredService<Services.IEmailService>();

            try
            {
                await emailService.SendHealthCheckEmailAsync();
                _logger.LogInformation("Email health check completed successfully");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Email health check failed! Email system may be down.");
                // The error is logged, but we continue running to try again later
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Email Health Check Worker stopping...");
            await base.StopAsync(stoppingToken);
        }
    }
}
