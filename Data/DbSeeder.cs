using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data
{
    public static class DbSeeder
    {
        public static void SeedSizes(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Size>().HasData(
                new Size 
                { 
                    Id = 1, 
                    Name = "XS", 
                    DisplayName = "Extra Small", 
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Size 
                { 
                    Id = 2, 
                    Name = "S", 
                    DisplayName = "Small", 
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Size 
                { 
                    Id = 3, 
                    Name = "M", 
                    DisplayName = "Medium", 
                    DisplayOrder = 3,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Size 
                { 
                    Id = 4, 
                    Name = "L", 
                    DisplayName = "Large", 
                    DisplayOrder = 4,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Size 
                { 
                    Id = 5, 
                    Name = "XL", 
                    DisplayName = "Extra Large", 
                    DisplayOrder = 5,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Size 
                { 
                    Id = 6, 
                    Name = "XXL", 
                    DisplayName = "2X Large", 
                    DisplayOrder = 6,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedColors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Color>().HasData(
                new Color 
                { 
                    Id = 1, 
                    Name = "Black", 
                    HexCode = "#000000", 
                    DisplayName = "Black", 
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Color 
                { 
                    Id = 2, 
                    Name = "White", 
                    HexCode = "#FFFFFF", 
                    DisplayName = "White", 
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Color 
                { 
                    Id = 3, 
                    Name = "Red", 
                    HexCode = "#FF0000", 
                    DisplayName = "Red", 
                    DisplayOrder = 3,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Color 
                { 
                    Id = 4, 
                    Name = "Blue", 
                    HexCode = "#0000FF", 
                    DisplayName = "Blue", 
                    DisplayOrder = 4,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Color 
                { 
                    Id = 5, 
                    Name = "Green", 
                    HexCode = "#00FF00", 
                    DisplayName = "Green", 
                    DisplayOrder = 5,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Color 
                { 
                    Id = 6, 
                    Name = "Yellow", 
                    HexCode = "#FFFF00", 
                    DisplayName = "Yellow", 
                    DisplayOrder = 6,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Color 
                { 
                    Id = 7, 
                    Name = "Navy", 
                    HexCode = "#000080", 
                    DisplayName = "Navy Blue", 
                    DisplayOrder = 7,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Color 
                { 
                    Id = 8, 
                    Name = "Gray", 
                    HexCode = "#808080", 
                    DisplayName = "Gray", 
                    DisplayOrder = 8,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                // Top level categories
                new Category 
                { 
                    Id = 1, 
                    Name = "Woman", 
                    Slug = "woman", 
                    DisplayOrder = 1, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 2, 
                    Name = "Man", 
                    Slug = "man", 
                    DisplayOrder = 2, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Woman subcategories
                new Category 
                { 
                    Id = 3, 
                    Name = "T-Shirts", 
                    Slug = "woman-tshirts", 
                    ParentCategoryId = 1, 
                    DisplayOrder = 1, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 4, 
                    Name = "Pants", 
                    Slug = "woman-pants", 
                    ParentCategoryId = 1, 
                    DisplayOrder = 2, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 5, 
                    Name = "Dresses", 
                    Slug = "woman-dresses", 
                    ParentCategoryId = 1, 
                    DisplayOrder = 3, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Man subcategories
                new Category 
                { 
                    Id = 6, 
                    Name = "T-Shirts", 
                    Slug = "man-tshirts", 
                    ParentCategoryId = 2, 
                    DisplayOrder = 1, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 7, 
                    Name = "Pants", 
                    Slug = "man-pants", 
                    ParentCategoryId = 2, 
                    DisplayOrder = 2, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 8, 
                    Name = "Shirts", 
                    Slug = "man-shirts", 
                    ParentCategoryId = 2, 
                    DisplayOrder = 3, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedLanguages(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupportedLanguage>().HasData(
                new SupportedLanguage
                {
                    Id = 1,
                    CultureCode = "pl-PL",
                    DisplayName = "Polski",
                    NativeName = "Polski",
                    TwoLetterIsoCode = "pl",
                    FlagIcon = "🇵🇱",
                    IsEnabled = true,
                    IsDefault = true,
                    DisplayOrder = 1,
                    CreatedAt = DateTime.UtcNow
                },
                new SupportedLanguage
                {
                    Id = 2,
                    CultureCode = "en-US",
                    DisplayName = "English",
                    NativeName = "English",
                    TwoLetterIsoCode = "en",
                    FlagIcon = "🇺🇸",
                    IsEnabled = false, // Disabled by default, admin can enable
                    IsDefault = false,
                    DisplayOrder = 2,
                    CreatedAt = DateTime.UtcNow
                },
                new SupportedLanguage
                {
                    Id = 3,
                    CultureCode = "de-DE",
                    DisplayName = "Deutsch",
                    NativeName = "Deutsch",
                    TwoLetterIsoCode = "de",
                    FlagIcon = "🇩🇪",
                    IsEnabled = false, // Disabled by default
                    IsDefault = false,
                    DisplayOrder = 3,
                    CreatedAt = DateTime.UtcNow
                },
                new SupportedLanguage
                {
                    Id = 4,
                    CultureCode = "fr-FR",
                    DisplayName = "Français",
                    NativeName = "Français",
                    TwoLetterIsoCode = "fr",
                    FlagIcon = "🇫🇷",
                    IsEnabled = false, // Disabled by default
                    IsDefault = false,
                    DisplayOrder = 4,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedBlogCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogCategory>().HasData(
                new BlogCategory
                {
                    Id = 1,
                    Name = "Porady",
                    Slug = "porady",
                    Description = "Porady dotyczące zakupów i stylizacji",
                    DisplayOrder = 1,
                    IsActive = true,
                    Language = "pl",
                    MetaDescription = "Porady zakupowe i stylizacyjne dla klientów Kokomija",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new BlogCategory
                {
                    Id = 2,
                    Name = "Nowości",
                    Slug = "nowosci",
                    Description = "Najnowsze produkty i kolekcje",
                    DisplayOrder = 2,
                    IsActive = true,
                    Language = "pl",
                    MetaDescription = "Najnowsze produkty i kolekcje w Kokomija",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new BlogCategory
                {
                    Id = 3,
                    Name = "Trendy",
                    Slug = "trendy",
                    Description = "Najnowsze trendy w modzie",
                    DisplayOrder = 3,
                    IsActive = true,
                    Language = "pl",
                    MetaDescription = "Najnowsze trendy w modzie i stylizacji",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new BlogCategory
                {
                    Id = 4,
                    Name = "Inspiracje",
                    Slug = "inspiracje",
                    Description = "Inspiracje stylizacyjne i lookbooki",
                    DisplayOrder = 4,
                    IsActive = true,
                    Language = "pl",
                    MetaDescription = "Inspiracje stylizacyjne i lookbooki od Kokomija",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new BlogCategory
                {
                    Id = 5,
                    Name = "O marce",
                    Slug = "o-marce",
                    Description = "Informacje o marce Kokomija",
                    DisplayOrder = 5,
                    IsActive = true,
                    Language = "pl",
                    MetaDescription = "Informacje o marce Kokomija i naszej misji",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedAdminSettings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SiteSetting>().HasData(
                new SiteSetting
                {
                    Id = 1,
                    Key = "SuperAdminEmail",
                    Value = "admin@kokomija.com", // CHANGE THIS TO YOUR EMAIL!
                    Description = "Super admin email for site control and emergency commands",
                    Category = "Security",
                    DataType = "string",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 2,
                    Key = "PlatformCommissionRate",
                    Value = "0.01", // 1%
                    Description = "Platform commission rate per product sale (decimal, e.g., 0.01 = 1%)",
                    Category = "Commission",
                    DataType = "decimal",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 3,
                    Key = "StripeProcessingFeeRate",
                    Value = "0.014", // 1.4% for Poland
                    Description = "Stripe processing fee rate (decimal, e.g., 0.014 = 1.4%)",
                    Category = "Commission",
                    DataType = "decimal",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 4,
                    Key = "StripeFixedFee",
                    Value = "1.00", // 1 PLN for Poland
                    Description = "Stripe fixed fee per transaction in PLN",
                    Category = "Commission",
                    DataType = "decimal",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 5,
                    Key = "SiteClosureEnabled",
                    Value = "false",
                    Description = "Is site currently closed for maintenance",
                    Category = "Maintenance",
                    DataType = "boolean",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 6,
                    Key = "SiteClosureMessage",
                    Value = "Przepraszamy, serwis jest tymczasowo niedostępny z powodu konserwacji.",
                    Description = "Message displayed when site is closed",
                    Category = "Maintenance",
                    DataType = "string",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 7,
                    Key = "AutoReopenAfterDays",
                    Value = "30",
                    Description = "Automatically reopen site after X days of closure",
                    Category = "Maintenance",
                    DataType = "integer",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 8,
                    Key = "DailyConfirmationEmailEnabled",
                    Value = "true",
                    Description = "Send daily confirmation emails during site closure",
                    Category = "Maintenance",
                    DataType = "boolean",
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
