using System.ComponentModel.DataAnnotations;

namespace Kokomija.Entity
{
    /// <summary>
    /// Represents pack quantity options (5-pack, 6-pack, 8-pack, etc.)
    /// </summary>
    public class PackQuantity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; } // 1, 5, 6, 8, 10, etc.

        [MaxLength(50)]
        public string? Name { get; set; } // "5-Pack", "6-Pack", etc.

        [MaxLength(100)]
        public string? NameKey { get; set; } // Translation key: "PackQuantity_5Pack", "PackQuantity_6Pack"

        public int DisplayOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
