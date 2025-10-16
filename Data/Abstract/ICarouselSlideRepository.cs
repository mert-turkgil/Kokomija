using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface ICarouselSlideRepository : IRepository<CarouselSlide>
    {
        /// <summary>
        /// Get active carousel slides for a specific location
        /// </summary>
        Task<IEnumerable<CarouselSlide>> GetActiveSlidesByLocationAsync(string location, int? categoryId = null);

        /// <summary>
        /// Get scheduled slides that should be active now
        /// </summary>
        Task<IEnumerable<CarouselSlide>> GetScheduledActiveSlides(string location);

        /// <summary>
        /// Get all slides ordered by display order
        /// </summary>
        Task<IEnumerable<CarouselSlide>> GetAllOrderedAsync();

        /// <summary>
        /// Get slides by location
        /// </summary>
        Task<IEnumerable<CarouselSlide>> GetByLocationAsync(string location);

        /// <summary>
        /// Get slides by category
        /// </summary>
        Task<IEnumerable<CarouselSlide>> GetByCategoryAsync(int categoryId);

        /// <summary>
        /// Update display orders
        /// </summary>
        Task UpdateDisplayOrdersAsync(Dictionary<int, int> slideOrders);

        /// <summary>
        /// Toggle slide active status
        /// </summary>
        Task ToggleActiveStatusAsync(int slideId);
    }
}
