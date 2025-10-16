namespace Kokomija.Entity
{
    /// <summary>
    /// Blog post entity
    /// </summary>
    public class Blog
    {
        /// <summary>
        /// Unique identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Blog post title
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// URL-friendly slug
        /// </summary>
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Blog post content (HTML)
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// Short excerpt for preview
        /// </summary>
        public string? Excerpt { get; set; }

        /// <summary>
        /// Featured image URL
        /// </summary>
        public string? FeaturedImage { get; set; }

        /// <summary>
        /// Author user ID
        /// </summary>
        public string AuthorId { get; set; } = string.Empty;

        /// <summary>
        /// Author user
        /// </summary>
        public ApplicationUser? Author { get; set; }

        /// <summary>
        /// Blog category ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Blog category
        /// </summary>
        public BlogCategory? Category { get; set; }

        /// <summary>
        /// Related product ID (optional)
        /// </summary>
        public int? ProductId { get; set; }

        /// <summary>
        /// Related product
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Publication date
        /// </summary>
        public DateTime? PublishedDate { get; set; }

        /// <summary>
        /// Is blog post published
        /// </summary>
        public bool IsPublished { get; set; }

        /// <summary>
        /// View count
        /// </summary>
        public int Views { get; set; }

        /// <summary>
        /// Meta description for SEO
        /// </summary>
        public string? MetaDescription { get; set; }

        /// <summary>
        /// Meta keywords for SEO
        /// </summary>
        public string? MetaKeywords { get; set; }

        /// <summary>
        /// Comma-separated tags
        /// </summary>
        public string? Tags { get; set; }

        /// <summary>
        /// Language code (pl, en, etc.)
        /// </summary>
        public string Language { get; set; } = "pl";

        /// <summary>
        /// Allow comments
        /// </summary>
        public bool AllowComments { get; set; } = true;

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
    }
}
