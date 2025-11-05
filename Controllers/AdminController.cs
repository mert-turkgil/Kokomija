using Kokomija.Data.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kokomija.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<AdminController> _logger;

    public AdminController(IUnitOfWork unitOfWork, ILogger<AdminController> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public IActionResult Index()
    {
        _logger.LogInformation("Admin accessed dashboard");
        return View();
    }

    public IActionResult Users()
    {
        // Future: User management
        return View();
    }

    public IActionResult Products()
    {
        // Future: Product management
        return View();
    }

    public IActionResult Orders()
    {
        // Future: Order management
        return View();
    }

    public IActionResult Settings()
    {
        // Future: Site settings
        return View();
    }
}
