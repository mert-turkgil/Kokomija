using Kokomija.Entity;

namespace Kokomija.Data.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        IColorRepository Colors { get; }
        ISizeRepository Sizes { get; }
        IProductVariantRepository ProductVariants { get; }
        IOrderRepository Orders { get; }
        IUserRepository Users { get; }
        ICouponRepository Coupons { get; }
        IRepository<SiteSetting> SiteSettings { get; }
        IRepository<AdminCommission> AdminCommissions { get; }
        IRepository<SiteClosure> SiteClosures { get; }
        IRepository<EmailCommand> EmailCommands { get; }
        IRepository<AdminEarnings> AdminEarnings { get; }
        ICarouselSlideRepository CarouselSlides { get; }
        IWishlistRepository Wishlists { get; }
        ICartRepository Carts { get; }
        IRepository<T> Repository<T>() where T : class;
        
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
