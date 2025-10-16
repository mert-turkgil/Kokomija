using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Represents a saved payment method (credit/debit card) for a user
    /// </summary>
    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Stripe Payment Method ID (pm_xxx)
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string StripePaymentMethodId { get; set; } = string.Empty;

        /// <summary>
        /// User who owns this payment method
        /// </summary>
        [Required]
        public string UserId { get; set; } = string.Empty;

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        /// <summary>
        /// Card brand (visa, mastercard, amex, etc.)
        /// </summary>
        [MaxLength(50)]
        public string? CardBrand { get; set; }

        /// <summary>
        /// Last 4 digits of the card
        /// </summary>
        [MaxLength(4)]
        public string? Last4 { get; set; }

        /// <summary>
        /// Card expiration month (1-12)
        /// </summary>
        public int? ExpMonth { get; set; }

        /// <summary>
        /// Card expiration year (4 digits)
        /// </summary>
        public int? ExpYear { get; set; }

        /// <summary>
        /// Cardholder name
        /// </summary>
        [MaxLength(200)]
        public string? CardholderName { get; set; }

        /// <summary>
        /// Billing address postal code
        /// </summary>
        [MaxLength(20)]
        public string? BillingPostalCode { get; set; }

        /// <summary>
        /// Billing address country
        /// </summary>
        [MaxLength(100)]
        public string? BillingCountry { get; set; }

        /// <summary>
        /// Is this the default payment method
        /// </summary>
        public bool IsDefault { get; set; } = false;

        /// <summary>
        /// Is this payment method active (can be deactivated without deletion)
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Nickname for the card (e.g., "Personal Visa", "Work Mastercard")
        /// </summary>
        [MaxLength(100)]
        public string? Nickname { get; set; }

        /// <summary>
        /// Date the payment method was added
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Last time the payment method was used
        /// </summary>
        public DateTime? LastUsedAt { get; set; }

        /// <summary>
        /// Soft delete flag
        /// </summary>
        public bool IsDeleted { get; set; } = false;
    }
}
