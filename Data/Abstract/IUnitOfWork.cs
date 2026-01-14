using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ICategoryTranslationRepository CategoryTranslations { get; }
        IColorRepository Colors { get; }
        ISizeRepository Sizes { get; }
        IProductVariantRepository ProductVariants { get; }
        IOrderRepository Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IUserRepository Users { get; }
        ICouponRepository Coupons { get; }
        IRepository<SiteSetting> SiteSettings { get; }
        IRepository<AdminCommission> AdminCommissions { get; }
        IRepository<SiteClosure> SiteClosures { get; }
        IRepository<EmailCommand> EmailCommands { get; }
        IRepository<AdminEarnings> AdminEarnings { get; }
        IRepository<DeveloperEarnings> DeveloperEarnings { get; }
        IRepository<CommissionSettings> CommissionSettings { get; }
        IRepository<ReturnRequest> ReturnRequests { get; }
        ICarouselSlideRepository CarouselSlides { get; }
        ICarouselSlideTranslationRepository CarouselSlideTranslations { get; }
        IWishlistRepository Wishlists { get; }
        ICartRepository Carts { get; }
        IBlogRepository Blogs { get; }
        IBlogCategoryRepository BlogCategories { get; }
        IProductReviewRepository ProductReviews { get; }
        IRepository<T> Repository<T>() where T : class;
        
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
