using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Services
{
    public interface IAdminCommissionService
    {
        Task<AdminCommission> CalculateCommissionForOrderAsync(int orderId);
        Task<List<AdminCommission>> CalculateCommissionsForOrderItemsAsync(int orderId);
        Task<AdminEarnings> GetEarningsSummaryAsync(string periodType = "all-time", DateTime? startDate = null, DateTime? endDate = null);
        Task<decimal> GetCurrentCommissionRateAsync();
        Task<bool> UpdateCommissionRateAsync(decimal newRate, string updatedBy);
        Task<List<AdminCommission>> GetPendingCommissionsAsync();
        Task<List<AdminCommission>> GetCommissionsByDateRangeAsync(DateTime startDate, DateTime endDate);
    }

    public class AdminCommissionService : IAdminCommissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AdminCommissionService> _logger;

        public AdminCommissionService(
            IUnitOfWork unitOfWork,
            ILogger<AdminCommissionService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        /// <summary>
        /// Calculate commission for an entire order
        /// </summary>
        public async Task<AdminCommission> CalculateCommissionForOrderAsync(int orderId)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(orderId);
            if (order == null)
            {
                throw new ArgumentException($"Order {orderId} not found");
            }

            var commissionRate = await GetCurrentCommissionRateAsync();
            var stripeFeeRate = await GetStripeFeeRateAsync();
            var stripeFixedFee = await GetStripeFixedFeeAsync();

            // Calculate totals
            var subtotal = order.SubtotalAmount;
            var platformCommission = subtotal * commissionRate;
            var stripeFees = (subtotal * stripeFeeRate) + stripeFixedFee;
            var totalDeductions = platformCommission + stripeFees;

            var commission = new AdminCommission
            {
                OrderId = orderId,
                ProductPrice = order.SubtotalAmount,
                Quantity = 1,
                Subtotal = subtotal,
                PlatformCommissionRate = commissionRate,
                PlatformCommissionAmount = platformCommission,
                StripeProcessingFeeRate = stripeFeeRate,
                StripeFixedFee = stripeFixedFee,
                TotalStripeFees = stripeFees,
                TotalDeductions = totalDeductions,
                Currency = "PLN",
                Status = "pending",
                CalculatedAt = DateTime.UtcNow
            };

            await _unitOfWork.AdminCommissions.AddAsync(commission);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Commission calculated for order {OrderId}: Platform={PlatformCommission:C}, Stripe={StripeFees:C}, Total={TotalDeductions:C}",
                orderId, platformCommission, stripeFees, totalDeductions);

            return commission;
        }

        /// <summary>
        /// Calculate commission for each order item (per product)
        /// </summary>
        public async Task<List<AdminCommission>> CalculateCommissionsForOrderItemsAsync(int orderId)
        {
            var order = await _unitOfWork.Orders.GetOrderWithItemsAsync(orderId);

            if (order == null)
            {
                throw new ArgumentException($"Order {orderId} not found");
            }

            var commissions = new List<AdminCommission>();
            var commissionRate = await GetCurrentCommissionRateAsync();
            var stripeFeeRate = await GetStripeFeeRateAsync();
            var stripeFixedFee = await GetStripeFixedFeeAsync();

            // Distribute Stripe fixed fee across all items proportionally
            var orderTotal = order.OrderItems.Sum(oi => oi.UnitPrice * oi.Quantity);

            foreach (var item in order.OrderItems)
            {
                var itemSubtotal = item.UnitPrice * item.Quantity;
                var itemPlatformCommission = itemSubtotal * commissionRate;
                
                // Proportional Stripe fees for this item
                var itemStripePercentageFee = itemSubtotal * stripeFeeRate;
                var itemStripeFixedFee = (itemSubtotal / orderTotal) * stripeFixedFee;
                var itemTotalStripeFees = itemStripePercentageFee + itemStripeFixedFee;
                
                var itemTotalDeductions = itemPlatformCommission + itemTotalStripeFees;

                var commission = new AdminCommission
                {
                    OrderId = orderId,
                    OrderItemId = item.Id,
                    ProductId = item.ProductVariantId,
                    ProductPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    Subtotal = itemSubtotal,
                    PlatformCommissionRate = commissionRate,
                    PlatformCommissionAmount = itemPlatformCommission,
                    StripeProcessingFeeRate = stripeFeeRate,
                    StripeFixedFee = itemStripeFixedFee,
                    TotalStripeFees = itemTotalStripeFees,
                    TotalDeductions = itemTotalDeductions,
                    Currency = "PLN",
                    Status = "pending",
                    CalculatedAt = DateTime.UtcNow
                };

                commissions.Add(commission);
                await _unitOfWork.AdminCommissions.AddAsync(commission);
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Calculated {Count} commission entries for order {OrderId}",
                commissions.Count, orderId);

            return commissions;
        }

        /// <summary>
        /// Get earnings summary for a period
        /// </summary>
        public async Task<AdminEarnings> GetEarningsSummaryAsync(
            string periodType = "all-time",
            DateTime? startDate = null,
            DateTime? endDate = null)
        {
            var allCommissions = await _unitOfWork.AdminCommissions.GetAllAsync();
            var query = allCommissions.Where(ac => ac.Status == "pending" || ac.Status == "paid");

            if (startDate.HasValue)
            {
                query = query.Where(ac => ac.CalculatedAt >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(ac => ac.CalculatedAt <= endDate.Value);
            }

            var commissions = query.ToList();

            var totalOrders = commissions.Select(c => c.OrderId).Distinct().Count();
            var totalProductsSold = commissions.Sum(c => c.Quantity);
            var totalSalesRevenue = commissions.Sum(c => c.Subtotal);
            var totalPlatformCommission = commissions.Sum(c => c.PlatformCommissionAmount);
            var totalStripeFees = commissions.Sum(c => c.TotalStripeFees);
            var totalDeductions = commissions.Sum(c => c.TotalDeductions);
            var netRevenue = totalSalesRevenue - totalDeductions;

            var earnings = new AdminEarnings
            {
                PeriodType = periodType,
                PeriodStart = startDate,
                PeriodEnd = endDate,
                TotalOrders = totalOrders,
                TotalProductsSold = totalProductsSold,
                TotalSalesRevenue = totalSalesRevenue,
                TotalPlatformCommission = totalPlatformCommission,
                TotalStripeFees = totalStripeFees,
                TotalDeductions = totalDeductions,
                NetRevenue = netRevenue,
                AverageOrderValue = totalOrders > 0 ? totalSalesRevenue / totalOrders : 0,
                AverageCommissionPerOrder = totalOrders > 0 ? totalPlatformCommission / totalOrders : 0,
                CurrentCommissionRate = await GetCurrentCommissionRateAsync(),
                Currency = "PLN",
                LastCalculatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Save or update earnings summary
            var allEarnings = await _unitOfWork.AdminEarnings.GetAllAsync();
            var existingSummary = allEarnings.FirstOrDefault(ae => ae.PeriodType == periodType 
                    && ae.PeriodStart == startDate 
                    && ae.PeriodEnd == endDate);

            if (existingSummary != null)
            {
                existingSummary.TotalOrders = earnings.TotalOrders;
                existingSummary.TotalProductsSold = earnings.TotalProductsSold;
                existingSummary.TotalSalesRevenue = earnings.TotalSalesRevenue;
                existingSummary.TotalPlatformCommission = earnings.TotalPlatformCommission;
                existingSummary.TotalStripeFees = earnings.TotalStripeFees;
                existingSummary.TotalDeductions = earnings.TotalDeductions;
                existingSummary.NetRevenue = earnings.NetRevenue;
                existingSummary.AverageOrderValue = earnings.AverageOrderValue;
                existingSummary.AverageCommissionPerOrder = earnings.AverageCommissionPerOrder;
                existingSummary.CurrentCommissionRate = earnings.CurrentCommissionRate;
                existingSummary.LastCalculatedAt = DateTime.UtcNow;
                existingSummary.UpdatedAt = DateTime.UtcNow;
                
                await _unitOfWork.SaveChangesAsync();
                return existingSummary;
            }
            else
            {
                await _unitOfWork.AdminEarnings.AddAsync(earnings);
                await _unitOfWork.SaveChangesAsync();
                return earnings;
            }
        }

        /// <summary>
        /// Get current commission rate from settings
        /// </summary>
        public async Task<decimal> GetCurrentCommissionRateAsync()
        {
            var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "PlatformCommissionRate");

            if (setting != null && decimal.TryParse(setting.Value, out decimal rate))
            {
                return rate;
            }

            return 0.01M; // Default 1%
        }

        /// <summary>
        /// Update commission rate
        /// </summary>
        public async Task<bool> UpdateCommissionRateAsync(decimal newRate, string updatedBy)
        {
            try
            {
                var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
                var setting = allSettings.FirstOrDefault(s => s.Key == "PlatformCommissionRate");

                if (setting != null)
                {
                    setting.Value = newRate.ToString("F4"); // Format to 4 decimal places
                    setting.UpdatedAt = DateTime.UtcNow;
                    setting.UpdatedBy = updatedBy;
                }
                else
                {
                    setting = new SiteSetting
                    {
                        Key = "PlatformCommissionRate",
                        Value = newRate.ToString("F4"),
                        Description = "Platform commission rate per product sale",
                        Category = "Commission",
                        DataType = "decimal",
                        UpdatedAt = DateTime.UtcNow,
                        UpdatedBy = updatedBy
                    };
                    await _unitOfWork.SiteSettings.AddAsync(setting);
                }

                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Commission rate updated to {Rate}% by {UpdatedBy}",
                    newRate * 100, updatedBy);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to update commission rate");
                return false;
            }
        }

        /// <summary>
        /// Get pending commissions
        /// </summary>
        public async Task<List<AdminCommission>> GetPendingCommissionsAsync()
        {
            var allCommissions = await _unitOfWork.AdminCommissions.GetAllAsync();
            return allCommissions
                .Where(ac => ac.Status == "pending")
                .OrderByDescending(ac => ac.CalculatedAt)
                .ToList();
        }

        /// <summary>
        /// Get commissions by date range
        /// </summary>
        public async Task<List<AdminCommission>> GetCommissionsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var allCommissions = await _unitOfWork.AdminCommissions.GetAllAsync();
            return allCommissions
                .Where(ac => ac.CalculatedAt >= startDate && ac.CalculatedAt <= endDate)
                .OrderByDescending(ac => ac.CalculatedAt)
                .ToList();
        }

        private async Task<decimal> GetStripeFeeRateAsync()
        {
            var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "StripeProcessingFeeRate");

            if (setting != null && decimal.TryParse(setting.Value, out decimal rate))
            {
                return rate;
            }

            return 0.014M; // Default 1.4% for Poland
        }

        private async Task<decimal> GetStripeFixedFeeAsync()
        {
            var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "StripeFixedFee");

            if (setting != null && decimal.TryParse(setting.Value, out decimal fee))
            {
                return fee;
            }

            return 1.00M; // Default 1 PLN
        }
    }
}
