using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetActiveProductsAsync();
        Task<IEnumerable<Product>> GetProductsWithImagesAsync();
        Task<IEnumerable<Product>> GetProductsWithVariantsAsync();
        Task<Product?> GetProductWithDetailsAsync(int id);
        Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm);
        Task<Product?> GetProductBySlugAsync(string slug, string cultureCode);
    }
}
