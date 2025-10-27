using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kokomija.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CartController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public CartController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddToCart([FromBody] CartAddRequest request)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        // Check if item already exists in cart
        var existingItem = await _unitOfWork.Carts.GetCartItemAsync(
            userId, 
            request.ProductId, 
            request.ColorId, 
            request.SizeId);

        if (existingItem != null)
        {
            // Update quantity
            existingItem.Quantity += request.Quantity;
            await _unitOfWork.SaveChangesAsync();
        }
        else
        {
            // Add new item
            var cartItem = new Cart
            {
                UserId = userId,
                ProductId = request.ProductId,
                ColorId = request.ColorId,
                SizeId = request.SizeId,
                Quantity = request.Quantity,
                AddedAt = DateTime.UtcNow
            };
            
            await _unitOfWork.Carts.AddAsync(cartItem);
            await _unitOfWork.SaveChangesAsync();
        }

        var count = await _unitOfWork.Carts.GetCartCountAsync(userId);
        return Ok(new { success = true, count });
    }

    [Authorize]
    [HttpPost("remove")]
    public async Task<IActionResult> RemoveFromCart([FromBody] CartRemoveRequest request)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var cartItem = await _unitOfWork.Carts.GetCartItemAsync(
            userId, 
            request.ProductId, 
            request.ColorId, 
            request.SizeId);

        if (cartItem != null)
        {
            _unitOfWork.Carts.Remove(cartItem);
            await _unitOfWork.SaveChangesAsync();
        }

        var count = await _unitOfWork.Carts.GetCartCountAsync(userId);
        return Ok(new { success = true, count });
    }

    [AllowAnonymous]
    [HttpGet("items")]
    public async Task<IActionResult> GetCartItems()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Ok(new List<object>());

        var items = await _unitOfWork.Carts.GetByUserIdAsync(userId);
        
        var cartItems = items.Select(c => new
        {
            productId = c.ProductId,
            productName = c.Product.Name,
            colorId = c.ColorId,
            colorName = c.Color?.DisplayName,
            sizeId = c.SizeId,
            sizeName = c.Size?.DisplayName,
            quantity = c.Quantity,
            price = c.Product.Price,
            imageUrl = c.Product.Images.FirstOrDefault()?.ImageUrl ?? "/img/logo_black.png"
        });

        return Ok(cartItems);
    }

    [Authorize]
    [HttpGet("count")]
    public async Task<IActionResult> GetCartCount()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Ok(new { count = 0 });

        var count = await _unitOfWork.Carts.GetCartCountAsync(userId);
        return Ok(new { count });
    }

    [Authorize]
    [HttpPost("merge")]
    public async Task<IActionResult> MergeGuestCart([FromBody] List<GuestCartItem> guestItems)
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        foreach (var guestItem in guestItems)
        {
            var existingItem = await _unitOfWork.Carts.GetCartItemAsync(
                userId,
                guestItem.ProductId,
                guestItem.ColorId,
                guestItem.SizeId);

            if (existingItem != null)
            {
                // Merge quantities
                existingItem.Quantity += guestItem.Quantity;
            }
            else
            {
                // Add new item from guest cart
                var cartItem = new Cart
                {
                    UserId = userId,
                    ProductId = guestItem.ProductId,
                    ColorId = guestItem.ColorId,
                    SizeId = guestItem.SizeId,
                    Quantity = guestItem.Quantity,
                    AddedAt = DateTime.UtcNow
                };
                
                await _unitOfWork.Carts.AddAsync(cartItem);
            }
        }

        await _unitOfWork.SaveChangesAsync();
        var count = await _unitOfWork.Carts.GetCartCountAsync(userId);
        
        return Ok(new { success = true, count });
    }
}

public class CartAddRequest
{
    public int ProductId { get; set; }
    public int? ColorId { get; set; }
    public int? SizeId { get; set; }
    public int Quantity { get; set; } = 1;
}

public class CartRemoveRequest
{
    public int ProductId { get; set; }
    public int? ColorId { get; set; }
    public int? SizeId { get; set; }
}

public class GuestCartItem
{
    public int ProductId { get; set; }
    public int? ColorId { get; set; }
    public int? SizeId { get; set; }
    public int Quantity { get; set; }
}
