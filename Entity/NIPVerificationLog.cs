using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Tracks NIP verification attempts for rate limiting
    /// </summary>
    public class NIPVerificationLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        /// <summary>
        /// The NIP that was attempted to verify
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string NIP { get; set; } = string.Empty;

        /// <summary>
        /// IP address of the request
        /// </summary>
        [MaxLength(45)]
        public string? IPAddress { get; set; }

        /// <summary>
        /// Whether the verification was successful
        /// </summary>
        public bool WasSuccessful { get; set; } = false;

        /// <summary>
        /// Error message if verification failed
        /// </summary>
        [MaxLength(500)]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// Response code from API
        /// </summary>
        [MaxLength(20)]
        public string? ResponseCode { get; set; }

        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;
    }
}
