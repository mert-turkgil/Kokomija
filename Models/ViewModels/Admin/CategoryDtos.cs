namespace Kokomija.Models.ViewModels.Admin
{
    /// <summary>
    /// DTO for creating a new category with translations
    /// </summary>
    public class CategoryCreateDto
    {
        public int? ParentCategoryId { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool ShowInNavbar { get; set; } = true;
        
        // For main categories: upload image
        public string? ImageTempFileName { get; set; }
        
        // For subcategories: Font Awesome icon OR uploaded icon image
        public string? IconCssClass { get; set; }
        public string? IconImageTempFileName { get; set; }
        public string? ExistingIconImagePath { get; set; } // Reuse an existing icon from another category
        
        // Styling
        public string? ButtonClass { get; set; }
        
        // Translations (one per language)
        public List<CategoryTranslationDto> Translations { get; set; } = new();
    }

    /// <summary>
    /// DTO for updating an existing category
    /// </summary>
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool ShowInNavbar { get; set; }
        
        // Optional new image (only if changing)
        public string? NewImageTempFileName { get; set; }
        
        // For subcategories: Font Awesome icon OR uploaded icon image
        public string? IconCssClass { get; set; }
        public string? IconImagePath { get; set; } // Current icon image path
        public string? NewIconImageTempFileName { get; set; } // New icon upload
        public string? ExistingIconImagePath { get; set; } // Reuse an existing icon from another category
        
        // Translations (one per language)
        public List<CategoryTranslationDto> Translations { get; set; } = new();
    }

    /// <summary>
    /// DTO for category translation
    /// </summary>
    public class CategoryTranslationDto
    {
        public int? Id { get; set; } // Null for new translations
        public string CultureCode { get; set; } = string.Empty; // e.g., "en-US", "pl-PL"
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
    }

    /// <summary>
    /// DTO for temporary image upload
    /// </summary>
    public class CategoryImageUploadDto
    {
        public string TempFileName { get; set; } = string.Empty;
        public string TempPath { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO for canceling an upload
    /// </summary>
    public class CategoryCancelUploadDto
    {
        public List<string> TempFileNames { get; set; } = new();
    }

    /// <summary>
    /// Enhanced view model for displaying category in admin
    /// </summary>
    public class CategoryAdminViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? IconCssClass { get; set; }
        public string? IconImagePath { get; set; }
        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryName { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public bool ShowInNavbar { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        
        // Subcategories
        public List<CategoryAdminViewModel> SubCategories { get; set; } = new();
        
        // Translations
        public Dictionary<string, CategoryTranslationDto> TranslationsByCulture { get; set; } = new();
        public int TranslationCount { get; set; }
        public int ProductCount { get; set; }
    }

    /// <summary>
    /// DTO for Font Awesome icon picker
    /// </summary>
    public class FontAwesomeIcon
    {
        public string Name { get; set; } = string.Empty;
        public string CssClass { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
