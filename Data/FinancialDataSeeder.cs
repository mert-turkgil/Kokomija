using Kokomija.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Data;

/// <summary>
/// Runtime seeder for financial demo data - creates orders for testing the Financial Dashboard.
/// Call from Program.cs or admin tools.
/// </summary>
public static class FinancialDataSeeder
{
    private static readonly Random _random = new();

    /// <summary>
    /// Seeds demo financial data if not already present
    /// </summary>
    public static async Task SeedFinancialDataAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var logger = services.GetRequiredService<ILogger<ApplicationDbContext>>();

            // Check if demo data already exists
            if (await context.Orders.AnyAsync(o => o.OrderNumber.StartsWith("DEMO-")))
            {
                logger.LogInformation("Financial demo data already exists. Skipping seed.");
                return;
            }

            logger.LogInformation("Seeding financial demo data...");

            // Get or create demo customer
            var customer = await GetOrCreateDemoCustomerAsync(userManager);

            // Get available product variants
            var variants = await context.ProductVariants
                .Include(v => v.Product)
                    .ThenInclude(p => p.Images)
                .Include(v => v.Size)
                .Include(v => v.Color)
                .Where(v => v.IsActive && v.StockQuantity > 0)
                .Take(10)
                .ToListAsync();

            // If no variants, try to create them from existing products
            if (!variants.Any())
            {
                logger.LogInformation("No product variants found. Creating variants from existing products...");
                variants = await CreateVariantsFromProductsAsync(context);
            }

            if (!variants.Any())
            {
                logger.LogWarning("No products available. Skipping financial data seed.");
                return;
            }

            // Ensure commission settings exist (use demo customer ID)
            await EnsureCommissionSettingsAsync(context, customer.Id);

            // Create orders over the last 90 days
            var orders = GenerateDemoOrders(customer, variants);
            
            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();

            // Create associated financial records
            await CreateFinancialRecordsAsync(context, orders);

            // Create return requests for some orders
            await CreateReturnRequestsAsync(context, orders, customer);

