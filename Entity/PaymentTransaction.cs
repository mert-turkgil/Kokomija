using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public enum TransactionType
    {
        Payment,
        Refund,
        Payout,
        Commission
    }

    public enum TransactionStatus
    {
        Pending,
        Processing,
        Succeeded,
        Failed,
        Cancelled
    }

    public class PaymentTransaction
    {
        [Key]
        public int Id { get; set; }

        public int? OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order? Order { get; set; }

        public int? ReturnRequestId { get; set; }

        [ForeignKey(nameof(ReturnRequestId))]
        public ReturnRequest? ReturnRequest { get; set; }

        [Required]
        public TransactionType Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        [MaxLength(10)]
        public string Currency { get; set; } = "TRY";

        [MaxLength(100)]
        public string? StripePaymentIntentId { get; set; }

        [MaxLength(100)]
        public string? StripeRefundId { get; set; }

        [MaxLength(100)]
        public string? StripePayoutId { get; set; }

        [Required]
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        public string? FailureReason { get; set; }

        public DateTime? ProcessedAt { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
