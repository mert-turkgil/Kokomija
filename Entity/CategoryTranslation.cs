using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Stores translations for categories in multiple languages
    /// </summary>
    public class CategoryTranslation
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Reference to the category
        /// </summary>
        public int CategoryId { get; set; }
        
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;

        /// <summary>
        /// Language/culture code (e.g., "en-US", "pl-PL")
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string CultureCode { get; set; } = string.Empty;

        /// <summary>
        /// Translated category name
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Translated URL-friendly slug
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Translated description
        /// </summary>
        [MaxLength(1000)]
        public string? Description { get; set; }

        /// <summary>
        /// SEO meta description
        /// </summary>
        [MaxLength(160)]
        public string? MetaDescription { get; set; }

        /// <summary>
        /// SEO meta keywords
        /// </summary>
        [MaxLength(500)]
        public string? MetaKeywords { get; set; }

        /// <summary>
        /// Creation timestamp
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Last update timestamp
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
