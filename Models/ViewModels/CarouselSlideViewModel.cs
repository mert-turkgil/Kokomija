namespace Kokomija.Models.ViewModels
{
    /// <summary>
    /// View model for carousel slide component
    /// </summary>
    public class CarouselSlideViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Subtitle { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public string? MobileImagePath { get; set; }
        public string ImageAlt { get; set; } = string.Empty;
        public string? LinkUrl { get; set; }
        public string? ButtonText { get; set; }
        public string ButtonClass { get; set; } = "btn-primary";
        public string? BackgroundColor { get; set; }
        public string? TextColor { get; set; }
        public string TextAlignment { get; set; } = "left";
        public int DisplayOrder { get; set; }
        
        /// <summary>
        /// Full URL path for the image
        /// </summary>
        public string FullImagePath { get; set; } = string.Empty;
        
        /// <summary>
        /// Full URL path for mobile image
        /// </summary>
        public string? FullMobileImagePath { get; set; }
        
        /// <summary>
        /// Whether to use fallback logo image
        /// </summary>
        public bool UseFallbackImage { get; set; }
    }
    
    /// <summary>
    /// Collection of carousel slides for the component
    /// </summary>
    public class CarouselSlideCollectionViewModel
    {
        public List<CarouselSlideViewModel> Slides { get; set; } = new();
        public string FallbackImagePath { get; set; } = "/img/logo_black.png";
    }
}
