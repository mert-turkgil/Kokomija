using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class CarouselSlideTranslationRepository : Repository<CarouselSlideTranslation>, ICarouselSlideTranslationRepository
    {
        private new readonly ApplicationDbContext _context;

        public CarouselSlideTranslationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CarouselSlideTranslation>> GetBySlideIdAsync(int slideId)
        {
            return await _context.CarouselSlideTranslations
                .Where(t => t.CarouselSlideId == slideId)
                .OrderBy(t => t.CultureCode)
                .ToListAsync();
        }

        public async Task<CarouselSlideTranslation?> GetBySlideIdAndCultureAsync(int slideId, string cultureCode)
        {
            return await _context.CarouselSlideTranslations
                .FirstOrDefaultAsync(t => t.CarouselSlideId == slideId && t.CultureCode == cultureCode);
        }

        public async Task<List<CarouselSlideTranslation>> GetByCultureCodeAsync(string cultureCode)
        {
            return await _context.CarouselSlideTranslations
                .Where(t => t.CultureCode == cultureCode)
                .Include(t => t.CarouselSlide)
                .OrderBy(t => t.CarouselSlide.DisplayOrder)
                .ToListAsync();
        }

        public async Task DeleteBySlideIdAsync(int slideId)
        {
            var translations = await _context.CarouselSlideTranslations
                .Where(t => t.CarouselSlideId == slideId)
                .ToListAsync();
            
            _context.CarouselSlideTranslations.RemoveRange(translations);
            await _context.SaveChangesAsync();
        }
    }
}
