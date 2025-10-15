using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IColorRepository : IRepository<Color>
    {
        Task<IEnumerable<Color>> GetActiveColorsAsync();
        Task<Color?> GetColorByNameAsync(string name);
    }
}
