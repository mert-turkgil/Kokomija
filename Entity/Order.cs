using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string StripePaymentIntentId { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? StripeChargeId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CommissionAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,4)")]
        public decimal CommissionRate { get; set; } = 0.015M; // 1.5%

        // Coupon/Discount
        public int? CouponId { get; set; }
        [ForeignKey("CouponId")]
        public Coupon? Coupon { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Column(TypeName = "decimal(18,2)")]
        public decimal SubtotalAmount { get; set; }

        [Required]
        [MaxLength(100)]
        public string CustomerEmail { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? CustomerName { get; set; }

        // User relationship (optional - for registered users)
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        [Required]
        [MaxLength(50)]
        public string OrderStatus { get; set; } = "pending"; // pending, paid, processing, shipped, delivered, cancelled

        [Required]
        [MaxLength(50)]
        public string PaymentStatus { get; set; } = "pending"; // pending, paid, failed, refunded

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }

        // Navigation properties
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
