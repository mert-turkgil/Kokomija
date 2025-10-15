using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IProductVariantRepository : IRepository<ProductVariant>
    {
        Task<IEnumerable<ProductVariant>> GetVariantsByProductIdAsync(int productId);
        Task<ProductVariant?> GetVariantBySkuAsync(string sku);
        Task<IEnumerable<ProductVariant>> GetActiveVariantsAsync();
        Task<IEnumerable<ProductVariant>> GetVariantsWithStockAsync(int productId);
    }
}
