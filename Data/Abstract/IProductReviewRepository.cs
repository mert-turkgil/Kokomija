using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IProductReviewRepository : IRepository<ProductReview>
    {
        Task<IEnumerable<ProductReview>> GetProductReviewsAsync(int productId, bool includeHidden = false);
        Task<decimal> GetAverageRatingAsync(int productId);
        Task<int> GetReviewCountAsync(int productId);
        Task<bool> HasUserPurchasedProductAsync(string userId, int productId);
        Task<bool> HasUserPurchasedProductGroupAsync(string userId, int productGroupId);
        Task<ProductReview?> GetUserReviewForProductAsync(string userId, int productId);
        Task<ProductReview?> GetUserReviewForProductGroupAsync(string userId, int productGroupId);
    }
}
