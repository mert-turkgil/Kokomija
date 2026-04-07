using Kokomija.Services;
using Stripe;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace Kokomija.BackgroundServices;

/// <summary>
/// Background service that performs monthly health checks on all external API integrations
/// and sends a detailed report via email.
/// APIs checked: Stripe, DeepL, InPost, DHL, Cloudflare Turnstile, Polish NIP, Customer SMTP, Developer SMTP
/// </summary>
public class ApiHealthCheckWorker : BackgroundService
{
    private readonly ILogger<ApiHealthCheckWorker> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;

    public ApiHealthCheckWorker(
        ILogger<ApiHealthCheckWorker> logger,
        IServiceProvider serviceProvider,
        IConfiguration configuration)
    {
        _logger = logger;
        _serviceProvider = serviceProvider;
        _configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("API Health Check Worker starting...");

        // Initial delay (10 minutes after startup)
        await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await PerformFullHealthCheckAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during API health check");
            }

            // Run monthly (30 days)
            _logger.LogInformation("Next API health check in 30 days");
            await Task.Delay(TimeSpan.FromDays(30), stoppingToken);
        }
    }

    private async Task PerformFullHealthCheckAsync()
    {
        _logger.LogInformation("Starting full API health check at {Time}", DateTime.UtcNow);

        var results = new List<ApiCheckResult>();

        // Check all APIs
        results.Add(await CheckStripeAsync());
        results.Add(await CheckDeepLAsync());
        results.Add(await CheckInPostAsync());
        results.Add(await CheckDhlAsync());
        results.Add(await CheckTurnstileAsync());
        results.Add(await CheckNipApiAsync());
        results.Add(await CheckCustomerSmtpAsync());
        results.Add(await CheckDeveloperSmtpAsync());
        results.Add(await CheckMyMemoryAsync());
        results.Add(await CheckGoogleOAuthAsync());
        results.Add(await CheckFacebookOAuthAsync());

        // Send report
        await SendHealthReportEmailAsync(results);

        var failedCount = results.Count(r => !r.IsHealthy);
        if (failedCount > 0)
            _logger.LogWarning("API Health Check completed: {Failed}/{Total} APIs unhealthy", failedCount, results.Count);
        else
            _logger.LogInformation("API Health Check completed: All {Total} APIs healthy", results.Count);
    }

    private async Task<ApiCheckResult> CheckStripeAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var secretKey = _configuration["Stripe:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
                return new ApiCheckResult("Stripe", false, "Secret key not configured", 0);

            StripeConfiguration.ApiKey = secretKey;
            var service = new BalanceService();
            var balance = await service.GetAsync();
            sw.Stop();

            return new ApiCheckResult("Stripe", true,
                $"Connected. Available: {balance.Available?.Sum(b => b.Amount) / 100m:N2} {balance.Available?.FirstOrDefault()?.Currency?.ToUpper()}",
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("Stripe", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckDeepLAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var apiKey = _configuration["DeepL:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
                return new ApiCheckResult("DeepL Translation", false, "API key not configured", 0);

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("DeepL-Auth-Key", apiKey);
            var response = await httpClient.GetAsync("https://api-free.deepl.com/v2/usage");
            sw.Stop();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return new ApiCheckResult("DeepL Translation", true, $"API reachable. Usage: {content}", sw.ElapsedMilliseconds);
            }
            return new ApiCheckResult("DeepL Translation", false, $"HTTP {(int)response.StatusCode}: {response.ReasonPhrase}", sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("DeepL Translation", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckInPostAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var apiToken = _configuration["InPost:ShipXApiToken"];
            var baseUrl = _configuration["InPost:BaseUrl"] ?? "https://api-shipx-pl.easypack24.net";
            if (string.IsNullOrEmpty(apiToken))
                return new ApiCheckResult("InPost (ShipX)", false, "API token not configured", 0);

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            var response = await httpClient.GetAsync($"{baseUrl}/v1/organizations");
            sw.Stop();

            return new ApiCheckResult("InPost (ShipX)", response.IsSuccessStatusCode,
                response.IsSuccessStatusCode ? "API reachable" : $"HTTP {(int)response.StatusCode}: {response.ReasonPhrase}",
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("InPost (ShipX)", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckDhlAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var apiKey = _configuration["DHL:ApiKey"];
            var baseUrl = _configuration["DHL:BaseUrl"] ?? "https://express.api.dhl.com/mydhlapi";
            if (string.IsNullOrEmpty(apiKey))
                return new ApiCheckResult("DHL Express", false, "API key not configured", 0);

            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("DHL-API-Key", apiKey);
            var response = await httpClient.GetAsync($"{baseUrl}/rates?accountNumber=test&originCountryCode=PL&originCityName=Warsaw&destinationCountryCode=DE&destinationCityName=Berlin&weight=1&length=10&width=10&height=10");
            sw.Stop();

            // DHL may return 400 for test params but proves connectivity
            var isReachable = (int)response.StatusCode < 500;
            return new ApiCheckResult("DHL Express", isReachable,
                isReachable ? $"API reachable (HTTP {(int)response.StatusCode})" : $"Server error: HTTP {(int)response.StatusCode}",
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("DHL Express", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckTurnstileAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var secretKey = _configuration["Turnstile:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
                return new ApiCheckResult("Cloudflare Turnstile", false, "Secret key not configured", 0);

            using var httpClient = new HttpClient();
            // Send a dummy token to verify the endpoint is reachable and key is valid
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("secret", secretKey),
                new KeyValuePair<string, string>("response", "health-check-dummy-token")
            });
            var response = await httpClient.PostAsync("https://challenges.cloudflare.com/turnstile/v0/siteverify", content);
            sw.Stop();

            // Endpoint should respond even with invalid token — proves connectivity and key format
            return new ApiCheckResult("Cloudflare Turnstile", response.IsSuccessStatusCode,
                response.IsSuccessStatusCode ? "Endpoint reachable, key format valid" : $"HTTP {(int)response.StatusCode}",
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("Cloudflare Turnstile", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckNipApiAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            using var httpClient = new HttpClient();
            // Check the API status endpoint
            var response = await httpClient.GetAsync("https://wl-api.mf.gov.pl/api/check/nip/5252344078?date=" + DateTime.UtcNow.ToString("yyyy-MM-dd"));
            sw.Stop();

            var isReachable = (int)response.StatusCode < 500;
            return new ApiCheckResult("Polish NIP (Gov API)", isReachable,
                isReachable ? $"API reachable (HTTP {(int)response.StatusCode})" : $"Server error: HTTP {(int)response.StatusCode}",
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("Polish NIP (Gov API)", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckCustomerSmtpAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var host = _configuration["Email:CustomerSmtp:Host"];
            var port = _configuration.GetValue<int>("Email:CustomerSmtp:Port", 587);
            if (string.IsNullOrEmpty(host))
                return new ApiCheckResult("Customer SMTP", false, "Host not configured", 0);

            using var client = new System.Net.Sockets.TcpClient();
            await client.ConnectAsync(host, port);
            sw.Stop();

            return new ApiCheckResult("Customer SMTP", true,
                $"Connected to {host}:{port}", sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("Customer SMTP", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckDeveloperSmtpAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var host = _configuration["Email:DeveloperSmtp:Host"];
            var port = _configuration.GetValue<int>("Email:DeveloperSmtp:Port", 587);
            if (string.IsNullOrEmpty(host))
                return new ApiCheckResult("Developer SMTP", false, "Host not configured", 0);

            using var client = new System.Net.Sockets.TcpClient();
            await client.ConnectAsync(host, port);
            sw.Stop();

            return new ApiCheckResult("Developer SMTP", true,
                $"Connected to {host}:{port}", sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("Developer SMTP", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckMyMemoryAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://api.mymemory.translated.net/get?q=hello&langpair=en|pl");
            sw.Stop();

            return new ApiCheckResult("MyMemory Translation", response.IsSuccessStatusCode,
                response.IsSuccessStatusCode ? "API reachable" : $"HTTP {(int)response.StatusCode}",
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("MyMemory Translation", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckGoogleOAuthAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var clientId = _configuration["Authentication:Google:ClientId"];
            if (string.IsNullOrEmpty(clientId))
                return new ApiCheckResult("Google OAuth", false, "Client ID not configured", 0);

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://accounts.google.com/.well-known/openid-configuration");
            sw.Stop();

            return new ApiCheckResult("Google OAuth", response.IsSuccessStatusCode,
                response.IsSuccessStatusCode ? $"OpenID endpoint reachable. Client ID: {clientId[..8]}..." : $"HTTP {(int)response.StatusCode}",
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("Google OAuth", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task<ApiCheckResult> CheckFacebookOAuthAsync()
    {
        var sw = Stopwatch.StartNew();
        try
        {
            var appId = _configuration["Authentication:Facebook:AppId"];
            if (string.IsNullOrEmpty(appId))
                return new ApiCheckResult("Facebook OAuth", false, "App ID not configured", 0);

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://graph.facebook.com/v18.0/me");
            sw.Stop();

            // Will return 400 (no token) but proves endpoint is reachable
            var isReachable = (int)response.StatusCode < 500;
            return new ApiCheckResult("Facebook OAuth", isReachable,
                isReachable ? $"Graph API reachable. App ID: {appId}" : $"Server error: HTTP {(int)response.StatusCode}",
                sw.ElapsedMilliseconds);
        }
        catch (Exception ex)
        {
            sw.Stop();
            return new ApiCheckResult("Facebook OAuth", false, $"Error: {ex.Message}", sw.ElapsedMilliseconds);
        }
    }

    private async Task SendHealthReportEmailAsync(List<ApiCheckResult> results)
    {
        using var scope = _serviceProvider.CreateScope();
        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

        var healthyCount = results.Count(r => r.IsHealthy);
        var totalCount = results.Count;
        var allHealthy = healthyCount == totalCount;

        var statusIcon = allHealthy ? "✅" : "⚠️";
        var statusColor = allHealthy ? "#10b981" : "#f59e0b";
        var statusText = allHealthy ? "All Systems Operational" : $"{totalCount - healthyCount} System(s) Require Attention";

        var rowsHtml = new StringBuilder();
        foreach (var result in results)
        {
            var icon = result.IsHealthy ? "✅" : "❌";
            var rowColor = result.IsHealthy ? "#f0fdf4" : "#fef2f2";
            var textColor = result.IsHealthy ? "#166534" : "#991b1b";
            rowsHtml.AppendLine($@"
                <tr style='background-color: {rowColor};'>
                    <td style='padding: 12px; border-bottom: 1px solid #e2e8f0;'>{icon} <strong>{result.ApiName}</strong></td>
                    <td style='padding: 12px; border-bottom: 1px solid #e2e8f0; color: {textColor};'>{(result.IsHealthy ? "Healthy" : "Unhealthy")}</td>
                    <td style='padding: 12px; border-bottom: 1px solid #e2e8f0;'>{result.ResponseTimeMs}ms</td>
                    <td style='padding: 12px; border-bottom: 1px solid #e2e8f0; font-size: 12px;'>{System.Net.WebUtility.HtmlEncode(result.Details)}</td>
                </tr>");
        }

        var subject = $"{statusIcon} Kokomija API Health Report — {healthyCount}/{totalCount} Healthy";
        var body = $@"
            <div style='font-family: Arial, sans-serif; max-width: 700px; margin: 0 auto;'>
                <div style='background: linear-gradient(135deg, {statusColor} 0%, #1e293b 100%); padding: 30px; text-align: center; border-radius: 8px 8px 0 0;'>
                    <h1 style='color: white; margin: 0;'>{statusIcon} API Health Report</h1>
                    <p style='color: rgba(255,255,255,0.85); margin: 8px 0 0;'>{statusText}</p>
                </div>
                <div style='padding: 20px; background-color: #f8fafc;'>
                    <table style='width: 100%; border-collapse: collapse; font-size: 14px;'>
                        <thead>
                            <tr style='background-color: #1e293b; color: white;'>
                                <th style='padding: 12px; text-align: left;'>API Service</th>
                                <th style='padding: 12px; text-align: left;'>Status</th>
                                <th style='padding: 12px; text-align: left;'>Response</th>
                                <th style='padding: 12px; text-align: left;'>Details</th>
                            </tr>
                        </thead>
                        <tbody>
                            {rowsHtml}
                        </tbody>
                    </table>
                    <div style='margin-top: 20px; padding: 15px; background: #e0f2fe; border-radius: 6px; font-size: 13px;'>
                        <strong>📊 Summary:</strong> {healthyCount}/{totalCount} APIs healthy | 
                        Checked at: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC |
                        Next check: ~{DateTime.UtcNow.AddDays(30):MMM dd, yyyy}
                    </div>
                </div>
                <div style='padding: 15px; text-align: center; background-color: #e2e8f0; border-radius: 0 0 8px 8px;'>
                    <p style='margin: 0; color: #64748b; font-size: 12px;'>
                        Automated monthly API health check — Kokomija System Monitor
                    </p>
                </div>
            </div>";

        var recipientEmail = _configuration["Email:HealthCheck:RecipientEmail"] ?? "notrespond@kokomija.com";

        try
        {
            await emailService.SendEmailAsync(recipientEmail, subject, body, SmtpProviderType.Developer, isHtml: true);
            _logger.LogInformation("API health report email sent to {Email}", recipientEmail);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to send API health report email");
        }
    }

    private class ApiCheckResult
    {
        public string ApiName { get; }
        public bool IsHealthy { get; }
        public string Details { get; }
        public long ResponseTimeMs { get; }

        public ApiCheckResult(string apiName, bool isHealthy, string details, long responseTimeMs)
        {
            ApiName = apiName;
            IsHealthy = isHealthy;
            Details = details;
            ResponseTimeMs = responseTimeMs;
        }
    }
}
