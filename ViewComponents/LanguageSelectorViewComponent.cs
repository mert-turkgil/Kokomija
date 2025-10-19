using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace Kokomija.ViewComponents
{
    public class LanguageSelectorViewComponent : ViewComponent
    {
        private readonly IConfiguration _configuration;

        public LanguageSelectorViewComponent(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            var cultureFeature = HttpContext.Features.Get<IRequestCultureFeature>();
            var currentCulture = cultureFeature?.RequestCulture?.Culture ?? CultureInfo.CurrentCulture;

            // Get supported cultures from configuration
            var supportedCultures = _configuration.GetSection("Localization:SupportedCultures").Get<string[]>()
                ?? new[] { "pl-PL", "en-US" };

            var cultures = new List<SelectListItem>();

            foreach (var cultureCode in supportedCultures)
            {
                try
                {
                    var culture = new CultureInfo(cultureCode);
                    cultures.Add(new SelectListItem
                    {
                        Text = culture.NativeName, // e.g., "Türkçe", "English"
                        Value = culture.Name,      // e.g., "tr-TR", "en-US"
                        Selected = culture.Name.Equals(currentCulture.Name, StringComparison.OrdinalIgnoreCase)
                    });
                }
                catch (CultureNotFoundException)
                {
                    // Skip invalid culture codes
                    continue;
                }
            }

            return View(cultures);
        }
    }
}
