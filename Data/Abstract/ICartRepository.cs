using Kokomija.Entity;

namespace Kokomija.Data.Abstract;

public interface ICartRepository : IRepository<Cart>
{
    Task<IEnumerable<Cart>> GetByUserIdAsync(string userId);
    Task<Cart?> GetCartItemAsync(string userId, int productId, int? colorId, int? sizeId);
    Task<int> GetCartCountAsync(string userId);
    Task ClearCartAsync(string userId);
}
