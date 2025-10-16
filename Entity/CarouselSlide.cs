using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Represents a carousel slide for homepage or category pages
    /// </summary>
    public class CarouselSlide
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of the slide (can be multilingual key)
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Subtitle or description (can be multilingual key)
        /// </summary>
        [MaxLength(500)]
        public string? Subtitle { get; set; }

        /// <summary>
        /// Image path (relative to wwwroot/Img/Carousel/)
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string ImagePath { get; set; } = string.Empty;

        /// <summary>
        /// Mobile image path (optional, for responsive design)
        /// </summary>
        [MaxLength(500)]
        public string? MobileImagePath { get; set; }

        /// <summary>
        /// Alt text for image (SEO and accessibility)
        /// </summary>
        [Required]
        [MaxLength(300)]
        public string ImageAlt { get; set; } = string.Empty;

        /// <summary>
        /// Link URL when slide is clicked
        /// </summary>
        [MaxLength(500)]
        public string? LinkUrl { get; set; }

        /// <summary>
        /// Link text for button (can be multilingual key)
        /// </summary>
        [MaxLength(100)]
        public string? ButtonText { get; set; }

        /// <summary>
        /// CSS class for button styling
        /// </summary>
        [MaxLength(100)]
        public string? ButtonClass { get; set; } = "btn-primary";

        /// <summary>
        /// Display order (lower numbers appear first)
        /// </summary>
        public int DisplayOrder { get; set; } = 0;

        /// <summary>
        /// Is slide active and visible
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Start date for scheduled slides
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// End date for scheduled slides
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Carousel location (home, category, product)
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Location { get; set; } = "home";

        /// <summary>
        /// Optional category ID for category-specific carousels
        /// </summary>
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        /// <summary>
        /// Background color (hex code or CSS color name)
        /// </summary>
        [MaxLength(50)]
        public string? BackgroundColor { get; set; }

        /// <summary>
        /// Text color (hex code or CSS color name)
        /// </summary>
        [MaxLength(50)]
        public string? TextColor { get; set; }

        /// <summary>
        /// Text alignment (left, center, right)
        /// </summary>
        [MaxLength(20)]
        public string TextAlign { get; set; } = "center";

        /// <summary>
        /// Animation type (fade, slide, zoom)
        /// </summary>
        [MaxLength(50)]
        public string? AnimationType { get; set; } = "fade";

        /// <summary>
        /// Slide duration in milliseconds
        /// </summary>
        public int Duration { get; set; } = 5000;

        /// <summary>
        /// Custom CSS classes for the slide container
        /// </summary>
        [MaxLength(200)]
        public string? CustomCssClass { get; set; }

        /// <summary>
        /// Creator user ID
        /// </summary>
        [MaxLength(450)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Last updater user ID
        /// </summary>
        [MaxLength(450)]
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// For soft delete
        /// </summary>
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        [MaxLength(450)]
        public string? DeletedBy { get; set; }
    }
}
