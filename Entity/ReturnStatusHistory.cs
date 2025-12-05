using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class ReturnStatusHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReturnRequestId { get; set; }

        [ForeignKey(nameof(ReturnRequestId))]
        public ReturnRequest ReturnRequest { get; set; } = null!;

        [Required]
        public ReturnRequestStatus Status { get; set; }

        public string? Notes { get; set; }

        [Required]
        public string ChangedBy { get; set; } = string.Empty;

        [ForeignKey(nameof(ChangedBy))]
        public ApplicationUser User { get; set; } = null!;

        [Required]
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
    }
}
