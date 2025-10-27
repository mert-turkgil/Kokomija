using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class BlogCategoryRepository : Repository<BlogCategory>, IBlogCategoryRepository
    {
        private new readonly ApplicationDbContext _context;

        public BlogCategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BlogCategory?> GetBySlugAsync(string slug)
        {
            return await _context.BlogCategories
                .FirstOrDefaultAsync(c => c.Slug == slug && c.IsActive);
        }

        public async Task<IEnumerable<BlogCategory>> GetActiveCategoriesAsync()
        {
            return await _context.BlogCategories
                .Where(c => c.IsActive)
                .OrderBy(c => c.DisplayOrder)
                .ThenBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Dictionary<int, int>> GetCategoryPostCountsAsync()
        {
            return await _context.Blogs
                .Where(b => b.IsPublished && !b.IsDeleted)
                .GroupBy(b => b.CategoryId)
                .Select(g => new { CategoryId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.CategoryId, x => x.Count);
        }
    }
}
