using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            return await _dbSet
                .Where(p => p.CategoryId == categoryId && p.IsActive)
                .Include(p => p.Category)
                .Include(p => p.Images)
                .OrderBy(p => p.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetActiveProductsAsync()
        {
            return await _dbSet
                .Where(p => p.IsActive)
                .Include(p => p.Category)
                .Include(p => p.Images.Where(i => i.IsPrimary))
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithImagesAsync()
        {
            return await _dbSet
                .Include(p => p.Images.OrderBy(i => i.DisplayOrder))
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsWithVariantsAsync()
        {
            return await _dbSet
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Size)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .Include(p => p.Category)
                .Where(p => p.IsActive)
                .ToListAsync();
        }

        public async Task<Product?> GetProductWithDetailsAsync(int id)
        {
            return await _dbSet
                .Include(p => p.Category)
                .Include(p => p.Images.OrderBy(i => i.DisplayOrder))
                    .ThenInclude(i => i.Color)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Size)
                .Include(p => p.Variants)
                    .ThenInclude(v => v.Color)
                .Include(p => p.AvailableColors)
                    .ThenInclude(pc => pc.Color)
                .Include(p => p.AvailableSizes)
                    .ThenInclude(ps => ps.Size)
                .Include(p => p.Reviews.Where(r => r.IsVisible).OrderByDescending(r => r.CreatedAt))
                    .ThenInclude(r => r.User)
                .Include(p => p.Reviews.Where(r => r.IsVisible).OrderByDescending(r => r.CreatedAt))
                    .ThenInclude(r => r.AdminUser)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm)
        {
            var lowerSearchTerm = searchTerm.ToLower();
            
            return await _dbSet
                .Where(p => p.IsActive && 
                    (p.Name.ToLower().Contains(lowerSearchTerm) || 
                     p.Description.ToLower().Contains(lowerSearchTerm)))
                .Include(p => p.Category)
                .Include(p => p.Images.Where(i => i.IsPrimary))
                .OrderBy(p => p.Name)
                .ToListAsync();
        }
    }
}
