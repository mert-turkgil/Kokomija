using Kokomija.Services;
using Microsoft.AspNetCore.Identity;
using Kokomija.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kokomija.ViewComponents
{
    /// <summary>
    /// ViewComponent that renders the B2B/Retail mode toggle for verified business users.
    /// Injected in the layout to appear on every page.
    /// </summary>
    public class BusinessModeViewComponent : ViewComponent
    {
        private readonly INIPValidationService _nipValidationService;
        private readonly UserManager<ApplicationUser> _userManager;

        public BusinessModeViewComponent(
            INIPValidationService nipValidationService,
            UserManager<ApplicationUser> userManager)
        {
            _nipValidationService = nipValidationService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (UserClaimsPrincipal?.Identity?.IsAuthenticated != true)
            {
                return Content(string.Empty);
            }

            var userId = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Content(string.Empty);
            }

            var profile = await _nipValidationService.GetBusinessProfileAsync(userId);
            if (profile == null || !profile.IsVerified)
            {
                return Content(string.Empty);
            }

            var model = new BusinessModeViewModel
            {
                IsBusinessModeActive = profile.IsBusinessModeActive,
                CompanyName = profile.CompanyName
            };

            return View(model);
        }
    }

    public class BusinessModeViewModel
    {
        public bool IsBusinessModeActive { get; set; }
        public string CompanyName { get; set; } = string.Empty;
    }
}
