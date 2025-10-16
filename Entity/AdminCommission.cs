using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Tracks commission earned by admin (you) for each order
    /// </summary>
    public class AdminCommission
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Related order ID
        /// </summary>
        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order? Order { get; set; }

        /// <summary>
        /// Related order item ID (commission per product)
        /// </summary>
        public int? OrderItemId { get; set; }

        [ForeignKey("OrderItemId")]
        public OrderItem? OrderItem { get; set; }

        /// <summary>
        /// Product that generated commission
        /// </summary>
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        /// <summary>
        /// Product sale price
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Quantity sold
        /// </summary>
        [Required]
        public int Quantity { get; set; } = 1;

        /// <summary>
        /// Subtotal (ProductPrice * Quantity)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; }

        /// <summary>
        /// Platform commission rate (default 1% = 0.01)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,4)")]
        public decimal PlatformCommissionRate { get; set; } = 0.01M; // 1%

        /// <summary>
        /// Platform commission amount (your earnings)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PlatformCommissionAmount { get; set; }

        /// <summary>
        /// Stripe processing fee rate (2.7% for Poland)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,4)")]
        public decimal StripeProcessingFeeRate { get; set; } = 0.027M; // 2.7%

        /// <summary>
        /// Stripe fixed fee per transaction (1 PLN for Poland, $0.30 for international)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal StripeFixedFee { get; set; } = 1.00M; // 1 PLN

        /// <summary>
        /// Total Stripe fees (percentage + fixed)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalStripeFees { get; set; }

        /// <summary>
        /// Total deductions (Platform + Stripe)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalDeductions { get; set; }

        /// <summary>
        /// Currency code (PLN, EUR, USD, etc.)
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "PLN";

        /// <summary>
        /// Commission status (pending, paid, cancelled)
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "pending";

        /// <summary>
        /// When commission was calculated
        /// </summary>
        public DateTime CalculatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// When commission was paid (if applicable)
        /// </summary>
        public DateTime? PaidAt { get; set; }

        /// <summary>
        /// Notes or reason for cancellation
        /// </summary>
        public string? Notes { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
