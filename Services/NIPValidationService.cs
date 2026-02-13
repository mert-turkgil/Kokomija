using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kokomija.Services
{
    public interface INIPValidationService
    {
        /// <summary>
        /// Validates a NIP with the Polish government API
        /// </summary>
        Task<NIPValidationResult> ValidateNIPAsync(string nip, string userId, string? ipAddress = null);

        /// <summary>
        /// Checks if user can attempt verification (rate limiting)
        /// </summary>
        Task<(bool CanAttempt, TimeSpan? WaitTime)> CanAttemptVerificationAsync(string userId);

        /// <summary>
        /// Gets the business profile for a user
        /// </summary>
        Task<BusinessProfile?> GetBusinessProfileAsync(string userId);

        /// <summary>
        /// Toggles business mode for shopping
        /// </summary>
        Task<bool> ToggleBusinessModeAsync(string userId);
    }

    public class NIPValidationService : INIPValidationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<NIPValidationService> _logger;
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;

        // Rate limiting settings
        private const int MaxAttemptsPerDay = 3;
        private const int CooldownMinutes = 60; // 1 hour between attempts
        private const string ProductionApiUrl = "https://wl-api.mf.gov.pl";
        private const string TestApiUrl = "https://wl-test.mf.gov.pl";

        public NIPValidationService(
            IUnitOfWork unitOfWork,
            IHttpClientFactory httpClientFactory,
            ILogger<NIPValidationService> logger,
            IMemoryCache cache,
            IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _cache = cache;
            _configuration = configuration;
        }

        public async Task<NIPValidationResult> ValidateNIPAsync(string nip, string userId, string? ipAddress = null)
        {
            var result = new NIPValidationResult();

            try
            {
                // Clean and validate NIP format
                nip = CleanNIP(nip);
                if (!IsValidNIPFormat(nip))
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Invalid NIP format. NIP must be exactly 10 digits.";
                    return result;
                }

                // Check checksum
                if (!ValidateNIPChecksum(nip))
                {
                    result.IsValid = false;
                    result.ErrorMessage = "Invalid NIP checksum. Please verify the number.";
                    return result;
                }

                // Check rate limiting
                var (canAttempt, waitTime) = await CanAttemptVerificationAsync(userId);
                if (!canAttempt)
                {
                    result.IsValid = false;
                    result.ErrorMessage = $"Too many verification attempts. Please wait {waitTime?.TotalMinutes:F0} minutes.";
                    result.RateLimited = true;
                    return result;
                }

                // Log the attempt
                var log = new NIPVerificationLog
                {
                    UserId = userId,
                    NIP = nip,
                    IPAddress = ipAddress,
                    AttemptedAt = DateTime.UtcNow
                };

                // Call government API
                var apiResult = await CallGovernmentAPIAsync(nip);

                log.WasSuccessful = apiResult.IsValid;
                log.ResponseCode = apiResult.ResponseCode;
                log.ErrorMessage = apiResult.ErrorMessage;

                await _unitOfWork.Repository<NIPVerificationLog>().AddAsync(log);

                if (apiResult.IsValid && apiResult.Subject != null)
                {
                    // Create or update business profile
                    var existingProfile = await GetBusinessProfileAsync(userId);
                    
                    if (existingProfile != null)
                    {
                        // Preserve SECONDARY (user-provided) fields before overwriting with GOV data
                        var savedPhone = existingProfile.Phone;
                        var savedEmail = existingProfile.CompanyEmail;
                        var savedContact = existingProfile.ContactPerson;
                        var savedPosition = existingProfile.Position;

                        // Update PRIMARY fields from government API
                        existingProfile.NIP = nip;
                        existingProfile.CompanyName = apiResult.Subject.Name ?? "";
                        existingProfile.REGON = apiResult.Subject.Regon;
                        existingProfile.KRS = apiResult.Subject.Krs;
                        existingProfile.VATStatus = apiResult.Subject.StatusVat;
                        existingProfile.ResidenceAddress = apiResult.Subject.ResidenceAddress;
                        existingProfile.WorkingAddress = apiResult.Subject.WorkingAddress;
                        existingProfile.RegistrationLegalDate = apiResult.Subject.RegistrationLegalDate;
                        
                        // Restore SECONDARY fields (user-provided, not available from gov API)
                        existingProfile.Phone = savedPhone;
                        existingProfile.CompanyEmail = savedEmail;
                        existingProfile.ContactPerson = savedContact;
                        existingProfile.Position = savedPosition;

                        // Update verification metadata
                        existingProfile.IsVerified = true;
                        existingProfile.VerifiedAt = DateTime.UtcNow;
                        existingProfile.LastVerificationAttempt = DateTime.UtcNow;
                        existingProfile.GovernmentRequestId = apiResult.RequestId;
                        existingProfile.RawApiResponse = apiResult.RawResponse;
                        existingProfile.UpdatedAt = DateTime.UtcNow;
                        
                        result.BusinessProfile = existingProfile;
                    }
                    else
                    {
                        // Create new profile with PRIMARY (gov) fields only
                        var newProfile = new BusinessProfile
                        {
                            UserId = userId,
                            NIP = nip,
                            CompanyName = apiResult.Subject.Name ?? "",
                            REGON = apiResult.Subject.Regon,
                            KRS = apiResult.Subject.Krs,
                            VATStatus = apiResult.Subject.StatusVat,
                            ResidenceAddress = apiResult.Subject.ResidenceAddress,
                            WorkingAddress = apiResult.Subject.WorkingAddress,
                            RegistrationLegalDate = apiResult.Subject.RegistrationLegalDate,
                            // SECONDARY fields left null - will be set by caller
                            IsVerified = true,
                            VerifiedAt = DateTime.UtcNow,
                            LastVerificationAttempt = DateTime.UtcNow,
                            GovernmentRequestId = apiResult.RequestId,
                            RawApiResponse = apiResult.RawResponse
                        };

                        await _unitOfWork.Repository<BusinessProfile>().AddAsync(newProfile);
                        result.BusinessProfile = newProfile;
                    }

                    result.IsValid = true;
                    result.CompanyName = apiResult.Subject.Name;
                    result.VATStatus = apiResult.Subject.StatusVat;
                    result.Address = apiResult.Subject.WorkingAddress ?? apiResult.Subject.ResidenceAddress;
                }
                else
                {
                    result.IsValid = false;
                    result.ErrorMessage = apiResult.ErrorMessage ?? "NIP not found in government registry.";
                }

                await _unitOfWork.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error validating NIP {NIP} for user {UserId}", nip, userId);
                result.IsValid = false;
                result.ErrorMessage = "An error occurred during verification. Please try again later.";
                return result;
            }
        }

        public async Task<(bool CanAttempt, TimeSpan? WaitTime)> CanAttemptVerificationAsync(string userId)
        {
            var now = DateTime.UtcNow;
            var dayStart = now.Date;

            // Get attempts in the last 24 hours
            var recentAttempts = await _unitOfWork.Repository<NIPVerificationLog>()
                .FindAsync(l => l.UserId == userId && l.AttemptedAt >= dayStart);

            var attemptCount = recentAttempts.Count();

            if (attemptCount >= MaxAttemptsPerDay)
            {
                var oldestAttempt = recentAttempts.OrderBy(a => a.AttemptedAt).First();
                var waitTime = oldestAttempt.AttemptedAt.AddDays(1) - now;
                return (false, waitTime);
            }

            // Check cooldown from last attempt
            var lastAttempt = recentAttempts.OrderByDescending(a => a.AttemptedAt).FirstOrDefault();
            if (lastAttempt != null)
            {
                var timeSinceLastAttempt = now - lastAttempt.AttemptedAt;
                if (timeSinceLastAttempt.TotalMinutes < CooldownMinutes)
                {
                    var waitTime = TimeSpan.FromMinutes(CooldownMinutes) - timeSinceLastAttempt;
                    return (false, waitTime);
                }
            }

            return (true, null);
        }

        public async Task<BusinessProfile?> GetBusinessProfileAsync(string userId)
        {
            var profiles = await _unitOfWork.Repository<BusinessProfile>()
                .FindAsync(p => p.UserId == userId);
            return profiles.FirstOrDefault();
        }

        public async Task<bool> ToggleBusinessModeAsync(string userId)
        {
            var profile = await GetBusinessProfileAsync(userId);
            if (profile == null || !profile.IsVerified)
            {
                return false;
            }

            profile.IsBusinessModeActive = !profile.IsBusinessModeActive;
            profile.UpdatedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();

            return profile.IsBusinessModeActive;
        }

        private async Task<GovernmentAPIResult> CallGovernmentAPIAsync(string nip)
        {
            var result = new GovernmentAPIResult();

            try
            {
                var useTestApi = _configuration.GetValue<bool>("NIPValidation:UseTestApi", false);
                var baseUrl = useTestApi ? TestApiUrl : ProductionApiUrl;
                var date = DateTime.UtcNow.ToString("yyyy-MM-dd");
                var url = $"{baseUrl}/api/search/nip/{nip}?date={date}";

                var client = _httpClientFactory.CreateClient("NIPValidation");
                client.Timeout = TimeSpan.FromSeconds(30);

                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                result.RawResponse = content;

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = JsonSerializer.Deserialize<NIPApiResponse>(content, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (apiResponse?.Result?.Subject != null)
                    {
                        result.IsValid = true;
                        result.Subject = apiResponse.Result.Subject;
                        result.RequestId = apiResponse.Result.RequestId;
                        result.ResponseCode = "OK";
                    }
                    else
                    {
                        result.IsValid = false;
                        result.ErrorMessage = "NIP not found in registry.";
                        result.ResponseCode = "NOT_FOUND";
                    }
                }
                else
                {
                    result.IsValid = false;
                    result.ErrorMessage = $"API error: {response.StatusCode}";
                    result.ResponseCode = response.StatusCode.ToString();
                }
            }
            catch (TaskCanceledException)
            {
                result.IsValid = false;
                result.ErrorMessage = "Government API timeout. Please try again.";
                result.ResponseCode = "TIMEOUT";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling government API for NIP");
                result.IsValid = false;
                result.ErrorMessage = "Unable to contact government API.";
                result.ResponseCode = "ERROR";
            }

            return result;
        }

        private static string CleanNIP(string nip)
        {
            if (string.IsNullOrWhiteSpace(nip))
                return string.Empty;

            // Remove all non-digit characters (spaces, dashes, etc.)
            return new string(nip.Where(char.IsDigit).ToArray());
        }

        private static bool IsValidNIPFormat(string nip)
        {
            return !string.IsNullOrEmpty(nip) && nip.Length == 10 && nip.All(char.IsDigit);
        }

        private static bool ValidateNIPChecksum(string nip)
        {
            if (!IsValidNIPFormat(nip))
                return false;

            // NIP checksum weights
            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += weights[i] * (nip[i] - '0');
            }

            int checksum = sum % 11;
            
            // If checksum is 10, NIP is invalid
            if (checksum == 10)
                return false;

            return checksum == (nip[9] - '0');
        }
    }

    #region API Response Models

    public class NIPValidationResult
    {
        public bool IsValid { get; set; }
        public string? ErrorMessage { get; set; }
        public string? CompanyName { get; set; }
        public string? VATStatus { get; set; }
        public string? Address { get; set; }
        public bool RateLimited { get; set; }
        public BusinessProfile? BusinessProfile { get; set; }
    }

    public class GovernmentAPIResult
    {
        public bool IsValid { get; set; }
        public string? ErrorMessage { get; set; }
        public string? ResponseCode { get; set; }
        public string? RequestId { get; set; }
        public string? RawResponse { get; set; }
        public NIPSubject? Subject { get; set; }
    }

    public class NIPApiResponse
    {
        [JsonPropertyName("result")]
        public NIPResult? Result { get; set; }
    }

    public class NIPResult
    {
        [JsonPropertyName("subject")]
        public NIPSubject? Subject { get; set; }

        [JsonPropertyName("requestDateTime")]
        public string? RequestDateTime { get; set; }

        [JsonPropertyName("requestId")]
        public string? RequestId { get; set; }
    }

    public class NIPSubject
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("nip")]
        public string? Nip { get; set; }

        [JsonPropertyName("statusVat")]
        public string? StatusVat { get; set; }

        [JsonPropertyName("regon")]
        public string? Regon { get; set; }

        [JsonPropertyName("krs")]
        public string? Krs { get; set; }

        [JsonPropertyName("residenceAddress")]
        public string? ResidenceAddress { get; set; }

        [JsonPropertyName("workingAddress")]
        public string? WorkingAddress { get; set; }

        [JsonPropertyName("registrationLegalDate")]
        public DateTime? RegistrationLegalDate { get; set; }

        [JsonPropertyName("registrationDenialDate")]
        public DateTime? RegistrationDenialDate { get; set; }

        [JsonPropertyName("removalDate")]
        public DateTime? RemovalDate { get; set; }

        [JsonPropertyName("restorationDate")]
        public DateTime? RestorationDate { get; set; }

        [JsonPropertyName("accountNumbers")]
        public List<string>? AccountNumbers { get; set; }

        [JsonPropertyName("hasVirtualAccounts")]
        public bool HasVirtualAccounts { get; set; }
    }

    #endregion
}
