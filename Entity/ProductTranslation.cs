using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Stores translations for products in multiple languages
    /// </summary>
    public class ProductTranslation
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Reference to the product
        /// </summary>
        public int ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;

        /// <summary>
        /// Language/culture code (e.g., "en-US", "pl-PL")
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string CultureCode { get; set; } = string.Empty;

        /// <summary>
        /// Translated product name
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Translated product description
        /// </summary>
        [Required]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// SEO-friendly URL slug
        /// </summary>
        [MaxLength(250)]
        public string? Slug { get; set; }

        /// <summary>
        /// Meta description for SEO
        /// </summary>
        [MaxLength(500)]
        public string? MetaDescription { get; set; }

        /// <summary>
        /// Meta keywords for SEO
        /// </summary>
        [MaxLength(500)]
        public string? MetaKeywords { get; set; }

        /// <summary>
        /// When this translation was created
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// When this translation was last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
