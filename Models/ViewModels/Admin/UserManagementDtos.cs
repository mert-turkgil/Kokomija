using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels.Admin
{
    public class UserManagementViewModel
    {
        public List<UserListItemDto> Users { get; set; } = new();
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int BannedUsers { get; set; }
        public int NewUsersThisMonth { get; set; }
    }

    public class UserListItemDto
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public bool IsBanned { get; set; }
        public DateTimeOffset? BannedUntil { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        public int TotalOrders { get; set; }
        public int TotalReviews { get; set; }
        public bool IsRoot { get; set; } = false;
        
        public string FullName => !string.IsNullOrEmpty(FirstName) || !string.IsNullOrEmpty(LastName) 
            ? $"{FirstName} {LastName}".Trim() 
            : Email;
    }

    public class UserEditDto
    {
        public string Id { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string? FirstName { get; set; }
        
        [StringLength(100)]
        public string? LastName { get; set; }
        
        [Phone]
        public string? PhoneNumber { get; set; }
        
        public bool EmailConfirmed { get; set; }
        public bool IsBanned { get; set; }
        public DateTimeOffset? BannedUntil { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLogin { get; set; }
        
        public List<UserReviewDto> Reviews { get; set; } = new();
        public List<UserOrderDto> Orders { get; set; } = new();
        public List<UserWishlistDto> Wishlist { get; set; } = new();
        public List<UserCouponDto> UsedCoupons { get; set; } = new();
        public List<UserCouponDto> AvailableCoupons { get; set; } = new();
    }

    public class UserReviewDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? AdminReply { get; set; }
        public DateTime? AdminReplyAt { get; set; }
    }

    public class UserOrderDto
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ItemCount { get; set; }
        public string? CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
    }

    public class UserWishlistDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? FeaturedImage { get; set; }
        public bool IsActive { get; set; }
        public bool InStock { get; set; }
        public DateTime AddedAt { get; set; }
    }

    public class UserCouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string DiscountType { get; set; } = string.Empty;
        public decimal DiscountValue { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool IsActive { get; set; }
        public int? UsageLimit { get; set; }
        public int UsageCount { get; set; }
        public int? UsageLimitPerUser { get; set; }
        public int UserUsageCount { get; set; }
        public DateTime? LastUsedAt { get; set; }
        
        // Restrictions
        public bool IsUserSpecific { get; set; }
        public string? RestrictedToProduct { get; set; }
        public string? RestrictedToCategory { get; set; }
    }

    public class CreateUserCouponDto
    {
        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Code { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public string DiscountType { get; set; } = "percentage"; // "percentage" or "fixed"

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal DiscountValue { get; set; }

        public decimal? MinimumOrderAmount { get; set; }
        public decimal? MaximumDiscountAmount { get; set; }
        public DateTime? ValidFrom { get; set; }
        public DateTime? ValidUntil { get; set; }
        public int? UsageLimit { get; set; }
        public int? UsageLimitPerUser { get; set; }
        
        // Restrictions
        public int? ProductId { get; set; }
        public int? CategoryId { get; set; }
    }
}
