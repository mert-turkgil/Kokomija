using Kokomija.Data.Abstract;
using Kokomija.Models.ViewModels;
using Kokomija.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Kokomija.Resources.CarouselResources;

namespace Kokomija.ViewComponents
{
    /// <summary>
    /// View component for displaying carousel slides on homepage
    /// </summary>
    public class CarouselSlideViewComponent : ViewComponent
    {
        private readonly ICarouselService _carouselService;
        private readonly ILogger<CarouselSlideViewComponent> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly IStringLocalizer<CarouselResources> _localizer;

        public CarouselSlideViewComponent(
            ICarouselService carouselService,
            ILogger<CarouselSlideViewComponent> logger,
            IWebHostEnvironment environment,
            IStringLocalizer<CarouselResources> localizer)
        {
            _carouselService = carouselService;
            _logger = logger;
            _environment = environment;
            _localizer = localizer;
        }

        public async Task<IViewComponentResult> InvokeAsync(string location = "home", int? categoryId = null)
        {
            try
            {
                var slides = await _carouselService.GetSlidesByLocationAsync(location, categoryId);

                if (!slides.Any())
                {
                    _logger.LogInformation("No carousel slides found for location: {Location}", location);
                    return Content(string.Empty);
                }

                var slideViewModels = slides
                    .Where(s => s.IsActive && !s.IsDeleted)
                    .Where(s => 
                        (!s.StartDate.HasValue || s.StartDate.Value <= DateTime.UtcNow) &&
                        (!s.EndDate.HasValue || s.EndDate.Value >= DateTime.UtcNow))
                    .OrderBy(s => s.DisplayOrder)
                    .Select(slide => CreateSlideViewModel(slide))
                    .ToList();

                if (!slideViewModels.Any())
                {
                    _logger.LogInformation("No active carousel slides found for location: {Location}", location);
                    return Content(string.Empty);
                }

                var model = new CarouselSlideCollectionViewModel
                {
                    Slides = slideViewModels,
                    FallbackImagePath = "/img/logo_black.png"
                };

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading carousel slides for location: {Location}", location);
                return Content(string.Empty);
            }
        }

        private CarouselSlideViewModel CreateSlideViewModel(Entity.CarouselSlide slide)
        {
            var wwwRootPath = _environment.WebRootPath;
            var desktopImagePath = slide.ImagePath;
            var tabletImagePath = slide.TabletImagePath;
            var mobileImagePath = slide.MobileImagePath;
            
            // Check if desktop image exists, if not use fallback
            var useFallback = false;
            if (!string.IsNullOrEmpty(desktopImagePath))
            {
                var fullPath = Path.Combine(wwwRootPath, desktopImagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (!File.Exists(fullPath))
                {
                    _logger.LogWarning("Desktop image not found: {ImagePath}, using fallback", desktopImagePath);
                    useFallback = true;
                    desktopImagePath = "/img/logo_black.png";
                }
            }
            else
            {
                useFallback = true;
                desktopImagePath = "/img/logo_black.png";
            }

            // Check tablet image
            if (!string.IsNullOrEmpty(tabletImagePath))
            {
                var fullTabletPath = Path.Combine(wwwRootPath, tabletImagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (!File.Exists(fullTabletPath))
                {
                    tabletImagePath = desktopImagePath; // Use desktop image if tablet doesn't exist
                }
            }
            else
            {
                tabletImagePath = desktopImagePath; // Use desktop image if no tablet version specified
            }

            // Check mobile image
            if (!string.IsNullOrEmpty(mobileImagePath))
            {
                var fullMobilePath = Path.Combine(wwwRootPath, mobileImagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (!File.Exists(fullMobilePath))
                {
                    mobileImagePath = tabletImagePath; // Use tablet image if mobile doesn't exist
                }
            }
            else
            {
                mobileImagePath = tabletImagePath; // Use tablet image if no mobile version specified
            }

            // Generate URL from route if RouteName is specified
            string? linkUrl = slide.LinkUrl;
            if (!string.IsNullOrEmpty(slide.RouteName))
            {
                try
                {
                    // Parse route parameters if provided
                    object? routeValues = null;
                    if (!string.IsNullOrEmpty(slide.RouteParameters))
                    {
                        routeValues = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(slide.RouteParameters);
                    }

                    linkUrl = Url.RouteUrl(slide.RouteName, routeValues);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error generating route URL for slide {SlideId}, route: {RouteName}", slide.Id, slide.RouteName);
                    // Fall back to LinkUrl if route generation fails
                }
            }

            // Try to get localized text from SharedResources, fall back to stored text
            var titleLocalized = _localizer[slide.Title];
            var title = titleLocalized.ResourceNotFound ? slide.Title : titleLocalized.Value;
            
            _logger.LogDebug("Carousel Title - Key: {Key}, Value: {Value}, ResourceNotFound: {NotFound}", 
                slide.Title, title, titleLocalized.ResourceNotFound);
            
            var subtitle = !string.IsNullOrEmpty(slide.Subtitle) 
                ? (_localizer[slide.Subtitle].ResourceNotFound ? slide.Subtitle : _localizer[slide.Subtitle].Value)
                : slide.Subtitle;
            var buttonText = !string.IsNullOrEmpty(slide.ButtonText)
                ? (_localizer[slide.ButtonText].ResourceNotFound ? slide.ButtonText : _localizer[slide.ButtonText].Value)
                : slide.ButtonText;

            return new CarouselSlideViewModel
            {
                Id = slide.Id,
                Title = title,
                Subtitle = subtitle,
                ImagePath = desktopImagePath,
                TabletImagePath = tabletImagePath,
                MobileImagePath = mobileImagePath,
                FullImagePath = Url.Content($"~{desktopImagePath}"),
                FullTabletImagePath = !string.IsNullOrEmpty(tabletImagePath) 
                    ? Url.Content($"~{tabletImagePath}") 
                    : null,
                FullMobileImagePath = !string.IsNullOrEmpty(mobileImagePath) 
                    ? Url.Content($"~{mobileImagePath}") 
                    : null,
                ImageAlt = slide.ImageAlt,
                LinkUrl = linkUrl,
                ButtonText = buttonText,
                ButtonClass = slide.ButtonClass ?? "btn-primary",
                BackgroundColor = slide.BackgroundColor,
                TextColor = slide.TextColor,
                TextAlignment = slide.TextAlign ?? "center",
                DisplayOrder = slide.DisplayOrder,
                UseFallbackImage = useFallback
            };
        }
    }
}
