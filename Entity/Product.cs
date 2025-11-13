using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? NameKey { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? DescriptionKey { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string StripeProductId { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string StripePriceId { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<ProductImage> Images { get; set; } = new List<ProductImage>();
        public ICollection<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public ICollection<ProductSize> AvailableSizes { get; set; } = new List<ProductSize>();
        public ICollection<ProductColor> AvailableColors { get; set; } = new List<ProductColor>();
        public ICollection<ProductReview> Reviews { get; set; } = new List<ProductReview>();

        // Computed properties
        [NotMapped]
        public decimal AverageRating => Reviews?.Any() == true 
            ? Reviews.Where(r => r.IsVisible).Average(r => r.Rating) 
            : 0;

        [NotMapped]
        public int ReviewCount => Reviews?.Count(r => r.IsVisible) ?? 0;
    }
}
