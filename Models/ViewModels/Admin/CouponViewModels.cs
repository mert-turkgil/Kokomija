using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Kokomija.Models.ViewModels.Admin
{
    // ==================== Coupon Management DTOs ====================

    /// <summary>
    /// Main ViewModel for Coupon Management page
    /// </summary>
    public class CouponManagementViewModel
    {
        // Statistics
        public int TotalCoupons { get; set; }
        public int ActiveCoupons { get; set; }
        public int ExpiredCoupons { get; set; }
        public int BirthdayCoupons { get; set; }
        public int NewUserCoupons { get; set; }
        public int CategoryCoupons { get; set; }
        public int VipCoupons { get; set; }
        public decimal TotalDiscountsGiven { get; set; }
        public string Currency { get; set; } = "PLN";

        // Coupon List
        public List<CouponListItemDto> Coupons { get; set; } = new();

        // Dropdowns for filters and creation
        public List<SelectListItem> Categories { get; set; } = new();
        public List<SelectListItem> Products { get; set; } = new();
        public List<SelectListItem> VipTiers { get; set; } = new();
        public List<SelectListItem> CouponTypes { get; set; } = new();
    }

    /// <summary>
    /// DTO for displaying coupon in a list
    /// </summary>
    public class CouponListItemDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string DiscountType { get; set; } = "percentage";
        public decimal DiscountValue { get; set; }
        public string CouponType { get; set; } = "general"; // general, birthday, new_user, vip, category, product
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? VipTierRequired { get; set; }
        public int? UsageLimit { get; set; }
        public int? UsageLimitPerUser { get; set; }
        public int UsageCount { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool IsActive { get; set; }
        public bool IsExpired => ValidUntil.HasValue && ValidUntil.Value < DateTime.UtcNow;
        public bool HasStripeSync { get; set; }
        public string? StripeCouponId { get; set; }
        public string? StripePromotionCodeId { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// DTO for creating a new coupon
    /// </summary>
    public class CreateCouponDto
    {
        [Required(ErrorMessage = "Coupon code is required")]
        [MaxLength(50)]
        [Display(Name = "Coupon Code")]
        public string Code { get; set; } = string.Empty;

        [MaxLength(200)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Discount type is required")]
        [Display(Name = "Discount Type")]
        public string DiscountType { get; set; } = "percentage"; // percentage, fixed_amount

        [Required(ErrorMessage = "Discount value is required")]
        [Range(0.01, 100000, ErrorMessage = "Discount value must be greater than 0")]
        [Display(Name = "Discount Value")]
        public decimal DiscountValue { get; set; }

        [Display(Name = "Coupon Type")]
        public string CouponType { get; set; } = "general"; // general, birthday, new_user, vip, category, product

        [Range(0, double.MaxValue)]
        [Display(Name = "Minimum Order Amount")]
        public decimal? MinimumOrderAmount { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Maximum Discount Amount")]
        public decimal? MaximumDiscountAmount { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Total Usage Limit")]
        public int? UsageLimit { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Usage Limit Per User")]
        public int? UsageLimitPerUser { get; set; }

        [Display(Name = "Valid From")]
        public DateTime? ValidFrom { get; set; }

        [Display(Name = "Valid Until")]
        public DateTime? ValidUntil { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        // Target restrictions
        [Display(Name = "Specific User (Optional)")]
        public string? UserId { get; set; }

        [Display(Name = "Category Restriction")]
        public int? CategoryId { get; set; }

        [Display(Name = "Product Restriction")]
        public int? ProductId { get; set; }

        [Display(Name = "VIP Tier Required")]
        public string? VipTierRequired { get; set; }

        // Birthday coupon specific
        [Display(Name = "Days Before Birthday")]
        public int? DaysBeforeBirthday { get; set; } = 7;

        [Display(Name = "Days After Birthday")]
        public int? DaysAfterBirthday { get; set; } = 7;

        // New user specific
        [Display(Name = "Account Age (Days)")]
        public int? AccountAgeDays { get; set; } = 30;

        // Auto-generate options
        [Display(Name = "Auto-generate Unique Codes")]
        public bool AutoGenerateCodes { get; set; } = false;

        [Display(Name = "Number of Codes to Generate")]
        public int? NumberOfCodesToGenerate { get; set; }

        [Display(Name = "Code Prefix")]
        public string? CodePrefix { get; set; }

        // Stripe synchronization
        [Display(Name = "Sync with Stripe")]
        public bool SyncWithStripe { get; set; } = true;
    }

    /// <summary>
    /// DTO for updating an existing coupon
    /// </summary>
    public class UpdateCouponDto
    {
        public int Id { get; set; }

        [MaxLength(200)]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Minimum Order Amount")]
        public decimal? MinimumOrderAmount { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Maximum Discount Amount")]
        public decimal? MaximumDiscountAmount { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Total Usage Limit")]
        public int? UsageLimit { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Usage Limit Per User")]
        public int? UsageLimitPerUser { get; set; }

        [Display(Name = "Valid Until")]
        public DateTime? ValidUntil { get; set; }

        [Display(Name = "Active")]
        public bool IsActive { get; set; }

        // Target restrictions
        [Display(Name = "Category Restriction")]
        public int? CategoryId { get; set; }

        [Display(Name = "Product Restriction")]
        public int? ProductId { get; set; }

        [Display(Name = "VIP Tier Required")]
        public string? VipTierRequired { get; set; }
    }

    /// <summary>
    /// DTO for coupon details view
    /// </summary>
    public class CouponDetailsViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string DiscountType { get; set; } = "percentage";
        public decimal DiscountValue { get; set; }
        public string CouponType { get; set; } = "general";
        public decimal? MinimumOrderAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public int? UsageLimit { get; set; }
        public int UsageCount { get; set; }
        public int? UsageLimitPerUser { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool IsActive { get; set; }
        public string? StripeCouponId { get; set; }
        public string? StripePromotionCodeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Related data
        public string? UserEmail { get; set; }
        public string? CategoryName { get; set; }
        public string? ProductName { get; set; }
        public string? VipTierRequired { get; set; }

        // Extended properties
        public int? DaysBeforeBirthday { get; set; }
        public int? DaysAfterBirthday { get; set; }
        public int? AccountAgeDays { get; set; }

        // Usage statistics
        public decimal TotalDiscountAmount { get; set; }
        public List<CouponUsageDto> RecentUsages { get; set; } = new();

        // Status
        public bool IsExpired => ValidUntil.HasValue && ValidUntil.Value < DateTime.UtcNow;
        public bool IsFullyUsed => UsageLimit.HasValue && UsageCount >= UsageLimit.Value;
        public string Status => !IsActive ? "Inactive" : IsExpired ? "Expired" : IsFullyUsed ? "Fully Used" : "Active";
    }

    /// <summary>
    /// DTO for coupon usage display
    /// </summary>
    public class CouponUsageDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string? UserEmail { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime UsedAt { get; set; }
    }

    // ==================== Birthday Coupon DTOs ====================

    /// <summary>
    /// DTO for birthday coupon settings
    /// </summary>
    public class BirthdayCouponSettingsDto
    {
        [Display(Name = "Enable Birthday Coupons")]
        public bool IsEnabled { get; set; } = true;

        [Required]
        [Display(Name = "Discount Type")]
        public string DiscountType { get; set; } = "percentage";

        [Required]
        [Range(0.01, 100)]
        [Display(Name = "Discount Value")]
        public decimal DiscountValue { get; set; } = 10;

        [Range(1, 30)]
        [Display(Name = "Days Before Birthday")]
        public int DaysBeforeBirthday { get; set; } = 7;

        [Range(1, 30)]
        [Display(Name = "Days After Birthday")]
        public int DaysAfterBirthday { get; set; } = 7;

        [Display(Name = "Minimum Order Amount")]
        public decimal? MinimumOrderAmount { get; set; }

        [Display(Name = "Require VIP Status")]
        public bool RequireVipStatus { get; set; } = false;

        [Display(Name = "Minimum VIP Tier")]
        public string? MinimumVipTier { get; set; }

        [Display(Name = "Auto-send Email")]
        public bool AutoSendEmail { get; set; } = true;

        [Display(Name = "Email Template")]
        public string? EmailTemplateKey { get; set; }
    }

    // ==================== VIP Tier Coupon DTOs ====================

    /// <summary>
    /// DTO for VIP tier benefits/coupons
    /// </summary>
    public class VipTierCouponDto
    {
        public string VipTier { get; set; } = "Bronze";
        public string DiscountType { get; set; } = "percentage";
        public decimal DiscountValue { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ApplicableCategories { get; set; } // JSON array
        public int? UsageLimitPerMonth { get; set; }
    }

    // ==================== Auto-Coupon Rules ====================

    /// <summary>
    /// DTO for automatic coupon generation rules
    /// </summary>
    public class AutoCouponRuleDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Rule Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Trigger Type")]
        public string TriggerType { get; set; } = "birthday"; // birthday, new_user, first_purchase, vip_upgrade, abandoned_cart

        [Display(Name = "Discount Type")]
        public string DiscountType { get; set; } = "percentage";

        [Display(Name = "Discount Value")]
        public decimal DiscountValue { get; set; }

        [Display(Name = "Validity Days")]
        public int ValidityDays { get; set; } = 30;

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Sync with Stripe")]
        public bool SyncWithStripe { get; set; } = true;
    }

    // ==================== Bulk Coupon Generation ====================

    /// <summary>
    /// DTO for bulk coupon generation
    /// </summary>
    public class BulkCouponGenerationDto
    {
        [Required]
        [Display(Name = "Number of Coupons")]
        [Range(1, 10000)]
        public int Count { get; set; } = 100;

        [Required]
        [MaxLength(20)]
        [Display(Name = "Code Prefix")]
        public string Prefix { get; set; } = "PROMO";

        [Required]
        [Display(Name = "Code Length (excluding prefix)")]
        [Range(4, 20)]
        public int CodeLength { get; set; } = 8;

        [Required]
        [Display(Name = "Discount Type")]
        public string DiscountType { get; set; } = "percentage";

        [Required]
        [Display(Name = "Discount Value")]
        public decimal DiscountValue { get; set; }

        [Display(Name = "Valid From")]
        public DateTime? ValidFrom { get; set; }

        [Display(Name = "Valid Until")]
        public DateTime? ValidUntil { get; set; }

        [Display(Name = "Usage Limit Per Code")]
        public int UsageLimitPerCode { get; set; } = 1;

        [Display(Name = "Category Restriction")]
        public int? CategoryId { get; set; }

        [Display(Name = "Sync with Stripe")]
        public bool SyncWithStripe { get; set; } = true;
    }

    /// <summary>
    /// Result of bulk coupon generation
    /// </summary>
    public class BulkCouponGenerationResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public int GeneratedCount { get; set; }
        public int FailedCount { get; set; }
        public List<string> GeneratedCodes { get; set; } = new();
        public List<string> Errors { get; set; } = new();
    }
}
