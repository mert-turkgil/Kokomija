using Kokomija.Entity;

namespace Kokomija.Models.ViewModels.Admin
{
    /// <summary>
    /// Comprehensive financial dashboard view model
    /// </summary>
    public class FinancialDashboardViewModel
    {
        // ===== SUMMARY STATISTICS =====
        public FinancialSummary Summary { get; set; } = new();
        
        // ===== PERIOD-BASED DATA =====
        public string SelectedPeriod { get; set; } = "month"; // day, week, month, year, all
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        
        // ===== CHART DATA =====
        public List<RevenueChartData> RevenueChart { get; set; } = new();
        public List<DeductionBreakdown> DeductionChart { get; set; } = new();
        
        // ===== PER-PRODUCT BREAKDOWN =====
        public List<ProductFinancialBreakdown> ProductBreakdowns { get; set; } = new();
        
        // ===== TRANSACTIONS LIST =====
        public List<FinancialTransaction> Transactions { get; set; } = new();
        public int TotalTransactions { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalPages => (int)Math.Ceiling((double)TotalTransactions / PageSize);
        
        // ===== COMMISSION SETTINGS =====
        public CommissionSettings? CommissionSettings { get; set; }
        
        // ===== DEVELOPER COMMISSION REQUESTS =====
        public List<DeveloperCommissionRequestDto> PendingCommissionRequests { get; set; } = new();
        
        // ===== TAX INFORMATION =====
        public List<TaxSummary> TaxBreakdown { get; set; } = new();
    }

    public class FinancialSummary
    {
        // Gross Revenue (Total Sales)
        public decimal GrossRevenue { get; set; }
        public decimal GrossRevenueThisMonth { get; set; }
        public decimal GrossRevenueToday { get; set; }
        public decimal GrossRevenueGrowth { get; set; } // % change from previous period
        
        // Deductions
        public decimal TotalStripeFees { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal TotalDeveloperCommission { get; set; }
        public decimal TotalPlatformCommission { get; set; }
        public decimal TotalRefunds { get; set; }
        public decimal TotalDiscounts { get; set; }
        
        // Net Amounts
        public decimal NetRevenue { get; set; } // After all deductions
        public decimal NetRevenueThisMonth { get; set; }
        
        // Personal Earnings (Admin's Take-Home)
        public decimal PersonalEarnings { get; set; }
        public decimal PersonalEarningsThisMonth { get; set; }
        public decimal PersonalEarningsToday { get; set; }
        
        // Statistics
        public int TotalOrders { get; set; }
        public int TotalProductsSold { get; set; }
        public decimal AverageOrderValue { get; set; }
        public decimal EffectiveTaxRate { get; set; }
        
        // Developer Stats
        public decimal DeveloperCommissionRate { get; set; }
        public decimal TotalPaidToDeveloper { get; set; }
        public decimal PendingDeveloperPayout { get; set; }
        
        // Currency
        public string Currency { get; set; } = "PLN";
    }

    public class RevenueChartData
    {
        public string Label { get; set; } = string.Empty; // Date/Period label
        public decimal GrossRevenue { get; set; }
        public decimal NetRevenue { get; set; }
        public decimal PersonalEarnings { get; set; }
        public int OrderCount { get; set; }
    }

    public class DeductionBreakdown
    {
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }
        public string Color { get; set; } = "#000000";
    }

    public class ProductFinancialBreakdown
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductImage { get; set; }
        public int QuantitySold { get; set; }
        public decimal GrossSales { get; set; }
        public decimal StripeFees { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal DeveloperCommission { get; set; }
        public decimal PlatformCommission { get; set; }
        public decimal NetRevenue { get; set; }
        public decimal ProfitMargin { get; set; }
        public decimal AveragePrice { get; set; }
    }

    public class FinancialTransaction
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        
        public decimal GrossAmount { get; set; }
        public decimal SubtotalAmount { get; set; }
        public decimal ShippingAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal StripeFee { get; set; }
        public decimal DeveloperCommission { get; set; }
        public decimal PlatformCommission { get; set; }
        public decimal NetAmount { get; set; }
        
        public string PaymentStatus { get; set; } = string.Empty;
        public string OrderStatus { get; set; } = string.Empty;
        public string Currency { get; set; } = "PLN";
        
        public List<TransactionItem> Items { get; set; } = new();
    }

    public class TransactionItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
    }

    public class TaxSummary
    {
        public string TaxName { get; set; } = string.Empty;
        public decimal Rate { get; set; }
        public string Country { get; set; } = string.Empty;
        public decimal TaxableAmount { get; set; }
        public decimal TaxCollected { get; set; }
        public int TransactionCount { get; set; }
    }

    public class DeveloperCommissionRequestDto
    {
        public int Id { get; set; }
        public string DeveloperName { get; set; } = string.Empty;
        public string DeveloperEmail { get; set; } = string.Empty;
        public decimal CurrentRate { get; set; }
        public decimal RequestedRate { get; set; }
        public string Reason { get; set; } = string.Empty;
        public CommissionRequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? AdminResponse { get; set; }
    }

    /// <summary>
    /// For Excel export
    /// </summary>
    public class FinancialExportData
    {
        public DateTime ExportDate { get; set; } = DateTime.UtcNow;
        public string ReportPeriod { get; set; } = string.Empty;
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }
        
        public FinancialSummary Summary { get; set; } = new();
        public List<FinancialTransaction> Transactions { get; set; } = new();
        public List<ProductFinancialBreakdown> ProductBreakdowns { get; set; } = new();
        public List<TaxSummary> TaxSummary { get; set; } = new();
    }
}
