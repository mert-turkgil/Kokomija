using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class ProductReviewRepository : Repository<ProductReview>, IProductReviewRepository
    {
        public ProductReviewRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int productId, bool includeHidden = false)
        {
            var query = _context.ProductReviews
                .Include(r => r.User)
                .Include(r => r.AdminUser)
                .Where(r => r.ProductId == productId);

            if (!includeHidden)
            {
                query = query.Where(r => r.IsVisible);
            }

            return await query
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();
        }

        public async Task<decimal> GetAverageRatingAsync(int productId)
        {
            var reviews = await _context.ProductReviews
                .Where(r => r.ProductId == productId && r.IsVisible)
                .ToListAsync();

            return reviews.Any() ? reviews.Average(r => r.Rating) : 0;
        }

        public async Task<int> GetReviewCountAsync(int productId)
        {
            return await _context.ProductReviews
                .Where(r => r.ProductId == productId && r.IsVisible)
                .CountAsync();
        }

        public async Task<bool> HasUserPurchasedProductAsync(string userId, int productId)
        {
            return await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.ProductVariant)
                .AnyAsync(oi => 
                    oi.Order.UserId == userId && 
                    oi.ProductVariant.ProductId == productId &&
                    oi.Order.OrderStatus == "completed");
        }

        public async Task<ProductReview?> GetUserReviewForProductAsync(string userId, int productId)
        {
            return await _context.ProductReviews
                .Include(r => r.User)
                .Include(r => r.AdminUser)
                .FirstOrDefaultAsync(r => r.UserId == userId && r.ProductId == productId);
        }
    }
}
