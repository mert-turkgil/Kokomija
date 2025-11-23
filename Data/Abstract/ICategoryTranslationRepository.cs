using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface ICategoryTranslationRepository : IRepository<CategoryTranslation>
    {
        Task<IEnumerable<CategoryTranslation>> GetByCategoryIdAsync(int categoryId);
        Task<CategoryTranslation?> GetByCategoryIdAndCultureAsync(int categoryId, string cultureCode);
        Task DeleteByCategoryIdAsync(int categoryId);
    }
}
