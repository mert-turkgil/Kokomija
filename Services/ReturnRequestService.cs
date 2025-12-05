using Kokomija.Data;
using Kokomija.Entity;
using Kokomija.Models.ViewModels.ReturnRequest;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace Kokomija.Services
{
    public interface IReturnRequestService
    {
        Task<(bool Success, string Message, int? ReturnRequestId)> CreateReturnRequestAsync(CreateReturnRequestDto dto, string userId);
        Task<ReturnRequestDetailsDto?> GetReturnRequestDetailsAsync(int id);
        Task<List<ReturnRequestListDto>> GetAllReturnRequestsAsync();
        Task<List<ReturnRequestListDto>> GetReturnRequestsByUserAsync(string userId);
        Task<List<OrderItemDto>> GetEligibleItemsForReturnAsync(string userId);
        Task<(bool Success, string Message)> ReviewReturnRequestAsync(ReviewReturnRequestDto dto, string reviewerId);
        Task<ReturnRequestsViewModel> GetReturnRequestsStatisticsAsync();
    }

    public class ReturnRequestService : IReturnRequestService
    {
        private readonly ApplicationDbContext _context;
        private readonly IProductImageService _productImageService;
        private readonly IEmailService _emailService;
        private readonly ILogger<ReturnRequestService> _logger;
        private readonly RefundService _stripeRefundService;

        public ReturnRequestService(
            ApplicationDbContext context,
            IProductImageService productImageService,
            IEmailService emailService,
            ILogger<ReturnRequestService> logger)
        {
            _context = context;
            _productImageService = productImageService;
            _emailService = emailService;
            _logger = logger;
            _stripeRefundService = new RefundService();
        }

        public async Task<(bool Success, string Message, int? ReturnRequestId)> CreateReturnRequestAsync(CreateReturnRequestDto dto, string userId)
        {
            try
            {
                // Validate order item belongs to user
                var orderItem = await _context.OrderItems
                    .Include(oi => oi.Order)
                    .Include(oi => oi.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                    .FirstOrDefaultAsync(oi => oi.Id == dto.OrderItemId && oi.Order.UserId == userId);

                if (orderItem == null)
                    return (false, "Order item not found or does not belong to you.", null);

                // Check if order is completed and within return window (e.g., 30 days)
                if (orderItem.Order.CreatedAt < DateTime.UtcNow.AddDays(-30))
                    return (false, "Return period has expired. Returns are only accepted within 30 days of purchase.", null);

                // Check if already has a pending/approved return request
                var existingRequest = await _context.ReturnRequests
                    .AnyAsync(rr => rr.OrderItemId == dto.OrderItemId && 
                                   (rr.Status == ReturnRequestStatus.Pending || 
                                    rr.Status == ReturnRequestStatus.UnderReview ||
                                    rr.Status == ReturnRequestStatus.Approved));

                if (existingRequest)
                    return (false, "A return request already exists for this item.", null);

                // Create return request
                var returnRequest = new Entity.ReturnRequest
                {
                    OrderId = dto.OrderId,
                    OrderItemId = dto.OrderItemId,
                    UserId = userId,
                    Reason = dto.Reason,
                    Description = dto.Description,
                    RequestedAmount = dto.RequestedAmount,
                    Status = ReturnRequestStatus.Pending,
                    RequestedAt = DateTime.UtcNow
                };

                _context.ReturnRequests.Add(returnRequest);
                await _context.SaveChangesAsync();

                // Add status history
                var statusHistory = new ReturnStatusHistory
                {
                    ReturnRequestId = returnRequest.Id,
                    Status = ReturnRequestStatus.Pending,
                    Notes = "Return request created by customer",
                    ChangedBy = userId,
                    ChangedAt = DateTime.UtcNow
                };
                _context.ReturnStatusHistories.Add(statusHistory);

                // Upload images if provided
                if (dto.Images != null && dto.Images.Any())
                {
                    foreach (var image in dto.Images)
                    {
                        var uploadResult = await _productImageService.UploadToTempAsync(image);
                        if (uploadResult.Success && !string.IsNullOrEmpty(uploadResult.TempUrl))
                        {
                            var returnImage = new ReturnRequestImage
                            {
                                ReturnRequestId = returnRequest.Id,
                                ImageUrl = uploadResult.TempUrl,
                                UploadedAt = DateTime.UtcNow
                            };
                            _context.ReturnRequestImages.Add(returnImage);
                        }
                    }
                }

                await _context.SaveChangesAsync();

                // Send email notification to customer
                await _emailService.SendReturnRequestConfirmationAsync(userId, returnRequest.Id);

                // Send notification to admins
                await _emailService.SendNewReturnRequestNotificationToAdminsAsync(returnRequest.Id);

                _logger.LogInformation("Return request {ReturnRequestId} created by user {UserId}", returnRequest.Id, userId);

                return (true, "Return request submitted successfully. You will be notified once it's reviewed.", returnRequest.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating return request for user {UserId}", userId);
                return (false, "An error occurred while submitting your return request. Please try again.", null);
            }
        }

        public async Task<ReturnRequestDetailsDto?> GetReturnRequestDetailsAsync(int id)
        {
            var returnRequest = await _context.ReturnRequests
                .Include(rr => rr.Order)
                .Include(rr => rr.OrderItem)
                    .ThenInclude(oi => oi.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                            .ThenInclude(p => p.Images)
                .Include(rr => rr.User)
                .Include(rr => rr.Reviewer)
                .Include(rr => rr.Images)
                .Include(rr => rr.StatusHistory)
                    .ThenInclude(sh => sh.User)
                .FirstOrDefaultAsync(rr => rr.Id == id);

            if (returnRequest == null)
                return null;

            return new ReturnRequestDetailsDto
            {
                Id = returnRequest.Id,
                OrderId = returnRequest.OrderId,
                OrderNumber = returnRequest.Order.OrderNumber,
                OrderItemId = returnRequest.OrderItemId,
                ProductName = returnRequest.OrderItem.ProductVariant.Product.Name,
                ProductImageUrl = returnRequest.OrderItem.ProductVariant.Product.Images.FirstOrDefault()?.ImageUrl,
                ProductPrice = returnRequest.OrderItem.UnitPrice,
                Quantity = returnRequest.OrderItem.Quantity,
                CustomerName = $"{returnRequest.User.FirstName} {returnRequest.User.LastName}",
                CustomerEmail = returnRequest.User.Email!,
                Reason = returnRequest.Reason,
                Description = returnRequest.Description,
                RequestedAmount = returnRequest.RequestedAmount,
                Status = returnRequest.Status,
                RequestedAt = returnRequest.RequestedAt,
                ReviewedAt = returnRequest.ReviewedAt,
                ReviewerName = returnRequest.Reviewer != null ? $"{returnRequest.Reviewer.FirstName} {returnRequest.Reviewer.LastName}" : null,
                ReviewNotes = returnRequest.ReviewNotes,
                StripeRefundId = returnRequest.StripeRefundId,
                RefundedAmount = returnRequest.RefundedAmount,
                RefundedAt = returnRequest.RefundedAt,
                ImageUrls = returnRequest.Images.Select(i => i.ImageUrl).ToList(),
                StatusHistory = returnRequest.StatusHistory
                    .OrderByDescending(sh => sh.ChangedAt)
                    .Select(sh => new ReturnStatusHistoryDto
                    {
                        Id = sh.Id,
                        Status = sh.Status,
                        Notes = sh.Notes,
                        ChangedBy = $"{sh.User.FirstName} {sh.User.LastName}",
                        ChangedAt = sh.ChangedAt
                    }).ToList()
            };
        }

        public async Task<List<ReturnRequestListDto>> GetAllReturnRequestsAsync()
        {
            return await _context.ReturnRequests
                .Include(rr => rr.Order)
                .Include(rr => rr.OrderItem)
                    .ThenInclude(oi => oi.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                            .ThenInclude(p => p.Images)
                .Include(rr => rr.User)
                .Include(rr => rr.Images)
                .OrderByDescending(rr => rr.RequestedAt)
                .Select(rr => new ReturnRequestListDto
                {
                    Id = rr.Id,
                    OrderId = rr.OrderId,
                    OrderNumber = rr.Order.OrderNumber,
                    ProductName = rr.OrderItem.ProductVariant.Product.Name,
                    ProductImageUrl = rr.OrderItem.ProductVariant.Product.Images.FirstOrDefault()!.ImageUrl,
                    CustomerName = rr.User.FirstName + " " + rr.User.LastName,
                    CustomerEmail = rr.User.Email!,
                    Reason = rr.Reason,
                    RequestedAmount = rr.RequestedAmount,
                    Status = rr.Status,
                    RequestedAt = rr.RequestedAt,
                    HasImages = rr.Images.Any()
                })
                .ToListAsync();
        }

        public async Task<List<ReturnRequestListDto>> GetReturnRequestsByUserAsync(string userId)
        {
            return await _context.ReturnRequests
                .Include(rr => rr.Order)
                .Include(rr => rr.OrderItem)
                    .ThenInclude(oi => oi.ProductVariant)
                        .ThenInclude(pv => pv.Product)
                            .ThenInclude(p => p.Images)
                .Include(rr => rr.Images)
                .Where(rr => rr.UserId == userId)
                .OrderByDescending(rr => rr.RequestedAt)
                .Select(rr => new ReturnRequestListDto
                {
                    Id = rr.Id,
                    OrderId = rr.OrderId,
                    OrderNumber = rr.Order.OrderNumber,
                    ProductName = rr.OrderItem.ProductVariant.Product.Name,
                    ProductImageUrl = rr.OrderItem.ProductVariant.Product.Images.FirstOrDefault()!.ImageUrl,
                    CustomerName = rr.User.FirstName + " " + rr.User.LastName,
                    CustomerEmail = rr.User.Email!,
                    Reason = rr.Reason,
                    RequestedAmount = rr.RequestedAmount,
                    Status = rr.Status,
                    RequestedAt = rr.RequestedAt,
                    HasImages = rr.Images.Any()
                })
                .ToListAsync();
        }

        public async Task<List<OrderItemDto>> GetEligibleItemsForReturnAsync(string userId)
        {
            var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);

            var orderItems = await _context.OrderItems
                .Include(oi => oi.Order)
                .Include(oi => oi.ProductVariant)
                    .ThenInclude(pv => pv.Product)
                        .ThenInclude(p => p.Images)
                .Where(oi => oi.Order.UserId == userId && 
                            oi.Order.PaymentStatus == "paid" &&
                            oi.Order.CreatedAt >= thirtyDaysAgo)
                .ToListAsync();

            var returnRequestItems = await _context.ReturnRequests
                .Where(rr => rr.UserId == userId)
                .Select(rr => rr.OrderItemId)
                .ToListAsync();

            return orderItems.Select(oi => new OrderItemDto
            {
                OrderId = oi.OrderId,
                OrderNumber = oi.Order.OrderNumber,
                OrderItemId = oi.Id,
                ProductName = oi.ProductVariant.Product.Name,
                ProductImageUrl = oi.ProductVariant.Product.Images.FirstOrDefault()?.ImageUrl,
                Price = oi.UnitPrice,
                Quantity = oi.Quantity,
                Total = oi.UnitPrice * oi.Quantity,
                OrderDate = oi.Order.CreatedAt,
                CanReturn = !returnRequestItems.Contains(oi.Id),
                CannotReturnReason = returnRequestItems.Contains(oi.Id) ? "Return request already exists" : null
            }).ToList();
        }

        public async Task<(bool Success, string Message)> ReviewReturnRequestAsync(ReviewReturnRequestDto dto, string reviewerId)
        {
            try
            {
                var returnRequest = await _context.ReturnRequests
                    .Include(rr => rr.Order)
                    .Include(rr => rr.OrderItem)
                    .Include(rr => rr.User)
                    .FirstOrDefaultAsync(rr => rr.Id == dto.ReturnRequestId);

                if (returnRequest == null)
                    return (false, "Return request not found.");

                if (returnRequest.Status != ReturnRequestStatus.Pending && returnRequest.Status != ReturnRequestStatus.UnderReview)
                    return (false, "This return request has already been reviewed.");

                var newStatus = dto.Approve ? ReturnRequestStatus.Approved : ReturnRequestStatus.Rejected;
                returnRequest.Status = newStatus;
                returnRequest.ReviewedAt = DateTime.UtcNow;
                returnRequest.ReviewedBy = reviewerId;
                returnRequest.ReviewNotes = dto.ReviewNotes;

                // Add status history
                var statusHistory = new ReturnStatusHistory
                {
                    ReturnRequestId = returnRequest.Id,
                    Status = newStatus,
                    Notes = dto.ReviewNotes ?? (dto.Approve ? "Return request approved" : "Return request rejected"),
                    ChangedBy = reviewerId,
                    ChangedAt = DateTime.UtcNow
                };
                _context.ReturnStatusHistories.Add(statusHistory);

                // Process refund if approved
                if (dto.Approve && !string.IsNullOrEmpty(returnRequest.Order.StripePaymentIntentId))
                {
                    var refundAmount = dto.RefundAmount ?? returnRequest.RequestedAmount;

                    try
                    {
                        // Create Stripe refund
                        var refundOptions = new RefundCreateOptions
                        {
                            PaymentIntent = returnRequest.Order.StripePaymentIntentId,
                            Amount = (long)(refundAmount * 100), // Convert to cents
                            Reason = RefundReasons.RequestedByCustomer,
                            Metadata = new Dictionary<string, string>
                            {
                                { "return_request_id", returnRequest.Id.ToString() },
                                { "order_id", returnRequest.OrderId.ToString() },
                                { "order_item_id", returnRequest.OrderItemId.ToString() }
                            }
                        };

                        var refund = await _stripeRefundService.CreateAsync(refundOptions);

                        if (refund.Status == "succeeded" || refund.Status == "pending")
                        {
                            returnRequest.StripeRefundId = refund.Id;
                            returnRequest.RefundedAmount = refundAmount;
                            returnRequest.RefundedAt = DateTime.UtcNow;
                            returnRequest.Status = ReturnRequestStatus.Completed;

                            // Create payment transaction record
                            var transaction = new PaymentTransaction
                            {
                                OrderId = returnRequest.OrderId,
                                ReturnRequestId = returnRequest.Id,
                                Type = TransactionType.Refund,
                                Amount = refundAmount,
                                Currency = "TRY",
                                StripeRefundId = refund.Id,
                                Status = refund.Status == "succeeded" ? TransactionStatus.Succeeded : TransactionStatus.Processing,
                                ProcessedAt = DateTime.UtcNow,
                                CreatedAt = DateTime.UtcNow
                            };
                            _context.PaymentTransactions.Add(transaction);

                            // Add completion status history
                            var completionHistory = new ReturnStatusHistory
                            {
                                ReturnRequestId = returnRequest.Id,
                                Status = ReturnRequestStatus.Completed,
                                Notes = $"Refund processed: {refundAmount:C} (Stripe Refund ID: {refund.Id})",
                                ChangedBy = reviewerId,
                                ChangedAt = DateTime.UtcNow
                            };
                            _context.ReturnStatusHistories.Add(completionHistory);

                            _logger.LogInformation("Stripe refund {RefundId} created for return request {ReturnRequestId}, amount: {Amount}",
                                refund.Id, returnRequest.Id, refundAmount);
                        }
                        else
                        {
                            _logger.LogWarning("Stripe refund failed for return request {ReturnRequestId}, status: {Status}",
                                returnRequest.Id, refund.Status);
                            return (false, $"Refund creation failed with status: {refund.Status}");
                        }
                    }
                    catch (StripeException stripeEx)
                    {
                        _logger.LogError(stripeEx, "Stripe error processing refund for return request {ReturnRequestId}", returnRequest.Id);
                        return (false, $"Error processing refund: {stripeEx.Message}");
                    }
                }

                await _context.SaveChangesAsync();

                // Send email notification to customer
                if (dto.Approve)
                {
                    await _emailService.SendReturnApprovedEmailAsync(returnRequest.UserId, returnRequest.Id, dto.CustomerMessage);
                }
                else
                {
                    await _emailService.SendReturnRejectedEmailAsync(returnRequest.UserId, returnRequest.Id, dto.CustomerMessage);
                }

                _logger.LogInformation("Return request {ReturnRequestId} {Action} by {ReviewerId}",
                    returnRequest.Id, dto.Approve ? "approved" : "rejected", reviewerId);

                return (true, dto.Approve ? "Return request approved and refund processed successfully." : "Return request rejected.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reviewing return request {ReturnRequestId}", dto.ReturnRequestId);
                return (false, "An error occurred while processing the review. Please try again.");
            }
        }

        public async Task<ReturnRequestsViewModel> GetReturnRequestsStatisticsAsync()
        {
            var allRequests = await GetAllReturnRequestsAsync();

            return new ReturnRequestsViewModel
            {
                ReturnRequests = allRequests,
                TotalCount = allRequests.Count,
                PendingCount = allRequests.Count(r => r.Status == ReturnRequestStatus.Pending || r.Status == ReturnRequestStatus.UnderReview),
                ApprovedCount = allRequests.Count(r => r.Status == ReturnRequestStatus.Approved),
                RejectedCount = allRequests.Count(r => r.Status == ReturnRequestStatus.Rejected),
                CompletedCount = allRequests.Count(r => r.Status == ReturnRequestStatus.Completed),
                TotalRefundedAmount = await _context.ReturnRequests
                    .Where(r => r.Status == ReturnRequestStatus.Completed && r.RefundedAmount.HasValue)
                    .SumAsync(r => r.RefundedAmount!.Value)
            };
        }
    }
}
