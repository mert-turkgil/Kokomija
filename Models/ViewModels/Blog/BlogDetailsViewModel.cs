using Kokomija.Entity;

namespace Kokomija.Models.ViewModels.Blog
{
    public class BlogDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? FeaturedImage { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string? AuthorAvatar { get; set; }
        public string? AuthorBio { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int Views { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public int ReadingTimeMinutes { get; set; }
        
        // Related content
        public IEnumerable<BlogPostViewModel> RelatedPosts { get; set; } = new List<BlogPostViewModel>();
        public Product? RelatedProduct { get; set; }
        
        // SEO
        public string MetaDescription { get; set; } = string.Empty;
        public string MetaKeywords { get; set; } = string.Empty;
        public string CanonicalUrl { get; set; } = string.Empty;
    }
}
