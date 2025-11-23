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
        public string? TabletImagePath { get; set; }
        public string? MobileImagePath { get; set; }
        public string ImageAlt { get; set; } = string.Empty;
        public string? LinkUrl { get; set; }
        public string? ButtonText { get; set; }
        public string ButtonClass { get; set; } = "btn-primary";
        public string? BackgroundColor { get; set; }
        public string? TextColor { get; set; }
        public string TextAlignment { get; set; } = "left";
        public int DisplayOrder { get; set; }
        
        // Routing properties for ASP.NET MVC routing
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? AreaName { get; set; }
        
        // Advanced carousel properties
        public string AnimationType { get; set; } = "fade"; // fade, slide, zoom
        public int Duration { get; set; } = 5000; // Autoplay duration in milliseconds
        public string? CustomCssClass { get; set; } // Custom CSS classes for the slide
        
        /// <summary>
        /// Full URL path for the desktop image
        /// </summary>
        public string FullImagePath { get; set; } = string.Empty;
        
        /// <summary>
        /// Full URL path for tablet image
        /// </summary>
        public string? FullTabletImagePath { get; set; }
        
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
