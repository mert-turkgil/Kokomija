using Kokomija.Entity;
using Stripe;

namespace Kokomija.Services
{
    public interface IStripeCustomerService
    {
        Task<string> CreateCustomerAsync(ApplicationUser user);
        Task<Customer?> GetCustomerAsync(string customerId);
        Task UpdateCustomerAsync(string customerId, string? email = null, string? name = null, string? phone = null);
        Task<bool> DeleteCustomerAsync(string customerId);
    }

    public class StripeCustomerService : IStripeCustomerService
    {
        private readonly CustomerService _customerService;
        private readonly ILogger<StripeCustomerService> _logger;

        public StripeCustomerService(ILogger<StripeCustomerService> logger)
        {
            _customerService = new CustomerService();
            _logger = logger;
        }

        public async Task<string> CreateCustomerAsync(ApplicationUser user)
        {
            try
            {
                var options = new CustomerCreateOptions
                {
                    Email = user.Email,
                    Name = $"{user.FirstName} {user.LastName}".Trim(),
                    Phone = user.PhoneNumber,
                    Metadata = new Dictionary<string, string>
                    {
                        { "user_id", user.Id },
                        { "created_at", DateTime.UtcNow.ToString("O") }
                    }
                };

                var customer = await _customerService.CreateAsync(options);
                _logger.LogInformation("Created Stripe customer {CustomerId} for user {UserId}", customer.Id, user.Id);
                
                return customer.Id;
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Error creating Stripe customer for user {UserId}", user.Id);
                throw;
            }
        }

        public async Task<Customer?> GetCustomerAsync(string customerId)
        {
            try
            {
                var customer = await _customerService.GetAsync(customerId);
                return customer;
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Error retrieving Stripe customer {CustomerId}", customerId);
                return null;
            }
        }

        public async Task UpdateCustomerAsync(string customerId, string? email = null, string? name = null, string? phone = null)
        {
            try
            {
                var options = new CustomerUpdateOptions();

                if (!string.IsNullOrEmpty(email))
                    options.Email = email;

                if (!string.IsNullOrEmpty(name))
                    options.Name = name;

                if (!string.IsNullOrEmpty(phone))
                    options.Phone = phone;

                await _customerService.UpdateAsync(customerId, options);
                _logger.LogInformation("Updated Stripe customer {CustomerId}", customerId);
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Error updating Stripe customer {CustomerId}", customerId);
                throw;
            }
        }

        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            try
            {
                await _customerService.DeleteAsync(customerId);
                _logger.LogInformation("Deleted Stripe customer {CustomerId}", customerId);
                return true;
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Error deleting Stripe customer {CustomerId}", customerId);
                return false;
            }
        }
    }
}
