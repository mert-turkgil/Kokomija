using Kokomija.Data;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Kokomija.Services
{
    public interface IStripePayoutService
    {
        Task<(bool Success, string Message, string? PayoutId)> CreatePayoutAsync(decimal amount, string currency = "pln");
        Task<(bool Success, string Message)> ProcessPendingDeveloperEarningsAsync();
        Task<decimal> GetPendingPayoutAmountAsync();
        Task<List<PayoutHistoryDto>> GetPayoutHistoryAsync(int count = 20);
        Task<(bool Success, string Message)> SetupConnectAccountAsync(string accountId);
        Task<string?> GetConnectedAccountIdAsync();
        Task<(bool Success, string Message)> VerifyConnectAccountAsync();
    }

    public class PayoutHistoryDto
    {
        public string PayoutId { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "pln";
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string? Description { get; set; }
    }

    public class StripePayoutService : IStripePayoutService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<StripePayoutService> _logger;

        public StripePayoutService(
            ApplicationDbContext context,
            IConfiguration configuration,
            ILogger<StripePayoutService> logger)
        {
            _context = context;
            _configuration = configuration;
            _logger = logger;
            
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
        }

        /// <summary>
        /// Creates a payout to the connected developer account
        /// </summary>
        public async Task<(bool Success, string Message, string? PayoutId)> CreatePayoutAsync(decimal amount, string currency = "pln")
        {
            try
            {
                var connectedAccountId = _configuration["Stripe:ConnectedAccountId"];
                if (string.IsNullOrEmpty(connectedAccountId))
                {
                    return (false, "Stripe Connect account not configured. Please set up your connected account first.", null);
                }

                var settings = await _context.CommissionSettings.FirstOrDefaultAsync();
                if (settings != null && amount < settings.MinimumPayoutAmount)
                {
                    return (false, $"Amount ({amount:N2} {currency.ToUpper()}) is below minimum payout threshold ({settings.MinimumPayoutAmount:N2} {currency.ToUpper()}).", null);
                }

                // Create a transfer to connected account
                var transferOptions = new TransferCreateOptions
                {
                    Amount = (long)(amount * 100), // Convert to cents
                    Currency = currency,
                    Destination = connectedAccountId,
                    Description = $"Developer commission payout - {DateTime.UtcNow:yyyy-MM-dd}",
                    Metadata = new Dictionary<string, string>
                    {
                        { "type", "developer_commission" },
                        { "date", DateTime.UtcNow.ToString("O") }
                    }
                };

                var transferService = new TransferService();
                var transfer = await transferService.CreateAsync(transferOptions);

                _logger.LogInformation("Created payout transfer {TransferId} for {Amount} {Currency}", 
                    transfer.Id, amount, currency.ToUpper());

                return (true, $"Payout of {amount:N2} {currency.ToUpper()} initiated successfully.", transfer.Id);
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error creating payout for {Amount}", amount);
                return (false, $"Stripe error: {ex.Message}", null);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating payout for {Amount}", amount);
                return (false, "An error occurred while processing the payout.", null);
            }
        }

        /// <summary>
        /// Processes all pending developer earnings and creates a single payout
        /// </summary>
        public async Task<(bool Success, string Message)> ProcessPendingDeveloperEarningsAsync()
        {
            try
            {
                var settings = await _context.CommissionSettings.FirstOrDefaultAsync();
                if (settings == null || !settings.AutoPayoutEnabled)
                {
                    return (false, "Automatic payouts are not enabled.");
                }

                var pendingEarnings = await _context.DeveloperEarnings
                    .Where(e => e.PayoutStatus == PayoutStatus.Pending)
                    .ToListAsync();

                if (!pendingEarnings.Any())
                {
                    return (true, "No pending earnings to process.");
                }

                var totalAmount = pendingEarnings.Sum(e => e.DeveloperCommission);

                if (totalAmount < settings.MinimumPayoutAmount)
                {
                    return (false, $"Total pending amount ({totalAmount:N2} PLN) is below minimum threshold ({settings.MinimumPayoutAmount:N2} PLN).");
                }

                // Create the payout
                var (success, message, payoutId) = await CreatePayoutAsync(totalAmount);

                if (success && !string.IsNullOrEmpty(payoutId))
                {
                    // Update all processed earnings
                    foreach (var earning in pendingEarnings)
                    {
                        earning.PayoutStatus = PayoutStatus.Processed;
                        earning.PayoutDate = DateTime.UtcNow;
                        earning.StripePayoutId = payoutId;
                    }

                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Processed {Count} pending earnings for total {Amount} PLN", 
                        pendingEarnings.Count, totalAmount);
                }

                return (success, message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing pending developer earnings");
                return (false, "An error occurred while processing pending earnings.");
            }
        }

        /// <summary>
        /// Gets the total pending payout amount
        /// </summary>
        public async Task<decimal> GetPendingPayoutAmountAsync()
        {
            return await _context.DeveloperEarnings
                .Where(e => e.PayoutStatus == PayoutStatus.Pending)
                .SumAsync(e => e.DeveloperCommission);
        }

        /// <summary>
        /// Gets payout history from Stripe
        /// </summary>
        public async Task<List<PayoutHistoryDto>> GetPayoutHistoryAsync(int count = 20)
        {
            try
            {
                var connectedAccountId = _configuration["Stripe:ConnectedAccountId"];
                if (string.IsNullOrEmpty(connectedAccountId))
                {
                    return new List<PayoutHistoryDto>();
                }

                // Get transfers to the connected account
                var transferService = new TransferService();
                var options = new TransferListOptions
                {
                    Limit = count,
                    Destination = connectedAccountId
                };

                var transfers = await transferService.ListAsync(options);

                return transfers.Data.Select(t => new PayoutHistoryDto
                {
                    PayoutId = t.Id,
                    Amount = t.Amount / 100m, // Convert from cents
                    Currency = t.Currency.ToUpper(),
                    Status = t.Reversed ? "reversed" : "completed",
                    CreatedAt = t.Created,
                    Description = t.Description
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching payout history");
                return new List<PayoutHistoryDto>();
            }
        }

        /// <summary>
        /// Sets up the connected account ID for payouts
        /// </summary>
        public async Task<(bool Success, string Message)> SetupConnectAccountAsync(string accountId)
        {
            try
            {
                // Verify the account exists in Stripe
                var accountService = new AccountService();
                var account = await accountService.GetAsync(accountId);

                if (account == null)
                {
                    return (false, "Invalid Stripe Connect account ID.");
                }

                if (!account.PayoutsEnabled)
                {
                    return (false, "This Stripe Connect account does not have payouts enabled. Please complete account verification.");
                }

                _logger.LogInformation("Stripe Connect account {AccountId} verified successfully", accountId);
                return (true, $"Connected account verified: {account.Email ?? account.Id}. Payouts are enabled.");
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Stripe error verifying account {AccountId}", accountId);
                return (false, $"Stripe error: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the configured connected account ID
        /// </summary>
        public Task<string?> GetConnectedAccountIdAsync()
        {
            return Task.FromResult(_configuration["Stripe:ConnectedAccountId"]);
        }

        /// <summary>
        /// Verifies the connected account is properly set up
        /// </summary>
        public async Task<(bool Success, string Message)> VerifyConnectAccountAsync()
        {
            var accountId = _configuration["Stripe:ConnectedAccountId"];
            if (string.IsNullOrEmpty(accountId))
            {
                return (false, "No connected account configured. Add 'Stripe:ConnectedAccountId' to your configuration.");
            }

            return await SetupConnectAccountAsync(accountId);
        }
    }
}
