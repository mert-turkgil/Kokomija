using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Aggregated admin earnings summary
    /// </summary>
    public class AdminEarnings
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Period type (daily, weekly, monthly, yearly, all-time)
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string PeriodType { get; set; } = "all-time";

        /// <summary>
        /// Period start date
        /// </summary>
        public DateTime? PeriodStart { get; set; }

        /// <summary>
        /// Period end date
        /// </summary>
        public DateTime? PeriodEnd { get; set; }

        /// <summary>
        /// Total number of orders
        /// </summary>
        public int TotalOrders { get; set; } = 0;

        /// <summary>
        /// Total products sold
        /// </summary>
        public int TotalProductsSold { get; set; } = 0;

        /// <summary>
        /// Total sales revenue
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalSalesRevenue { get; set; } = 0;

        /// <summary>
        /// Total platform commission earned (1%)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPlatformCommission { get; set; } = 0;

        /// <summary>
        /// Total Stripe fees deducted
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalStripeFees { get; set; } = 0;

        /// <summary>
        /// Total developer commission deducted (root developer's cut)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDeveloperCommission { get; set; } = 0;

        /// <summary>
        /// Total deductions (Platform + Stripe + Developer)
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDeductions { get; set; } = 0;

        /// <summary>
        /// Net revenue after all deductions
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetRevenue { get; set; } = 0;

        /// <summary>
        /// Average order value
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal AverageOrderValue { get; set; } = 0;

        /// <summary>
        /// Average commission per order
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal AverageCommissionPerOrder { get; set; } = 0;

        /// <summary>
        /// Current platform commission rate
        /// </summary>
        [Column(TypeName = "decimal(5,4)")]
        public decimal CurrentCommissionRate { get; set; } = 0.01M; // 1%

        /// <summary>
        /// Currency
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "PLN";

        /// <summary>
        /// Last calculated date
        /// </summary>
        public DateTime LastCalculatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Updated date
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
