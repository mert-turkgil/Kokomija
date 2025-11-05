using Kokomija.Entity;

namespace Kokomija.Data.Abstract;

public interface IWishlistRepository : IRepository<Wishlist>
{
    Task<Wishlist?> GetByUserAndProductAsync(string userId, int productId);
    Task<IEnumerable<Wishlist>> GetByUserIdAsync(string userId);
    Task<int> GetWishlistCountAsync(string userId);
    Task<bool> ExistsAsync(string userId, int productId);
}
