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

        public static void SeedPackQuantities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PackQuantity>().HasData(
                new PackQuantity 
                { 
                    Id = 1, 
                    Quantity = 1, 
                    Name = "Single", 
                    NameKey = "PackQuantity_Single",
                    DisplayOrder = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new PackQuantity 
                { 
                    Id = 2, 
                    Quantity = 5, 
                    Name = "5-Pack", 
                    NameKey = "PackQuantity_5Pack",
                    DisplayOrder = 2,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new PackQuantity 
                { 
                    Id = 3, 
                    Quantity = 6, 
                    Name = "6-Pack", 
                    NameKey = "PackQuantity_6Pack",
                    DisplayOrder = 3,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new PackQuantity 
                { 
                    Id = 4, 
                    Quantity = 8, 
                    Name = "8-Pack", 
                    NameKey = "PackQuantity_8Pack",
                    DisplayOrder = 4,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new PackQuantity 
                { 
                    Id = 5, 
                    Quantity = 10, 
                    Name = "10-Pack", 
                    NameKey = "PackQuantity_10Pack",
                    DisplayOrder = 5,
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
                    Name = "Damskie", 
                    NameKey = "Category_Women",
                    Slug = "damskie", 
                    Description = "Odzież damska",
                    IconCssClass = "fas fa-female",
                    ImageUrl = "categories/women.jpg",
                    DisplayOrder = 1, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 2, 
                    Name = "Męskie", 
                    NameKey = "Category_Men",
                    Slug = "meskie", 
                    Description = "Odzież męska",
                    IconCssClass = "fas fa-male",
                    ImageUrl = "categories/men.jpg",
                    DisplayOrder = 2, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 3, 
                    Name = "Odzież Wierzchnia", 
                    NameKey = "Category_Outerwear",
                    Slug = "odziez-wierzchnia", 
                    Description = "Kurtki i płaszcze",
                    IconCssClass = "fas fa-wind",
                    ImageUrl = "categories/outerwear.jpg",
                    DisplayOrder = 3, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 4, 
                    Name = "Akcesoria", 
                    NameKey = "Category_Accessories",
                    Slug = "akcesoria", 
                    Description = "Dodatki i akcesoria",
                    IconCssClass = "fas fa-shopping-bag",
                    ImageUrl = "categories/accessories.jpg",
                    DisplayOrder = 4, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Woman subcategories
                new Category 
                { 
                    Id = 5, 
                    Name = "Sukienki", 
                    NameKey = "Category_Dresses",
                    Slug = "damskie-sukienki", 
                    Description = "Eleganckie sukienki damskie",
                    IconCssClass = "fas fa-tshirt",
                    ParentCategoryId = 1, 
                    DisplayOrder = 1, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 6, 
                    Name = "Spódnice", 
                    NameKey = "Category_Skirts",
                    Slug = "damskie-spodnice", 
                    Description = "Modne spódnice",
                    IconCssClass = "fas fa-tshirt",
                    ParentCategoryId = 1, 
                    DisplayOrder = 2, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 7, 
                    Name = "Bluzki", 
                    NameKey = "Category_Blouses",
                    Slug = "damskie-bluzki", 
                    Description = "Eleganckie bluzki damskie",
                    IconCssClass = "fas fa-tshirt",
                    ParentCategoryId = 1, 
                    DisplayOrder = 3, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 8, 
                    Name = "Spodnie", 
                    NameKey = "Category_WomenPants",
                    Slug = "damskie-spodnie", 
                    Description = "Spodnie damskie",
                    IconCssClass = "fas fa-tshirt",
                    ParentCategoryId = 1, 
                    DisplayOrder = 4, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Man subcategories
                new Category 
                { 
                    Id = 9, 
                    Name = "Koszule", 
                    NameKey = "Category_Shirts",
                    Slug = "meskie-koszule", 
                    Description = "Eleganckie koszule męskie",
                    IconCssClass = "fas fa-tshirt",
                    ParentCategoryId = 2, 
                    DisplayOrder = 1, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 10, 
                    Name = "Spodnie", 
                    NameKey = "Category_MenPants",
                    Slug = "meskie-spodnie", 
                    Description = "Spodnie męskie",
                    IconCssClass = "fas fa-tshirt",
                    ParentCategoryId = 2, 
                    DisplayOrder = 2, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 11, 
                    Name = "T-Shirty", 
                    NameKey = "Category_TShirts",
                    Slug = "meskie-tshirty", 
                    Description = "Koszulki męskie",
                    IconCssClass = "fas fa-tshirt",
                    ParentCategoryId = 2, 
                    DisplayOrder = 3, 
                    ShowInNavbar = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Category 
                { 
                    Id = 12, 
                    Name = "Bluzy", 
                    NameKey = "Category_Sweatshirts",
                    Slug = "meskie-bluzy", 
                    Description = "Bluzy męskie",
                    IconCssClass = "fas fa-tshirt",
                    ParentCategoryId = 2, 
                    DisplayOrder = 4, 
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

        public static void SeedBlogs(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    CategoryId = 3, // Trendy
                    FeaturedImage = "/img/Blog/fashion-trends-2025.jpg",
                    IsPublished = true,
                    PublishedDate = DateTime.UtcNow,
                    Views = 0,
                    AllowComments = true,
                    AuthorId = null, // Nullable to allow seeding before users exist
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    IsDeleted = false
                }
            );
        }

        public static void SeedBlogTranslations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogTranslation>().HasData(
                // Blog 1 - English
                new BlogTranslation
                {
                    Id = 1,
                    BlogId = 1,
                    CultureCode = "en-US",
                    Title = "Fashion Trends for 2025",
                    Slug = "fashion-trends-2025",
                    Content = "<p>Discover the hottest fashion trends that will dominate 2025. From sustainable fabrics to bold colors, we present everything you need to know to stay stylish.</p><p>This season brings a return to classics with a modern twist - oversized blazers, midi skirts, and minimalist accessories are the must-haves in every wardrobe.</p><p><strong>Key trends:</strong></p><ul><li>Sustainable and eco-friendly materials</li><li>Bold color combinations</li><li>Oversized silhouettes</li><li>Minimalist accessories</li><li>Vintage revival</li></ul><p>Stay tuned for more fashion tips and style inspiration on our blog!</p>",
                    Excerpt = "Discover the hottest fashion trends that will dominate 2025. From sustainable fabrics to bold colors.",
                    Tags = "fashion,trends,2025,style",
                    MetaDescription = "Discover the hottest fashion trends for 2025 - sustainable materials, bold colors, and timeless style.",
                    MetaKeywords = "fashion,trends,2025,style,clothing,sustainable fashion",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                // Blog 1 - Polish
                new BlogTranslation
                {
                    Id = 2,
                    BlogId = 1,
                    CultureCode = "pl-PL",
                    Title = "Trendy Modowe na 2025",
                    Slug = "trendy-modowe-2025",
                    Content = "<p>Odkryj najgorętsze trendy modowe, które zdominują rok 2025. Od zrównoważonych materiałów po odważne kolory, prezentujemy wszystko, co musisz wiedzieć, aby być na czasie.</p><p>Ten sezon przynosi powrót do klasyki z nowoczesnym akcentem - oversize'owe marynarki, midi spódnice i minimalistyczna biżuteria to must-have w każdej garderobie.</p><p><strong>Kluczowe trendy:</strong></p><ul><li>Zrównoważone i ekologiczne materiały</li><li>Odważne kombinacje kolorów</li><li>Oversize'owe sylwetki</li><li>Minimalistyczne akcesoria</li><li>Powrót vintage</li></ul><p>Bądź na bieżąco z naszymi poradami modowymi i inspiracjami stylistycznymi na blogu!</p>",
                    Excerpt = "Odkryj najgorętsze trendy modowe, które zdominują rok 2025. Od zrównoważonych materiałów po odważne kolory.",
                    Tags = "moda,trendy,2025,styl",
                    MetaDescription = "Odkryj najgorętsze trendy modowe na rok 2025 - zrównoważone materiały, odważne kolory i ponadczasowy styl.",
                    MetaKeywords = "moda,trendy,2025,styl,odzież,zrównoważona moda",
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
                },
                new SiteSetting
                {
                    Id = 9,
                    Key = "TaxRate",
                    Value = "0.23", // 23% VAT for Poland
                    Description = "Tax rate (VAT) applied to orders (decimal, e.g., 0.23 = 23%)",
                    Category = "Tax",
                    DataType = "decimal",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 10,
                    Key = "ShippingRate",
                    Value = "15.00", // 15 PLN standard shipping
                    Description = "Standard shipping cost in PLN",
                    Category = "Shipping",
                    DataType = "decimal",
                    UpdatedAt = DateTime.UtcNow
                },
                new SiteSetting
                {
                    Id = 11,
                    Key = "FreeShippingThreshold",
                    Value = "200.00", // Free shipping over 200 PLN
                    Description = "Minimum order value for free shipping in PLN",
                    Category = "Shipping",
                    DataType = "decimal",
                    UpdatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedCoupons(this ModelBuilder modelBuilder)
        {
            // Note: HasData only inserts if the Id doesn't exist
            // If coupon with Id=1 exists, it will be skipped automatically
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon
                {
                    Id = 1,
                    Code = "WELCOME10",
                    Description = "10% off your first order",
                    DiscountType = "percentage",
                    DiscountValue = 10.00m,
                    MinimumOrderAmount = 50.00m,
                    MaximumDiscountAmount = 50.00m,
                    UsageLimit = 1000,
                    UsageCount = 0,
                    UsageLimitPerUser = 1,
                    ValidFrom = DateTime.UtcNow,
                    ValidUntil = DateTime.UtcNow.AddMonths(6),
                    IsActive = true,
                    StripeCouponId = "",
                    StripePromotionCodeId = "",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            // Note: HasData only inserts if the Id doesn't exist
            // If products with these Ids exist, they will be skipped automatically
            modelBuilder.Entity<Product>().HasData(
                // Product 1: Women's Cotton Briefs - Base/Single
                new Product 
                { 
                    Id = 1, 
                    Name = "Majtki damskie bawełniane wysokie - Single", 
                    Slug = "majtki-damskie-bawelniane-wysokie-single",
                    Description = "Wysokiej jakości majtki damskie bawełniane. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.",
                    Price = 9.95m,
                    StripeProductId = string.Empty,
                    StripePriceId = string.Empty,
                    StripeTaxCode = "txcd_30011000",
                    PackSize = 1,
                    ProductGroupId = 1,
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Product 2: Women's Cotton Briefs 5-Pack
                new Product 
                { 
                    Id = 2, 
                    Name = "Majtki damskie bawełniane wysokie - 5 pak", 
                    Slug = "majtki-damskie-bawelniane-wysokie-5-pak",
                    Description = "Wysokiej jakości majtki damskie bawełniane w zestawie 5 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.",
                    Price = 49.75m,
                    StripeProductId = string.Empty,
                    StripePriceId = string.Empty,
                    StripeTaxCode = "txcd_30011000",
                    PackSize = 5,
                    ProductGroupId = 1,
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Product 3: Women's Cotton Briefs 7-Pack
                new Product 
                { 
                    Id = 3, 
                    Name = "Majtki damskie bawełniane wysokie - 7 pak", 
                    Slug = "majtki-damskie-bawelniane-wysokie-7-pak",
                    Description = "Wysokiej jakości majtki damskie bawełniane w zestawie 7 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.",
                    Price = 69.65m,
                    StripeProductId = string.Empty,
                    StripePriceId = string.Empty,
                    StripeTaxCode = "txcd_30011000",
                    PackSize = 7,
                    ProductGroupId = 1,
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Product 4: Women's Cotton Briefs 8-Pack (Best Value)
                new Product 
                { 
                    Id = 4, 
                    Name = "Majtki damskie bawełniane wysokie - 8 pak", 
                    Slug = "majtki-damskie-bawelniane-wysokie-8-pak",
                    Description = "Wysokiej jakości majtki damskie bawełniane w zestawie 8 sztuk. Wygodne, przewiewne i trwałe. Najlepszy wybór wartościowy! Dostępne w różnych kolorach i rozmiarach.",
                    Price = 79.60m,
                    StripeProductId = string.Empty,
                    StripePriceId = string.Empty,
                    StripeTaxCode = "txcd_30011000",
                    PackSize = 8,
                    ProductGroupId = 1,
                    CategoryId = 1,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedProductImages(this ModelBuilder modelBuilder)
        {
            var images = new List<ProductImage>();
            int imageId = 1;

            // All 4 products share same images (2 images per product)
            for (int productId = 1; productId <= 4; productId++)
            {
                for (int imageNum = 1; imageNum <= 2; imageNum++)
                {
                    images.Add(new ProductImage
                    {
                        Id = imageId++,
                        ProductId = productId,
                        ImageUrl = $"products/briefs/image-{imageNum}.jpg",
                        AltText = imageNum == 1 
                            ? $"Majtki damskie bawełniane wysokie - widok z przodu" 
                            : $"Majtki damskie bawełniane wysokie - szczegóły produktu",
                        IsPrimary = imageNum == 1,
                        DisplayOrder = imageNum,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            modelBuilder.Entity<ProductImage>().HasData(images);
        }

        public static void SeedProductTranslations(this ModelBuilder modelBuilder)
        {
            var translations = new List<ProductTranslation>();
            int translationId = 1;

            // Product names and descriptions with pack info
            var productData = new[]
            {
                new { ProductId = 1, PackName = "Single", PackNamePl = "Pojedyncze", PackDesc = "", PackDescPl = "" },
                new { ProductId = 2, PackName = "5-Pack", PackNamePl = "5 pak", PackDesc = " (5 pieces)", PackDescPl = " (5 sztuk)" },
                new { ProductId = 3, PackName = "7-Pack", PackNamePl = "7 pak", PackDesc = " (7 pieces)", PackDescPl = " (7 sztuk)" },
                new { ProductId = 4, PackName = "8-Pack", PackNamePl = "8 pak", PackDesc = " (8 pieces)", PackDescPl = " (8 sztuk)" }
            };

            foreach (var product in productData)
            {
                // Polish translation
                translations.Add(new ProductTranslation
                {
                    Id = translationId++,
                    ProductId = product.ProductId,
                    CultureCode = "pl-PL",
                    Name = $"Majtki damskie bawełniane wysokie {product.PackNamePl}",
                    Description = $"Wysokiej jakości majtki damskie bawełniane{product.PackDescPl}. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.",
                    Slug = $"majtki-damskie-bawelniane-wysokie-{product.PackNamePl.ToLower().Replace(" ", "-")}",
                    MetaDescription = $"Kup majtki damskie bawełniane wysokie {product.PackNamePl}. Wygodne, przewiewne i trwałe. Dostawa w Polsce. Najlepsza jakość w przystępnej cenie.",
                    MetaKeywords = "majtki damskie, bawełna, bielizna damska, majtki wysokie, Kokomija"
                });

                // English translation
                translations.Add(new ProductTranslation
                {
                    Id = translationId++,
                    ProductId = product.ProductId,
                    CultureCode = "en-US",
                    Name = $"Women's Cotton Briefs {product.PackName}",
                    Description = $"High quality women's cotton briefs{product.PackDesc}. Comfortable, breathable and durable. Perfect choice for everyday wear. Available in various colors and sizes.",
                    Slug = $"womens-cotton-briefs-{product.PackName.ToLower().Replace(" ", "-")}",
                    MetaDescription = $"Buy women's cotton briefs {product.PackName}. Comfortable, breathable and durable underwear. Best quality at an affordable price.",
                    MetaKeywords = "women's briefs, cotton underwear, briefs, Kokomija"
                });
            }

            modelBuilder.Entity<ProductTranslation>().HasData(translations);
        }

        public static void SeedProductVariants(this ModelBuilder modelBuilder)
        {
            var variants = new List<ProductVariant>();
            int variantId = 1;

            // Sizes: 2=S, 3=M, 4=L, 5=XL, 6=XXL
            // Colors: 1=Black, 2=White, 3=Red, 4=Blue, 7=Navy
            
            int[] colors = { 1, 2, 3, 4, 7 }; // Black, White, Red, Blue, Navy
            int[] sizes = { 2, 3, 4, 5, 6 }; // S, M, L, XL, XXL

            // Product pricing
            var productPrices = new Dictionary<int, decimal>
            {
                { 1, 9.95m },     // Single: 9.95 PLN
                { 2, 49.75m },    // 5-Pack: 49.75 PLN
                { 3, 69.65m },    // 7-Pack: 69.65 PLN
                { 4, 79.60m }     // 8-Pack: 79.60 PLN
            };

            // Create 25 variants per product (5 colors × 5 sizes)
            for (int productId = 1; productId <= 4; productId++)
            {
                foreach (var colorId in colors)
                {
                    foreach (var sizeId in sizes)
                    {
                        string packName = productId switch
                        {
                            1 => "SINGLE",
                            2 => "5PK",
                            3 => "7PK",
                            4 => "8PK",
                            _ => "BULK"
                        };

                        variants.Add(new ProductVariant
                        {
                            Id = variantId++,
                            ProductId = productId,
                            SizeId = sizeId,
                            ColorId = colorId,
                            SKU = $"BRIEFS-{packName}-C{colorId}-S{sizeId}",
                            Price = productPrices[productId],
                            StockQuantity = 100,
                            StripePriceId = string.Empty,
                            IsActive = true,
                            CreatedAt = DateTime.UtcNow
                        });
                    }
                }
            }

            modelBuilder.Entity<ProductVariant>().HasData(variants);
        }

        public static void SeedCarouselSlides(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarouselSlide>().HasData(
                new CarouselSlide
                {
                    Id = 1,
                    Title = "Carousel_NewCollection", // Resource key
                    Subtitle = "Carousel_NewCollection_Subtitle", // Resource key
                    ImagePath = "/img/Carousel/1.jpg", // Desktop image
                    TabletImagePath = "/img/Carousel/2.jpg", // Tablet image
                    MobileImagePath = "/img/Carousel/3.jpg", // Mobile image
                    ImageAlt = "New Spring 2025 Collection",
                    ButtonText = "Carousel_ShopNow", // Resource key
                    DisplayOrder = 1,
                    IsActive = true,
                    Location = "Home",
                    StartDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedCarouselSlideTranslations(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarouselSlideTranslation>().HasData(
                // Slide 1 - English
                new CarouselSlideTranslation
                {
                    Id = 1,
                    CarouselSlideId = 1,
                    CultureCode = "en-US",
                    Title = "New Spring 2025 Collection",
                    Subtitle = "Discover the latest trends in women's and men's fashion",
                    ButtonText = "Shop Now",
                    ControllerName = "Product",
                    ActionName = "Index",
                    AreaName = null,
                    RouteParameters = null,
                    ImageAlt = "Kokomija Spring 2025 Fashion Collection - Premium Women's and Men's Underwear",
                    CreatedAt = DateTime.UtcNow
                },
                // Slide 1 - Polish
                new CarouselSlideTranslation
                {
                    Id = 2,
                    CarouselSlideId = 1,
                    CultureCode = "pl-PL",
                    Title = "Nowa Kolekcja Wiosna 2025",
                    Subtitle = "Odkryj najnowsze trendy w modzie damskiej i męskiej",
                    ButtonText = "Kup Teraz",
                    ControllerName = "Product",
                    ActionName = "Index",
                    AreaName = null,
                    RouteParameters = null,
                    ImageAlt = "Kokomija Kolekcja Wiosna 2025 - Wysokiej Jakości Bielizna Damska i Męska",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedProductGroups(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductGroup>().HasData(
                new ProductGroup
                {
                    Id = 1,
                    Name = "Women's Cotton Briefs Pack Collection",
                    NameKey = "ProductGroup_WomenBriefs_Name",
                    Description = "High-quality women's cotton briefs in various pack sizes",
                    DescriptionKey = "ProductGroup_WomenBriefs_Description",
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
