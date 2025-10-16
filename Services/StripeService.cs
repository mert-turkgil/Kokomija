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
        Task<Stripe.Checkout.Session> CreateCheckoutSessionAsync(List<Stripe.Checkout.SessionLineItemOptions> lineItems, string successUrl, string cancelUrl, string? customerId = null, Dictionary<string, string>? metadata = null);
        Task<Stripe.Checkout.Session> GetCheckoutSessionAsync(string sessionId);
        Task<Stripe.PaymentMethod> GetPaymentMethodAsync(string paymentMethodId);
        Task<Stripe.PaymentMethod> AttachPaymentMethodToCustomerAsync(string paymentMethodId, string customerId);
        Task<Stripe.PaymentMethod> DetachPaymentMethodAsync(string paymentMethodId);
        Task<List<Stripe.PaymentMethod>> ListCustomerPaymentMethodsAsync(string customerId);
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
        private readonly Stripe.Checkout.SessionService _checkoutSessionService;
        private readonly PaymentMethodService _paymentMethodService;

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
            _checkoutSessionService = new Stripe.Checkout.SessionService();
            _paymentMethodService = new PaymentMethodService();
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

        /// <summary>
        /// Create a Stripe Checkout Session (for FREE tier - no Billing Portal needed)
        /// </summary>
        public async Task<Stripe.Checkout.Session> CreateCheckoutSessionAsync(
            List<Stripe.Checkout.SessionLineItemOptions> lineItems,
            string successUrl,
            string cancelUrl,
            string? customerId = null,
            Dictionary<string, string>? metadata = null)
        {
            var options = new Stripe.Checkout.SessionCreateOptions
            {
                LineItems = lineItems,
                Mode = "payment", // one-time payment
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
                PaymentMethodTypes = new List<string> { "card" }, // FREE tier supports cards
                
                // Collect shipping address automatically
                ShippingAddressCollection = new Stripe.Checkout.SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> 
                    { 
                        "PL", // Poland
                        "DE", // Germany
                        "FR", // France
                        "IT", // Italy
                        "ES", // Spain
                        "GB", // United Kingdom
                        "US", // United States
                        // Add more countries as needed
                    }
                },

                // Collect billing address
                BillingAddressCollection = "required",

                // Collect phone number
                PhoneNumberCollection = new Stripe.Checkout.SessionPhoneNumberCollectionOptions
                {
                    Enabled = true
                },

                // Customer email
                CustomerEmail = customerId == null ? null : null, // If no customer, we'll provide email field
                
                // If customer exists, attach to them
                Customer = customerId,

                // Save payment method for future use (FREE for Checkout)
                PaymentIntentData = new Stripe.Checkout.SessionPaymentIntentDataOptions
                {
                    SetupFutureUsage = "on_session", // Save card for logged-in users
                    Metadata = metadata ?? new Dictionary<string, string>()
                },

                // Metadata
                Metadata = metadata ?? new Dictionary<string, string>(),

                // Automatic tax calculation (FREE tier - basic tax)
                AutomaticTax = new Stripe.Checkout.SessionAutomaticTaxOptions
                {
                    Enabled = true // Stripe handles EU VAT automatically
                },

                // Allow promotion codes
                AllowPromotionCodes = true,

                // Locale
                Locale = "pl", // Polish by default

                // Customer update (allow updating email and address)
                CustomerUpdate = customerId != null ? new Stripe.Checkout.SessionCustomerUpdateOptions
                {
                    Address = "auto",
                    Name = "auto",
                    Shipping = "auto"
                } : null
            };

            return await _checkoutSessionService.CreateAsync(options);
        }

        /// <summary>
        /// Get Checkout Session details
        /// </summary>
        public async Task<Stripe.Checkout.Session> GetCheckoutSessionAsync(string sessionId)
        {
            var options = new Stripe.Checkout.SessionGetOptions();
            options.AddExpand("line_items");
            options.AddExpand("customer");
            options.AddExpand("payment_intent");
            options.AddExpand("shipping_details");

            return await _checkoutSessionService.GetAsync(sessionId, options);
        }

        /// <summary>
        /// Get payment method details
        /// </summary>
        public async Task<Stripe.PaymentMethod> GetPaymentMethodAsync(string paymentMethodId)
        {
            return await _paymentMethodService.GetAsync(paymentMethodId);
        }

        /// <summary>
        /// Attach payment method to customer (for saving cards)
        /// </summary>
        public async Task<Stripe.PaymentMethod> AttachPaymentMethodToCustomerAsync(string paymentMethodId, string customerId)
        {
            var options = new PaymentMethodAttachOptions
            {
                Customer = customerId
            };

            return await _paymentMethodService.AttachAsync(paymentMethodId, options);
        }

        /// <summary>
        /// Detach payment method from customer (remove saved card)
        /// </summary>
        public async Task<Stripe.PaymentMethod> DetachPaymentMethodAsync(string paymentMethodId)
        {
            return await _paymentMethodService.DetachAsync(paymentMethodId);
        }

        /// <summary>
        /// List all payment methods for a customer
        /// </summary>
        public async Task<List<Stripe.PaymentMethod>> ListCustomerPaymentMethodsAsync(string customerId)
        {
            var options = new PaymentMethodListOptions
            {
                Customer = customerId,
                Type = "card" // Only cards for now
            };

            var paymentMethods = await _paymentMethodService.ListAsync(options);
            return paymentMethods.Data.ToList();
        }
    }
}
