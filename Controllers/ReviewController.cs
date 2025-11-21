using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Kokomija.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kokomija.Controllers
{
    [Route("[controller]")]
    public class ReviewController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ReviewController> _logger;
        private readonly ILocalizationService _localizationService;

        public ReviewController(
            IUnitOfWork unitOfWork, 
            ILogger<ReviewController> logger,
            ILocalizationService localizationService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _localizationService = localizationService;
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ReviewCreateModel model)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Json(new { success = false, message = _localizationService.GetString("Review_LoginRequired") });
                }

                // Get the product to check ProductGroup
                var product = await _unitOfWork.Products.GetByIdAsync(model.ProductId);
                if (product == null)
                {
                    return Json(new { success = false, message = _localizationService.GetString("Product_NotFound") });
                }

                // Check if user has already reviewed this product OR any product in the same group
                ProductReview? existingReview = null;
                if (product.ProductGroupId.HasValue)
                {
                    existingReview = await _unitOfWork.ProductReviews.GetUserReviewForProductGroupAsync(userId, product.ProductGroupId.Value);
                }
                else
                {
                    existingReview = await _unitOfWork.ProductReviews.GetUserReviewForProductAsync(userId, model.ProductId);
                }
                
                if (existingReview != null)
                {
                    return Json(new { success = false, message = _localizationService.GetString("Review_AlreadyReviewed") });
                }

                // Check if user has purchased the product or any product in the same group
                bool hasPurchased;
                if (product.ProductGroupId.HasValue)
                {
                    hasPurchased = await _unitOfWork.ProductReviews.HasUserPurchasedProductGroupAsync(userId, product.ProductGroupId.Value);
                }
                else
                {
                    hasPurchased = await _unitOfWork.ProductReviews.HasUserPurchasedProductAsync(userId, model.ProductId);
                }

                if (!hasPurchased)
                {
                    return Json(new { success = false, message = _localizationService.GetString("Review_MustPurchaseFirst") });
                }

                var review = new ProductReview
                {
                    ProductId = model.ProductId,
                    UserId = userId,
                    Rating = model.Rating,
                    Comment = model.Comment.Trim(),
                    IsVerifiedPurchase = true, // Always verified since we check purchase
                    IsVisible = true,
                    CreatedAt = DateTime.UtcNow
                };

                await _unitOfWork.ProductReviews.AddAsync(review);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("User {UserId} created review {ReviewId} for product {ProductId}", userId, review.Id, model.ProductId);

                return Json(new { success = true, message = _localizationService.GetString("Review_SubmitSuccess") });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating review for product {ProductId}", model.ProductId);
                return Json(new { success = false, message = _localizationService.GetString("Error_Generic") });
            }
        }
        
        public class ReviewCreateModel
        {
            public int ProductId { get; set; }
            public decimal Rating { get; set; }
            public string Comment { get; set; } = string.Empty;
        }

        [HttpPost("AdminReply")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminReply(int reviewId, string adminReply)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId))
                {
                    return Json(new { success = false, message = _localizationService.GetString("Review_LoginRequired") });
                }

                var review = await _unitOfWork.ProductReviews.GetByIdAsync(reviewId);
                if (review == null)
                {
                    return Json(new { success = false, message = _localizationService.GetString("Review_NotFound") });
                }

                review.AdminReply = adminReply.Trim();
                review.AdminReplyBy = userId;
                review.AdminReplyAt = DateTime.UtcNow;
                review.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.ProductReviews.Update(review);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Admin {AdminId} replied to review {ReviewId}", userId, reviewId);

                return Json(new { success = true, message = _localizationService.GetString("Review_ReplySuccess") });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding admin reply to review {ReviewId}", reviewId);
                return Json(new { success = false, message = _localizationService.GetString("Error_Generic") });
            }
        }

        [HttpPost("AdminEdit")]
        [Authorize(Roles = "Admin,SuperAdmin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdminEdit(int reviewId, bool isVisible)
        {
            try
            {
                var review = await _unitOfWork.ProductReviews.GetByIdAsync(reviewId);
                if (review == null)
                {
                    return Json(new { success = false, message = _localizationService.GetString("Review_NotFound") });
                }

                review.IsVisible = isVisible;
                review.UpdatedAt = DateTime.UtcNow;

                _unitOfWork.ProductReviews.Update(review);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Admin toggled visibility of review {ReviewId} to {IsVisible}", reviewId, isVisible);

                return Json(new { success = true, message = _localizationService.GetString("Review_UpdateSuccess") });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error editing review {ReviewId}", reviewId);
                return Json(new { success = false, message = _localizationService.GetString("Error_Generic") });
            }
        }

        [HttpGet("GetReviews/{productId}")]
        public async Task<IActionResult> GetReviews(int productId)
        {
            try
            {
                var reviews = await _unitOfWork.ProductReviews.GetProductReviewsAsync(productId, false);
                var avgRating = await _unitOfWork.ProductReviews.GetAverageRatingAsync(productId);
                var reviewCount = await _unitOfWork.ProductReviews.GetReviewCountAsync(productId);

                return Json(new
                {
                    success = true,
                    reviews = reviews.Select(r => new
                    {
                        id = r.Id,
                        rating = r.Rating,
                        comment = r.Comment,
                        userName = r.User?.UserName ?? "Unknown",
                        isVerifiedPurchase = r.IsVerifiedPurchase,
                        adminReply = r.AdminReply,
                        adminUserName = r.AdminUser?.UserName,
                        createdAt = r.CreatedAt.ToString("yyyy-MM-dd"),
                        adminReplyAt = r.AdminReplyAt?.ToString("yyyy-MM-dd")
                    }),
                    averageRating = avgRating,
                    reviewCount = reviewCount
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting reviews for product {ProductId}", productId);
                return Json(new { success = false, message = _localizationService.GetString("Error_Generic") });
            }
        }
    }
}
