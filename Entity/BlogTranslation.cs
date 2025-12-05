using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Stores translations for blog posts in multiple languages
    /// </summary>
    public class BlogTranslation
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Reference to the blog post
        /// </summary>
        public int BlogId { get; set; }
        
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; } = null!;

        /// <summary>
        /// Language/culture code (e.g., "en-US", "pl-PL")
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string CultureCode { get; set; } = string.Empty;

        /// <summary>
        /// Translated blog post title
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Translated URL-friendly slug
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Translated blog post content (HTML from CKEditor)
        /// </summary>
        [Required]
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Translated short excerpt for preview
        /// </summary>
        [MaxLength(500)]
        public string? Excerpt { get; set; }

        /// <summary>
        /// SEO meta description
        /// </summary>
        [MaxLength(160)]
        public string? MetaDescription { get; set; }

        /// <summary>
        /// SEO meta keywords (comma-separated)
        /// </summary>
        [MaxLength(500)]
        public string? MetaKeywords { get; set; }

        /// <summary>
        /// Translated comma-separated tags
        /// </summary>
        [MaxLength(500)]
        public string? Tags { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Last update date
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
