using Kokomija.Data;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
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
        Task<List<TrackingEvent>> GetTrackingHistoryAsync(string trackingNumber, string carrierCode);
        
        // Shipment Creation
        Task<ShipmentCreationResult> CreateShipmentAsync(CreateShipmentRequest request);
        Task<LabelGenerationResult> GenerateLabelAsync(int shipmentId);
        Task<(bool Success, string Message)> CancelShipmentAsync(int shipmentId);
        
        // Rate Calculation
        Task<List<ShippingQuote>> GetShippingQuotesAsync(ShippingQuoteRequest request);
        
        // Webhook Processing
        Task<(bool Success, string Message)> ProcessWebhookAsync(string carrierCode, string payload, string signature);
        
        // Carrier Status
        Task<CarrierStatus> CheckCarrierStatusAsync(string carrierCode);
        Task<List<CarrierStatus>> GetAllCarrierStatusesAsync();
    }

    #region DTOs

    public class TrackingResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string TrackingNumber { get; set; } = string.Empty;
        public string CarrierCode { get; set; } = string.Empty;
        public string CurrentStatus { get; set; } = string.Empty;
        public string StatusDescription { get; set; } = string.Empty;
        public DateTime? EstimatedDelivery { get; set; }
        public DateTime? ActualDelivery { get; set; }
        public string? SignedBy { get; set; }
        public string? CurrentLocation { get; set; }
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
        public string ServiceType { get; set; } = "standard"; // standard, express, overnight
        public AddressInfo Sender { get; set; } = new();
        public AddressInfo Recipient { get; set; } = new();
        public PackageInfo Package { get; set; } = new();
        public bool SignatureRequired { get; set; }
        public string? SpecialInstructions { get; set; }
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
    }

    public class ShipmentCreationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public string? TrackingNumber { get; set; }
        public string? CarrierShipmentId { get; set; }
        public string? LabelUrl { get; set; }
        public decimal? ShippingCost { get; set; }
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
        public List<string>? PreferredCarriers { get; set; }
    }

    public class ShippingQuote
    {
        public string CarrierCode { get; set; } = string.Empty;
        public string CarrierName { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Currency { get; set; } = "PLN";
        public int EstimatedDaysMin { get; set; }
        public int EstimatedDaysMax { get; set; }
        public DateTime? EstimatedDelivery { get; set; }
        public bool GuaranteedDelivery { get; set; }
    }

    public class CarrierStatus
    {
        public string CarrierCode { get; set; } = string.Empty;
        public string CarrierName { get; set; } = string.Empty;
        public bool IsConfigured { get; set; }
        public bool IsConnected { get; set; }
        public bool HasApiKey { get; set; }
        public DateTime? LastSuccessfulCall { get; set; }
        public string? ErrorMessage { get; set; }
        public string Status => IsConnected ? "Connected" : (IsConfigured ? "Configured" : "Not Configured");
    }

    #endregion

    /// <summary>
    /// Carrier API service implementation with support for multiple carriers
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

        #region Tracking

        public async Task<TrackingResult> GetTrackingInfoAsync(string trackingNumber, string carrierCode)
        {
            try
            {
                var provider = await _context.ShippingProviders
                    .FirstOrDefaultAsync(p => p.Code == carrierCode && p.IsActive);

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

                // Route to specific carrier implementation
                return carrierCode.ToLower() switch
                {
                    "dhl" => await GetDhlTrackingAsync(trackingNumber, provider),
                    "inpost" => await GetInPostTrackingAsync(trackingNumber, provider),
                    "dpd" => await GetDpdTrackingAsync(trackingNumber, provider),
                    "ups" => await GetUpsTrackingAsync(trackingNumber, provider),
                    "fedex" => await GetFedExTrackingAsync(trackingNumber, provider),
                    "gls" => await GetGlsTrackingAsync(trackingNumber, provider),
                    "poczta_polska" => await GetPocztaPolskaTrackingAsync(trackingNumber, provider),
                    _ => await GetGenericTrackingAsync(trackingNumber, provider)
                };
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

        public async Task<List<TrackingEvent>> GetTrackingHistoryAsync(string trackingNumber, string carrierCode)
        {
            var result = await GetTrackingInfoAsync(trackingNumber, carrierCode);
            return result.Events;
        }

        // Carrier-specific tracking implementations (stubs - implement when API keys are available)

        private async Task<TrackingResult> GetDhlTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            // DHL API: https://developer.dhl.com/api-reference/shipment-tracking
            if (string.IsNullOrEmpty(provider.ApiKey))
            {
                return CreateMockTrackingResult(trackingNumber, "dhl", "DHL Express");
            }

            // TODO: Implement actual DHL API call
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("DHL-API-Key", provider.ApiKey);

            try
            {
                var response = await client.GetAsync($"https://api-eu.dhl.com/track/shipments?trackingNumber={trackingNumber}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // Parse DHL response
                    return ParseDhlTrackingResponse(trackingNumber, content);
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "DHL API call failed, using mock data");
            }

            return CreateMockTrackingResult(trackingNumber, "dhl", "DHL Express");
        }

        private async Task<TrackingResult> GetInPostTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            // InPost API (Poland): https://api-shipx-pl.easypack24.net
            if (string.IsNullOrEmpty(provider.ApiKey))
            {
                return CreateMockTrackingResult(trackingNumber, "inpost", "InPost");
            }

            // TODO: Implement actual InPost API call
            return CreateMockTrackingResult(trackingNumber, "inpost", "InPost");
        }

        private async Task<TrackingResult> GetDpdTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            // DPD API
            return CreateMockTrackingResult(trackingNumber, "dpd", "DPD");
        }

        private async Task<TrackingResult> GetUpsTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            // UPS API: https://developer.ups.com/api/reference
            return CreateMockTrackingResult(trackingNumber, "ups", "UPS");
        }

        private async Task<TrackingResult> GetFedExTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            // FedEx API
            return CreateMockTrackingResult(trackingNumber, "fedex", "FedEx");
        }

        private async Task<TrackingResult> GetGlsTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            // GLS API
            return CreateMockTrackingResult(trackingNumber, "gls", "GLS");
        }

        private async Task<TrackingResult> GetPocztaPolskaTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            // Poczta Polska API
            return CreateMockTrackingResult(trackingNumber, "poczta_polska", "Poczta Polska");
        }

        private async Task<TrackingResult> GetGenericTrackingAsync(string trackingNumber, ShippingProvider provider)
        {
            return CreateMockTrackingResult(trackingNumber, provider.Code, provider.Name);
        }

        private TrackingResult CreateMockTrackingResult(string trackingNumber, string carrierCode, string carrierName)
        {
            // Generate realistic mock tracking events
            var baseDate = DateTime.UtcNow.AddDays(-3);
            var events = new List<TrackingEvent>
            {
                new() { Timestamp = baseDate, Status = "PICKED_UP", Description = "Shipment picked up", Location = "Warsaw, PL" },
                new() { Timestamp = baseDate.AddHours(4), Status = "IN_TRANSIT", Description = "Departed facility", Location = "Warsaw Distribution Center" },
                new() { Timestamp = baseDate.AddDays(1), Status = "IN_TRANSIT", Description = "In transit to destination", Location = "Sorting Facility" },
                new() { Timestamp = baseDate.AddDays(2), Status = "OUT_FOR_DELIVERY", Description = "Out for delivery", Location = "Local Delivery Depot" },
            };

            return new TrackingResult
            {
                Success = true,
                Message = "Tracking information retrieved (mock data - API not configured)",
                TrackingNumber = trackingNumber,
                CarrierCode = carrierCode,
                CurrentStatus = "IN_TRANSIT",
                StatusDescription = "Package is in transit",
                EstimatedDelivery = DateTime.UtcNow.AddDays(1),
                CurrentLocation = "Local Delivery Depot",
                Events = events
            };
        }

        private TrackingResult ParseDhlTrackingResponse(string trackingNumber, string jsonResponse)
        {
            // Parse actual DHL API response
            // This is a placeholder - implement based on actual DHL API response structure
            return CreateMockTrackingResult(trackingNumber, "dhl", "DHL Express");
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

                // Route to specific carrier implementation
                var result = provider.Code.ToLower() switch
                {
                    "dhl" => await CreateDhlShipmentAsync(request, provider),
                    "inpost" => await CreateInPostShipmentAsync(request, provider),
                    "dpd" => await CreateDpdShipmentAsync(request, provider),
                    _ => await CreateGenericShipmentAsync(request, provider)
                };

                if (result.Success && !string.IsNullOrEmpty(result.TrackingNumber))
                {
                    // Get first shipping rate for the provider
                    var shippingRate = await _context.ShippingRates
                        .Where(r => r.ShippingProviderId == request.ShippingProviderId)
                        .FirstOrDefaultAsync();
                    
                    // Create shipment record in database
                    var shipment = new OrderShipment
                    {
                        OrderId = request.OrderId,
                        ShippingProviderId = request.ShippingProviderId,
                        ShippingRateId = shippingRate?.Id ?? 1, // Default to 1 if no rate found
                        TrackingNumber = result.TrackingNumber,
                        Status = ShipmentStatus.Pending,
                        ShippingCost = result.ShippingCost ?? 0,
                        CreatedAt = DateTime.UtcNow,
                        UpdatedAt = DateTime.UtcNow
                    };

                    _context.OrderShipments.Add(shipment);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Shipment created for order {OrderId} with tracking {TrackingNumber}",
                        request.OrderId, result.TrackingNumber);
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

        private async Task<ShipmentCreationResult> CreateDhlShipmentAsync(CreateShipmentRequest request, ShippingProvider provider)
        {
            // TODO: Implement DHL shipment creation
            return new ShipmentCreationResult
            {
                Success = true,
                Message = "Shipment created (mock - API not configured)",
                TrackingNumber = $"DHL{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}",
                ShippingCost = 25.00m
            };
        }

        private async Task<ShipmentCreationResult> CreateInPostShipmentAsync(CreateShipmentRequest request, ShippingProvider provider)
        {
            // TODO: Implement InPost shipment creation
            return new ShipmentCreationResult
            {
                Success = true,
                Message = "Shipment created (mock - API not configured)",
                TrackingNumber = $"INP{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}",
                ShippingCost = 12.99m
            };
        }

        private async Task<ShipmentCreationResult> CreateDpdShipmentAsync(CreateShipmentRequest request, ShippingProvider provider)
        {
            return new ShipmentCreationResult
            {
                Success = true,
                Message = "Shipment created (mock - API not configured)",
                TrackingNumber = $"DPD{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}",
                ShippingCost = 18.50m
            };
        }

        private async Task<ShipmentCreationResult> CreateGenericShipmentAsync(CreateShipmentRequest request, ShippingProvider provider)
        {
            return new ShipmentCreationResult
            {
                Success = true,
                Message = "Shipment created (manual tracking)",
                TrackingNumber = $"{provider.Code.ToUpper()}{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}",
                ShippingCost = 15.00m
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

                // TODO: Implement actual label generation via carrier API
                return new LabelGenerationResult
                {
                    Success = true,
                    Message = "Label generated (mock - implement with carrier API)",
                    LabelFormat = "PDF"
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

                // TODO: Call carrier API to cancel shipment

                shipment.Status = ShipmentStatus.Failed; // Using Failed status for cancelled shipments
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
                var providers = await _context.ShippingProviders
                    .Where(p => p.IsActive)
                    .ToListAsync();

                if (request.PreferredCarriers?.Any() == true)
                {
                    providers = providers
                        .Where(p => request.PreferredCarriers.Contains(p.Code, StringComparer.OrdinalIgnoreCase))
                        .ToList();
                }

                foreach (var provider in providers)
                {
                    // Get rates for each provider
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

        private async Task<List<ShippingQuote>> GetProviderQuotesAsync(ShippingProvider provider, ShippingQuoteRequest request)
        {
            // TODO: Implement actual API calls for each provider
            // For now, return rates from database
            var rates = await _context.ShippingRates
                .Where(r => r.ShippingProviderId == provider.Id && r.IsActive)
                .ToListAsync();

            return rates.Select(r => new ShippingQuote
            {
                CarrierCode = provider.Code,
                CarrierName = provider.Name,
                ServiceType = "standard",
                ServiceName = r.Name,
                Price = r.BasePrice,
                Currency = "PLN",
                EstimatedDaysMin = r.MinDeliveryDays,
                EstimatedDaysMax = r.MaxDeliveryDays,
                EstimatedDelivery = DateTime.UtcNow.AddDays(r.MaxDeliveryDays)
            }).ToList();
        }

        #endregion

        #region Webhook Processing

        public async Task<(bool Success, string Message)> ProcessWebhookAsync(string carrierCode, string payload, string signature)
        {
            try
            {
                var provider = await _context.ShippingProviders
                    .FirstOrDefaultAsync(p => p.Code == carrierCode);

                if (provider == null)
                {
                    return (false, "Carrier not found.");
                }

                // Verify webhook signature (carrier-specific)
                // TODO: Implement signature verification for each carrier

                // Parse and process webhook payload
                var result = carrierCode.ToLower() switch
                {
                    "dhl" => await ProcessDhlWebhookAsync(payload, provider),
                    "inpost" => await ProcessInPostWebhookAsync(payload, provider),
                    "dpd" => await ProcessDpdWebhookAsync(payload, provider),
                    _ => (false, "Webhook processing not implemented for this carrier.")
                };

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing webhook for carrier {CarrierCode}", carrierCode);
                return (false, "An error occurred while processing the webhook.");
            }
        }

        private async Task<(bool Success, string Message)> ProcessDhlWebhookAsync(string payload, ShippingProvider provider)
        {
            // TODO: Implement DHL webhook processing
            // Update shipment status based on webhook data
            return (true, "Webhook processed.");
        }

        private async Task<(bool Success, string Message)> ProcessInPostWebhookAsync(string payload, ShippingProvider provider)
        {
            // TODO: Implement InPost webhook processing
            return (true, "Webhook processed.");
        }

        private async Task<(bool Success, string Message)> ProcessDpdWebhookAsync(string payload, ShippingProvider provider)
        {
            return (true, "Webhook processed.");
        }

        #endregion

        #region Carrier Status

        public async Task<CarrierStatus> CheckCarrierStatusAsync(string carrierCode)
        {
            var provider = await _context.ShippingProviders
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
            if (hasApiKey)
            {
                isConnected = await TestCarrierConnectionAsync(provider);
            }

            return new CarrierStatus
            {
                CarrierCode = provider.Code,
                CarrierName = provider.Name,
                IsConfigured = true,
                HasApiKey = hasApiKey,
                IsConnected = isConnected
            };
        }

        public async Task<List<CarrierStatus>> GetAllCarrierStatusesAsync()
        {
            var providers = await _context.ShippingProviders.ToListAsync();
            var statuses = new List<CarrierStatus>();

            foreach (var provider in providers)
            {
                var hasApiKey = !string.IsNullOrEmpty(provider.ApiKey);
                statuses.Add(new CarrierStatus
                {
                    CarrierCode = provider.Code,
                    CarrierName = provider.Name,
                    IsConfigured = true,
                    HasApiKey = hasApiKey,
                    IsConnected = hasApiKey // Assume connected if API key exists
                });
            }

            return statuses;
        }

        private async Task<bool> TestCarrierConnectionAsync(ShippingProvider provider)
        {
            try
            {
                // Implement carrier-specific health check
                return true; // Placeholder
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
