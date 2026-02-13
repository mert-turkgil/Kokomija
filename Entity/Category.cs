using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Product categories with hierarchical structure and multilingual support
    /// </summary>
    public class Category
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Default name (fallback if translation not available)
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Default slug (fallback if translation not available)
        /// </summary>
        [MaxLength(100)]
        public string Slug { get; set; } = string.Empty;

        /// <summary>
        /// Legacy localization key (deprecated, use Translations instead)
        /// </summary>
        [MaxLength(100)]
        public string? NameKey { get; set; }

        /// <summary>
        /// Default description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Parent category ID for hierarchical structure
        /// </summary>
        public int? ParentCategoryId { get; set; }
        
        [ForeignKey("ParentCategoryId")]
        public Category? ParentCategory { get; set; }

        /// <summary>
        /// Display order for sorting
        /// </summary>
        public int DisplayOrder { get; set; } = 0;

        /// <summary>
        /// Show in navigation menu
        /// </summary>
        public bool ShowInNavbar { get; set; } = true;

        /// <summary>
        /// Is category active/visible
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Font Awesome icon class (e.g., "fa-solid fa-shirt" for subcategories)
        /// </summary>
        [MaxLength(100)]
        public string? IconCssClass { get; set; }

        /// <summary>
        /// Custom icon image path for subcategories (alternative to Font Awesome icons)
        /// e.g., /img/category-icons/custom-icon.png
        /// </summary>
        [MaxLength(500)]
        public string? IconImagePath { get; set; }

        /// <summary>
        /// Image path for main/parent categories (e.g., /img/categories/women.jpg)
        /// </summary>
        [MaxLength(500)]
        public string? ImageUrl { get; set; }

        /// <summary>
        /// Creator user ID
        /// </summary>
        [MaxLength(450)]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Creation timestamp
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Last updater user ID
        /// </summary>
        [MaxLength(450)]
        public string? UpdatedBy { get; set; }

        /// <summary>
        /// Last update timestamp
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        /// <summary>
        /// Child categories (subcategories)
        /// </summary>
        public ICollection<Category> SubCategories { get; set; } = new List<Category>();

        /// <summary>
        /// Products in this category
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();

        /// <summary>
        /// Multilingual translations for this category
        /// </summary>
        public ICollection<CategoryTranslation> Translations { get; set; } = new List<CategoryTranslation>();
    }
}
