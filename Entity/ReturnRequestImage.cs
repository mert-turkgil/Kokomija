using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class ReturnRequestImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ReturnRequestId { get; set; }

        [ForeignKey(nameof(ReturnRequestId))]
        public ReturnRequest ReturnRequest { get; set; } = null!;

        [Required]
        [MaxLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        [Required]
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    }
}
