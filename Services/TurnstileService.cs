using System.Text.Json;

namespace Kokomija.Services
{
    /// <summary>
    /// Cloudflare Turnstile verification service interface
    /// Replaces traditional CAPTCHA with privacy-focused alternative
    /// </summary>
    public interface ITurnstileService
    {
        Task<TurnstileVerificationResult> VerifyTokenAsync(string token, string? remoteIp = null);
    }

    /// <summary>
    /// Cloudflare Turnstile service implementation
    /// Documentation: https://developers.cloudflare.com/turnstile/
    /// </summary>
    public class TurnstileService : ITurnstileService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TurnstileService> _logger;
        private readonly HttpClient _httpClient;
        private const string VerifyEndpoint = "https://challenges.cloudflare.com/turnstile/v0/siteverify";

        public TurnstileService(IConfiguration configuration, ILogger<TurnstileService> logger, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<TurnstileVerificationResult> VerifyTokenAsync(string token, string? remoteIp = null)
        {
            try
            {
                var secretKey = _configuration["Turnstile:SecretKey"];
                
                if (string.IsNullOrEmpty(secretKey))
                {
                    _logger.LogWarning("Turnstile SecretKey not configured. Verification skipped.");
                    return new TurnstileVerificationResult
                    {
                        Success = false,
                        ErrorCodes = new[] { "missing-secret-key" }
                    };
                }

                var formData = new Dictionary<string, string>
                {
                    { "secret", secretKey },
                    { "response", token }
                };

                if (!string.IsNullOrEmpty(remoteIp))
                {
                    formData.Add("remoteip", remoteIp);
                }

                var content = new FormUrlEncodedContent(formData);
                var response = await _httpClient.PostAsync(VerifyEndpoint, content);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("Turnstile verification failed with status code: {StatusCode}", response.StatusCode);
                    return new TurnstileVerificationResult
                    {
                        Success = false,
                        ErrorCodes = new[] { "http-error" }
                    };
                }

                var result = JsonSerializer.Deserialize<TurnstileApiResponse>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (result == null)
                {
                    _logger.LogError("Failed to deserialize Turnstile response");
                    return new TurnstileVerificationResult
                    {
                        Success = false,
                        ErrorCodes = new[] { "parse-error" }
                    };
                }

                var verificationResult = new TurnstileVerificationResult
                {
                    Success = result.Success,
                    ChallengeTs = result.ChallengeTs,
                    Hostname = result.Hostname,
                    ErrorCodes = result.ErrorCodes ?? Array.Empty<string>(),
                    Action = result.Action,
                    CData = result.CData
                };

                if (!verificationResult.Success)
                {
                    _logger.LogWarning("Turnstile verification failed. Error codes: {ErrorCodes}", 
                        string.Join(", ", verificationResult.ErrorCodes));
                }
                else
                {
                    _logger.LogInformation("Turnstile verification successful for hostname: {Hostname}", verificationResult.Hostname);
                }

                return verificationResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception during Turnstile verification");
                return new TurnstileVerificationResult
                {
                    Success = false,
                    ErrorCodes = new[] { "exception" }
                };
            }
        }

        private class TurnstileApiResponse
        {
            public bool Success { get; set; }
            public string? ChallengeTs { get; set; }
            public string? Hostname { get; set; }
            public string[]? ErrorCodes { get; set; }
            public string? Action { get; set; }
            public string? CData { get; set; }
        }
    }

    /// <summary>
    /// Turnstile verification result
    /// </summary>
    public class TurnstileVerificationResult
    {
        /// <summary>
        /// Whether the verification succeeded
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// ISO timestamp of the challenge
        /// </summary>
        public string? ChallengeTs { get; set; }

        /// <summary>
        /// Hostname where challenge was completed
        /// </summary>
        public string? Hostname { get; set; }

        /// <summary>
        /// Error codes if verification failed
        /// Possible values: missing-input-secret, invalid-input-secret, 
        /// missing-input-response, invalid-input-response, timeout-or-duplicate
        /// </summary>
        public string[] ErrorCodes { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Action name (if configured in Turnstile widget)
        /// </summary>
        public string? Action { get; set; }

        /// <summary>
        /// Customer data passed through (if configured)
        /// </summary>
        public string? CData { get; set; }
    }
}
