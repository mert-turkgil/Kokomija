using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class SiteBlockLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string BlockedBy { get; set; } = string.Empty; // Must be root user

        [ForeignKey(nameof(BlockedBy))]
        public ApplicationUser BlockedByUser { get; set; } = null!;

        [Required]
        public string Reason { get; set; } = string.Empty;

        [Required]
        public string UserMessage { get; set; } = string.Empty; // Message shown to blocked users

        [Required]
        public DateTime BlockedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UnblockedAt { get; set; }

        public string? UnblockedBy { get; set; }

        [ForeignKey(nameof(UnblockedBy))]
        public ApplicationUser? UnblockedByUser { get; set; }

        /// <summary>
        /// Is this block currently active?
        /// </summary>
        [Required]
        public bool IsActive { get; set; } = true;
    }
}
