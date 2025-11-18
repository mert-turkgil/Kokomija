using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity;

public class ProductPriceHistory
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal OldPrice { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal NewPrice { get; set; }

    [MaxLength(500)]
    public string? Reason { get; set; } // "Manual Update", "Coupon Applied", "Seasonal Discount", etc.

    [Required]
    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

    [MaxLength(100)]
    public string? ChangedBy { get; set; } // UserId or "System"
}
