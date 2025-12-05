using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels
{
    // ==================== Tax Rate DTOs ====================

    public class TaxRateDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string? StateCode { get; set; }
        public decimal Rate { get; set; }
        public string StripeTaxRateId { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class CreateTaxRateDto
    {
        [Required(ErrorMessage = "Tax name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country code is required")]
        [MaxLength(10)]
        public string CountryCode { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? StateCode { get; set; }

        [Required(ErrorMessage = "Tax rate is required")]
        [Range(0.01, 100.00, ErrorMessage = "Tax rate must be between 0.01% and 100%")]
        public decimal Rate { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsDefault { get; set; } = false;
    }

    public class UpdateTaxRateDto
    {
        [Required(ErrorMessage = "Tax name is required")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country code is required")]
        [MaxLength(10)]
        public string CountryCode { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? StateCode { get; set; }

        [Required(ErrorMessage = "Tax rate is required")]
        [Range(0.01, 100.00, ErrorMessage = "Tax rate must be between 0.01% and 100%")]
        public decimal Rate { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public bool IsActive { get; set; }
        public bool IsDefault { get; set; }
    }

    // ==================== View Models ====================

    public class TaxRatesViewModel
    {
        public List<TaxRateDto> TaxRates { get; set; } = new();
        public int TotalTaxRates { get; set; }
        public int ActiveTaxRates { get; set; }
        public TaxRateDto? DefaultTaxRate { get; set; }
    }
}
