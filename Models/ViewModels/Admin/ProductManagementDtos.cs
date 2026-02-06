using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kokomija.Models.ViewModels.Admin;

public class ProductManagementViewModel
{
    public List<ProductListItemDto> Products { get; set; } = new();
    public int TotalProducts { get; set; }
    public int ActiveProducts { get; set; }
    public int InactiveProducts { get; set; }
    public int OutOfStockProducts { get; set; }
    public decimal TotalInventoryValue { get; set; }
    public int BusinessOnlyProducts { get; set; }
    
    // Search/filter parameters
    public string? SearchTerm { get; set; }
    public string? SearchType { get; set; } // "name", "sku", "id"
    public bool? IsBusinessOnly { get; set; }
    public int? CategoryId { get; set; }
}

public class ProductListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? CategoryName { get; set; }
    public string? ParentCategoryName { get; set; }
    public decimal Price { get; set; }
    public int PackSize { get; set; }
    public bool IsActive { get; set; }
    public int TotalStock { get; set; }
    public int TotalVariants { get; set; }
    public int ReviewCount { get; set; }
    public decimal AverageRating { get; set; }
    public string? FeaturedImage { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string StripeProductId { get; set; } = string.Empty;
    public string StripePriceId { get; set; } = string.Empty;
    
    // Business (B2B) fields
    public bool IsBusinessOnly { get; set; }
    public bool IsAvailableForBusiness { get; set; }
    public int MinBusinessQuantity { get; set; }
    public decimal? BusinessPrice { get; set; }
    
    // SKU info for search
    public List<string> SKUs { get; set; } = new();
}

public class ProductCreateDto
{
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    public string? ShortDescription { get; set; }

    [Required]
    public string Description { get; set; } = string.Empty;

    // Translations
    public List<ProductTranslationDto> Translations { get; set; } = new();

    [Required]
    [Range(0.01, 999999.99)]
    public decimal BasePrice { get; set; }

    [Range(1, 100)]
    public int PackSize { get; set; } = 1;

    [Required]
    public int CategoryId { get; set; }

    public int? ProductGroupId { get; set; }

    /// <summary>
    /// Optional: Associate a coupon with this product for automatic discount
    /// </summary>
    public int? CouponId { get; set; }

    [StringLength(50)]
    public string? StripeTaxCode { get; set; }

    public bool IsActive { get; set; } = true;

    // ===== BUSINESS (B2B) FIELDS =====
    
    /// <summary>
    /// If true, only visible to verified business customers
    /// </summary>
    public bool IsBusinessOnly { get; set; } = false;

    /// <summary>
    /// If true, available for both retail and business customers
    /// </summary>
    public bool IsAvailableForBusiness { get; set; } = true;

    /// <summary>
    /// Minimum quantity for business purchases (0 = no minimum)
    /// </summary>
    [Range(0, 10000)]
    public int MinBusinessQuantity { get; set; } = 0;

    /// <summary>
    /// Special business price (leave empty to use retail price)
    /// </summary>
    [Range(0, 999999.99)]
    public decimal? BusinessPrice { get; set; }
    
    // ===== END BUSINESS FIELDS =====

    /// <summary>
    /// Custom color hex code if not in the predefined palette
    /// </summary>
    [StringLength(7)]
    public string? CustomColorHex { get; set; }

    [StringLength(50)]
    public string? CustomColorName { get; set; }

    // Size Guide (photo and/or data table)
    public SizeGuideDto? SizeGuide { get; set; }

    // Image upload - temp file names from AJAX upload
    public List<string> TempImageFileNames { get; set; } = new();

    // Variants (colors, sizes, stock)
    public List<ProductVariantDto> Variants { get; set; } = new();

    // Selected sizes and colors
    public List<int> SelectedSizeIds { get; set; } = new();
    public List<int> SelectedColorIds { get; set; } = new();

    // For dropdown/checkbox population (not posted back)
    public SelectList? Categories { get; set; }
    public List<SelectListItem> AvailableSizes { get; set; } = new();
    public List<SelectListItem> AvailableColors { get; set; } = new();
}

public class ProductUpdateDto
{
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    // Translations
    public List<ProductTranslationDto> Translations { get; set; } = new();

    [Required]
    [Range(0.01, 999999.99)]
    public decimal Price { get; set; }

    [Range(1, 100)]
    public int PackSize { get; set; } = 1;

    public int? CategoryId { get; set; }

    public int? ProductGroupId { get; set; }

    /// <summary>
    /// Optional: Associate a coupon with this product for automatic discount
    /// </summary>
    public int? CouponId { get; set; }

    [StringLength(50)]
    public string? StripeTaxCode { get; set; }

    public bool IsActive { get; set; }

