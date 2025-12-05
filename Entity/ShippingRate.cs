using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class ShippingRate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ShippingProviderId { get; set; }

        [ForeignKey(nameof(ShippingProviderId))]
        public ShippingProvider ShippingProvider { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // "Standard", "Express", "Overnight"

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal BasePrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PricePerKg { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? PricePerKm { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? FreeShippingThreshold { get; set; } // Free if order > this amount

        public int MinDeliveryDays { get; set; }

        public int MaxDeliveryDays { get; set; }

        [MaxLength(100)]
        public string? StripeShippingRateId { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [MaxLength(10)]
        public string? CountryCode { get; set; } // ISO country code, null = all countries

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<OrderShipment> Shipments { get; set; } = new List<OrderShipment>();
    }
}
