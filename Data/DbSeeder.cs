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
                // English version
                new Blog
                {
                    Id = 1,
                    Title = "Fashion Trends for 2025",
                    Content = "<p>Discover the hottest fashion trends that will dominate 2025. From sustainable fabrics to bold colors, we present everything you need to know to stay stylish.</p><p>This season brings a return to classics with a modern twist - oversized blazers, midi skirts, and minimalist accessories are the must-haves in every wardrobe.</p><p><strong>Key trends:</strong></p><ul><li>Sustainable and eco-friendly materials</li><li>Bold color combinations</li><li>Oversized silhouettes</li><li>Minimalist accessories</li><li>Vintage revival</li></ul>",
                    Excerpt = "Discover the hottest fashion trends that will dominate 2025.",
                    Slug = "fashion-trends-2025-en",
                    CategoryId = 3, // Trendy
                    FeaturedImage = "/images/blog/fashion-trends-2025.jpg",
                    Tags = "fashion,trends,2025,style",
                    IsPublished = true,
                    PublishedDate = DateTime.UtcNow,
                    Views = 0,
                    Language = "en",
                    MetaDescription = "Discover the hottest fashion trends for 2025",
                    MetaKeywords = "fashion,trends,2025,style,clothing",
                    AuthorId = "", // Will be set to admin user after seeding
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                // Polish version
                new Blog
                {
                    Id = 2,
                    Title = "Trendy Modowe na 2025",
                    Content = "<p>Odkryj najgorętsze trendy modowe, które zdominują rok 2025. Od zrównoważonych materiałów po odważne kolory, prezentujemy wszystko, co musisz wiedzieć, aby być na czasie.</p><p>Ten sezon przynosi powrót do klasyki z nowoczesnym akcentem - oversize'owe marynarki, midi spódnice i minimalistyczna biżuteria to must-have w każdej garderobie.</p><p><strong>Kluczowe trendy:</strong></p><ul><li>Zrównoważone i ekologiczne materiały</li><li>Odważne kombinacje kolorów</li><li>Oversize'owe sylwetki</li><li>Minimalistyczne akcesoria</li><li>Powrót vintage</li></ul>",
                    Excerpt = "Odkryj najgorętsze trendy modowe, które zdominują rok 2025.",
                    Slug = "trendy-modowe-2025",
                    CategoryId = 3, // Trendy
                    FeaturedImage = "/images/blog/fashion-trends-2025.jpg",
                    Tags = "moda,trendy,2025,styl",
                    IsPublished = true,
                    PublishedDate = DateTime.UtcNow,
                    Views = 0,
                    Language = "pl",
                    MetaDescription = "Odkryj najgorętsze trendy modowe na rok 2025",
                    MetaKeywords = "moda,trendy,2025,styl,odzież",
                    AuthorId = "", // Will be set to admin user after seeding
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
                // Product 1: Women's Cotton Briefs 5-Pack
                new Product 
                { 
                    Id = 1, 
                    Name = "Majtki damskie bawełniane wysokie - 5 pak", 
                    NameKey = "Product_WomenBriefs5Pack_Name",
                    Description = "Wysokiej jakości majtki damskie bawełniane w zestawie 5 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.",
                    DescriptionKey = "Product_WomenBriefs5Pack_Description",
                    Price = 49.75m,
                    StripeProductId = string.Empty, // Will be created by StripeProductSeeder
                    StripePriceId = string.Empty,
                    StripeTaxCode = "txcd_30011000", // Clothing - Apparel
                    PackSize = 5,
                    ProductGroupId = 1, // Women's Briefs Pack Collection
                    CategoryId = 1, // Damskie
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Product 2: Women's Cotton Briefs 6-Pack
                new Product 
                { 
                    Id = 2, 
                    Name = "Majtki damskie bawełniane wysokie - 6 pak", 
                    NameKey = "Product_WomenBriefs6Pack_Name",
                    Description = "Wysokiej jakości majtki damskie bawełniane w zestawie 6 sztuk. Wygodne, przewiewne i trwałe. Idealny wybór na co dzień. Dostępne w różnych kolorach i rozmiarach.",
                    DescriptionKey = "Product_WomenBriefs6Pack_Description",
                    Price = 59.70m,
                    StripeProductId = string.Empty, // Will be created by StripeProductSeeder
                    StripePriceId = string.Empty,
                    StripeTaxCode = "txcd_30011000", // Clothing - Apparel
                    PackSize = 6,
                    ProductGroupId = 1, // Women's Briefs Pack Collection
                    CategoryId = 1, // Damskie
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Product 3: Women's Cotton Briefs 8-Pack (Best Value)
                new Product 
                { 
                    Id = 3, 
                    Name = "Majtki damskie bawełniane wysokie - 8 pak", 
                    NameKey = "Product_WomenBriefs8Pack_Name",
                    Description = "Wysokiej jakości majtki damskie bawełniane w zestawie 8 sztuk. Wygodne, przewiewne i trwałe. Najlepszy wybór wartościowy! Dostępne w różnych kolorach i rozmiarach.",
                    DescriptionKey = "Product_WomenBriefs8Pack_Description",
                    Price = 79.60m,
                    StripeProductId = string.Empty, // Will be created by StripeProductSeeder
                    StripePriceId = string.Empty,
                    StripeTaxCode = "txcd_30011000", // Clothing - Apparel
                    PackSize = 8,
                    ProductGroupId = 1, // Women's Briefs Pack Collection
                    CategoryId = 1, // Damskie
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedProductImages(this ModelBuilder modelBuilder)
        {
            var images = new List<ProductImage>();
            int imageId = 1;

            // Women's Briefs 5-Pack - Product ID 1
            for (int imageNum = 1; imageNum <= 8; imageNum++)
            {
                images.Add(new ProductImage
                {
                    Id = imageId++,
                    ProductId = 1,
                    ImageUrl = $"products/briefs-5pack/image-{imageNum}.jpg",
                    AltText = $"Majtki damskie bawełniane 5-pak - zdjęcie {imageNum}",
                    IsPrimary = imageNum == 1,
                    DisplayOrder = imageNum,
                    CreatedAt = DateTime.UtcNow
                });
            }

            // Women's Briefs 6-Pack - Product ID 2
            for (int imageNum = 1; imageNum <= 8; imageNum++)
            {
                images.Add(new ProductImage
                {
                    Id = imageId++,
                    ProductId = 2,
                    ImageUrl = $"products/briefs-6pack/image-{imageNum}.jpg",
                    AltText = $"Majtki damskie bawełniane 6-pak - zdjęcie {imageNum}",
                    IsPrimary = imageNum == 1,
                    DisplayOrder = imageNum,
                    CreatedAt = DateTime.UtcNow
                });
            }

            // Women's Briefs 8-Pack - Product ID 3
            for (int imageNum = 1; imageNum <= 8; imageNum++)
            {
                images.Add(new ProductImage
                {
                    Id = imageId++,
                    ProductId = 3,
                    ImageUrl = $"products/briefs-8pack/image-{imageNum}.jpg",
                    AltText = $"Majtki damskie bawełniane 8-pak - zdjęcie {imageNum}",
                    IsPrimary = imageNum == 1,
                    DisplayOrder = imageNum,
                    CreatedAt = DateTime.UtcNow
                });
            }

            modelBuilder.Entity<ProductImage>().HasData(images);
        }

        public static void SeedProductVariants(this ModelBuilder modelBuilder)
        {
            var variants = new List<ProductVariant>();
            int variantId = 1;

            // Sizes available: XS=1, S=2, M=3, L=4, XL=5, XXL=6
            // Colors: Multi-color mix (no specific color, use id=8 for "Mix")
            int[] sizes = { 2, 3, 4, 5, 6 }; // S, M, L, XL, XXL
            int mixColorId = 8; // Gray/Mix placeholder

            // Product 1: Women's Briefs 5-Pack
            foreach (var sizeId in sizes)
            {
                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = 1,
                    SizeId = sizeId,
                    ColorId = mixColorId,
                    SKU = $"BRIEFS-5PK-S{sizeId}",
                    Price = 49.75m,
                    StockQuantity = 100,
                    StripePriceId = string.Empty,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                });
            }

            // Product 2: Women's Briefs 6-Pack
            foreach (var sizeId in sizes)
            {
                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = 2,
                    SizeId = sizeId,
                    ColorId = mixColorId,
                    SKU = $"BRIEFS-6PK-S{sizeId}",
                    Price = 59.70m,
                    StockQuantity = 100,
                    StripePriceId = string.Empty,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                });
            }

            // Product 3: Women's Briefs 8-Pack (Best Value)
            foreach (var sizeId in sizes)
            {
                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = 3,
                    SizeId = sizeId,
                    ColorId = mixColorId,
                    SKU = $"BRIEFS-8PK-S{sizeId}",
                    Price = 79.60m,
                    StockQuantity = 100,
                    StripePriceId = string.Empty,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                });
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
