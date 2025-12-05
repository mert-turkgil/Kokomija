using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public enum ShipmentStatus
    {
        Pending,
        Processing,
        Shipped,
        InTransit,
        OutForDelivery,
        Delivered,
        Failed,
        Returned
    }

    public class OrderShipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        [Required]
        public int ShippingProviderId { get; set; }

        [ForeignKey(nameof(ShippingProviderId))]
        public ShippingProvider ShippingProvider { get; set; } = null!;

        [Required]
        public int ShippingRateId { get; set; }

        [ForeignKey(nameof(ShippingRateId))]
        public ShippingRate ShippingRate { get; set; } = null!;

        [MaxLength(100)]
        public string? TrackingNumber { get; set; }

        [Required]
        public ShipmentStatus Status { get; set; } = ShipmentStatus.Pending;

        public DateTime? EstimatedDeliveryDate { get; set; }

        public DateTime? ActualDeliveryDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ShippingCost { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Weight { get; set; } // in kg

        public DateTime? ShippedAt { get; set; }

        public DateTime? DeliveredAt { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ShipmentTrackingEvent> TrackingEvents { get; set; } = new List<ShipmentTrackingEvent>();
    }
}
