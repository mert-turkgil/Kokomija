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

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                // Women's Products
                new Product 
                { 
                    Id = 1, 
                    Name = "Elegancka Sukienka Letnia", 
                    Description = "Piękna, zwiewna sukienka idealna na letnie wieczory. Wykonana z wysokiej jakości materiału, zapewnia komfort i styl.",
                    Price = 189.99m,
                    StripeProductId = "prod_sukienka_letnia_001",
                    StripePriceId = "price_sukienka_letnia_001",
                    CategoryId = 5, // Sukienki
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 2, 
                    Name = "Spódnica Midi Plisowana", 
                    Description = "Klasyczna plisowana spódnica midi. Doskonała do biura i na specjalne okazje.",
                    Price = 149.99m,
                    StripeProductId = "prod_spodnica_midi_001",
                    StripePriceId = "price_spodnica_midi_001",
                    CategoryId = 6, // Spódnice
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 3, 
                    Name = "Bluzka Elegancka Biała", 
                    Description = "Elegancka biała bluzka z delikatnymi wzorami. Idealna do spodni i spódnic.",
                    Price = 99.99m,
                    StripeProductId = "prod_bluzka_biala_001",
                    StripePriceId = "price_bluzka_biala_001",
                    CategoryId = 7, // Bluzki
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 4, 
                    Name = "Spodnie Damskie Czarne", 
                    Description = "Klasyczne czarne spodnie damskie. Wygodne i eleganckie, pasują do każdej stylizacji.",
                    Price = 129.99m,
                    StripeProductId = "prod_spodnie_damskie_001",
                    StripePriceId = "price_spodnie_damskie_001",
                    CategoryId = 8, // Spodnie damskie
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 5, 
                    Name = "Bluzka Kwiatowa Wzór", 
                    Description = "Kolorowa bluzka w kwiatowy wzór. Idealna na wiosnę i lato.",
                    Price = 89.99m,
                    StripeProductId = "prod_bluzka_kwiatowa_001",
                    StripePriceId = "price_bluzka_kwiatowa_001",
                    CategoryId = 7, // Bluzki
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Men's Products
                new Product 
                { 
                    Id = 6, 
                    Name = "Koszula Męska Niebieska", 
                    Description = "Elegancka niebieska koszula męska. Idealna do garnituru i na oficjalne spotkania.",
                    Price = 159.99m,
                    StripeProductId = "prod_koszula_niebieska_001",
                    StripePriceId = "price_koszula_niebieska_001",
                    CategoryId = 9, // Koszule
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 7, 
                    Name = "Spodnie Męskie Chino", 
                    Description = "Klasyczne spodnie męskie typu chino. Wygodne i stylowe na co dzień.",
                    Price = 179.99m,
                    StripeProductId = "prod_spodnie_chino_001",
                    StripePriceId = "price_spodnie_chino_001",
                    CategoryId = 10, // Spodnie męskie
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 8, 
                    Name = "T-Shirt Męski Basic Biały", 
                    Description = "Podstawowy biały t-shirt męski. Wysokiej jakości bawełna, idealny na co dzień.",
                    Price = 59.99m,
                    StripeProductId = "prod_tshirt_bialy_001",
                    StripePriceId = "price_tshirt_bialy_001",
                    CategoryId = 11, // T-Shirty
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 9, 
                    Name = "T-Shirt Męski Basic Czarny", 
                    Description = "Podstawowy czarny t-shirt męski. Niezawodny element każdej szafy.",
                    Price = 59.99m,
                    StripeProductId = "prod_tshirt_czarny_001",
                    StripePriceId = "price_tshirt_czarny_001",
                    CategoryId = 11, // T-Shirty
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 10, 
                    Name = "Bluza Męska z Kapturem", 
                    Description = "Ciepła i wygodna bluza męska z kapturem. Idealna na chłodniejsze dni.",
                    Price = 139.99m,
                    StripeProductId = "prod_bluza_kaptur_001",
                    StripePriceId = "price_bluza_kaptur_001",
                    CategoryId = 12, // Bluzy
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 11, 
                    Name = "Koszula Męska Biała Classic", 
                    Description = "Klasyczna biała koszula męska. Must-have w każdej szafie.",
                    Price = 149.99m,
                    StripeProductId = "prod_koszula_biala_001",
                    StripePriceId = "price_koszula_biala_001",
                    CategoryId = 9, // Koszule
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 12, 
                    Name = "Spodnie Męskie Jeans", 
                    Description = "Klasyczne jeansy męskie w kolorze ciemnego denimu. Trwałe i stylowe.",
                    Price = 199.99m,
                    StripeProductId = "prod_jeans_meskie_001",
                    StripePriceId = "price_jeans_meskie_001",
                    CategoryId = 10, // Spodnie męskie
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                
                // Outerwear
                new Product 
                { 
                    Id = 13, 
                    Name = "Kurtka Wiosenna Damska", 
                    Description = "Lekka kurtka wiosenna dla kobiet. Wodoodporna i wygodna.",
                    Price = 299.99m,
                    StripeProductId = "prod_kurtka_wiosenna_001",
                    StripePriceId = "price_kurtka_wiosenna_001",
                    CategoryId = 3, // Odzież Wierzchnia
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 14, 
                    Name = "Płaszcz Męski Wełniany", 
                    Description = "Elegancki wełniany płaszcz męski. Ciepły i stylowy na zimę.",
                    Price = 449.99m,
                    StripeProductId = "prod_plaszcz_welniany_001",
                    StripePriceId = "price_plaszcz_welniany_001",
                    CategoryId = 3, // Odzież Wierzchnia
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                },
                new Product 
                { 
                    Id = 15, 
                    Name = "Kurtka Skórzana", 
                    Description = "Klasyczna kurtka skórzana. Ponadczasowy styl dla mężczyzn i kobiet.",
                    Price = 599.99m,
                    StripeProductId = "prod_kurtka_skorzana_001",
                    StripePriceId = "price_kurtka_skorzana_001",
                    CategoryId = 3, // Odzież Wierzchnia
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }

        public static void SeedProductImages(this ModelBuilder modelBuilder)
        {
            var images = new List<ProductImage>();
            int imageId = 1;

            // Generate 3 images for each product (15 products)
            for (int productId = 1; productId <= 15; productId++)
            {
                for (int imageNum = 1; imageNum <= 3; imageNum++)
                {
                    images.Add(new ProductImage
                    {
                        Id = imageId++,
                        ProductId = productId,
                        ImageUrl = $"{imageNum}.jpg",
                        AltText = $"Product {productId} Image {imageNum}",
                        IsPrimary = imageNum == 1,
                        DisplayOrder = imageNum,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            modelBuilder.Entity<ProductImage>().HasData(images);
        }

        public static void SeedProductVariants(this ModelBuilder modelBuilder)
        {
            var variants = new List<ProductVariant>();
            int variantId = 1;

            // Product 1: Sukienka - Sizes: S, M, L, XL | Colors: Red, Blue, Black
            int[] sizes = { 2, 3, 4, 5 }; // S, M, L, XL
            int[] colors1 = { 3, 4, 1 }; // Red, Blue, Black
            foreach (var sizeId in sizes)
            {
                foreach (var colorId in colors1)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 1,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"SUK-001-{sizeId}-{colorId}",
                        Price = 189.99m,
                        StockQuantity = 25,
                        StripePriceId = $"price_suk_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 2: Spódnica - Sizes: XS, S, M, L | Colors: Black, White, Navy
            int[] sizes2 = { 1, 2, 3, 4 }; // XS, S, M, L
            int[] colors2 = { 1, 2, 7 }; // Black, White, Navy
            foreach (var sizeId in sizes2)
            {
                foreach (var colorId in colors2)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 2,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"SPO-001-{sizeId}-{colorId}",
                        Price = 149.99m,
                        StockQuantity = 30,
                        StripePriceId = $"price_spo_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 3: Bluzka Biała - Sizes: S, M, L, XL | Colors: White
            int[] colors3 = { 2 }; // White only
            foreach (var sizeId in sizes)
            {
                foreach (var colorId in colors3)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 3,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"BLU-001-{sizeId}-{colorId}",
                        Price = 99.99m,
                        StockQuantity = 40,
                        StripePriceId = $"price_blu_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 4: Spodnie Damskie - Sizes: S, M, L, XL, XXL | Colors: Black, Gray
            int[] sizes4 = { 2, 3, 4, 5, 6 }; // S, M, L, XL, XXL
            int[] colors4 = { 1, 8 }; // Black, Gray
            foreach (var sizeId in sizes4)
            {
                foreach (var colorId in colors4)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 4,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"SPD-001-{sizeId}-{colorId}",
                        Price = 129.99m,
                        StockQuantity = 35,
                        StripePriceId = $"price_spd_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 5: Bluzka Kwiatowa - Sizes: XS, S, M, L, XL | Colors: Red, Yellow, Green
            int[] sizes5 = { 1, 2, 3, 4, 5 }; // XS, S, M, L, XL
            int[] colors5 = { 3, 6, 5 }; // Red, Yellow, Green
            foreach (var sizeId in sizes5)
            {
                foreach (var colorId in colors5)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 5,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"BLK-001-{sizeId}-{colorId}",
                        Price = 89.99m,
                        StockQuantity = 45,
                        StripePriceId = $"price_blk_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 6: Koszula Niebieska - Sizes: M, L, XL, XXL | Colors: Blue, Navy
            int[] sizes6 = { 3, 4, 5, 6 }; // M, L, XL, XXL
            int[] colors6 = { 4, 7 }; // Blue, Navy
            foreach (var sizeId in sizes6)
            {
                foreach (var colorId in colors6)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 6,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"KOS-001-{sizeId}-{colorId}",
                        Price = 159.99m,
                        StockQuantity = 30,
                        StripePriceId = $"price_kos_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 7: Spodnie Chino - Sizes: S, M, L, XL, XXL | Colors: Black, Gray, Navy
            int[] colors7 = { 1, 8, 7 }; // Black, Gray, Navy
            foreach (var sizeId in sizes4)
            {
                foreach (var colorId in colors7)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 7,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"CHI-001-{sizeId}-{colorId}",
                        Price = 179.99m,
                        StockQuantity = 28,
                        StripePriceId = $"price_chi_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 8: T-Shirt Biały - Sizes: S, M, L, XL, XXL | Colors: White
            int[] colorsWhite = { 2 }; // White
            foreach (var sizeId in sizes4)
            {
                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = 8,
                    SizeId = sizeId,
                    ColorId = 2,
                    SKU = $"TSH-W-{sizeId}",
                    Price = 59.99m,
                    StockQuantity = 50,
                    StripePriceId = $"price_tsh_w_{sizeId}",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                });
            }

            // Product 9: T-Shirt Czarny - Sizes: S, M, L, XL, XXL | Colors: Black
            foreach (var sizeId in sizes4)
            {
                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = 9,
                    SizeId = sizeId,
                    ColorId = 1,
                    SKU = $"TSH-B-{sizeId}",
                    Price = 59.99m,
                    StockQuantity = 50,
                    StripePriceId = $"price_tsh_b_{sizeId}",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                });
            }

            // Product 10: Bluza z Kapturem - Sizes: M, L, XL, XXL | Colors: Black, Gray, Navy
            foreach (var sizeId in sizes6)
            {
                foreach (var colorId in colors7)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 10,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"BLZ-001-{sizeId}-{colorId}",
                        Price = 139.99m,
                        StockQuantity = 32,
                        StripePriceId = $"price_blz_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 11: Koszula Biała - Sizes: M, L, XL, XXL | Colors: White
            foreach (var sizeId in sizes6)
            {
                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = 11,
                    SizeId = sizeId,
                    ColorId = 2,
                    SKU = $"KSH-W-{sizeId}",
                    Price = 149.99m,
                    StockQuantity = 35,
                    StripePriceId = $"price_ksh_w_{sizeId}",
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                });
            }

            // Product 12: Jeansy - Sizes: S, M, L, XL, XXL | Colors: Blue, Navy
            foreach (var sizeId in sizes4)
            {
                foreach (var colorId in colors6)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 12,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"JEA-001-{sizeId}-{colorId}",
                        Price = 199.99m,
                        StockQuantity = 28,
                        StripePriceId = $"price_jea_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 13: Kurtka Wiosenna - Sizes: S, M, L, XL | Colors: Red, Blue, Black
            foreach (var sizeId in sizes)
            {
                foreach (var colorId in colors1)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 13,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"KUR-001-{sizeId}-{colorId}",
                        Price = 299.99m,
                        StockQuantity = 20,
                        StripePriceId = $"price_kur_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 14: Płaszcz Wełniany - Sizes: M, L, XL, XXL | Colors: Black, Gray
            foreach (var sizeId in sizes6)
            {
                foreach (var colorId in colors4)
                {
                    variants.Add(new ProductVariant
                    {
                        Id = variantId++,
                        ProductId = 14,
                        SizeId = sizeId,
                        ColorId = colorId,
                        SKU = $"PLA-001-{sizeId}-{colorId}",
                        Price = 449.99m,
                        StockQuantity = 15,
                        StripePriceId = $"price_pla_001_{sizeId}_{colorId}",
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            // Product 15: Kurtka Skórzana - Sizes: M, L, XL, XXL | Colors: Black
            foreach (var sizeId in sizes6)
            {
                variants.Add(new ProductVariant
                {
                    Id = variantId++,
                    ProductId = 15,
                    SizeId = sizeId,
                    ColorId = 1,
                    SKU = $"SKO-001-{sizeId}",
                    Price = 599.99m,
                    StockQuantity = 10,
                    StripePriceId = $"price_sko_001_{sizeId}",
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
                    Title = "Nowa Kolekcja Wiosna 2025",
                    Subtitle = "Odkryj najnowsze trendy w modzie damskiej i męskiej",
                    ImagePath = "1.jpg",
                    ImageAlt = "Nowa kolekcja wiosenna 2025",
                    LinkUrl = "/damskie",
                    ButtonText = "Kup Teraz",
                    DisplayOrder = 1,
                    IsActive = true,
                    Location = "home",
                    StartDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new CarouselSlide
                {
                    Id = 2,
                    Title = "Wyprzedaż do -50%",
                    Subtitle = "Nie przegap okazji! Setki produktów w obniżonych cenach",
                    ImagePath = "2.jpg",
                    ImageAlt = "Wielka wyprzedaż do -50%",
                    LinkUrl = "/meskie",
                    ButtonText = "Zobacz Ofertę",
                    DisplayOrder = 2,
                    IsActive = true,
                    Location = "home",
                    StartDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new CarouselSlide
                {
                    Id = 3,
                    Title = "Elegancja na Każdą Okazję",
                    Subtitle = "Koszule, sukienki i dodatki dla wymagających",
                    ImagePath = "3.jpg",
                    ImageAlt = "Elegancka odzież na specjalne okazje",
                    LinkUrl = "/odziez-wierzchnia",
                    ButtonText = "Przeglądaj",
                    DisplayOrder = 3,
                    IsActive = true,
                    Location = "home",
                    StartDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new CarouselSlide
                {
                    Id = 4,
                    Title = "Darmowa Dostawa",
                    Subtitle = "Przy zamówieniach powyżej 200 PLN",
                    ImagePath = "4.jpg",
                    ImageAlt = "Darmowa dostawa powyżej 200 PLN",
                    LinkUrl = "/akcesoria",
                    ButtonText = "Sprawdź",
                    DisplayOrder = 4,
                    IsActive = true,
                    Location = "home",
                    StartDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                },
                new CarouselSlide
                {
                    Id = 5,
                    Title = "Stylowe Kurtki",
                    Subtitle = "Przygotuj się na zimę z naszą kolekcją kurtek",
                    ImagePath = "5.jpg",
                    ImageAlt = "Kolekcja zimowych kurtek",
                    LinkUrl = "/odziez-wierzchnia",
                    ButtonText = "Odkryj Więcej",
                    DisplayOrder = 5,
                    IsActive = true,
                    Location = "home",
                    StartDate = DateTime.UtcNow,
                    CreatedAt = DateTime.UtcNow
                }
            );
        }
    }
}