            logger.LogInformation("Successfully created {Count} demo orders with financial records.", orders.Count);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<ApplicationDbContext>>();
            logger.LogError(ex, "Error seeding financial demo data.");
        }
    }

    /// <summary>
    /// Removes all demo financial data
    /// </summary>
    public static async Task RemoveFinancialDataAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var logger = services.GetRequiredService<ILogger<ApplicationDbContext>>();

            var demoOrders = await context.Orders
                .Where(o => o.OrderNumber.StartsWith("DEMO-"))
                .ToListAsync();

            if (!demoOrders.Any())
            {
                logger.LogInformation("No demo data found to remove.");
                return;
            }

            var orderIds = demoOrders.Select(o => o.Id).ToList();

            // Get return request IDs first
            var returnRequestIds = await context.ReturnRequests
                .Where(r => orderIds.Contains(r.OrderId))
                .Select(r => r.Id)
                .ToListAsync();

            // Remove return status history (depends on return requests)
            if (returnRequestIds.Any())
            {
                var returnStatusHistory = await context.ReturnStatusHistories
                    .Where(h => returnRequestIds.Contains(h.ReturnRequestId))
                    .ToListAsync();
                context.ReturnStatusHistories.RemoveRange(returnStatusHistory);

                // Remove return request images (depends on return requests)
                var returnImages = await context.ReturnRequestImages
                    .Where(i => returnRequestIds.Contains(i.ReturnRequestId))
                    .ToListAsync();
                context.ReturnRequestImages.RemoveRange(returnImages);
            }

            // Remove return requests
            var returnRequests = await context.ReturnRequests
                .Where(r => orderIds.Contains(r.OrderId))
                .ToListAsync();
            context.ReturnRequests.RemoveRange(returnRequests);

            // Remove related records
            var developerEarnings = await context.DeveloperEarnings
                .Where(e => orderIds.Contains(e.OrderId))
                .ToListAsync();
            context.DeveloperEarnings.RemoveRange(developerEarnings);

            var adminCommissions = await context.AdminCommissions
                .Where(e => orderIds.Contains(e.OrderId))
                .ToListAsync();
            context.AdminCommissions.RemoveRange(adminCommissions);

            // Remove payment transactions
            var paymentTransactions = await context.PaymentTransactions
                .Where(pt => orderIds.Contains(pt.OrderId ?? 0) || returnRequestIds.Contains(pt.ReturnRequestId ?? 0))
                .ToListAsync();
            context.PaymentTransactions.RemoveRange(paymentTransactions);

            // Get shipment IDs first
            var shipmentIds = await context.OrderShipments
                .Where(s => orderIds.Contains(s.OrderId))
                .Select(s => s.Id)
                .ToListAsync();

            // Remove shipment tracking events
            if (shipmentIds.Any())
            {
                var trackingEvents = await context.ShipmentTrackingEvents
                    .Where(e => shipmentIds.Contains(e.OrderShipmentId))
                    .ToListAsync();
                context.ShipmentTrackingEvents.RemoveRange(trackingEvents);
            }

            // Remove order shipments
            var orderShipments = await context.OrderShipments
                .Where(s => orderIds.Contains(s.OrderId))
                .ToListAsync();
            context.OrderShipments.RemoveRange(orderShipments);

            // Remove order items
            var orderItems = await context.OrderItems
                .Where(i => orderIds.Contains(i.OrderId))
                .ToListAsync();
            context.OrderItems.RemoveRange(orderItems);

            // Remove orders
            context.Orders.RemoveRange(demoOrders);

            await context.SaveChangesAsync();

            // Remove demo customer - but first update any references to them
            var demoCustomer = await userManager.FindByEmailAsync("demo.customer@kokomija.com");
            if (demoCustomer != null)
            {
                // Find an admin user to reassign CommissionSettings.LastModifiedBy
                var adminUsers = await userManager.GetUsersInRoleAsync("Admin");
                var adminUser = adminUsers.FirstOrDefault(u => u.Id != demoCustomer.Id);
                
                // If no other admin, try root user
                if (adminUser == null)
                {
                    var rootUsers = await userManager.GetUsersInRoleAsync("Root");
                    adminUser = rootUsers.FirstOrDefault(u => u.Id != demoCustomer.Id);
                }

                // Update CommissionSettings that reference the demo customer
                if (adminUser != null)
                {
                    var settingsToUpdate = await context.CommissionSettings
                        .Where(cs => cs.LastModifiedBy == demoCustomer.Id)
                        .ToListAsync();

                    foreach (var settings in settingsToUpdate)
                    {
                        settings.LastModifiedBy = adminUser.Id;
                    }

                    if (settingsToUpdate.Any())
                    {
                        await context.SaveChangesAsync();
                    }
                }

                // Remove demo customer's cart items and cart
                var demoCart = await context.Carts
                    .Where(c => c.UserId == demoCustomer.Id)
                    .ToListAsync();
                context.Carts.RemoveRange(demoCart);

                // Remove demo customer's wishlist
                var demoWishlist = await context.Wishlists
                    .Where(w => w.UserId == demoCustomer.Id)
                    .ToListAsync();
                
                // Remove wishlist notifications for demo customer's wishlist items
                var demoWishlistIds = demoWishlist.Select(w => w.Id).ToList();
                if (demoWishlistIds.Any())
                {
                    var demoWishlistNotifications = await context.WishlistNotifications
                        .Where(wn => demoWishlistIds.Contains(wn.WishlistId))
                        .ToListAsync();
                    context.WishlistNotifications.RemoveRange(demoWishlistNotifications);
                }
                
                context.Wishlists.RemoveRange(demoWishlist);

                await context.SaveChangesAsync();

                // Now safely delete the demo customer
                await userManager.DeleteAsync(demoCustomer);
            }

            // Remove demo product variants (created by seeder)
            var demoVariants = await context.ProductVariants
                .Where(v => v.SKU.StartsWith("DEMO-"))
                .ToListAsync();
            if (demoVariants.Any())
            {
                context.ProductVariants.RemoveRange(demoVariants);
                await context.SaveChangesAsync();
            }

            logger.LogInformation("Removed {Count} demo orders and related financial records.", demoOrders.Count);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<ApplicationDbContext>>();
            logger.LogError(ex, "Error removing financial demo data.");
        }
    }

    private static async Task<ApplicationUser> GetOrCreateDemoCustomerAsync(UserManager<ApplicationUser> userManager)
    {
        const string email = "demo.customer@kokomija.com";
        var existing = await userManager.FindByEmailAsync(email);

        if (existing != null) return existing;

        var customer = new ApplicationUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true,
            FirstName = "Demo",
            LastName = "Customer",
            PhoneNumber = "+48123456789",
            PhoneNumberConfirmed = true,
            IsActive = true,
            CreatedAt = DateTime.UtcNow.AddDays(-100)
        };

        var result = await userManager.CreateAsync(customer, "Demo@123456");
        if (!result.Succeeded)
        {
            throw new Exception($"Failed to create demo customer: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }

        await userManager.AddToRoleAsync(customer, "Customer");
        return customer;
    }

    private static async Task EnsureCommissionSettingsAsync(ApplicationDbContext context, string userId)
    {
        if (!await context.CommissionSettings.AnyAsync())
        {
            var settings = new CommissionSettings
            {
                DeveloperCommissionRate = 10m,
                PlatformCommissionRate = 1m,
                StripeCommissionRate = 2.9m,
                StripeFixedFee = 1.00m,
                MinimumPayoutAmount = 100m,
                PayoutFrequency = PayoutFrequency.Monthly,
                AutoPayoutEnabled = false,
                LastModifiedBy = userId,
                LastModifiedAt = DateTime.UtcNow,
                CreatedAt = DateTime.UtcNow
            };
            await context.CommissionSettings.AddAsync(settings);
            await context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Creates product variants from existing products if none exist
    /// </summary>
    private static async Task<List<ProductVariant>> CreateVariantsFromProductsAsync(ApplicationDbContext context)
    {
        var products = await context.Products
            .Include(p => p.Images)
            .Where(p => p.IsActive)
            .ToListAsync();

        if (!products.Any())
            return new List<ProductVariant>();

        // Get or create default sizes
        var sizes = await context.Sizes.ToListAsync();
        if (!sizes.Any())
        {
            sizes = new List<Size>
            {
                new Size { Name = "S", DisplayOrder = 1 },
                new Size { Name = "M", DisplayOrder = 2 },
                new Size { Name = "L", DisplayOrder = 3 },
                new Size { Name = "XL", DisplayOrder = 4 }
            };
            await context.Sizes.AddRangeAsync(sizes);
            await context.SaveChangesAsync();
        }

        // Get or create default colors
        var colors = await context.Colors.ToListAsync();
        if (!colors.Any())
        {
            colors = new List<Color>
            {
                new Color { Name = "Black", HexCode = "#000000" },
                new Color { Name = "White", HexCode = "#FFFFFF" },
                new Color { Name = "Navy", HexCode = "#000080" },
                new Color { Name = "Grey", HexCode = "#808080" }
            };
            await context.Colors.AddRangeAsync(colors);
            await context.SaveChangesAsync();
        }

        var variants = new List<ProductVariant>();
        var skuCounter = 1;

        foreach (var product in products)
        {
            // Create a few variants for each product (different size/color combos)
            foreach (var size in sizes.Take(3))
            {
                foreach (var color in colors.Take(2))
                {
                    var variant = new ProductVariant
                    {
                        ProductId = product.Id,
                        SizeId = size.Id,
                        ColorId = color.Id,
                        SKU = $"DEMO-{product.Id}-{size.Name}-{color.Name.Substring(0, 2).ToUpper()}-{skuCounter++:D4}",
                        Price = product.Price,
                        StockQuantity = _random.Next(10, 100),
                        IsActive = true,
                        CreatedAt = DateTime.UtcNow
                    };
                    variants.Add(variant);
                }
            }
        }

        await context.ProductVariants.AddRangeAsync(variants);
        await context.SaveChangesAsync();

        // Reload with navigation properties
        return await context.ProductVariants
            .Include(v => v.Product)
                .ThenInclude(p => p.Images)
            .Include(v => v.Size)
            .Include(v => v.Color)
            .Where(v => v.SKU.StartsWith("DEMO-"))
            .ToListAsync();
    }

    private static List<Order> GenerateDemoOrders(ApplicationUser customer, List<ProductVariant> variants)
    {
        var orders = new List<Order>();
        var startDate = DateTime.UtcNow.AddDays(-90);
        var orderNumber = 1;

        for (var date = startDate; date <= DateTime.UtcNow; date = date.AddDays(_random.Next(1, 4)))
        {
            var ordersPerDay = _random.Next(1, 4);

            for (int i = 0; i < ordersPerDay; i++)
            {
                var order = CreateDemoOrder(customer, variants, date, orderNumber++);
                orders.Add(order);
            }
        }

        return orders;
    }

    private static Order CreateDemoOrder(ApplicationUser customer, List<ProductVariant> variants, DateTime date, int orderNumber)
    {
        var itemCount = _random.Next(1, 5);
        var selectedVariants = variants.OrderBy(_ => _random.Next()).Take(itemCount).ToList();

        var orderItems = new List<OrderItem>();
        decimal subtotal = 0;

        foreach (var variant in selectedVariants)
        {
            var quantity = _random.Next(1, 4);
            var unitPrice = variant.Price;
            var lineTotal = unitPrice * quantity;
            subtotal += lineTotal;

            orderItems.Add(new OrderItem
            {
                ProductVariantId = variant.Id,
                ProductName = variant.Product.Name,
                Size = variant.Size?.Name,
                Color = variant.Color?.Name,
                Quantity = quantity,
                UnitPrice = unitPrice,
                TotalPrice = lineTotal,
                CreatedAt = date
            });
        }

        // Calculate financials
        var taxRate = 23m; // 23% VAT
        var taxAmount = subtotal * taxRate / 100m;
        var shippingCost = _random.Next(0, 2) == 0 ? 0 : _random.Next(10, 25);
        
        // Apply random discount (0-15%)
        var discountPercent = _random.Next(0, 16);
        var discountAmount = subtotal * discountPercent / 100m;
        
        var totalAmount = subtotal - discountAmount + taxAmount + shippingCost;
        var commissionRate = 0.015m; // 1.5%
        var commissionAmount = totalAmount * commissionRate;

        // Determine status (weighted: most are completed)
        var statusRoll = _random.Next(100);
        var orderStatus = statusRoll < 70 ? "delivered" :
                          statusRoll < 85 ? "shipped" :
                          statusRoll < 92 ? "processing" :
                          statusRoll < 97 ? "pending" : "cancelled";

        var paymentStatus = orderStatus == "cancelled" ? "refunded" :
                            orderStatus == "pending" ? "pending" : "paid";

        var orderDate = date.AddHours(_random.Next(9, 22)).AddMinutes(_random.Next(0, 60));

        return new Order
        {
            UserId = customer.Id,
            OrderNumber = $"DEMO-{orderNumber:D5}",
            StripePaymentIntentId = $"pi_demo_{Guid.NewGuid():N}",
            StripeChargeId = paymentStatus == "paid" ? $"ch_demo_{Guid.NewGuid():N}" : null,
            IsDemoOrder = true, // Mark as demo data
            
            SubtotalAmount = subtotal,
            DiscountAmount = discountAmount,
            TaxAmount = taxAmount,
            TaxRate = taxRate / 100m,
            ShippingCost = shippingCost,
            TotalAmount = totalAmount,
            CommissionRate = commissionRate,
            CommissionAmount = commissionAmount,
            Currency = "pln",
            
            ShippingAddress = "ul. Marszałkowska 1/10",
            ShippingCity = "Warsaw",
            ShippingPostalCode = "00-001",
            ShippingCountry = "Poland",
            ShippingState = "Mazowieckie",
            
            BillingAddress = "ul. Marszałkowska 1/10",
            BillingCity = "Warsaw",
            BillingPostalCode = "00-001",
            BillingCountry = "Poland",
            BillingState = "Mazowieckie",
            
            CustomerEmail = customer.Email!,
            CustomerName = $"{customer.FirstName} {customer.LastName}",
            CustomerPhone = customer.PhoneNumber,
            CustomerCountry = "PL",
            
            OrderStatus = orderStatus,
            PaymentStatus = paymentStatus,
            SessionStatus = paymentStatus == "paid" ? "complete" : null,
            
            CreatedAt = orderDate,
            PaidAt = paymentStatus == "paid" ? orderDate.AddMinutes(_random.Next(1, 10)) : null,
            ShippedAt = orderStatus is "shipped" or "delivered" ? orderDate.AddDays(_random.Next(1, 3)) : null,
            DeliveredAt = orderStatus == "delivered" ? orderDate.AddDays(_random.Next(3, 7)) : null,
            
            OrderItems = orderItems
        };
    }

    private static async Task CreateFinancialRecordsAsync(ApplicationDbContext context, List<Order> orders)
    {
        var commissionSettings = await context.CommissionSettings.FirstOrDefaultAsync();
        var developerRate = commissionSettings?.DeveloperCommissionRate ?? 10m;
        var stripeRate = commissionSettings?.StripeCommissionRate ?? 2.9m;
        var stripeFixedFee = commissionSettings?.StripeFixedFee ?? 1.00m;

        var developerEarnings = new List<DeveloperEarnings>();
        var adminCommissions = new List<AdminCommission>();

        foreach (var order in orders.Where(o => o.PaymentStatus == "paid"))
        {
            // Calculate Stripe fee (2.9% + fixed fee)
            var stripeFee = (order.TotalAmount * stripeRate / 100m) + stripeFixedFee;
            var netAfterStripe = order.TotalAmount - stripeFee - order.TaxAmount;
            var developerCommission = netAfterStripe * developerRate / 100m;
            var adminNet = netAfterStripe - developerCommission;

            // Developer earnings record
            developerEarnings.Add(new DeveloperEarnings
            {
                OrderId = order.Id,
                GrossAmount = order.TotalAmount,
                StripeProcessingFee = stripeFee,
                DeveloperCommission = developerCommission,
                NetAmount = adminNet,
                EarnedAt = order.CreatedAt,
                PayoutStatus = _random.Next(100) < 30 ? PayoutStatus.Processed : PayoutStatus.Pending,
                PayoutDate = _random.Next(100) < 30 ? order.CreatedAt.AddDays(_random.Next(15, 45)) : null
            });

            // Admin commission record
            var avgProductPrice = order.SubtotalAmount / Math.Max(1, order.OrderItems.Sum(i => i.Quantity));
            adminCommissions.Add(new AdminCommission
            {
                OrderId = order.Id,
                ProductPrice = avgProductPrice,
                Quantity = order.OrderItems.Sum(i => i.Quantity),
                Subtotal = order.SubtotalAmount,
                PlatformCommissionRate = commissionSettings?.PlatformCommissionRate / 100m ?? 0.01m,
                PlatformCommissionAmount = order.CommissionAmount,
                StripeProcessingFeeRate = stripeRate / 100m,
                StripeFixedFee = stripeFixedFee,
                TotalStripeFees = stripeFee,
                TotalDeductions = stripeFee + order.CommissionAmount,
                Currency = "PLN",
                Status = "paid",
                CalculatedAt = order.CreatedAt,
                PaidAt = order.PaidAt,
                CreatedAt = order.CreatedAt
            });
        }

        if (developerEarnings.Any())
            await context.DeveloperEarnings.AddRangeAsync(developerEarnings);

        if (adminCommissions.Any())
            await context.AdminCommissions.AddRangeAsync(adminCommissions);

        await context.SaveChangesAsync();
    }

    private static async Task CreateReturnRequestsAsync(ApplicationDbContext context, List<Order> orders, ApplicationUser customer)
    {
        var returnReasons = new[]
        {
            ("Wrong size", "The size doesn't fit as expected. Would like to exchange or return for a refund."),
            ("Product damaged", "The product arrived with visible damage on the packaging and the item itself."),
            ("Not as described", "The color/material is different from what was shown on the website."),
            ("Changed my mind", "I no longer need this product and would like to return it within the return period."),
            ("Defective item", "The product has a manufacturing defect and doesn't work properly."),
            ("Wrong item received", "I received a different product than what I ordered."),
            ("Quality not as expected", "The quality of the product is lower than expected based on the price and description."),
            ("Duplicate order", "I accidentally placed the same order twice and need to return one.")
        };

        var returnRequests = new List<ReturnRequest>();
        
        // Select orders eligible for returns (delivered, shipped or completed with items)
        var eligibleOrders = orders
            .Where(o => o.PaymentStatus == "paid" && o.OrderStatus is "delivered" or "shipped")
            .Where(o => o.OrderItems.Any())
            .OrderBy(_ => _random.Next())
            .Take(Math.Max(5, orders.Count / 10)) // About 10% of orders have return requests
            .ToList();

        foreach (var order in eligibleOrders)
        {
            var orderItem = order.OrderItems.First();
            var (reason, description) = returnReasons[_random.Next(returnReasons.Length)];
            
            // Randomly assign status with weighted distribution
            var statusRoll = _random.Next(100);
            var status = statusRoll < 35 ? ReturnRequestStatus.Pending :
                        statusRoll < 55 ? ReturnRequestStatus.UnderReview :
                        statusRoll < 75 ? ReturnRequestStatus.Approved :
                        statusRoll < 85 ? ReturnRequestStatus.Completed :
                        statusRoll < 95 ? ReturnRequestStatus.Rejected : ReturnRequestStatus.Cancelled;

            var requestedAt = order.CreatedAt.AddDays(_random.Next(3, 14));
            DateTime? reviewedAt = status != ReturnRequestStatus.Pending ? requestedAt.AddDays(_random.Next(1, 5)) : null;

            var returnRequest = new ReturnRequest
            {
                OrderId = order.Id,
                OrderItemId = orderItem.Id,
                UserId = customer.Id,
                Reason = reason,
                Description = $"{description} Order #{order.OrderNumber}. Item: {orderItem.ProductName}",
                RequestedAmount = orderItem.TotalPrice,
                Status = status,
                RequestedAt = requestedAt,
                ReviewedAt = reviewedAt,
                ReviewNotes = status switch
                {
                    ReturnRequestStatus.Approved => "Return request approved. Please ship the item back within 14 days.",
                    ReturnRequestStatus.Rejected => "Return request rejected. The return period has expired or item is not eligible.",
                    ReturnRequestStatus.Completed => "Refund has been processed successfully.",
                    _ => null
                },
                StripeRefundId = status == ReturnRequestStatus.Completed ? $"re_demo_{Guid.NewGuid():N}" : null,
                RefundedAmount = status == ReturnRequestStatus.Completed ? orderItem.TotalPrice : null,
                RefundedAt = status == ReturnRequestStatus.Completed ? reviewedAt?.AddDays(_random.Next(1, 3)) : null
            };

            returnRequests.Add(returnRequest);
        }

        if (returnRequests.Any())
        {
            await context.ReturnRequests.AddRangeAsync(returnRequests);
            await context.SaveChangesAsync();
        }
    }
}
