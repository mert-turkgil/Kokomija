using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete;

public class CartRepository : Repository<Cart>, ICartRepository
{
    public CartRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Cart>> GetByUserIdAsync(string userId)
    {
        return await _context.Carts
            .Where(c => c.UserId == userId)
            .Include(c => c.Product)
                .ThenInclude(p => p.Images)
            .Include(c => c.Color)
            .Include(c => c.Size)
            .OrderByDescending(c => c.AddedAt)
            .ToListAsync();
    }

    public async Task<Cart?> GetCartItemAsync(string userId, int productId, int? colorId, int? sizeId)
    {
        return await _context.Carts
            .FirstOrDefaultAsync(c => 
                c.UserId == userId && 
                c.ProductId == productId && 
                c.ColorId == colorId && 
                c.SizeId == sizeId);
    }

    public async Task<int> GetCartCountAsync(string userId)
    {
        return await _context.Carts
            .Where(c => c.UserId == userId)
            .SumAsync(c => c.Quantity);
    }

    public async Task<int> GetCartItemCountAsync(string userId)
    {
        return await _context.Carts
            .Where(c => c.UserId == userId)
            .SumAsync(c => c.Quantity);
    }

    public async Task ClearCartAsync(string userId)
    {
        var cartItems = await _context.Carts
            .Where(c => c.UserId == userId)
            .ToListAsync();
        
        _context.Carts.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
    }
}
