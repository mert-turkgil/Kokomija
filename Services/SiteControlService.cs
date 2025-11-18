using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;
using System.Text;

namespace Kokomija.Services
{
    public interface ISiteControlService
    {
        Task<bool> CloseSiteAsync(string reason, string closedBy);
        Task<bool> ReopenSiteAsync(string reopenedBy, string method = "manual");
        Task<bool> IsSiteClosedAsync();
        Task<SiteClosure?> GetCurrentClosureAsync();
        Task<bool> VerifyEmergencyPasswordAsync(string password);
        Task<bool> SetEmergencyPasswordAsync(string password);
        Task<string> GenerateReopenTokenAsync();
        Task<bool> VerifyReopenTokenAsync(string token);
        Task SendDailyConfirmationEmailAsync();
        Task CheckScheduledReopeningAsync();
    }

    public class SiteControlService : ISiteControlService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly ILogger<SiteControlService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private const string SITE_CLOSURE_CACHE_KEY = "SiteClosureEnabled";

        public SiteControlService(
            IUnitOfWork unitOfWork,
            IEmailService emailService,
            ILogger<SiteControlService> logger,
            IConfiguration configuration,
            IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _logger = logger;
            _configuration = configuration;
            _cache = cache;
        }

        /// <summary>
        /// Close the site for emergency maintenance
        /// </summary>
        public async Task<bool> CloseSiteAsync(string reason, string closedBy)
        {
            try
            {
                // Check if site is already closed
                var existingClosure = await GetCurrentClosureAsync();
                if (existingClosure != null && existingClosure.IsClosed)
                {
                    _logger.LogWarning("Site is already closed");
                    return false;
                }

                var autoReopenDays = await GetAutoReopenDaysAsync();
                var scheduledReopen = DateTime.UtcNow.AddDays(autoReopenDays);

                var closure = new SiteClosure
                {
                    IsClosed = true,
                    Reason = reason,
                    ClosedBy = closedBy,
                    ClosedAt = DateTime.UtcNow,
                    ScheduledReopenAt = scheduledReopen,
                    ReopenConfirmationToken = GenerateSecureToken(),
                    TokenExpiresAt = DateTime.UtcNow.AddDays(autoReopenDays + 1),
                    AllowPasswordAccess = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                await _unitOfWork.SiteClosures.AddAsync(closure);

                // Update site setting
                var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "SiteClosureEnabled");

                if (setting != null)
                {
                    setting.Value = "true";
                    setting.UpdatedAt = DateTime.UtcNow;
                    setting.UpdatedBy = closedBy;
                }

                await _unitOfWork.SaveChangesAsync();

                // Invalidate cache
                _cache.Remove(SITE_CLOSURE_CACHE_KEY);

                _logger.LogCritical("Site closed by {ClosedBy}. Reason: {Reason}. Scheduled reopen: {ScheduledReopen}",
                    closedBy, reason, scheduledReopen);

                // Send notification email
                await SendClosureNotificationEmailAsync(closure);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to close site");
                return false;
            }
        }

