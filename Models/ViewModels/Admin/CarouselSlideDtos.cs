namespace Kokomija.Models.ViewModels.Admin
{
    /// <summary>
    /// DTO for creating a new carousel slide with translations
    /// </summary>
    public class CarouselSlideCreateDto
    {
        // Base slide properties
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; } = "Home";
        public int? CategoryId { get; set; }
        
        // Temporary file names for the three responsive images
        public string? DesktopImageTempFileName { get; set; }
        public string? TabletImageTempFileName { get; set; }
        public string? MobileImageTempFileName { get; set; }

        // Styling options
        public string? BackgroundColor { get; set; }
        public string? TextColor { get; set; }
        public string TextAlign { get; set; } = "center";
        public string? AnimationType { get; set; } = "fade";
        public int Duration { get; set; } = 5000;
        public string? CustomCssClass { get; set; }
        public string? ButtonClass { get; set; } = "btn-primary";

        // Translations (one per language)
        public List<CarouselSlideTranslationDto> Translations { get; set; } = new();
    }

    /// <summary>
    /// DTO for updating an existing carousel slide
    /// </summary>
    public class CarouselSlideUpdateDto
    {
        public int Id { get; set; }
        
        // Base slide properties
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; } = "Home";
        public int? CategoryId { get; set; }
        
        // Optional new images (only if changing)
        public string? NewDesktopImageTempFileName { get; set; }
        public string? NewTabletImageTempFileName { get; set; }
        public string? NewMobileImageTempFileName { get; set; }

        // Styling options
        public string? BackgroundColor { get; set; }
        public string? TextColor { get; set; }
        public string TextAlign { get; set; } = "center";
        public string? AnimationType { get; set; } = "fade";
        public int Duration { get; set; } = 5000;
        public string? CustomCssClass { get; set; }
        public string? ButtonClass { get; set; } = "btn-primary";

        // Translations (one per language)
        public List<CarouselSlideTranslationDto> Translations { get; set; } = new();
    }

    /// <summary>
    /// DTO for carousel slide translation
    /// </summary>
    public class CarouselSlideTranslationDto
    {
        public int? Id { get; set; } // Null for new translations
        public string CultureCode { get; set; } = string.Empty; // e.g., "en-US", "pl-PL"
        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; }
        public string? ButtonText { get; set; }
        public string? ImageAlt { get; set; }
        
        // ASP.NET Routing
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? AreaName { get; set; }
        public string? RouteParameters { get; set; } // JSON string
        
        // Or direct URL (one of these will be used)
        public string? LinkUrl { get; set; }
    }

    /// <summary>
    /// DTO for temporary image upload
    /// </summary>
    public class CarouselImageUploadDto
    {
        public string ImageType { get; set; } = "desktop"; // "desktop", "tablet", "mobile"
        public string TempFileName { get; set; } = string.Empty;
        public string TempPath { get; set; } = string.Empty;
    }

    /// <summary>
    /// DTO for canceling an upload
    /// </summary>
    public class CarouselCancelUploadDto
    {
        public List<string> TempFileNames { get; set; } = new();
    }

    /// <summary>
    /// Enhanced view model for displaying carousel slide in admin settings
    /// </summary>
    public class CarouselSlideAdminViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string? TabletImagePath { get; set; }
        public string? MobileImagePath { get; set; }
        public string? ButtonText { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; } = "Home";
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        
        // Additional display properties
        public Dictionary<string, CarouselSlideTranslationDto> TranslationsByCulture { get; set; } = new();
        public bool HasActiveTranslations { get; set; }
        public int TranslationCount { get; set; }
    }
}
