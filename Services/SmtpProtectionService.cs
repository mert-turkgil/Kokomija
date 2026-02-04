using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Kokomija.Services
{
    /// <summary>
    /// Service interface for SMTP configuration protection
    /// </summary>
    public interface ISmtpProtectionService
    {
        /// <summary>
        /// Validates that the developer SMTP configuration hasn't been tampered with
        /// </summary>
        /// <returns>True if configuration is valid, false if tampered</returns>
        Task<bool> ValidateConfigurationAsync();

        /// <summary>
        /// Stores a hash of the current developer SMTP configuration
        /// </summary>
        Task StoreConfigurationHashAsync();

        /// <summary>
        /// Sends an alert if SMTP configuration tampering is detected
        /// </summary>
        Task SendTamperingAlertAsync(string details);
    }

    /// <summary>
    /// SMTP Protection Service implementation.
    /// Detects and alerts on unauthorized changes to protected SMTP settings.
    /// </summary>
    public class SmtpProtectionService : ISmtpProtectionService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<SmtpProtectionService> _logger;
        private readonly IServiceProvider _serviceProvider;
        
        // In-memory storage of configuration hash (in production, this should be stored securely)
        private static string? _storedConfigHash;
        private static readonly object _lockObject = new();

        public SmtpProtectionService(
            IConfiguration configuration,
            ILogger<SmtpProtectionService> logger,
            IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        public async Task<bool> ValidateConfigurationAsync()
        {
            await Task.Yield();
            var currentHash = ComputeConfigurationHash();
            
            lock (_lockObject)
            {
                if (_storedConfigHash == null)
                {
                    // First run, store the hash
                    _storedConfigHash = currentHash;
                    _logger.LogInformation("SMTP configuration hash initialized");
                    return true;
                }

                if (_storedConfigHash != currentHash)
                {
                    _logger.LogWarning("SMTP configuration tampering detected!");
                    return false;
                }
            }

            return true;
        }

        public Task StoreConfigurationHashAsync()
        {
            var hash = ComputeConfigurationHash();
            
            lock (_lockObject)
            {
                _storedConfigHash = hash;
            }

            _logger.LogInformation("SMTP configuration hash stored");
            return Task.CompletedTask;
        }

        public async Task SendTamperingAlertAsync(string details)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();
                var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                var alertSubject = "🚨 CRITICAL: SMTP Configuration Tampering Detected!";
                var alertMessage = $@"
                    <h3>Security Alert: Developer SMTP Configuration Changed</h3>
                    <p><strong>Time:</strong> {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>
                    <p><strong>Details:</strong></p>
                    <pre style='background-color: #f1f5f9; padding: 15px; border-radius: 8px;'>{details}</pre>
                    <p style='color: #ef4444; font-weight: bold;'>
                        ⚠️ This could indicate unauthorized access to your configuration files.
                    </p>
                    <p>Recommended actions:</p>
                    <ul>
                        <li>Review recent changes to appsettings files</li>
                        <li>Check server access logs</li>
                        <li>Rotate SMTP credentials if necessary</li>
                        <li>Verify no unauthorized deployments occurred</li>
                    </ul>";

                await emailService.SendDeveloperAlertAsync(alertSubject, alertMessage);
                _logger.LogWarning("SMTP tampering alert sent: {Details}", details);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send SMTP tampering alert");
            }
        }

        private string ComputeConfigurationHash()
        {
            // Build a string from the protected SMTP settings
            var configString = new StringBuilder();
            configString.Append(_configuration["Email:DeveloperSmtp:Host"] ?? "");
            configString.Append(_configuration["Email:DeveloperSmtp:Port"] ?? "");
            configString.Append(_configuration["Email:DeveloperSmtp:Username"] ?? "");
            configString.Append(_configuration["Email:DeveloperSmtp:Password"] ?? "");
            configString.Append(_configuration["Email:DeveloperSmtp:FromEmail"] ?? "");

            // Compute SHA256 hash
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(configString.ToString());
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    /// <summary>
    /// Background service that monitors SMTP configuration for unauthorized changes
    /// </summary>
    public class SmtpProtectionWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<SmtpProtectionWorker> _logger;
        private readonly IConfiguration _configuration;

        public SmtpProtectionWorker(
            IServiceProvider serviceProvider,
            ILogger<SmtpProtectionWorker> logger,
            IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SMTP Protection Worker starting...");

            // Initial hash storage
            using (var scope = _serviceProvider.CreateScope())
            {
                var protectionService = scope.ServiceProvider.GetRequiredService<ISmtpProtectionService>();
                await protectionService.StoreConfigurationHashAsync();
            }

            // Check every hour
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                    await PerformProtectionCheckAsync();
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during SMTP protection check");
                }
            }
        }

        private async Task PerformProtectionCheckAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var protectionService = scope.ServiceProvider.GetRequiredService<ISmtpProtectionService>();

            var isValid = await protectionService.ValidateConfigurationAsync();
            if (!isValid)
            {
                await protectionService.SendTamperingAlertAsync(
                    "Developer SMTP configuration has been modified since application startup. " +
                    "This change was not authorized through normal application channels.");
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SMTP Protection Worker stopping...");
            await base.StopAsync(stoppingToken);
        }
    }
}
