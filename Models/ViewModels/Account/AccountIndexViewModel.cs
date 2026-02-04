namespace Kokomija.Models.ViewModels.Account
{
    public class AccountIndexViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? StripeCustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public bool IsAdmin { get; set; }
        
        // Default Shipping Address
        public string? DefaultAddress { get; set; }
        public string? DefaultCity { get; set; }
        public string? DefaultPostalCode { get; set; }
        public string? DefaultCountry { get; set; }
        
        // VIP Status
        public VIPStatusViewModel VIPStatus { get; set; } = new VIPStatusViewModel();
        
        // Business Profile
        public BusinessProfileViewModel? BusinessProfile { get; set; }
        
        // Recent Orders
        public IEnumerable<OrderViewModel> RecentOrders { get; set; } = new List<OrderViewModel>();
        
        // Return Requests
        public IEnumerable<ReturnRequestSummaryViewModel> RecentReturnRequests { get; set; } = new List<ReturnRequestSummaryViewModel>();
        
        // Statistics
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public int WishlistCount { get; set; }
        public int CartItemsCount { get; set; }
        public int PendingReturnRequests { get; set; }
        
        // Connected External Logins (Google, Facebook, etc.)
        public IList<ExternalLoginViewModel> ExternalLogins { get; set; } = new List<ExternalLoginViewModel>();
        public IList<string> AvailableProviders { get; set; } = new List<string>();
        public bool HasPassword { get; set; } = true;
        
        // Coupons
        public IList<AccountCouponViewModel> AvailableCoupons { get; set; } = new List<AccountCouponViewModel>();
        public IList<UsedCouponViewModel> UsedCoupons { get; set; } = new List<UsedCouponViewModel>();
    }
    
    public class AccountCouponViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string DiscountType { get; set; } = string.Empty; // percentage, fixed_amount
        public decimal DiscountValue { get; set; }
        public decimal? MinimumOrderAmount { get; set; }
        public DateTime? ValidUntil { get; set; }
        public bool IsNew { get; set; }
    }
    
    public class UsedCouponViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal DiscountAmount { get; set; }
        public DateTime UsedAt { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
    }
    
    public class ExternalLoginViewModel
    {
        public string LoginProvider { get; set; } = string.Empty;
        public string ProviderDisplayName { get; set; } = string.Empty;
        public string ProviderKey { get; set; } = string.Empty;
    }
    
    public class ReturnRequestSummaryViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public decimal? RefundedAmount { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }
    
    public class BusinessProfileViewModel
    {
        public int Id { get; set; }
        public string NIP { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string? REGON { get; set; }
        public string? KRS { get; set; }
        public string? VATStatus { get; set; }
        public string? ResidenceAddress { get; set; }
        public string? WorkingAddress { get; set; }
        public bool IsVerified { get; set; }
        public bool IsBusinessModeActive { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    
    public class NIPVerificationRequestModel
    {
        public string NIP { get; set; } = string.Empty;
    }
    
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SubtotalAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public string Currency { get; set; } = "pln";
        public string? SessionStatus { get; set; }
        public string? CustomerCountry { get; set; }
        public int ItemCount { get; set; }
        public bool CanCancel { get; set; }
        public bool CanReturn { get; set; }
        
        // Shipping details
        public string? ShippingMethod { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        
        // Billing details
        public string? ShippingAddress { get; set; }
        public string? ShippingCity { get; set; }
        public string? ShippingPostalCode { get; set; }
        public string? ShippingCountry { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhone { get; set; }
        
        // Payment details
        public string? PaymentMethod { get; set; }
        public string? StripePaymentIntentId { get; set; }
        public DateTime? PaidAt { get; set; }
        
        // Coupon
        public string? CouponCode { get; set; }
        
        public IEnumerable<OrderItemViewModel> Items { get; set; } = new List<OrderItemViewModel>();
    }
    
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImage { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
    
    public class VIPStatusViewModel
    {
        public string TierName { get; set; } = "Bronze"; // Bronze, Silver, Gold, Platinum
        public int TierLevel { get; set; } = 1; // 1-4
        public decimal CurrentSpending { get; set; }
        public decimal NextTierThreshold { get; set; }
        public int ProgressPercentage { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool HasFreeShipping { get; set; }
        public bool HasEarlyAccess { get; set; }
        public bool HasBirthdayGift { get; set; }
        public int AvailableCoupons { get; set; }
        public IEnumerable<VIPBenefitViewModel> Benefits { get; set; } = new List<VIPBenefitViewModel>();
    }
    
    public class VIPBenefitViewModel
    {
        public string Icon { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsUnlocked { get; set; }
    }
    
    public class ReturnRequestDetailsViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string? Description { get; set; }
        public decimal RequestedAmount { get; set; }
        public decimal? RefundedAmount { get; set; }
        public string? RefundTransactionId { get; set; }
        public DateTime RequestedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? ReviewedBy { get; set; }
        public string? ReviewNotes { get; set; }
        public DateTime? CompletedAt { get; set; }
        
        // Order Item details
        public OrderItemViewModel? OrderItem { get; set; }
        
        // Status History
        public List<ReturnStatusHistoryViewModel> StatusHistory { get; set; } = new List<ReturnStatusHistoryViewModel>();
        
        // Images uploaded with the request
        public List<string> Images { get; set; } = new List<string>();
    }
    
    public class ReturnStatusHistoryViewModel
    {
        public int Id { get; set; }
        public string? PreviousStatus { get; set; }
        public string NewStatus { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; }
        public string? ChangedBy { get; set; }
        public string? Notes { get; set; }
    }
}
