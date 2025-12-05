using System.ComponentModel.DataAnnotations;

namespace Kokomija.Entity
{
    public class ShippingProvider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // "UPS", "FedEx", "DHL", "InPost"

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty; // "ups", "fedex", "dhl"

        [Required]
        public bool IsActive { get; set; } = true;

        [MaxLength(500)]
        public string? LogoUrl { get; set; }

        [MaxLength(500)]
        public string? ApiKey { get; set; } // Encrypted

        [MaxLength(500)]
        public string? ApiSecret { get; set; } // Encrypted

        [MaxLength(500)]
        public string? WebhookUrl { get; set; }

        [MaxLength(500)]
        public string? TrackingUrlTemplate { get; set; } // e.g., "https://www.ups.com/track?tracknum={trackingNumber}"

        public string? SupportedCountries { get; set; } // JSON array of country codes

        public int EstimatedDeliveryDays { get; set; } = 3;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ShippingRate> ShippingRates { get; set; } = new List<ShippingRate>();
        public ICollection<OrderShipment> Shipments { get; set; } = new List<OrderShipment>();
    }
}
