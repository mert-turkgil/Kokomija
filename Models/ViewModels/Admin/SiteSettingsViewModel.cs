using Kokomija.Entity;

namespace Kokomija.Models.ViewModels.Admin
{
    public class SiteSettingsViewModel
    {
        // Carousel Management
        public List<CarouselSlideItemViewModel> CarouselSlides { get; set; } = new();
        public int TotalCarouselSlides { get; set; }
        public int ActiveCarouselSlides { get; set; }

        // Category Management
        public List<CategoryItemViewModel> Categories { get; set; } = new();
        public int TotalCategories { get; set; }
        public int ActiveCategories { get; set; }
        public int TotalSubcategories { get; set; }

        // Translation Management
        public List<TranslationKeyViewModel> TranslationKeys { get; set; } = new();
        public int TotalTranslationKeys { get; set; }
        public List<LanguageViewModel> SupportedLanguages { get; set; } = new();
    }

    public class CarouselSlideItemViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string? LinkUrl { get; set; }
        public string? ButtonText { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; } = "home";
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }

    public class CategoryItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? NameKey { get; set; }
        public string Slug { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
        public string? ParentCategoryName { get; set; }
        public int DisplayOrder { get; set; }
        public bool ShowInNavbar { get; set; }
        public bool IsActive { get; set; }
        public string? IconCssClass { get; set; }
        public string? ImageUrl { get; set; }
        public int ProductCount { get; set; }
        public int SubcategoryCount { get; set; }
        public List<CategoryItemViewModel> Subcategories { get; set; } = new();
    }

    public class TranslationKeyViewModel
    {
        public string Key { get; set; } = string.Empty;
        public Dictionary<string, string> Values { get; set; } = new();
        public string Category { get; set; } = string.Empty;
        public DateTime? LastModified { get; set; }
    }

    public class LanguageViewModel
    {
        public int Id { get; set; }
        public string CultureCode { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string NativeName { get; set; } = string.Empty;
        public string? FlagIcon { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsDefault { get; set; }
        public int DisplayOrder { get; set; }
    }
}
