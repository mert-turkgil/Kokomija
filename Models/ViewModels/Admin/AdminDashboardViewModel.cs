using Kokomija.Entity;

namespace Kokomija.Models.ViewModels.Admin
{
    public class AdminDashboardViewModel
    {
        // Overview Statistics
        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int TotalOrders { get; set; }
        public int PendingOrders { get; set; }
        public int CompletedOrders { get; set; }
        public int TotalProducts { get; set; }
        public int ActiveProducts { get; set; }
        public int OutOfStockProducts { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal MonthlyRevenue { get; set; }
        public decimal PlatformCommission { get; set; }
        public string Currency { get; set; } = "PLN";

        // Recent Activity
        public List<RecentOrderViewModel> RecentOrders { get; set; } = new();
        public List<RecentUserViewModel> RecentUsers { get; set; } = new();
        public List<LowStockProductViewModel> LowStockProducts { get; set; } = new();
        public List<RecentReviewViewModel> RecentReviews { get; set; } = new();

        // Blog Statistics
        public int TotalBlogs { get; set; }
        public int PublishedBlogs { get; set; }
        public int DraftBlogs { get; set; }

        // Additional Metrics
        public int NewsletterSubscribers { get; set; }
        public int ActiveCoupons { get; set; }
        public int PendingReviews { get; set; }

        // Charts Data (for future implementation)
        public Dictionary<string, decimal> MonthlyRevenueData { get; set; } = new();
        public Dictionary<string, int> MonthlyOrdersData { get; set; } = new();
    }

    public class RecentOrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string Currency { get; set; } = "PLN";
    }

    public class RecentUserViewModel
    {
        public string Id { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) 
            ? $"{FirstName} {LastName}" 
            : Email;
        public string VipTier { get; set; } = "None";
        public decimal TotalSpent { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
    }

    public class LowStockProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TotalStock { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }

    public class RecentReviewViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
