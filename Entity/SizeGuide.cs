using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    /// <summary>
    /// Size guide for a product - can include chart image and/or size data table
    /// </summary>
    public class SizeGuide
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; } = null!;

        /// <summary>
        /// Optional: Path to size chart image (e.g., /img/ProductImage/size-guide-123.jpg)
        /// </summary>
        [MaxLength(500)]
        public string? ChartImageUrl { get; set; }

        /// <summary>
        /// Optional: JSON-encoded size data for table display
        /// Example: [{"size":"XS","chest":"32-34","waist":"24-26"},...]
        /// </summary>
        public string? SizeDataJson { get; set; }

        /// <summary>
        /// Optional: Measurement instructions (e.g., "How to measure your chest")
        /// </summary>
        public string? MeasurementInstructions { get; set; }

        /// <summary>
        /// Optional: Translation key for measurement instructions
        /// </summary>
        [MaxLength(100)]
        public string? MeasurementInstructionsKey { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}
