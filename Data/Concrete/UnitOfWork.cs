using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Kokomija.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private IDbContextTransaction? _transaction;
        private readonly Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _repositories = new Dictionary<Type, object>();
            
            // Initialize specific repositories
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
            Colors = new ColorRepository(_context);
            Sizes = new SizeRepository(_context);
            ProductVariants = new ProductVariantRepository(_context);
            Orders = new OrderRepository(_context);
            Users = new UserRepository(_context, _userManager);
            Coupons = new CouponRepository(_context);
            
            // Initialize admin and system repositories
            SiteSettings = new Repository<SiteSetting>(_context);
            AdminCommissions = new Repository<AdminCommission>(_context);
            SiteClosures = new Repository<SiteClosure>(_context);
            EmailCommands = new Repository<EmailCommand>(_context);
            AdminEarnings = new Repository<AdminEarnings>(_context);
            
            // Initialize carousel repository
            CarouselSlides = new CarouselSlideRepository(_context);
            CarouselSlideTranslations = new CarouselSlideTranslationRepository(_context);
            
            // Initialize wishlist repository
            Wishlists = new WishlistRepository(_context);
            
            // Initialize cart repository
            Carts = new CartRepository(_context);
            
            // Initialize blog repositories
            Blogs = new BlogRepository(_context);
            BlogCategories = new BlogCategoryRepository(_context);
            
            // Initialize product review repository
            ProductReviews = new ProductReviewRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IColorRepository Colors { get; private set; }
        public ISizeRepository Sizes { get; private set; }
        public IProductVariantRepository ProductVariants { get; private set; }
        public IOrderRepository Orders { get; private set; }
        public IUserRepository Users { get; private set; }
        public ICouponRepository Coupons { get; private set; }
        public IRepository<SiteSetting> SiteSettings { get; private set; }
        public IRepository<AdminCommission> AdminCommissions { get; private set; }
        public IRepository<SiteClosure> SiteClosures { get; private set; }
        public IRepository<EmailCommand> EmailCommands { get; private set; }
        public IRepository<AdminEarnings> AdminEarnings { get; private set; }
        public ICarouselSlideRepository CarouselSlides { get; private set; }
        public ICarouselSlideTranslationRepository CarouselSlideTranslations { get; private set; }
        public IWishlistRepository Wishlists { get; private set; }
        public ICartRepository Carts { get; private set; }
        public IBlogRepository Blogs { get; private set; }
        public IBlogCategoryRepository BlogCategories { get; private set; }
        public IProductReviewRepository ProductReviews { get; private set; }

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (_repositories.ContainsKey(type))
            {
                return (IRepository<T>)_repositories[type];
            }

            var repositoryInstance = new Repository<T>(_context);
            _repositories.Add(type, repositoryInstance);

            return repositoryInstance;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
