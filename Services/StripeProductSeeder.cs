using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Kokomija.Services
{
    public interface IStripeProductSeeder
    {
        Task SeedProductsToStripeAsync();
        Task SeedStripeConfigurationAsync();
    }

    public class StripeProductSeeder : IStripeProductSeeder
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStripeService _stripeService;
        private readonly ILogger<StripeProductSeeder> _logger;
        private readonly IPriceHistoryService _priceHistoryService;

        public StripeProductSeeder(
            IUnitOfWork unitOfWork,
            IStripeService stripeService,
            ILogger<StripeProductSeeder> logger,
            IPriceHistoryService priceHistoryService)
        {
            _unitOfWork = unitOfWork;
            _stripeService = stripeService;
            _logger = logger;
            _priceHistoryService = priceHistoryService;
        }

        public async Task SeedProductsToStripeAsync()
        {
            try
            {
                _logger.LogInformation("Starting Stripe product seeding...");

                // Get all products from database
                var allProducts = await _unitOfWork.Products.GetAllAsync();
                
                // Get all products from Stripe to check for existing products
                var stripeService = new Stripe.ProductService();
                var stripePriceService = new Stripe.PriceService();
                var stripeProducts = await stripeService.ListAsync(new Stripe.ProductListOptions { Limit = 100, Active = true });
                
                // Process all products (both with and without Stripe IDs)
                var products = allProducts.ToList();

                if (!products.Any())
                {
                    _logger.LogInformation("No products to process.");
                    return;
                }

                foreach (var product in products)
                {
                    try
                    {
                        _logger.LogInformation($"Processing product: {product.Name} (Price: {product.Price} PLN)");

                        // If product already has a Stripe ID, verify and update it
                        if (!string.IsNullOrEmpty(product.StripeProductId))
                        {
                            try
                            {
                                var existingProduct = await stripeService.GetAsync(product.StripeProductId);
                                if (existingProduct != null)
                                {
                                    _logger.LogInformation($"Updating existing Stripe product: {product.StripeProductId}");
                                    await _stripeService.UpdateProductAsync(product.StripeProductId, product);
                                    
                                    // Check if price needs updating
                                    var prices = await stripePriceService.ListAsync(new Stripe.PriceListOptions
                                    {
                                        Product = product.StripeProductId,
                                        Active = true,
                                        Limit = 10
                                    });
                                    
                                    var productPriceInGrosze = (long)(product.Price * 100);
                                    var matchingPrice = prices.Data.FirstOrDefault(p => 
                                        p.Currency == "pln" && 
                                        p.UnitAmount == productPriceInGrosze);
                                    
                                    if (matchingPrice != null)
                                    {
                                        product.StripePriceId = matchingPrice.Id;
                                    }
                                    else
                                    {
                                        // Create new price if none matches
                                        var newPrice = await _stripeService.CreatePriceAsync(product.StripeProductId, product.Price, "pln");
                                        product.StripePriceId = newPrice.Id;
                                    }
                                    
                                    await _unitOfWork.SaveChangesAsync();
                                    continue; // Skip to next product
                                }
                            }
                            catch (StripeException ex) when (ex.StripeError?.Type == "invalid_request_error")
                            {
                                _logger.LogWarning($"Stripe product {product.StripeProductId} not found, will create new one");
                                product.StripeProductId = string.Empty; // Clear invalid ID
                            }
                        }

                        // Check if a Stripe product with the same price already exists
                        Stripe.Product? matchingStripeProduct = null;
                        foreach (var stripeProduct in stripeProducts.Data)
                        {
                            // Get prices for this Stripe product
                            var prices = await stripePriceService.ListAsync(new Stripe.PriceListOptions
                            {
                                Product = stripeProduct.Id,
                                Active = true,
                                Limit = 10
                            });

                            // Check if any price matches our product price (convert PLN to grosze)
                            var productPriceInGrosze = (long)(product.Price * 100);
                            var matchingPrice = prices.Data.FirstOrDefault(p => 
                                p.Currency == "pln" && 
                                p.UnitAmount == productPriceInGrosze);

                            if (matchingPrice != null)
                            {
                                matchingStripeProduct = stripeProduct;
                                product.StripeProductId = stripeProduct.Id;
                                product.StripePriceId = matchingPrice.Id;
                                _logger.LogInformation($"Found existing Stripe product: {stripeProduct.Id} with matching price");
                                break;
                            }
                        }

                        // If no matching Stripe product found, create a new one
                        if (matchingStripeProduct == null)
                        {
                            _logger.LogInformation($"Creating new Stripe product for: {product.Name}");

                            // Create Stripe product
                            var stripeProduct = await _stripeService.CreateProductAsync(product);
                            product.StripeProductId = stripeProduct.Id;

                            // Create a default price for the product (base price)
                            var stripePrice = await _stripeService.CreatePriceAsync(
                                stripeProduct.Id, 
                                product.Price, 
                                "pln"
                            );
                            product.StripePriceId = stripePrice.Id;

                            _logger.LogInformation($"Created Stripe product: {stripeProduct.Id} with price: {stripePrice.Id}");
                            
                            // Save to price history
                            await _priceHistoryService.SavePriceHistoryAsync(product.Id, 0, product.Price, "Initial Stripe product creation", "System");
                        }
                        else
                        {
                            _logger.LogInformation($"Using existing Stripe product, skipping creation");
                        }

                        // Update all variants to use the same price
                        var allVariants = await _unitOfWork.ProductVariants.GetAllAsync();
                        var variants = allVariants.Where(v => v.ProductId == product.Id).ToList();

                        foreach (var variant in variants)
                        {
                            // All variants share the same product price
                            variant.StripePriceId = product.StripePriceId;
                        }

                        await _unitOfWork.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Failed to create Stripe product for: {product.Name}");
                    }
                }

                _logger.LogInformation("Stripe product seeding completed.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Stripe product seeding");
                throw;
            }
        }

        public async Task SeedStripeConfigurationAsync()
        {
            try
            {
                _logger.LogInformation("Starting Stripe configuration seeding...");

                // Check if coupons already exist in database - if so, skip coupon seeding
                var existingDbCoupons = await _unitOfWork.Coupons.GetAllAsync();
                bool skipCouponSeeding = existingDbCoupons.Any();
                
                if (skipCouponSeeding)
                {
                    _logger.LogInformation("Coupons already exist in database, skipping coupon seeding to avoid duplicates.");
                }

                // 1. Create or verify 23% VAT tax rate
                var taxRateService = new Stripe.TaxRateService();
                var existingTaxRates = await taxRateService.ListAsync(new Stripe.TaxRateListOptions
                {
                    Active = true,
                    Limit = 100
                });

                var vat23Rate = existingTaxRates.Data.FirstOrDefault(t => 
                    t.Percentage == 23.0m && 
                    t.Jurisdiction == "PL" && 
                    t.DisplayName == "VAT");

                if (vat23Rate == null)
                {
                    _logger.LogInformation("Creating 23% VAT tax rate...");
                    var taxRateOptions = new Stripe.TaxRateCreateOptions
                    {
                        DisplayName = "VAT",
                        Description = "Poland VAT 23%",
                        Jurisdiction = "PL",
                        Percentage = 23.0m,
                        Inclusive = true, // VAT is included in price
                        Active = true
                    };
                    vat23Rate = await taxRateService.CreateAsync(taxRateOptions);
                    _logger.LogInformation($"Created VAT tax rate: {vat23Rate.Id}");
                }
                else
                {
                    _logger.LogInformation($"VAT 23% tax rate already exists: {vat23Rate.Id}");
                }

                // 2. Create or verify 9.99 PLN shipping rate
                var shippingRateService = new Stripe.ShippingRateService();
                var existingShippingRates = await shippingRateService.ListAsync(new Stripe.ShippingRateListOptions
                {
                    Active = true,
                    Limit = 100
                });

                var standardShipping = existingShippingRates.Data.FirstOrDefault(s => 
                    s.DisplayName == "Standard Shipping" && 
                    s.FixedAmount?.Amount == 999 && // 9.99 PLN in grosze
                    s.FixedAmount?.Currency == "pln");

                if (standardShipping == null)
                {
                    _logger.LogInformation("Creating standard shipping rate (9.99 PLN)...");
                    var shippingRateOptions = new Stripe.ShippingRateCreateOptions
                    {
                        DisplayName = "Standard Shipping",
                        Type = "fixed_amount",
                        FixedAmount = new Stripe.ShippingRateFixedAmountOptions
                        {
                            Amount = 999, // 9.99 PLN in grosze
                            Currency = "pln"
                        },
                        DeliveryEstimate = new Stripe.ShippingRateDeliveryEstimateOptions
                        {
                            Minimum = new Stripe.ShippingRateDeliveryEstimateMinimumOptions
                            {
                                Unit = "business_day",
                                Value = 3
                            },
                            Maximum = new Stripe.ShippingRateDeliveryEstimateMaximumOptions
                            {
                                Unit = "business_day",
                                Value = 7
                            }
                        },
                        TaxBehavior = "exclusive" // Tax calculated separately
                    };
                    standardShipping = await shippingRateService.CreateAsync(shippingRateOptions);
                    _logger.LogInformation($"Created shipping rate: {standardShipping.Id}");
                }
                else
                {
                    _logger.LogInformation($"Standard shipping rate already exists: {standardShipping.Id}");
                }

                // 3. Create or verify WELCOME10 coupon (only if not skipping)
                if (!skipCouponSeeding)
                {
                    var couponService = new Stripe.CouponService();
                    Stripe.Coupon? welcomeCoupon = null;

                    try
                    {
                        welcomeCoupon = await couponService.GetAsync("WELCOME10");
                        _logger.LogInformation($"WELCOME10 coupon already exists: {welcomeCoupon.Id}");
                    }
                    catch (StripeException ex) when (ex.StripeError?.Code == "resource_missing")
                    {
                        _logger.LogInformation("Creating WELCOME10 coupon...");
                        var couponOptions = new Stripe.CouponCreateOptions
                        {
                            Id = "WELCOME10",
                            Name = "Welcome 10% Off",
                            PercentOff = 10,
                            Duration = "once",
                            MaxRedemptions = 1000,
                            Currency = "pln"
                        };
                        welcomeCoupon = await couponService.CreateAsync(couponOptions);
                        _logger.LogInformation($"Created coupon: {welcomeCoupon.Id}");
                    }

                    // 4. Create promotion code for the coupon
                    var promoCodeService = new Stripe.PromotionCodeService();
                    var existingPromoCodes = await promoCodeService.ListAsync(new Stripe.PromotionCodeListOptions
                    {
                        Coupon = welcomeCoupon.Id,
                        Active = true,
                        Limit = 10
                    });

                    var welcomePromoCode = existingPromoCodes.Data.FirstOrDefault(p => p.Code == "WELCOME10");

                    if (welcomePromoCode == null)
                    {
                        _logger.LogInformation("Creating WELCOME10 promotion code...");
                        var promoCodeOptions = new Stripe.PromotionCodeCreateOptions
                        {
                            Code = "WELCOME10",
                            Promotion = new Stripe.PromotionCodePromotionOptions
                            {
                                Type = "coupon",
                                Coupon = welcomeCoupon.Id
                            },
                            Active = true,
                            MaxRedemptions = 1000,
                            Restrictions = new Stripe.PromotionCodeRestrictionsOptions
                            {
                                FirstTimeTransaction = true,
                                MinimumAmount = 5000, // 50.00 PLN in grosze
                                MinimumAmountCurrency = "pln"
                            }
                        };
                        welcomePromoCode = await promoCodeService.CreateAsync(promoCodeOptions);
                        _logger.LogInformation($"Created promotion code: {welcomePromoCode.Id}");
                    }
                    else
                    {
                        _logger.LogInformation($"WELCOME10 promotion code already exists: {welcomePromoCode.Id}");
                    }

                    // Update database coupon with Stripe IDs
                    var dbCoupons = await _unitOfWork.Coupons.GetAllAsync();
                    var welcomeDbCoupon = dbCoupons.FirstOrDefault(c => c.Code == "WELCOME10");
                    
                    if (welcomeDbCoupon != null)
                    {
                        welcomeDbCoupon.StripeCouponId = welcomeCoupon.Id;
                        welcomeDbCoupon.StripePromotionCodeId = welcomePromoCode.Id;
                        await _unitOfWork.SaveChangesAsync();
                        _logger.LogInformation("Updated database coupon with Stripe IDs");
                    }

                    _logger.LogInformation("Stripe configuration seeding completed successfully!");
                    _logger.LogInformation($"  - VAT Tax Rate: {vat23Rate.Id} (23%)");
                    _logger.LogInformation($"  - Shipping Rate: {standardShipping.Id} (9.99 PLN)");
                    _logger.LogInformation($"  - Coupon: {welcomeCoupon.Id}");
                    _logger.LogInformation($"  - Promotion Code: {welcomePromoCode.Id}");
                }
                else
                {
                    _logger.LogInformation("Stripe configuration seeding completed successfully!");
                    _logger.LogInformation($"  - VAT Tax Rate: {vat23Rate.Id} (23%)");
                    _logger.LogInformation($"  - Shipping Rate: {standardShipping.Id} (9.99 PLN)");
                    _logger.LogInformation("  - Coupon seeding skipped (coupons already exist in database)");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during Stripe configuration seeding");
                throw;
            }
        }
    }
}
