using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Category>> GetTopLevelCategoriesAsync()
        {
            return await _dbSet
                .Where(c => c.ParentCategoryId == null && c.IsActive)
                .Include(c => c.Translations)
                .Include(c => c.SubCategories.Where(sc => sc.IsActive))
                .OrderBy(c => c.DisplayOrder)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetCategoriesWithSubCategoriesAsync()
        {
            return await _dbSet
                .Where(c => c.ParentCategoryId == null && c.IsActive)
                .Include(c => c.Translations)
                .Include(c => c.SubCategories.Where(sc => sc.IsActive))
                    .ThenInclude(sc => sc.Translations)
                .OrderBy(c => c.DisplayOrder)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetNavbarCategoriesAsync()
        {
            return await _dbSet
                .Where(c => c.ParentCategoryId == null && c.ShowInNavbar && c.IsActive)
                .Include(c => c.Translations)
                .Include(c => c.SubCategories.Where(sc => sc.ShowInNavbar && sc.IsActive).OrderBy(sc => sc.DisplayOrder))
                    .ThenInclude(sc => sc.Translations)
                .OrderBy(c => c.DisplayOrder)
                .Take(2) // Only take the first 2 categories for navbar
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryBySlugAsync(string slug)
        {
            return await _dbSet
                .Include(c => c.Translations)
                .Include(c => c.SubCategories.Where(sc => sc.IsActive))
                    .ThenInclude(sc => sc.Translations)
                .Include(c => c.ParentCategory!)
                    .ThenInclude(pc => pc.Translations)
                .Include(c => c.Products.Where(p => p.IsActive))
                .FirstOrDefaultAsync(c => c.Slug == slug && c.IsActive);
        }

        public async Task<IEnumerable<Category>> GetSubCategoriesAsync(int parentId)
        {
            return await _dbSet
                .Where(c => c.ParentCategoryId == parentId && c.IsActive)
                .Include(c => c.Translations)
                .OrderBy(c => c.DisplayOrder)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdWithTranslationsAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Translations)
                .Include(c => c.SubCategories)
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAllWithTranslationsAsync()
        {
            return await _dbSet
                .Include(c => c.Translations)
                .Include(c => c.ParentCategory)
                .Include(c => c.SubCategories)
                .OrderBy(c => c.DisplayOrder)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryBySlugAndCultureAsync(string slug, string cultureCode)
        {
            return await _dbSet
                .Include(c => c.Translations)
                .Include(c => c.SubCategories.Where(sc => sc.IsActive))
                    .ThenInclude(sc => sc.Translations)
                .Include(c => c.Products.Where(p => p.IsActive))
                .Where(c => c.IsActive)
                .Where(c => c.Translations.Any(t => t.Slug == slug && t.CultureCode == cultureCode) || c.Slug == slug)
                .FirstOrDefaultAsync();
        }
    }
}
