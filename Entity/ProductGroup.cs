using System.ComponentModel.DataAnnotations;

namespace Kokomija.Entity
{
    /// <summary>
    /// Groups related products (e.g., different pack sizes of the same item)
    /// </summary>
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? NameKey { get; set; } // Translation key for group name

        [MaxLength(500)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? DescriptionKey { get; set; } // Translation key for description

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