        /// <summary>
        /// Reopen the site
        /// </summary>
        public async Task<bool> ReopenSiteAsync(string reopenedBy, string method = "manual")
        {
            try
            {
                var closure = await GetCurrentClosureAsync();
                if (closure == null || !closure.IsClosed)
                {
                    _logger.LogWarning("Site is not currently closed");
                    return false;
                }

                closure.IsClosed = false;
                closure.ReopenedAt = DateTime.UtcNow;
                closure.ReopenedBy = reopenedBy;
                closure.ReopenMethod = method;
                closure.DaysClosed = (int)(DateTime.UtcNow - closure.ClosedAt.GetValueOrDefault()).TotalDays;
                closure.UpdatedAt = DateTime.UtcNow;

                // Update site setting
                var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "SiteClosureEnabled");

                if (setting != null)
                {
                    setting.Value = "false";
                    setting.UpdatedAt = DateTime.UtcNow;
                    setting.UpdatedBy = reopenedBy;
                }

                await _unitOfWork.SaveChangesAsync();

                // Invalidate cache
                _cache.Remove(SITE_CLOSURE_CACHE_KEY);

                _logger.LogInformation("Site reopened by {ReopenedBy} via {Method}. Was closed for {Days} days",
                    reopenedBy, method, closure.DaysClosed);

                // Send notification
                await SendReopenNotificationEmailAsync(closure);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to reopen site");
                return false;
            }
        }

        /// <summary>
        /// Check if site is currently closed
        /// </summary>
        public async Task<bool> IsSiteClosedAsync()
        {
            // Check cache first to avoid hitting DB on every request
            if (_cache.TryGetValue(SITE_CLOSURE_CACHE_KEY, out bool isClosed))
            {
                return isClosed;
            }

            // Cache miss - query database
            var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "SiteClosureEnabled");

            isClosed = setting != null && setting.Value.Equals("true", StringComparison.OrdinalIgnoreCase);

            // Cache for 1 minute with sliding expiration
            _cache.Set(SITE_CLOSURE_CACHE_KEY, isClosed, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(1),
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });

            return isClosed;
        }

        /// <summary>
        /// Get current active closure
        /// </summary>
        public async Task<SiteClosure?> GetCurrentClosureAsync()
        {
            var allClosures = await _unitOfWork.SiteClosures.GetAllAsync();
            return allClosures
                .Where(sc => sc.IsClosed)
                .OrderByDescending(sc => sc.ClosedAt)
                .FirstOrDefault();
        }

        /// <summary>
        /// Verify emergency password
        /// </summary>
        public async Task<bool> VerifyEmergencyPasswordAsync(string password)
        {
            var closure = await GetCurrentClosureAsync();
            if (closure == null || string.IsNullOrEmpty(closure.EmergencyPasswordHash))
            {
                return false;
            }

            var passwordHash = HashPassword(password);
            return closure.EmergencyPasswordHash == passwordHash;
        }

        /// <summary>
        /// Set emergency password
        /// </summary>
        public async Task<bool> SetEmergencyPasswordAsync(string password)
        {
            var closure = await GetCurrentClosureAsync();
            if (closure == null)
            {
                return false;
            }

            closure.EmergencyPasswordHash = HashPassword(password);
            closure.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Generate reopen confirmation token
        /// </summary>
        public async Task<string> GenerateReopenTokenAsync()
        {
            var closure = await GetCurrentClosureAsync();
            if (closure == null)
            {
                return string.Empty;
            }

            var token = GenerateSecureToken();
            closure.ReopenConfirmationToken = token;
            closure.TokenExpiresAt = DateTime.UtcNow.AddDays(1);
            closure.UpdatedAt = DateTime.UtcNow;
            
            await _unitOfWork.SaveChangesAsync();

            return token;
        }

        /// <summary>
        /// Verify reopen token
        /// </summary>
        public async Task<bool> VerifyReopenTokenAsync(string token)
        {
            var closure = await GetCurrentClosureAsync();
            if (closure == null || string.IsNullOrEmpty(closure.ReopenConfirmationToken))
            {
                return false;
            }

            if (closure.TokenExpiresAt.HasValue && closure.TokenExpiresAt.Value < DateTime.UtcNow)
            {
                _logger.LogWarning("Reopen token has expired");
                return false;
            }

            return closure.ReopenConfirmationToken == token;
        }

        /// <summary>
        /// Send daily confirmation email during closure
        /// </summary>
        public async Task SendDailyConfirmationEmailAsync()
        {
            var closure = await GetCurrentClosureAsync();
            if (closure == null || !closure.IsClosed)
            {
                return;
            }

            var dailyEmailEnabled = await IsDailyEmailEnabledAsync();
            if (!dailyEmailEnabled)
            {
                return;
            }

            var superAdminEmail = await GetSuperAdminEmailAsync();
            var token = await GenerateReopenTokenAsync();
            var reopenUrl = $"{_configuration["AppUrl"]}/admin/site-control/reopen?token={token}";

            var daysClosed = (int)(DateTime.UtcNow - closure.ClosedAt.GetValueOrDefault()).TotalDays;
            var daysUntilAutoReopen = closure.ScheduledReopenAt.HasValue
                ? (int)(closure.ScheduledReopenAt.Value - DateTime.UtcNow).TotalDays
                : 0;

            var emailBody = $@"
                <h2>Kokomija - Potwierdzenie zamknięcia strony (Dzień {daysClosed})</h2>
                <p>Strona jest zamknięta od: <strong>{closure.ClosedAt:dd.MM.yyyy HH:mm}</strong></p>
                <p>Powód: <strong>{closure.Reason}</strong></p>
                <p>Automatyczne otwarcie za: <strong>{daysUntilAutoReopen} dni</strong> ({closure.ScheduledReopenAt:dd.MM.yyyy})</p>
                
                <h3>Opcje otwarcia:</h3>
                <p>1. Kliknij link: <a href=""{reopenUrl}"">Otwórz stronę teraz</a></p>
                <p>2. Odpowiedz na ten email z hasłem awaryjnym</p>
                <p>3. Poczekaj na automatyczne otwarcie ({daysUntilAutoReopen} dni)</p>
                
                <p>Emails wysłane: {closure.ConfirmationEmailsSent + 1}</p>
                <p>Jeśli nie chcesz otrzymywać tych emaili, odpowiedz: STOP</p>
            ";

            await _emailService.SendEmailAsync(superAdminEmail, "Kokomija - Potwierdzenie zamknięcia strony", emailBody, isHtml: true);

            closure.ConfirmationEmailsSent++;
            closure.LastConfirmationEmailAt = DateTime.UtcNow;
            closure.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Daily confirmation email sent ({Count})", closure.ConfirmationEmailsSent);
        }

        /// <summary>
        /// Check if it's time for scheduled reopening
        /// </summary>
        public async Task CheckScheduledReopeningAsync()
        {
            var closure = await GetCurrentClosureAsync();
            if (closure == null || !closure.IsClosed)
            {
                return;
            }

            if (closure.ScheduledReopenAt.HasValue && closure.ScheduledReopenAt.Value <= DateTime.UtcNow)
            {
                await ReopenSiteAsync("System (Automatic)", "automatic");
                _logger.LogInformation("Site automatically reopened after scheduled period");
            }
        }

        private async Task SendClosureNotificationEmailAsync(SiteClosure closure)
        {
            var superAdminEmail = await GetSuperAdminEmailAsync();
            var token = closure.ReopenConfirmationToken;
            var reopenUrl = $"{_configuration["AppUrl"]}/admin/site-control/reopen?token={token}";

            var emailBody = $@"
                <h2>⚠️ Kokomija - Strona została zamknięta</h2>
                <p>Strona została zamknięta: <strong>{closure.ClosedAt:dd.MM.yyyy HH:mm}</strong></p>
                <p>Powód: <strong>{closure.Reason}</strong></p>
                <p>Zamknięta przez: <strong>{closure.ClosedBy}</strong></p>
                <p>Automatyczne otwarcie: <strong>{closure.ScheduledReopenAt:dd.MM.yyyy HH:mm}</strong> (30 dni)</p>
                
                <h3>Aby otworzyć stronę wcześniej:</h3>
                <p>1. <a href=""{reopenUrl}"">Kliknij tutaj aby otworzyć</a></p>
                <p>2. Użyj hasła awaryjnego</p>
                <p>3. Odpowiedz na codzienne emaile potwierdzające</p>
                
                <p>Będziesz otrzymywać codzienne emaile z opcją otwarcia.</p>
            ";

            await _emailService.SendEmailAsync(superAdminEmail, "⚠️ Kokomija - Strona zamknięta", emailBody, isHtml: true);
        }

        private async Task SendReopenNotificationEmailAsync(SiteClosure closure)
        {
            var superAdminEmail = await GetSuperAdminEmailAsync();

            var emailBody = $@"
                <h2>✅ Kokomija - Strona została otwarta</h2>
                <p>Strona została otwarta: <strong>{closure.ReopenedAt:dd.MM.yyyy HH:mm}</strong></p>
                <p>Otwarta przez: <strong>{closure.ReopenedBy}</strong></p>
                <p>Metoda: <strong>{closure.ReopenMethod}</strong></p>
                <p>Czas zamknięcia: <strong>{closure.DaysClosed} dni</strong></p>
                
                <p>Strona działa normalnie.</p>
            ";

            await _emailService.SendEmailAsync(superAdminEmail, "✅ Kokomija - Strona otwarta", emailBody, isHtml: true);
        }

        private async Task<string> GetSuperAdminEmailAsync()
        {
            var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "SuperAdminEmail");

            return setting?.Value ?? "admin@kokomija.com";
        }

        private async Task<int> GetAutoReopenDaysAsync()
        {
            var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "AutoReopenAfterDays");

            if (setting != null && int.TryParse(setting.Value, out int days))
            {
                return days;
            }

            return 30; // Default 30 days
        }

        private async Task<bool> IsDailyEmailEnabledAsync()
        {
            var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "DailyConfirmationEmailEnabled");

            return setting == null || setting.Value.Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        private string GenerateSecureToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}

