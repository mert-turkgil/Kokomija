using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface ICarouselSlideTranslationRepository : IRepository<CarouselSlideTranslation>
    {
        Task<List<CarouselSlideTranslation>> GetBySlideIdAsync(int slideId);
        Task<CarouselSlideTranslation?> GetBySlideIdAndCultureAsync(int slideId, string cultureCode);
        Task<List<CarouselSlideTranslation>> GetByCultureCodeAsync(string cultureCode);
        Task DeleteBySlideIdAsync(int slideId);
    }
}
