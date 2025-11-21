using Kokomija.Data.Abstract;
using Kokomija.Entity;

namespace Kokomija.Services
{
    public interface IPriceHistoryService
    {
        Task SavePriceHistoryAsync(int productId, decimal oldPrice, decimal newPrice, string reason, string changedBy);
    }

    public class PriceHistoryService : IPriceHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PriceHistoryService> _logger;

        public PriceHistoryService(IUnitOfWork unitOfWork, ILogger<PriceHistoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task SavePriceHistoryAsync(int productId, decimal oldPrice, decimal newPrice, string reason, string changedBy)
        {
            try
            {
                // Check if this exact price already exists in history
                var priceHistories = await _unitOfWork.Repository<ProductPriceHistory>().GetAllAsync();
                var existingHistory = priceHistories.FirstOrDefault(ph => 
                    ph.ProductId == productId && 
                    ph.NewPrice == newPrice &&
                    ph.OldPrice == oldPrice);

                if (existingHistory != null)
                {
                    _logger.LogInformation($"Price history already exists for product {productId}: {oldPrice} -> {newPrice}");
                    return;
                }

                var priceHistory = new ProductPriceHistory
                {
                    ProductId = productId,
                    OldPrice = oldPrice,
                    NewPrice = newPrice,
                    Reason = reason,
                    ChangedBy = changedBy,
                    ChangedAt = DateTime.UtcNow
                };

                await _unitOfWork.Repository<ProductPriceHistory>().AddAsync(priceHistory);
                await _unitOfWork.SaveChangesAsync();
                
                _logger.LogInformation($"Saved price history for product {productId}: {oldPrice} PLN -> {newPrice} PLN");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to save price history for product {productId}");
            }
        }
    }
}
