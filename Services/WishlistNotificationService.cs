using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.Extensions.Logging;

namespace Kokomija.Services;

public interface IWishlistNotificationService
{
    Task CheckPriceChangesAsync();
    Task NotifyNewProductAsync(int productId);
    Task NotifyNewCouponAsync(string couponCode, string description);
}

public class WishlistNotificationService : IWishlistNotificationService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<WishlistNotificationService> _logger;

    public WishlistNotificationService(
        IServiceProvider serviceProvider,
        ILogger<WishlistNotificationService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public async Task CheckPriceChangesAsync()
    {
        using var scope = _serviceProvider.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        try
        {
            var products = await unitOfWork.Products.GetAllAsync();

            foreach (var product in products)
            {
                var priceHistories = await unitOfWork.Repository<ProductPriceHistory>()
                    .FindAsync(h => h.ProductId == product.Id);
                
                var lastPrice = priceHistories.OrderByDescending(h => h.ChangedAt).FirstOrDefault();
                
                if (lastPrice != null && lastPrice.NewPrice != product.Price)
                {
                    var priceHistory = new ProductPriceHistory
                    {
                        ProductId = product.Id,
                        OldPrice = lastPrice.NewPrice,
                        NewPrice = product.Price,
                        Reason = "Price Update",
                        ChangedAt = DateTime.UtcNow,
                        ChangedBy = "System"
                    };

                    await unitOfWork.Repository<ProductPriceHistory>().AddAsync(priceHistory);

                    if (product.Price < lastPrice.NewPrice)
                    {
                        await CreatePriceDropNotificationsAsync(product.Id, lastPrice.NewPrice, product.Price, unitOfWork);
                    }
                }
                else if (lastPrice == null)
                {
                    var priceHistory = new ProductPriceHistory
                    {
                        ProductId = product.Id,
                        OldPrice = product.Price,
                        NewPrice = product.Price,
                        Reason = "Initial Price",
                        ChangedAt = DateTime.UtcNow,
                        ChangedBy = "System"
                    };

                    await unitOfWork.Repository<ProductPriceHistory>().AddAsync(priceHistory);
                }
            }

            await unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Price change check completed");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking price changes");
        }
    }

    private async Task CreatePriceDropNotificationsAsync(int productId, decimal oldPrice, decimal newPrice, IUnitOfWork unitOfWork)
    {
        var wishlists = await unitOfWork.Repository<Wishlist>()
            .FindAsync(w => w.ProductId == productId);

        foreach (var wishlist in wishlists)
        {
            var notification = new WishlistNotification
            {
                WishlistId = wishlist.Id,
                NotificationType = "PriceDropped",
                Message = $"Price dropped from {oldPrice:N2} zł to {newPrice:N2} zł!",
                OldPrice = oldPrice,
                NewPrice = newPrice,
                CreatedAt = DateTime.UtcNow
            };

            await unitOfWork.Repository<WishlistNotification>().AddAsync(notification);
        }
    }

    public async Task NotifyNewProductAsync(int productId)
    {
        using var scope = _serviceProvider.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        try
        {
            var product = await unitOfWork.Products.GetByIdAsync(productId);
            if (product == null) return;

            var subscribers = await unitOfWork.Repository<NewsletterSubscription>()
                .FindAsync(n => n.IsActive && n.ReceiveNewProductNotifications);

            // Email notifications will be sent later via background service
            _logger.LogInformation("New product {ProductId} ready for notification to {Count} subscribers", 
                productId, subscribers.Count());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error preparing new product notifications");
        }
    }

    public async Task NotifyNewCouponAsync(string couponCode, string description)
    {
        using var scope = _serviceProvider.CreateScope();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        try
        {
            var subscribers = await unitOfWork.Repository<NewsletterSubscription>()
                .FindAsync(n => n.IsActive && n.ReceiveDiscountNotifications);

            var allWishlists = await unitOfWork.Wishlists.GetAllAsync();
            var uniqueUserIds = allWishlists.Select(w => w.UserId).Distinct();

            foreach (var userId in uniqueUserIds)
            {
                var userWishlists = await unitOfWork.Wishlists.GetByUserIdAsync(userId);
                foreach (var wishlist in userWishlists)
                {
                    var notification = new WishlistNotification
                    {
                        WishlistId = wishlist.Id,
                        NotificationType = "NewCoupon",
                        Message = $"New coupon available: {couponCode} - {description}",
                        CouponCode = couponCode,
                        CreatedAt = DateTime.UtcNow
                    };

                    await unitOfWork.Repository<WishlistNotification>().AddAsync(notification);
                }
            }

            await unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Coupon notifications created for {CouponCode}", couponCode);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating coupon notifications");
        }
    }
}
