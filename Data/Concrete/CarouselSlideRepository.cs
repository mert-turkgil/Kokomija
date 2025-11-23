using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class CarouselSlideRepository : Repository<CarouselSlide>, ICarouselSlideRepository
    {
        private new readonly ApplicationDbContext _context;

        public CarouselSlideRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarouselSlide>> GetActiveSlidesByLocationAsync(string location, int? categoryId = null)
        {
            var now = DateTime.UtcNow;
            
            var query = _context.CarouselSlides
                .Include(cs => cs.Category)
                .Include(cs => cs.Translations)
                .Where(cs => cs.IsActive 
                    && !cs.IsDeleted 
                    && cs.Location.ToLower() == location.ToLower()
                    && (cs.StartDate == null || cs.StartDate <= now)
                    && (cs.EndDate == null || cs.EndDate >= now));

            if (categoryId.HasValue)
            {
                query = query.Where(cs => cs.CategoryId == categoryId.Value || cs.CategoryId == null);
            }

            return await query
                .OrderBy(cs => cs.DisplayOrder)
                .ThenByDescending(cs => cs.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<CarouselSlide>> GetScheduledActiveSlides(string location)
        {
            var now = DateTime.UtcNow;
            
            return await _context.CarouselSlides
                .Include(cs => cs.Category)
                .Where(cs => cs.IsActive 
                    && !cs.IsDeleted 
                    && cs.Location == location
                    && cs.StartDate != null 
                    && cs.StartDate <= now
                    && (cs.EndDate == null || cs.EndDate >= now))
                .OrderBy(cs => cs.DisplayOrder)
                .ThenByDescending(cs => cs.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<CarouselSlide>> GetAllOrderedAsync()
        {
            return await _context.CarouselSlides
                .Include(cs => cs.Category)
                .Include(cs => cs.Translations)
                .Where(cs => !cs.IsDeleted)
                .OrderBy(cs => cs.Location)
                .ThenBy(cs => cs.DisplayOrder)
                .ThenByDescending(cs => cs.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<CarouselSlide>> GetByLocationAsync(string location)
        {
            return await _context.CarouselSlides
                .Include(cs => cs.Category)
                .Include(cs => cs.Translations)
                .Where(cs => cs.Location == location && !cs.IsDeleted)
                .OrderBy(cs => cs.DisplayOrder)
                .ThenByDescending(cs => cs.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<CarouselSlide>> GetByCategoryAsync(int categoryId)
        {
            return await _context.CarouselSlides
                .Include(cs => cs.Category)
                .Include(cs => cs.Translations)
                .Where(cs => cs.CategoryId == categoryId && !cs.IsDeleted)
                .OrderBy(cs => cs.DisplayOrder)
                .ThenByDescending(cs => cs.CreatedAt)
                .ToListAsync();
        }

        public async Task UpdateDisplayOrdersAsync(Dictionary<int, int> slideOrders)
        {
            foreach (var kvp in slideOrders)
            {
                var slide = await _context.CarouselSlides.FindAsync(kvp.Key);
                if (slide != null)
                {
                    slide.DisplayOrder = kvp.Value;
                    slide.UpdatedAt = DateTime.UtcNow;
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task ToggleActiveStatusAsync(int slideId)
        {
            var slide = await _context.CarouselSlides.FindAsync(slideId);
            if (slide != null)
            {
                slide.IsActive = !slide.IsActive;
                slide.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
