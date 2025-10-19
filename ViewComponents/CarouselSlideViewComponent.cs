using Kokomija.Data.Abstract;
using Kokomija.Models.ViewModels;
using Kokomija.Services;
using Microsoft.AspNetCore.Mvc;

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

        public CarouselSlideViewComponent(
            ICarouselService carouselService,
            ILogger<CarouselSlideViewComponent> logger,
            IWebHostEnvironment environment)
        {
            _carouselService = carouselService;
            _logger = logger;
            _environment = environment;
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
            var imagePath = slide.ImagePath;
            var mobileImagePath = slide.MobileImagePath;
            
            // Check if image exists, if not use fallback
            var useFallback = false;
            if (!string.IsNullOrEmpty(imagePath))
            {
                var fullPath = Path.Combine(wwwRootPath, imagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (!File.Exists(fullPath))
                {
                    _logger.LogWarning("Image not found: {ImagePath}, using fallback", imagePath);
                    useFallback = true;
                    imagePath = "/img/logo_black.png";
                }
            }
            else
            {
                useFallback = true;
                imagePath = "/img/logo_black.png";
            }

            // Check mobile image
            if (!string.IsNullOrEmpty(mobileImagePath))
            {
                var fullMobilePath = Path.Combine(wwwRootPath, mobileImagePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (!File.Exists(fullMobilePath))
                {
                    mobileImagePath = imagePath; // Use desktop image if mobile doesn't exist
                }
            }
            else
            {
                mobileImagePath = imagePath; // Use desktop image if no mobile version specified
            }

            // Use English text directly (localization can be added later)
            var title = slide.Title;
            var subtitle = slide.Subtitle;
            var buttonText = slide.ButtonText;

            return new CarouselSlideViewModel
            {
                Id = slide.Id,
                Title = title,
                Subtitle = subtitle,
                ImagePath = imagePath,
                MobileImagePath = mobileImagePath,
                FullImagePath = Url.Content($"~{imagePath}"),
                FullMobileImagePath = !string.IsNullOrEmpty(mobileImagePath) 
                    ? Url.Content($"~{mobileImagePath}") 
                    : null,
                ImageAlt = slide.ImageAlt,
                LinkUrl = slide.LinkUrl,
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
