using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public enum PayoutStatus
    {
        Pending,
        Processed,
        Failed
    }

    public class DeveloperEarnings
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;

        /// <summary>
        /// Total order amount before any fees
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal GrossAmount { get; set; }

        /// <summary>
        /// Stripe's processing fee
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal StripeProcessingFee { get; set; }

        /// <summary>
        /// Root developer's commission
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DeveloperCommission { get; set; }

        /// <summary>
        /// Amount after all fees (for merchant/admin)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NetAmount { get; set; }

        [Required]
        public DateTime EarnedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public PayoutStatus PayoutStatus { get; set; } = PayoutStatus.Pending;

        [MaxLength(100)]
        public string? PayoutId { get; set; } // Stripe payout ID

        public DateTime? PayoutDate { get; set; }
    }
}
