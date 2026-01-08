using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface ICouponRepository : IRepository<Coupon>
    {
        Task<Coupon?> GetByCodeAsync(string code);
        Task<Coupon?> GetActiveByCodeAsync(string code);
        Task<IEnumerable<Coupon>> GetActiveCouponsAsync();
        Task<bool> ValidateCouponAsync(string code, decimal orderAmount, string? userId = null);
        Task<decimal> CalculateDiscountAsync(Coupon coupon, decimal orderAmount);
        Task IncrementUsageAsync(int couponId);
        Task<int> GetUserUsageCountAsync(int couponId, string userId);
        Task<IEnumerable<Coupon>> GetAllWithRelationsAsync();
        Task<Coupon?> GetByIdWithRelationsAsync(int id);
    }
}
