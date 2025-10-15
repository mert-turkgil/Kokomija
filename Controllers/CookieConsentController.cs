using Kokomija.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kokomija.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieConsentController : ControllerBase
    {
        private readonly ICookieConsentService _cookieConsentService;

        public CookieConsentController(ICookieConsentService cookieConsentService)
        {
            _cookieConsentService = cookieConsentService;
        }

        [HttpPost]
        public IActionResult SaveConsent([FromBody] CookieConsent consent)
        {
            if (consent == null)
            {
                return BadRequest("Invalid consent data");
            }

            _cookieConsentService.SaveConsent(HttpContext, consent);
            return Ok(new { message = "Cookie consent saved successfully" });
        }

        [HttpGet]
        public IActionResult GetConsent()
        {
            var consent = _cookieConsentService.GetConsent(HttpContext);
            return Ok(consent);
        }

        [HttpDelete]
        public IActionResult RevokeConsent()
        {
            _cookieConsentService.RevokeConsent(HttpContext);
            return Ok(new { message = "Cookie consent revoked successfully" });
        }
    }
}
