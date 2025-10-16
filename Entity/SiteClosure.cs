using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Tracks site closure events for emergency maintenance
    /// </summary>
    public class SiteClosure
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Is site currently closed
        /// </summary>
        [Required]
        public bool IsClosed { get; set; } = false;

        /// <summary>
        /// Reason for closure
        /// </summary>
        [MaxLength(1000)]
        public string? Reason { get; set; }

        /// <summary>
        /// Who initiated the closure (email address)
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string ClosedBy { get; set; } = string.Empty;

        /// <summary>
        /// When site was closed
        /// </summary>
        public DateTime? ClosedAt { get; set; }

        /// <summary>
        /// Scheduled automatic reopening date (30 days after closure)
        /// </summary>
        public DateTime? ScheduledReopenAt { get; set; }

        /// <summary>
        /// Confirmation token for email-based reopening
        /// </summary>
        [MaxLength(500)]
        public string? ReopenConfirmationToken { get; set; }

        /// <summary>
        /// Token expiry date
        /// </summary>
        public DateTime? TokenExpiresAt { get; set; }

        /// <summary>
        /// Password-based access allowed
        /// </summary>
        public bool AllowPasswordAccess { get; set; } = true;

        /// <summary>
        /// Hashed password for emergency access (if set)
        /// </summary>
        [MaxLength(500)]
        public string? EmergencyPasswordHash { get; set; }

        /// <summary>
        /// When site was reopened
        /// </summary>
        public DateTime? ReopenedAt { get; set; }

        /// <summary>
        /// Who reopened the site
        /// </summary>
        [MaxLength(200)]
        public string? ReopenedBy { get; set; }

        /// <summary>
        /// How site was reopened (email, password, automatic, manual)
        /// </summary>
        [MaxLength(50)]
        public string? ReopenMethod { get; set; }

        /// <summary>
        /// Number of days site was closed
        /// </summary>
        public int? DaysClosed { get; set; }

        /// <summary>
        /// Daily confirmation emails sent
        /// </summary>
        public int ConfirmationEmailsSent { get; set; } = 0;

        /// <summary>
        /// Last confirmation email sent at
        /// </summary>
        public DateTime? LastConfirmationEmailAt { get; set; }

        /// <summary>
        /// Additional notes
        /// </summary>
        public string? Notes { get; set; }

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
