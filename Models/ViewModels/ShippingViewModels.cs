using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels
{
    // ==================== Shipping Provider DTOs ====================
    
    public class ShippingProviderDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? TrackingUrlTemplate { get; set; }
        public string? SupportedCountries { get; set; }
        public bool IsActive { get; set; }
        public int RatesCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateShippingProviderDto
    {
        [Required(ErrorMessage = "Provider name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Provider code is required")]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? TrackingUrlTemplate { get; set; }

        public string? SupportedCountries { get; set; }

        [MaxLength(500)]
        public string? ApiKey { get; set; }

        [MaxLength(500)]
        public string? ApiSecret { get; set; }
    }

    public class UpdateShippingProviderDto
    {
        [Required(ErrorMessage = "Provider name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? TrackingUrlTemplate { get; set; }

        public string? SupportedCountries { get; set; }

        [MaxLength(500)]
        public string? ApiKey { get; set; }

        [MaxLength(500)]
        public string? ApiSecret { get; set; }

        public bool IsActive { get; set; }
    }

    // ==================== Shipping Rate DTOs ====================

    public class ShippingRateDto
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string? Zone { get; set; }
        public string? Country { get; set; }
        public decimal MinOrderTotal { get; set; }
        public decimal? MaxOrderTotal { get; set; }
        public decimal Rate { get; set; }
        public decimal? FreeShippingThreshold { get; set; }
        public int EstimatedDaysMin { get; set; }
        public int EstimatedDaysMax { get; set; }
        public bool IsActive { get; set; }
        public string? StripeShippingRateId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateShippingRateDto
    {
        [Required]
        public int ProviderId { get; set; }

        [MaxLength(100)]
        public string? Zone { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [Range(0, double.MaxValue)]
        public decimal MinOrderTotal { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public decimal? MaxOrderTotal { get; set; }

        [Required]
        [Range(0.01, 9999.99)]
        public decimal Rate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? FreeShippingThreshold { get; set; }

        [Range(1, 365)]
        public int EstimatedDaysMin { get; set; } = 3;

        [Range(1, 365)]
        public int EstimatedDaysMax { get; set; } = 7;
    }

    public class UpdateShippingRateDto
    {
        [Required]
        public int ProviderId { get; set; }

        [MaxLength(100)]
        public string? Zone { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [Range(0, double.MaxValue)]
        public decimal MinOrderTotal { get; set; } = 0;

        [Range(0, double.MaxValue)]
        public decimal? MaxOrderTotal { get; set; }

        [Required]
        [Range(0.01, 9999.99)]
        public decimal Rate { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? FreeShippingThreshold { get; set; }

        [Range(1, 365)]
        public int EstimatedDaysMin { get; set; } = 3;

        [Range(1, 365)]
        public int EstimatedDaysMax { get; set; } = 7;

        public bool IsActive { get; set; }
    }

    // ==================== Shipment DTOs ====================

    public class OrderShipmentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public int ProviderId { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string? TrackingNumber { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal ShippingCost { get; set; }
        public DateTime? EstimatedDelivery { get; set; }
        public DateTime? ActualDelivery { get; set; }
        public DateTime ShippedAt { get; set; }
        public int TrackingEventsCount { get; set; }
    }

    public class CreateShipmentDto
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProviderId { get; set; }

        [MaxLength(100)]
        public string? TrackingNumber { get; set; }

        [Range(0, double.MaxValue)]
        public decimal ShippingCost { get; set; }

        public DateTime? EstimatedDelivery { get; set; }
    }

    public class ShipmentTrackingEventDto
    {
        public int Id { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime EventDate { get; set; }
    }

    public class CreateTrackingEventDto
    {
        [Required]
        [MaxLength(100)]
        public string Status { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Location { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public DateTime EventDate { get; set; } = DateTime.UtcNow;
    }

    // ==================== View Models ====================

    public class ShippingProvidersViewModel
    {
        public List<ShippingProviderDto> Providers { get; set; } = new();
        public int TotalProviders { get; set; }
        public int ActiveProviders { get; set; }
    }

    public class ShippingRatesViewModel
    {
        public List<ShippingRateDto> Rates { get; set; } = new();
        public List<ShippingProviderDto> Providers { get; set; } = new();
        public int TotalRates { get; set; }
        public int ActiveRates { get; set; }
    }

    public class OrderShipmentsViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public List<OrderShipmentDto> Shipments { get; set; } = new();
    }
}
