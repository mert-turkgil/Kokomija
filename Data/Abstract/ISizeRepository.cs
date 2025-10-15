using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface ISizeRepository : IRepository<Size>
    {
        Task<IEnumerable<Size>> GetActiveSizesAsync();
        Task<Size?> GetSizeByNameAsync(string name);
    }
}
