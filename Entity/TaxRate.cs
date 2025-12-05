using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kokomija.Entity
{
    public class TaxRate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // "VAT 23%", "Sales Tax 8%"

        [Required]
        [MaxLength(10)]
        public string CountryCode { get; set; } = string.Empty; // ISO country code

        [MaxLength(10)]
        public string? StateCode { get; set; } // For US states, etc.

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Rate { get; set; } // Percentage (e.g., 23.00 for 23%)

        [Required]
        [MaxLength(100)]
        public string StripeTaxRateId { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public bool IsDefault { get; set; } = false;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
