using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity;

public class WishlistNotification
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int WishlistId { get; set; }

    [ForeignKey(nameof(WishlistId))]
    public Wishlist Wishlist { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public string NotificationType { get; set; } = string.Empty; // "PriceDropped", "NewDiscount", "NewCoupon", "BackInStock"

    [Required]
    [MaxLength(500)]
    public string Message { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? OldPrice { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? NewPrice { get; set; }

    [MaxLength(100)]
    public string? CouponCode { get; set; }

    [Required]
    public bool IsRead { get; set; } = false;

    [Required]
    public bool EmailSent { get; set; } = false;

    public DateTime? EmailSentAt { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
