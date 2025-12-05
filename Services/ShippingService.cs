using Kokomija.Data;
using Kokomija.Entity;
using Kokomija.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Services
{
    public class ShippingService : IShippingService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ShippingService> _logger;

        public ShippingService(ApplicationDbContext context, ILogger<ShippingService> logger)
        {
            _context = context;
            _logger = logger;
        }

        // ==================== Shipping Providers ====================

        public async Task<List<ShippingProviderDto>> GetAllProvidersAsync()
        {
            return await _context.ShippingProviders
                .Select(sp => new ShippingProviderDto
                {
                    Id = sp.Id,
                    Name = sp.Name,
                    Code = sp.Code,
                    TrackingUrlTemplate = sp.TrackingUrlTemplate,
                    SupportedCountries = sp.SupportedCountries,
                    IsActive = sp.IsActive,
                    RatesCount = sp.ShippingRates.Count,
                    CreatedAt = sp.CreatedAt
                })
                .OrderBy(sp => sp.Name)
                .ToListAsync();
        }

        public async Task<ShippingProviderDto?> GetProviderByIdAsync(int id)
        {
            return await _context.ShippingProviders
                .Where(sp => sp.Id == id)
                .Select(sp => new ShippingProviderDto
                {
                    Id = sp.Id,
                    Name = sp.Name,
                    Code = sp.Code,
                    TrackingUrlTemplate = sp.TrackingUrlTemplate,
                    SupportedCountries = sp.SupportedCountries,
                    IsActive = sp.IsActive,
                    RatesCount = sp.ShippingRates.Count,
                    CreatedAt = sp.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string Message, int? ProviderId)> CreateProviderAsync(CreateShippingProviderDto dto)
        {
            try
            {
                var exists = await _context.ShippingProviders.AnyAsync(sp => sp.Code == dto.Code);
                if (exists)
                    return (false, "A provider with this code already exists.", null);

                var provider = new ShippingProvider
                {
                    Name = dto.Name,
                    Code = dto.Code,
                    TrackingUrlTemplate = dto.TrackingUrlTemplate,
                    SupportedCountries = dto.SupportedCountries,
                    ApiKey = dto.ApiKey,
                    ApiSecret = dto.ApiSecret,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.ShippingProviders.Add(provider);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Shipping provider {ProviderName} created with ID {ProviderId}", provider.Name, provider.Id);
                return (true, "Shipping provider created successfully.", provider.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating shipping provider {ProviderName}", dto.Name);
                return (false, "An error occurred while creating the shipping provider.", null);
            }
        }

        public async Task<(bool Success, string Message)> UpdateProviderAsync(int id, UpdateShippingProviderDto dto)
        {
            try
            {
                var provider = await _context.ShippingProviders.FindAsync(id);
                if (provider == null)
                    return (false, "Shipping provider not found.");

                provider.Name = dto.Name;
                provider.TrackingUrlTemplate = dto.TrackingUrlTemplate;
                provider.SupportedCountries = dto.SupportedCountries;
                provider.ApiKey = dto.ApiKey;
                provider.ApiSecret = dto.ApiSecret;
                provider.IsActive = dto.IsActive;
                provider.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Shipping provider {ProviderId} updated", id);
                return (true, "Shipping provider updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating shipping provider {ProviderId}", id);
                return (false, "An error occurred while updating the shipping provider.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteProviderAsync(int id)
        {
            try
            {
                var provider = await _context.ShippingProviders
                    .Include(sp => sp.ShippingRates)
                    .Include(sp => sp.Shipments)
                    .FirstOrDefaultAsync(sp => sp.Id == id);

                if (provider == null)
                    return (false, "Shipping provider not found.");

                if (provider.Shipments.Any())
                    return (false, "Cannot delete provider with existing shipments. Deactivate instead.");

                _context.ShippingProviders.Remove(provider);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Shipping provider {ProviderId} deleted", id);
                return (true, "Shipping provider deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting shipping provider {ProviderId}", id);
                return (false, "An error occurred while deleting the shipping provider.");
            }
        }

        public async Task<(bool Success, string Message)> ToggleProviderStatusAsync(int id)
        {
            try
            {
                var provider = await _context.ShippingProviders.FindAsync(id);
                if (provider == null)
                    return (false, "Shipping provider not found.");

                provider.IsActive = !provider.IsActive;
                provider.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                var status = provider.IsActive ? "activated" : "deactivated";
                _logger.LogInformation("Shipping provider {ProviderId} {Status}", id, status);
                return (true, $"Shipping provider {status} successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling provider status {ProviderId}", id);
                return (false, "An error occurred while updating the provider status.");
            }
        }

        // ==================== Shipping Rates ====================

        public async Task<List<ShippingRateDto>> GetAllRatesAsync()
        {
            return await _context.ShippingRates
                .Include(sr => sr.ShippingProvider)
                .Select(sr => new ShippingRateDto
                {
                    Id = sr.Id,
                    ProviderId = sr.ShippingProviderId,
                    ProviderName = sr.ShippingProvider.Name,
                    Zone = sr.Name, // Using Name as Zone
                    Country = sr.CountryCode,
                    MinOrderTotal = 0,
                    MaxOrderTotal = sr.FreeShippingThreshold,
                    Rate = sr.BasePrice,
                    FreeShippingThreshold = sr.FreeShippingThreshold,
                    EstimatedDaysMin = sr.MinDeliveryDays,
                    EstimatedDaysMax = sr.MaxDeliveryDays,
                    IsActive = sr.IsActive,
                    CreatedAt = sr.CreatedAt
                })
                .OrderBy(sr => sr.ProviderName)
                .ThenBy(sr => sr.Country)
                .ToListAsync();
        }

        public async Task<List<ShippingRateDto>> GetRatesByProviderAsync(int providerId)
        {
            return await _context.ShippingRates
                .Include(sr => sr.ShippingProvider)
                .Where(sr => sr.ShippingProviderId == providerId)
                .Select(sr => new ShippingRateDto
                {
                    Id = sr.Id,
                    ProviderId = sr.ShippingProviderId,
                    ProviderName = sr.ShippingProvider.Name,
                    Zone = sr.Name,
                    Country = sr.CountryCode,
                    MinOrderTotal = 0,
                    MaxOrderTotal = sr.FreeShippingThreshold,
                    Rate = sr.BasePrice,
                    FreeShippingThreshold = sr.FreeShippingThreshold,
                    EstimatedDaysMin = sr.MinDeliveryDays,
                    EstimatedDaysMax = sr.MaxDeliveryDays,
                    IsActive = sr.IsActive,
                    CreatedAt = sr.CreatedAt
                })
                .OrderBy(sr => sr.Country)
                .ToListAsync();
        }

        public async Task<ShippingRateDto?> GetRateByIdAsync(int id)
        {
            return await _context.ShippingRates
                .Include(sr => sr.ShippingProvider)
                .Where(sr => sr.Id == id)
                .Select(sr => new ShippingRateDto
                {
                    Id = sr.Id,
                    ProviderId = sr.ShippingProviderId,
                    ProviderName = sr.ShippingProvider.Name,
                    Zone = sr.Name,
                    Country = sr.CountryCode,
                    MinOrderTotal = 0,
                    MaxOrderTotal = sr.FreeShippingThreshold,
                    Rate = sr.BasePrice,
                    FreeShippingThreshold = sr.FreeShippingThreshold,
                    EstimatedDaysMin = sr.MinDeliveryDays,
                    EstimatedDaysMax = sr.MaxDeliveryDays,
                    IsActive = sr.IsActive,
                    CreatedAt = sr.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string Message, int? RateId)> CreateRateAsync(CreateShippingRateDto dto)
        {
            try
            {
                var provider = await _context.ShippingProviders.FindAsync(dto.ProviderId);
                if (provider == null)
                    return (false, "Shipping provider not found.", null);

                var rate = new ShippingRate
                {
                    ShippingProviderId = dto.ProviderId,
                    Name = dto.Zone ?? "Standard",
                    BasePrice = dto.Rate,
                    FreeShippingThreshold = dto.FreeShippingThreshold,
                    MinDeliveryDays = dto.EstimatedDaysMin,
                    MaxDeliveryDays = dto.EstimatedDaysMax,
                    CountryCode = dto.Country,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.ShippingRates.Add(rate);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Shipping rate created for provider {ProviderId}", dto.ProviderId);
                return (true, "Shipping rate created successfully.", rate.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating shipping rate for provider {ProviderId}", dto.ProviderId);
                return (false, "An error occurred while creating the shipping rate.", null);
            }
        }

        public async Task<(bool Success, string Message)> UpdateRateAsync(int id, UpdateShippingRateDto dto)
        {
            try
            {
                var rate = await _context.ShippingRates.FindAsync(id);
                if (rate == null)
                    return (false, "Shipping rate not found.");

                rate.ShippingProviderId = dto.ProviderId;
                rate.Name = dto.Zone ?? "Standard";
                rate.BasePrice = dto.Rate;
                rate.FreeShippingThreshold = dto.FreeShippingThreshold;
                rate.MinDeliveryDays = dto.EstimatedDaysMin;
                rate.MaxDeliveryDays = dto.EstimatedDaysMax;
                rate.CountryCode = dto.Country;
                rate.IsActive = dto.IsActive;
                rate.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Shipping rate {RateId} updated", id);
                return (true, "Shipping rate updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating shipping rate {RateId}", id);
                return (false, "An error occurred while updating the shipping rate.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteRateAsync(int id)
        {
            try
            {
                var rate = await _context.ShippingRates.FindAsync(id);
                if (rate == null)
                    return (false, "Shipping rate not found.");

                _context.ShippingRates.Remove(rate);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Shipping rate {RateId} deleted", id);
                return (true, "Shipping rate deleted successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting shipping rate {RateId}", id);
                return (false, "An error occurred while deleting the shipping rate.");
            }
        }

        public async Task<(bool Success, string Message)> ToggleRateStatusAsync(int id)
        {
            try
            {
                var rate = await _context.ShippingRates.FindAsync(id);
                if (rate == null)
                    return (false, "Shipping rate not found.");

                rate.IsActive = !rate.IsActive;
                rate.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                var status = rate.IsActive ? "activated" : "deactivated";
                _logger.LogInformation("Shipping rate {RateId} {Status}", id, status);
                return (true, $"Shipping rate {status} successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling rate status {RateId}", id);
                return (false, "An error occurred while updating the rate status.");
            }
        }

        // ==================== Shipping Calculation ====================

        public async Task<List<ShippingRateDto>> GetAvailableRatesForOrderAsync(string country, decimal orderTotal)
        {
            var rates = await _context.ShippingRates
                .Include(sr => sr.ShippingProvider)
                .Where(sr => sr.IsActive && 
                            sr.ShippingProvider.IsActive &&
                            (sr.CountryCode == null || sr.CountryCode == country))
                .Select(sr => new ShippingRateDto
                {
                    Id = sr.Id,
                    ProviderId = sr.ShippingProviderId,
                    ProviderName = sr.ShippingProvider.Name,
                    Zone = sr.Name,
                    Country = sr.CountryCode,
                    MinOrderTotal = 0,
                    MaxOrderTotal = sr.FreeShippingThreshold,
                    Rate = sr.BasePrice,
                    FreeShippingThreshold = sr.FreeShippingThreshold,
                    EstimatedDaysMin = sr.MinDeliveryDays,
                    EstimatedDaysMax = sr.MaxDeliveryDays,
                    IsActive = sr.IsActive,
                    CreatedAt = sr.CreatedAt
                })
                .OrderBy(sr => sr.Rate)
                .ToListAsync();

            return rates;
        }

        public async Task<decimal> CalculateShippingCostAsync(int rateId, decimal orderTotal)
        {
            var rate = await _context.ShippingRates.FindAsync(rateId);
            if (rate == null)
                return 0;

            if (rate.FreeShippingThreshold.HasValue && orderTotal >= rate.FreeShippingThreshold.Value)
                return 0;

            return rate.BasePrice;
        }

        // ==================== Shipment Tracking ====================

        public async Task<List<OrderShipmentDto>> GetShipmentsByOrderAsync(int orderId)
        {
            return await _context.OrderShipments
                .Include(os => os.Order)
                .Include(os => os.ShippingProvider)
                .Where(os => os.OrderId == orderId)
                .Select(os => new OrderShipmentDto
                {
                    Id = os.Id,
                    OrderId = os.OrderId,
                    OrderNumber = os.Order.OrderNumber,
                    ProviderId = os.ShippingProviderId,
                    ProviderName = os.ShippingProvider.Name,
                    TrackingNumber = os.TrackingNumber,
                    Status = os.Status.ToString(),
                    ShippingCost = os.ShippingCost,
                    EstimatedDelivery = os.EstimatedDeliveryDate,
                    ActualDelivery = os.ActualDeliveryDate,
                    ShippedAt = os.ShippedAt ?? DateTime.MinValue,
                    TrackingEventsCount = os.TrackingEvents.Count
                })
                .ToListAsync();
        }

        public async Task<OrderShipmentDto?> GetShipmentByIdAsync(int id)
        {
            return await _context.OrderShipments
                .Include(os => os.Order)
                .Include(os => os.ShippingProvider)
                .Where(os => os.Id == id)
                .Select(os => new OrderShipmentDto
                {
                    Id = os.Id,
                    OrderId = os.OrderId,
                    OrderNumber = os.Order.OrderNumber,
                    ProviderId = os.ShippingProviderId,
                    ProviderName = os.ShippingProvider.Name,
                    TrackingNumber = os.TrackingNumber,
                    Status = os.Status.ToString(),
                    ShippingCost = os.ShippingCost,
                    EstimatedDelivery = os.EstimatedDeliveryDate,
                    ActualDelivery = os.ActualDeliveryDate,
                    ShippedAt = os.ShippedAt ?? DateTime.MinValue,
                    TrackingEventsCount = os.TrackingEvents.Count
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string Message, int? ShipmentId)> CreateShipmentAsync(CreateShipmentDto dto)
        {
            try
            {
                var order = await _context.Orders.FindAsync(dto.OrderId);
                if (order == null)
                    return (false, "Order not found.", null);

                var provider = await _context.ShippingProviders.FindAsync(dto.ProviderId);
                if (provider == null)
                    return (false, "Shipping provider not found.", null);

                // Get a default shipping rate for this provider
                var rate = await _context.ShippingRates
                    .FirstOrDefaultAsync(sr => sr.ShippingProviderId == dto.ProviderId && sr.IsActive);
                
                if (rate == null)
                    return (false, "No active shipping rate found for this provider.", null);

                var shipment = new OrderShipment
                {
                    OrderId = dto.OrderId,
                    ShippingProviderId = dto.ProviderId,
                    ShippingRateId = rate.Id,
                    TrackingNumber = dto.TrackingNumber,
                    Status = ShipmentStatus.Pending,
                    ShippingCost = dto.ShippingCost,
                    EstimatedDeliveryDate = dto.EstimatedDelivery,
                    ShippedAt = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.OrderShipments.Add(shipment);

                // Update order status
                order.OrderStatus = "shipped";
                order.ShippedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Shipment created for order {OrderId}", dto.OrderId);
                return (true, "Shipment created successfully.", shipment.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating shipment for order {OrderId}", dto.OrderId);
                return (false, "An error occurred while creating the shipment.", null);
            }
        }

        public async Task<(bool Success, string Message)> UpdateTrackingNumberAsync(int shipmentId, string trackingNumber)
        {
            try
            {
                var shipment = await _context.OrderShipments.FindAsync(shipmentId);
                if (shipment == null)
                    return (false, "Shipment not found.");

                shipment.TrackingNumber = trackingNumber;
                shipment.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Tracking number updated for shipment {ShipmentId}", shipmentId);
                return (true, "Tracking number updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating tracking number for shipment {ShipmentId}", shipmentId);
                return (false, "An error occurred while updating the tracking number.");
            }
        }

        public async Task<(bool Success, string Message)> AddTrackingEventAsync(int shipmentId, CreateTrackingEventDto dto)
        {
            try
            {
                var shipment = await _context.OrderShipments.FindAsync(shipmentId);
                if (shipment == null)
                    return (false, "Shipment not found.");

                var trackingEvent = new ShipmentTrackingEvent
                {
                    OrderShipmentId = shipmentId,
                    Status = dto.Status,
                    Location = dto.Location,
                    Description = dto.Description ?? string.Empty,
                    EventDate = dto.EventDate,
                    CreatedAt = DateTime.UtcNow
                };

                _context.ShipmentTrackingEvents.Add(trackingEvent);

                // Update shipment status based on event
                if (Enum.TryParse<ShipmentStatus>(dto.Status, true, out var status))
                {
                    shipment.Status = status;
                }

                // If delivered, update delivery dates
                if (dto.Status.Equals("delivered", StringComparison.OrdinalIgnoreCase))
                {
                    shipment.ActualDeliveryDate = dto.EventDate;
                    shipment.DeliveredAt = dto.EventDate;
                    
                    var order = await _context.Orders.FindAsync(shipment.OrderId);
                    if (order != null)
                    {
                        order.OrderStatus = "delivered";
                        order.DeliveredAt = dto.EventDate;
                    }
                }

                shipment.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();

                _logger.LogInformation("Tracking event added for shipment {ShipmentId}", shipmentId);
                return (true, "Tracking event added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding tracking event for shipment {ShipmentId}", shipmentId);
                return (false, "An error occurred while adding the tracking event.");
            }
        }

        public async Task<List<ShipmentTrackingEventDto>> GetTrackingEventsAsync(int shipmentId)
        {
            return await _context.ShipmentTrackingEvents
                .Where(ste => ste.OrderShipmentId == shipmentId)
                .OrderByDescending(ste => ste.EventDate)
                .Select(ste => new ShipmentTrackingEventDto
                {
                    Id = ste.Id,
                    Status = ste.Status,
                    Location = ste.Location,
                    Description = ste.Description,
                    EventDate = ste.EventDate
                })
                .ToListAsync();
        }

        public async Task<string?> GetTrackingUrlAsync(int shipmentId)
        {
            var shipment = await _context.OrderShipments
                .Include(os => os.ShippingProvider)
                .FirstOrDefaultAsync(os => os.Id == shipmentId);

            if (shipment == null || string.IsNullOrEmpty(shipment.TrackingNumber))
                return null;

            if (string.IsNullOrEmpty(shipment.ShippingProvider.TrackingUrlTemplate))
                return null;

            return shipment.ShippingProvider.TrackingUrlTemplate.Replace("{trackingNumber}", shipment.TrackingNumber);
        }
    }
}
