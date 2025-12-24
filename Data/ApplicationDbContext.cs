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
        public DbSet<BlogTranslation> BlogTranslations { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<AdminCommission> AdminCommissions { get; set; }
        public DbSet<SiteClosure> SiteClosures { get; set; }
        public DbSet<EmailCommand> EmailCommands { get; set; }
        public DbSet<AdminEarnings> AdminEarnings { get; set; }
        public DbSet<CarouselSlide> CarouselSlides { get; set; }
        public DbSet<CarouselSlideTranslation> CarouselSlideTranslations { get; set; }
        public DbSet<CategoryTranslation> CategoryTranslations { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistNotification> WishlistNotifications { get; set; }
        public DbSet<NewsletterSubscription> NewsletterSubscriptions { get; set; }
        public DbSet<ProductPriceHistory> ProductPriceHistories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<ProductTranslation> ProductTranslations { get; set; }

        // Order Management
        public DbSet<ReturnRequest> ReturnRequests { get; set; }
        public DbSet<ReturnRequestImage> ReturnRequestImages { get; set; }
        public DbSet<ReturnStatusHistory> ReturnStatusHistories { get; set; }
        public DbSet<ShippingProvider> ShippingProviders { get; set; }
        public DbSet<ShippingRate> ShippingRates { get; set; }
        public DbSet<OrderShipment> OrderShipments { get; set; }
        public DbSet<ShipmentTrackingEvent> ShipmentTrackingEvents { get; set; }
        public DbSet<TaxRate> TaxRates { get; set; }
        public DbSet<CommissionSettings> CommissionSettings { get; set; }
        public DbSet<DeveloperEarnings> DeveloperEarnings { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        public DbSet<SiteBlockLog> SiteBlockLogs { get; set; }
        public DbSet<DeveloperCommissionRequest> DeveloperCommissionRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply all configurations from separate files
            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductGroupConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryTranslationConfiguration());
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
            modelBuilder.ApplyConfiguration(new BlogTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            modelBuilder.ApplyConfiguration(new AdminCommissionConfiguration());
            modelBuilder.ApplyConfiguration(new SiteClosureConfiguration());
            modelBuilder.ApplyConfiguration(new EmailCommandConfiguration());
            modelBuilder.ApplyConfiguration(new AdminEarningsConfiguration());
            modelBuilder.ApplyConfiguration(new CarouselSlideConfiguration());
            modelBuilder.ApplyConfiguration(new CarouselSlideTranslationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductReviewConfiguration());
            modelBuilder.ApplyConfiguration(new NewsletterSubscriptionConfiguration());
            modelBuilder.ApplyConfiguration(new WishlistNotificationConfiguration());
            modelBuilder.ApplyConfiguration(new ProductPriceHistoryConfiguration());

            // Order Management Configurations
            modelBuilder.ApplyConfiguration(new ReturnRequestConfiguration());
            modelBuilder.ApplyConfiguration(new ShippingProviderConfiguration());
            modelBuilder.ApplyConfiguration(new ShippingRateConfiguration());
            modelBuilder.ApplyConfiguration(new OrderShipmentConfiguration());
            modelBuilder.ApplyConfiguration(new TaxRateConfiguration());
            modelBuilder.ApplyConfiguration(new CommissionSettingsConfiguration());
            modelBuilder.ApplyConfiguration(new DeveloperEarningsConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTransactionConfiguration());
            modelBuilder.ApplyConfiguration(new SiteBlockLogConfiguration());

            // Seed initial data (only runs on InitialCreate migration)
            modelBuilder.SeedSizes();
            modelBuilder.SeedColors();
            modelBuilder.SeedCategories();
            modelBuilder.SeedLanguages();
            modelBuilder.SeedBlogCategories();
            modelBuilder.SeedBlogs(); 
            modelBuilder.SeedBlogTranslations(); 
            modelBuilder.SeedAdminSettings();
            
            // Order Management seed data
            modelBuilder.SeedShippingProviders();
            modelBuilder.SeedShippingRates();
            modelBuilder.SeedTaxRates();
            
            // Coupons and Products seeding
            modelBuilder.SeedCoupons();
            modelBuilder.SeedProductGroups(); // Seed product groups before products
            modelBuilder.SeedProducts();
            modelBuilder.SeedProductImages();
            modelBuilder.SeedProductVariants();
            
            modelBuilder.SeedCarouselSlides();
            modelBuilder.SeedCarouselSlideTranslations();
        }
    }
}
