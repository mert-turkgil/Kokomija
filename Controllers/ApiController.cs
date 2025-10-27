using Kokomija.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Kokomija.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ColorsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ColorsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetColor(int id)
    {
        var color = await _unitOfWork.Colors.GetByIdAsync(id);
        if (color == null)
            return NotFound();

        return Ok(new { id = color.Id, name = color.DisplayName, hexCode = color.HexCode });
    }
}

[ApiController]
[Route("api/[controller]")]
public class SizesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public SizesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSize(int id)
    {
        var size = await _unitOfWork.Sizes.GetByIdAsync(id);
        if (size == null)
            return NotFound();

        return Ok(new { id = size.Id, name = size.DisplayName });
    }
}

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await _unitOfWork.Products.GetProductWithDetailsAsync(id);
        if (product == null)
            return NotFound();

        return Ok(new 
        { 
            id = product.Id,
            name = product.Name,
            price = product.Price,
            images = product.Images?.Select(img => new { imageUrl = img.ImageUrl }).ToList()
        });
    }
}
