using Kokomija.Entity;
using Stripe;
using Microsoft.Extensions.Logging;

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
        Task<PromotionCode> CreateStripePromotionCodeWithRestrictionsAsync(string stripeCouponId, string code, int? maxRedemptions = null, int? maxRedemptionsPerCustomer = null, DateTime? expiresAt = null, decimal? minimumAmount = null);
        Task<PromotionCode> UpdateStripePromotionCodeAsync(string promotionCodeId, bool isActive);
        Task<Stripe.Coupon> GetStripeCouponAsync(string couponId);
        Task<PromotionCode?> GetStripePromotionCodeAsync(string promotionCodeId);
        Task<(int TimesRedeemed, bool Valid, long? RedeemBy)?> GetStripeCouponInfoAsync(string couponId);
        Task<(int TimesRedeemed, bool IsActive)?> SyncCouponUsageFromStripeAsync(Entity.Coupon coupon);
        Task<IEnumerable<Stripe.Coupon>> ListAllStripeCouponsAsync(int limit = 100);
        Task<IEnumerable<PromotionCode>> ListAllStripePromotionCodesAsync(int limit = 100);
        Task<Stripe.Checkout.Session> CreateCheckoutSessionAsync(List<Stripe.Checkout.SessionLineItemOptions> lineItems, string successUrl, string cancelUrl, string? customerId = null, Dictionary<string, string>? metadata = null);
        Task<Stripe.Checkout.Session> GetCheckoutSessionAsync(string sessionId);
        Task<Stripe.PaymentMethod> GetPaymentMethodAsync(string paymentMethodId);
        Task<Stripe.PaymentMethod> AttachPaymentMethodToCustomerAsync(string paymentMethodId, string customerId);
        Task<Stripe.PaymentMethod> DetachPaymentMethodAsync(string paymentMethodId);
        Task<List<Stripe.PaymentMethod>> ListCustomerPaymentMethodsAsync(string customerId);
        Task<Stripe.Coupon> CreateProductCouponAsync(Entity.Coupon coupon, string stripeProductId);
        Task DeleteStripeCouponAsync(string couponId);
        Task DeleteStripeProductAsync(string stripeProductId);
        Task ArchiveStripeProductAsync(string stripeProductId);
    }

    public class StripeService : IStripeService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<StripeService> _logger;
        private readonly CustomerService _customerService;
        private readonly ProductService _productService;
        private readonly PriceService _priceService;
        private readonly PaymentIntentService _paymentIntentService;
        private readonly RefundService _refundService;
        private readonly CouponService _couponService;
        private readonly PromotionCodeService _promotionCodeService;
        private readonly Stripe.Checkout.SessionService _checkoutSessionService;
        private readonly PaymentMethodService _paymentMethodService;

        public StripeService(IConfiguration configuration, ILogger<StripeService> logger)
        {
            _configuration = configuration;
            _logger = logger;
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
            // Get the primary image URL for Stripe
            var primaryImage = product.Images?.OrderBy(i => i.DisplayOrder).FirstOrDefault();
            var imageUrls = new List<string>();
            
            if (primaryImage != null && !string.IsNullOrEmpty(primaryImage.ImageUrl))
            {
                // Stripe requires full HTTPS URLs for images
                // Use a placeholder or your actual domain
                var baseUrl = _configuration.GetValue<string>("AppSettings:BaseUrl") ?? "https://kokomija.com";
                var imageUrl = $"{baseUrl}/img/ProductImage/{primaryImage.ImageUrl}";
                imageUrls.Add(imageUrl);
            }
            
            var options = new ProductCreateOptions
            {
                Name = product.Name,
                Description = product.Description,
                Active = product.IsActive,
                TaxCode = product.StripeTaxCode ?? "txcd_99999999", // Default: General tangible goods
                Metadata = new Dictionary<string, string>
                {
                    { "product_id", product.Id.ToString() },
                    { "category_id", product.CategoryId?.ToString() ?? "" },
                    { "pack_size", product.PackSize.ToString() }
                }
            };
            
            // Only add images if we have at least one (Stripe requires valid URLs)
            if (imageUrls.Any())
            {
                options.Images = imageUrls;
            }

            return await _productService.CreateAsync(options);
        }

        public async Task<Price> CreatePriceAsync(string stripeProductId, decimal amount, string currency = "pln")
        {
            var options = new PriceCreateOptions
            {
                Product = stripeProductId,
                UnitAmount = (long)(amount * 100), // Convert to cents
                Currency = currency,
                TaxBehavior = "exclusive", // Tax is added on top of price (23% VAT)
            };

            return await _priceService.CreateAsync(options);
        }

        public async Task<Stripe.Product> UpdateProductAsync(string stripeProductId, Entity.Product product)
        {
            // Get the primary image URL for Stripe
            var primaryImage = product.Images?.OrderBy(i => i.DisplayOrder).FirstOrDefault();
            var imageUrls = new List<string>();
            
            if (primaryImage != null && !string.IsNullOrEmpty(primaryImage.ImageUrl))
            {
                var baseUrl = _configuration.GetValue<string>("AppSettings:BaseUrl") ?? "https://kokomija.com";
                var imageUrl = $"{baseUrl}/img/ProductImage/{primaryImage.ImageUrl}";
                imageUrls.Add(imageUrl);
            }
            
            var options = new ProductUpdateOptions
            {
                Name = product.Name,
                Description = product.Description,
                Active = product.IsActive,
                TaxCode = product.StripeTaxCode ?? "txcd_99999999", // Default: General tangible goods
                Metadata = new Dictionary<string, string>
                {
                    { "product_id", product.Id.ToString() },
                    { "category_id", product.CategoryId?.ToString() ?? "" },
                    { "pack_size", product.PackSize.ToString() }
                }
            };
            
            // Update images if available
            if (imageUrls.Any())
            {
                options.Images = imageUrls;
            }

            return await _productService.UpdateAsync(stripeProductId, options);
        }

        public async Task<Price> CreateVariantPriceAsync(ProductVariant variant, string currency = "pln")
        {
            var options = new PriceCreateOptions
            {
                Product = variant.Product.StripeProductId,
                UnitAmount = (long)(variant.Price * 100), // Convert to cents
                Currency = currency,
                TaxBehavior = "exclusive", // Tax is added on top of price (23% VAT)
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

            // Set discount type and value
            if (coupon.DiscountType == "percentage")
            {
                options.PercentOff = coupon.DiscountValue;
            }
            else if (coupon.DiscountType == "fixed_amount")
            {
                options.AmountOff = (long)(coupon.DiscountValue * 100); // Convert to cents/grosz
                options.Currency = "pln";
            }

            // Set name (description in Stripe)
            options.Name = !string.IsNullOrEmpty(coupon.Description) ? coupon.Description : coupon.Code;
            
            // Coupon duration - Stripe requires this
            // "once" = applies once per customer subscription
            // "forever" = applies indefinitely 
            // "repeating" = applies for specified number of months
            options.Duration = "once";

            // Set max redemptions (total usage limit across all customers)
            if (coupon.UsageLimit.HasValue)
            {
                options.MaxRedemptions = coupon.UsageLimit.Value;
            }

            // Set redemption deadline (valid until date)
            if (coupon.ValidUntil.HasValue)
            {
                options.RedeemBy = coupon.ValidUntil.Value;
            }

            // Metadata for tracking
            options.Metadata = new Dictionary<string, string>
            {
                { "coupon_id", coupon.Id.ToString() },
                { "code", coupon.Code },
                { "coupon_type", coupon.CouponType ?? "general" }
            };

            if (!string.IsNullOrEmpty(coupon.VipTierRequired))
            {
                options.Metadata["vip_tier_required"] = coupon.VipTierRequired;
            }

            if (coupon.CategoryId.HasValue)
            {
                options.Metadata["category_id"] = coupon.CategoryId.Value.ToString();
            }

            if (coupon.ProductId.HasValue)
            {
                options.Metadata["product_id"] = coupon.ProductId.Value.ToString();
            }

            return await _couponService.CreateAsync(options);
        }

        public async Task<PromotionCode> CreateStripePromotionCodeAsync(string stripeCouponId, string code)
        {
            var options = new PromotionCodeCreateOptions
            {
                Code = code,
                Active = true
            };
            options.AddExtraParam("coupon", stripeCouponId);

            return await _promotionCodeService.CreateAsync(options);
        }

        /// <summary>
        /// Create promotion code with restrictions (usage limits per customer)
        /// </summary>
        public async Task<PromotionCode> CreateStripePromotionCodeWithRestrictionsAsync(
            string stripeCouponId, 
            string code, 
            int? maxRedemptions = null,
            int? maxRedemptionsPerCustomer = null,
            DateTime? expiresAt = null,
            decimal? minimumAmount = null)
        {
            var options = new PromotionCodeCreateOptions
            {
                Code = code,
                Active = true
            };
            options.AddExtraParam("coupon", stripeCouponId);

            // Per-customer usage limit (e.g., 1 for one-time use per customer)
            if (maxRedemptionsPerCustomer.HasValue)
            {
                options.MaxRedemptions = maxRedemptionsPerCustomer.Value;
            }

            // Set expiration
            if (expiresAt.HasValue)
            {
                options.ExpiresAt = expiresAt.Value;
            }

            // Minimum order restrictions
            if (minimumAmount.HasValue)
            {
                options.Restrictions = new PromotionCodeRestrictionsOptions
                {
                    MinimumAmount = (long)(minimumAmount.Value * 100),
                    MinimumAmountCurrency = "pln"
                };
            }

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

                // Automatic tax calculation disabled (requires Stripe Tax subscription)
                // Tax is calculated in the application and included in line item prices

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
            options.AddExpand("shipping_cost");
            options.AddExpand("total_details");

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

        public async Task<Stripe.Coupon> CreateProductCouponAsync(Entity.Coupon coupon, string stripeProductId)
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
            
            // Restrict to specific product
            options.AppliesTo = new CouponAppliesToOptions
            {
                Products = new List<string> { stripeProductId }
            };

            if (coupon.MaximumDiscountAmount.HasValue)
            {
                options.MaxRedemptions = coupon.UsageLimit;
            }
            
            if (coupon.ValidUntil.HasValue)
            {
                options.RedeemBy = coupon.ValidUntil.Value;
            }

            options.Metadata = new Dictionary<string, string>
            {
                { "coupon_id", coupon.Id.ToString() },
                { "code", coupon.Code },
                { "product_id", stripeProductId }
            };

            return await _couponService.CreateAsync(options);
        }

        public async Task DeleteStripeCouponAsync(string couponId)
        {
            await _couponService.DeleteAsync(couponId);
        }

        public async Task<PromotionCode> UpdateStripePromotionCodeAsync(string promotionCodeId, bool isActive)
        {
            var options = new PromotionCodeUpdateOptions
            {
                Active = isActive
            };
            return await _promotionCodeService.UpdateAsync(promotionCodeId, options);
        }

        public async Task DeleteStripeProductAsync(string stripeProductId)
        {
            await _productService.DeleteAsync(stripeProductId);
        }

        public async Task ArchiveStripeProductAsync(string stripeProductId)
        {
            var options = new ProductUpdateOptions
            {
                Active = false
            };
            await _productService.UpdateAsync(stripeProductId, options);
        }

        /// <summary>
        /// Get promotion code details from Stripe API
        /// </summary>
        public async Task<PromotionCode?> GetStripePromotionCodeAsync(string promotionCodeId)
        {
            try
            {
                return await _promotionCodeService.GetAsync(promotionCodeId);
            }
            catch (StripeException ex) when (ex.StripeError?.Code == "resource_missing")
            {
                return null;
            }
        }

        /// <summary>
        /// Get coupon info from Stripe (includes redemptions count)
        /// </summary>
        public async Task<(int TimesRedeemed, bool Valid, long? RedeemBy)?> GetStripeCouponInfoAsync(string couponId)
        {
            try
            {
                var stripeCoupon = await _couponService.GetAsync(couponId);
                // Convert RedeemBy (DateTime?) to unix timestamp
                long? redeemByTimestamp = stripeCoupon.RedeemBy.HasValue 
                    ? new DateTimeOffset(stripeCoupon.RedeemBy.Value).ToUnixTimeSeconds() 
                    : null;
                return ((int)stripeCoupon.TimesRedeemed, stripeCoupon.Valid, redeemByTimestamp);
            }
            catch (StripeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Sync coupon usage data from Stripe to local database
        /// </summary>
        public async Task<(int TimesRedeemed, bool IsActive)?> SyncCouponUsageFromStripeAsync(Entity.Coupon coupon)
        {
            if (string.IsNullOrEmpty(coupon.StripeCouponId))
                return null;

            try
            {
                var stripeCoupon = await _couponService.GetAsync(coupon.StripeCouponId);
                
                // Update local coupon with Stripe's redemption count
                var timesRedeemed = (int)stripeCoupon.TimesRedeemed;
                var isActive = stripeCoupon.Valid;

                return (timesRedeemed, isActive);
            }
            catch (StripeException ex)
            {
                _logger.LogWarning(ex, "Failed to sync coupon {Code} usage from Stripe", coupon.Code);
                return null;
            }
        }

        /// <summary>
        /// List all Stripe coupons (for admin dashboard sync)
        /// </summary>
        public async Task<IEnumerable<Stripe.Coupon>> ListAllStripeCouponsAsync(int limit = 100)
        {
            var options = new CouponListOptions
            {
                Limit = limit
            };
            var coupons = await _couponService.ListAsync(options);
            return coupons.Data;
        }

        /// <summary>
        /// List all Stripe promotion codes (for admin dashboard sync)  
        /// </summary>
        public async Task<IEnumerable<PromotionCode>> ListAllStripePromotionCodesAsync(int limit = 100)
        {
            var options = new PromotionCodeListOptions
            {
                Limit = limit
            };
            var promotionCodes = await _promotionCodeService.ListAsync(options);
            return promotionCodes.Data;
        }
    }
}
