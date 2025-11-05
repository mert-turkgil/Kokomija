using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class ProductVariantRepository : Repository<ProductVariant>, IProductVariantRepository
    {
        public ProductVariantRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductVariant>> GetVariantsByProductIdAsync(int productId)
        {
            return await _dbSet
                .Where(v => v.ProductId == productId && v.IsActive)
                .Include(v => v.Size)
                .Include(v => v.Color)
                .Include(v => v.Product)
                .OrderBy(v => v.Size!.DisplayOrder)
                .ThenBy(v => v.Color!.DisplayOrder)
                .ToListAsync();
        }

        public async Task<ProductVariant?> GetVariantBySkuAsync(string sku)
        {
            return await _dbSet
                .Include(v => v.Product)
                .Include(v => v.Size)
                .Include(v => v.Color)
                .FirstOrDefaultAsync(v => v.SKU == sku && v.IsActive);
        }

        public async Task<ProductVariant?> GetVariantAsync(int productId, int? sizeId, int? colorId)
        {
            return await _dbSet
                .Include(v => v.Product)
                .Include(v => v.Size)
                .Include(v => v.Color)
                .FirstOrDefaultAsync(v => 
                    v.ProductId == productId && 
                    v.SizeId == sizeId && 
                    v.ColorId == colorId && 
                    v.IsActive);
        }

        public async Task<IEnumerable<ProductVariant>> GetActiveVariantsAsync()
        {
            return await _dbSet
                .Where(v => v.IsActive)
                .Include(v => v.Product)
                .Include(v => v.Size)
                .Include(v => v.Color)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProductVariant>> GetVariantsWithStockAsync(int productId)
        {
            return await _dbSet
                .Where(v => v.ProductId == productId && v.IsActive && v.StockQuantity > 0)
                .Include(v => v.Size)
                .Include(v => v.Color)
                .OrderBy(v => v.Size!.DisplayOrder)
                .ThenBy(v => v.Color!.DisplayOrder)
                .ToListAsync();
        }
    }
}
