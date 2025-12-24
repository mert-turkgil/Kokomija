using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class Coupon
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        [MaxLength(50)]
        public string DiscountType { get; set; } = "percentage"; // percentage, fixed_amount

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DiscountValue { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MinimumOrderAmount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? MaximumDiscountAmount { get; set; }

        public int? UsageLimit { get; set; }

        public int UsageCount { get; set; } = 0;

        public int? UsageLimitPerUser { get; set; }

        public DateTime? ValidFrom { get; set; }

        public DateTime? ValidUntil { get; set; }

        public bool IsActive { get; set; } = true;

        [MaxLength(100)]
        public string? StripeCouponId { get; set; }

        [MaxLength(100)]
        public string? StripePromotionCodeId { get; set; }

        // User-specific coupon (if null, available to all users)
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        // Product restriction (if set, coupon only valid for this specific product)
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        // Category restriction (if set, coupon only valid for products in this category)
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CouponUsage> CouponUsages { get; set; } = new List<CouponUsage>();
    }
}