    // ===== BUSINESS (B2B) FIELDS =====
    
    /// <summary>
    /// If true, only visible to verified business customers
    /// </summary>
    public bool IsBusinessOnly { get; set; } = false;

    /// <summary>
    /// If true, available for both retail and business customers
    /// </summary>
    public bool IsAvailableForBusiness { get; set; } = true;

    /// <summary>
    /// Minimum quantity for business purchases (0 = no minimum)
    /// </summary>
    [Range(0, 10000)]
    public int MinBusinessQuantity { get; set; } = 0;

    /// <summary>
    /// Special business price (leave empty to use retail price)
    /// </summary>
    [Range(0, 999999.99)]
    public decimal? BusinessPrice { get; set; }

    /// <summary>
    /// Stripe Price ID for business price
    /// </summary>
    public string? BusinessStripePriceId { get; set; }
    
    // ===== END BUSINESS FIELDS =====

    /// <summary>
    /// Custom color hex code if not in the predefined palette
    /// </summary>
    [StringLength(7)]
    public string? CustomColorHex { get; set; }

    [StringLength(50)]
    public string? CustomColorName { get; set; }

    public string StripeProductId { get; set; } = string.Empty;
    public string StripePriceId { get; set; } = string.Empty;

    // Size Guide (photo and/or data table)
    public SizeGuideDto? SizeGuide { get; set; }

    // Images
    public List<string> ExistingImageUrls { get; set; } = new();
    public List<string> NewImageTempFileNames { get; set; } = new();
    public List<string> ImagesToDelete { get; set; } = new();

    // Variants
    public List<ProductVariantDto> Variants { get; set; } = new();

    // Available sizes
    public List<int> SizeIds { get; set; } = new();

    // Available colors
    public List<int> ColorIds { get; set; } = new();

    // Reviews (for management)
    public List<ProductReviewManagementDto> Reviews { get; set; } = new();

    // Price History
    public List<ProductPriceHistoryDto> PriceHistory { get; set; } = new();
}

public class ProductVariantDto
{
    public int? Id { get; set; }
    public int? ColorId { get; set; }
    public string? ColorName { get; set; }
    public int? SizeId { get; set; }
    public string? SizeName { get; set; }
    public int? PackQuantityId { get; set; }
    public string? PackQuantityName { get; set; }
    public int StockQuantity { get; set; }
    
    [Required]
    [StringLength(50)]
    public string SKU { get; set; } = string.Empty;
    
    /// <summary>
    /// Variant price. If null or 0, defaults to product's BasePrice
    /// </summary>
    [Range(0, 999999.99)]
    public decimal? Price { get; set; }
}

public class ProductReviewManagementDto
{
    public int Id { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public decimal Rating { get; set; }
    public string Comment { get; set; } = string.Empty;
    public bool IsVisible { get; set; }
    public bool IsVerifiedPurchase { get; set; }
    public string? AdminReply { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public bool UserIsBanned { get; set; }
}

public class ProductImageCancelDto
{
    public List<string> TempFileNames { get; set; } = new();
}

public class SizeGuideDto
{
    public int? Id { get; set; }
    
    /// <summary>
    /// Path to size chart image (optional)
    /// </summary>
    [MaxLength(500)]
    public string? ChartImageUrl { get; set; }
    
    /// <summary>
    /// JSON-encoded size data for table display
    /// </summary>
    public string? SizeDataJson { get; set; }
    
    /// <summary>
    /// Measurement instructions text
    /// </summary>
    public string? MeasurementInstructions { get; set; }
    
    /// <summary>
    /// Translation key for measurement instructions
    /// </summary>
    [MaxLength(100)]
    public string? MeasurementInstructionsKey { get; set; }
    
    public bool IsActive { get; set; } = true;
}

public class ProductTranslationDto
{
    public int? Id { get; set; }
    
    [Required]
    [StringLength(10)]
    public string CultureCode { get; set; } = string.Empty;
    
    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [StringLength(250)]
    public string? Slug { get; set; }
    
    [StringLength(500)]
    public string? MetaDescription { get; set; }
    
    [StringLength(500)]
    public string? MetaKeywords { get; set; }
}

public class ProductPriceHistoryDto
{
    public int Id { get; set; }
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string? Reason { get; set; }
    public DateTime ChangedAt { get; set; }
    public string? ChangedBy { get; set; }
}

/// <summary>
/// Request model for auto-translation API
/// </summary>
public class TranslateContentRequest
{
    public string SourceLanguage { get; set; } = "en";
    public string TargetLanguage { get; set; } = "pl";
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeywords { get; set; }
}

/// <summary>
/// Response model for auto-translation API
/// </summary>
public class TranslateContentResponse
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Slug { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeywords { get; set; }
}
