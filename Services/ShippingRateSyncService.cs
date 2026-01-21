using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Services
{
    /// <summary>
    /// Service to synchronize shipping rates with Stripe
    /// </summary>
    public interface IShippingRateSyncService
    {
        Task SyncAllShippingRatesAsync();
        Task SyncShippingRateAsync(int shippingRateId);
    }

    public class ShippingRateSyncService : IShippingRateSyncService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStripeService _stripeService;
        private readonly ILogger<ShippingRateSyncService> _logger;

        public ShippingRateSyncService(
            IUnitOfWork unitOfWork,
            IStripeService stripeService,
            ILogger<ShippingRateSyncService> logger)
        {
            _unitOfWork = unitOfWork;
            _stripeService = stripeService;
            _logger = logger;
        }

        /// <summary>
        /// Sync all shipping rates with Stripe (create if missing, update if exists)
        /// </summary>
        public async Task SyncAllShippingRatesAsync()
        {
            try
            {
                _logger.LogInformation("Starting shipping rates sync with Stripe...");

                var allRates = await _unitOfWork.ShippingRates.GetAllAsync();
                var ratesList = allRates.Where(r => r.IsActive).ToList();

                var syncedCount = 0;
                var createdCount = 0;
                var updatedCount = 0;
                var errorCount = 0;

                foreach (var rate in ratesList)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(rate.StripeShippingRateId))
                        {
                            // Create new Stripe shipping rate
                            var stripeRate = await _stripeService.CreateShippingRateAsync(rate);
                            
                            // Update local record with Stripe ID
                            rate.StripeShippingRateId = stripeRate.Id;
                            _unitOfWork.Repository<ShippingRate>().Update(rate);
                            
                            createdCount++;
                            _logger.LogInformation("Created Stripe shipping rate for {Name}: {StripeId}", 
                                rate.Name, stripeRate.Id);
                        }
                        else
                        {
                            // Update existing Stripe shipping rate
                            try
                            {
                                await _stripeService.UpdateShippingRateAsync(rate.StripeShippingRateId, rate);
                                updatedCount++;
                                _logger.LogInformation("Updated Stripe shipping rate {Name}: {StripeId}", 
                                    rate.Name, rate.StripeShippingRateId);
                            }
                            catch (Stripe.StripeException ex) when (ex.StripeError?.Code == "resource_missing")
                            {
                                // Stripe rate was deleted, create a new one
                                _logger.LogWarning("Stripe rate {StripeId} not found, creating new one", 
                                    rate.StripeShippingRateId);
                                
                                var stripeRate = await _stripeService.CreateShippingRateAsync(rate);
                                rate.StripeShippingRateId = stripeRate.Id;
                                _unitOfWork.Repository<ShippingRate>().Update(rate);
                                createdCount++;
                            }
                        }

                        syncedCount++;
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        _logger.LogError(ex, "Failed to sync shipping rate {Name} (ID: {Id})", 
                            rate.Name, rate.Id);
                    }
                }

                // Save all changes
                if (createdCount > 0 || updatedCount > 0)
                {
                    await _unitOfWork.SaveChangesAsync();
                    _logger.LogInformation(
                        "Shipping rates sync completed. Total: {Total}, Created: {Created}, Updated: {Updated}, Errors: {Errors}",
                        syncedCount, createdCount, updatedCount, errorCount);
                }
                else
                {
                    _logger.LogInformation("No shipping rates needed syncing.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to sync shipping rates with Stripe");
                throw;
            }
        }

        /// <summary>
        /// Sync a single shipping rate with Stripe
        /// </summary>
        public async Task SyncShippingRateAsync(int shippingRateId)
        {
            try
            {
                var rate = await _unitOfWork.ShippingRates.GetByIdAsync(shippingRateId);
                if (rate == null)
                {
                    _logger.LogWarning("Shipping rate {Id} not found", shippingRateId);
                    return;
                }

                if (!rate.IsActive)
                {
                    _logger.LogInformation("Shipping rate {Name} is inactive, skipping sync", rate.Name);
                    return;
                }

                if (string.IsNullOrEmpty(rate.StripeShippingRateId))
                {
                    // Create new Stripe shipping rate
                    var stripeRate = await _stripeService.CreateShippingRateAsync(rate);
                    
                    // Update local record with Stripe ID
                    rate.StripeShippingRateId = stripeRate.Id;
                    _unitOfWork.Repository<ShippingRate>().Update(rate);
                    await _unitOfWork.SaveChangesAsync();
                    
                    _logger.LogInformation("Created Stripe shipping rate for {Name}: {StripeId}", 
                        rate.Name, stripeRate.Id);
                }
                else
                {
                    // Update existing Stripe shipping rate
                    await _stripeService.UpdateShippingRateAsync(rate.StripeShippingRateId, rate);
                    _logger.LogInformation("Updated Stripe shipping rate {Name}: {StripeId}", 
                        rate.Name, rate.StripeShippingRateId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to sync shipping rate {Id}", shippingRateId);
                throw;
            }
        }
    }
}
