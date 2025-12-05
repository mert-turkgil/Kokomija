using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels.Admin
{
    /// <summary>
    /// DTO for creating a new blog post with translations
    /// </summary>
    public class BlogCreateDto
    {
        public int CategoryId { get; set; }
        public int? ProductId { get; set; }
        public string? FeaturedImage { get; set; }
        public string? ImageTempFileName { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool AllowComments { get; set; } = true;

        public List<BlogTranslationDto> Translations { get; set; } = new();
    }

    /// <summary>
    /// DTO for updating an existing blog post with translations
    /// </summary>
    public class BlogUpdateDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int? ProductId { get; set; }
        public string? FeaturedImage { get; set; }
        public string? NewImageTempFileName { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }
        public bool AllowComments { get; set; } = true;

        public List<BlogTranslationDto> Translations { get; set; } = new();
    }

    /// <summary>
    /// DTO for blog translation in a specific language
    /// </summary>
    public class BlogTranslationDto
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string CultureCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Slug { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Excerpt { get; set; }

        [MaxLength(500)]
        public string? Tags { get; set; }

        [MaxLength(160)]
        public string? MetaDescription { get; set; }

        [MaxLength(500)]
        public string? MetaKeywords { get; set; }
    }

    /// <summary>
    /// DTO for canceling image upload
    /// </summary>
    public class BlogCancelUploadDto
    {
        public string? ImageTempFileName { get; set; }
    }

    /// <summary>
    /// View model for blog list item in admin
    /// </summary>
    public class BlogItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? FeaturedImage { get; set; }
        public string AuthorName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }
        public int Views { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
