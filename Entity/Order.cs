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

        [MaxLength(100)]
        public string? StripeCheckoutSessionId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TaxAmount { get; set; } = 0;

        [Column(TypeName = "decimal(5,4)")]
        public decimal TaxRate { get; set; } = 0;

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

        [MaxLength(100)]
        public string? CustomerPhone { get; set; }

        // Shipping Address (collected by Stripe Checkout)
        [MaxLength(500)]
        public string? ShippingAddress { get; set; }

        [MaxLength(200)]
        public string? ShippingCity { get; set; }

        [MaxLength(200)]
        public string? ShippingState { get; set; }

        [MaxLength(20)]
        public string? ShippingPostalCode { get; set; }

        [MaxLength(100)]
        public string? ShippingCountry { get; set; }

        // Billing Address (collected by Stripe Checkout)
        [MaxLength(500)]
        public string? BillingAddress { get; set; }

        [MaxLength(200)]
        public string? BillingCity { get; set; }

        [MaxLength(200)]
        public string? BillingState { get; set; }

        [MaxLength(20)]
        public string? BillingPostalCode { get; set; }

        [MaxLength(100)]
        public string? BillingCountry { get; set; }

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

        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "pln"; // pln, eur, usd

        [MaxLength(100)]
        public string? SessionStatus { get; set; } // complete, expired, cancelled

        [MaxLength(100)]
        public string? CustomerCountry { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? PaidAt { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }

        // Navigation properties
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
