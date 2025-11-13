using Kokomija.Entity;

namespace Kokomija.Models.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Category> FeaturedCategories { get; set; } = new();
        public List<ProductCardViewModel> FeaturedProducts { get; set; } = new();
        public HeroAdViewModel? HeroAd { get; set; }
        public List<CouponBannerViewModel> ActiveCoupons { get; set; } = new();
        
        // SEO Meta Data
        public string MetaTitle { get; set; } = string.Empty;
        public string MetaDescription { get; set; } = string.Empty;
        public string MetaKeywords { get; set; } = string.Empty;
        public string CanonicalUrl { get; set; } = string.Empty;
    }
    
    public class ProductCardViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public string? MainImagePath { get; set; }
        public string? MainImageUrl { get; set; }
        public bool IsNew { get; set; }
        public bool IsOnSale { get; set; }
        public int? StockQuantity { get; set; }
        public bool HasStock { get; set; }
        public List<string> AvailableColors { get; set; } = new();
        public List<string> AvailableSizes { get; set; } = new();
        public List<ColorViewModel> Colors { get; set; } = new();
        public List<SizeViewModel> Sizes { get; set; } = new();
        public List<ProductImageViewModel> Images { get; set; } = new();
        public int? CategoryId { get; set; }
    }
    
    public class ColorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string HexCode { get; set; } = string.Empty;
    }
    
    public class SizeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
    }
    
    public class ProductImageViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string AltText { get; set; } = string.Empty;
        public bool IsPrimary { get; set; }
        public int DisplayOrder { get; set; }
    }
    
    public class HeroAdViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string ButtonText { get; set; } = string.Empty;
        public string ButtonUrl { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string BackgroundColor { get; set; } = "#F4A261";
    }

    public class CouponBannerViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public DateTime ValidUntil { get; set; }
        public bool IsNew { get; set; }
        public int DaysUntilExpiry { get; set; }
    }
}
