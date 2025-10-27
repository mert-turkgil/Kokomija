using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IBlogCategoryRepository : IRepository<BlogCategory>
    {
        Task<BlogCategory?> GetBySlugAsync(string slug);
        Task<IEnumerable<BlogCategory>> GetActiveCategoriesAsync();
        Task<Dictionary<int, int>> GetCategoryPostCountsAsync();
    }
}
