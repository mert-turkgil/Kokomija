using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Business profile for B2B customers with verified Polish NIP
    /// </summary>
    public class BusinessProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        /// <summary>
        /// Polish Tax Identification Number (NIP) - 10 digits
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string NIP { get; set; } = string.Empty;

        /// <summary>
        /// Company name from government registry
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// REGON number (9 or 14 digits)
        /// </summary>
        [MaxLength(14)]
        public string? REGON { get; set; }

        /// <summary>
        /// KRS number if applicable
        /// </summary>
        [MaxLength(20)]
        public string? KRS { get; set; }

        /// <summary>
        /// VAT status: Czynny, Zwolniony, Niezarejestrowany
        /// </summary>
        [MaxLength(50)]
        public string? VATStatus { get; set; }

        /// <summary>
        /// Residence/registered address from registry
        /// </summary>
        [MaxLength(500)]
        public string? ResidenceAddress { get; set; }

        /// <summary>
        /// Working/business address from registry
        /// </summary>
        [MaxLength(500)]
        public string? WorkingAddress { get; set; }

        /// <summary>
        /// Date of VAT registration
        /// </summary>
        public DateTime? RegistrationLegalDate { get; set; }

        /// <summary>
        /// Whether the business profile is verified and active
        /// </summary>
        public bool IsVerified { get; set; } = false;

        /// <summary>
        /// Whether the user has switched to business mode for shopping
        /// </summary>
        public bool IsBusinessModeActive { get; set; } = false;

        /// <summary>
        /// When the NIP was verified with government API
        /// </summary>
        public DateTime? VerifiedAt { get; set; }

        /// <summary>
        /// Last verification attempt timestamp
        /// </summary>
        public DateTime? LastVerificationAttempt { get; set; }

        /// <summary>
        /// Number of verification attempts (for rate limiting)
        /// </summary>
        public int VerificationAttempts { get; set; } = 0;

        /// <summary>
        /// Request ID from the government API (for audit purposes)
        /// </summary>
        [MaxLength(100)]
        public string? GovernmentRequestId { get; set; }

        /// <summary>
        /// Raw JSON response from government API (for debugging/audit)
        /// </summary>
        public string? RawApiResponse { get; set; }

        /// <summary>
        /// Company phone number (provided by user)
        /// </summary>
        [MaxLength(30)]
        public string? Phone { get; set; }

        /// <summary>
        /// Company email for invoices (provided by user)
        /// </summary>
        [MaxLength(200)]
        public string? CompanyEmail { get; set; }

        /// <summary>
        /// Contact person name (provided by user)
        /// </summary>
        [MaxLength(200)]
        public string? ContactPerson { get; set; }

        /// <summary>
        /// Contact person's position/role (provided by user)
        /// </summary>
        [MaxLength(100)]
        public string? Position { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
