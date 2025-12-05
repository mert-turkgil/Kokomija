using Kokomija.Models.ViewModels;

namespace Kokomija.Services
{
    public interface IShippingService
    {
        // Shipping Providers
        Task<List<ShippingProviderDto>> GetAllProvidersAsync();
        Task<ShippingProviderDto?> GetProviderByIdAsync(int id);
        Task<(bool Success, string Message, int? ProviderId)> CreateProviderAsync(CreateShippingProviderDto dto);
        Task<(bool Success, string Message)> UpdateProviderAsync(int id, UpdateShippingProviderDto dto);
        Task<(bool Success, string Message)> DeleteProviderAsync(int id);
        Task<(bool Success, string Message)> ToggleProviderStatusAsync(int id);

        // Shipping Rates
        Task<List<ShippingRateDto>> GetAllRatesAsync();
        Task<List<ShippingRateDto>> GetRatesByProviderAsync(int providerId);
        Task<ShippingRateDto?> GetRateByIdAsync(int id);
        Task<(bool Success, string Message, int? RateId)> CreateRateAsync(CreateShippingRateDto dto);
        Task<(bool Success, string Message)> UpdateRateAsync(int id, UpdateShippingRateDto dto);
        Task<(bool Success, string Message)> DeleteRateAsync(int id);
        Task<(bool Success, string Message)> ToggleRateStatusAsync(int id);

        // Shipping Calculation
        Task<List<ShippingRateDto>> GetAvailableRatesForOrderAsync(string country, decimal orderTotal);
        Task<decimal> CalculateShippingCostAsync(int rateId, decimal orderTotal);

        // Shipment Tracking
        Task<List<OrderShipmentDto>> GetShipmentsByOrderAsync(int orderId);
        Task<OrderShipmentDto?> GetShipmentByIdAsync(int id);
        Task<(bool Success, string Message, int? ShipmentId)> CreateShipmentAsync(CreateShipmentDto dto);
        Task<(bool Success, string Message)> UpdateTrackingNumberAsync(int shipmentId, string trackingNumber);
        Task<(bool Success, string Message)> AddTrackingEventAsync(int shipmentId, CreateTrackingEventDto dto);
        Task<List<ShipmentTrackingEventDto>> GetTrackingEventsAsync(int shipmentId);
        Task<string?> GetTrackingUrlAsync(int shipmentId);
    }
}
