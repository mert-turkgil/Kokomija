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
                _logger.LogInformation("Loading carousel slides for location: {Location}, categoryId: {CategoryId}", location, categoryId);
                var slides = await _carouselService.GetSlidesByLocationAsync(location, categoryId);

                _logger.LogInformation("Found {Count} total slides for location: {Location}", slides.Count(), location);
                
                if (!slides.Any())
                {
                    _logger.LogWarning("No carousel slides found for location: {Location}", location);
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
            
            // Get current culture code
            var currentCulture = System.Globalization.CultureInfo.CurrentUICulture.Name;
            
            // Get translation for current culture, fallback to first available translation or null
            var translation = slide.Translations?.FirstOrDefault(t => t.CultureCode == currentCulture)
                ?? slide.Translations?.FirstOrDefault();
            
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

            // Generate URL from controller/action if specified
            string? linkUrl = translation?.LinkUrl ?? slide.LinkUrl;
            
            // Priority: translation controller/action > slide RouteName > LinkUrl
            if (!string.IsNullOrEmpty(translation?.ControllerName) && !string.IsNullOrEmpty(translation.ActionName))
            {
                try
                {
                    var routeValues = new Dictionary<string, object?>();
                    
                    // Add area if specified
                    if (!string.IsNullOrEmpty(translation.AreaName))
                    {
                        routeValues["area"] = translation.AreaName;
                    }
                    
                    // Parse additional route parameters if provided
                    if (!string.IsNullOrEmpty(translation.RouteParameters))
                    {
                        var additionalParams = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(translation.RouteParameters);
                        if (additionalParams != null)
                        {
                            foreach (var param in additionalParams)
                            {
                                routeValues[param.Key] = param.Value;
                            }
                        }
                    }
                    
                    linkUrl = Url.Action(translation.ActionName, translation.ControllerName, routeValues.Any() ? routeValues : null);
                    _logger.LogInformation("Generated link URL from translation: {Url} (Controller: {Controller}, Action: {Action})", 
                        linkUrl, translation.ControllerName, translation.ActionName);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error generating URL from translation controller/action for slide {SlideId}", slide.Id);
                }
            }
            else if (!string.IsNullOrEmpty(slide.RouteName))
            {
                try
                {
                    // Parse route parameters if provided
                    object? routeValues = null;
                    var routeParams = slide.RouteParameters;
                    if (!string.IsNullOrEmpty(routeParams))
                    {
                        routeValues = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(routeParams);
                    }

                    linkUrl = Url.RouteUrl(slide.RouteName, routeValues);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Error generating route URL for slide {SlideId}, route: {RouteName}", slide.Id, slide.RouteName);
                }
            }

            // Get localized text from translation, fallback to main slide entity
            var title = translation?.Title ?? slide.Title;
            var subtitle = translation?.Subtitle ?? slide.Subtitle;
            var buttonText = translation?.ButtonText ?? slide.ButtonText;
            var imageAlt = translation?.ImageAlt ?? slide.ImageAlt;

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
                ImageAlt = imageAlt,
                LinkUrl = linkUrl,
                ButtonText = buttonText,
                ButtonClass = slide.ButtonClass ?? "btn-primary",
                BackgroundColor = slide.BackgroundColor,
                TextColor = slide.TextColor,
                TextAlignment = slide.TextAlign ?? "center",
                DisplayOrder = slide.DisplayOrder,
                UseFallbackImage = useFallback,
                AnimationType = slide.AnimationType ?? "fade",
                Duration = slide.Duration,
                CustomCssClass = slide.CustomCssClass,
                ControllerName = translation?.ControllerName,
                ActionName = translation?.ActionName,
                AreaName = translation?.AreaName
            };
        }
    }
}
