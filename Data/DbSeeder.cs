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
    }
}
