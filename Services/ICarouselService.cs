using Kokomija.Entity;

namespace Kokomija.Services
{
    public interface ICarouselService
    {
        /// <summary>
        /// Get active carousel slides for homepage
        /// </summary>
        Task<IEnumerable<CarouselSlide>> GetHomepageSlidesAsync();

        /// <summary>
        /// Get active carousel slides for a specific location
        /// </summary>
        Task<IEnumerable<CarouselSlide>> GetSlidesByLocationAsync(string location, int? categoryId = null);

        /// <summary>
        /// Get all carousel slides for admin management
        /// </summary>
        Task<IEnumerable<CarouselSlide>> GetAllSlidesAsync();

        /// <summary>
        /// Get carousel slide by ID
        /// </summary>
        Task<CarouselSlide?> GetSlideByIdAsync(int id);

        /// <summary>
        /// Create new carousel slide
        /// </summary>
        Task<CarouselSlide> CreateSlideAsync(CarouselSlide slide, string createdBy);

        /// <summary>
        /// Update carousel slide
        /// </summary>
        Task<CarouselSlide> UpdateSlideAsync(CarouselSlide slide, string updatedBy);

        /// <summary>
        /// Delete carousel slide (soft delete)
        /// </summary>
        Task<bool> DeleteSlideAsync(int id, string deletedBy);

        /// <summary>
        /// Toggle active status
        /// </summary>
        Task<bool> ToggleActiveStatusAsync(int id);

        /// <summary>
        /// Update display orders for multiple slides
        /// </summary>
        Task UpdateDisplayOrdersAsync(Dictionary<int, int> slideOrders);

        /// <summary>
        /// Upload carousel image
        /// </summary>
        Task<string> UploadImageAsync(IFormFile file, string subfolder = "");

        /// <summary>
        /// Delete carousel image
        /// </summary>
        Task<bool> DeleteImageAsync(string imagePath);
    }
}
