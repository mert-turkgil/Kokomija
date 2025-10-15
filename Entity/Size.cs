using System.ComponentModel.DataAnnotations;

namespace Kokomija.Entity
{
    public class Size
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Name { get; set; } = string.Empty; // S, M, L, XL, XXL

        [MaxLength(50)]
        public string? DisplayName { get; set; }

        [MaxLength(20)]
        public string? Region { get; set; } // EU, US, UK

        public int DisplayOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
