using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kokomija.Controllers;

[Authorize]
public class WishlistController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<WishlistController> _logger;

    public WishlistController(IUnitOfWork unitOfWork, ILogger<WishlistController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    // View wishlist page
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return RedirectToAction("Login", "Account");
        }

        var wishlistItems = await _unitOfWork.Wishlists.GetByUserIdAsync(userId);
        return View(wishlistItems);
    }

    // Toggle wishlist (add or remove)
    [HttpPost]
    public async Task<IActionResult> Toggle(int productId)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Json(new { success = false, message = "User not authenticated", requiresLogin = true });
            }

            var exists = await _unitOfWork.Wishlists.ExistsAsync(userId, productId);
            
            if (exists)
            {
                // Remove from wishlist
                var wishlistItem = await _unitOfWork.Wishlists.GetByUserAndProductAsync(userId, productId);
                if (wishlistItem != null)
                {
                    _unitOfWork.Wishlists.Remove(wishlistItem);
                    await _unitOfWork.SaveChangesAsync();
                    return Json(new { success = true, added = false, message = "Removed from wishlist" });
                }
            }
            else
            {
                // Add to wishlist
                var product = await _unitOfWork.Products.GetByIdAsync(productId);
                if (product == null)
                {
                    return Json(new { success = false, message = "Product not found" });
                }

                var wishlistItem = new Wishlist
                {
                    UserId = userId,
                    ProductId = productId,
                    AddedAt = DateTime.UtcNow
                };

                await _unitOfWork.Wishlists.AddAsync(wishlistItem);
                await _unitOfWork.SaveChangesAsync();
                
                return Json(new { success = true, added = true, message = "Added to wishlist" });
            }

            return Json(new { success = false, message = "Operation failed" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error toggling wishlist");
            return Json(new { success = false, message = "An error occurred" });
        }
    }

    // API endpoints for AJAX calls
    [HttpPost("api/wishlist/add")]
    public async Task<IActionResult> AddToWishlist([FromBody] WishlistRequest request)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            // Check if product exists
            var product = await _unitOfWork.Products.GetByIdAsync(request.ProductId);
            if (product == null)
            {
                return NotFound(new { message = "Product not found" });
            }

            // Check if already in wishlist
            var exists = await _unitOfWork.Wishlists.ExistsAsync(userId, request.ProductId);
            if (exists)
            {
                return BadRequest(new { message = "Product already in wishlist" });
            }

            // Add to wishlist
            var wishlistItem = new Wishlist
            {
                UserId = userId,
                ProductId = request.ProductId,
                AddedAt = DateTime.UtcNow
            };

            await _unitOfWork.Wishlists.AddAsync(wishlistItem);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("User {UserId} added product {ProductId} to wishlist", userId, request.ProductId);

            return Ok(new { message = "Product added to wishlist", wishlistId = wishlistItem.Id });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding product to wishlist");
            return StatusCode(500, new { message = "An error occurred while adding to wishlist" });
        }
    }

    [HttpPost("remove")]
    [Route("api/wishlist/remove")]
    public async Task<IActionResult> RemoveFromWishlist([FromBody] WishlistRequest request)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var wishlistItem = await _unitOfWork.Wishlists.GetByUserAndProductAsync(userId, request.ProductId);
            if (wishlistItem == null)
            {
                return NotFound(new { message = "Product not in wishlist" });
            }

            _unitOfWork.Wishlists.Remove(wishlistItem);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("User {UserId} removed product {ProductId} from wishlist", userId, request.ProductId);

            return Ok(new { message = "Product removed from wishlist" });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error removing product from wishlist");
            return StatusCode(500, new { message = "An error occurred while removing from wishlist" });
        }
    }

    [HttpGet]
    [Route("api/wishlist")]
    public async Task<IActionResult> GetWishlist()
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var wishlistItems = await _unitOfWork.Wishlists.GetByUserIdAsync(userId);

            var result = wishlistItems.Select(w => new
            {
                id = w.Id,
                productId = w.ProductId,
                productName = w.Product.Name,
                price = w.Product.Price,
                imageUrl = w.Product.Images?.FirstOrDefault()?.ImageUrl ?? "logo_black.png",
                addedAt = w.AddedAt
            });

            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error retrieving wishlist");
            return StatusCode(500, new { message = "An error occurred while retrieving wishlist" });
        }
    }

    [HttpGet("check/{productId}")]
    [Route("api/wishlist/check/{productId}")]
    public async Task<IActionResult> CheckWishlist(int productId)
    {
        try
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var exists = await _unitOfWork.Wishlists.ExistsAsync(userId, productId);

            return Ok(new { inWishlist = exists });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error checking wishlist status");
            return StatusCode(500, new { message = "An error occurred while checking wishlist" });
        }
    }
}

public class WishlistRequest
{
    public int ProductId { get; set; }
}
