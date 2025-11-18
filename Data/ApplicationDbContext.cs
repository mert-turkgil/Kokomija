using Kokomija.Data.Configurations;
using Kokomija.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Suppress pending model changes warning during migration
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<CouponUsage> CouponUsages { get; set; }
        public DbSet<SupportedLanguage> SupportedLanguages { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<AdminCommission> AdminCommissions { get; set; }
        public DbSet<SiteClosure> SiteClosures { get; set; }
        public DbSet<EmailCommand> EmailCommands { get; set; }
        public DbSet<AdminEarnings> AdminEarnings { get; set; }
        public DbSet<CarouselSlide> CarouselSlides { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistNotification> WishlistNotifications { get; set; }
        public DbSet<NewsletterSubscription> NewsletterSubscriptions { get; set; }
        public DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations from separate files
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductGroupConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ColorConfiguration());
            modelBuilder.ApplyConfiguration(new SizeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductVariantConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ProductColorConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new CouponConfiguration());
            modelBuilder.ApplyConfiguration(new CouponUsageConfiguration());
            modelBuilder.ApplyConfiguration(new SupportedLanguageConfiguration());
            modelBuilder.ApplyConfiguration(new SiteSettingConfiguration());
            modelBuilder.ApplyConfiguration(new BlogConfiguration());
            modelBuilder.ApplyConfiguration(new BlogCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new AdminCommissionConfiguration());
            modelBuilder.ApplyConfiguration(new SiteClosureConfiguration());
            modelBuilder.ApplyConfiguration(new EmailCommandConfiguration());
            modelBuilder.ApplyConfiguration(new AdminEarningsConfiguration());
            modelBuilder.ApplyConfiguration(new CarouselSlideConfiguration());
            modelBuilder.ApplyConfiguration(new ProductReviewConfiguration());
            modelBuilder.ApplyConfiguration(new NewsletterSubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new WishlistNotificationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPriceHistoryConfiguration());

            // Seed initial data
            modelBuilder.SeedSizes();
            modelBuilder.SeedColors();
            modelBuilder.SeedCategories();
            modelBuilder.SeedLanguages();
            modelBuilder.SeedBlogCategories();
            // Note: Blog seeding requires user accounts to be created first
            // modelBuilder.SeedBlogs(); // Uncomment after running IdentitySeeder
            modelBuilder.SeedAdminSettings();
            modelBuilder.SeedCoupons();
            modelBuilder.SeedProductGroups(); // Seed product groups before products
            modelBuilder.SeedProducts();
            modelBuilder.SeedProductImages();
            modelBuilder.SeedProductVariants();
            modelBuilder.SeedCarouselSlides();
        }
    }
}
