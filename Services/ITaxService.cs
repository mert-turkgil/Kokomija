using Kokomija.Models.ViewModels;

namespace Kokomija.Services
{
    public interface ITaxService
    {
        // Tax Rates CRUD
        Task<List<TaxRateDto>> GetAllTaxRatesAsync();
        Task<List<TaxRateDto>> GetActiveTaxRatesAsync();
        Task<TaxRateDto?> GetTaxRateByIdAsync(int id);
        Task<TaxRateDto?> GetDefaultTaxRateAsync();
        Task<TaxRateDto?> GetTaxRateByCountryAsync(string countryCode, string? stateCode = null);
        
        Task<(bool Success, string Message, int? TaxRateId)> CreateTaxRateAsync(CreateTaxRateDto dto);
        Task<(bool Success, string Message)> UpdateTaxRateAsync(int id, UpdateTaxRateDto dto);
        Task<(bool Success, string Message)> DeleteTaxRateAsync(int id);
        Task<(bool Success, string Message)> ToggleTaxRateStatusAsync(int id);
        Task<(bool Success, string Message)> SetDefaultTaxRateAsync(int id);

        // Tax Calculation
        Task<decimal> CalculateTaxAsync(decimal amount, string countryCode, string? stateCode = null);
        Task<(decimal TaxAmount, decimal Total)> CalculateTaxAndTotalAsync(decimal subtotal, string countryCode, string? stateCode = null);

        // Stripe Integration
        Task<(bool Success, string Message)> SyncTaxRateWithStripeAsync(int id);
        Task<string?> GetStripeTaxRateIdAsync(string countryCode, string? stateCode = null);
    }
}
