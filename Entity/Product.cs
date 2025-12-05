using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Default product name (fallback if no translation found)
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Default product description (fallback if no translation found)
        /// </summary>
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(100)]
        public string StripeProductId { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string StripePriceId { get; set; } = string.Empty;

        /// <summary>
        /// Stripe Tax Code for automatic tax calculation (e.g., txcd_99999999 for general tangible goods)
        /// </summary>
        [MaxLength(50)]
        public string? StripeTaxCode { get; set; }

        /// <summary>
        /// Number of items in the package/pack. 1 for single items, >1 for packs (e.g., 5-pack, 8-pack)
        /// </summary>
        public int PackSize { get; set; } = 1;

        /// <summary>
        /// Optional: Groups related products (e.g., 5-pack, 6-pack, 8-pack of same item)
        /// </summary>
        public int? ProductGroupId { get; set; }
        [ForeignKey("ProductGroupId")]
        public ProductGroup? ProductGroup { get; set; }

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
        public ICollection<ProductTranslation> Translations { get; set; } = new List<ProductTranslation>();

        // Computed properties
        [NotMapped]
        public decimal AverageRating => Reviews?.Any() == true 
            ? Reviews.Where(r => r.IsVisible).Average(r => r.Rating) 
            : 0;

        [NotMapped]
        public int ReviewCount => Reviews?.Count(r => r.IsVisible) ?? 0;
    }
}
