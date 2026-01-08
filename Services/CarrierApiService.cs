using Kokomija.Data;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kokomija.Services
{
    /// <summary>
    /// Interface for shipping carrier API integrations
    /// </summary>
    public interface ICarrierApiService
    {
        // Tracking
        Task<TrackingResult> GetTrackingInfoAsync(string trackingNumber, string carrierCode);
        Task<TrackingResult> GetTrackingInfoByShipmentIdAsync(int shipmentId);
        Task<List<TrackingEvent>> GetTrackingHistoryAsync(string trackingNumber, string carrierCode);
        
        // Shipment Creation
        Task<ShipmentCreationResult> CreateShipmentAsync(CreateShipmentRequest request);
        Task<LabelGenerationResult> GenerateLabelAsync(int shipmentId);
        Task<(bool Success, string Message)> CancelShipmentAsync(int shipmentId);
        
        // Rate Calculation
        Task<List<ShippingQuote>> GetShippingQuotesAsync(ShippingQuoteRequest request);
        Task<List<ShippingQuote>> GetLiveRatesAsync(string destinationCountry, decimal orderTotal, PackageInfo? package = null);
        
        // Delivery Estimates
        Task<DeliveryEstimate> GetDeliveryEstimateAsync(int shippingRateId, string? destinationCountry = null);
        Task<List<DeliveryEstimate>> GetAllDeliveryEstimatesAsync(string? destinationCountry = null);
        
        // Webhook Processing
        Task<(bool Success, string Message)> ProcessWebhookAsync(string carrierCode, string payload, string signature);
        
        // Carrier Status
        Task<CarrierStatus> CheckCarrierStatusAsync(string carrierCode);
        Task<List<CarrierStatus>> GetAllCarrierStatusesAsync();
        
        // Provider Management
        Task<ShippingProvider?> GetProviderByCodeAsync(string carrierCode);
        Task<List<ShippingProvider>> GetActiveProvidersAsync();
    }

    #region DTOs

    public class TrackingResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string TrackingNumber { get; set; } = string.Empty;
        public string CarrierCode { get; set; } = string.Empty;
        public string CarrierName { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
        public DateTime? EstimatedDelivery { get; set; }
        public DateTime? ActualDelivery { get; set; }
        public string? SignedBy { get; set; }
        public string? CurrentLocation { get; set; }
        public string? TrackingUrl { get; set; } // Direct link to carrier's tracking page
        public List<TrackingEvent> Events { get; set; } = new();
    }

    public class TrackingEvent
    {
        public DateTime Timestamp { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }

    public class CreateShipmentRequest
    {
        public int OrderId { get; set; }
        public int ShippingProviderId { get; set; }
        public int? ShippingRateId { get; set; }
        public string ServiceType { get; set; } = "standard"; // standard, express, overnight
        public AddressInfo Sender { get; set; } = new();
        public AddressInfo Recipient { get; set; } = new();
        public PackageInfo Package { get; set; } = new();
        public bool SignatureRequired { get; set; }
        public bool InsuranceRequired { get; set; }
        public decimal? InsuredValue { get; set; }
        public string? SpecialInstructions { get; set; }
        public string? Reference { get; set; } // Order reference number
    }

    public class AddressInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Street2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class PackageInfo
    {
        public decimal Weight { get; set; } // kg
        public decimal Length { get; set; } // cm
        public decimal Width { get; set; }  // cm
        public decimal Height { get; set; } // cm
        public decimal DeclaredValue { get; set; }
        public string Currency { get; set; } = "PLN";
        public int Quantity { get; set; } = 1;
        public string? PackageType { get; set; } // "box", "envelope", "parcel"
    }

    public class ShipmentCreationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? TrackingNumber { get; set; }
        public string? CarrierShipmentId { get; set; }
        public string? LabelUrl { get; set; }
        public decimal? ShippingCost { get; set; }
        public DateTime? EstimatedDelivery { get; set; }
        public int? EstimatedDaysMin { get; set; }
        public int? EstimatedDaysMax { get; set; }
    }

    public class LabelGenerationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? LabelUrl { get; set; }
        public byte[]? LabelData { get; set; }
        public string? LabelFormat { get; set; } // PDF, PNG, ZPL
    }

    public class ShippingQuoteRequest
    {
        public AddressInfo Origin { get; set; } = new();
        public AddressInfo Destination { get; set; } = new();
        public PackageInfo Package { get; set; } = new();
        public decimal OrderTotal { get; set; }
        public List<string>? PreferredCarriers { get; set; }
        public bool IncludeInactiveRates { get; set; } = false;
    }

    public class ShippingQuote
    {
        public int RateId { get; set; }
        public int ProviderId { get; set; }
        public string CarrierCode { get; set; } = string.Empty;
        public string CarrierName { get; set; } = string.Empty;
        public string? CarrierLogo { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string? ServiceDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? OriginalPrice { get; set; } // Before free shipping discount
        public string Currency { get; set; } = "PLN";
        public int EstimatedDaysMin { get; set; }
        public int EstimatedDaysMax { get; set; }
        public DateTime? EstimatedDeliveryDate { get; set; }
        public bool GuaranteedDelivery { get; set; }
        public bool IsFreeShipping { get; set; }
        public decimal? FreeShippingThreshold { get; set; }
        public bool IsLiveRate { get; set; } // True if from API, false if from database
    }

    public class DeliveryEstimate
    {
        public int RateId { get; set; }
        public int ProviderId { get; set; }
        public string CarrierCode { get; set; } = string.Empty;
        public string CarrierName { get; set; } = string.Empty;
        public string? CarrierLogo { get; set; }
        public string RateName { get; set; } = string.Empty;
        public string? RateDescription { get; set; }
        public int MinDays { get; set; }
        public int MaxDays { get; set; }
        public DateTime EstimatedDeliveryMin { get; set; }
        public DateTime EstimatedDeliveryMax { get; set; }
        public string DeliveryEstimateText { get; set; } = string.Empty; // "3-5 business days"
        public decimal BasePrice { get; set; }
        public decimal? FreeShippingThreshold { get; set; }
        public bool IsActive { get; set; }
    }

    public class CarrierStatus
    {
        public int ProviderId { get; set; }
        public string CarrierCode { get; set; } = string.Empty;
        public string CarrierName { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public bool IsActive { get; set; }
        public bool IsConfigured { get; set; }
        public bool IsConnected { get; set; }
        public bool HasApiKey { get; set; }
        public bool SupportsTracking { get; set; }
        public bool SupportsLabelGeneration { get; set; }
        public bool SupportsRateCalculation { get; set; }
        public bool SupportsWebhooks { get; set; }
        public DateTime? LastSuccessfulCall { get; set; }
        public string? ErrorMessage { get; set; }
        public string Status => IsConnected ? "Connected" : (IsConfigured ? "Configured" : "Not Configured");
        public int ActiveRatesCount { get; set; }
    }

    #endregion

    /// <summary>
    /// Generic carrier API service implementation that works with any configured shipping provider
    /// </summary>
    public class CarrierApiService : ICarrierApiService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CarrierApiService> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public CarrierApiService(
            ApplicationDbContext context,
            ILogger<CarrierApiService> logger,
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        #region Provider Management

        public async Task<ShippingProvider?> GetProviderByCodeAsync(string carrierCode)
        {
            return await _context.ShippingProviders
                .Include(p => p.ShippingRates.Where(r => r.IsActive))
                .FirstOrDefaultAsync(p => p.Code == carrierCode && p.IsActive);
        }

        public async Task<List<ShippingProvider>> GetActiveProvidersAsync()
        {
            return await _context.ShippingProviders
                .Include(p => p.ShippingRates.Where(r => r.IsActive))
                .Where(p => p.IsActive)
                .OrderBy(p => p.Priority)
                .ThenBy(p => p.Name)
                .ToListAsync();
        }

        #endregion

        #region Delivery Estimates

        public async Task<DeliveryEstimate> GetDeliveryEstimateAsync(int shippingRateId, string? destinationCountry = null)
        {
            var rate = await _context.ShippingRates
                .Include(r => r.ShippingProvider)
                .FirstOrDefaultAsync(r => r.Id == shippingRateId);

            if (rate == null)
            {
                return new DeliveryEstimate
                {
                    RateId = shippingRateId,
                    MinDays = 3,
                    MaxDays = 7,
                    DeliveryEstimateText = "3-7 business days"
                };
            }

            return CreateDeliveryEstimate(rate);
        }

        public async Task<List<DeliveryEstimate>> GetAllDeliveryEstimatesAsync(string? destinationCountry = null)
        {
            var query = _context.ShippingRates
                .Include(r => r.ShippingProvider)
                .Where(r => r.IsActive && r.ShippingProvider.IsActive);

            if (!string.IsNullOrEmpty(destinationCountry))
            {
                query = query.Where(r => r.CountryCode == null || r.CountryCode == destinationCountry);
            }

            var rates = await query
                .OrderBy(r => r.ShippingProvider.Priority)
                .ThenBy(r => r.MinDeliveryDays)
                .ToListAsync();

            return rates.Select(CreateDeliveryEstimate).ToList();
        }

        private DeliveryEstimate CreateDeliveryEstimate(ShippingRate rate)
        {
            var minDays = rate.MinDeliveryDays > 0 ? rate.MinDeliveryDays : rate.ShippingProvider.EstimatedDeliveryDays;
            var maxDays = rate.MaxDeliveryDays > 0 ? rate.MaxDeliveryDays : rate.ShippingProvider.EstimatedDeliveryDays + 2;

            // Calculate business days (skip weekends)
            var estimatedMinDate = AddBusinessDays(DateTime.UtcNow, minDays);
            var estimatedMaxDate = AddBusinessDays(DateTime.UtcNow, maxDays);

            return new DeliveryEstimate
            {
                RateId = rate.Id,
                ProviderId = rate.ShippingProviderId,
                CarrierCode = rate.ShippingProvider.Code,
                CarrierName = rate.ShippingProvider.Name,
                CarrierLogo = rate.ShippingProvider.LogoUrl,
                RateName = rate.Name,
                RateDescription = rate.Description,
                MinDays = minDays,
                MaxDays = maxDays,
                EstimatedDeliveryMin = estimatedMinDate,
                EstimatedDeliveryMax = estimatedMaxDate,
                DeliveryEstimateText = minDays == maxDays 
                    ? $"{minDays} business day{(minDays > 1 ? "s" : "")}"
                    : $"{minDays}-{maxDays} business days",
                BasePrice = rate.BasePrice,
                FreeShippingThreshold = rate.FreeShippingThreshold,
                IsActive = rate.IsActive
            };
        }

        private DateTime AddBusinessDays(DateTime startDate, int businessDays)
        {
            var currentDate = startDate;
            var daysAdded = 0;

            while (daysAdded < businessDays)
            {
                currentDate = currentDate.AddDays(1);
                if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    daysAdded++;
                }
            }

            return currentDate;
        }

        #endregion

        #region Tracking

        public async Task<TrackingResult> GetTrackingInfoAsync(string trackingNumber, string carrierCode)
        {
            try
            {
                var provider = await GetProviderByCodeAsync(carrierCode);

                if (provider == null)
                {
                    return new TrackingResult
                    {
                        Success = false,
                        Message = $"Carrier '{carrierCode}' not found or not active.",
                        TrackingNumber = trackingNumber,
                        CarrierCode = carrierCode
                    };
                }

                // Try to get live tracking if API is configured
                if (provider.SupportsTracking && !string.IsNullOrEmpty(provider.ApiKey))
                {
                    var liveResult = await GetLiveTrackingAsync(trackingNumber, provider);
                    if (liveResult.Success)
                    {
                        // Update provider's last API call status
                        await UpdateProviderApiStatus(provider, true, null);
                        return liveResult;
                    }
                }

                // Fallback to generating tracking URL
                var result = CreateTrackingResultWithUrl(trackingNumber, provider);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting tracking info for {TrackingNumber} via {Carrier}", trackingNumber, carrierCode);
                return new TrackingResult
                {
                    Success = false,
                    Message = "An error occurred while fetching tracking information.",
                    TrackingNumber = trackingNumber,
                    CarrierCode = carrierCode
                };
            }
        }

        public async Task<TrackingResult> GetTrackingInfoByShipmentIdAsync(int shipmentId)
        {
            var shipment = await _context.OrderShipments
                .Include(s => s.ShippingProvider)
                .FirstOrDefaultAsync(s => s.Id == shipmentId);

            if (shipment == null || string.IsNullOrEmpty(shipment.TrackingNumber))
            {
                return new TrackingResult
                {
                    Success = false,
                    Message = "Shipment not found or no tracking number available."
                };
            }

            return await GetTrackingInfoAsync(shipment.TrackingNumber, shipment.ShippingProvider.Code);
        }

        public async Task<List<TrackingEvent>> GetTrackingHistoryAsync(string trackingNumber, string carrierCode)
        {
            var result = await GetTrackingInfoAsync(trackingNumber, carrierCode);
            return result.Events;
        }

        private async Task<TrackingResult> GetLiveTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            try
            {
                var client = CreateHttpClientForProvider(provider);
                var trackingEndpoint = BuildTrackingEndpoint(provider, trackingNumber);

                if (string.IsNullOrEmpty(trackingEndpoint))
                {
                    return new TrackingResult { Success = false, Message = "Tracking endpoint not configured." };
                }

                var response = await client.GetAsync(trackingEndpoint);
                
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return ParseTrackingResponse(trackingNumber, provider, content);
                }

                _logger.LogWarning("Tracking API call failed for {Carrier}: {StatusCode}", provider.Code, response.StatusCode);
                return new TrackingResult { Success = false, Message = $"API returned {response.StatusCode}" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling tracking API for {Carrier}", provider.Code);
                await UpdateProviderApiStatus(provider, false, ex.Message);
                return new TrackingResult { Success = false, Message = ex.Message };
            }
        }

        private string? BuildTrackingEndpoint(ShippingProvider provider, string trackingNumber)
        {
            if (string.IsNullOrEmpty(provider.TrackingApiEndpoint))
                return null;

            var baseUrl = provider.UseSandbox && !string.IsNullOrEmpty(provider.SandboxApiBaseUrl)
                ? provider.SandboxApiBaseUrl
                : provider.ApiBaseUrl;

            if (string.IsNullOrEmpty(baseUrl))
                return null;

            var endpoint = provider.TrackingApiEndpoint.Replace("{trackingNumber}", trackingNumber);
            return $"{baseUrl.TrimEnd('/')}/{endpoint.TrimStart('/')}";
        }

        private TrackingResult ParseTrackingResponse(string trackingNumber, ShippingProvider provider, string jsonResponse)
        {
            // Generic JSON parsing - adapt based on carrier's response structure
            // Most carriers return similar structures with status, location, events
            try
            {
                using var doc = JsonDocument.Parse(jsonResponse);
                var root = doc.RootElement;

                // Try common response patterns
                var events = new List<TrackingEvent>();
                string? currentStatus = null;
                string? currentLocation = null;

                // Pattern 1: DHL-style { shipments: [{ status: {...}, events: [...] }] }
                if (root.TryGetProperty("shipments", out var shipments) && shipments.GetArrayLength() > 0)
                {
                    var shipment = shipments[0];
                    if (shipment.TryGetProperty("status", out var status))
                    {
                        currentStatus = status.TryGetProperty("status", out var s) ? s.GetString() : null;
                        currentLocation = status.TryGetProperty("location", out var l) ? l.GetString() : null;
                    }
                }
                // Pattern 2: { trackingNumber, status, events: [...] }
                else if (root.TryGetProperty("status", out var statusProp))
                {
                    currentStatus = statusProp.GetString();
                }

                // Parse events if available
                if (root.TryGetProperty("events", out var eventsArray))
                {
                    foreach (var evt in eventsArray.EnumerateArray())
                    {
                        events.Add(new TrackingEvent
                        {
                            Timestamp = evt.TryGetProperty("timestamp", out var ts) 
                                ? DateTime.Parse(ts.GetString()!) 
                                : DateTime.UtcNow,
                            Status = evt.TryGetProperty("status", out var es) ? es.GetString()! : "",
                            Description = evt.TryGetProperty("description", out var ed) ? ed.GetString()! : "",
                            Location = evt.TryGetProperty("location", out var el) ? el.GetString() : null
                        });
                    }
                }

                return new TrackingResult
                {
                    Success = true,
                    Message = "Tracking information retrieved from carrier API.",
                    TrackingNumber = trackingNumber,
                    CarrierCode = provider.Code,
                    CarrierName = provider.Name,
                    CurrentStatus = currentStatus ?? "UNKNOWN",
                    CurrentLocation = currentLocation,
                    TrackingUrl = BuildTrackingUrl(provider, trackingNumber),
                    Events = events
                };
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to parse tracking response for {Carrier}", provider.Code);
                return CreateTrackingResultWithUrl(trackingNumber, provider);
            }
        }

        private TrackingResult CreateTrackingResultWithUrl(string trackingNumber, ShippingProvider provider)
        {
            return new TrackingResult
            {
                Success = true,
                Message = "Tracking URL generated. Click to view on carrier's website.",
                TrackingNumber = trackingNumber,
                CarrierCode = provider.Code,
                CarrierName = provider.Name,
                CurrentStatus = "TRACKING_AVAILABLE",
                StatusDescription = "Click the tracking link to view current status on carrier website.",
                TrackingUrl = BuildTrackingUrl(provider, trackingNumber),
                Events = new List<TrackingEvent>()
            };
        }

        private string? BuildTrackingUrl(ShippingProvider provider, string trackingNumber)
        {
            if (string.IsNullOrEmpty(provider.TrackingUrlTemplate))
                return null;

            return provider.TrackingUrlTemplate.Replace("{trackingNumber}", trackingNumber);
        }

        #endregion

        #region Shipment Creation

        public async Task<ShipmentCreationResult> CreateShipmentAsync(CreateShipmentRequest request)
        {
            try
            {
                var provider = await _context.ShippingProviders.FindAsync(request.ShippingProviderId);
                if (provider == null)
                {
                    return new ShipmentCreationResult
                    {
                        Success = false,
                        Message = "Shipping provider not found."
                    };
                }

                // Get shipping rate for delivery estimates
                ShippingRate? shippingRate = null;
                if (request.ShippingRateId.HasValue)
                {
                    shippingRate = await _context.ShippingRates.FindAsync(request.ShippingRateId.Value);
                }
                else
                {
                    shippingRate = await _context.ShippingRates
                        .Where(r => r.ShippingProviderId == request.ShippingProviderId && r.IsActive)
                        .FirstOrDefaultAsync();
                }

                ShipmentCreationResult result;

                // Try live API if configured
                if (!string.IsNullOrEmpty(provider.ApiKey) && !string.IsNullOrEmpty(provider.ShipmentApiEndpoint))
                {
                    result = await CreateLiveShipmentAsync(request, provider);
                }
                else
                {
                    // Generate mock tracking number for manual processing
                    result = CreateManualShipment(request, provider);
                }

                // Add delivery estimates from database rate
                if (shippingRate != null)
                {
                    result.EstimatedDaysMin = shippingRate.MinDeliveryDays;
                    result.EstimatedDaysMax = shippingRate.MaxDeliveryDays;
                    result.EstimatedDelivery = AddBusinessDays(DateTime.UtcNow, shippingRate.MaxDeliveryDays);
                    result.ShippingCost ??= shippingRate.BasePrice;
                }

                if (result.Success && !string.IsNullOrEmpty(result.TrackingNumber))
                {
                    // Create shipment record in database
                    var shipment = new OrderShipment
                    {
                        OrderId = request.OrderId,
                        ShippingProviderId = request.ShippingProviderId,
                        ShippingRateId = shippingRate?.Id ?? 1,
                        TrackingNumber = result.TrackingNumber,
                        Status = ShipmentStatus.Pending,
                        ShippingCost = result.ShippingCost ?? shippingRate?.BasePrice ?? 0,
                        EstimatedDeliveryDate = result.EstimatedDelivery,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    _context.OrderShipments.Add(shipment);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Shipment created for order {OrderId} with tracking {TrackingNumber}, estimated delivery: {EstimatedDays} days",
                        request.OrderId, result.TrackingNumber, result.EstimatedDaysMax);
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating shipment for order {OrderId}", request.OrderId);
                return new ShipmentCreationResult
                {
                    Success = false,
                    Message = "An error occurred while creating the shipment."
                };
            }
        }

        private async Task<ShipmentCreationResult> CreateLiveShipmentAsync(CreateShipmentRequest request, ShippingProvider provider)
        {
            try
            {
                var client = CreateHttpClientForProvider(provider);
                var endpoint = BuildShipmentEndpoint(provider);

                if (string.IsNullOrEmpty(endpoint))
                {
                    return CreateManualShipment(request, provider);
                }

                // Build carrier-specific payload
                var payload = BuildShipmentPayload(request, provider);
                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(endpoint, content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = ParseShipmentResponse(responseContent, provider);
                    await UpdateProviderApiStatus(provider, true, null);
                    return result;
                }

                _logger.LogWarning("Shipment API call failed for {Carrier}: {StatusCode}", provider.Code, response.StatusCode);
                await UpdateProviderApiStatus(provider, false, $"API returned {response.StatusCode}");
                return CreateManualShipment(request, provider);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling shipment API for {Carrier}", provider.Code);
                await UpdateProviderApiStatus(provider, false, ex.Message);
                return CreateManualShipment(request, provider);
            }
        }

        private string? BuildShipmentEndpoint(ShippingProvider provider)
        {
            if (string.IsNullOrEmpty(provider.ShipmentApiEndpoint))
                return null;

            var baseUrl = provider.UseSandbox && !string.IsNullOrEmpty(provider.SandboxApiBaseUrl)
                ? provider.SandboxApiBaseUrl
                : provider.ApiBaseUrl;

            if (string.IsNullOrEmpty(baseUrl))
                return null;

            return $"{baseUrl.TrimEnd('/')}/{provider.ShipmentApiEndpoint.TrimStart('/')}";
        }

        private object BuildShipmentPayload(CreateShipmentRequest request, ShippingProvider provider)
        {
            // Generic payload structure - carriers may need specific formats
            return new
            {
                reference = request.Reference ?? $"ORDER-{request.OrderId}",
                service = request.ServiceType,
                sender = request.Sender,
                recipient = request.Recipient,
                package = request.Package,
                options = new
                {
                    signatureRequired = request.SignatureRequired,
                    insurance = request.InsuranceRequired ? new { value = request.InsuredValue, currency = request.Package.Currency } : null
                }
            };
        }

        private ShipmentCreationResult ParseShipmentResponse(string jsonResponse, ShippingProvider provider)
        {
            try
            {
                using var doc = JsonDocument.Parse(jsonResponse);
                var root = doc.RootElement;

                string? trackingNumber = null;
                string? shipmentId = null;
                string? labelUrl = null;

                // Common response patterns
                if (root.TryGetProperty("trackingNumber", out var tn))
                    trackingNumber = tn.GetString();
                else if (root.TryGetProperty("tracking_number", out var tn2))
                    trackingNumber = tn2.GetString();

                if (root.TryGetProperty("shipmentId", out var si))
                    shipmentId = si.GetString();
                else if (root.TryGetProperty("id", out var si2))
                    shipmentId = si2.GetString();

                if (root.TryGetProperty("labelUrl", out var lu))
                    labelUrl = lu.GetString();
                else if (root.TryGetProperty("label_url", out var lu2))
                    labelUrl = lu2.GetString();

                return new ShipmentCreationResult
                {
                    Success = !string.IsNullOrEmpty(trackingNumber),
                    Message = !string.IsNullOrEmpty(trackingNumber) ? "Shipment created via carrier API." : "No tracking number returned.",
                    TrackingNumber = trackingNumber,
                    CarrierShipmentId = shipmentId,
                    LabelUrl = labelUrl
                };
            }
            catch
            {
                return CreateManualShipment(new CreateShipmentRequest(), provider);
            }
        }

        private ShipmentCreationResult CreateManualShipment(CreateShipmentRequest request, ShippingProvider provider)
        {
            // Generate tracking number for manual processing
            var trackingNumber = $"{provider.Code.ToUpper()}{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";

            return new ShipmentCreationResult
            {
                Success = true,
                Message = "Shipment reference created. Please process manually with carrier.",
                TrackingNumber = trackingNumber
            };
        }

        public async Task<LabelGenerationResult> GenerateLabelAsync(int shipmentId)
        {
            try
            {
                var shipment = await _context.OrderShipments
                    .Include(s => s.ShippingProvider)
                    .Include(s => s.Order)
                    .FirstOrDefaultAsync(s => s.Id == shipmentId);

                if (shipment == null)
                {
                    return new LabelGenerationResult
                    {
                        Success = false,
                        Message = "Shipment not found."
                    };
                }

                var provider = shipment.ShippingProvider;

                // Try live API if configured
                if (provider.SupportsLabelGeneration && !string.IsNullOrEmpty(provider.ApiKey) && !string.IsNullOrEmpty(provider.LabelApiEndpoint))
                {
                    var result = await GenerateLiveLabelAsync(shipment, provider);
                    if (result.Success) return result;
                }

                return new LabelGenerationResult
                {
                    Success = true,
                    Message = "Please generate label manually through carrier's portal.",
                    LabelFormat = "MANUAL"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating label for shipment {ShipmentId}", shipmentId);
                return new LabelGenerationResult
                {
                    Success = false,
                    Message = "An error occurred while generating the label."
                };
            }
        }

        private async Task<LabelGenerationResult> GenerateLiveLabelAsync(OrderShipment shipment, ShippingProvider provider)
        {
            // Implementation depends on carrier API
            await Task.CompletedTask;
            return new LabelGenerationResult
            {
                Success = false,
                Message = "Label API not implemented for this carrier."
            };
        }

        public async Task<(bool Success, string Message)> CancelShipmentAsync(int shipmentId)
        {
            try
            {
                var shipment = await _context.OrderShipments
                    .Include(s => s.ShippingProvider)
                    .FirstOrDefaultAsync(s => s.Id == shipmentId);

                if (shipment == null)
                {
                    return (false, "Shipment not found.");
                }

                if (shipment.Status == ShipmentStatus.Delivered)
                {
                    return (false, "Cannot cancel a delivered shipment.");
                }

                if (shipment.Status == ShipmentStatus.InTransit)
                {
                    return (false, "Cannot cancel a shipment that is already in transit. Please contact the carrier directly.");
                }

                // TODO: Call carrier API to cancel shipment if supported

                shipment.Status = ShipmentStatus.Failed;
                shipment.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Shipment {ShipmentId} cancelled", shipmentId);
                return (true, "Shipment cancelled successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling shipment {ShipmentId}", shipmentId);
                return (false, "An error occurred while cancelling the shipment.");
            }
        }

        #endregion

        #region Rate Calculation

        public async Task<List<ShippingQuote>> GetShippingQuotesAsync(ShippingQuoteRequest request)
        {
            var quotes = new List<ShippingQuote>();

            try
            {
                var providers = await GetActiveProvidersAsync();

                if (request.PreferredCarriers?.Any() == true)
                {
                    providers = providers
                        .Where(p => request.PreferredCarriers.Contains(p.Code, StringComparer.OrdinalIgnoreCase))
                        .ToList();
                }

                foreach (var provider in providers)
                {
                    var providerQuotes = await GetProviderQuotesAsync(provider, request);
                    quotes.AddRange(providerQuotes);
                }

                return quotes.OrderBy(q => q.Price).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting shipping quotes");
                return quotes;
            }
        }

        public async Task<List<ShippingQuote>> GetLiveRatesAsync(string destinationCountry, decimal orderTotal, PackageInfo? package = null)
        {
            var request = new ShippingQuoteRequest
            {
                Destination = new AddressInfo { Country = destinationCountry },
                OrderTotal = orderTotal,
                Package = package ?? new PackageInfo { Weight = 1, Length = 20, Width = 15, Height = 10 }
            };

            return await GetShippingQuotesAsync(request);
        }

        private async Task<List<ShippingQuote>> GetProviderQuotesAsync(ShippingProvider provider, ShippingQuoteRequest request)
        {
            var quotes = new List<ShippingQuote>();

            // Try live rates if configured
            if (provider.SupportsRateCalculation && !string.IsNullOrEmpty(provider.ApiKey) && !string.IsNullOrEmpty(provider.RatesApiEndpoint))
            {
                var liveQuotes = await GetLiveProviderRatesAsync(provider, request);
                if (liveQuotes.Any())
                {
                    return liveQuotes;
                }
            }

            // Fallback to database rates
            var rates = await _context.ShippingRates
                .Where(r => r.ShippingProviderId == provider.Id && r.IsActive)
                .Where(r => r.CountryCode == null || r.CountryCode == request.Destination.Country)
                .ToListAsync();

            foreach (var rate in rates)
            {
                var isFreeShipping = rate.FreeShippingThreshold.HasValue && request.OrderTotal >= rate.FreeShippingThreshold.Value;
                
                quotes.Add(new ShippingQuote
                {
                    RateId = rate.Id,
                    ProviderId = provider.Id,
                    CarrierCode = provider.Code,
                    CarrierName = provider.Name,
                    CarrierLogo = provider.LogoUrl,
                    ServiceType = rate.Name.ToLower().Contains("express") ? "express" : "standard",
                    ServiceName = rate.Name,
                    ServiceDescription = rate.Description,
                    OriginalPrice = rate.BasePrice,
                    Price = isFreeShipping ? 0 : rate.BasePrice,
                    Currency = "PLN",
                    EstimatedDaysMin = rate.MinDeliveryDays,
                    EstimatedDaysMax = rate.MaxDeliveryDays,
                    EstimatedDeliveryDate = AddBusinessDays(DateTime.UtcNow, rate.MaxDeliveryDays),
                    IsFreeShipping = isFreeShipping,
                    FreeShippingThreshold = rate.FreeShippingThreshold,
                    IsLiveRate = false
                });
            }

            return quotes;
        }

        private async Task<List<ShippingQuote>> GetLiveProviderRatesAsync(ShippingProvider provider, ShippingQuoteRequest request)
        {
            // Implementation for live rate fetching from carrier API
            // Return empty list to fall back to database rates
            await Task.CompletedTask;
            return new List<ShippingQuote>();
        }

        #endregion

        #region Webhook Processing

        public async Task<(bool Success, string Message)> ProcessWebhookAsync(string carrierCode, string payload, string signature)
        {
            try
            {
                var provider = await GetProviderByCodeAsync(carrierCode);

                if (provider == null)
                {
                    return (false, "Carrier not found.");
                }

                if (!provider.SupportsWebhooks)
                {
                    return (false, "Webhooks not supported for this carrier.");
                }

                // Verify webhook signature
                if (!string.IsNullOrEmpty(provider.WebhookSecret))
                {
                    if (!VerifyWebhookSignature(payload, signature, provider.WebhookSecret))
                    {
                        _logger.LogWarning("Invalid webhook signature for carrier {CarrierCode}", carrierCode);
                        return (false, "Invalid webhook signature.");
                    }
                }

                // Process webhook payload
                var result = await ProcessWebhookPayloadAsync(payload, provider);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing webhook for carrier {CarrierCode}", carrierCode);
                return (false, "An error occurred while processing the webhook.");
            }
        }

        private bool VerifyWebhookSignature(string payload, string signature, string secret)
        {
            // Generic HMAC-SHA256 verification - adapt for specific carriers
            using var hmac = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(secret));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            var computedSignature = Convert.ToBase64String(hash);
            return computedSignature == signature;
        }

        private async Task<(bool Success, string Message)> ProcessWebhookPayloadAsync(string payload, ShippingProvider provider)
        {
            try
            {
                using var doc = JsonDocument.Parse(payload);
                var root = doc.RootElement;

                // Extract tracking number and status
                string? trackingNumber = null;
                string? newStatus = null;

                if (root.TryGetProperty("trackingNumber", out var tn))
                    trackingNumber = tn.GetString();
                else if (root.TryGetProperty("tracking_number", out var tn2))
                    trackingNumber = tn2.GetString();

                if (root.TryGetProperty("status", out var st))
                    newStatus = st.GetString();
                else if (root.TryGetProperty("event", out var ev))
                    newStatus = ev.GetString();

                if (string.IsNullOrEmpty(trackingNumber))
                {
                    return (false, "No tracking number in webhook payload.");
                }

                // Find and update shipment
                var shipment = await _context.OrderShipments
                    .FirstOrDefaultAsync(s => s.TrackingNumber == trackingNumber);

                if (shipment != null && !string.IsNullOrEmpty(newStatus))
                {
                    var mappedStatus = MapCarrierStatusToShipmentStatus(newStatus);
                    shipment.Status = mappedStatus;
                    shipment.UpdatedAt = DateTime.UtcNow;

                    // Add tracking event
                    var trackingEvent = new ShipmentTrackingEvent
                    {
                        OrderShipmentId = shipment.Id,
                        Status = newStatus,
                        Description = root.TryGetProperty("description", out var desc) ? desc.GetString() ?? newStatus : newStatus,
                        Location = root.TryGetProperty("location", out var loc) ? loc.GetString() : null,
                        EventDate = DateTime.UtcNow
                    };
                    _context.ShipmentTrackingEvents.Add(trackingEvent);

                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Updated shipment {TrackingNumber} status to {Status} via webhook", trackingNumber, newStatus);
                }

                return (true, "Webhook processed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error parsing webhook payload");
                return (false, "Failed to parse webhook payload.");
            }
        }

        private ShipmentStatus MapCarrierStatusToShipmentStatus(string carrierStatus)
        {
            return carrierStatus.ToUpper() switch
            {
                "DELIVERED" or "DELIVERY_COMPLETE" or "POD" => ShipmentStatus.Delivered,
                "IN_TRANSIT" or "TRANSIT" or "ON_THE_WAY" => ShipmentStatus.InTransit,
                "OUT_FOR_DELIVERY" or "WITH_DELIVERY_COURIER" => ShipmentStatus.OutForDelivery,
                "PICKED_UP" or "COLLECTED" or "SHIPPED" => ShipmentStatus.Shipped,
                "FAILED" or "EXCEPTION" or "RETURNED" => ShipmentStatus.Failed,
                _ => ShipmentStatus.Pending
            };
        }

        #endregion

        #region Carrier Status

        public async Task<CarrierStatus> CheckCarrierStatusAsync(string carrierCode)
        {
            var provider = await _context.ShippingProviders
                .Include(p => p.ShippingRates.Where(r => r.IsActive))
                .FirstOrDefaultAsync(p => p.Code == carrierCode);

            if (provider == null)
            {
                return new CarrierStatus
                {
                    CarrierCode = carrierCode,
                    CarrierName = carrierCode,
                    IsConfigured = false,
                    IsConnected = false
                };
            }

            var hasApiKey = !string.IsNullOrEmpty(provider.ApiKey);
            var isConnected = false;

            // Try a test API call if configured
            if (hasApiKey && !string.IsNullOrEmpty(provider.ApiBaseUrl))
            {
                isConnected = await TestCarrierConnectionAsync(provider);
            }

            return new CarrierStatus
            {
                ProviderId = provider.Id,
                CarrierCode = provider.Code,
                CarrierName = provider.Name,
                LogoUrl = provider.LogoUrl,
                IsActive = provider.IsActive,
                IsConfigured = true,
                HasApiKey = hasApiKey,
                IsConnected = isConnected,
                SupportsTracking = provider.SupportsTracking,
                SupportsLabelGeneration = provider.SupportsLabelGeneration,
                SupportsRateCalculation = provider.SupportsRateCalculation,
                SupportsWebhooks = provider.SupportsWebhooks,
                LastSuccessfulCall = provider.LastApiCallAt,
                ErrorMessage = provider.LastApiError,
                ActiveRatesCount = provider.ShippingRates.Count
            };
        }

        public async Task<List<CarrierStatus>> GetAllCarrierStatusesAsync()
        {
            var providers = await _context.ShippingProviders
                .Include(p => p.ShippingRates.Where(r => r.IsActive))
                .OrderBy(p => p.Priority)
                .ToListAsync();

            var statuses = new List<CarrierStatus>();

            foreach (var provider in providers)
            {
                var hasApiKey = !string.IsNullOrEmpty(provider.ApiKey);
                statuses.Add(new CarrierStatus
                {
                    ProviderId = provider.Id,
                    CarrierCode = provider.Code,
                    CarrierName = provider.Name,
                    LogoUrl = provider.LogoUrl,
                    IsActive = provider.IsActive,
                    IsConfigured = true,
                    HasApiKey = hasApiKey,
                    IsConnected = hasApiKey && provider.LastApiCallSuccess,
                    SupportsTracking = provider.SupportsTracking,
                    SupportsLabelGeneration = provider.SupportsLabelGeneration,
                    SupportsRateCalculation = provider.SupportsRateCalculation,
                    SupportsWebhooks = provider.SupportsWebhooks,
                    LastSuccessfulCall = provider.LastApiCallAt,
                    ErrorMessage = provider.LastApiError,
                    ActiveRatesCount = provider.ShippingRates.Count
                });
            }

            return statuses;
        }

        private async Task<bool> TestCarrierConnectionAsync(ShippingProvider provider)
        {
            try
            {
                var client = CreateHttpClientForProvider(provider);
                
                // Try a simple health check or tracking endpoint
                var baseUrl = provider.UseSandbox && !string.IsNullOrEmpty(provider.SandboxApiBaseUrl)
                    ? provider.SandboxApiBaseUrl
                    : provider.ApiBaseUrl;

                if (string.IsNullOrEmpty(baseUrl))
                    return false;

                var response = await client.GetAsync(baseUrl);
                var success = response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.Unauthorized;
                
                await UpdateProviderApiStatus(provider, success, success ? null : response.StatusCode.ToString());
                return success;
            }
            catch (Exception ex)
            {
                await UpdateProviderApiStatus(provider, false, ex.Message);
                return false;
            }
        }

        #endregion

        #region HTTP Client Helpers

        private HttpClient CreateHttpClientForProvider(ShippingProvider provider)
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(30);

            // Set authentication headers based on provider configuration
            switch (provider.AuthenticationType?.ToLower())
            {
                case "apikey":
                    var headerName = provider.AuthHeaderName ?? "X-API-Key";
                    client.DefaultRequestHeaders.Add(headerName, provider.ApiKey);
                    break;

                case "bearer":
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", provider.ApiKey);
                    break;

                case "basic":
                    var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{provider.ApiKey}:{provider.ApiSecret}"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);
                    break;

                case "oauth2":
                    if (!string.IsNullOrEmpty(provider.OAuthAccessToken))
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", provider.OAuthAccessToken);
                    }
                    break;

                default:
                    if (!string.IsNullOrEmpty(provider.ApiKey))
                    {
                        client.DefaultRequestHeaders.Add(provider.AuthHeaderName ?? "X-API-Key", provider.ApiKey);
                    }
                    break;
            }

            // Add common headers
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        private async Task UpdateProviderApiStatus(ShippingProvider provider, bool success, string? errorMessage)
        {
            try
            {
                provider.LastApiCallAt = DateTime.UtcNow;
                provider.LastApiCallSuccess = success;
                provider.LastApiError = success ? null : errorMessage;
                provider.UpdatedAt = DateTime.UtcNow;

                _context.ShippingProviders.Update(provider);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Failed to update provider API status for {CarrierCode}", provider.Code);
            }
        }

        #endregion
    }
}
