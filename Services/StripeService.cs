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
        Task<bool> HasCustomerUsedPromotionCodeAsync(string stripeCustomerId, string promotionCodeId);
        Task<List<string>> GetCustomerUsedPromotionCodesAsync(string stripeCustomerId);
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
        Task<(Stripe.Coupon StripeCoupon, PromotionCode PromoCode)> SyncCouponToStripeAsync(Entity.Coupon coupon);
        Task<List<Entity.Coupon>> ImportCouponsFromStripeAsync(IEnumerable<Entity.Coupon> existingCoupons);
        Task DeleteStripeProductAsync(string stripeProductId);
        Task ArchiveStripeProductAsync(string stripeProductId);
        Task<Stripe.ShippingRate> CreateShippingRateAsync(Entity.ShippingRate shippingRate);
        Task<Stripe.ShippingRate> UpdateShippingRateAsync(string stripeShippingRateId, Entity.ShippingRate shippingRate);
        Task<Stripe.ShippingRate> GetShippingRateAsync(string stripeShippingRateId);
        Task<IEnumerable<Stripe.ShippingRate>> ListAllShippingRatesAsync(int limit = 100);
        Task<Dictionary<string, string>> EnsureVipTierCouponsExistAsync();
        Task<string?> GetVipTierStripeCouponIdAsync(string vipTier);
        Task<bool> IsCouponValidOnStripeAsync(string? stripeCouponId);
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
        private readonly ShippingRateService _shippingRateService;

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
            _shippingRateService = new ShippingRateService();
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
                Promotion = new PromotionCodePromotionOptions { Type = "coupon", Coupon = stripeCouponId },
                Code = code,
                Active = true
            };

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
                Promotion = new PromotionCodePromotionOptions { Type = "coupon", Coupon = stripeCouponId },
                Code = code,
                Active = true
            };

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
        /// Check if a customer has used a specific promotion code in Stripe
        /// </summary>
        public async Task<bool> HasCustomerUsedPromotionCodeAsync(string stripeCustomerId, string promotionCodeId)
        {
            if (string.IsNullOrEmpty(stripeCustomerId) || string.IsNullOrEmpty(promotionCodeId))
                return false;

            try
            {
                // Get customer's checkout sessions that were completed
                var sessionService = new Stripe.Checkout.SessionService();
                var sessions = await sessionService.ListAsync(new Stripe.Checkout.SessionListOptions
                {
                    Customer = stripeCustomerId,
                    Limit = 100,
                    Expand = new List<string> { "data.total_details.breakdown" }
                });

                // Check if any session used this promotion code
                foreach (var session in sessions.Data)
                {
                    if (session.Status == "complete" && session.TotalDetails?.Breakdown?.Discounts != null)
                    {
                        foreach (var discount in session.TotalDetails.Breakdown.Discounts)
                        {
                            // PromotionCode is an object, compare by Id
                            var promoCodeId = discount.Discount?.PromotionCode?.Id ?? discount.Discount?.PromotionCodeId;
                            if (promoCodeId == promotionCodeId)
                            {
                                return true;
                            }
                        }
                    }
                }

                return false;
            }
            catch (StripeException ex)
            {
                _logger.LogWarning(ex, "Failed to check promotion code usage for customer {CustomerId}", stripeCustomerId);
                return false;
            }
        }

        /// <summary>
        /// Get list of all promotion codes used by a customer from Stripe
        /// </summary>
        public async Task<List<string>> GetCustomerUsedPromotionCodesAsync(string stripeCustomerId)
        {
            var usedPromotionCodes = new List<string>();
            
            if (string.IsNullOrEmpty(stripeCustomerId))
                return usedPromotionCodes;

            try
            {
                // Get customer's completed checkout sessions
                var sessionService = new Stripe.Checkout.SessionService();
                var sessions = await sessionService.ListAsync(new Stripe.Checkout.SessionListOptions
                {
                    Customer = stripeCustomerId,
                    Limit = 100,
                    Expand = new List<string> { "data.total_details.breakdown" }
                });

                foreach (var session in sessions.Data)
                {
                    if (session.Status == "complete" && session.TotalDetails?.Breakdown?.Discounts != null)
                    {
                        foreach (var discount in session.TotalDetails.Breakdown.Discounts)
                        {
                            // PromotionCode is an object, get the Id
                            var promoCodeId = discount.Discount?.PromotionCode?.Id ?? discount.Discount?.PromotionCodeId;
                            if (!string.IsNullOrEmpty(promoCodeId))
                            {
                                usedPromotionCodes.Add(promoCodeId);
                            }
                        }
                    }
                }

                return usedPromotionCodes.Distinct().ToList();
            }
            catch (StripeException ex)
            {
                _logger.LogWarning(ex, "Failed to get used promotion codes for customer {CustomerId}", stripeCustomerId);
                return usedPromotionCodes;
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

        /// <summary>
        /// Create a Stripe shipping rate
        /// </summary>
        public async Task<Stripe.ShippingRate> CreateShippingRateAsync(Entity.ShippingRate shippingRate)
        {
            try
            {
                var options = new ShippingRateCreateOptions
                {
                    DisplayName = shippingRate.Name,
                    Type = "fixed_amount",
                    FixedAmount = new ShippingRateFixedAmountOptions
                    {
                        Amount = (long)(shippingRate.BasePrice * 100), // Convert to cents
                        Currency = "pln"
                    },
                    DeliveryEstimate = new ShippingRateDeliveryEstimateOptions
                    {
                        Minimum = new ShippingRateDeliveryEstimateMinimumOptions
                        {
                            Unit = "business_day",
                            Value = shippingRate.MinDeliveryDays
                        },
                        Maximum = new ShippingRateDeliveryEstimateMaximumOptions
                        {
                            Unit = "business_day",
                            Value = shippingRate.MaxDeliveryDays
                        }
                    },
                    Metadata = new Dictionary<string, string>
                    {
                        { "kokomija_rate_id", shippingRate.Id.ToString() },
                        { "provider_id", shippingRate.ShippingProviderId.ToString() },
                        { "description", shippingRate.Description ?? "" }
                    }
                };

                var stripeRate = await _shippingRateService.CreateAsync(options);
                _logger.LogInformation("Created Stripe shipping rate {StripeId} for {Name}", stripeRate.Id, shippingRate.Name);
                return stripeRate;
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Failed to create Stripe shipping rate for {Name}", shippingRate.Name);
                throw;
            }
        }

        /// <summary>
        /// Update a Stripe shipping rate (note: most fields are immutable, this updates metadata)
        /// </summary>
        public async Task<Stripe.ShippingRate> UpdateShippingRateAsync(string stripeShippingRateId, Entity.ShippingRate shippingRate)
        {
            try
            {
                var options = new ShippingRateUpdateOptions
                {
                    Active = shippingRate.IsActive,
                    Metadata = new Dictionary<string, string>
                    {
                        { "kokomija_rate_id", shippingRate.Id.ToString() },
                        { "provider_id", shippingRate.ShippingProviderId.ToString() },
                        { "description", shippingRate.Description ?? "" }
                    }
                };

                var stripeRate = await _shippingRateService.UpdateAsync(stripeShippingRateId, options);
                _logger.LogInformation("Updated Stripe shipping rate {StripeId}", stripeShippingRateId);
                return stripeRate;
            }
            catch (StripeException ex)
            {
                _logger.LogError(ex, "Failed to update Stripe shipping rate {StripeId}", stripeShippingRateId);
                throw;
            }
        }

        /// <summary>
        /// Get a Stripe shipping rate
        /// </summary>
        public async Task<Stripe.ShippingRate> GetShippingRateAsync(string stripeShippingRateId)
        {
            return await _shippingRateService.GetAsync(stripeShippingRateId);
        }

        /// <summary>
        /// List all Stripe shipping rates
        /// </summary>
        public async Task<IEnumerable<Stripe.ShippingRate>> ListAllShippingRatesAsync(int limit = 100)
        {
            var options = new ShippingRateListOptions
            {
                Limit = limit,
                Active = true
            };
            var rates = await _shippingRateService.ListAsync(options);
            return rates.Data;
        }

        /// <summary>
        /// Idempotent upsert: finds existing Stripe coupon by metadata coupon_id, updates or creates.
        /// Also ensures a promotion code exists with the correct restrictions.
        /// </summary>
        public async Task<(Stripe.Coupon StripeCoupon, PromotionCode PromoCode)> SyncCouponToStripeAsync(Entity.Coupon coupon)
        {
            Stripe.Coupon? stripeCoupon = null;

            // Try to find existing Stripe coupon by StripeCouponId
            if (!string.IsNullOrEmpty(coupon.StripeCouponId))
            {
                try
                {
                    stripeCoupon = await _couponService.GetAsync(coupon.StripeCouponId);
                }
                catch (StripeException ex) when (ex.StripeError?.Code == "resource_missing")
                {
                    _logger.LogWarning("Stripe coupon {StripeCouponId} not found, will create new one", coupon.StripeCouponId);
                    stripeCoupon = null;
                }
            }

            // If not found by ID, search by metadata
            if (stripeCoupon == null)
            {
                var allCoupons = await ListAllStripeCouponsAsync(100);
                stripeCoupon = allCoupons.FirstOrDefault(sc =>
                    sc.Metadata != null &&
                    sc.Metadata.TryGetValue("coupon_id", out var cid) &&
                    cid == coupon.Id.ToString());
            }

            // Update existing or create new
            if (stripeCoupon != null)
            {
                // Stripe coupons are mostly immutable (can't change discount), but we can update metadata/name
                var updateOptions = new CouponUpdateOptions
                {
                    Name = !string.IsNullOrEmpty(coupon.Description) ? coupon.Description : coupon.Code,
                    Metadata = new Dictionary<string, string>
                    {
                        { "coupon_id", coupon.Id.ToString() },
                        { "code", coupon.Code },
                        { "coupon_type", coupon.CouponType ?? "general" }
                    }
                };

                if (!string.IsNullOrEmpty(coupon.VipTierRequired))
                    updateOptions.Metadata["vip_tier_required"] = coupon.VipTierRequired;
                if (coupon.CategoryId.HasValue)
                    updateOptions.Metadata["category_id"] = coupon.CategoryId.Value.ToString();
                if (coupon.ProductId.HasValue)
                    updateOptions.Metadata["product_id"] = coupon.ProductId.Value.ToString();

                stripeCoupon = await _couponService.UpdateAsync(stripeCoupon.Id, updateOptions);
            }
            else
            {
                stripeCoupon = await CreateStripeCouponAsync(coupon);
            }

            // Ensure promotion code exists
            PromotionCode? promoCode = null;

            if (!string.IsNullOrEmpty(coupon.StripePromotionCodeId))
            {
                promoCode = await GetStripePromotionCodeAsync(coupon.StripePromotionCodeId);
            }

            // Search for existing promotion code by coupon code if not found by ID
            if (promoCode == null)
            {
                // Search by code across all promotion codes for this coupon
                var searchOptions = new PromotionCodeListOptions
                {
                    Limit = 100,
                    Code = coupon.Code
                };
                var matchingPromoCodes = await _promotionCodeService.ListAsync(searchOptions);
                promoCode = matchingPromoCodes.Data.FirstOrDefault();
            }

            if (promoCode != null)
            {
                // Check if restrictions changed — Stripe doesn't allow updating restrictions on promotion codes
                // so we must deactivate old one and create a new one
                bool restrictionsChanged = false;

                // Check minimum amount
                var existingMinAmount = promoCode.Restrictions?.MinimumAmount;
                var newMinAmount = coupon.MinimumOrderAmount.HasValue ? (long)(coupon.MinimumOrderAmount.Value * 100) : (long?)null;
                if (existingMinAmount != newMinAmount)
                    restrictionsChanged = true;

                // Check max redemptions
                if (promoCode.MaxRedemptions != (coupon.UsageLimitPerUser.HasValue ? (long?)coupon.UsageLimitPerUser.Value : null))
                    restrictionsChanged = true;

                // Check expiration
                if (promoCode.ExpiresAt != coupon.ValidUntil)
                    restrictionsChanged = true;

                if (restrictionsChanged)
                {
                    // Deactivate old promotion code
                    await UpdateStripePromotionCodeAsync(promoCode.Id, false);
                    _logger.LogInformation("Deactivated old promotion code {PromoId} for coupon {Code} due to restriction changes",
                        promoCode.Id, coupon.Code);

                    // Create new promotion code with updated restrictions
                    try
                    {
                        promoCode = await CreateStripePromotionCodeWithRestrictionsAsync(
                            stripeCouponId: stripeCoupon.Id,
                            code: coupon.Code,
                            maxRedemptions: coupon.UsageLimit,
                            maxRedemptionsPerCustomer: coupon.UsageLimitPerUser,
                            expiresAt: coupon.ValidUntil,
                            minimumAmount: coupon.MinimumOrderAmount
                        );
                    }
                    catch (StripeException ex) when (ex.StripeError?.Code == "resource_already_exists")
                    {
                        // Code already taken — create with a suffix
                        var newCode = $"{coupon.Code}-{DateTime.UtcNow:yyyyMMddHHmmss}";
                        promoCode = await CreateStripePromotionCodeWithRestrictionsAsync(
                            stripeCouponId: stripeCoupon.Id,
                            code: newCode,
                            maxRedemptions: coupon.UsageLimit,
                            maxRedemptionsPerCustomer: coupon.UsageLimitPerUser,
                            expiresAt: coupon.ValidUntil,
                            minimumAmount: coupon.MinimumOrderAmount
                        );
                        _logger.LogWarning("Created new promotion code with code {NewCode} (original {OrigCode} was taken)",
                            newCode, coupon.Code);
                    }
                }
                else
                {
                    // Only update active status if needed
                    if (promoCode.Active != coupon.IsActive)
                    {
                        promoCode = await UpdateStripePromotionCodeAsync(promoCode.Id, coupon.IsActive);
                    }
                }
            }
            else
            {
                // Create new promotion code with restrictions
                promoCode = await CreateStripePromotionCodeWithRestrictionsAsync(
                    stripeCouponId: stripeCoupon.Id,
                    code: coupon.Code,
                    maxRedemptions: coupon.UsageLimit,
                    maxRedemptionsPerCustomer: coupon.UsageLimitPerUser,
                    expiresAt: coupon.ValidUntil,
                    minimumAmount: coupon.MinimumOrderAmount
                );
            }

            _logger.LogInformation("Synced coupon {Code} with Stripe: CouponId={StripeCouponId}, PromotionCodeId={PromoCodeId}",
                coupon.Code, stripeCoupon.Id, promoCode.Id);

            return (stripeCoupon, promoCode);
        }

        /// <summary>
        /// Import coupons from Stripe that don't exist locally.
        /// Returns list of newly created local Coupon entities (not yet saved to DB).
        /// </summary>
        public async Task<List<Entity.Coupon>> ImportCouponsFromStripeAsync(IEnumerable<Entity.Coupon> existingCoupons)
        {
            var imported = new List<Entity.Coupon>();
            var existingStripeCouponIds = existingCoupons
                .Where(c => !string.IsNullOrEmpty(c.StripeCouponId))
                .Select(c => c.StripeCouponId!)
                .ToHashSet();
            var existingCodes = existingCoupons
                .Select(c => c.Code.ToUpper())
                .ToHashSet();

            var stripeCoupons = await ListAllStripeCouponsAsync(100);
            var stripePromoCodes = await ListAllStripePromotionCodesAsync(100);

            foreach (var sc in stripeCoupons)
            {
                // Skip if already tracked
                if (existingStripeCouponIds.Contains(sc.Id))
                    continue;

                // Also skip if matched by metadata coupon_id
                if (sc.Metadata != null && sc.Metadata.TryGetValue("coupon_id", out var cid))
                {
                    if (existingCoupons.Any(c => c.Id.ToString() == cid))
                        continue;
                }

                // Find promotion code for this Stripe coupon by searching with code from metadata
                var promoCodeStr = sc.Metadata?.GetValueOrDefault("code");
                PromotionCode? relatedPromo = null;
                if (!string.IsNullOrEmpty(promoCodeStr))
                {
                    var searchResult = await _promotionCodeService.ListAsync(new PromotionCodeListOptions
                    {
                        Limit = 5,
                        Code = promoCodeStr
                    });
                    relatedPromo = searchResult.Data.FirstOrDefault();
                }
                // Fallback: search in pre-fetched list by iterating
                if (relatedPromo == null)
                {
                    relatedPromo = stripePromoCodes.FirstOrDefault(pc => pc.Code == (promoCodeStr ?? sc.Id));
                }
                var code = relatedPromo?.Code ?? sc.Metadata?.GetValueOrDefault("code") ?? sc.Id;

                // Skip if a coupon with same code already exists
                if (existingCodes.Contains(code.ToUpper()))
                    continue;

                var newCoupon = new Entity.Coupon
                {
                    Code = code.ToUpper(),
                    Description = sc.Name,
                    DiscountType = sc.PercentOff.HasValue ? "percentage" : "fixed_amount",
                    DiscountValue = sc.PercentOff ?? (sc.AmountOff.HasValue ? sc.AmountOff.Value / 100m : 0),
                    CouponType = sc.Metadata?.GetValueOrDefault("coupon_type") ?? "general",
                    StripeCouponId = sc.Id,
                    StripePromotionCodeId = relatedPromo?.Id,
                    IsActive = sc.Valid,
                    UsageLimit = sc.MaxRedemptions.HasValue ? (int)sc.MaxRedemptions.Value : null,
                    UsageCount = (int)sc.TimesRedeemed,
                    ValidUntil = sc.RedeemBy,
                    CreatedAt = sc.Created,
                    VipTierRequired = sc.Metadata?.GetValueOrDefault("vip_tier_required"),
                    CategoryId = sc.Metadata != null && sc.Metadata.TryGetValue("category_id", out var catId) && int.TryParse(catId, out var catIdInt) ? catIdInt : null,
                    ProductId = sc.Metadata != null && sc.Metadata.TryGetValue("product_id", out var prodId) && int.TryParse(prodId, out var prodIdInt) ? prodIdInt : null
                };

                imported.Add(newCoupon);
                existingCodes.Add(newCoupon.Code);

                _logger.LogInformation("Imported coupon {Code} from Stripe (CouponId={StripeCouponId})", newCoupon.Code, sc.Id);
            }

            return imported;
        }

        /// <summary>
        /// Ensures persistent Stripe coupons exist for each VIP tier.
        /// Returns a dictionary mapping tier name to Stripe coupon ID.
        /// Idempotent — safe to call on every startup.
        /// </summary>
        public async Task<Dictionary<string, string>> EnsureVipTierCouponsExistAsync()
        {
            var tiers = new Dictionary<string, decimal>
            {
                { "Bronze", 2m },
                { "Silver", 5m },
                { "Gold", 8m },
                { "Platinum", 12m }
            };

            var result = new Dictionary<string, string>();

            // List existing coupons and find VIP ones by metadata
            var existingCoupons = await ListAllStripeCouponsAsync(100);

            foreach (var (tier, percent) in tiers)
            {
                var metadataKey = $"vip_tier_auto";
                var existing = existingCoupons.FirstOrDefault(c =>
                    c.Metadata != null &&
                    c.Metadata.TryGetValue(metadataKey, out var val) &&
                    val == tier);

                if (existing != null)
                {
                    result[tier] = existing.Id;
                    _logger.LogInformation("VIP tier coupon already exists for {Tier}: {CouponId}", tier, existing.Id);
                    continue;
                }

                // Create new coupon for this tier
                var options = new CouponCreateOptions
                {
                    PercentOff = percent,
                    Duration = "forever",
                    Name = $"VIP {tier} Discount ({percent}%)",
                    Metadata = new Dictionary<string, string>
                    {
                        { "vip_tier_auto", tier },
                        { "vip_discount_percentage", percent.ToString("F2") }
                    }
                };

                var created = await _couponService.CreateAsync(options);
                result[tier] = created.Id;
                _logger.LogInformation("Created VIP tier coupon for {Tier}: {CouponId}", tier, created.Id);
            }

            return result;
        }

        /// <summary>
        /// Checks whether a Stripe coupon still exists and is valid.
        /// Returns false if the coupon was deleted or is invalid on Stripe.
        /// </summary>
        public async Task<bool> IsCouponValidOnStripeAsync(string? stripeCouponId)
        {
            if (string.IsNullOrEmpty(stripeCouponId))
                return false;

            try
            {
                var stripeCoupon = await _couponService.GetAsync(stripeCouponId);
                return stripeCoupon.Valid;
            }
            catch (StripeException ex) when (ex.StripeError?.Code == "resource_missing")
            {
                return false;
            }
            catch (StripeException)
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves the Stripe coupon ID for a given VIP tier.
        /// Searches existing Stripe coupons by metadata.
        /// </summary>
        public async Task<string?> GetVipTierStripeCouponIdAsync(string vipTier)
        {
            if (string.IsNullOrEmpty(vipTier) || vipTier == "None")
                return null;

            var existingCoupons = await ListAllStripeCouponsAsync(100);
            var match = existingCoupons.FirstOrDefault(c =>
                c.Metadata != null &&
                c.Metadata.TryGetValue("vip_tier_auto", out var val) &&
                val == vipTier);

            return match?.Id;
        }
    }
}

