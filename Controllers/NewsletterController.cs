using Microsoft.AspNetCore.Mvc;
using Kokomija.Data.Abstract;
using Kokomija.Services;
using Kokomija.Entity;

namespace Kokomija.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly ILogger<NewsletterController> _logger;

        public NewsletterController(
            IUnitOfWork unitOfWork,
            IEmailService emailService,
            ILogger<NewsletterController> logger)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _logger = logger;
        }

        /// <summary>
        /// Confirm newsletter subscription via email link
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Confirm(string token, string email)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Invalid confirmation link.";
                return RedirectToAction("Index", "Home");
            }

            var subscription = await _unitOfWork.Repository<NewsletterSubscription>()
                .FirstOrDefaultAsync(ns => ns.Email == email && ns.ConfirmationToken == token);

            if (subscription == null)
            {
                TempData["ErrorMessage"] = "Invalid or expired confirmation link.";
                return RedirectToAction("Index", "Home");
            }

            if (subscription.ConfirmationTokenExpiry.HasValue && subscription.ConfirmationTokenExpiry < DateTime.UtcNow)
            {
                TempData["ErrorMessage"] = "This confirmation link has expired. Please subscribe again.";
                return RedirectToAction("Index", "Home");
            }

            if (subscription.IsActive && subscription.ConfirmedAt.HasValue)
            {
                TempData["InfoMessage"] = "Your subscription has already been confirmed.";
                return RedirectToAction("Index", "Home");
            }

            // Activate subscription
            subscription.IsActive = true;
            subscription.ConfirmedAt = DateTime.UtcNow;
            subscription.ConfirmationToken = null; // Clear token after use
            
            await _unitOfWork.SaveChangesAsync();

            // Send welcome email
            await _emailService.SendNewsletterWelcomeAsync(email);

            _logger.LogInformation("Newsletter subscription confirmed for {Email}", email);

            TempData["SuccessMessage"] = "Thank you! Your newsletter subscription has been confirmed. Check your inbox for a welcome email.";
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Unsubscribe from newsletter
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Unsubscribe(string token, string? email)
        {
            NewsletterSubscription? subscription = null;

            if (!string.IsNullOrEmpty(token))
            {
                subscription = await _unitOfWork.Repository<NewsletterSubscription>()
                    .FirstOrDefaultAsync(ns => ns.UnsubscribeToken == token);
            }
            else if (!string.IsNullOrEmpty(email))
            {
                subscription = await _unitOfWork.Repository<NewsletterSubscription>()
                    .FirstOrDefaultAsync(ns => ns.Email == email);
            }

            if (subscription == null)
            {
                TempData["ErrorMessage"] = "Subscription not found.";
                return RedirectToAction("Index", "Home");
            }

            if (!subscription.IsActive)
            {
                TempData["InfoMessage"] = "You have already been unsubscribed from our newsletter.";
                return RedirectToAction("Index", "Home");
            }

            // Deactivate subscription
            subscription.IsActive = false;
            subscription.UnsubscribedAt = DateTime.UtcNow;
            
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Newsletter unsubscribed for {Email}", subscription.Email);

            TempData["SuccessMessage"] = "You have been successfully unsubscribed from our newsletter.";
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Subscribe to newsletter (from footer form)
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(string email)
        {
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                return Json(new { success = false, message = "Please enter a valid email address." });
            }

            try
            {
                var existingSubscription = await _unitOfWork.Repository<NewsletterSubscription>()
                    .FirstOrDefaultAsync(ns => ns.Email == email);

                if (existingSubscription != null)
                {
                    if (existingSubscription.IsActive)
                    {
                        return Json(new { success = false, message = "This email is already subscribed to our newsletter." });
                    }

                    // Reactivate subscription
                    existingSubscription.ConfirmationToken = Guid.NewGuid().ToString("N");
                    existingSubscription.ConfirmationTokenExpiry = DateTime.UtcNow.AddHours(24);
                    existingSubscription.Source = "Footer";
                    await _unitOfWork.SaveChangesAsync();

                    var confirmationUrl = $"{GetBaseUrl()}/Newsletter/Confirm?token={existingSubscription.ConfirmationToken}&email={Uri.EscapeDataString(email)}";
                    await _emailService.SendNewsletterConfirmationAsync(email, confirmationUrl);

                    return Json(new { success = true, message = "Please check your email to confirm your subscription." });
                }

                // Create new subscription
                var subscription = new NewsletterSubscription
                {
                    Email = email,
                    IsActive = false,
                    SubscribedAt = DateTime.UtcNow,
                    UnsubscribeToken = Guid.NewGuid().ToString("N"),
                    ConfirmationToken = Guid.NewGuid().ToString("N"),
                    ConfirmationTokenExpiry = DateTime.UtcNow.AddHours(24),
                    Source = "Footer"
                };

                await _unitOfWork.Repository<NewsletterSubscription>().AddAsync(subscription);
                await _unitOfWork.SaveChangesAsync();

                var baseUrl = GetBaseUrl();
                var confirmUrl = $"{baseUrl}/Newsletter/Confirm?token={subscription.ConfirmationToken}&email={Uri.EscapeDataString(email)}";
                await _emailService.SendNewsletterConfirmationAsync(email, confirmUrl);

                _logger.LogInformation("New newsletter subscription created for {Email}", email);

                return Json(new { success = true, message = "Thank you! Please check your email to confirm your subscription." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing newsletter subscription for {Email}", email);
                return Json(new { success = false, message = "An error occurred. Please try again later." });
            }
        }

        private string GetBaseUrl()
        {
            return $"{Request.Scheme}://{Request.Host}";
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
