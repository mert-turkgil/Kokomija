namespace Kokomija.Models.ViewModels
{
    /// <summary>
    /// DTO for commission settings display
    /// </summary>
    public class CommissionSettingsDto
    {
        public int Id { get; set; }
        public decimal DeveloperCommissionRate { get; set; }
        public decimal PlatformCommissionRate { get; set; }
        public decimal StripeCommissionRate { get; set; }
        public decimal StripeFixedFee { get; set; }
        public decimal MinimumPayoutAmount { get; set; }
        public string PayoutFrequency { get; set; } = string.Empty;
        public bool AutoPayoutEnabled { get; set; }
        public DateTime LastModifiedAt { get; set; }
        public string? LastModifiedBy { get; set; }
    }

    /// <summary>
    /// DTO for updating commission settings (ROOT only)
    /// </summary>
    public class UpdateCommissionSettingsDto
    {
        public decimal DeveloperCommissionRate { get; set; }
        public decimal PlatformCommissionRate { get; set; }
        public decimal StripeCommissionRate { get; set; }
        public decimal StripeFixedFee { get; set; }
        public decimal MinimumPayoutAmount { get; set; }
        public string PayoutFrequency { get; set; } = "Weekly";
        public bool AutoPayoutEnabled { get; set; }
    }

    /// <summary>
    /// Developer earnings summary for ROOT dashboard
    /// </summary>
    public class DeveloperEarningsSummaryDto
    {
        public decimal TodayEarnings { get; set; }
        public decimal WeekEarnings { get; set; }
        public decimal MonthEarnings { get; set; }
        public decimal YearEarnings { get; set; }
        public decimal AllTimeEarnings { get; set; }
        public decimal PendingPayout { get; set; }
        public DateTime? NextPayoutDate { get; set; }
        public int TotalOrders { get; set; }
        public decimal AverageCommissionPerOrder { get; set; }
    }

    /// <summary>
    /// Individual developer earning record
    /// </summary>
    public class DeveloperEarningDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public decimal GrossAmount { get; set; }
        public decimal StripeProcessingFee { get; set; }
        public decimal DeveloperCommission { get; set; }
        public decimal NetAmount { get; set; }
        public DateTime EarnedAt { get; set; }
        public string PayoutStatus { get; set; } = string.Empty;
        public string? PayoutId { get; set; }
        public DateTime? PayoutDate { get; set; }
    }

    /// <summary>
    /// Site closure/blocking DTO
    /// </summary>
    public class SiteClosureDto
    {
        public int Id { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }

    /// <summary>
    /// Create site closure request
    /// </summary>
    public class CreateSiteClosureDto
    {
        public string Reason { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// Commission settings view model
    /// </summary>
    public class CommissionSettingsViewModel
    {
        public CommissionSettingsDto? Settings { get; set; }
        public DeveloperEarningsSummaryDto? EarningsSummary { get; set; }
        public List<DeveloperEarningDto> RecentEarnings { get; set; } = new();
        public SiteClosureDto? ActiveSiteClosure { get; set; }
    }

    /// <summary>
    /// Developer earnings view model
    /// </summary>
    public class DeveloperEarningsViewModel
    {
        public DeveloperEarningsSummaryDto Summary { get; set; } = new();
        public List<DeveloperEarningDto> Earnings { get; set; } = new();
        public int TotalRecords { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
