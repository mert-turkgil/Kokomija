using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class CategoryTranslationRepository : Repository<CategoryTranslation>, ICategoryTranslationRepository
    {
        public CategoryTranslationRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CategoryTranslation>> GetByCategoryIdAsync(int categoryId)
        {
            return await _dbSet
                .Where(ct => ct.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<CategoryTranslation?> GetByCategoryIdAndCultureAsync(int categoryId, string cultureCode)
        {
            return await _dbSet
                .FirstOrDefaultAsync(ct => ct.CategoryId == categoryId && ct.CultureCode == cultureCode);
        }

        public async Task DeleteByCategoryIdAsync(int categoryId)
        {
            var translations = await _dbSet
                .Where(ct => ct.CategoryId == categoryId)
                .ToListAsync();

            _dbSet.RemoveRange(translations);
        }
    }
}
