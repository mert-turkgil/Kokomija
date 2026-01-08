using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data.Concrete
{
    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        public CouponRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Coupon?> GetByCodeAsync(string code)
        {
            return await _dbSet
                .FirstOrDefaultAsync(c => c.Code.ToLower() == code.ToLower());
        }

        public async Task<Coupon?> GetActiveByCodeAsync(string code)
        {
            var now = DateTime.UtcNow;
            
            return await _dbSet
                .Where(c => c.Code.ToLower() == code.ToLower() 
                    && c.IsActive
                    && (c.ValidFrom == null || c.ValidFrom <= now)
                    && (c.ValidUntil == null || c.ValidUntil >= now)
                    && (c.UsageLimit == null || c.UsageCount < c.UsageLimit))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Coupon>> GetActiveCouponsAsync()
        {
            var now = DateTime.UtcNow;
            
            return await _dbSet
                .Where(c => c.IsActive
                    && (c.ValidFrom == null || c.ValidFrom <= now)
                    && (c.ValidUntil == null || c.ValidUntil >= now)
                    && (c.UsageLimit == null || c.UsageCount < c.UsageLimit))
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> ValidateCouponAsync(string code, decimal orderAmount, string? userId = null)
        {
            var coupon = await GetActiveByCodeAsync(code);
            
            if (coupon == null)
                return false;

            // Check minimum order amount
            if (coupon.MinimumOrderAmount.HasValue && orderAmount < coupon.MinimumOrderAmount.Value)
                return false;

            // Check per-user usage limit
            if (!string.IsNullOrEmpty(userId) && coupon.UsageLimitPerUser.HasValue)
            {
                var userUsageCount = await GetUserUsageCountAsync(coupon.Id, userId);
                if (userUsageCount >= coupon.UsageLimitPerUser.Value)
                    return false;
            }

            return true;
        }

        public Task<decimal> CalculateDiscountAsync(Coupon coupon, decimal orderAmount)
        {
            decimal discount = 0;

            if (coupon.DiscountType == "percentage")
            {
                discount = orderAmount * (coupon.DiscountValue / 100);
            }
            else if (coupon.DiscountType == "fixed_amount")
            {
                discount = coupon.DiscountValue;
            }

            // Apply maximum discount limit if set
            if (coupon.MaximumDiscountAmount.HasValue && discount > coupon.MaximumDiscountAmount.Value)
            {
                discount = coupon.MaximumDiscountAmount.Value;
            }

            // Ensure discount doesn't exceed order amount
            if (discount > orderAmount)
            {
                discount = orderAmount;
            }

            return Task.FromResult(discount);
        }

        public async Task IncrementUsageAsync(int couponId)
        {
            var coupon = await _dbSet.FindAsync(couponId);
            if (coupon != null)
            {
                coupon.UsageCount++;
                coupon.UpdatedAt = DateTime.UtcNow;
                _dbSet.Update(coupon);
            }
        }

        public async Task<int> GetUserUsageCountAsync(int couponId, string userId)
        {
            return await _context.Set<CouponUsage>()
                .Where(cu => cu.CouponId == couponId && cu.UserId == userId)
                .CountAsync();
        }

        public async Task<IEnumerable<Coupon>> GetAllWithRelationsAsync()
        {
            return await _dbSet
                .Include(c => c.Category)
                .Include(c => c.Product)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<Coupon?> GetByIdWithRelationsAsync(int id)
        {
            return await _dbSet
                .Include(c => c.Category)
                .Include(c => c.Product)
                .Include(c => c.User)
                .Include(c => c.CouponUsages)
                    .ThenInclude(u => u.User)
                .Include(c => c.CouponUsages)
                    .ThenInclude(u => u.Order)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
