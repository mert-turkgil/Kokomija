using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Business profile for B2B customers with verified Polish NIP.
    /// 
    /// DATA PRIORITY:
    ///   PRIMARY (Government API - wl-api.mf.gov.pl):
    ///     NIP, CompanyName, REGON, KRS, VATStatus, ResidenceAddress, WorkingAddress, RegistrationLegalDate
    ///     → These fields are ONLY written by the government API during verification.
    ///     → They should never be manually overwritten except through re-verification.
    ///   
    ///   SECONDARY (User / Admin provided):
    ///     Phone, CompanyEmail, ContactPerson, Position
    ///     → These fields are provided by the user or admin.
    ///     → They are preserved during re-verification (not overwritten by gov API).
    ///
    /// VERIFICATION FLOW:
    ///   1. User/Admin provides NIP + CompanyName
    ///   2. System calls Polish government API with the NIP
    ///   3. Government returns company data (uppercase names)
    ///   4. System compares provided CompanyName with government CompanyName
    ///   5. If match → all government fields are saved, profile is verified
    ///   6. If mismatch → verification fails, nothing is saved
    ///   7. User-provided fields (Phone, Email, etc.) are saved separately
    /// </summary>
    public class BusinessProfile
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        #region PRIMARY FIELDS - From Polish Government API (wl-api.mf.gov.pl)
        // These fields are populated exclusively from the government registry.
        // They should only be updated through API verification, never manually.

        /// <summary>
        /// Polish Tax Identification Number (NIP) - 10 digits [GOV]
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string NIP { get; set; } = string.Empty;

        /// <summary>
        /// Company name from government registry (always UPPERCASE) [GOV]
        /// e.g. "KOKOMIJA SPÓŁKA Z OGRANICZONĄ ODPOWIEDZIALNOŚCIĄ"
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// REGON number (9 or 14 digits) [GOV]
        /// </summary>
        [MaxLength(14)]
        public string? REGON { get; set; }

        /// <summary>
        /// KRS number if applicable [GOV]
        /// </summary>
        [MaxLength(20)]
        public string? KRS { get; set; }

        /// <summary>
        /// VAT status: Czynny, Zwolniony, Niezarejestrowany [GOV]
        /// </summary>
        [MaxLength(50)]
        public string? VATStatus { get; set; }

        /// <summary>
        /// Residence/registered address from registry [GOV]
        /// </summary>
        [MaxLength(500)]
        public string? ResidenceAddress { get; set; }

        /// <summary>
        /// Working/business address from registry [GOV]
        /// </summary>
        [MaxLength(500)]
        public string? WorkingAddress { get; set; }

        /// <summary>
        /// Date of VAT registration [GOV]
        /// </summary>
        public DateTime? RegistrationLegalDate { get; set; }

        #endregion

        #region SECONDARY FIELDS - User / Admin Provided
        // These fields are NOT available from the government API ("no data" on biznes.gov.pl).
        // They are provided by the user during registration or by admin in the edit panel.
        // They are preserved during re-verification and not overwritten by government data.

        /// <summary>
        /// Company phone number [USER/ADMIN]
        /// </summary>
        [MaxLength(30)]
        public string? Phone { get; set; }

        /// <summary>
        /// Company email for invoices [USER/ADMIN]
        /// </summary>
        [MaxLength(200)]
        public string? CompanyEmail { get; set; }

        /// <summary>
        /// Contact person name [USER/ADMIN]
        /// </summary>
        [MaxLength(200)]
        public string? ContactPerson { get; set; }

        /// <summary>
        /// Contact person's position/role [USER/ADMIN]
        /// </summary>
        [MaxLength(100)]
        public string? Position { get; set; }

        #endregion

        #region VERIFICATION METADATA

        /// <summary>
        /// Whether the business profile is verified (NIP + CompanyName matched gov API)
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

        #endregion

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
