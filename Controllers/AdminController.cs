using ClosedXML.Excel;
using Kokomija.Data;
using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.Admin;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Kokomija.Controllers;

[Authorize(Roles = "Root,Admin")]
public class AdminController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AdminController> _logger;
    private readonly ICarouselImageService _carouselImageService;
    private readonly ICarouselService _carouselService;
    private readonly ICategoryImageService _categoryImageService;
    private readonly ILocalizationService _localizationService;
    private readonly ITranslationManagementService _translationManagementService;
    private readonly IWebHostEnvironment _environment;
    private readonly IConfiguration _configuration;
    private readonly IBlogImageService _blogImageService;
    private readonly IProductImageService _productImageService;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IShippingService _shippingService;
    private readonly ITaxService _taxService;
    private readonly IReturnRequestService _returnRequestService;
    private readonly IStripeService _stripeService;
    private readonly IStripePayoutService _stripePayoutService;
    private readonly ICarrierApiService _carrierApiService;

    public AdminController(
        IUnitOfWork unitOfWork, 
        ILogger<AdminController> logger,
        ICarouselImageService carouselImageService,
        ICarouselService carouselService,
        ICategoryImageService categoryImageService,
        ILocalizationService localizationService,
        ITranslationManagementService translationManagementService,
        IWebHostEnvironment environment,
        IConfiguration configuration,
        IBlogImageService blogImageService,
        IProductImageService productImageService,
        UserManager<ApplicationUser> userManager,
        IShippingService shippingService,
        ITaxService taxService,
        IReturnRequestService returnRequestService,
        IStripeService stripeService,
        IStripePayoutService stripePayoutService,
        ICarrierApiService carrierApiService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _carouselImageService = carouselImageService;
        _carouselService = carouselService;
        _categoryImageService = categoryImageService;
        _localizationService = localizationService;
        _translationManagementService = translationManagementService;
        _environment = environment;
        _configuration = configuration;
        _blogImageService = blogImageService;
        _productImageService = productImageService;
        _userManager = userManager;
        _shippingService = shippingService;
        _taxService = taxService;
        _returnRequestService = returnRequestService;
        _stripeService = stripeService;
        _stripePayoutService = stripePayoutService;
        _carrierApiService = carrierApiService;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Admin accessed dashboard");

        var viewModel = new AdminDashboardViewModel();

        try
        {
            // Get all users
            var allUsers = await _unitOfWork.Users.GetAllUsersAsync();
            viewModel.TotalUsers = allUsers.Count();
            viewModel.ActiveUsers = allUsers.Count(u => u.IsActive);

            // Get all orders
            var allOrders = await _unitOfWork.Orders.GetAllAsync();
            viewModel.TotalOrders = allOrders.Count();
            viewModel.PendingOrders = allOrders.Count(o => o.OrderStatus == "pending" || o.OrderStatus == "processing");
            viewModel.CompletedOrders = allOrders.Count(o => o.OrderStatus == "delivered");
            viewModel.TotalRevenue = allOrders.Where(o => o.PaymentStatus == "paid").Sum(o => o.TotalAmount);
            viewModel.PlatformCommission = allOrders.Where(o => o.PaymentStatus == "paid").Sum(o => o.CommissionAmount);

            // Calculate monthly revenue
            var firstDayOfMonth = new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1);
            viewModel.MonthlyRevenue = allOrders
                .Where(o => o.PaymentStatus == "paid" && o.CreatedAt >= firstDayOfMonth)
                .Sum(o => o.TotalAmount);

            // Get all products
            var allProducts = await _unitOfWork.Products.GetAllAsync();
            viewModel.TotalProducts = allProducts.Count();
            viewModel.ActiveProducts = allProducts.Count(p => p.IsActive);

            // Calculate out of stock products
            var productsWithStock = await _unitOfWork.Products.GetProductsWithVariantsAsync();
            viewModel.OutOfStockProducts = productsWithStock
                .Count(p => p.Variants.All(v => v.StockQuantity == 0));

            // Get recent orders (last 5)
            var recentOrders = allOrders
                .OrderByDescending(o => o.CreatedAt)
                .Take(5)
                .ToList();

            viewModel.RecentOrders = recentOrders.Select(o => new RecentOrderViewModel
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                CustomerName = o.CustomerName ?? "Guest",
                CustomerEmail = o.CustomerEmail,
                TotalAmount = o.TotalAmount,
                OrderStatus = o.OrderStatus,
                PaymentStatus = o.PaymentStatus,
                CreatedAt = o.CreatedAt,
                Currency = o.Currency.ToUpper()
            }).ToList();

            // Get recent users (last 5)
            var recentUsers = allUsers
                .OrderByDescending(u => u.CreatedAt)
                .Take(5)
                .ToList();

            viewModel.RecentUsers = recentUsers.Select(u => new RecentUserViewModel
            {
                Id = u.Id,
                Email = u.Email ?? string.Empty,
                FirstName = u.FirstName,
                LastName = u.LastName,
                VipTier = u.VipTier,
                TotalSpent = u.TotalSpent,
                CreatedAt = u.CreatedAt,
                LastLoginAt = u.LastLoginAt
            }).ToList();

            // Get low stock products (stock < 10)
            var lowStockProducts = productsWithStock
                .Where(p => p.Variants.Sum(v => v.StockQuantity) < 10 && p.IsActive)
                .OrderBy(p => p.Variants.Sum(v => v.StockQuantity))
                .Take(5)
                .ToList();

            viewModel.LowStockProducts = lowStockProducts.Select(p => new LowStockProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                TotalStock = p.Variants.Sum(v => v.StockQuantity),
                ImageUrl = p.Images.FirstOrDefault()?.ImageUrl,
                Price = p.Price,
                IsActive = p.IsActive
            }).ToList();

            // Get recent reviews (last 5)
            var allReviews = await _unitOfWork.ProductReviews.GetAllAsync();
            var recentReviewsList = allReviews
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .ToList();
            
            viewModel.RecentReviews = recentReviewsList.Select(r => new RecentReviewViewModel
            {
                Id = r.Id,
                ProductName = r.Product?.Name ?? "Unknown",
                UserName = r.User?.Email ?? "Anonymous",
                Rating = r.Rating,
                Comment = r.Comment.Length > 100 ? r.Comment.Substring(0, 100) + "..." : r.Comment,
                IsVisible = r.IsVisible,
                CreatedAt = r.CreatedAt
            }).ToList();

            // Blog statistics
            var allBlogs = await _unitOfWork.Blogs.GetAllAsync();
            viewModel.TotalBlogs = allBlogs.Count();
            viewModel.PublishedBlogs = allBlogs.Count(b => b.IsPublished);
            viewModel.DraftBlogs = allBlogs.Count(b => !b.IsPublished);

            // Additional metrics
            var newsletterSubs = await _unitOfWork.Repository<Kokomija.Entity.NewsletterSubscription>().GetAllAsync();
            viewModel.NewsletterSubscribers = newsletterSubs.Count(n => n.IsActive);

            var coupons = await _unitOfWork.Coupons.GetAllAsync();
            viewModel.ActiveCoupons = coupons.Count(c => c.IsActive);

            viewModel.PendingReviews = allReviews.Count(r => !r.IsVisible);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading admin dashboard data");
            // Continue with empty viewModel - UI will show zeros
        }

        return View(viewModel);
    }

    public IActionResult Users()
    {
        // Future: User management
        return View();
    }


    /// <summary>
    /// GET: Order Management page with list and statistics
    /// </summary>
    public async Task<IActionResult> Orders(int page = 1, string? search = null, string? status = null, 
        string? paymentStatus = null, DateTime? dateFrom = null, DateTime? dateTo = null)
    {
        int pageSize = 20;
        
        // Get all orders with related data
        var allOrders = await _unitOfWork.Orders.GetAllOrdersWithDetailsAsync();
        
        // Apply filters
        var filteredOrders = allOrders.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.ToLower();
            filteredOrders = filteredOrders.Where(o => 
                o.OrderNumber.ToLower().Contains(search) ||
                (o.CustomerName != null && o.CustomerName.ToLower().Contains(search)) ||
                o.CustomerEmail.ToLower().Contains(search)
            );
        }
        
        if (!string.IsNullOrWhiteSpace(status))
        {
            filteredOrders = filteredOrders.Where(o => o.OrderStatus.ToLower() == status.ToLower());
        }
        
        if (!string.IsNullOrWhiteSpace(paymentStatus))
        {
            filteredOrders = filteredOrders.Where(o => o.PaymentStatus.ToLower() == paymentStatus.ToLower());
        }
        
        if (dateFrom.HasValue)
        {
            filteredOrders = filteredOrders.Where(o => o.CreatedAt >= dateFrom.Value);
        }
        
        if (dateTo.HasValue)
        {
            var endDate = dateTo.Value.AddDays(1); // Include entire day
            filteredOrders = filteredOrders.Where(o => o.CreatedAt < endDate);
        }
        
        // Get statistics
        var statistics = new OrderStatisticsDto
        {
            TotalOrders = allOrders.Count(),
            PendingOrders = allOrders.Count(o => o.OrderStatus == "pending"),
            ProcessingOrders = allOrders.Count(o => o.OrderStatus == "processing"),
            ShippedOrders = allOrders.Count(o => o.OrderStatus == "shipped"),
            DeliveredOrders = allOrders.Count(o => o.OrderStatus == "delivered"),
            CancelledOrders = allOrders.Count(o => o.OrderStatus == "cancelled"),
            TotalRevenue = allOrders.Where(o => o.PaymentStatus == "paid").Sum(o => o.TotalAmount),
            TodayRevenue = allOrders.Where(o => o.PaymentStatus == "paid" && o.CreatedAt.Date == DateTime.UtcNow.Date)
                .Sum(o => o.TotalAmount),
            MonthRevenue = allOrders.Where(o => o.PaymentStatus == "paid" && 
                o.CreatedAt.Year == DateTime.UtcNow.Year && 
                o.CreatedAt.Month == DateTime.UtcNow.Month)
                .Sum(o => o.TotalAmount),
            AverageOrderValue = allOrders.Any() ? allOrders.Average(o => o.TotalAmount) : 0,
            AwaitingShipment = allOrders.Count(o => o.OrderStatus == "processing" && o.PaymentStatus == "paid"),
        };
        
        // Get return requests count
        var allReturns = await _unitOfWork.ReturnRequests.GetAllAsync();
        statistics.PendingReturns = allReturns.Count(r => 
            r.Status == ReturnRequestStatus.Pending || 
            r.Status == ReturnRequestStatus.UnderReview
        );
        
        // Get shipments for orders
        var allShipments = await _unitOfWork.Repository<OrderShipment>().GetAllAsync();
        var shipmentsByOrderId = allShipments.GroupBy(s => s.OrderId)
            .ToDictionary(g => g.Key, g => g.First());
        
        // Get return requests for orders
        var returnsByOrderId = allReturns
            .Where(r => r.Status == ReturnRequestStatus.Pending || 
                       r.Status == ReturnRequestStatus.UnderReview ||
                       r.Status == ReturnRequestStatus.Approved)
            .GroupBy(r => r.OrderId)
            .ToDictionary(g => g.Key, g => g.Count());
        
        // Pagination
        var totalOrders = filteredOrders.Count();
        var orders = filteredOrders
            .OrderByDescending(o => o.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        // Map to DTOs
        var orderDtos = orders.Select(o =>
        {
            var hasShipment = shipmentsByOrderId.TryGetValue(o.Id, out var shipment);
            var hasReturn = returnsByOrderId.TryGetValue(o.Id, out var returnCount);
            
            return new OrderListItemDto
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                CustomerName = o.CustomerName ?? (o.User != null ? $"{o.User.FirstName} {o.User.LastName}" : null) ?? "Guest",
                CustomerEmail = o.CustomerEmail,
                TotalAmount = o.TotalAmount,
                Currency = o.Currency.ToUpper(),
                OrderStatus = o.OrderStatus,
                PaymentStatus = o.PaymentStatus,
                CreatedAt = o.CreatedAt,
                ItemCount = o.OrderItems.Count,
                HasShipment = hasShipment,
                ShipmentStatus = hasShipment ? shipment!.Status : null,
                TrackingNumber = hasShipment ? shipment!.TrackingNumber : null,
                HasActiveReturn = hasReturn,
                ActiveReturnCount = hasReturn ? returnCount : 0,
                IsDemoOrder = o.IsDemoOrder || o.OrderNumber.StartsWith("DEMO-")
            };
        }).ToList();
        
        var viewModel = new OrderManagementViewModel
        {
            Orders = orderDtos,
            Statistics = statistics,
            CurrentPage = page,
            PageSize = pageSize,
            TotalOrders = totalOrders,
            SearchQuery = search,
            StatusFilter = status,
            PaymentStatusFilter = paymentStatus,
            DateFrom = dateFrom,
            DateTo = dateTo
        };
        
        return View(viewModel);
    }

    /// <summary>
    /// GET: Order details page
    /// </summary>
    public async Task<IActionResult> OrderDetails(int id)
    {
        var orderEntity = await _unitOfWork.Orders.GetOrderWithFullDetailsAsync(id);
        if (orderEntity == null)
        {
            TempData["Error"] = "Order not found";
            return RedirectToAction(nameof(Orders));
        }
        
        // Get shipment with related data
        var shipments = await _unitOfWork.Repository<OrderShipment>().FindAsync(
            s => s.OrderId == id
        );
        var shipment = shipments.FirstOrDefault();
        
        // Manually load shipment related data
        if (shipment != null)
        {
            var providers = await _unitOfWork.Repository<ShippingProvider>().FindAsync(p => p.Id == shipment.ShippingProviderId);
            shipment.ShippingProvider = providers.FirstOrDefault()!;
            
            var rates = await _unitOfWork.Repository<ShippingRate>().FindAsync(r => r.Id == shipment.ShippingRateId);
            shipment.ShippingRate = rates.FirstOrDefault()!;
            
            var trackingEvents = await _unitOfWork.Repository<ShipmentTrackingEvent>()
                .FindAsync(e => e.OrderShipmentId == shipment.Id);
            shipment.TrackingEvents = trackingEvents.OrderByDescending(e => e.EventDate).ToList();
        }
        
        // Get return requests with related data
        var returns = await _unitOfWork.ReturnRequests.FindAsync(
            r => r.OrderId == id
        );
        
        // Manually load return request related data
        foreach (var returnRequest in returns)
        {
            if (returnRequest.ReviewedBy != null)
            {
                returnRequest.Reviewer = await _unitOfWork.Users.GetByIdAsync(returnRequest.ReviewedBy);
            }
            
            var orderItems = await _unitOfWork.Repository<OrderItem>().FindAsync(oi => oi.Id == returnRequest.OrderItemId);
            returnRequest.OrderItem = orderItems.FirstOrDefault()!;
        }
        
        // Get developer earnings
        var earnings = await _unitOfWork.DeveloperEarnings.FindAsync(e => e.OrderId == id);
        var earning = earnings.FirstOrDefault();
        
        // Map to ViewModel
        var viewModel = new OrderDetailsViewModel
        {
            Id = orderEntity.Id,
            OrderNumber = orderEntity.OrderNumber,
            StripePaymentIntentId = orderEntity.StripePaymentIntentId,
            StripeChargeId = orderEntity.StripeChargeId,
            IsDemoOrder = orderEntity.IsDemoOrder || orderEntity.OrderNumber.StartsWith("DEMO-"),
            
            // Customer
            UserId = orderEntity.UserId,
            CustomerName = orderEntity.CustomerName ?? (orderEntity.User != null ? $"{orderEntity.User.FirstName} {orderEntity.User.LastName}" : null) ?? "Guest",
            CustomerEmail = orderEntity.CustomerEmail,
            CustomerPhone = orderEntity.CustomerPhone,
            UserVipTier = orderEntity.User?.VipTier,
            UserTotalSpent = orderEntity.User?.TotalSpent,
            
            // Status
            OrderStatus = orderEntity.OrderStatus,
            PaymentStatus = orderEntity.PaymentStatus,
            CreatedAt = orderEntity.CreatedAt,
            PaidAt = orderEntity.PaidAt,
            ShippedAt = orderEntity.ShippedAt,
            DeliveredAt = orderEntity.DeliveredAt,
            
            // Financial
            SubtotalAmount = orderEntity.SubtotalAmount,
            TaxAmount = orderEntity.TaxAmount,
            TaxRate = orderEntity.TaxRate,
            ShippingCost = orderEntity.ShippingCost,
            DiscountAmount = orderEntity.DiscountAmount,
            TotalAmount = orderEntity.TotalAmount,
            CommissionAmount = orderEntity.CommissionAmount,
            CommissionRate = orderEntity.CommissionRate,
            Currency = orderEntity.Currency.ToUpper(),
            
            // Coupon
            CouponId = orderEntity.CouponId,
            CouponCode = orderEntity.Coupon?.Code,
            
            // Addresses
            ShippingAddress = new AddressDto
            {
                Address = orderEntity.ShippingAddress,
                City = orderEntity.ShippingCity,
                State = orderEntity.ShippingState,
                PostalCode = orderEntity.ShippingPostalCode,
                Country = orderEntity.ShippingCountry
            },
            BillingAddress = new AddressDto
            {
                Address = orderEntity.BillingAddress,
                City = orderEntity.BillingCity,
                State = orderEntity.BillingState,
                PostalCode = orderEntity.BillingPostalCode,
                Country = orderEntity.BillingCountry
            },
            
            // Order Items
            OrderItems = orderEntity.OrderItems.Select(oi =>
            {
                var hasReturn = returns.Any(r => r.OrderItemId == oi.Id);
                var returnRequest = returns.FirstOrDefault(r => r.OrderItemId == oi.Id);
                
                return new OrderItemDetailsDto
                {
                    Id = oi.Id,
                    ProductVariantId = oi.ProductVariantId,
                    ProductId = oi.ProductVariant?.ProductId ?? 0,
                    ProductName = oi.ProductName,
                    ProductImageUrl = oi.ProductVariant?.Product?.Images?.FirstOrDefault()?.ImageUrl,
                    Size = oi.Size,
                    Color = oi.Color,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    TotalPrice = oi.TotalPrice,
                    HasActiveReturn = hasReturn,
                    ReturnStatus = returnRequest?.Status
                };
            }).ToList(),
            
            // Shipment
            Shipment = shipment == null ? null : new OrderShipmentDetailsDto
            {
                Id = shipment.Id,
                OrderId = shipment.OrderId,
                TrackingNumber = shipment.TrackingNumber,
                Status = shipment.Status,
                EstimatedDeliveryDate = shipment.EstimatedDeliveryDate,
                ActualDeliveryDate = shipment.ActualDeliveryDate,
                ShippingCost = shipment.ShippingCost,
                Weight = shipment.Weight,
                ShippedAt = shipment.ShippedAt,
                DeliveredAt = shipment.DeliveredAt,
                CreatedAt = shipment.CreatedAt,
                UpdatedAt = shipment.UpdatedAt,
                ProviderName = shipment.ShippingProvider?.Name ?? "Unknown",
                ProviderCode = shipment.ShippingProvider?.Code ?? "unknown",
                TrackingUrl = !string.IsNullOrEmpty(shipment.TrackingNumber) && !string.IsNullOrEmpty(shipment.ShippingProvider?.TrackingUrlTemplate)
                    ? shipment.ShippingProvider.TrackingUrlTemplate.Replace("{trackingNumber}", shipment.TrackingNumber)
                    : null,
                RateName = shipment.ShippingRate?.Name ?? "Standard",
                MinDeliveryDays = shipment.ShippingRate?.MinDeliveryDays ?? 3,
                MaxDeliveryDays = shipment.ShippingRate?.MaxDeliveryDays ?? 5,
                TrackingEvents = shipment.TrackingEvents.Select(e => new ShipmentTrackingEventDto
                {
                    Id = e.Id,
                    Status = e.Status,
                    Location = e.Location,
                    Description = e.Description,
                    EventDate = e.EventDate,
                    CreatedAt = e.CreatedAt
                }).ToList()
            },
            
            // Returns
            ReturnRequests = returns.Select(r => new ReturnRequestSummaryDto
            {
                Id = r.Id,
                OrderItemId = r.OrderItemId,
                ProductName = r.OrderItem?.ProductName ?? "Unknown Product",
                Reason = r.Reason,
                RequestedAmount = r.RequestedAmount,
                Status = r.Status,
                RequestedAt = r.RequestedAt,
                ReviewedAt = r.ReviewedAt,
                ReviewerName = r.Reviewer != null ? $"{r.Reviewer.FirstName} {r.Reviewer.LastName}" : null
            }).ToList(),
            
            // Developer Earnings
            DeveloperEarnings = earning == null ? null : new DeveloperEarningsDto
            {
                Id = earning.Id,
                GrossAmount = earning.GrossAmount,
                StripeProcessingFee = earning.StripeProcessingFee,
                DeveloperCommission = earning.DeveloperCommission,
                NetAmount = earning.NetAmount,
                EarnedAt = earning.EarnedAt,
                PayoutStatus = earning.PayoutStatus,
                PayoutId = earning.PayoutId,
                PayoutDate = earning.PayoutDate
            }
        };
        
        return View(viewModel);
    }

    /// <summary>
    /// POST: Update order status
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateOrderStatus([FromBody] UpdateOrderStatusDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data" });
        
        var orders = await _unitOfWork.Orders.FindAsync(o => o.Id == dto.OrderId);
        var order = orders.FirstOrDefault();
        
        if (order == null)
            return Json(new { success = false, message = "Order not found" });
        
        order.OrderStatus = dto.OrderStatus.ToLower();
        
        // Update timestamps based on status
        if (dto.OrderStatus.ToLower() == "shipped" && !order.ShippedAt.HasValue)
            order.ShippedAt = DateTime.UtcNow;
        else if (dto.OrderStatus.ToLower() == "delivered" && !order.DeliveredAt.HasValue)
            order.DeliveredAt = DateTime.UtcNow;
        
        _unitOfWork.Orders.Update(order);
        await _unitOfWork.SaveChangesAsync();
        
        return Json(new { success = true, message = "Order status updated successfully" });
    }

    /// <summary>
    /// POST: Create shipment for order
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateOrderShipment([FromBody] CreateOrderShipmentDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data" });
        
        var orders = await _unitOfWork.Orders.FindAsync(o => o.Id == dto.OrderId);
        var order = orders.FirstOrDefault();
        
        if (order == null)
            return Json(new { success = false, message = "Order not found" });
        
        // Check if shipment already exists
        var existingShipments = await _unitOfWork.Repository<OrderShipment>().FindAsync(s => s.OrderId == dto.OrderId);
        if (existingShipments.Any())
            return Json(new { success = false, message = "Shipment already exists for this order" });
        
        // Get shipping rate to calculate estimated delivery
        var rates = await _unitOfWork.Repository<ShippingRate>().FindAsync(r => r.Id == dto.ShippingRateId);
        var rate = rates.FirstOrDefault();
        
        var shipment = new OrderShipment
        {
            OrderId = dto.OrderId,
            ShippingProviderId = dto.ShippingProviderId,
            ShippingRateId = dto.ShippingRateId,
            TrackingNumber = dto.TrackingNumber,
            Status = ShipmentStatus.Pending,
            ShippingCost = order.ShippingCost,
            Weight = dto.Weight,
            EstimatedDeliveryDate = dto.EstimatedDeliveryDate ?? DateTime.UtcNow.AddDays(rate?.MaxDeliveryDays ?? 5),
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
        
        await _unitOfWork.Repository<OrderShipment>().AddAsync(shipment);
        
        // Update order status
        if (order.OrderStatus == "processing" || order.OrderStatus == "pending")
        {
            order.OrderStatus = "shipped";
            order.ShippedAt = DateTime.UtcNow;
            _unitOfWork.Orders.Update(order);
        }
        
        await _unitOfWork.SaveChangesAsync();
        
        return Json(new { success = true, message = "Shipment created successfully", shipmentId = shipment.Id });
    }

    /// <summary>
    /// POST: Update tracking number
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateOrderTrackingNumber([FromBody] UpdateTrackingNumberDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data" });
        
        var shipments = await _unitOfWork.Repository<OrderShipment>().FindAsync(s => s.Id == dto.ShipmentId);
        var shipment = shipments.FirstOrDefault();
        
        if (shipment == null)
            return Json(new { success = false, message = "Shipment not found" });
        
        shipment.TrackingNumber = dto.TrackingNumber;
        shipment.UpdatedAt = DateTime.UtcNow;
        
        if (shipment.Status == ShipmentStatus.Pending)
            shipment.Status = ShipmentStatus.Processing;
        
        _unitOfWork.Repository<OrderShipment>().Update(shipment);
        await _unitOfWork.SaveChangesAsync();
        
        return Json(new { success = true, message = "Tracking number updated successfully" });
    }

    /// <summary>
    /// POST: Add tracking event
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> AddOrderTrackingEvent([FromBody] AddTrackingEventDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data" });
        
        var shipments = await _unitOfWork.Repository<OrderShipment>().FindAsync(s => s.Id == dto.ShipmentId);
        var shipment = shipments.FirstOrDefault();
        
        if (shipment == null)
            return Json(new { success = false, message = "Shipment not found" });
        
        var trackingEvent = new ShipmentTrackingEvent
        {
            OrderShipmentId = dto.ShipmentId,
            Status = dto.Status,
            Location = dto.Location,
            Description = dto.Description,
            EventDate = dto.EventDate ?? DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow
        };
        
        await _unitOfWork.Repository<ShipmentTrackingEvent>().AddAsync(trackingEvent);
        
        // Update shipment status based on event
        var statusLower = dto.Status.ToLower();
        if (statusLower.Contains("delivered"))
        {
            shipment.Status = ShipmentStatus.Delivered;
            shipment.DeliveredAt = trackingEvent.EventDate;
            shipment.ActualDeliveryDate = trackingEvent.EventDate;
            
            // Update order
            var orders = await _unitOfWork.Orders.FindAsync(o => o.Id == shipment.OrderId);
            var order = orders.FirstOrDefault();
            if (order != null)
            {
                order.OrderStatus = "delivered";
                order.DeliveredAt = trackingEvent.EventDate;
                _unitOfWork.Orders.Update(order);
            }
        }
        else if (statusLower.Contains("transit") || statusLower.Contains("in-transit"))
        {
            shipment.Status = ShipmentStatus.InTransit;
        }
        else if (statusLower.Contains("out for delivery"))
        {
            shipment.Status = ShipmentStatus.OutForDelivery;
        }
        else if (statusLower.Contains("shipped"))
        {
            shipment.Status = ShipmentStatus.Shipped;
            if (!shipment.ShippedAt.HasValue)
                shipment.ShippedAt = trackingEvent.EventDate;
        }
        
        shipment.UpdatedAt = DateTime.UtcNow;
        _unitOfWork.Repository<OrderShipment>().Update(shipment);
        
        await _unitOfWork.SaveChangesAsync();
        
        return Json(new { success = true, message = "Tracking event added successfully" });
    }

    #region Carrier API Endpoints

    /// <summary>
    /// GET: Get all carrier statuses
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetCarrierStatuses()
    {
        try
        {
            var statuses = await _carrierApiService.GetAllCarrierStatusesAsync();
            return Json(new { success = true, statuses });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting carrier statuses");
            return Json(new { success = false, message = "Error retrieving carrier statuses" });
        }
    }

    /// <summary>
    /// GET: Get orders awaiting shipment
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAwaitingShipments()
    {
        try
        {
            var orders = await _unitOfWork.Orders.FindAsync(o => 
                (o.OrderStatus == "processing" || o.OrderStatus == "pending" || o.OrderStatus == "confirmed") &&
                o.PaymentStatus == "paid");
            
            var orderList = orders.OrderBy(o => o.CreatedAt).Select(o => new
            {
                id = o.Id,
                orderNumber = o.OrderNumber,
                customerName = o.User != null ? $"{o.User.FirstName} {o.User.LastName}" : (o.CustomerName ?? o.CustomerEmail ?? "Guest"),
                itemCount = o.OrderItems?.Count ?? 0,
                shippingAddress = $"{o.ShippingAddress}, {o.ShippingCity} {o.ShippingPostalCode}",
                createdAt = o.CreatedAt,
                totalAmount = o.TotalAmount
            }).ToList();
            
            return Json(new { success = true, orders = orderList });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting awaiting shipments");
            return Json(new { success = false, message = "Error retrieving orders" });
        }
    }

    /// <summary>
    /// GET: Get shipping providers list
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetShippingProvidersList()
    {
        try
        {
            var providers = await _unitOfWork.Repository<ShippingProvider>().FindAsync(p => p.IsActive);
            var providerList = providers.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                code = p.Code,
                trackingUrl = p.TrackingUrlTemplate
            }).ToList();
            
            return Json(new { success = true, providers = providerList });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting shipping providers");
            return Json(new { success = false, message = "Error retrieving providers" });
        }
    }

    /// <summary>
    /// POST: Create shipment via carrier API
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateShipmentForOrder([FromBody] CreateShipmentFromOrderDto dto)
    {
        try
        {
            var orders = await _unitOfWork.Orders.FindAsync(o => o.Id == dto.OrderId);
            var order = orders.FirstOrDefault();
            
            if (order == null)
                return Json(new { success = false, message = "Order not found" });
            
            var providers = await _unitOfWork.Repository<ShippingProvider>().FindAsync(p => p.Id == dto.ShippingProviderId);
            var provider = providers.FirstOrDefault();
            
            if (provider == null)
                return Json(new { success = false, message = "Shipping provider not found" });
            
            // Build shipment request
            var request = new CreateShipmentRequest
            {
                OrderId = dto.OrderId,
                ShippingProviderId = dto.ShippingProviderId,
                ServiceType = dto.ServiceType ?? "standard",
                SignatureRequired = dto.SignatureRequired,
                SpecialInstructions = dto.SpecialInstructions,
                Sender = new AddressInfo
                {
                    Name = _configuration["Store:Name"] ?? "Kokomija",
                    Street = _configuration["Store:Address"] ?? "",
                    City = _configuration["Store:City"] ?? "",
                    PostalCode = _configuration["Store:PostalCode"] ?? "",
                    Country = _configuration["Store:Country"] ?? "PL",
                    Phone = _configuration["Store:Phone"] ?? "",
                    Email = _configuration["Store:Email"] ?? ""
                },
                Recipient = new AddressInfo
                {
                    Name = order.User != null ? $"{order.User.FirstName} {order.User.LastName}" : (order.CustomerName ?? ""),
                    Street = order.ShippingAddress ?? "",
                    City = order.ShippingCity ?? "",
                    PostalCode = order.ShippingPostalCode ?? "",
                    Country = order.ShippingCountry ?? "PL",
                    Phone = order.User?.PhoneNumber ?? order.CustomerPhone ?? "",
                    Email = order.User?.Email ?? order.CustomerEmail ?? ""
                },
                Package = new PackageInfo
                {
                    Weight = dto.Weight,
                    Length = dto.Length,
                    Width = dto.Width,
                    Height = dto.Height,
                    DeclaredValue = dto.DeclaredValue ?? order.TotalAmount,
                    Currency = "PLN"
                }
            };
            
            var result = await _carrierApiService.CreateShipmentAsync(request);
            
            if (result.Success)
            {
                // Get first shipping rate for the provider (for the required field)
                var rates = await _unitOfWork.Repository<ShippingRate>().FindAsync(r => r.ShippingProviderId == dto.ShippingProviderId);
                var firstRate = rates.FirstOrDefault();
                
                // Create OrderShipment record
                var shipment = new OrderShipment
                {
                    OrderId = dto.OrderId,
                    ShippingProviderId = dto.ShippingProviderId,
                    ShippingRateId = firstRate?.Id ?? 1, // Default to first available rate
                    TrackingNumber = result.TrackingNumber,
                    Status = ShipmentStatus.Pending,
                    ShippingCost = result.ShippingCost ?? order.ShippingCost,
                    Weight = dto.Weight,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                
                await _unitOfWork.Repository<OrderShipment>().AddAsync(shipment);
                
                // Update order status
                order.OrderStatus = "shipped";
                order.ShippedAt = DateTime.UtcNow;
                _unitOfWork.Orders.Update(order);
                
                await _unitOfWork.SaveChangesAsync();
                
                return Json(new { 
                    success = true, 
                    message = $"Shipment created with tracking number: {result.TrackingNumber}",
                    trackingNumber = result.TrackingNumber,
                    labelUrl = result.LabelUrl
                });
            }
            
            return Json(new { success = false, message = result.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating shipment for order {OrderId}", dto.OrderId);
            return Json(new { success = false, message = "Error creating shipment" });
        }
    }

    /// <summary>
    /// GET: Get tracking information via carrier API
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetTrackingInfo(string trackingNumber, string carrierCode = "auto")
    {
        try
        {
            if (string.IsNullOrEmpty(trackingNumber))
                return Json(new { success = false, message = "Tracking number is required" });
            
            var result = await _carrierApiService.GetTrackingInfoAsync(trackingNumber, carrierCode);
            
            if (result.Success)
            {
                return Json(new { success = true, tracking = result });
            }
            
            return Json(new { success = false, message = result.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting tracking info for {TrackingNumber}", trackingNumber);
            return Json(new { success = false, message = "Error retrieving tracking information" });
        }
    }

    /// <summary>
    /// GET: Get shipping quotes from carriers
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetShippingQuotes(int orderId, decimal weight, decimal length, decimal width, decimal height)
    {
        try
        {
            var orders = await _unitOfWork.Orders.FindAsync(o => o.Id == orderId);
            var order = orders.FirstOrDefault();
            
            if (order == null)
                return Json(new { success = false, message = "Order not found" });
            
            var request = new ShippingQuoteRequest
            {
                Origin = new AddressInfo
                {
                    PostalCode = _configuration["Store:PostalCode"] ?? "",
                    Country = _configuration["Store:Country"] ?? "PL"
                },
                Destination = new AddressInfo
                {
                    PostalCode = order.ShippingPostalCode ?? "",
                    Country = order.ShippingCountry ?? "PL"
                },
                Package = new PackageInfo
                {
                    Weight = weight,
                    Length = length,
                    Width = width,
                    Height = height,
                    DeclaredValue = order.TotalAmount
                }
            };
            
            var quotes = await _carrierApiService.GetShippingQuotesAsync(request);
            
            return Json(new { success = true, quotes });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting shipping quotes for order {OrderId}", orderId);
            return Json(new { success = false, message = "Error retrieving shipping quotes" });
        }
    }

    /// <summary>
    /// POST: Process carrier webhook
    /// </summary>
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CarrierWebhook([FromRoute] string carrierCode)
    {
        try
        {
            using var reader = new StreamReader(Request.Body);
            var payload = await reader.ReadToEndAsync();
            var signature = Request.Headers["X-Webhook-Signature"].ToString();
            
            var result = await _carrierApiService.ProcessWebhookAsync(carrierCode, payload, signature);
            
            if (result.Success)
            {
                return Ok(new { success = true });
            }
            
            return BadRequest(new { success = false, message = result.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing carrier webhook for {CarrierCode}", carrierCode);
            return StatusCode(500, new { success = false, message = "Error processing webhook" });
        }
    }

    #endregion

    public async Task<IActionResult> Settings(string? tab = null)
    {
        _logger.LogInformation("Admin accessed site settings");
        
        // Pass tab parameter to view for active tab selection
        if (!string.IsNullOrEmpty(tab))
        {
            ViewBag.ActiveTab = tab;
        }

        var viewModel = new SiteSettingsViewModel();

        try
        {
            // Get carousel slides (exclude soft-deleted)
            var carouselSlides = await _unitOfWork.CarouselSlides.GetAllAsync();
            var activeCarouselSlides = carouselSlides.Where(c => !c.IsDeleted).ToList();
            viewModel.CarouselSlides = activeCarouselSlides.Select(c => new CarouselSlideItemViewModel
            {
                Id = c.Id,
                Title = c.Title,
                Subtitle = c.Subtitle,
                ImagePath = c.ImagePath,
                LinkUrl = c.LinkUrl,
                ButtonText = c.ButtonText,
                DisplayOrder = c.DisplayOrder,
                IsActive = c.IsActive,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                Location = c.Location,
                CreatedAt = c.CreatedAt,
                CreatedBy = c.CreatedBy
            }).OrderBy(c => c.DisplayOrder).ToList();

            viewModel.TotalCarouselSlides = activeCarouselSlides.Count();
            viewModel.ActiveCarouselSlides = activeCarouselSlides.Count(c => c.IsActive);

            // Get categories
            var categories = await _unitOfWork.Categories.GetAllAsync();
            var categoryViewModels = new List<CategoryItemViewModel>();

            foreach (var category in categories.Where(c => c.ParentCategoryId == null).OrderBy(c => c.DisplayOrder))
            {
                var categoryVm = new CategoryItemViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    NameKey = category.NameKey,
                    Slug = category.Slug,
                    ParentCategoryId = category.ParentCategoryId,
                    DisplayOrder = category.DisplayOrder,
                    ShowInNavbar = category.ShowInNavbar,
                    IsActive = category.IsActive,
                    IconCssClass = category.IconCssClass,
                    ImageUrl = category.ImageUrl,
                    ProductCount = category.Products.Count,
                    SubcategoryCount = categories.Count(c => c.ParentCategoryId == category.Id)
                };

                // Get subcategories
                categoryVm.Subcategories = categories
                    .Where(c => c.ParentCategoryId == category.Id)
                    .OrderBy(c => c.DisplayOrder)
                    .Select(sub => new CategoryItemViewModel
                    {
                        Id = sub.Id,
                        Name = sub.Name,
                        NameKey = sub.NameKey,
                        Slug = sub.Slug,
                        ParentCategoryId = sub.ParentCategoryId,
                        ParentCategoryName = category.Name,
                        DisplayOrder = sub.DisplayOrder,
                        ShowInNavbar = sub.ShowInNavbar,
                        IsActive = sub.IsActive,
                        IconCssClass = sub.IconCssClass,
                        ImageUrl = sub.ImageUrl,
                        ProductCount = sub.Products.Count,
                        SubcategoryCount = 0
                    }).ToList();

                categoryViewModels.Add(categoryVm);
            }

            viewModel.Categories = categoryViewModels;
            viewModel.TotalCategories = categories.Count(c => c.ParentCategoryId == null);
            viewModel.ActiveCategories = categories.Count(c => c.IsActive && c.ParentCategoryId == null);
            viewModel.TotalSubcategories = categories.Count(c => c.ParentCategoryId != null);

            // Get blog posts
            var blogs = await _unitOfWork.Blogs.GetAllAsync();
            var currentCulture = System.Globalization.CultureInfo.CurrentCulture.Name;
            
            viewModel.BlogPosts = new List<BlogItemViewModel>();
            foreach (var blog in blogs.Where(b => !b.IsDeleted).OrderByDescending(b => b.CreatedAt))
            {
                var translations = (await _unitOfWork.Repository<Entity.BlogTranslation>()
                    .FindAsync(t => t.BlogId == blog.Id)).ToList();
                
                var translation = translations.FirstOrDefault(t => t.CultureCode == currentCulture)
                                ?? translations.FirstOrDefault(t => t.CultureCode == "pl-PL");

                if (translation != null)
                {
                    viewModel.BlogPosts.Add(new BlogItemViewModel
                    {
                        Id = blog.Id,
                        Title = translation.Title,
                        Slug = translation.Slug,
                        FeaturedImage = blog.FeaturedImage,
                        AuthorName = blog.Author?.UserName ?? "Unknown",
                        CategoryName = blog.Category?.Name ?? "Uncategorized",
                        IsPublished = blog.IsPublished,
                        PublishedDate = blog.PublishedDate,
                        Views = blog.Views,
                        CreatedAt = blog.CreatedAt,
                        UpdatedAt = blog.UpdatedAt
                    });
                }
            }
            
            viewModel.TotalBlogs = blogs.Count(b => !b.IsDeleted);
            viewModel.PublishedBlogs = blogs.Count(b => !b.IsDeleted && b.IsPublished);
            viewModel.DraftBlogs = blogs.Count(b => !b.IsDeleted && !b.IsPublished);

            // Supported Languages (placeholder - you can implement database storage later)
            viewModel.SupportedLanguages = new List<LanguageViewModel>
            {
                new LanguageViewModel
                {
                    Id = 1,
                    CultureCode = "en-US",
                    DisplayName = "English",
                    NativeName = "English",
                    FlagIcon = "🇺🇸",
                    IsEnabled = true,
                    IsDefault = false,
                    DisplayOrder = 1
                },
                new LanguageViewModel
                {
                    Id = 2,
                    CultureCode = "pl-PL",
                    DisplayName = "Polish",
                    NativeName = "Polski",
                    FlagIcon = "🇵🇱",
                    IsEnabled = true,
                    IsDefault = true,
                    DisplayOrder = 2
                }
            };

            // Translation keys - no longer showing placeholder data, 
            // will be loaded via AJAX in the UI
            viewModel.TranslationKeys = new List<TranslationKeyViewModel>();
            
            // Count resource file pairs (each category has en-US and pl-PL)
            var resourceFolders = await _translationManagementService.GetAllTranslationFilesAsync();
            viewModel.TotalTranslationKeys = resourceFolders.Sum(f => f.KeyCount);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading site settings");
        }

        return View(viewModel);
    }



    #region Carousel Slide Management

    /// <summary>
    /// GET: Create new carousel slide form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> CarouselCreate()
    {
        ViewData["Title"] = _localizationService["Admin_Carousel_CreateNew"];
        
        var viewModel = new CarouselSlideCreateDto
        {
            DisplayOrder = 0,
            IsActive = true,
            Location = "Home",
            TextAlign = "center",
            AnimationType = "fade",
            Duration = 5000,
            ButtonClass = "btn-primary",
            Translations = new List<CarouselSlideTranslationDto>
            {
                new CarouselSlideTranslationDto 
                { 
                    CultureCode = "en-US",
                    Title = "",
                    Subtitle = "",
                    ButtonText = "",
                    ImageAlt = ""
                },
                new CarouselSlideTranslationDto 
                { 
                    CultureCode = "pl-PL",
                    Title = "",
                    Subtitle = "",
                    ButtonText = "",
                    ImageAlt = ""
                }
            }
        };

        // Load categories for dropdown
        var categories = await _unitOfWork.Categories.GetAllAsync();
        ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();

        return View(viewModel);
    }

    /// <summary>
    /// POST: Create new carousel slide
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CarouselCreate(CarouselSlideCreateDto model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorSave"];
            return View(model);
        }

        try
        {
            // Process images from temp folder to permanent location
            var (desktopPath, tabletPath, mobilePath) = await _carouselImageService.ProcessAndMoveFromTempAsync(
                model.DesktopImageTempFileName,
                model.TabletImageTempFileName,
                model.MobileImageTempFileName
            );

            // Create the carousel slide entity
            var slide = new CarouselSlide
            {
                ImagePath = desktopPath,
                TabletImagePath = !string.IsNullOrEmpty(tabletPath) ? tabletPath : desktopPath,
                MobileImagePath = !string.IsNullOrEmpty(mobilePath) ? mobilePath : (!string.IsNullOrEmpty(tabletPath) ? tabletPath : desktopPath),
                DisplayOrder = model.DisplayOrder,
                IsActive = model.IsActive,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Location = model.Location,
                CategoryId = model.CategoryId,
                BackgroundColor = model.BackgroundColor,
                TextColor = model.TextColor,
                TextAlign = model.TextAlign,
                AnimationType = model.AnimationType,
                Duration = model.Duration,
                CustomCssClass = model.CustomCssClass,
                ButtonClass = model.ButtonClass ?? "btn-primary",
                
                // Temporary values from first translation (will be replaced by translation entity)
                Title = model.Translations.FirstOrDefault()?.Title ?? "Untitled",
                ImageAlt = model.Translations.FirstOrDefault()?.ImageAlt ?? "Carousel slide"
            };

            // Save slide to get ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system";
            var createdSlide = await _carouselService.CreateSlideAsync(slide, userId);

            // Create translations for each language
            foreach (var translationDto in model.Translations)
            {
                var translation = new CarouselSlideTranslation
                {
                    CarouselSlideId = createdSlide.Id,
                    CultureCode = translationDto.CultureCode,
                    Title = translationDto.Title,
                    Subtitle = translationDto.Subtitle,
                    ButtonText = translationDto.ButtonText,
                    ImageAlt = translationDto.ImageAlt ?? translationDto.Title,
                    LinkUrl = translationDto.LinkUrl,
                    ControllerName = translationDto.ControllerName,
                    ActionName = translationDto.ActionName,
                    AreaName = translationDto.AreaName,
                    RouteParameters = translationDto.RouteParameters
                };

                await _unitOfWork.CarouselSlideTranslations.AddAsync(translation);
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Carousel slide created successfully: {SlideId}", createdSlide.Id);
            TempData["Success"] = _localizationService["Admin_Carousel_SuccessCreated"];
            
            return RedirectToAction(nameof(Settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating carousel slide");
            
            // Clean up temp files on error
            var tempFilesToCleanup = new[] 
            { 
                model.DesktopImageTempFileName, 
                model.TabletImageTempFileName, 
                model.MobileImageTempFileName 
            }
            .Where(f => !string.IsNullOrEmpty(f))
            .Select(f => f!)
            .ToArray();
            
            if (tempFilesToCleanup.Length > 0)
            {
                await _carouselImageService.DeleteTempFilesAsync(tempFilesToCleanup);
            }

            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorSave"];
            return View(model);
        }
    }

    /// <summary>
    /// GET: Edit carousel slide form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> CarouselEdit(int id)
    {
        var slide = await _unitOfWork.CarouselSlides.GetByIdAsync(id);
        if (slide == null)
        {
            TempData["Error"] = "Carousel slide not found";
            return RedirectToAction(nameof(Settings));
        }

        // Load translations
        var translations = (await _unitOfWork.CarouselSlideTranslations.FindAsync(t => t.CarouselSlideId == id)).ToList();

        var viewModel = new CarouselSlideUpdateDto
        {
            Id = slide.Id,
            DisplayOrder = slide.DisplayOrder,
            IsActive = slide.IsActive,
            StartDate = slide.StartDate,
            EndDate = slide.EndDate,
            Location = slide.Location,
            CategoryId = slide.CategoryId,
            BackgroundColor = slide.BackgroundColor,
            TextColor = slide.TextColor,
            TextAlign = slide.TextAlign,
            AnimationType = slide.AnimationType,
            Duration = slide.Duration,
            CustomCssClass = slide.CustomCssClass,
            ButtonClass = slide.ButtonClass,
            Translations = translations.Select(t => new CarouselSlideTranslationDto
            {
                Id = t.Id,
                CultureCode = t.CultureCode,
                Title = t.Title,
                Subtitle = t.Subtitle,
                ButtonText = t.ButtonText,
                ImageAlt = t.ImageAlt,
                LinkUrl = t.LinkUrl,
                ControllerName = t.ControllerName,
                ActionName = t.ActionName,
                AreaName = t.AreaName,
                RouteParameters = t.RouteParameters
            }).ToList()
        };

        // Ensure we have translations for both languages
        if (!viewModel.Translations.Any(t => t.CultureCode == "en-US"))
        {
            viewModel.Translations.Add(new CarouselSlideTranslationDto { CultureCode = "en-US" });
        }
        if (!viewModel.Translations.Any(t => t.CultureCode == "pl-PL"))
        {
            viewModel.Translations.Add(new CarouselSlideTranslationDto { CultureCode = "pl-PL" });
        }

        // Load current images for preview
        ViewBag.CurrentDesktopImage = slide.ImagePath;
        ViewBag.CurrentTabletImage = slide.TabletImagePath;
        ViewBag.CurrentMobileImage = slide.MobileImagePath;

        // Load categories for dropdown
        var categories = await _unitOfWork.Categories.GetAllAsync();
        ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();

        ViewData["Title"] = _localizationService["Admin_Carousel_EditSlide"];
        return View(viewModel);
    }

    /// <summary>
    /// POST: Update carousel slide
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CarouselEdit(CarouselSlideUpdateDto model)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorSave"];
            return View(model);
        }

        try
        {
            var slide = await _unitOfWork.CarouselSlides.GetByIdAsync(model.Id);
            if (slide == null)
            {
                TempData["Error"] = "Carousel slide not found";
                return RedirectToAction(nameof(Settings));
            }

            // Process new images if provided
            if (!string.IsNullOrEmpty(model.NewDesktopImageTempFileName) ||
                !string.IsNullOrEmpty(model.NewTabletImageTempFileName) ||
                !string.IsNullOrEmpty(model.NewMobileImageTempFileName))
            {
                var (desktopPath, tabletPath, mobilePath) = await _carouselImageService.ProcessAndMoveFromTempAsync(
                    model.NewDesktopImageTempFileName ?? null,
                    model.NewTabletImageTempFileName ?? null,
                    model.NewMobileImageTempFileName ?? null
                );

                // Delete old images
                if (!string.IsNullOrEmpty(desktopPath))
                {
                    await _carouselImageService.DeletePermanentImagesAsync(slide.ImagePath);
                    slide.ImagePath = desktopPath;
                }

                if (!string.IsNullOrEmpty(tabletPath))
                {
                    if (!string.IsNullOrEmpty(slide.TabletImagePath))
                    {
                        await _carouselImageService.DeletePermanentImagesAsync(slide.TabletImagePath);
                    }
                    slide.TabletImagePath = tabletPath;
                }

                if (!string.IsNullOrEmpty(mobilePath))
                {
                    if (!string.IsNullOrEmpty(slide.MobileImagePath))
                    {
                        await _carouselImageService.DeletePermanentImagesAsync(slide.MobileImagePath);
                    }
                    slide.MobileImagePath = mobilePath;
                }
            }

            // Update slide properties
            slide.DisplayOrder = model.DisplayOrder;
            slide.IsActive = model.IsActive;
            slide.StartDate = model.StartDate;
            slide.EndDate = model.EndDate;
            slide.Location = model.Location;
            slide.CategoryId = model.CategoryId;
            slide.BackgroundColor = model.BackgroundColor;
            slide.TextColor = model.TextColor;
            slide.TextAlign = model.TextAlign;
            slide.AnimationType = model.AnimationType;
            slide.Duration = model.Duration;
            slide.CustomCssClass = model.CustomCssClass;
            slide.ButtonClass = model.ButtonClass;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system";
            await _carouselService.UpdateSlideAsync(slide, userId);

            // Update or create translations
            foreach (var translationDto in model.Translations)
            {
                if (translationDto.Id.HasValue)
                {
                    // Update existing translation
                    var existingTranslation = await _unitOfWork.CarouselSlideTranslations.GetByIdAsync(translationDto.Id.Value);
                    if (existingTranslation != null)
                    {
                        existingTranslation.Title = translationDto.Title;
                        existingTranslation.Subtitle = translationDto.Subtitle;
                        existingTranslation.ButtonText = translationDto.ButtonText;
                        existingTranslation.ImageAlt = translationDto.ImageAlt ?? translationDto.Title;
                        existingTranslation.LinkUrl = translationDto.LinkUrl;
                        existingTranslation.ControllerName = translationDto.ControllerName;
                        existingTranslation.ActionName = translationDto.ActionName;
                        existingTranslation.AreaName = translationDto.AreaName;
                        existingTranslation.RouteParameters = translationDto.RouteParameters;
                        existingTranslation.UpdatedAt = DateTime.UtcNow;

                        _unitOfWork.CarouselSlideTranslations.Update(existingTranslation);
                    }
                }
                else
                {
                    // Create new translation
                    var newTranslation = new CarouselSlideTranslation
                    {
                        CarouselSlideId = slide.Id,
                        CultureCode = translationDto.CultureCode,
                        Title = translationDto.Title,
                        Subtitle = translationDto.Subtitle,
                        ButtonText = translationDto.ButtonText,
                        ImageAlt = translationDto.ImageAlt ?? translationDto.Title,
                        LinkUrl = translationDto.LinkUrl,
                        ControllerName = translationDto.ControllerName,
                        ActionName = translationDto.ActionName,
                        AreaName = translationDto.AreaName,
                        RouteParameters = translationDto.RouteParameters
                    };

                    await _unitOfWork.CarouselSlideTranslations.AddAsync(newTranslation);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Carousel slide updated successfully: {SlideId}", slide.Id);
            TempData["Success"] = _localizationService["Admin_Carousel_SuccessUpdated"];

            return RedirectToAction(nameof(Settings));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating carousel slide");

            // Clean up temp files on error
            var tempFilesToCleanup = new[] 
            { 
                model.NewDesktopImageTempFileName, 
                model.NewTabletImageTempFileName, 
                model.NewMobileImageTempFileName 
            }
            .Where(f => !string.IsNullOrEmpty(f))
            .Select(f => f!)
            .ToArray();
            
            if (tempFilesToCleanup.Length > 0)
            {
                await _carouselImageService.DeleteTempFilesAsync(tempFilesToCleanup);
            }

            var categories = await _unitOfWork.Categories.GetAllAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorSave"];
            return View(model);
        }
    }

    /// <summary>
    /// POST: Delete carousel slide
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CarouselDelete(int id)
    {
        try
        {
            var slide = await _unitOfWork.CarouselSlides.GetByIdAsync(id);
            if (slide == null)
            {
                TempData["Error"] = _localizationService["Admin_Carousel_NotFound"];
                return RedirectToAction(nameof(Settings), new { tab = "carousel" });
            }

            _logger.LogInformation("Deleting carousel slide {SlideId}: Desktop={Desktop}, Tablet={Tablet}, Mobile={Mobile}", 
                id, slide.ImagePath, slide.TabletImagePath, slide.MobileImagePath);

            // Delete physical image files FIRST before soft delete
            var imagesToDelete = new List<string>();
            if (!string.IsNullOrEmpty(slide.ImagePath)) imagesToDelete.Add(slide.ImagePath);
            if (!string.IsNullOrEmpty(slide.TabletImagePath)) imagesToDelete.Add(slide.TabletImagePath);
            if (!string.IsNullOrEmpty(slide.MobileImagePath)) imagesToDelete.Add(slide.MobileImagePath);

            foreach (var imagePath in imagesToDelete)
            {
                try
                {
                    await _carouselImageService.DeletePermanentImagesAsync(imagePath);
                    _logger.LogInformation("Successfully deleted image: {ImagePath}", imagePath);
                }
                catch (Exception imgEx)
                {
                    _logger.LogError(imgEx, "Failed to delete image: {ImagePath}", imagePath);
                    // Continue with other deletions even if one fails
                }
            }

            // Delete from database (soft delete)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "system";
            await _carouselService.DeleteSlideAsync(id, userId);

            _logger.LogInformation("Carousel slide deleted successfully: {SlideId} by user {UserId}", id, userId);
            TempData["Success"] = _localizationService["Admin_Carousel_SuccessDeleted"];
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting carousel slide {SlideId}", id);
            TempData["Error"] = _localizationService["Admin_Carousel_ErrorDeleted"];
        }

        return RedirectToAction(nameof(Settings), new { tab = "carousel" });
    }

    /// <summary>
    /// POST: Upload image to temp folder (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CarouselUploadImage(IFormFile file, string imageType)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return Json(new { success = false, message = "No file provided" });
            }

            var tempFileName = await _carouselImageService.UploadToTempAsync(file, imageType);

            return Json(new
            {
                success = true,
                tempFileName = tempFileName,
                tempPath = $"/img/Carousel/temp/{tempFileName}",
                message = "Image uploaded successfully"
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading carousel image");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Delete temp files (AJAX) - called when user cancels
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CarouselCancelUpload([FromBody] CarouselCancelUploadDto model)
    {
        try
        {
            await _carouselImageService.DeleteTempFilesAsync(model.TempFileNames.ToArray());

            return Json(new { success = true, message = "Temp files deleted" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting temp files");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Toggle carousel slide active status (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CarouselToggleActive(int id)
    {
        try
        {
            var result = await _carouselService.ToggleActiveStatusAsync(id);

            if (result)
            {
                return Json(new { success = true, message = "Status toggled successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Slide not found" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling carousel slide status");
            return Json(new { success = false, message = ex.Message });
        }
    }

    #endregion

    #region Category Management

    /// <summary>
    /// GET: Create new category form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> CategoryCreate()
    {
        ViewData["Title"] = _localizationService["Admin_Category_CreateNew"];
        
        var viewModel = new CategoryCreateDto
        {
            DisplayOrder = 0,
            IsActive = true,
            ShowInNavbar = true,
            Translations = new List<CategoryTranslationDto>
            {
                new CategoryTranslationDto 
                { 
                    CultureCode = "en-US",
                    Name = "",
                    Slug = "",
                    Description = ""
                },
                new CategoryTranslationDto 
                { 
                    CultureCode = "pl-PL",
                    Name = "",
                    Slug = "",
                    Description = ""
                }
            }
        };

        // Load parent categories for dropdown
        var categories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
        ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();

        return View(viewModel);
    }

    /// <summary>
    /// POST: Create new category
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CategoryCreate(CategoryCreateDto model)
    {
        // Prevent subcategories from having parent categories (no sub-subcategories)
        if (model.ParentCategoryId.HasValue)
        {
            var parentCategory = await _unitOfWork.Categories.GetByIdAsync(model.ParentCategoryId.Value);
            if (parentCategory != null && parentCategory.ParentCategoryId.HasValue)
            {
                ModelState.AddModelError("ParentCategoryId", "Cannot create a subcategory under another subcategory. Only 2 levels are supported.");
            }
        }

        if (!ModelState.IsValid)
        {
            var categories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
            ViewBag.Categories = categories.OrderBy(c => c.DisplayOrder).ToList();
            TempData["Error"] = _localizationService["Admin_Category_ErrorSave"];
            return View(model);
        }

        var tempFilesToCleanup = new string[] { };

        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Create the category entity
            var category = new Category
            {
                Name = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US")?.Name ?? "Unnamed",
                Slug = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US")?.Slug ?? "unnamed",
                Description = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US")?.Description,
                ParentCategoryId = model.ParentCategoryId,
                DisplayOrder = model.DisplayOrder,
                IsActive = model.IsActive,
                ShowInNavbar = model.ShowInNavbar,
                IconCssClass = model.IconCssClass,
                CreatedBy = userId,
                CreatedAt = DateTime.UtcNow
            };

            // Handle image upload for main categories
            if (!string.IsNullOrEmpty(model.ImageTempFileName))
            {
                tempFilesToCleanup = new[] { model.ImageTempFileName };
                var imageUrl = await _categoryImageService.MoveTempImageToPermanentAsync(
                    model.ImageTempFileName, 
                    category.Slug);
                category.ImageUrl = imageUrl;
            }

            // Add category to database
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveChangesAsync();

            // Add translations
            foreach (var translationDto in model.Translations)
            {
                var translation = new CategoryTranslation
                {
                    CategoryId = category.Id,
                    CultureCode = translationDto.CultureCode,
                    Name = translationDto.Name,
                    Slug = translationDto.Slug,
                    Description = translationDto.Description,
                    MetaDescription = translationDto.MetaDescription,
                    MetaKeywords = translationDto.MetaKeywords,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.CategoryTranslations.AddAsync(translation);
            }

            await _unitOfWork.SaveChangesAsync();

            TempData["Success"] = _localizationService["Admin_Category_SuccessCreate"];
            _logger.LogInformation("Category created: {CategoryId} by {UserId}", category.Id, userId);

            return RedirectToAction(nameof(Settings), new { tab = "categories" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating category");
            TempData["Error"] = _localizationService["Admin_Category_ErrorSave"];
            
            if (tempFilesToCleanup.Length > 0)
            {
                await _categoryImageService.CleanupTempFilesAsync(tempFilesToCleanup.ToList());
            }

            var categories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
            ViewBag.ParentCategories = categories.OrderBy(c => c.DisplayOrder).ToList();
            return View(model);
        }
    }

    /// <summary>
    /// GET: Edit category form
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> CategoryEdit(int id)
    {
        var category = await _unitOfWork.Categories.GetByIdWithTranslationsAsync(id);
        if (category == null)
        {
            TempData["Error"] = "Category not found";
            return RedirectToAction(nameof(Settings));
        }

        var viewModel = new CategoryUpdateDto
        {
            Id = category.Id,
            ParentCategoryId = category.ParentCategoryId,
            DisplayOrder = category.DisplayOrder,
            IsActive = category.IsActive,
            ShowInNavbar = category.ShowInNavbar,
            IconCssClass = category.IconCssClass,
            Translations = category.Translations.Select(t => new CategoryTranslationDto
            {
                Id = t.Id,
                CultureCode = t.CultureCode,
                Name = t.Name,
                Slug = t.Slug,
                Description = t.Description,
                MetaDescription = t.MetaDescription,
                MetaKeywords = t.MetaKeywords
            }).ToList()
        };

        // Ensure we have translations for both languages
        if (!viewModel.Translations.Any(t => t.CultureCode == "en-US"))
        {
            viewModel.Translations.Add(new CategoryTranslationDto { CultureCode = "en-US" });
        }
        if (!viewModel.Translations.Any(t => t.CultureCode == "pl-PL"))
        {
            viewModel.Translations.Add(new CategoryTranslationDto { CultureCode = "pl-PL" });
        }

        // Load current image for preview
        ViewBag.CurrentImage = category.ImageUrl;

        // Only show top-level categories as parent options (no subcategories)
        // Exclude current category to prevent self-parenting
        var allCategories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
        ViewBag.Categories = allCategories
            .Where(c => c.Id != id)
            .OrderBy(c => c.DisplayOrder)
            .ToList();

        ViewData["Title"] = _localizationService["Admin_Category_Edit"];
        return View(viewModel);
    }

    /// <summary>
    /// POST: Update category
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CategoryEdit(CategoryUpdateDto model)
    {
        // Prevent subcategories from having parent categories (no sub-subcategories)
        if (model.ParentCategoryId.HasValue)
        {
            var parentCategory = await _unitOfWork.Categories.GetByIdAsync(model.ParentCategoryId.Value);
            if (parentCategory != null && parentCategory.ParentCategoryId.HasValue)
            {
                ModelState.AddModelError("ParentCategoryId", "Cannot set parent to a subcategory. Only 2 levels are supported.");
            }

            // Prevent category from being its own parent
            if (model.ParentCategoryId.Value == model.Id)
            {
                ModelState.AddModelError("ParentCategoryId", "A category cannot be its own parent.");
            }
        }

        if (!ModelState.IsValid)
        {
            // Only show top-level categories as parent options (no subcategories)
            var allCategories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
            ViewBag.Categories = allCategories
                .Where(c => c.Id != model.Id)
                .OrderBy(c => c.DisplayOrder)
                .ToList();
            TempData["Error"] = _localizationService["Admin_Category_ErrorSave"];
            return View(model);
        }

        var tempFilesToCleanup = new string[] { };

        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var category = await _unitOfWork.Categories.GetByIdWithTranslationsAsync(model.Id);
            
            if (category == null)
            {
                TempData["Error"] = "Category not found";
                return RedirectToAction(nameof(Settings));
            }

            // Handle new image upload
            if (!string.IsNullOrEmpty(model.NewImageTempFileName))
            {
                tempFilesToCleanup = new[] { model.NewImageTempFileName };
                
                // Delete old image
                if (!string.IsNullOrEmpty(category.ImageUrl))
                {
                    await _categoryImageService.DeleteCategoryImageAsync(category.ImageUrl);
                }

                // Move new image to permanent location
                var newSlug = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US")?.Slug ?? category.Slug;
                var imageUrl = await _categoryImageService.MoveTempImageToPermanentAsync(
                    model.NewImageTempFileName,
                    newSlug);
                category.ImageUrl = imageUrl;
            }

            // Update category properties
            category.ParentCategoryId = model.ParentCategoryId;
            category.DisplayOrder = model.DisplayOrder;
            category.IsActive = model.IsActive;
            category.ShowInNavbar = model.ShowInNavbar;
            category.IconCssClass = model.IconCssClass;
            category.UpdatedBy = userId;
            category.UpdatedAt = DateTime.UtcNow;

            // Update default name and slug from English translation
            var enTranslation = model.Translations.FirstOrDefault(t => t.CultureCode == "en-US");
            if (enTranslation != null)
            {
                category.Name = enTranslation.Name;
                category.Slug = enTranslation.Slug;
                category.Description = enTranslation.Description;
            }

            // Update translations
            foreach (var translationDto in model.Translations)
            {
                var existingTranslation = category.Translations
                    .FirstOrDefault(t => t.CultureCode == translationDto.CultureCode);

                if (existingTranslation != null)
                {
                    // Update existing translation
                    existingTranslation.Name = translationDto.Name;
                    existingTranslation.Slug = translationDto.Slug;
                    existingTranslation.Description = translationDto.Description;
                    existingTranslation.MetaDescription = translationDto.MetaDescription;
                    existingTranslation.MetaKeywords = translationDto.MetaKeywords;
                    existingTranslation.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    // Add new translation
                    var newTranslation = new CategoryTranslation
                    {
                        CategoryId = category.Id,
                        CultureCode = translationDto.CultureCode,
                        Name = translationDto.Name,
                        Slug = translationDto.Slug,
                        Description = translationDto.Description,
                        MetaDescription = translationDto.MetaDescription,
                        MetaKeywords = translationDto.MetaKeywords,
                        CreatedAt = DateTime.UtcNow
                    };
                    await _unitOfWork.CategoryTranslations.AddAsync(newTranslation);
                }
            }

            _unitOfWork.Categories.Update(category);
            await _unitOfWork.SaveChangesAsync();

            TempData["Success"] = _localizationService["Admin_Category_SuccessUpdate"];
            _logger.LogInformation("Category updated: {CategoryId} by {UserId}", category.Id, userId);

            return RedirectToAction(nameof(Settings), new { tab = "categories" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating category");
            TempData["Error"] = _localizationService["Admin_Category_ErrorSave"];
            
            if (tempFilesToCleanup.Length > 0)
            {
                await _categoryImageService.CleanupTempFilesAsync(tempFilesToCleanup.ToList());
            }

            // Only show top-level categories as parent options (no subcategories)
            var allCategories = await _unitOfWork.Categories.GetTopLevelCategoriesAsync();
            ViewBag.Categories = allCategories
                .Where(c => c.Id != model.Id)
                .OrderBy(c => c.DisplayOrder)
                .ToList();
            return View(model);
        }
    }

    /// <summary>
    /// POST: Delete category
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CategoryDelete(int id)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetByIdWithTranslationsAsync(id);
            if (category == null)
            {
                TempData["Error"] = "Category not found";
                return RedirectToAction(nameof(Settings));
            }

            // Delete category image if exists
            if (!string.IsNullOrEmpty(category.ImageUrl))
            {
                await _categoryImageService.DeleteCategoryImageAsync(category.ImageUrl);
            }

            // Delete category (translations will cascade)
            _unitOfWork.Categories.Remove(category);
            await _unitOfWork.SaveChangesAsync();

            TempData["Success"] = _localizationService["Admin_Category_SuccessDelete"];
            _logger.LogInformation("Category deleted: {CategoryId}", id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting category: {CategoryId}", id);
            TempData["Error"] = _localizationService["Admin_Category_ErrorDelete"];
        }

        return RedirectToAction(nameof(Settings), new { tab = "categories" });
    }

    /// <summary>
    /// POST: Upload category image to temp folder (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CategoryUploadImage(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return Json(new { success = false, message = "No file uploaded" });
            }

            var tempFileName = await _categoryImageService.UploadCategoryImageAsync(file, "img/temp");
            var tempPath = $"/img/temp/{tempFileName}";

            return Json(new { 
                success = true, 
                tempFileName = tempFileName,
                tempPath = tempPath
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error uploading category image");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Delete temp files (AJAX) - called when user cancels
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CategoryCancelUpload([FromBody] CategoryCancelUploadDto model)
    {
        try
        {
            await _categoryImageService.CleanupTempFilesAsync(model.TempFileNames);
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error cleaning up temp files");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Toggle category active status (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CategoryToggleActive(int id)
    {
        try
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            
            if (category != null)
            {
                category.IsActive = !category.IsActive;
                category.UpdatedAt = DateTime.UtcNow;
                category.UpdatedBy = User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                _unitOfWork.Categories.Update(category);
                await _unitOfWork.SaveChangesAsync();
                
                var status = category.IsActive ? "activated" : "deactivated";
                return Json(new { success = true, message = $"Category {status} successfully", isActive = category.IsActive });
            }
            else
            {
                return Json(new { success = false, message = "Category not found" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling category status");
            return Json(new { success = false, message = ex.Message });
        }
    }

    #endregion



    #region Translation Management

    /// <summary>
    /// GET: Get all translation files (AJAX)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAllTranslationFiles()
    {
        try
        {
            var files = await _translationManagementService.GetAllTranslationFilesAsync();
            return Json(new { success = true, data = files });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting translation files");
            return Json(new { success = false, message = "Error loading translation files" });
        }
    }

    /// <summary>
    /// GET: Get translations by file (AJAX)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetTranslationsByFile(string fileName)
    {
        try
        {
            var translations = await _translationManagementService.GetTranslationsByFileAsync(fileName);
            return Json(new { success = true, data = translations });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting translations for file: {FileName}", fileName);
            return Json(new { success = false, message = "Error loading translations" });
        }
    }

    /// <summary>
    /// POST: Search translations (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> SearchTranslations([FromBody] TranslationSearchDto model)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(model.SearchTerm))
            {
                return Json(new { success = true, data = new List<object>() });
            }

            var results = await _translationManagementService.SearchTranslationsAsync(
                model.SearchTerm, 
                model.FileName
            );

            return Json(new { success = true, data = results, count = results.Count });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error searching translations");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Update translation (AJAX - Live update)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateTranslation([FromBody] TranslationUpdateDto model)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(model.FileName) || 
                string.IsNullOrWhiteSpace(model.Key) || 
                string.IsNullOrWhiteSpace(model.CultureCode))
            {
                return Json(new { success = false, message = "Invalid translation data" });
            }

            // Only allow en-US and pl-PL
            if (model.CultureCode != "en-US" && model.CultureCode != "pl-PL")
            {
                return Json(new { success = false, message = "Only English (en-US) and Polish (pl-PL) translations are supported" });
            }

            var success = await _translationManagementService.UpdateTranslationAsync(
                model.FileName, 
                model.Key, 
                model.CultureCode, 
                model.Value);

            if (success)
            {
                _logger.LogInformation("Translation updated: {File}.{Key} ({Culture}) = {Value}", 
                    model.FileName, model.Key, model.CultureCode, model.Value);
                
                // Force browser to not cache responses
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                Response.Headers["Pragma"] = "no-cache";
                Response.Headers["Expires"] = "0";
                
                return Json(new { 
                    success = true, 
                    message = "Translation updated successfully. Changes will appear immediately on page refresh." 
                });
            }
            else
            {
                return Json(new { success = false, message = "Failed to update translation" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating translation");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Update translation comment (AJAX)
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> UpdateTranslationComment([FromBody] TranslationCommentUpdateDto model)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(model.FileName) || string.IsNullOrWhiteSpace(model.Key))
            {
                return Json(new { success = false, message = "Invalid data" });
            }

            var success = await _translationManagementService.UpdateCommentAsync(
                model.FileName, 
                model.Key, 
                model.Comment ?? string.Empty);

            if (success)
            {
                _logger.LogInformation("Translation comment updated: {File}.{Key}", model.FileName, model.Key);
                
                // Force browser to not cache responses
                Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
                Response.Headers["Pragma"] = "no-cache";
                Response.Headers["Expires"] = "0";
                
                return Json(new { success = true, message = "Comment updated successfully" });
            }
            else
            {
                return Json(new { success = false, message = "Failed to update comment" });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating translation comment");
            return Json(new { success = false, message = ex.Message });
        }
    }

    #endregion

    #region Shipping Management

    // GET: /Admin/ShippingProviders
    public async Task<IActionResult> ShippingProviders()
    {
        var providers = await _shippingService.GetAllProvidersAsync();
        var viewModel = new Kokomija.Models.ViewModels.ShippingProvidersViewModel
        {
            Providers = providers,
            TotalProviders = providers.Count,
            ActiveProviders = providers.Count(p => p.IsActive)
        };
        return View(viewModel);
    }

    // GET: /Admin/ShippingRates
    public async Task<IActionResult> ShippingRates()
    {
        var rates = await _shippingService.GetAllRatesAsync();
        var providers = await _shippingService.GetAllProvidersAsync();
        var viewModel = new Kokomija.Models.ViewModels.ShippingRatesViewModel
        {
            Rates = rates,
            Providers = providers,
            TotalRates = rates.Count,
            ActiveRates = rates.Count(r => r.IsActive)
        };
        return View(viewModel);
    }

    // POST: /Admin/CreateShippingProvider
    [HttpPost]
    public async Task<IActionResult> CreateShippingProvider([FromBody] Kokomija.Models.ViewModels.CreateShippingProviderDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _shippingService.CreateProviderAsync(dto);
        return Json(new { success = result.Success, message = result.Message, providerId = result.ProviderId });
    }

    // POST: /Admin/UpdateShippingProvider
    [HttpPost]
    public async Task<IActionResult> UpdateShippingProvider(int id, [FromBody] Kokomija.Models.ViewModels.UpdateShippingProviderDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _shippingService.UpdateProviderAsync(id, dto);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/DeleteShippingProvider
    [HttpPost]
    public async Task<IActionResult> DeleteShippingProvider(int id)
    {
        var result = await _shippingService.DeleteProviderAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/ToggleShippingProvider
    [HttpPost]
    public async Task<IActionResult> ToggleShippingProvider(int id)
    {
        var result = await _shippingService.ToggleProviderStatusAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/CreateShippingRate
    [HttpPost]
    public async Task<IActionResult> CreateShippingRate([FromBody] Kokomija.Models.ViewModels.CreateShippingRateDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _shippingService.CreateRateAsync(dto);
        return Json(new { success = result.Success, message = result.Message, rateId = result.RateId });
    }

    // POST: /Admin/UpdateShippingRate
    [HttpPost]
    public async Task<IActionResult> UpdateShippingRate(int id, [FromBody] Kokomija.Models.ViewModels.UpdateShippingRateDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _shippingService.UpdateRateAsync(id, dto);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/DeleteShippingRate
    [HttpPost]
    public async Task<IActionResult> DeleteShippingRate(int id)
    {
        var result = await _shippingService.DeleteRateAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/ToggleShippingRate
    [HttpPost]
    public async Task<IActionResult> ToggleShippingRate(int id)
    {
        var result = await _shippingService.ToggleRateStatusAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    #endregion

    #region Tax Management

    // GET: /Admin/TaxRates
    public async Task<IActionResult> TaxRates()
    {
        var taxRates = await _taxService.GetAllTaxRatesAsync();
        var defaultTaxRate = await _taxService.GetDefaultTaxRateAsync();
        
        var viewModel = new Kokomija.Models.ViewModels.TaxRatesViewModel
        {
            TaxRates = taxRates,
            TotalTaxRates = taxRates.Count,
            ActiveTaxRates = taxRates.Count(tr => tr.IsActive),
            DefaultTaxRate = defaultTaxRate
        };
        
        return View(viewModel);
    }

    // POST: /Admin/CreateTaxRate
    [HttpPost]
    public async Task<IActionResult> CreateTaxRate([FromBody] Kokomija.Models.ViewModels.CreateTaxRateDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _taxService.CreateTaxRateAsync(dto);
        return Json(new { success = result.Success, message = result.Message, taxRateId = result.TaxRateId });
    }

    // POST: /Admin/UpdateTaxRate
    [HttpPost]
    public async Task<IActionResult> UpdateTaxRate(int id, [FromBody] Kokomija.Models.ViewModels.UpdateTaxRateDto dto)
    {
        if (!ModelState.IsValid)
            return Json(new { success = false, message = "Invalid data provided" });

        var result = await _taxService.UpdateTaxRateAsync(id, dto);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/DeleteTaxRate
    [HttpPost]
    public async Task<IActionResult> DeleteTaxRate(int id)
    {
        var result = await _taxService.DeleteTaxRateAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/ToggleTaxRate
    [HttpPost]
    public async Task<IActionResult> ToggleTaxRate(int id)
    {
        var result = await _taxService.ToggleTaxRateStatusAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/SetDefaultTaxRate
    [HttpPost]
    public async Task<IActionResult> SetDefaultTaxRate(int id)
    {
        var result = await _taxService.SetDefaultTaxRateAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    // POST: /Admin/SyncTaxRateWithStripe
    [HttpPost]
    public async Task<IActionResult> SyncTaxRateWithStripe(int id)
    {
        var result = await _taxService.SyncTaxRateWithStripeAsync(id);
        return Json(new { success = result.Success, message = result.Message });
    }

    #endregion

    #region Commission Settings (ROOT Only)

    // GET: /Admin/CommissionSettings
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> CommissionSettings()
    {
        var settings = (await _unitOfWork.CommissionSettings.GetAllAsync()).FirstOrDefault();
        var activeClosure = (await _unitOfWork.SiteClosures.FindAsync(sc => sc.IsClosed)).FirstOrDefault();

        // Calculate earnings summary
        var today = DateTime.UtcNow.Date;
        var weekStart = today.AddDays(-(int)today.DayOfWeek);
        var monthStart = new DateTime(today.Year, today.Month, 1);
        var yearStart = new DateTime(today.Year, 1, 1);

        var allEarnings = await _unitOfWork.DeveloperEarnings.GetAllAsync();

        var summary = new Kokomija.Models.ViewModels.DeveloperEarningsSummaryDto
        {
            TodayEarnings = allEarnings.Where(e => e.EarnedAt.Date == today).Sum(e => e.DeveloperCommission),
            WeekEarnings = allEarnings.Where(e => e.EarnedAt.Date >= weekStart).Sum(e => e.DeveloperCommission),
            MonthEarnings = allEarnings.Where(e => e.EarnedAt >= monthStart).Sum(e => e.DeveloperCommission),
            YearEarnings = allEarnings.Where(e => e.EarnedAt >= yearStart).Sum(e => e.DeveloperCommission),
            AllTimeEarnings = allEarnings.Sum(e => e.DeveloperCommission),
            PendingPayout = allEarnings.Where(e => e.PayoutStatus == Entity.PayoutStatus.Pending).Sum(e => e.DeveloperCommission),
            TotalOrders = allEarnings.Count(),
            AverageCommissionPerOrder = allEarnings.Any() ? allEarnings.Average(e => e.DeveloperCommission) : 0
        };

        // Calculate next payout date based on frequency
        if (settings != null && settings.AutoPayoutEnabled)
        {
            summary.NextPayoutDate = settings.PayoutFrequency switch
            {
                Entity.PayoutFrequency.Daily => DateTime.UtcNow.Date.AddDays(1),
                Entity.PayoutFrequency.Weekly => weekStart.AddDays(7),
                Entity.PayoutFrequency.BiWeekly => weekStart.AddDays(14),
                Entity.PayoutFrequency.Monthly => monthStart.AddMonths(1),
                _ => null
            };
        }

        var recentEarnings = allEarnings
            .OrderByDescending(e => e.EarnedAt)
            .Take(10)
            .Select(e => new Kokomija.Models.ViewModels.DeveloperEarningDto
            {
                Id = e.Id,
                OrderId = e.OrderId,
                OrderNumber = $"ORD-{e.OrderId}",
                GrossAmount = e.GrossAmount,
                StripeProcessingFee = e.StripeProcessingFee,
                DeveloperCommission = e.DeveloperCommission,
                NetAmount = e.NetAmount,
                EarnedAt = e.EarnedAt,
                PayoutStatus = e.PayoutStatus.ToString(),
                PayoutId = e.PayoutId,
                PayoutDate = e.PayoutDate
            })
            .ToList();

        var viewModel = new Kokomija.Models.ViewModels.CommissionSettingsViewModel
        {
            Settings = settings == null ? null : new Kokomija.Models.ViewModels.CommissionSettingsDto
            {
                Id = settings.Id,
                DeveloperCommissionRate = settings.DeveloperCommissionRate,
                PlatformCommissionRate = settings.PlatformCommissionRate,
                StripeCommissionRate = settings.StripeCommissionRate,
                StripeFixedFee = settings.StripeFixedFee,
                MinimumPayoutAmount = settings.MinimumPayoutAmount,
                PayoutFrequency = settings.PayoutFrequency.ToString(),
                AutoPayoutEnabled = settings.AutoPayoutEnabled,
                LastModifiedAt = settings.LastModifiedAt,
                LastModifiedBy = settings.LastModifiedBy
            },
            EarningsSummary = summary,
            RecentEarnings = recentEarnings,
            ActiveSiteClosure = activeClosure == null ? null : new Kokomija.Models.ViewModels.SiteClosureDto
            {
                Id = activeClosure.Id,
                Reason = activeClosure.Reason ?? string.Empty,
                Message = string.Empty,
                IsActive = activeClosure.IsClosed,
                StartDate = activeClosure.ClosedAt,
                EndDate = activeClosure.ScheduledReopenAt,
                CreatedAt = activeClosure.ClosedAt ?? DateTime.UtcNow
            }
        };

        // Fetch Stripe Connect account info
        var connectedAccountId = _configuration["Stripe:ConnectedAccountId"];
        if (!string.IsNullOrEmpty(connectedAccountId))
        {
            try
            {
                var accountService = new Stripe.AccountService();
                var account = await accountService.GetAsync(connectedAccountId);
                
                viewModel.ConnectAccount = new Kokomija.Models.ViewModels.StripeConnectAccountDto
                {
                    AccountId = account.Id,
                    Email = account.Email,
                    BusinessName = account.BusinessProfile?.Name ?? account.Individual?.FirstName + " " + account.Individual?.LastName,
                    IsVerified = account.DetailsSubmitted,
                    PayoutsEnabled = account.PayoutsEnabled,
                    ChargesEnabled = account.ChargesEnabled,
                    Country = account.Country,
                    Currency = account.DefaultCurrency?.ToUpper(),
                    BusinessType = account.Type,
                    Status = account.PayoutsEnabled ? "Active" : (account.DetailsSubmitted ? "Pending Verification" : "Incomplete")
                };
            }
            catch (Stripe.StripeException ex)
            {
                viewModel.ConnectAccount = new Kokomija.Models.ViewModels.StripeConnectAccountDto
                {
                    AccountId = connectedAccountId,
                    Status = "Error",
                    ErrorMessage = ex.Message
                };
            }
        }

        return View(viewModel);
    }

    // POST: /Admin/UpdateCommissionSettings
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> UpdateCommissionSettings([FromBody] Kokomija.Models.ViewModels.UpdateCommissionSettingsDto dto)
    {
        try
        {
            // Validate commission rates
            if (dto.DeveloperCommissionRate < 0 || dto.DeveloperCommissionRate > 100)
            {
                return Json(new { success = false, message = "Developer commission rate must be between 0 and 100" });
            }

            if (dto.PlatformCommissionRate < 0 || dto.PlatformCommissionRate > 100)
            {
                return Json(new { success = false, message = "Platform commission rate must be between 0 and 100" });
            }

            // Get the current user's ID (not name)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var settings = (await _unitOfWork.CommissionSettings.GetAllAsync()).FirstOrDefault();

            if (settings == null)
            {
                // Create new settings
                settings = new Entity.CommissionSettings
                {
                    DeveloperCommissionRate = dto.DeveloperCommissionRate,
                    PlatformCommissionRate = dto.PlatformCommissionRate,
                    StripeCommissionRate = dto.StripeCommissionRate,
                    StripeFixedFee = dto.StripeFixedFee,
                    MinimumPayoutAmount = dto.MinimumPayoutAmount,
                    PayoutFrequency = Enum.Parse<Entity.PayoutFrequency>(dto.PayoutFrequency),
                    AutoPayoutEnabled = dto.AutoPayoutEnabled,
                    LastModifiedBy = userId!,
                    LastModifiedAt = DateTime.UtcNow
                };
                await _unitOfWork.CommissionSettings.AddAsync(settings);
            }
            else
            {
                // Update existing settings
                settings.DeveloperCommissionRate = dto.DeveloperCommissionRate;
                settings.PlatformCommissionRate = dto.PlatformCommissionRate;
                settings.StripeCommissionRate = dto.StripeCommissionRate;
                settings.StripeFixedFee = dto.StripeFixedFee;
                settings.MinimumPayoutAmount = dto.MinimumPayoutAmount;
                settings.PayoutFrequency = Enum.Parse<Entity.PayoutFrequency>(dto.PayoutFrequency);
                settings.AutoPayoutEnabled = dto.AutoPayoutEnabled;
                settings.LastModifiedBy = userId!;
                settings.LastModifiedAt = DateTime.UtcNow;
            }

            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation("Commission settings updated by {User}", User.Identity?.Name);

            return Json(new { success = true, message = "Commission settings updated successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating commission settings");
            return Json(new { success = false, message = "Error updating commission settings" });
        }
    }

    // POST: /Admin/ProcessDeveloperPayout
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> ProcessDeveloperPayout()
    {
        try
        {
            // Get pending amount first
            var pendingAmount = await _stripePayoutService.GetPendingPayoutAmountAsync();
            
            if (pendingAmount <= 0)
            {
                return Json(new { success = false, message = "No pending earnings to process." });
            }

            // Process the payout
            var (success, message) = await _stripePayoutService.ProcessPendingDeveloperEarningsAsync();

            if (success)
            {
                _logger.LogInformation("Manual developer payout processed by {User} for {Amount} PLN", 
                    User.Identity?.Name, pendingAmount);
                return Json(new { success = true, message = message, amount = $"{pendingAmount:N2} PLN" });
            }
            else
            {
                return Json(new { success = false, message = message });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing manual developer payout");
            return Json(new { success = false, message = "An error occurred while processing the payout." });
        }
    }

    // GET: /Admin/DeveloperEarnings
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> DeveloperEarnings(int page = 1, int pageSize = 50)
    {
        var today = DateTime.UtcNow.Date;
        var weekStart = today.AddDays(-(int)today.DayOfWeek);
        var monthStart = new DateTime(today.Year, today.Month, 1);
        var yearStart = new DateTime(today.Year, 1, 1);

        var allEarnings = await _unitOfWork.DeveloperEarnings.GetAllAsync();

        var summary = new Kokomija.Models.ViewModels.DeveloperEarningsSummaryDto
        {
            TodayEarnings = allEarnings.Where(e => e.EarnedAt.Date == today).Sum(e => e.DeveloperCommission),
            WeekEarnings = allEarnings.Where(e => e.EarnedAt.Date >= weekStart).Sum(e => e.DeveloperCommission),
            MonthEarnings = allEarnings.Where(e => e.EarnedAt >= monthStart).Sum(e => e.DeveloperCommission),
            YearEarnings = allEarnings.Where(e => e.EarnedAt >= yearStart).Sum(e => e.DeveloperCommission),
            AllTimeEarnings = allEarnings.Sum(e => e.DeveloperCommission),
            PendingPayout = allEarnings.Where(e => e.PayoutStatus == Entity.PayoutStatus.Pending).Sum(e => e.DeveloperCommission),
            TotalOrders = allEarnings.Count(),
            AverageCommissionPerOrder = allEarnings.Any() ? allEarnings.Average(e => e.DeveloperCommission) : 0
        };

        var pagedEarnings = allEarnings
            .OrderByDescending(e => e.EarnedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(e => new Kokomija.Models.ViewModels.DeveloperEarningDto
            {
                Id = e.Id,
                OrderId = e.OrderId,
                OrderNumber = $"ORD-{e.OrderId}",
                GrossAmount = e.GrossAmount,
                StripeProcessingFee = e.StripeProcessingFee,
                DeveloperCommission = e.DeveloperCommission,
                NetAmount = e.NetAmount,
                EarnedAt = e.EarnedAt,
                PayoutStatus = e.PayoutStatus.ToString(),
                PayoutId = e.PayoutId,
                PayoutDate = e.PayoutDate
            })
            .ToList();

        var viewModel = new Kokomija.Models.ViewModels.DeveloperEarningsViewModel
        {
            Summary = summary,
            Earnings = pagedEarnings,
            TotalRecords = allEarnings.Count(),
            PageNumber = page,
            PageSize = pageSize
        };

        return View(viewModel);
    }

    // POST: /Admin/BlockSite
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> BlockSite([FromBody] Kokomija.Models.ViewModels.CreateSiteClosureDto dto)
    {
        try
        {
            // Deactivate any existing active closures
            var activeClosures = await _unitOfWork.SiteClosures.FindAsync(sc => sc.IsClosed);
            foreach (var closure in activeClosures)
            {
                closure.IsClosed = false;
            }

            // Create new site closure
            var siteClosure = new Entity.SiteClosure
            {
                Reason = dto.Reason,
                IsClosed = true,
                ClosedBy = User.Identity?.Name ?? "System",
                ClosedAt = dto.StartDate ?? DateTime.UtcNow,
                ScheduledReopenAt = dto.EndDate
            };

            await _unitOfWork.SiteClosures.AddAsync(siteClosure);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogWarning("Site blocked by {User}. Reason: {Reason}", User.Identity?.Name, dto.Reason);

            return Json(new { success = true, message = "Site blocked successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error blocking site");
            return Json(new { success = false, message = "Error blocking site" });
        }
    }

    // POST: /Admin/UnblockSite
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> UnblockSite(int id)
    {
        try
        {
            var closure = await _unitOfWork.SiteClosures.GetByIdAsync(id);
            if (closure == null)
            {
                return Json(new { success = false, message = "Site closure not found" });
            }

            closure.IsClosed = false;
            closure.ScheduledReopenAt = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Site unblocked by {User}", User.Identity?.Name);

            return Json(new { success = true, message = "Site unblocked successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error unblocking site");
            return Json(new { success = false, message = "Error unblocking site" });
        }
    }

    #endregion

    #region Return Management

    // GET: /Admin/ReturnRequests
    public async Task<IActionResult> ReturnRequests()
    {
        var statistics = await _returnRequestService.GetReturnRequestsStatisticsAsync();
        return View(statistics);
    }

    // GET: /Admin/ReturnRequestDetails
    public async Task<IActionResult> ReturnRequestDetails(int id)
    {
        var returnRequest = await _returnRequestService.GetReturnRequestDetailsAsync(id);
        if (returnRequest == null)
        {
            return NotFound();
        }
        return View(returnRequest);
    }

    // POST: /Admin/ReviewReturnRequest
    [HttpPost]
    public async Task<IActionResult> ReviewReturnRequest([FromBody] Kokomija.Models.ViewModels.ReturnRequest.ReviewReturnRequestDto dto)
    {
        try
        {
            var reviewerId = User.Identity?.Name ?? "Admin";
            var result = await _returnRequestService.ReviewReturnRequestAsync(dto, reviewerId);

            return Json(new { success = result.Success, message = result.Message });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reviewing return request");
            return Json(new { success = false, message = "An error occurred while reviewing the return request" });
        }
    }

    #endregion

    #region Financial Dashboard

    /// <summary>
    /// GET: Financial Dashboard - Comprehensive earnings and deductions view
    /// </summary>
    public async Task<IActionResult> Financial(string period = "month", DateTime? dateFrom = null, DateTime? dateTo = null, int page = 1)
    {
        try
        {
            var viewModel = new FinancialDashboardViewModel
            {
                SelectedPeriod = period,
                DateFrom = dateFrom,
                DateTo = dateTo,
                CurrentPage = page
            };

            // Calculate date range based on period
            DateTime startDate, endDate = DateTime.UtcNow;
            switch (period.ToLower())
            {
                case "day":
                    startDate = DateTime.UtcNow.Date;
                    break;
                case "week":
                    startDate = DateTime.UtcNow.AddDays(-7);
                    break;
                case "month":
                    startDate = DateTime.UtcNow.AddMonths(-1);
                    break;
                case "year":
                    startDate = DateTime.UtcNow.AddYears(-1);
                    break;
                case "all":
                    startDate = DateTime.MinValue;
                    break;
                case "custom":
                    startDate = dateFrom ?? DateTime.UtcNow.AddMonths(-1);
                    endDate = dateTo ?? DateTime.UtcNow;
                    break;
                default:
                    startDate = DateTime.UtcNow.AddMonths(-1);
                    break;
            }

            if (period != "custom")
            {
                viewModel.DateFrom = startDate;
                viewModel.DateTo = endDate;
            }

            // Get all orders within the period
            var allOrders = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate && o.PaymentStatus == "paid");
            var orders = allOrders.ToList();

            // Get orders from previous period for comparison
            var previousPeriodStart = startDate.AddDays(-(endDate - startDate).TotalDays);
            var previousOrdersQuery = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.CreatedAt >= previousPeriodStart && o.CreatedAt < startDate && o.PaymentStatus == "paid");
            var previousOrders = previousOrdersQuery.ToList();

            // Get commission settings
            var commissionSettings = (await _unitOfWork.Repository<CommissionSettings>().GetAllAsync()).FirstOrDefault();
            viewModel.CommissionSettings = commissionSettings;

            // Calculate Summary
            var summary = new FinancialSummary
            {
                Currency = "PLN",
                TotalOrders = orders.Count,
                DeveloperCommissionRate = commissionSettings?.DeveloperCommissionRate ?? 0
            };

            // Gross Revenue
            summary.GrossRevenue = orders.Sum(o => o.TotalAmount);
            summary.GrossRevenueThisMonth = orders.Where(o => o.CreatedAt >= DateTime.UtcNow.AddMonths(-1)).Sum(o => o.TotalAmount);
            summary.GrossRevenueToday = orders.Where(o => o.CreatedAt.Date == DateTime.UtcNow.Date).Sum(o => o.TotalAmount);

            // Calculate growth
            var previousGross = previousOrders.Sum(o => o.TotalAmount);
            summary.GrossRevenueGrowth = previousGross > 0 ? ((summary.GrossRevenue - previousGross) / previousGross) * 100 : 0;

            // Deductions - Get from AdminCommission records
            var adminCommissions = await _unitOfWork.Repository<AdminCommission>()
                .FindAsync(ac => orders.Select(o => o.Id).Contains(ac.OrderId));
            var commissionsList = adminCommissions.ToList();

            summary.TotalStripeFees = commissionsList.Sum(c => c.TotalStripeFees);
            summary.TotalPlatformCommission = commissionsList.Sum(c => c.PlatformCommissionAmount);
            summary.TotalTaxAmount = orders.Sum(o => o.TaxAmount);
            summary.TotalDiscounts = orders.Sum(o => o.DiscountAmount);

            // Developer earnings
            var developerEarnings = await _unitOfWork.Repository<DeveloperEarnings>()
                .FindAsync(de => orders.Select(o => o.Id).Contains(de.OrderId));
            var devEarningsList = developerEarnings.ToList();
            
            summary.TotalDeveloperCommission = devEarningsList.Sum(de => de.DeveloperCommission);
            summary.TotalPaidToDeveloper = devEarningsList.Where(de => de.PayoutStatus == PayoutStatus.Processed).Sum(de => de.DeveloperCommission);
            summary.PendingDeveloperPayout = devEarningsList.Where(de => de.PayoutStatus == PayoutStatus.Pending).Sum(de => de.DeveloperCommission);

            // Refunds
            var refundedOrders = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate && o.PaymentStatus == "refunded");
            summary.TotalRefunds = refundedOrders.Sum(o => o.TotalAmount);

            // Shipping calculations
            summary.TotalShippingCollected = orders.Sum(o => o.ShippingCost);
            summary.OrdersWithShipping = orders.Count(o => o.ShippingCost > 0);
            summary.OrdersWithFreeShipping = orders.Count(o => o.ShippingCost == 0);
            
            // Get actual shipping costs from OrderShipment
            var orderIds = orders.Select(o => o.Id).ToList();
            var shipmentsQuery = await _unitOfWork.Repository<OrderShipment>()
                .FindAsync(s => orderIds.Contains(s.OrderId));
            var shipments = shipmentsQuery.ToList();
            summary.TotalShippingCost = shipments.Sum(s => s.ShippingCost);
            summary.ShippingProfit = summary.TotalShippingCollected - summary.TotalShippingCost;

            // Get order items for product stats
            var orderItemsQuery = await _unitOfWork.Repository<OrderItem>()
                .FindAsync(oi => orderIds.Contains(oi.OrderId));
            var orderItemsList = orderItemsQuery.ToList();
            summary.TotalProductsSold = orderItemsList.Sum(oi => oi.Quantity);
            summary.UniqueProductsSold = orderItemsList.Select(oi => oi.ProductName).Distinct().Count();

            // Net Revenue (Company perspective)
            summary.NetRevenue = summary.GrossRevenue - summary.TotalStripeFees - summary.TotalDeveloperCommission - summary.TotalRefunds;
            summary.NetRevenueThisMonth = orders.Where(o => o.CreatedAt >= DateTime.UtcNow.AddMonths(-1)).Sum(o => o.TotalAmount) 
                - commissionsList.Where(c => orders.Where(o => o.CreatedAt >= DateTime.UtcNow.AddMonths(-1)).Select(o => o.Id).Contains(c.OrderId)).Sum(c => c.TotalStripeFees);

            // Personal Earnings (Admin's actual take-home after platform commission)
            summary.PersonalEarnings = summary.NetRevenue; // For owner, net revenue is personal earnings
            summary.PersonalEarningsThisMonth = summary.NetRevenueThisMonth;
            summary.PersonalEarningsToday = orders.Where(o => o.CreatedAt.Date == DateTime.UtcNow.Date).Sum(o => o.TotalAmount)
                - commissionsList.Where(c => orders.Where(o => o.CreatedAt.Date == DateTime.UtcNow.Date).Select(o => o.Id).Contains(c.OrderId)).Sum(c => c.TotalStripeFees);

            // Statistics
            summary.AverageOrderValue = orders.Any() ? summary.GrossRevenue / orders.Count : 0;
            summary.EffectiveTaxRate = summary.GrossRevenue > 0 ? (summary.TotalTaxAmount / summary.GrossRevenue) * 100 : 0;

            viewModel.Summary = summary;

            // Chart Data - Group by day/week/month depending on period
            viewModel.RevenueChart = GenerateRevenueChartData(orders, period, startDate, endDate);

            // Deduction breakdown for pie chart
            var totalDeductions = summary.TotalStripeFees + summary.TotalDeveloperCommission + summary.TotalTaxAmount + summary.TotalRefunds + summary.TotalDiscounts;
            viewModel.DeductionChart = new List<DeductionBreakdown>
            {
                new() { Category = "Stripe Fees", Amount = summary.TotalStripeFees, Percentage = totalDeductions > 0 ? (summary.TotalStripeFees / totalDeductions) * 100 : 0, Color = "#635bff" },
                new() { Category = "Developer Commission", Amount = summary.TotalDeveloperCommission, Percentage = totalDeductions > 0 ? (summary.TotalDeveloperCommission / totalDeductions) * 100 : 0, Color = "#00d4aa" },
                new() { Category = "Tax", Amount = summary.TotalTaxAmount, Percentage = totalDeductions > 0 ? (summary.TotalTaxAmount / totalDeductions) * 100 : 0, Color = "#ff6b6b" },
                new() { Category = "Refunds", Amount = summary.TotalRefunds, Percentage = totalDeductions > 0 ? (summary.TotalRefunds / totalDeductions) * 100 : 0, Color = "#ffd43b" },
                new() { Category = "Discounts", Amount = summary.TotalDiscounts, Percentage = totalDeductions > 0 ? (summary.TotalDiscounts / totalDeductions) * 100 : 0, Color = "#845ef7" }
            };

            // Product Breakdowns
            viewModel.ProductBreakdowns = await GetProductFinancialBreakdowns(orders.Select(o => o.Id).ToList());

            // Transactions with pagination
            var skip = (page - 1) * viewModel.PageSize;
            viewModel.TotalTransactions = orders.Count;
            viewModel.Transactions = await GetFinancialTransactions(orders.OrderByDescending(o => o.CreatedAt).Skip(skip).Take(viewModel.PageSize).ToList());

            // Tax breakdown
            viewModel.TaxBreakdown = GetTaxBreakdown(orders);

            // Pending commission requests
            var pendingRequests = await _unitOfWork.Repository<DeveloperCommissionRequest>()
                .FindAsync(r => r.Status == CommissionRequestStatus.Pending);
            viewModel.PendingCommissionRequests = pendingRequests.Select(r => new DeveloperCommissionRequestDto
            {
                Id = r.Id,
                DeveloperName = r.Developer != null ? $"{r.Developer.FirstName} {r.Developer.LastName}" : "Unknown",
                DeveloperEmail = r.Developer?.Email ?? "",
                CurrentRate = r.CurrentRate,
                RequestedRate = r.RequestedRate,
                Reason = r.Reason,
                Status = r.Status,
                CreatedAt = r.CreatedAt
            }).ToList();

            return View(viewModel);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading financial dashboard");
            return View(new FinancialDashboardViewModel());
        }
    }

    /// <summary>
    /// Export financial data to Excel (.xlsx)
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> ExportFinancial(string period = "month", DateTime? dateFrom = null, DateTime? dateTo = null)
    {
        try
        {
            // Calculate date range
            DateTime startDate, endDate = DateTime.UtcNow;
            switch (period.ToLower())
            {
                case "day": startDate = DateTime.UtcNow.Date; break;
                case "week": startDate = DateTime.UtcNow.AddDays(-7); break;
                case "month": startDate = DateTime.UtcNow.AddMonths(-1); break;
                case "year": startDate = DateTime.UtcNow.AddYears(-1); break;
                case "all": startDate = DateTime.MinValue; break;
                case "custom":
                    startDate = dateFrom ?? DateTime.UtcNow.AddMonths(-1);
                    endDate = dateTo ?? DateTime.UtcNow;
                    break;
                default: startDate = DateTime.UtcNow.AddMonths(-1); break;
            }

            var allOrders = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.CreatedAt >= startDate && o.CreatedAt <= endDate && o.PaymentStatus == "paid");
            var orders = allOrders.ToList();

            // Generate Excel using ClosedXML
            var excelBytes = await GenerateFinancialExcelAsync(orders, startDate, endDate);
            
            var fileName = $"Financial_Report_{startDate:yyyyMMdd}_to_{endDate:yyyyMMdd}.xlsx";
            
            return File(excelBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error exporting financial data");
            return BadRequest("Error generating export");
        }
    }

    /// <summary>
    /// Handle commission rate change request from developer
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> RequestCommissionChange([FromBody] CommissionChangeRequestDto dto)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId!);
            
            if (user == null)
                return Json(new { success = false, message = "User not found" });

            // Get current settings
            var settings = (await _unitOfWork.Repository<CommissionSettings>().GetAllAsync()).FirstOrDefault();
            var currentRate = settings?.DeveloperCommissionRate ?? 0;

            // Create request
            var request = new DeveloperCommissionRequest
            {
                DeveloperId = userId!,
                CurrentRate = currentRate,
                RequestedRate = dto.RequestedRate,
                Reason = dto.Reason,
                Status = CommissionRequestStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _unitOfWork.Repository<DeveloperCommissionRequest>().AddAsync(request);
            await _unitOfWork.SaveChangesAsync();

            // Send email notification to admin
            await SendCommissionRequestNotification(request, user);

            return Json(new { success = true, message = "Commission change request submitted. Admin will review and respond via email." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error submitting commission change request");
            return Json(new { success = false, message = "Error submitting request" });
        }
    }

    /// <summary>
    /// Review commission change request (Admin only)
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> ReviewCommissionRequest([FromBody] ReviewCommissionRequestDto dto)
    {
        try
        {
            var request = await _unitOfWork.Repository<DeveloperCommissionRequest>().GetByIdAsync(dto.RequestId);
            if (request == null)
                return Json(new { success = false, message = "Request not found" });

            var adminId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            request.Status = dto.Approved ? CommissionRequestStatus.Approved : CommissionRequestStatus.Rejected;
            request.ReviewedById = adminId;
            request.AdminResponse = dto.Response;
            request.ReviewedAt = DateTime.UtcNow;
            request.UpdatedAt = DateTime.UtcNow;

            // If approved, update the commission settings
            if (dto.Approved)
            {
                var settings = (await _unitOfWork.Repository<CommissionSettings>().GetAllAsync()).FirstOrDefault();
                if (settings != null)
                {
                    settings.DeveloperCommissionRate = request.RequestedRate;
                    settings.LastModifiedBy = adminId!;
                    settings.LastModifiedAt = DateTime.UtcNow;
                    _unitOfWork.Repository<CommissionSettings>().Update(settings);
                }
            }

            _unitOfWork.Repository<DeveloperCommissionRequest>().Update(request);
            await _unitOfWork.SaveChangesAsync();

            // Send notification to developer
            await SendCommissionDecisionNotification(request);

            return Json(new { success = true, message = dto.Approved ? "Request approved and commission rate updated" : "Request rejected" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reviewing commission request");
            return Json(new { success = false, message = "Error processing request" });
        }
    }

    /// <summary>
    /// Get commission settings
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetCommissionSettings()
    {
        var settings = (await _unitOfWork.Repository<CommissionSettings>().GetAllAsync()).FirstOrDefault();
        return Json(new { 
            success = true, 
            settings = new {
                developerRate = settings?.DeveloperCommissionRate ?? 0,
                platformRate = settings?.PlatformCommissionRate ?? 0,
                stripeRate = settings?.StripeCommissionRate ?? 2.9m,
                stripeFixedFee = settings?.StripeFixedFee ?? 0.30m,
                autoPayoutEnabled = settings?.AutoPayoutEnabled ?? false,
                minimumPayout = settings?.MinimumPayoutAmount ?? 100
            }
        });
    }

    /// <summary>
    /// Get all tax rates
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetTaxRates()
    {
        var taxRates = await _unitOfWork.Repository<TaxRate>().GetAllAsync();
        return Json(new { 
            success = true, 
            taxRates = taxRates.Select(t => new {
                id = t.Id,
                name = t.Name,
                countryCode = t.CountryCode,
                stateCode = t.StateCode,
                rate = t.Rate,
                isActive = t.IsActive,
                isDefault = t.IsDefault,
                stripeTaxRateId = t.StripeTaxRateId
            }).OrderBy(t => t.countryCode).ThenBy(t => t.name)
        });
    }

    /// <summary>
    /// Update tax rate (Root only)
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> UpdateTaxRate([FromBody] UpdateTaxRateDto dto)
    {
        try
        {
            var taxRate = await _unitOfWork.Repository<TaxRate>().GetByIdAsync(dto.Id);
            if (taxRate == null)
                return Json(new { success = false, message = "Tax rate not found" });
            
            taxRate.Name = dto.Name;
            taxRate.Rate = dto.Rate;
            taxRate.IsActive = dto.IsActive;
            taxRate.IsDefault = dto.IsDefault;
            taxRate.UpdatedAt = DateTime.UtcNow;
            
            // If setting as default, unset others
            if (dto.IsDefault)
            {
                var allTaxRates = await _unitOfWork.Repository<TaxRate>().GetAllAsync();
                foreach (var tr in allTaxRates.Where(t => t.Id != dto.Id && t.IsDefault))
                {
                    tr.IsDefault = false;
                    _unitOfWork.Repository<TaxRate>().Update(tr);
                }
            }
            
            _unitOfWork.Repository<TaxRate>().Update(taxRate);
            await _unitOfWork.SaveChangesAsync();
            
            return Json(new { success = true, message = "Tax rate updated successfully" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating tax rate");
            return Json(new { success = false, message = "Error updating tax rate" });
        }
    }

    /// <summary>
    /// Create new tax rate (Root only)
    /// </summary>
    [HttpPost]
    [Authorize(Roles = "Root")]
    public async Task<IActionResult> CreateTaxRate([FromBody] CreateTaxRateDto dto)
    {
        try
        {
            var taxRate = new TaxRate
            {
                Name = dto.Name,
                CountryCode = dto.CountryCode,
                StateCode = dto.StateCode,
                Rate = dto.Rate,
                IsActive = dto.IsActive,
                IsDefault = dto.IsDefault,
                StripeTaxRateId = dto.StripeTaxRateId ?? "",
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            
            // If setting as default, unset others
            if (dto.IsDefault)
            {
                var allTaxRates = await _unitOfWork.Repository<TaxRate>().GetAllAsync();
                foreach (var tr in allTaxRates.Where(t => t.IsDefault))
                {
                    tr.IsDefault = false;
                    _unitOfWork.Repository<TaxRate>().Update(tr);
                }
            }
            
            await _unitOfWork.Repository<TaxRate>().AddAsync(taxRate);
            await _unitOfWork.SaveChangesAsync();
            
            return Json(new { success = true, message = "Tax rate created successfully", id = taxRate.Id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating tax rate");
            return Json(new { success = false, message = "Error creating tax rate" });
        }
    }

    // Helper methods for Financial Dashboard
    private List<RevenueChartData> GenerateRevenueChartData(List<Order> orders, string period, DateTime startDate, DateTime endDate)
    {
        var chartData = new List<RevenueChartData>();
        
        IEnumerable<IGrouping<string, Order>> grouped;
        
        if (period == "day" || (endDate - startDate).TotalDays <= 7)
        {
            // Group by hour
            grouped = orders.GroupBy(o => o.CreatedAt.ToString("HH:00"));
        }
        else if ((endDate - startDate).TotalDays <= 31)
        {
            // Group by day
            grouped = orders.GroupBy(o => o.CreatedAt.ToString("MMM dd"));
        }
        else if ((endDate - startDate).TotalDays <= 365)
        {
            // Group by week - use date range as label
            grouped = orders.GroupBy(o => o.CreatedAt.ToString("MMM dd"));
        }
        else
        {
            // Group by month
            grouped = orders.GroupBy(o => o.CreatedAt.ToString("MMM yyyy"));
        }

        foreach (var group in grouped.OrderBy(g => g.Min(o => o.CreatedAt)))
        {
            var grossRevenue = group.Sum(o => o.TotalAmount);
            // Calculate net: Gross - StripeFees(~2.9% + 1 PLN per transaction) - Tax - DevCommission(~10%)
            var stripeFees = group.Sum(o => (o.TotalAmount * 0.029m) + 1.00m);
            var taxAmount = group.Sum(o => o.TaxAmount);
            var devCommission = (grossRevenue - stripeFees - taxAmount) * 0.10m; // 10% dev commission on net
            var netRevenue = grossRevenue - stripeFees - devCommission;
            
            chartData.Add(new RevenueChartData
            {
                Label = group.Key,
                GrossRevenue = grossRevenue,
                NetRevenue = netRevenue,
                PersonalEarnings = netRevenue,
                OrderCount = group.Count()
            });
        }

        return chartData;
    }

    private async Task<List<ProductFinancialBreakdown>> GetProductFinancialBreakdowns(List<int> orderIds)
    {
        var breakdowns = new List<ProductFinancialBreakdown>();
        
        var orderItems = await _unitOfWork.Repository<OrderItem>()
            .FindAsync(oi => orderIds.Contains(oi.OrderId));

        // Group by ProductVariantId since OrderItem doesn't have ProductId directly
        var productGroups = orderItems.GroupBy(oi => oi.ProductVariantId);

        foreach (var group in productGroups.OrderByDescending(g => g.Sum(oi => oi.TotalPrice)))
        {
            var variant = await _unitOfWork.Repository<ProductVariant>().GetByIdAsync(group.Key, v => v.Product);
            if (variant?.Product == null) continue;

            var grossSales = group.Sum(oi => oi.TotalPrice);
            var quantity = group.Sum(oi => oi.Quantity);
            
            // Estimate fees (Stripe 2.9% + 1 PLN)
            var stripeFees = (grossSales * 0.029m) + (group.Count() * 1.00m);
            
            breakdowns.Add(new ProductFinancialBreakdown
            {
                ProductId = variant.Product.Id,
                ProductName = variant.Product.Name,
                ProductImage = variant.Product.Images.FirstOrDefault()?.ImageUrl,
                QuantitySold = quantity,
                GrossSales = grossSales,
                StripeFees = stripeFees,
                TaxAmount = 0, // Tax is on order level, not item level
                DeveloperCommission = 0, // Will be calculated from settings
                PlatformCommission = grossSales * 0.01m,
                NetRevenue = grossSales - stripeFees,
                ProfitMargin = grossSales > 0 ? ((grossSales - stripeFees) / grossSales) * 100 : 0,
                AveragePrice = quantity > 0 ? grossSales / quantity : 0
            });
        }

        return breakdowns.Take(20).ToList(); // Top 20 products
    }

    private async Task<List<FinancialTransaction>> GetFinancialTransactions(List<Order> orders)
    {
        var transactions = new List<FinancialTransaction>();

        foreach (var order in orders)
        {
            // Estimate Stripe fee (2.9% + fixed)
            var stripeFee = (order.TotalAmount * 0.029m) + 1.00m; // 1 PLN fixed fee for Poland

            var transaction = new FinancialTransaction
            {
                OrderId = order.Id,
                OrderNumber = order.OrderNumber,
                Date = order.CreatedAt,
                CustomerName = order.CustomerName ?? "Guest",
                CustomerEmail = order.CustomerEmail,
                GrossAmount = order.TotalAmount,
                SubtotalAmount = order.SubtotalAmount,
                ShippingAmount = order.ShippingCost,
                DiscountAmount = order.DiscountAmount,
                TaxAmount = order.TaxAmount,
                StripeFee = stripeFee,
                DeveloperCommission = 0, // From DeveloperEarnings
                PlatformCommission = order.CommissionAmount,
                NetAmount = order.TotalAmount - stripeFee - order.CommissionAmount,
                PaymentStatus = order.PaymentStatus,
                OrderStatus = order.OrderStatus,
                Currency = "PLN"
            };

            // Get order items
            var items = await _unitOfWork.Repository<OrderItem>().FindAsync(oi => oi.OrderId == order.Id);
            transaction.Items = items.Select(i => new TransactionItem
            {
                ProductId = i.ProductVariantId, // Use variant ID as product reference
                ProductName = i.ProductName,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                Total = i.TotalPrice,
                Tax = 0 // Tax is at order level
            }).ToList();

            transactions.Add(transaction);
        }

        return transactions;
    }

    private List<TaxSummary> GetTaxBreakdown(List<Order> orders)
    {
        return orders
            .Where(o => o.TaxRate > 0)
            .GroupBy(o => new { o.TaxRate, Country = o.ShippingCountry ?? "Unknown" })
            .Select(g => new TaxSummary
            {
                TaxName = $"VAT {g.Key.TaxRate * 100:F0}%",
                Rate = g.Key.TaxRate * 100,
                Country = g.Key.Country,
                TaxableAmount = g.Sum(o => o.SubtotalAmount),
                TaxCollected = g.Sum(o => o.TaxAmount),
                TransactionCount = g.Count()
            })
            .ToList();
    }

    private async Task<string> GenerateFinancialCsvAsync(List<Order> orders, DateTime startDate, DateTime endDate)
    {
        var sb = new System.Text.StringBuilder();
        
        // Get commission and earnings data
        var orderIds = orders.Select(o => o.Id).ToList();
        var adminCommissions = (await _unitOfWork.Repository<AdminCommission>()
            .FindAsync(ac => orderIds.Contains(ac.OrderId))).ToDictionary(ac => ac.OrderId);
        var developerEarnings = (await _unitOfWork.Repository<DeveloperEarnings>()
            .FindAsync(de => orderIds.Contains(de.OrderId))).ToDictionary(de => de.OrderId);
        var commissionSettings = (await _unitOfWork.Repository<CommissionSettings>().GetAllAsync()).FirstOrDefault();

        // Calculate totals
        var grossRevenue = orders.Sum(o => o.TotalAmount);
        var totalTax = orders.Sum(o => o.TaxAmount);
        var totalDiscounts = orders.Sum(o => o.DiscountAmount);
        var totalStripeFees = adminCommissions.Values.Sum(c => c.TotalStripeFees);
        var totalDevCommission = developerEarnings.Values.Sum(d => d.DeveloperCommission);
        var netRevenue = grossRevenue - totalStripeFees - totalDevCommission;
        
        // Header
        sb.AppendLine("KOKOMIJA FINANCIAL REPORT");
        sb.AppendLine($"Period: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
        sb.AppendLine($"Generated: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC");
        sb.AppendLine();
        
        // Summary Section
        sb.AppendLine("=== SUMMARY ===");
        sb.AppendLine($"Total Orders,{orders.Count}");
        sb.AppendLine($"Gross Revenue,{grossRevenue:F2} PLN");
        sb.AppendLine($"Total Tax Collected,{totalTax:F2} PLN");
        sb.AppendLine($"Total Discounts Given,{totalDiscounts:F2} PLN");
        sb.AppendLine($"Total Stripe Fees,{totalStripeFees:F2} PLN");
        sb.AppendLine($"Developer Commission ({commissionSettings?.DeveloperCommissionRate ?? 0}%),{totalDevCommission:F2} PLN");
        sb.AppendLine($"Net Revenue (Your Earnings),{netRevenue:F2} PLN");
        sb.AppendLine();
        
        // Deductions Breakdown
        sb.AppendLine("=== DEDUCTIONS BREAKDOWN ===");
        sb.AppendLine("Category,Amount (PLN),Percentage");
        var totalDeductions = totalStripeFees + totalDevCommission + totalTax;
        if (totalDeductions > 0)
        {
            sb.AppendLine($"Stripe Fees,{totalStripeFees:F2},{(totalStripeFees / totalDeductions * 100):F1}%");
            sb.AppendLine($"Developer Commission,{totalDevCommission:F2},{(totalDevCommission / totalDeductions * 100):F1}%");
            sb.AppendLine($"Tax,{totalTax:F2},{(totalTax / totalDeductions * 100):F1}%");
        }
        sb.AppendLine();
        
        // Transactions Detail
        sb.AppendLine("=== TRANSACTION DETAILS ===");
        sb.AppendLine("Order Number,Type,Date,Customer,Email,Subtotal,Shipping,Discount,Tax,Gross Total,Stripe Fee,Dev Commission,Net Amount,Payment Status,Order Status");
        
        foreach (var order in orders.OrderByDescending(o => o.CreatedAt))
        {
            var isDemo = order.OrderNumber.StartsWith("DEMO-") ? "[DEMO] " : "";
            var stripeFee = adminCommissions.TryGetValue(order.Id, out var ac) ? ac.TotalStripeFees : (order.TotalAmount * 0.029m + 1m);
            var devComm = developerEarnings.TryGetValue(order.Id, out var de) ? de.DeveloperCommission : 0m;
            var netAmount = order.TotalAmount - stripeFee - devComm;
            
            sb.AppendLine($"{order.OrderNumber},{isDemo.Trim()},{order.CreatedAt:yyyy-MM-dd HH:mm},{order.CustomerName?.Replace(",", " ")},{order.CustomerEmail},{order.SubtotalAmount:F2},{order.ShippingCost:F2},{order.DiscountAmount:F2},{order.TaxAmount:F2},{order.TotalAmount:F2},{stripeFee:F2},{devComm:F2},{netAmount:F2},{order.PaymentStatus},{order.OrderStatus}");
        }
        sb.AppendLine();
        
        // Developer Earnings Summary
        sb.AppendLine("=== DEVELOPER EARNINGS ===");
        sb.AppendLine("Status,Amount (PLN)");
        var paidDev = developerEarnings.Values.Where(d => d.PayoutStatus == PayoutStatus.Processed).Sum(d => d.DeveloperCommission);
        var pendingDev = developerEarnings.Values.Where(d => d.PayoutStatus == PayoutStatus.Pending).Sum(d => d.DeveloperCommission);
        sb.AppendLine($"Paid,{paidDev:F2}");
        sb.AppendLine($"Pending,{pendingDev:F2}");
        sb.AppendLine($"Total,{totalDevCommission:F2}");
        sb.AppendLine();
        
        // Tax Summary
        sb.AppendLine("=== TAX SUMMARY ===");
        var taxByRate = orders.GroupBy(o => o.TaxRate)
            .Select(g => new { Rate = g.Key * 100, Amount = g.Sum(o => o.TaxAmount), Count = g.Count() })
            .OrderByDescending(t => t.Amount);
        sb.AppendLine("Tax Rate,Tax Collected,Order Count");
        foreach (var tax in taxByRate)
        {
            sb.AppendLine($"{tax.Rate:F0}%,{tax.Amount:F2} PLN,{tax.Count}");
        }

        return sb.ToString();
    }

    private string GenerateFinancialCsv(List<Order> orders, DateTime startDate, DateTime endDate)
    {
        // Sync wrapper for backward compatibility
        return GenerateFinancialCsvAsync(orders, startDate, endDate).GetAwaiter().GetResult();
    }

    /// <summary>
    /// Generate Excel file using ClosedXML
    /// </summary>
    private async Task<byte[]> GenerateFinancialExcelAsync(List<Order> orders, DateTime startDate, DateTime endDate)
    {
        using var workbook = new XLWorkbook();
        
        // Get commission and earnings data
        var orderIds = orders.Select(o => o.Id).ToList();
        var adminCommissions = (await _unitOfWork.Repository<AdminCommission>()
            .FindAsync(ac => orderIds.Contains(ac.OrderId))).ToDictionary(ac => ac.OrderId);
        var developerEarnings = (await _unitOfWork.Repository<DeveloperEarnings>()
            .FindAsync(de => orderIds.Contains(de.OrderId))).ToDictionary(de => de.OrderId);
        var commissionSettings = (await _unitOfWork.Repository<CommissionSettings>().GetAllAsync()).FirstOrDefault();
        
        // Get shipping data for this period
        var shipments = (await _unitOfWork.Repository<OrderShipment>()
            .FindAsync(s => orderIds.Contains(s.OrderId))).ToList();
        var shippingProviders = (await _unitOfWork.Repository<ShippingProvider>().GetAllAsync()).ToDictionary(p => p.Id);
        var shippingRates = (await _unitOfWork.Repository<ShippingRate>().GetAllAsync()).ToDictionary(r => r.Id);

        // Calculate totals
        var grossRevenue = orders.Sum(o => o.TotalAmount);
        var totalTax = orders.Sum(o => o.TaxAmount);
        var totalDiscounts = orders.Sum(o => o.DiscountAmount);
        var totalShippingCollected = orders.Sum(o => o.ShippingCost);
        var totalShippingCost = shipments.Sum(s => s.ShippingCost); // Actual cost to you
        var totalStripeFees = adminCommissions.Values.Sum(c => c.TotalStripeFees);
        var totalDevCommission = developerEarnings.Values.Sum(d => d.DeveloperCommission);
        var shippingProfit = totalShippingCollected - totalShippingCost;
        var netRevenue = grossRevenue - totalStripeFees - totalDevCommission;

        // === SUMMARY SHEET ===
        var summarySheet = workbook.Worksheets.Add("Summary");
        
        // Title
        summarySheet.Cell("A1").Value = "KOKOMIJA FINANCIAL REPORT";
        summarySheet.Cell("A1").Style.Font.Bold = true;
        summarySheet.Cell("A1").Style.Font.FontSize = 16;
        summarySheet.Range("A1:D1").Merge();
        
        summarySheet.Cell("A2").Value = $"Period: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}";
        summarySheet.Cell("A3").Value = $"Generated: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC";
        
        // Get order items for product count
        var orderItemsQuery = await _unitOfWork.Repository<OrderItem>()
            .FindAsync(oi => orderIds.Contains(oi.OrderId));
        var orderItems = orderItemsQuery.ToList();
        var uniqueProductsCount = orderItems.Select(oi => oi.ProductName).Distinct().Count();
        var totalItemsSold = orderItems.Sum(oi => oi.Quantity);
        
        // Summary data
        var row = 5;
        summarySheet.Cell(row, 1).Value = "Metric";
        summarySheet.Cell(row, 2).Value = "Value";
        summarySheet.Range(row, 1, row, 2).Style.Font.Bold = true;
        summarySheet.Range(row, 1, row, 2).Style.Fill.BackgroundColor = XLColor.LightBlue;
        
        row++;
        summarySheet.Cell(row, 1).Value = "Total Orders";
        summarySheet.Cell(row, 2).Value = orders.Count;
        
        row++;
        summarySheet.Cell(row, 1).Value = "Unique Products Sold";
        summarySheet.Cell(row, 2).Value = uniqueProductsCount;
        
        row++;
        summarySheet.Cell(row, 1).Value = "Total Items Sold";
        summarySheet.Cell(row, 2).Value = totalItemsSold;
        
        row++;
        summarySheet.Cell(row, 1).Value = "Gross Revenue (incl. Shipping)";
        summarySheet.Cell(row, 2).Value = grossRevenue;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        
        row++;
        summarySheet.Cell(row, 1).Value = "Product Subtotal";
        summarySheet.Cell(row, 2).Value = orders.Sum(o => o.SubtotalAmount);
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        
        row++;
        summarySheet.Cell(row, 1).Value = "Shipping Revenue Collected";
        summarySheet.Cell(row, 2).Value = totalShippingCollected;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        
        row++;
        summarySheet.Cell(row, 1).Value = "Actual Shipping Cost (Your Cost)";
        summarySheet.Cell(row, 2).Value = totalShippingCost;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        summarySheet.Cell(row, 2).Style.Font.FontColor = XLColor.Red;
        
        row++;
        summarySheet.Cell(row, 1).Value = "Shipping Profit/Loss";
        summarySheet.Cell(row, 2).Value = shippingProfit;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        summarySheet.Cell(row, 2).Style.Font.FontColor = shippingProfit >= 0 ? XLColor.Green : XLColor.Red;
        
        row++;
        summarySheet.Cell(row, 1).Value = "Total Tax Collected (VAT)";
        summarySheet.Cell(row, 2).Value = totalTax;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        
        row++;
        summarySheet.Cell(row, 1).Value = "Total Discounts Given";
        summarySheet.Cell(row, 2).Value = totalDiscounts;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        summarySheet.Cell(row, 2).Style.Font.FontColor = XLColor.Red;
        
        row++;
        summarySheet.Cell(row, 1).Value = "Total Stripe Fees";
        summarySheet.Cell(row, 2).Value = totalStripeFees;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        summarySheet.Cell(row, 2).Style.Font.FontColor = XLColor.Red;
        
        row++;
        summarySheet.Cell(row, 1).Value = $"Developer Commission ({commissionSettings?.DeveloperCommissionRate ?? 0}%)";
        summarySheet.Cell(row, 2).Value = totalDevCommission;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        summarySheet.Cell(row, 2).Style.Font.FontColor = XLColor.Red;
        
        row++;
        summarySheet.Range(row, 1, row, 2).Style.Fill.BackgroundColor = XLColor.LightGreen;
        summarySheet.Cell(row, 1).Value = "NET REVENUE (Your Earnings)";
        summarySheet.Cell(row, 1).Style.Font.Bold = true;
        summarySheet.Cell(row, 2).Value = netRevenue;
        summarySheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        summarySheet.Cell(row, 2).Style.Font.Bold = true;
        summarySheet.Cell(row, 2).Style.Font.FontColor = XLColor.DarkGreen;
        
        // Order status breakdown
        row += 2;
        summarySheet.Cell(row, 1).Value = "Order Status Breakdown";
        summarySheet.Cell(row, 1).Style.Font.Bold = true;
        summarySheet.Range(row, 1, row, 2).Style.Fill.BackgroundColor = XLColor.LightYellow;
        
        var statusGroups = orders.GroupBy(o => o.OrderStatus)
            .Select(g => new { Status = g.Key, Count = g.Count(), Revenue = g.Sum(o => o.TotalAmount) })
            .OrderByDescending(s => s.Count);
        
        foreach (var status in statusGroups)
        {
            row++;
            summarySheet.Cell(row, 1).Value = $"  {status.Status.ToUpper()}";
            summarySheet.Cell(row, 2).Value = $"{status.Count} orders ({status.Revenue:N2} PLN)";
        }
        
        // Payment status breakdown
        row += 2;
        summarySheet.Cell(row, 1).Value = "Payment Status Breakdown";
        summarySheet.Cell(row, 1).Style.Font.Bold = true;
        summarySheet.Range(row, 1, row, 2).Style.Fill.BackgroundColor = XLColor.LightYellow;
        
        var paymentGroups = orders.GroupBy(o => o.PaymentStatus)
            .Select(g => new { Status = g.Key, Count = g.Count(), Revenue = g.Sum(o => o.TotalAmount) })
            .OrderByDescending(s => s.Count);
        
        foreach (var status in paymentGroups)
        {
            row++;
            summarySheet.Cell(row, 1).Value = $"  {status.Status.ToUpper()}";
            summarySheet.Cell(row, 2).Value = $"{status.Count} orders ({status.Revenue:N2} PLN)";
        }
        
        summarySheet.Columns().AdjustToContents();

        // === TRANSACTIONS SHEET ===
        var transSheet = workbook.Worksheets.Add("Transactions");
        
        // Headers
        var headers = new[] { "Order Number", "Type", "Date", "Customer", "Email", "Subtotal", "Shipping", "Discount", "Tax", "Gross Total", "Stripe Fee", "Dev Commission", "Net Amount", "Payment Status", "Order Status" };
        for (int i = 0; i < headers.Length; i++)
        {
            transSheet.Cell(1, i + 1).Value = headers[i];
        }
        transSheet.Range(1, 1, 1, headers.Length).Style.Font.Bold = true;
        transSheet.Range(1, 1, 1, headers.Length).Style.Fill.BackgroundColor = XLColor.LightBlue;
        
        // Data rows
        row = 2;
        foreach (var order in orders.OrderByDescending(o => o.CreatedAt))
        {
            var isDemo = order.OrderNumber.StartsWith("DEMO-") ? "[DEMO]" : "";
            var stripeFee = adminCommissions.TryGetValue(order.Id, out var ac) ? ac.TotalStripeFees : (order.TotalAmount * 0.029m + 1m);
            var devComm = developerEarnings.TryGetValue(order.Id, out var de) ? de.DeveloperCommission : 0m;
            var netAmount = order.TotalAmount - stripeFee - devComm;
            
            transSheet.Cell(row, 1).Value = order.OrderNumber;
            transSheet.Cell(row, 2).Value = isDemo;
            transSheet.Cell(row, 3).Value = order.CreatedAt;
            transSheet.Cell(row, 3).Style.NumberFormat.Format = "yyyy-MM-dd HH:mm";
            transSheet.Cell(row, 4).Value = order.CustomerName;
            transSheet.Cell(row, 5).Value = order.CustomerEmail;
            transSheet.Cell(row, 6).Value = order.SubtotalAmount;
            transSheet.Cell(row, 7).Value = order.ShippingCost;
            transSheet.Cell(row, 8).Value = order.DiscountAmount;
            transSheet.Cell(row, 9).Value = order.TaxAmount;
            transSheet.Cell(row, 10).Value = order.TotalAmount;
            transSheet.Cell(row, 11).Value = stripeFee;
            transSheet.Cell(row, 12).Value = devComm;
            transSheet.Cell(row, 13).Value = netAmount;
            transSheet.Cell(row, 14).Value = order.PaymentStatus;
            transSheet.Cell(row, 15).Value = order.OrderStatus;
            
            // Format currency columns
            for (int col = 6; col <= 13; col++)
            {
                transSheet.Cell(row, col).Style.NumberFormat.Format = "#,##0.00";
            }
            
            // Color net amount
            transSheet.Cell(row, 13).Style.Font.FontColor = netAmount >= 0 ? XLColor.Green : XLColor.Red;
            
            row++;
        }
        
        // Create table
        if (orders.Any())
        {
            var tableRange = transSheet.Range(1, 1, row - 1, headers.Length);
            tableRange.CreateTable("TransactionsTable");
        }
        
        transSheet.Columns().AdjustToContents();

        // === DEVELOPER EARNINGS SHEET ===
        var devSheet = workbook.Worksheets.Add("Developer Earnings");
        
        devSheet.Cell("A1").Value = "Developer Earnings Summary";
        devSheet.Cell("A1").Style.Font.Bold = true;
        devSheet.Cell("A1").Style.Font.FontSize = 14;
        
        var paidDev = developerEarnings.Values.Where(d => d.PayoutStatus == PayoutStatus.Processed).Sum(d => d.DeveloperCommission);
        var pendingDev = developerEarnings.Values.Where(d => d.PayoutStatus == PayoutStatus.Pending).Sum(d => d.DeveloperCommission);
        
        devSheet.Cell("A3").Value = "Status";
        devSheet.Cell("B3").Value = "Amount (PLN)";
        devSheet.Range("A3:B3").Style.Font.Bold = true;
        devSheet.Range("A3:B3").Style.Fill.BackgroundColor = XLColor.LightGreen;
        
        devSheet.Cell("A4").Value = "Paid";
        devSheet.Cell("B4").Value = paidDev;
        devSheet.Cell("B4").Style.NumberFormat.Format = "#,##0.00";
        
        devSheet.Cell("A5").Value = "Pending";
        devSheet.Cell("B5").Value = pendingDev;
        devSheet.Cell("B5").Style.NumberFormat.Format = "#,##0.00";
        
        devSheet.Cell("A6").Value = "Total";
        devSheet.Cell("B6").Value = totalDevCommission;
        devSheet.Cell("B6").Style.NumberFormat.Format = "#,##0.00";
        devSheet.Cell("B6").Style.Font.Bold = true;
        
        devSheet.Columns().AdjustToContents();

        // === TAX SUMMARY SHEET ===
        var taxSheet = workbook.Worksheets.Add("Tax Summary");
        
        taxSheet.Cell("A1").Value = "Tax Summary";
        taxSheet.Cell("A1").Style.Font.Bold = true;
        taxSheet.Cell("A1").Style.Font.FontSize = 14;
        
        taxSheet.Cell("A3").Value = "Tax Rate";
        taxSheet.Cell("B3").Value = "Tax Collected";
        taxSheet.Cell("C3").Value = "Order Count";
        taxSheet.Range("A3:C3").Style.Font.Bold = true;
        taxSheet.Range("A3:C3").Style.Fill.BackgroundColor = XLColor.LightYellow;
        
        var taxByRate = orders.GroupBy(o => o.TaxRate)
            .Select(g => new { Rate = g.Key * 100, Amount = g.Sum(o => o.TaxAmount), Count = g.Count() })
            .OrderByDescending(t => t.Amount)
            .ToList();
        
        row = 4;
        foreach (var tax in taxByRate)
        {
            taxSheet.Cell(row, 1).Value = $"{tax.Rate:F0}%";
            taxSheet.Cell(row, 2).Value = tax.Amount;
            taxSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
            taxSheet.Cell(row, 3).Value = tax.Count;
            row++;
        }
        
        taxSheet.Columns().AdjustToContents();

        // === DAILY BREAKDOWN SHEET ===
        var dailySheet = workbook.Worksheets.Add("Daily Breakdown");
        
        dailySheet.Cell("A1").Value = "Daily Revenue Breakdown";
        dailySheet.Cell("A1").Style.Font.Bold = true;
        dailySheet.Cell("A1").Style.Font.FontSize = 14;
        
        dailySheet.Cell("A3").Value = "Date";
        dailySheet.Cell("B3").Value = "Orders";
        dailySheet.Cell("C3").Value = "Gross Revenue";
        dailySheet.Cell("D3").Value = "Fees";
        dailySheet.Cell("E3").Value = "Net Revenue";
        dailySheet.Cell("F3").Value = "Avg Order Value";
        dailySheet.Range("A3:F3").Style.Font.Bold = true;
        dailySheet.Range("A3:F3").Style.Fill.BackgroundColor = XLColor.LightCoral;
        
        var dailyData = orders.GroupBy(o => o.CreatedAt.Date)
            .Select(g => new {
                Date = g.Key,
                OrderCount = g.Count(),
                GrossRevenue = g.Sum(o => o.TotalAmount),
                Fees = g.Sum(o => adminCommissions.TryGetValue(o.Id, out var ac) ? ac.TotalStripeFees : (o.TotalAmount * 0.029m + 1m)) +
                       g.Sum(o => developerEarnings.TryGetValue(o.Id, out var de) ? de.DeveloperCommission : 0m),
                AvgOrderValue = g.Average(o => o.TotalAmount)
            })
            .OrderByDescending(d => d.Date)
            .ToList();
        
        row = 4;
        foreach (var day in dailyData)
        {
            dailySheet.Cell(row, 1).Value = day.Date;
            dailySheet.Cell(row, 1).Style.NumberFormat.Format = "yyyy-MM-dd";
            dailySheet.Cell(row, 2).Value = day.OrderCount;
            dailySheet.Cell(row, 3).Value = day.GrossRevenue;
            dailySheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";
            dailySheet.Cell(row, 4).Value = day.Fees;
            dailySheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";
            dailySheet.Cell(row, 5).Value = day.GrossRevenue - day.Fees;
            dailySheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";
            dailySheet.Cell(row, 5).Style.Font.FontColor = XLColor.Green;
            dailySheet.Cell(row, 6).Value = day.AvgOrderValue;
            dailySheet.Cell(row, 6).Style.NumberFormat.Format = "#,##0.00";
            row++;
        }
        
        // Add totals row
        if (dailyData.Any())
        {
            dailySheet.Cell(row, 1).Value = "TOTAL";
            dailySheet.Cell(row, 1).Style.Font.Bold = true;
            dailySheet.Cell(row, 2).Value = dailyData.Sum(d => d.OrderCount);
            dailySheet.Cell(row, 2).Style.Font.Bold = true;
            dailySheet.Cell(row, 3).Value = dailyData.Sum(d => d.GrossRevenue);
            dailySheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";
            dailySheet.Cell(row, 3).Style.Font.Bold = true;
            dailySheet.Cell(row, 4).Value = dailyData.Sum(d => d.Fees);
            dailySheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";
            dailySheet.Cell(row, 4).Style.Font.Bold = true;
            dailySheet.Cell(row, 5).Value = dailyData.Sum(d => d.GrossRevenue - d.Fees);
            dailySheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";
            dailySheet.Cell(row, 5).Style.Font.Bold = true;
            dailySheet.Cell(row, 5).Style.Font.FontColor = XLColor.Green;
            dailySheet.Range(row, 1, row, 6).Style.Fill.BackgroundColor = XLColor.LightGray;
        }
        
        dailySheet.Columns().AdjustToContents();

        // === PRODUCTS PERFORMANCE SHEET ===
        var productsSheet = workbook.Worksheets.Add("Products Performance");
        
        productsSheet.Cell("A1").Value = $"Products Sold in Period ({startDate:MMM dd} - {endDate:MMM dd, yyyy})";
        productsSheet.Cell("A1").Style.Font.Bold = true;
        productsSheet.Cell("A1").Style.Font.FontSize = 14;
        
        productsSheet.Cell("A2").Value = $"Only showing products that were sold during this period";
        productsSheet.Cell("A2").Style.Font.Italic = true;
        productsSheet.Cell("A2").Style.Font.FontColor = XLColor.Gray;
        
        productsSheet.Cell("A4").Value = "Product Name";
        productsSheet.Cell("B4").Value = "Size";
        productsSheet.Cell("C4").Value = "Color";
        productsSheet.Cell("D4").Value = "Units Sold";
        productsSheet.Cell("E4").Value = "Gross Revenue";
        productsSheet.Cell("F4").Value = "Avg Unit Price";
        productsSheet.Cell("G4").Value = "% of Total Revenue";
        productsSheet.Range("A4:G4").Style.Font.Bold = true;
        productsSheet.Range("A4:G4").Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
        
        // orderItems already loaded in Summary section
        var totalProductRevenue = orderItems.Sum(oi => oi.TotalPrice);
        
        var productPerformance = orderItems
            .GroupBy(oi => new { oi.ProductName, Size = oi.Size ?? "-", Color = oi.Color ?? "-" })
            .Select(g => new {
                ProductName = g.Key.ProductName,
                Size = g.Key.Size,
                Color = g.Key.Color,
                UnitsSold = g.Sum(oi => oi.Quantity),
                GrossRevenue = g.Sum(oi => oi.TotalPrice),
                AvgPrice = g.Average(oi => oi.UnitPrice),
                RevenuePercent = totalProductRevenue > 0 ? (g.Sum(oi => oi.TotalPrice) / totalProductRevenue) : 0
            })
            .OrderByDescending(p => p.GrossRevenue)
            .ToList();
        
        row = 5;
        foreach (var product in productPerformance)
        {
            productsSheet.Cell(row, 1).Value = product.ProductName;
            productsSheet.Cell(row, 2).Value = product.Size;
            productsSheet.Cell(row, 3).Value = product.Color;
            productsSheet.Cell(row, 4).Value = product.UnitsSold;
            productsSheet.Cell(row, 5).Value = product.GrossRevenue;
            productsSheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";
            productsSheet.Cell(row, 6).Value = product.AvgPrice;
            productsSheet.Cell(row, 6).Style.NumberFormat.Format = "#,##0.00";
            productsSheet.Cell(row, 7).Value = product.RevenuePercent;
            productsSheet.Cell(row, 7).Style.NumberFormat.Format = "0.0%";
            row++;
        }
        
        // Add totals
        if (productPerformance.Any())
        {
            productsSheet.Cell(row, 1).Value = "TOTAL";
            productsSheet.Cell(row, 1).Style.Font.Bold = true;
            productsSheet.Cell(row, 4).Value = productPerformance.Sum(p => p.UnitsSold);
            productsSheet.Cell(row, 4).Style.Font.Bold = true;
            productsSheet.Cell(row, 5).Value = productPerformance.Sum(p => p.GrossRevenue);
            productsSheet.Cell(row, 5).Style.NumberFormat.Format = "#,##0.00";
            productsSheet.Cell(row, 5).Style.Font.Bold = true;
            productsSheet.Cell(row, 7).Value = 1;
            productsSheet.Cell(row, 7).Style.NumberFormat.Format = "0%";
            productsSheet.Cell(row, 7).Style.Font.Bold = true;
            productsSheet.Range(row, 1, row, 7).Style.Fill.BackgroundColor = XLColor.LightGray;
        }
        
        // Add unique products count summary
        row += 2;
        productsSheet.Cell(row, 1).Value = "Summary:";
        productsSheet.Cell(row, 1).Style.Font.Bold = true;
        row++;
        productsSheet.Cell(row, 1).Value = $"Unique Products Sold: {productPerformance.Select(p => p.ProductName).Distinct().Count()}";
        row++;
        productsSheet.Cell(row, 1).Value = $"Total Product Variants: {productPerformance.Count}";
        row++;
        productsSheet.Cell(row, 1).Value = $"Total Units Sold: {productPerformance.Sum(p => p.UnitsSold)}";
        
        productsSheet.Columns().AdjustToContents();

        // === ORDERS DETAIL SHEET ===
        var ordersSheet = workbook.Worksheets.Add("Orders Detail");
        
        ordersSheet.Cell("A1").Value = "Complete Orders Report";
        ordersSheet.Cell("A1").Style.Font.Bold = true;
        ordersSheet.Cell("A1").Style.Font.FontSize = 14;
        
        // Order headers
        var orderHeaders = new[] { 
            "Order #", "Date", "Customer", "Email", "Phone", "Shipping Address", 
            "Product", "Size", "Color", "Qty", "Unit Price", "Line Total",
            "Subtotal", "Shipping", "Discount", "Tax", "Grand Total", "Payment Status", "Order Status", "Currency"
        };
        for (int i = 0; i < orderHeaders.Length; i++)
        {
            ordersSheet.Cell(3, i + 1).Value = orderHeaders[i];
        }
        ordersSheet.Range(3, 1, 3, orderHeaders.Length).Style.Font.Bold = true;
        ordersSheet.Range(3, 1, 3, orderHeaders.Length).Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
        
        row = 4;
        foreach (var order in orders.OrderByDescending(o => o.CreatedAt))
        {
            // Get order items
            var items = orderItems.Where(oi => oi.OrderId == order.Id).ToList();
            
            var shippingAddress = $"{order.ShippingAddress}, {order.ShippingCity}, {order.ShippingPostalCode}, {order.ShippingCountry}";
            var isFirstItem = true;
            
            if (items.Any())
            {
                foreach (var item in items)
                {
                    ordersSheet.Cell(row, 1).Value = order.OrderNumber;
                    ordersSheet.Cell(row, 2).Value = order.CreatedAt;
                    ordersSheet.Cell(row, 2).Style.NumberFormat.Format = "yyyy-MM-dd HH:mm";
                    ordersSheet.Cell(row, 3).Value = order.CustomerName;
                    ordersSheet.Cell(row, 4).Value = order.CustomerEmail;
                    ordersSheet.Cell(row, 5).Value = order.CustomerPhone;
                    ordersSheet.Cell(row, 6).Value = shippingAddress;
                    ordersSheet.Cell(row, 7).Value = item.ProductName;
                    ordersSheet.Cell(row, 8).Value = item.Size ?? "-";
                    ordersSheet.Cell(row, 9).Value = item.Color ?? "-";
                    ordersSheet.Cell(row, 10).Value = item.Quantity;
                    ordersSheet.Cell(row, 11).Value = item.UnitPrice;
                    ordersSheet.Cell(row, 11).Style.NumberFormat.Format = "#,##0.00";
                    ordersSheet.Cell(row, 12).Value = item.TotalPrice;
                    ordersSheet.Cell(row, 12).Style.NumberFormat.Format = "#,##0.00";
                    
                    // Only show order totals on first item row
                    if (isFirstItem)
                    {
                        ordersSheet.Cell(row, 13).Value = order.SubtotalAmount;
                        ordersSheet.Cell(row, 13).Style.NumberFormat.Format = "#,##0.00";
                        ordersSheet.Cell(row, 14).Value = order.ShippingCost;
                        ordersSheet.Cell(row, 14).Style.NumberFormat.Format = "#,##0.00";
                        ordersSheet.Cell(row, 15).Value = order.DiscountAmount;
                        ordersSheet.Cell(row, 15).Style.NumberFormat.Format = "#,##0.00";
                        ordersSheet.Cell(row, 16).Value = order.TaxAmount;
                        ordersSheet.Cell(row, 16).Style.NumberFormat.Format = "#,##0.00";
                        ordersSheet.Cell(row, 17).Value = order.TotalAmount;
                        ordersSheet.Cell(row, 17).Style.NumberFormat.Format = "#,##0.00";
                        ordersSheet.Cell(row, 17).Style.Font.Bold = true;
                        ordersSheet.Cell(row, 18).Value = order.PaymentStatus;
                        ordersSheet.Cell(row, 19).Value = order.OrderStatus;
                        ordersSheet.Cell(row, 20).Value = order.Currency.ToUpper();
                        isFirstItem = false;
                    }
                    
                    row++;
                }
            }
            else
            {
                // Order without items (edge case)
                ordersSheet.Cell(row, 1).Value = order.OrderNumber;
                ordersSheet.Cell(row, 2).Value = order.CreatedAt;
                ordersSheet.Cell(row, 2).Style.NumberFormat.Format = "yyyy-MM-dd HH:mm";
                ordersSheet.Cell(row, 3).Value = order.CustomerName;
                ordersSheet.Cell(row, 4).Value = order.CustomerEmail;
                ordersSheet.Cell(row, 5).Value = order.CustomerPhone;
                ordersSheet.Cell(row, 6).Value = shippingAddress;
                ordersSheet.Cell(row, 7).Value = "(No items)";
                ordersSheet.Cell(row, 13).Value = order.SubtotalAmount;
                ordersSheet.Cell(row, 13).Style.NumberFormat.Format = "#,##0.00";
                ordersSheet.Cell(row, 14).Value = order.ShippingCost;
                ordersSheet.Cell(row, 14).Style.NumberFormat.Format = "#,##0.00";
                ordersSheet.Cell(row, 15).Value = order.DiscountAmount;
                ordersSheet.Cell(row, 15).Style.NumberFormat.Format = "#,##0.00";
                ordersSheet.Cell(row, 16).Value = order.TaxAmount;
                ordersSheet.Cell(row, 16).Style.NumberFormat.Format = "#,##0.00";
                ordersSheet.Cell(row, 17).Value = order.TotalAmount;
                ordersSheet.Cell(row, 17).Style.NumberFormat.Format = "#,##0.00";
                ordersSheet.Cell(row, 17).Style.Font.Bold = true;
                ordersSheet.Cell(row, 18).Value = order.PaymentStatus;
                ordersSheet.Cell(row, 19).Value = order.OrderStatus;
                ordersSheet.Cell(row, 20).Value = order.Currency.ToUpper();
                row++;
            }
            
            // Add separator row with light background between orders
            ordersSheet.Range(row - 1, 1, row - 1, orderHeaders.Length).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ordersSheet.Range(row - 1, 1, row - 1, orderHeaders.Length).Style.Border.BottomBorderColor = XLColor.LightGray;
        }
        
        ordersSheet.Columns().AdjustToContents();
        
        // Freeze header row
        ordersSheet.SheetView.FreezeRows(3);

        // === SHIPPING SUMMARY SHEET ===
        var shippingSheet = workbook.Worksheets.Add("Shipping Summary");
        
        shippingSheet.Cell("A1").Value = "Shipping Analysis";
        shippingSheet.Cell("A1").Style.Font.Bold = true;
        shippingSheet.Cell("A1").Style.Font.FontSize = 14;
        
        shippingSheet.Cell("A2").Value = $"Period: {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}";
        shippingSheet.Cell("A2").Style.Font.Italic = true;
        shippingSheet.Cell("A2").Style.Font.FontColor = XLColor.Gray;
        
        // Shipping overview
        shippingSheet.Cell("A4").Value = "Overview";
        shippingSheet.Cell("A4").Style.Font.Bold = true;
        shippingSheet.Range("A4:B4").Style.Fill.BackgroundColor = XLColor.LightBlue;
        
        row = 5;
        shippingSheet.Cell(row, 1).Value = "Total Orders with Shipping";
        shippingSheet.Cell(row, 2).Value = orders.Count(o => o.ShippingCost > 0);
        
        row++;
        shippingSheet.Cell(row, 1).Value = "Orders with Free Shipping";
        shippingSheet.Cell(row, 2).Value = orders.Count(o => o.ShippingCost == 0);
        
        row++;
        shippingSheet.Cell(row, 1).Value = "Total Shipping Charged to Customers";
        shippingSheet.Cell(row, 2).Value = totalShippingCollected;
        shippingSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        
        row++;
        shippingSheet.Cell(row, 1).Value = "Total Actual Shipping Cost";
        shippingSheet.Cell(row, 2).Value = totalShippingCost;
        shippingSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        shippingSheet.Cell(row, 2).Style.Font.FontColor = XLColor.Red;
        
        row++;
        shippingSheet.Cell(row, 1).Value = "Shipping Profit/Loss";
        shippingSheet.Cell(row, 2).Value = shippingProfit;
        shippingSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        shippingSheet.Cell(row, 2).Style.Font.Bold = true;
        shippingSheet.Cell(row, 2).Style.Font.FontColor = shippingProfit >= 0 ? XLColor.Green : XLColor.Red;
        shippingSheet.Range(row, 1, row, 2).Style.Fill.BackgroundColor = XLColor.LightGray;
        
        // Shipping by Provider
        row += 2;
        shippingSheet.Cell(row, 1).Value = "Shipping by Provider";
        shippingSheet.Cell(row, 1).Style.Font.Bold = true;
        shippingSheet.Range(row, 1, row, 5).Style.Fill.BackgroundColor = XLColor.LightSteelBlue;
        
        row++;
        shippingSheet.Cell(row, 1).Value = "Provider";
        shippingSheet.Cell(row, 2).Value = "Shipments";
        shippingSheet.Cell(row, 3).Value = "Total Cost";
        shippingSheet.Cell(row, 4).Value = "Avg Cost";
        shippingSheet.Cell(row, 5).Value = "% of Total";
        shippingSheet.Range(row, 1, row, 5).Style.Font.Bold = true;
        
        var shipmentsByProvider = shipments
            .GroupBy(s => s.ShippingProviderId)
            .Select(g => new {
                Provider = shippingProviders.TryGetValue(g.Key, out var p) ? p.Name : "Unknown",
                Count = g.Count(),
                TotalCost = g.Sum(s => s.ShippingCost),
                AvgCost = g.Average(s => s.ShippingCost)
            })
            .OrderByDescending(s => s.TotalCost)
            .ToList();
        
        row++;
        if (shipmentsByProvider.Any())
        {
            foreach (var provider in shipmentsByProvider)
            {
                shippingSheet.Cell(row, 1).Value = provider.Provider;
                shippingSheet.Cell(row, 2).Value = provider.Count;
                shippingSheet.Cell(row, 3).Value = provider.TotalCost;
                shippingSheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";
                shippingSheet.Cell(row, 4).Value = provider.AvgCost;
                shippingSheet.Cell(row, 4).Style.NumberFormat.Format = "#,##0.00";
                shippingSheet.Cell(row, 5).Value = totalShippingCost > 0 ? (provider.TotalCost / totalShippingCost) : 0;
                shippingSheet.Cell(row, 5).Style.NumberFormat.Format = "0.0%";
                row++;
            }
        }
        else
        {
            shippingSheet.Cell(row, 1).Value = "(No shipment records - using order shipping costs)";
            shippingSheet.Cell(row, 1).Style.Font.Italic = true;
            row++;
        }
        
        // Shipping by Status
        row += 2;
        shippingSheet.Cell(row, 1).Value = "Shipment Status Breakdown";
        shippingSheet.Cell(row, 1).Style.Font.Bold = true;
        shippingSheet.Range(row, 1, row, 3).Style.Fill.BackgroundColor = XLColor.LightYellow;
        
        row++;
        shippingSheet.Cell(row, 1).Value = "Status";
        shippingSheet.Cell(row, 2).Value = "Count";
        shippingSheet.Cell(row, 3).Value = "Shipping Cost";
        shippingSheet.Range(row, 1, row, 3).Style.Font.Bold = true;
        
        var shipmentsByStatus = shipments
            .GroupBy(s => s.Status)
            .Select(g => new {
                Status = g.Key.ToString(),
                Count = g.Count(),
                TotalCost = g.Sum(s => s.ShippingCost)
            })
            .OrderByDescending(s => s.Count)
            .ToList();
        
        row++;
        if (shipmentsByStatus.Any())
        {
            foreach (var status in shipmentsByStatus)
            {
                shippingSheet.Cell(row, 1).Value = status.Status;
                shippingSheet.Cell(row, 2).Value = status.Count;
                shippingSheet.Cell(row, 3).Value = status.TotalCost;
                shippingSheet.Cell(row, 3).Style.NumberFormat.Format = "#,##0.00";
                row++;
            }
        }
        else
        {
            shippingSheet.Cell(row, 1).Value = "(No shipment tracking data yet)";
            shippingSheet.Cell(row, 1).Style.Font.Italic = true;
            row++;
        }
        
        // Individual shipment details
        row += 2;
        shippingSheet.Cell(row, 1).Value = "Shipment Details";
        shippingSheet.Cell(row, 1).Style.Font.Bold = true;
        shippingSheet.Range(row, 1, row, 7).Style.Fill.BackgroundColor = XLColor.LightGreen;
        
        row++;
        shippingSheet.Cell(row, 1).Value = "Order #";
        shippingSheet.Cell(row, 2).Value = "Provider";
        shippingSheet.Cell(row, 3).Value = "Rate/Service";
        shippingSheet.Cell(row, 4).Value = "Tracking #";
        shippingSheet.Cell(row, 5).Value = "Status";
        shippingSheet.Cell(row, 6).Value = "Shipped Date";
        shippingSheet.Cell(row, 7).Value = "Cost";
        shippingSheet.Range(row, 1, row, 7).Style.Font.Bold = true;
        
        row++;
        foreach (var shipment in shipments.OrderByDescending(s => s.CreatedAt))
        {
            var order = orders.FirstOrDefault(o => o.Id == shipment.OrderId);
            var provider = shippingProviders.TryGetValue(shipment.ShippingProviderId, out var p) ? p.Name : "Unknown";
            var rate = shippingRates.TryGetValue(shipment.ShippingRateId, out var r) ? r.Name : "Standard";
            
            shippingSheet.Cell(row, 1).Value = order?.OrderNumber ?? $"Order #{shipment.OrderId}";
            shippingSheet.Cell(row, 2).Value = provider;
            shippingSheet.Cell(row, 3).Value = rate;
            shippingSheet.Cell(row, 4).Value = shipment.TrackingNumber ?? "-";
            shippingSheet.Cell(row, 5).Value = shipment.Status.ToString();
            shippingSheet.Cell(row, 6).Value = shipment.ShippedAt?.ToString("yyyy-MM-dd HH:mm") ?? "-";
            shippingSheet.Cell(row, 7).Value = shipment.ShippingCost;
            shippingSheet.Cell(row, 7).Style.NumberFormat.Format = "#,##0.00";
            row++;
        }
        
        // Note about API integration
        row += 2;
        shippingSheet.Cell(row, 1).Value = "Note: Shipping costs shown are current values. When shipping provider APIs are integrated,";
        shippingSheet.Cell(row, 1).Style.Font.Italic = true;
        shippingSheet.Cell(row, 1).Style.Font.FontColor = XLColor.Gray;
        row++;
        shippingSheet.Cell(row, 1).Value = "real-time rates and tracking data will be available.";
        shippingSheet.Cell(row, 1).Style.Font.Italic = true;
        shippingSheet.Cell(row, 1).Style.Font.FontColor = XLColor.Gray;
        
        shippingSheet.Columns().AdjustToContents();

        // === DEDUCTIONS BREAKDOWN SHEET ===
        var deductSheet = workbook.Worksheets.Add("Deductions Breakdown");
        
        deductSheet.Cell("A1").Value = "Deductions & Costs Analysis";
        deductSheet.Cell("A1").Style.Font.Bold = true;
        deductSheet.Cell("A1").Style.Font.FontSize = 14;
        
        deductSheet.Cell("A3").Value = "Category";
        deductSheet.Cell("B3").Value = "Amount (PLN)";
        deductSheet.Cell("C3").Value = "% of Total";
        deductSheet.Cell("D3").Value = "Notes";
        deductSheet.Range("A3:D3").Style.Font.Bold = true;
        deductSheet.Range("A3:D3").Style.Fill.BackgroundColor = XLColor.LightPink;
        
        var totalDeductions = totalStripeFees + totalDevCommission + totalTax + totalDiscounts + totalShippingCost;
        var deductions = new[]
        {
            new { Category = "Stripe Processing Fees", Amount = totalStripeFees, Note = "2.9% + fixed fee per transaction" },
            new { Category = "Developer Commission", Amount = totalDevCommission, Note = $"{commissionSettings?.DeveloperCommissionRate ?? 0}% of order total" },
            new { Category = "Tax Collected (VAT)", Amount = totalTax, Note = "To be remitted to tax authority" },
            new { Category = "Discounts Applied", Amount = totalDiscounts, Note = "Coupons and promotional discounts" },
            new { Category = "Actual Shipping Costs", Amount = totalShippingCost, Note = "Cost paid to shipping providers" }
        };
        
        row = 4;
        foreach (var deduction in deductions)
        {
            deductSheet.Cell(row, 1).Value = deduction.Category;
            deductSheet.Cell(row, 2).Value = deduction.Amount;
            deductSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00";
            deductSheet.Cell(row, 3).Value = totalDeductions > 0 ? (deduction.Amount / totalDeductions) : 0;
            deductSheet.Cell(row, 3).Style.NumberFormat.Format = "0.0%";
            deductSheet.Cell(row, 4).Value = deduction.Note;
            deductSheet.Cell(row, 4).Style.Font.FontColor = XLColor.Gray;
            row++;
        }
        
        deductSheet.Cell(row, 1).Value = "TOTAL DEDUCTIONS & COSTS";
        deductSheet.Cell(row, 1).Style.Font.Bold = true;
        deductSheet.Cell(row, 2).Value = totalDeductions;
        deductSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00";
        deductSheet.Cell(row, 2).Style.Font.Bold = true;
        deductSheet.Cell(row, 3).Value = 1;
        deductSheet.Cell(row, 3).Style.NumberFormat.Format = "0%";
        deductSheet.Range(row, 1, row, 4).Style.Fill.BackgroundColor = XLColor.LightGray;
        
        // Add profit summary after deductions
        row += 2;
        deductSheet.Cell(row, 1).Value = "Profit Summary";
        deductSheet.Cell(row, 1).Style.Font.Bold = true;
        deductSheet.Range(row, 1, row, 2).Style.Fill.BackgroundColor = XLColor.LightGreen;
        
        row++;
        deductSheet.Cell(row, 1).Value = "Gross Revenue";
        deductSheet.Cell(row, 2).Value = grossRevenue;
        deductSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        
        row++;
        deductSheet.Cell(row, 1).Value = "Total Deductions & Costs";
        deductSheet.Cell(row, 2).Value = totalDeductions;
        deductSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        deductSheet.Cell(row, 2).Style.Font.FontColor = XLColor.Red;
        
        row++;
        deductSheet.Cell(row, 1).Value = "NET PROFIT";
        deductSheet.Cell(row, 1).Style.Font.Bold = true;
        deductSheet.Cell(row, 2).Value = grossRevenue - totalDeductions;
        deductSheet.Cell(row, 2).Style.NumberFormat.Format = "#,##0.00 \"PLN\"";
        deductSheet.Cell(row, 2).Style.Font.Bold = true;
        deductSheet.Cell(row, 2).Style.Font.FontColor = (grossRevenue - totalDeductions) >= 0 ? XLColor.DarkGreen : XLColor.Red;
        deductSheet.Range(row, 1, row, 2).Style.Fill.BackgroundColor = XLColor.LightGray;
        
        deductSheet.Columns().AdjustToContents();

        // Save to memory stream and return bytes
        using var stream = new MemoryStream();
        workbook.SaveAs(stream);
        return stream.ToArray();
    }

    private async Task SendCommissionRequestNotification(DeveloperCommissionRequest request, ApplicationUser developer)
    {
        try
        {
            // Log the notification - in production, integrate with email service
            var developerName = $"{developer.FirstName} {developer.LastName}".Trim();
            _logger.LogInformation(
                "Commission change request notification: Developer {Developer} ({Email}) requested rate change from {CurrentRate}% to {RequestedRate}%",
                developerName,
                developer.Email,
                request.CurrentRate,
                request.RequestedRate
            );
            
            request.AdminNotified = true;
            _unitOfWork.Repository<DeveloperCommissionRequest>().Update(request);
            
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending commission request notification");
        }
    }

    private async Task SendCommissionDecisionNotification(DeveloperCommissionRequest request)
    {
        try
        {
            var developer = await _userManager.FindByIdAsync(request.DeveloperId);
            if (developer == null) return;

            var statusText = request.Status == CommissionRequestStatus.Approved ? "APPROVED" : "REJECTED";
            
            // Log the notification - in production, integrate with email service
            _logger.LogInformation(
                "Commission decision notification: Request {RequestId} was {Status}. Developer: {Email}, Requested Rate: {Rate}%",
                request.Id,
                statusText,
                developer.Email,
                request.RequestedRate
            );
            
            request.DeveloperNotified = true;
            _unitOfWork.Repository<DeveloperCommissionRequest>().Update(request);
            
            await _unitOfWork.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error sending commission decision notification");
        }
    }

    /// <summary>
    /// POST: Seed demo financial data for testing
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> SeedDemoData()
    {
        try
        {
            await FinancialDataSeeder.SeedFinancialDataAsync(HttpContext.RequestServices);
            return Json(new { success = true, message = "Demo data seeded successfully. Refresh to see results." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error seeding demo data");
            return Json(new { success = false, message = ex.Message });
        }
    }

    /// <summary>
    /// POST: Remove demo financial data
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> RemoveDemoData()
    {
        try
        {
            await FinancialDataSeeder.RemoveFinancialDataAsync(HttpContext.RequestServices);
            return Json(new { success = true, message = "Demo data removed successfully." });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing demo data");
            return Json(new { success = false, message = ex.Message });
        }
    }

    #endregion
}

public class CommissionChangeRequestDto
{
    public decimal RequestedRate { get; set; }
    public string Reason { get; set; } = string.Empty;
}

public class ReviewCommissionRequestDto
{
    public int RequestId { get; set; }
    public bool Approved { get; set; }
    public string? Response { get; set; }
}

public class UpdateCommissionSettingsDto
{
    public decimal DeveloperRate { get; set; }
    public decimal PlatformRate { get; set; }
    public bool AutoPayoutEnabled { get; set; }
    public decimal MinimumPayout { get; set; }
}

public class UpdateTaxRateDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDefault { get; set; }
}

public class CreateTaxRateDto
{
    public string Name { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string? StateCode { get; set; }
    public decimal Rate { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDefault { get; set; }
    public string? StripeTaxRateId { get; set; }
    public string? Description { get; set; }
}