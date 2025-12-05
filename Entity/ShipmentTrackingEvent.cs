using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class ShipmentTrackingEvent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderShipmentId { get; set; }

        [ForeignKey(nameof(OrderShipmentId))]
        public OrderShipment OrderShipment { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Status { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Location { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
