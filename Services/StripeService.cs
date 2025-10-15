using Kokomija.Entity;
using Stripe;

namespace Kokomija.Services
{
    public interface IStripeService
    {
        Task<Customer> CreateCustomerAsync(string email, string name, Dictionary<string, string>? metadata = null);
        Task<Customer> UpdateCustomerAsync(string customerId, string? email = null, string? name = null);
        Task<Customer> GetCustomerAsync(string customerId);
        Task<Stripe.Product> CreateProductAsync(Entity.Product product);
        Task<Price> CreatePriceAsync(string stripeProductId, decimal amount, string currency = "pln");
        Task<Stripe.Product> UpdateProductAsync(string stripeProductId, Entity.Product product);
        Task<Price> CreateVariantPriceAsync(ProductVariant variant, string currency = "pln");
        Task<PaymentIntent> CreatePaymentIntentAsync(decimal amount, string currency = "pln", Dictionary<string, string>? metadata = null, string? customerId = null);
        Task<PaymentIntent> ConfirmPaymentIntentAsync(string paymentIntentId);
        Task<Refund> CreateRefundAsync(string chargeId, long? amount = null);
        Task<Stripe.Coupon> CreateStripeCouponAsync(Entity.Coupon coupon);
        Task<PromotionCode> CreateStripePromotionCodeAsync(string stripeCouponId, string code);
        Task<Stripe.Coupon> GetStripeCouponAsync(string couponId);
    }

    public class StripeService : IStripeService
    {
        private readonly IConfiguration _configuration;
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly PriceService _priceService;
        private readonly PaymentIntentService _paymentIntentService;
        private readonly RefundService _refundService;
        private readonly CouponService _couponService;
        private readonly PromotionCodeService _promotionCodeService;

        public StripeService(IConfiguration configuration)
        {
            _configuration = configuration;
            _customerService = new CustomerService();
            _productService = new ProductService();
            _priceService = new PriceService();
            _paymentIntentService = new PaymentIntentService();
            _refundService = new RefundService();
            _couponService = new CouponService();
            _promotionCodeService = new PromotionCodeService();
        }

        public async Task<Customer> CreateCustomerAsync(string email, string name, Dictionary<string, string>? metadata = null)
        {
            var options = new CustomerCreateOptions
            {
                Email = email,
                Name = name,
                Metadata = metadata ?? new Dictionary<string, string>()
            };

            return await _customerService.CreateAsync(options);
        }

        public async Task<Customer> UpdateCustomerAsync(string customerId, string? email = null, string? name = null)
        {
            var options = new CustomerUpdateOptions
            {
                Email = email,
                Name = name
            };

            return await _customerService.UpdateAsync(customerId, options);
        }

        public async Task<Customer> GetCustomerAsync(string customerId)
        {
            return await _customerService.GetAsync(customerId);
        }

        public async Task<Stripe.Product> CreateProductAsync(Entity.Product product)
        {
            var options = new ProductCreateOptions
            {
                Name = product.Name,
                Description = product.Description,
                Active = product.IsActive,
                Metadata = new Dictionary<string, string>
                {
                    { "product_id", product.Id.ToString() },
                    { "category_id", product.CategoryId?.ToString() ?? "" }
                }
            };

            return await _productService.CreateAsync(options);
        }

        public async Task<Price> CreatePriceAsync(string stripeProductId, decimal amount, string currency = "pln")
        {
            var options = new PriceCreateOptions
            {
                Product = stripeProductId,
                UnitAmount = (long)(amount * 100), // Convert to cents
                Currency = currency,
            };

            return await _priceService.CreateAsync(options);
        }

        public async Task<Stripe.Product> UpdateProductAsync(string stripeProductId, Entity.Product product)
        {
            var options = new ProductUpdateOptions
            {
                Name = product.Name,
                Description = product.Description,
                Active = product.IsActive,
                Metadata = new Dictionary<string, string>
                {
                    { "product_id", product.Id.ToString() },
                    { "category_id", product.CategoryId?.ToString() ?? "" }
                }
            };

            return await _productService.UpdateAsync(stripeProductId, options);
        }

        public async Task<Price> CreateVariantPriceAsync(ProductVariant variant, string currency = "pln")
        {
            var options = new PriceCreateOptions
            {
                Product = variant.Product.StripeProductId,
                UnitAmount = (long)(variant.Price * 100), // Convert to cents
                Currency = currency,
                Metadata = new Dictionary<string, string>
                {
                    { "variant_id", variant.Id.ToString() },
                    { "sku", variant.SKU },
                    { "size", variant.Size?.Name ?? "" },
                    { "color", variant.Color?.Name ?? "" }
                }
            };

            return await _priceService.CreateAsync(options);
        }

        public async Task<PaymentIntent> CreatePaymentIntentAsync(decimal amount, string currency = "pln", Dictionary<string, string>? metadata = null, string? customerId = null)
        {
            var commissionRate = _configuration.GetValue<decimal>("Commission:DefaultRate");
            var commissionAmount = (long)(amount * commissionRate * 100); // Convert to cents

            var options = new PaymentIntentCreateOptions
            {
                Amount = (long)(amount * 100), // Convert to cents
                Currency = currency,
                Customer = customerId,
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
                Metadata = metadata ?? new Dictionary<string, string>(),
                ApplicationFeeAmount = commissionAmount, // Your 1.5% commission
            };

            options.Metadata.Add("commission_rate", commissionRate.ToString());
            options.Metadata.Add("commission_amount", (commissionAmount / 100m).ToString());

            return await _paymentIntentService.CreateAsync(options);
        }

        public async Task<PaymentIntent> ConfirmPaymentIntentAsync(string paymentIntentId)
        {
            return await _paymentIntentService.ConfirmAsync(paymentIntentId);
        }

        public async Task<Refund> CreateRefundAsync(string chargeId, long? amount = null)
        {
            var options = new RefundCreateOptions
            {
                Charge = chargeId,
                Amount = amount, // If null, refunds the full amount
            };

            return await _refundService.CreateAsync(options);
        }

        public async Task<Stripe.Coupon> CreateStripeCouponAsync(Entity.Coupon coupon)
        {
            var options = new CouponCreateOptions();

            if (coupon.DiscountType == "percentage")
            {
                options.PercentOff = coupon.DiscountValue;
            }
            else if (coupon.DiscountType == "fixed_amount")
            {
                options.AmountOff = (long)(coupon.DiscountValue * 100); // Convert to cents
                options.Currency = "pln";
            }

            options.Name = coupon.Code;
            options.Duration = "once"; // Can be 'once', 'repeating', or 'forever'

            if (coupon.MaximumDiscountAmount.HasValue)
            {
                options.MaxRedemptions = coupon.UsageLimit;
            }

            options.Metadata = new Dictionary<string, string>
            {
                { "coupon_id", coupon.Id.ToString() },
                { "code", coupon.Code }
            };

            return await _couponService.CreateAsync(options);
        }

        public async Task<PromotionCode> CreateStripePromotionCodeAsync(string stripeCouponId, string code)
        {
            var options = new PromotionCodeCreateOptions
            {
                Coupon = stripeCouponId,
                Code = code,
                Active = true
            };

            return await _promotionCodeService.CreateAsync(options);
        }

        public async Task<Stripe.Coupon> GetStripeCouponAsync(string couponId)
        {
            return await _couponService.GetAsync(couponId);
        }
    }
}
