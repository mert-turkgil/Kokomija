using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Blog category entity
    /// </summary>
    public class BlogCategory
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// URL-friendly slug
        /// </summary>
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Category description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Category icon or image URL
        /// </summary>
        public string? IconUrl { get; set; }

        /// <summary>
        /// Display order for sorting
        /// </summary>
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Is category active
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Language code (pl, en, etc.)
        /// </summary>
        public string Language { get; set; } = "pl";

        /// <summary>
        /// Optional: Link to product category for filtering related products
        /// </summary>
        public int? ProductCategoryId { get; set; }
        
        [ForeignKey("ProductCategoryId")]
        public Category? ProductCategory { get; set; }

        /// <summary>
        /// Meta description for SEO
        /// </summary>
        public string? MetaDescription { get; set; }

        /// <summary>
        /// Creation date
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Last update date
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Soft delete flag
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Blog posts in this category
        /// </summary>
        public ICollection<Blog>? Blogs { get; set; }
    }
}
