using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IProductVariantRepository : IRepository<ProductVariant>
    {
        Task<IEnumerable<ProductVariant>> GetVariantsByProductIdAsync(int productId);
        Task<ProductVariant?> GetVariantBySkuAsync(string sku);
        Task<ProductVariant?> GetVariantAsync(int productId, int? sizeId, int? colorId);
        Task<IEnumerable<ProductVariant>> GetActiveVariantsAsync();
        Task<IEnumerable<ProductVariant>> GetVariantsWithStockAsync(int productId);
    }
}
