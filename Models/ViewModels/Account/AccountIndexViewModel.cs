namespace Kokomija.Models.ViewModels.Account
{
    public class AccountIndexViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public string? StripeCustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public bool IsAdmin { get; set; }
        
        // VIP Status
        public VIPStatusViewModel VIPStatus { get; set; } = new VIPStatusViewModel();
        
        // Recent Orders
        public IEnumerable<OrderViewModel> RecentOrders { get; set; } = new List<OrderViewModel>();
        
        // Statistics
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public decimal TotalSpent { get; set; }
        public int WishlistCount { get; set; }
        public int CartItemsCount { get; set; }
    }
    
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public int ItemCount { get; set; }
        public bool CanCancel { get; set; }
        public bool CanReturn { get; set; }
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
}
