using Kokomija.Data;
using Kokomija.Entity;
using Kokomija.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Kokomija.Services
{
    public class TaxService : ITaxService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TaxService> _logger;
        private readonly IConfiguration _configuration;

        public TaxService(ApplicationDbContext context, ILogger<TaxService> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        // ==================== Tax Rates CRUD ====================

        public async Task<List<TaxRateDto>> GetAllTaxRatesAsync()
        {
            return await _context.TaxRates
                .OrderByDescending(tr => tr.IsDefault)
                .ThenBy(tr => tr.CountryCode)
                .ThenBy(tr => tr.StateCode)
                .Select(tr => new TaxRateDto
                {
                    Id = tr.Id,
                    Name = tr.Name,
                    CountryCode = tr.CountryCode,
                    StateCode = tr.StateCode,
                    Rate = tr.Rate,
                    StripeTaxRateId = tr.StripeTaxRateId,
                    IsActive = tr.IsActive,
                    IsDefault = tr.IsDefault,
                    Description = tr.Description,
                    CreatedAt = tr.CreatedAt,
                    UpdatedAt = tr.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<List<TaxRateDto>> GetActiveTaxRatesAsync()
        {
            return await _context.TaxRates
                .Where(tr => tr.IsActive)
                .OrderByDescending(tr => tr.IsDefault)
                .ThenBy(tr => tr.CountryCode)
                .Select(tr => new TaxRateDto
                {
                    Id = tr.Id,
                    Name = tr.Name,
                    CountryCode = tr.CountryCode,
                    StateCode = tr.StateCode,
                    Rate = tr.Rate,
                    StripeTaxRateId = tr.StripeTaxRateId,
                    IsActive = tr.IsActive,
                    IsDefault = tr.IsDefault,
                    Description = tr.Description,
                    CreatedAt = tr.CreatedAt,
                    UpdatedAt = tr.UpdatedAt
                })
                .ToListAsync();
        }

        public async Task<TaxRateDto?> GetTaxRateByIdAsync(int id)
        {
            return await _context.TaxRates
                .Where(tr => tr.Id == id)
                .Select(tr => new TaxRateDto
                {
                    Id = tr.Id,
                    Name = tr.Name,
                    CountryCode = tr.CountryCode,
                    StateCode = tr.StateCode,
                    Rate = tr.Rate,
                    StripeTaxRateId = tr.StripeTaxRateId,
                    IsActive = tr.IsActive,
                    IsDefault = tr.IsDefault,
                    Description = tr.Description,
                    CreatedAt = tr.CreatedAt,
                    UpdatedAt = tr.UpdatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TaxRateDto?> GetDefaultTaxRateAsync()
        {
            return await _context.TaxRates
                .Where(tr => tr.IsDefault && tr.IsActive)
                .Select(tr => new TaxRateDto
                {
                    Id = tr.Id,
                    Name = tr.Name,
                    CountryCode = tr.CountryCode,
                    StateCode = tr.StateCode,
                    Rate = tr.Rate,
                    StripeTaxRateId = tr.StripeTaxRateId,
                    IsActive = tr.IsActive,
                    IsDefault = tr.IsDefault,
                    Description = tr.Description,
                    CreatedAt = tr.CreatedAt,
                    UpdatedAt = tr.UpdatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<TaxRateDto?> GetTaxRateByCountryAsync(string countryCode, string? stateCode = null)
        {
            var query = _context.TaxRates
                .Where(tr => tr.IsActive && tr.CountryCode == countryCode);

            if (!string.IsNullOrEmpty(stateCode))
            {
                query = query.Where(tr => tr.StateCode == stateCode);
            }
            else
            {
                query = query.Where(tr => tr.StateCode == null);
            }

            return await query
                .Select(tr => new TaxRateDto
                {
                    Id = tr.Id,
                    Name = tr.Name,
                    CountryCode = tr.CountryCode,
                    StateCode = tr.StateCode,
                    Rate = tr.Rate,
                    StripeTaxRateId = tr.StripeTaxRateId,
                    IsActive = tr.IsActive,
                    IsDefault = tr.IsDefault,
                    Description = tr.Description,
                    CreatedAt = tr.CreatedAt,
                    UpdatedAt = tr.UpdatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task<(bool Success, string Message, int? TaxRateId)> CreateTaxRateAsync(CreateTaxRateDto dto)
        {
            try
            {
                // Check if tax rate already exists for this country/state
                var exists = await _context.TaxRates
                    .AnyAsync(tr => tr.CountryCode == dto.CountryCode && tr.StateCode == dto.StateCode);

                if (exists)
                    return (false, "A tax rate already exists for this country/state combination.", null);

                // Create Stripe tax rate
                var stripeSecretKey = _configuration["Stripe:SecretKey"];
                StripeConfiguration.ApiKey = stripeSecretKey;

                var options = new TaxRateCreateOptions
                {
                    DisplayName = dto.Name,
                    Percentage = dto.Rate,
                    Inclusive = false,
                    Country = dto.CountryCode,
                    State = dto.StateCode,
                    Description = dto.Description
                };

                var service = new TaxRateService();
                var stripeTaxRate = await service.CreateAsync(options);

                // Create database record
                var taxRate = new Entity.TaxRate
                {
                    Name = dto.Name,
                    CountryCode = dto.CountryCode,
                    StateCode = dto.StateCode,
                    Rate = dto.Rate,
                    StripeTaxRateId = stripeTaxRate.Id,
                    IsActive = true,
                    IsDefault = dto.IsDefault,
                    Description = dto.Description,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                // If this is set as default, unset other defaults
                if (dto.IsDefault)
                {
                    var currentDefaults = await _context.TaxRates.Where(tr => tr.IsDefault).ToListAsync();
                    foreach (var current in currentDefaults)
                    {
                        current.IsDefault = false;
                        current.UpdatedAt = DateTime.UtcNow;
                    }
                }

                _context.TaxRates.Add(taxRate);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Tax rate {TaxRateName} created with Stripe ID {StripeId}", taxRate.Name, stripeTaxRate.Id);
                return (true, "Tax rate created successfully and synced with Stripe.", taxRate.Id);
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error creating tax rate {TaxRateName}", dto.Name);
                return (false, $"Stripe error: {ex.Message}", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating tax rate {TaxRateName}", dto.Name);
                return (false, "An error occurred while creating the tax rate.", null);
            }
        }

        public async Task<(bool Success, string Message)> UpdateTaxRateAsync(int id, UpdateTaxRateDto dto)
        {
            try
            {
                var taxRate = await _context.TaxRates.FindAsync(id);
                if (taxRate == null)
                    return (false, "Tax rate not found.");

                // Update Stripe tax rate
                var stripeSecretKey = _configuration["Stripe:SecretKey"];
                StripeConfiguration.ApiKey = stripeSecretKey;

                var options = new TaxRateUpdateOptions
                {
                    DisplayName = dto.Name,
                    Description = dto.Description,
                    Active = dto.IsActive
                };

                var service = new TaxRateService();
                await service.UpdateAsync(taxRate.StripeTaxRateId, options);

                // Update database record
                taxRate.Name = dto.Name;
                taxRate.CountryCode = dto.CountryCode;
                taxRate.StateCode = dto.StateCode;
                taxRate.Rate = dto.Rate;
                taxRate.IsActive = dto.IsActive;
                taxRate.Description = dto.Description;
                taxRate.UpdatedAt = DateTime.UtcNow;

                // Handle default flag
                if (dto.IsDefault && !taxRate.IsDefault)
                {
                    var currentDefaults = await _context.TaxRates.Where(tr => tr.IsDefault && tr.Id != id).ToListAsync();
                    foreach (var current in currentDefaults)
                    {
                        current.IsDefault = false;
                        current.UpdatedAt = DateTime.UtcNow;
                    }
                    taxRate.IsDefault = true;
                }
                else if (!dto.IsDefault && taxRate.IsDefault)
                {
                    taxRate.IsDefault = false;
                }

                await _context.SaveChangesAsync();

                _logger.LogInformation("Tax rate {TaxRateId} updated", id);
                return (true, "Tax rate updated successfully and synced with Stripe.");
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error updating tax rate {TaxRateId}", id);
                return (false, $"Stripe error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating tax rate {TaxRateId}", id);
                return (false, "An error occurred while updating the tax rate.");
            }
        }

        public async Task<(bool Success, string Message)> DeleteTaxRateAsync(int id)
        {
            try
            {
                var taxRate = await _context.TaxRates.FindAsync(id);
                if (taxRate == null)
                    return (false, "Tax rate not found.");

                if (taxRate.IsDefault)
                    return (false, "Cannot delete the default tax rate. Set another as default first.");

                // Archive in Stripe instead of deleting
                var stripeSecretKey = _configuration["Stripe:SecretKey"];
                StripeConfiguration.ApiKey = stripeSecretKey;

                var options = new TaxRateUpdateOptions { Active = false };
                var service = new TaxRateService();
                await service.UpdateAsync(taxRate.StripeTaxRateId, options);

                _context.TaxRates.Remove(taxRate);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Tax rate {TaxRateId} deleted and archived in Stripe", id);
                return (true, "Tax rate deleted successfully and archived in Stripe.");
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error deleting tax rate {TaxRateId}", id);
                return (false, $"Stripe error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting tax rate {TaxRateId}", id);
                return (false, "An error occurred while deleting the tax rate.");
            }
        }

        public async Task<(bool Success, string Message)> ToggleTaxRateStatusAsync(int id)
        {
            try
            {
                var taxRate = await _context.TaxRates.FindAsync(id);
                if (taxRate == null)
                    return (false, "Tax rate not found.");

                taxRate.IsActive = !taxRate.IsActive;
                taxRate.UpdatedAt = DateTime.UtcNow;

                // Update Stripe
                var stripeSecretKey = _configuration["Stripe:SecretKey"];
                StripeConfiguration.ApiKey = stripeSecretKey;

                var options = new TaxRateUpdateOptions { Active = taxRate.IsActive };
                var service = new TaxRateService();
                await service.UpdateAsync(taxRate.StripeTaxRateId, options);

                await _context.SaveChangesAsync();

                var status = taxRate.IsActive ? "activated" : "deactivated";
                _logger.LogInformation("Tax rate {TaxRateId} {Status}", id, status);
                return (true, $"Tax rate {status} successfully and synced with Stripe.");
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error toggling tax rate {TaxRateId}", id);
                return (false, $"Stripe error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling tax rate status {TaxRateId}", id);
                return (false, "An error occurred while updating the tax rate status.");
            }
        }

        public async Task<(bool Success, string Message)> SetDefaultTaxRateAsync(int id)
        {
            try
            {
                var taxRate = await _context.TaxRates.FindAsync(id);
                if (taxRate == null)
                    return (false, "Tax rate not found.");

                if (!taxRate.IsActive)
                    return (false, "Cannot set an inactive tax rate as default.");

                // Unset all other defaults
                var currentDefaults = await _context.TaxRates.Where(tr => tr.IsDefault).ToListAsync();
                foreach (var current in currentDefaults)
                {
                    current.IsDefault = false;
                    current.UpdatedAt = DateTime.UtcNow;
                }

                taxRate.IsDefault = true;
                taxRate.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Tax rate {TaxRateId} set as default", id);
                return (true, "Default tax rate updated successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error setting default tax rate {TaxRateId}", id);
                return (false, "An error occurred while setting the default tax rate.");
            }
        }

        // ==================== Tax Calculation ====================

        public async Task<decimal> CalculateTaxAsync(decimal amount, string countryCode, string? stateCode = null)
        {
            var taxRate = await GetTaxRateByCountryAsync(countryCode, stateCode);
            
            if (taxRate == null)
            {
                taxRate = await GetDefaultTaxRateAsync();
            }

            if (taxRate == null)
                return 0;

            return Math.Round(amount * (taxRate.Rate / 100), 2);
        }

        public async Task<(decimal TaxAmount, decimal Total)> CalculateTaxAndTotalAsync(decimal subtotal, string countryCode, string? stateCode = null)
        {
            var taxAmount = await CalculateTaxAsync(subtotal, countryCode, stateCode);
            var total = subtotal + taxAmount;
            return (taxAmount, total);
        }

        // ==================== Stripe Integration ====================

        public async Task<(bool Success, string Message)> SyncTaxRateWithStripeAsync(int id)
        {
            try
            {
                var taxRate = await _context.TaxRates.FindAsync(id);
                if (taxRate == null)
                    return (false, "Tax rate not found.");

                var stripeSecretKey = _configuration["Stripe:SecretKey"];
                StripeConfiguration.ApiKey = stripeSecretKey;

                var service = new TaxRateService();
                var stripeTaxRate = await service.GetAsync(taxRate.StripeTaxRateId);

                if (stripeTaxRate == null)
                    return (false, "Tax rate not found in Stripe.");

                // Sync any differences
                if (stripeTaxRate.Percentage != taxRate.Rate || 
                    stripeTaxRate.Active != taxRate.IsActive)
                {
                    var options = new TaxRateUpdateOptions
                    {
                        DisplayName = taxRate.Name,
                        Description = taxRate.Description,
                        Active = taxRate.IsActive
                    };

                    await service.UpdateAsync(taxRate.StripeTaxRateId, options);
                }

                _logger.LogInformation("Tax rate {TaxRateId} synced with Stripe", id);
                return (true, "Tax rate synced successfully with Stripe.");
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error syncing tax rate {TaxRateId}", id);
                return (false, $"Stripe error: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error syncing tax rate {TaxRateId}", id);
                return (false, "An error occurred while syncing with Stripe.");
            }
        }

        public async Task<string?> GetStripeTaxRateIdAsync(string countryCode, string? stateCode = null)
        {
            var taxRate = await GetTaxRateByCountryAsync(countryCode, stateCode);
            
            if (taxRate == null)
            {
                taxRate = await GetDefaultTaxRateAsync();
            }

            return taxRate?.StripeTaxRateId;
        }
    }
}
