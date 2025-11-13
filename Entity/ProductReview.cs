using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class ProductReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product? Product { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser? User { get; set; }

        [Required]
        [Range(0.5, 5.0)]
        [Column(TypeName = "decimal(2,1)")]
        public decimal Rating { get; set; }

        [Required]
        [StringLength(2000)]
        public string Comment { get; set; } = string.Empty;

        public bool IsVerifiedPurchase { get; set; } = false;

        [StringLength(2000)]
        public string? AdminReply { get; set; }

        public string? AdminReplyBy { get; set; }

        [ForeignKey(nameof(AdminReplyBy))]
        public virtual ApplicationUser? AdminUser { get; set; }

        public DateTime? AdminReplyAt { get; set; }

        public bool IsVisible { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}
