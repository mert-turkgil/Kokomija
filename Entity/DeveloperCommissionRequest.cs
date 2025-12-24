using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public enum CommissionRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

    /// <summary>
    /// Tracks developer requests to change commission rates
    /// </summary>
    public class DeveloperCommissionRequest
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Developer who made the request
        /// </summary>
        [Required]
        public string DeveloperId { get; set; } = string.Empty;

        [ForeignKey(nameof(DeveloperId))]
        public ApplicationUser? Developer { get; set; }

        /// <summary>
        /// Current commission rate when request was made
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CurrentRate { get; set; }

        /// <summary>
        /// Requested new commission rate
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal RequestedRate { get; set; }

        /// <summary>
        /// Reason for the change request
        /// </summary>
        [Required]
        [MaxLength(2000)]
        public string Reason { get; set; } = string.Empty;

        /// <summary>
        /// Request status
        /// </summary>
        [Required]
        public CommissionRequestStatus Status { get; set; } = CommissionRequestStatus.Pending;

        /// <summary>
        /// Admin who reviewed the request
        /// </summary>
        public string? ReviewedById { get; set; }

        [ForeignKey(nameof(ReviewedById))]
        public ApplicationUser? ReviewedBy { get; set; }

        /// <summary>
        /// Admin's response/notes
        /// </summary>
        [MaxLength(2000)]
        public string? AdminResponse { get; set; }

        /// <summary>
        /// When the request was reviewed
        /// </summary>
        public DateTime? ReviewedAt { get; set; }

        /// <summary>
        /// Email notification sent to admin
        /// </summary>
        public bool AdminNotified { get; set; } = false;

        /// <summary>
        /// Email notification sent to developer about decision
        /// </summary>
        public bool DeveloperNotified { get; set; } = false;

        /// <summary>
        /// When request was created
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Last updated
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
