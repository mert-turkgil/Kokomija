using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete;

public class WishlistRepository : Repository<Wishlist>, IWishlistRepository
{
    public WishlistRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Wishlist?> GetByUserAndProductAsync(string userId, int productId)
    {
        return await _context.Wishlists
            .FirstOrDefaultAsync(w => w.UserId == userId && w.ProductId == productId);
    }

    public async Task<IEnumerable<Wishlist>> GetByUserIdAsync(string userId)
    {
        return await _context.Wishlists
            .Include(w => w.Product)
                .ThenInclude(p => p.Images)
            .Include(w => w.Product)
                .ThenInclude(p => p.Variants)
            .Where(w => w.UserId == userId)
            .OrderByDescending(w => w.AddedAt)
            .ToListAsync();
    }

    public async Task<int> GetWishlistCountAsync(string userId)
    {
        return await _context.Wishlists
            .CountAsync(w => w.UserId == userId);
    }

    public async Task<bool> ExistsAsync(string userId, int productId)
    {
        return await _context.Wishlists
            .AnyAsync(w => w.UserId == userId && w.ProductId == productId);
    }
}
