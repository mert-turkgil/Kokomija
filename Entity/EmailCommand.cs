using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Email-based admin commands for site control
    /// </summary>
    public class EmailCommand
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Command type (change_rate, close_site, reopen_site, confirm_reopen)
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string CommandType { get; set; } = string.Empty;

        /// <summary>
        /// Sender email address
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string SenderEmail { get; set; } = string.Empty;

        /// <summary>
        /// Email subject
        /// </summary>
        [MaxLength(500)]
        public string? Subject { get; set; }

        /// <summary>
        /// Email body content
        /// </summary>
        public string? Body { get; set; }

        /// <summary>
        /// Parsed command parameters (JSON)
        /// </summary>
        public string? CommandParameters { get; set; }

        /// <summary>
        /// Command status (pending, executed, rejected, failed)
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = "pending";

        /// <summary>
        /// Is sender authorized (super admin)
        /// </summary>
        [Required]
        public bool IsAuthorized { get; set; } = false;

        /// <summary>
        /// Authorization token (for email confirmation)
        /// </summary>
        [MaxLength(500)]
        public string? AuthorizationToken { get; set; }

        /// <summary>
        /// Token expiry
        /// </summary>
        public DateTime? TokenExpiresAt { get; set; }

        /// <summary>
        /// Was command executed
        /// </summary>
        public bool IsExecuted { get; set; } = false;

        /// <summary>
        /// Execution result
        /// </summary>
        public string? ExecutionResult { get; set; }

        /// <summary>
        /// Error message if failed
        /// </summary>
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// When command was received
        /// </summary>
        public DateTime ReceivedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// When command was executed
        /// </summary>
        public DateTime? ExecutedAt { get; set; }

        /// <summary>
        /// IP address of confirmation (if web-based)
        /// </summary>
        [MaxLength(100)]
        public string? ConfirmationIp { get; set; }

        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
