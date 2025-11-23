using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Stores translations for carousel slides in multiple languages
    /// </summary>
    public class CarouselSlideTranslation
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Reference to the carousel slide
        /// </summary>
        public int CarouselSlideId { get; set; }
        
        [ForeignKey("CarouselSlideId")]
        public CarouselSlide CarouselSlide { get; set; } = null!;

        /// <summary>
        /// Language/culture code (e.g., "en-US", "pl-PL")
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string CultureCode { get; set; } = string.Empty;

        /// <summary>
        /// Translated title
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Translated subtitle
        /// </summary>
        [MaxLength(500)]
        public string? Subtitle { get; set; }

        /// <summary>
        /// Translated button text
        /// </summary>
        [MaxLength(100)]
        public string? ButtonText { get; set; }

        /// <summary>
        /// Localized link URL (can be different per language)
        /// </summary>
        [MaxLength(500)]
        public string? LinkUrl { get; set; }

        /// <summary>
        /// ASP.NET Controller name for routing
        /// </summary>
        [MaxLength(100)]
        public string? ControllerName { get; set; }

        /// <summary>
        /// ASP.NET Action name for routing
        /// </summary>
        [MaxLength(100)]
        public string? ActionName { get; set; }

        /// <summary>
        /// ASP.NET Area name for routing (optional)
        /// </summary>
        [MaxLength(100)]
        public string? AreaName { get; set; }

    /// <summary>
    /// Route parameters as JSON (e.g., {"category": "damskie", "slug": "new-collection"})
    /// </summary>
    [MaxLength(1000)]
    public string? RouteParameters { get; set; }

    /// <summary>
    /// Alt text for image (SEO and accessibility)
    /// </summary>
    [Required]
    [MaxLength(300)]
    public string ImageAlt { get; set; } = string.Empty;

    /// <summary>
    /// Creation timestamp
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;        /// <summary>
        /// Last update timestamp
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
