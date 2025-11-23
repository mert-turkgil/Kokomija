using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetTopLevelCategoriesAsync();
        Task<IEnumerable<Category>> GetCategoriesWithSubCategoriesAsync();
        Task<IEnumerable<Category>> GetNavbarCategoriesAsync();
        Task<Category?> GetCategoryBySlugAsync(string slug);
        Task<IEnumerable<Category>> GetSubCategoriesAsync(int parentId);
        Task<Category?> GetByIdWithTranslationsAsync(int id);
        Task<IEnumerable<Category>> GetAllWithTranslationsAsync();
        Task<Category?> GetCategoryBySlugAndCultureAsync(string slug, string cultureCode);
    }
}
