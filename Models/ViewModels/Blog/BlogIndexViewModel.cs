using Kokomija.Entity;

namespace Kokomija.Models.ViewModels.Blog
{
    public class BlogIndexViewModel
    {
        public IEnumerable<BlogPostViewModel> Posts { get; set; } = new List<BlogPostViewModel>();
        public IEnumerable<BlogCategory> Categories { get; set; } = new List<BlogCategory>();
        public IEnumerable<TagViewModel> PopularTags { get; set; } = new List<TagViewModel>();
        public IEnumerable<BlogPostViewModel> RecentPosts { get; set; } = new List<BlogPostViewModel>();
        
        // Filter properties
        public int? SelectedCategoryId { get; set; }
        public string? SelectedTag { get; set; }
        public string? SearchQuery { get; set; }
        
        // Pagination
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int PageSize { get; set; } = 9;
        public int TotalPosts { get; set; }
    }

    public class BlogPostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Excerpt { get; set; } = string.Empty;
        public string? FeaturedImage { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string? AuthorAvatar { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int Views { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public int ReadingTimeMinutes { get; set; }
    }

    public class TagViewModel
    {
        public string Name { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}
