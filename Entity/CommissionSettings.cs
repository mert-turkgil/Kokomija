using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public enum PayoutFrequency
    {
        Daily,
        Weekly,
        BiWeekly,
        Monthly
    }

    public class CommissionSettings
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Root developer commission percentage (only root can modify)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal DeveloperCommissionRate { get; set; } = 0.00m;

        /// <summary>
        /// Platform/marketplace commission percentage
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal PlatformCommissionRate { get; set; } = 0.00m;

        /// <summary>
        /// Stripe's fee percentage (for reference/calculation)
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal StripeCommissionRate { get; set; } = 2.9m; // Stripe default

        /// <summary>
        /// Stripe's fixed fee per transaction
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal StripeFixedFee { get; set; } = 0.30m; // Stripe default

        /// <summary>
        /// Minimum amount required for automatic payout
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinimumPayoutAmount { get; set; } = 100.00m;

        /// <summary>
        /// How often automatic payouts should occur
        /// </summary>
        [Required]
        public PayoutFrequency PayoutFrequency { get; set; } = PayoutFrequency.Weekly;

        /// <summary>
        /// Enable or disable automatic payouts
        /// </summary>
        [Required]
        public bool AutoPayoutEnabled { get; set; } = false;

        [Required]
        public string LastModifiedBy { get; set; } = string.Empty;

        [ForeignKey(nameof(LastModifiedBy))]
        public ApplicationUser Modifier { get; set; } = null!;

        [Required]
        public DateTime LastModifiedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
