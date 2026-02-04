using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Kokomija.Data;

namespace Kokomija.Services
{
    /// <summary>
    /// Email service interface for sending emails via SMTP
    /// </summary>
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, bool isHtml = true);
        Task SendEmailAsync(string to, string subject, string body, string? replyTo, bool isHtml = true);
        Task SendEmailAsync(string to, string subject, string body, SmtpProviderType provider, bool isHtml = true);
        Task SendEmailWithAttachmentAsync(string to, string subject, string body, string attachmentPath, bool isHtml = true);
        Task SendBulkEmailAsync(List<string> recipients, string subject, string body, bool isHtml = true);
        Task<bool> SendOrderConfirmationAsync(string to, OrderEmailData orderData);
        Task<bool> SendOrderConfirmationAsync(string to, OrderEmailData orderData, string languageCode);
        Task<string> LoadEmailTemplate(string templateName);
        
        // Return Request emails
        Task SendReturnRequestConfirmationAsync(string userId, int returnRequestId);
        Task SendNewReturnRequestNotificationToAdminsAsync(int returnRequestId);
        Task SendReturnApprovedEmailAsync(string userId, int returnRequestId, string? customMessage);
        Task SendReturnRejectedEmailAsync(string userId, int returnRequestId, string? customMessage);
        
        // Developer earnings emails (uses DeveloperSmtp)
        Task SendDeveloperEarningsSummaryAsync(string period, decimal amount);
        Task SendCommissionChangeAlertAsync(decimal oldRate, decimal newRate);
        Task SendDeveloperAlertAsync(string subject, string message);
        
        // Account management emails
        Task SendPasswordResetAsync(string email, string resetUrl);
        Task SendPasswordResetAsync(string email, string resetUrl, string languageCode);
        Task SendEmailVerificationAsync(string email, string verificationUrl, string languageCode);
        Task SendPayoutFailureNotificationAsync(string adminEmail, string payoutId, string errorMessage);
        Task SendPayoutSuccessNotificationAsync(string adminEmail, string payoutId, decimal amount);
        
        // Newsletter emails
        Task SendNewsletterConfirmationAsync(string email, string confirmationUrl);
        Task SendNewsletterWelcomeAsync(string email);
        
        // Health check
        Task SendHealthCheckEmailAsync();
    }

    /// <summary>
    /// Order email data for template
    /// </summary>
    public class OrderEmailData
    {
        public string OrderNumber { get; set; } = string.Empty;
        public string OrderDate { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; } = string.Empty;
        public string OrderItemsHtml { get; set; } = string.Empty;
        public string TrackOrderUrl { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public string PrivacyUrl { get; set; } = string.Empty;
        public string ContactUrl { get; set; } = string.Empty;
    }

    /// <summary>
    /// SMTP Email Service implementation
    /// Configured via appsettings.json (Development/Production)
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger, IWebHostEnvironment environment, ApplicationDbContext context)
        {
            _configuration = configuration;
            _logger = logger;
            _environment = environment;
            _context = context;
        }

        public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            await SendEmailAsync(to, subject, body, null, isHtml);
        }

        public async Task SendEmailAsync(string to, string subject, string body, string? replyTo, bool isHtml = true)
        {
            try
            {
                var smtpSettings = GetSmtpSettings();

                using var client = new SmtpClient(smtpSettings.Host, smtpSettings.Port)
                {
                    EnableSsl = smtpSettings.EnableSsl,
                    Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password),
                    Timeout = smtpSettings.Timeout
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings.FromEmail, smtpSettings.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                mailMessage.To.Add(to);

                if (!string.IsNullOrEmpty(replyTo))
                {
                    mailMessage.ReplyToList.Add(replyTo);
                }

                await client.SendMailAsync(mailMessage);

                _logger.LogInformation("Email sent successfully to {Email} with subject: {Subject}", to, subject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {Email} with subject: {Subject}", to, subject);
                throw;
            }
        }

        public async Task SendEmailAsync(string to, string subject, string body, SmtpProviderType provider, bool isHtml = true)
        {
            try
            {
                var smtpSettings = GetSmtpSettings(provider);

                using var client = new SmtpClient(smtpSettings.Host, smtpSettings.Port)
                {
                    EnableSsl = smtpSettings.EnableSsl,
                    Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password),
                    Timeout = smtpSettings.Timeout
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings.FromEmail, smtpSettings.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                mailMessage.To.Add(to);

                await client.SendMailAsync(mailMessage);

                _logger.LogInformation("Email sent successfully via {Provider} to {Email} with subject: {Subject}", provider, to, subject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email via {Provider} to {Email} with subject: {Subject}", provider, to, subject);
                throw;
            }
        }

        public async Task SendEmailWithAttachmentAsync(string to, string subject, string body, string attachmentPath, bool isHtml = true)
        {
            try
            {
                var smtpSettings = GetSmtpSettings();

                using var client = new SmtpClient(smtpSettings.Host, smtpSettings.Port)
                {
                    EnableSsl = smtpSettings.EnableSsl,
                    Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password),
                    Timeout = smtpSettings.Timeout
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings.FromEmail, smtpSettings.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                mailMessage.To.Add(to);

                if (File.Exists(attachmentPath))
                {
                    var attachment = new Attachment(attachmentPath);
                    mailMessage.Attachments.Add(attachment);
                }
                else
                {
                    _logger.LogWarning("Attachment file not found: {AttachmentPath}", attachmentPath);
                }

                await client.SendMailAsync(mailMessage);

                _logger.LogInformation("Email with attachment sent successfully to {Email}", to);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email with attachment to {Email}", to);
                throw;
            }
        }

        public async Task SendBulkEmailAsync(List<string> recipients, string subject, string body, bool isHtml = true)
        {
            try
            {
                var smtpSettings = GetSmtpSettings();

                using var client = new SmtpClient(smtpSettings.Host, smtpSettings.Port)
                {
                    EnableSsl = smtpSettings.EnableSsl,
                    Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password),
                    Timeout = smtpSettings.Timeout
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings.FromEmail, smtpSettings.FromName),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isHtml
                };

                foreach (var recipient in recipients)
                {
                    mailMessage.Bcc.Add(recipient);
                }

                // Send to a dummy address (or first recipient) with all others in BCC
                mailMessage.To.Add(smtpSettings.FromEmail);

                await client.SendMailAsync(mailMessage);

                _logger.LogInformation("Bulk email sent successfully to {Count} recipients", recipients.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send bulk email to {Count} recipients", recipients.Count);
                throw;
            }
        }

        private SmtpSettings GetSmtpSettings(SmtpProviderType provider = SmtpProviderType.Customer)
        {
            var configSection = provider == SmtpProviderType.Developer ? "Email:DeveloperSmtp" : "Email:CustomerSmtp";
            
            var settings = new SmtpSettings
            {
                Host = _configuration[$"{configSection}:Host"] ?? throw new InvalidOperationException($"SMTP Host not configured for {provider}"),
                Port = _configuration.GetValue<int>($"{configSection}:Port"),
                EnableSsl = _configuration.GetValue<bool>($"{configSection}:EnableSsl", true),
                Username = _configuration[$"{configSection}:Username"] ?? throw new InvalidOperationException($"SMTP Username not configured for {provider}"),
                Password = _configuration[$"{configSection}:Password"] ?? throw new InvalidOperationException($"SMTP Password not configured for {provider}"),
                FromEmail = _configuration[$"{configSection}:FromEmail"] ?? throw new InvalidOperationException($"From Email not configured for {provider}"),
                FromName = _configuration[$"{configSection}:FromName"] ?? "Kokomija",
                Timeout = _configuration.GetValue<int>("Email:Timeout", 30000)
            };

            return settings;
        }

        public async Task<string> LoadEmailTemplate(string templateName)
        {
            try
            {
                var templatePath = Path.Combine(_environment.ContentRootPath, "Views", "EmailTemplates", $"{templateName}.html");
                
                if (!File.Exists(templatePath))
                {
                    _logger.LogError("Email template not found: {TemplatePath}", templatePath);
                    throw new FileNotFoundException($"Email template not found: {templateName}");
                }

                var template = await File.ReadAllTextAsync(templatePath);
                _logger.LogInformation("Email template loaded successfully: {TemplateName}", templateName);
                
                return template;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading email template: {TemplateName}", templateName);
                throw;
            }
        }

        public async Task<bool> SendOrderConfirmationAsync(string to, OrderEmailData orderData)
        {
            try
            {
                // Load the order confirmation template
                var template = await LoadEmailTemplate("OrderConfirmation");

                // Replace placeholders with actual data
                var emailBody = template
                    .Replace("{{ORDER_NUMBER}}", orderData.OrderNumber)
                    .Replace("{{ORDER_DATE}}", orderData.OrderDate)
                    .Replace("{{TOTAL_AMOUNT}}", orderData.TotalAmount.ToString("N2") + " PLN")
                    .Replace("{{SHIPPING_ADDRESS}}", orderData.ShippingAddress)
                    .Replace("{{ORDER_ITEMS}}", orderData.OrderItemsHtml)
                    .Replace("{{TRACK_ORDER_URL}}", orderData.TrackOrderUrl)
                    .Replace("{{WEBSITE_URL}}", orderData.WebsiteUrl)
                    .Replace("{{PRIVACY_URL}}", orderData.PrivacyUrl)
                    .Replace("{{CONTACT_URL}}", orderData.ContactUrl);

                // Send the email
                await SendEmailAsync(
                    to,
                    $"Potwierdzenie zamówienia #{orderData.OrderNumber} - Kokomija",
                    emailBody,
                    isHtml: true
                );

                _logger.LogInformation("Order confirmation email sent successfully to {Email} for order {OrderNumber}", 
                    to, orderData.OrderNumber);
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending order confirmation email to {Email} for order {OrderNumber}", 
                    to, orderData.OrderNumber);
                return false;
            }
        }

        public async Task<bool> SendOrderConfirmationAsync(string to, OrderEmailData orderData, string languageCode)
        {
            try
            {
                var lang = languageCode.ToLower().Contains("pl") ? "PL" : "EN";
                var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                
                // Load the localized order receipt template
                var template = await LoadEmailTemplate($"OrderReceipt_{lang}");

                // Build order items HTML
                var orderItemsHtml = orderData.OrderItemsHtml;

                // Get localized subject
                var subject = lang == "PL" 
                    ? $"Potwierdzenie zamówienia #{orderData.OrderNumber} - Kokomija"
                    : $"Order Confirmation #{orderData.OrderNumber} - Kokomija";

                // Replace placeholders with actual data
                var emailBody = template
                    .Replace("{{ORDER_NUMBER}}", orderData.OrderNumber)
                    .Replace("{{ORDER_DATE}}", orderData.OrderDate)
                    .Replace("{{TOTAL_AMOUNT}}", orderData.TotalAmount.ToString("N2") + " PLN")
                    .Replace("{{SUBTOTAL}}", orderData.TotalAmount.ToString("N2") + " PLN")
                    .Replace("{{SHIPPING_COST}}", "0.00 PLN")
                    .Replace("{{TAX_AMOUNT}}", "0.00 PLN")
                    .Replace("{{DISCOUNT_ROW}}", "")
                    .Replace("{{SHIPPING_ADDRESS}}", orderData.ShippingAddress)
                    .Replace("{{ORDER_ITEMS}}", orderItemsHtml)
                    .Replace("{{TRACK_ORDER_URL}}", orderData.TrackOrderUrl)
                    .Replace("{{WEBSITE_URL}}", orderData.WebsiteUrl)
                    .Replace("{{PRIVACY_URL}}", orderData.PrivacyUrl)
                    .Replace("{{CONTACT_URL}}", orderData.ContactUrl)
                    .Replace("{{LOGO_URL}}", $"{baseUrl}/img/logo_black.png")
                    .Replace("{{YEAR}}", DateTime.Now.Year.ToString());

                // Send the email via customer SMTP
                await SendEmailAsync(to, subject, emailBody, SmtpProviderType.Customer, isHtml: true);

                _logger.LogInformation("Localized order confirmation ({Lang}) sent to {Email} for order {OrderNumber}", 
                    lang, to, orderData.OrderNumber);
                
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending localized order confirmation to {Email} for order {OrderNumber}", 
                    to, orderData.OrderNumber);
                return false;
            }
        }

        public async Task SendReturnRequestConfirmationAsync(string userId, int returnRequestId)
        {
            try
            {
                var returnRequest = await _context.ReturnRequests
                    .Include(rr => rr.Order)
                    .Include(rr => rr.OrderItem)
                        .ThenInclude(oi => oi.ProductVariant)
                            .ThenInclude(pv => pv.Product)
                    .Include(rr => rr.User)
                    .FirstOrDefaultAsync(rr => rr.Id == returnRequestId);

                if (returnRequest == null || returnRequest.User == null)
                {
                    _logger.LogWarning("Return request {ReturnRequestId} not found for confirmation email", returnRequestId);
                    return;
                }

                var subject = $"Return Request #{returnRequest.Id} Received - Kokomija";
                var body = $@"
                    <h2>Return Request Received</h2>
                    <p>Dear {returnRequest.User.FirstName},</p>
                    <p>We have received your return request for the following item:</p>
                    <div style='background-color: #f8f9fa; padding: 15px; border-left: 4px solid #007bff; margin: 20px 0;'>
                        <strong>Order Number:</strong> {returnRequest.Order.OrderNumber}<br>
                        <strong>Product:</strong> {returnRequest.OrderItem.ProductVariant.Product.Name}<br>
                        <strong>Return Request ID:</strong> #{returnRequest.Id}<br>
                        <strong>Requested Amount:</strong> {returnRequest.RequestedAmount:C}<br>
                        <strong>Reason:</strong> {returnRequest.Reason}<br>
                        <strong>Status:</strong> Pending Review
                    </div>
                    <p>Our team will review your request within 1-2 business days. You will receive an email once your request has been reviewed.</p>
                    <p>If you have any questions, please contact our customer support.</p>
                    <p>Thank you for your patience.</p>";

                await SendEmailAsync(returnRequest.User.Email!, subject, body);
                _logger.LogInformation("Return request confirmation sent to {Email} for request {ReturnRequestId}", 
                    returnRequest.User.Email, returnRequestId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending return request confirmation for {ReturnRequestId}", returnRequestId);
            }
        }

        public async Task SendNewReturnRequestNotificationToAdminsAsync(int returnRequestId)
        {
            try
            {
                var returnRequest = await _context.ReturnRequests
                    .Include(rr => rr.Order)
                    .Include(rr => rr.OrderItem)
                        .ThenInclude(oi => oi.ProductVariant)
                            .ThenInclude(pv => pv.Product)
                    .Include(rr => rr.User)
                    .FirstOrDefaultAsync(rr => rr.Id == returnRequestId);

                if (returnRequest == null)
                {
                    _logger.LogWarning("Return request {ReturnRequestId} not found for admin notification", returnRequestId);
                    return;
                }

                // Get all admin and root users via UserRoles
                var adminRoleIds = await _context.Roles
                    .Where(r => r.Name == "Admin" || r.Name == "Root")
                    .Select(r => r.Id)
                    .ToListAsync();

                var adminUserIds = await _context.UserRoles
                    .Where(ur => adminRoleIds.Contains(ur.RoleId))
                    .Select(ur => ur.UserId)
                    .Distinct()
                    .ToListAsync();

                var admins = await _context.Users
                    .Where(u => adminUserIds.Contains(u.Id))
                    .ToListAsync();

                var subject = $"🔔 New Return Request #{returnRequest.Id} - Action Required";
                var body = $@"
                    <h2>New Return Request Received</h2>
                    <p>A new return request requires your review:</p>
                    <div style='background-color: #fff3cd; padding: 15px; border-left: 4px solid #ffc107; margin: 20px 0;'>
                        <strong>Return Request ID:</strong> #{returnRequest.Id}<br>
                        <strong>Customer:</strong> {returnRequest.User.FirstName} {returnRequest.User.LastName} ({returnRequest.User.Email})<br>
                        <strong>Order Number:</strong> {returnRequest.Order.OrderNumber}<br>
                        <strong>Product:</strong> {returnRequest.OrderItem.ProductVariant.Product.Name}<br>
                        <strong>Requested Amount:</strong> {returnRequest.RequestedAmount:C}<br>
                        <strong>Reason:</strong> {returnRequest.Reason}<br>
                        <strong>Description:</strong> {returnRequest.Description ?? "N/A"}<br>
                        <strong>Submitted:</strong> {returnRequest.RequestedAt:yyyy-MM-dd HH:mm} UTC
                    </div>
                    <p><a href='{_configuration["AppUrl"]}/Admin/ReturnRequests' style='background-color: #007bff; color: white; padding: 10px 20px; text-decoration: none; border-radius: 5px; display: inline-block;'>Review Request</a></p>";

                foreach (var admin in admins)
                {
                    await SendEmailAsync(admin.Email!, subject, body);
                }

                _logger.LogInformation("Return request notification sent to {AdminCount} admins for request {ReturnRequestId}", 
                    admins.Count, returnRequestId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending admin notification for return request {ReturnRequestId}", returnRequestId);
            }
        }

        public async Task SendReturnApprovedEmailAsync(string userId, int returnRequestId, string? customMessage)
        {
            try
            {
                var returnRequest = await _context.ReturnRequests
                    .Include(rr => rr.Order)
                    .Include(rr => rr.OrderItem)
                        .ThenInclude(oi => oi.ProductVariant)
                            .ThenInclude(pv => pv.Product)
                    .Include(rr => rr.User)
                    .FirstOrDefaultAsync(rr => rr.Id == returnRequestId);

                if (returnRequest == null || returnRequest.User == null)
                {
                    _logger.LogWarning("Return request {ReturnRequestId} not found for approval email", returnRequestId);
                    return;
                }

                var subject = $"✅ Return Request #{returnRequest.Id} Approved - Kokomija";
                var customMessageHtml = !string.IsNullOrEmpty(customMessage) 
                    ? $"<div style='background-color: #e7f3ff; padding: 15px; border-left: 4px solid #0056b3; margin: 20px 0;'><strong>Message from our team:</strong><br>{customMessage}</div>" 
                    : "";

                var body = $@"
                    <h2>✅ Return Request Approved</h2>
                    <p>Dear {returnRequest.User.FirstName},</p>
                    <p>Great news! Your return request has been approved.</p>
                    <div style='background-color: #d4edda; padding: 15px; border-left: 4px solid #28a745; margin: 20px 0;'>
                        <strong>Return Request ID:</strong> #{returnRequest.Id}<br>
                        <strong>Order Number:</strong> {returnRequest.Order.OrderNumber}<br>
                        <strong>Product:</strong> {returnRequest.OrderItem.ProductVariant.Product.Name}<br>
                        <strong>Refund Amount:</strong> {returnRequest.RefundedAmount:C}<br>
                        <strong>Stripe Refund ID:</strong> {returnRequest.StripeRefundId}
                    </div>
                    {customMessageHtml}
                    <p>The refund will be processed to your original payment method within 5-10 business days.</p>
                    <p>Thank you for shopping with Kokomija!</p>";

                await SendEmailAsync(returnRequest.User.Email!, subject, body);
                _logger.LogInformation("Return approved email sent to {Email} for request {ReturnRequestId}", 
                    returnRequest.User.Email, returnRequestId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending return approved email for {ReturnRequestId}", returnRequestId);
            }
        }

        public async Task SendReturnRejectedEmailAsync(string userId, int returnRequestId, string? customMessage)
        {
            try
            {
                var returnRequest = await _context.ReturnRequests
                    .Include(rr => rr.Order)
                    .Include(rr => rr.OrderItem)
                        .ThenInclude(oi => oi.ProductVariant)
                            .ThenInclude(pv => pv.Product)
                    .Include(rr => rr.User)
                    .FirstOrDefaultAsync(rr => rr.Id == returnRequestId);

                if (returnRequest == null || returnRequest.User == null)
                {
                    _logger.LogWarning("Return request {ReturnRequestId} not found for rejection email", returnRequestId);
                    return;
                }

                var subject = $"Return Request #{returnRequest.Id} - Update - Kokomija";
                var reasonHtml = !string.IsNullOrEmpty(customMessage) 
                    ? $"<p><strong>Reason:</strong> {customMessage}</p>" 
                    : "";

                var body = $@"
                    <h2>Return Request Update</h2>
                    <p>Dear {returnRequest.User.FirstName},</p>
                    <p>We have reviewed your return request for the following item:</p>
                    <div style='background-color: #f8d7da; padding: 15px; border-left: 4px solid #dc3545; margin: 20px 0;'>
                        <strong>Return Request ID:</strong> #{returnRequest.Id}<br>
                        <strong>Order Number:</strong> {returnRequest.Order.OrderNumber}<br>
                        <strong>Product:</strong> {returnRequest.OrderItem.ProductVariant.Product.Name}<br>
                        <strong>Status:</strong> Not Approved
                    </div>
                    {reasonHtml}
                    <p>If you have any questions or concerns, please contact our customer support team.</p>
                    <p>We appreciate your understanding.</p>";

                await SendEmailAsync(returnRequest.User.Email!, subject, body);
                _logger.LogInformation("Return rejected email sent to {Email} for request {ReturnRequestId}", 
                    returnRequest.User.Email, returnRequestId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending return rejected email for {ReturnRequestId}", returnRequestId);
            }
        }

        // SendDeveloperEarningsSummaryAsync and SendCommissionChangeAlertAsync are now defined at the end of the file
        // with dual SMTP provider support

        // SendPasswordResetAsync, SendPayoutFailureNotificationAsync, and SendPayoutSuccessNotificationAsync  
        // are now defined at the end of the file with template-based emails and dual SMTP provider support

        public async Task SendNewsletterConfirmationAsync(string email, string confirmationUrl)
        {
            try
            {
                var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                var subject = "📬 Potwierdź subskrypcję newslettera Kokomija | Confirm your Newsletter Subscription";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; background-color: #ffffff;'>
                        <div style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); padding: 30px; text-align: center;'>
                            <img src='{baseUrl}/img/logo_white.png' alt='Kokomija' style='height: 50px; margin-bottom: 15px;' />
                            <h1 style='color: white; margin: 0; font-size: 24px;'>Welcome to Kokomija Newsletter!</h1>
                        </div>
                        
                        <div style='padding: 30px;'>
                            <p style='font-size: 16px; color: #334155; line-height: 1.6;'>
                                Thank you for subscribing to our newsletter! 
                                Click the button below to confirm your subscription and start receiving exclusive updates, promotions, and new arrivals.
                            </p>
                            
                            <p style='font-size: 16px; color: #334155; line-height: 1.6;'>
                                Dziękujemy za subskrypcję naszego newslettera! 
                                Kliknij poniższy przycisk, aby potwierdzić subskrypcję i zacząć otrzymywać ekskluzywne aktualizacje, promocje i nowości.
                            </p>
                            
                            <div style='text-align: center; margin: 30px 0;'>
                                <a href='{confirmationUrl}' style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 15px 40px; text-decoration: none; border-radius: 8px; display: inline-block; font-weight: bold; font-size: 16px;'>
                                    ✉️ Confirm Subscription / Potwierdź Subskrypcję
                                </a>
                            </div>
                            
                            <p style='font-size: 14px; color: #64748b; line-height: 1.6;'>
                                If you didn't request this subscription, please ignore this email.<br/>
                                Jeśli nie prosiłeś o tę subskrypcję, zignoruj tę wiadomość.
                            </p>
                            
                            <hr style='border: none; border-top: 1px solid #e2e8f0; margin: 20px 0;' />
                            
                            <p style='font-size: 12px; color: #94a3b8; text-align: center;'>
                                This link will expire in 24 hours. | Ten link wygaśnie za 24 godziny.
                            </p>
                        </div>
                        
                        <div style='background-color: #f8fafc; padding: 20px; text-align: center;'>
                            <p style='font-size: 12px; color: #64748b; margin: 0;'>
                                © {DateTime.Now.Year} Kokomija. All rights reserved.
                            </p>
                        </div>
                    </div>";

                await SendEmailAsync(email, subject, body, true);
                _logger.LogInformation("Newsletter confirmation email sent to {Email}", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending newsletter confirmation email to {Email}", email);
            }
        }

        public async Task SendNewsletterWelcomeAsync(string email)
        {
            try
            {
                var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                var subject = "🎉 Witamy w newsletterze Kokomija! | Welcome to Kokomija Newsletter!";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto; background-color: #ffffff;'>
                        <div style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); padding: 30px; text-align: center;'>
                            <img src='{baseUrl}/img/logo_white.png' alt='Kokomija' style='height: 50px; margin-bottom: 15px;' />
                            <h1 style='color: white; margin: 0; font-size: 24px;'>🎉 Subscription Confirmed!</h1>
                        </div>
                        
                        <div style='padding: 30px;'>
                            <p style='font-size: 16px; color: #334155; line-height: 1.6;'>
                                Your subscription has been confirmed! You will now receive:
                            </p>
                            
                            <ul style='font-size: 16px; color: #334155; line-height: 1.8;'>
                                <li>🆕 New product announcements</li>
                                <li>💰 Exclusive discounts and promotions</li>
                                <li>✨ Early access to sales</li>
                                <li>📚 Fashion tips and trends</li>
                            </ul>
                            
                            <p style='font-size: 16px; color: #334155; line-height: 1.6;'>
                                Twoja subskrypcja została potwierdzona! Od teraz będziesz otrzymywać:
                            </p>
                            
                            <ul style='font-size: 16px; color: #334155; line-height: 1.8;'>
                                <li>🆕 Informacje o nowych produktach</li>
                                <li>💰 Ekskluzywne rabaty i promocje</li>
                                <li>✨ Wcześniejszy dostęp do wyprzedaży</li>
                                <li>📚 Porady modowe i trendy</li>
                            </ul>
                            
                            <div style='text-align: center; margin: 30px 0;'>
                                <a href='{baseUrl}/Product' style='background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; padding: 15px 40px; text-decoration: none; border-radius: 8px; display: inline-block; font-weight: bold; font-size: 16px;'>
                                    🛍️ Start Shopping / Zacznij Zakupy
                                </a>
                            </div>
                        </div>
                        
                        <div style='background-color: #f8fafc; padding: 20px; text-align: center;'>
                            <p style='font-size: 12px; color: #64748b; margin: 0;'>
                                © {DateTime.Now.Year} Kokomija. All rights reserved.<br/>
                                <a href='{baseUrl}/Newsletter/Unsubscribe' style='color: #64748b;'>Unsubscribe / Wypisz się</a>
                            </p>
                        </div>
                    </div>";

                await SendEmailAsync(email, subject, body, true);
                _logger.LogInformation("Newsletter welcome email sent to {Email}", email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending newsletter welcome email to {Email}", email);
            }
        }

        public async Task SendPasswordResetAsync(string email, string resetUrl)
        {
            await SendPasswordResetAsync(email, resetUrl, "en");
        }

        public async Task SendPasswordResetAsync(string email, string resetUrl, string languageCode)
        {
            try
            {
                var lang = languageCode.ToLower().Contains("pl") ? "PL" : "EN";
                var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                
                var template = await LoadEmailTemplate($"PasswordReset_{lang}");
                
                var subject = lang == "PL" 
                    ? "🔐 Resetowanie hasła - Kokomija"
                    : "🔐 Password Reset - Kokomija";

                var emailBody = template
                    .Replace("{{RESET_URL}}", resetUrl)
                    .Replace("{{WEBSITE_URL}}", baseUrl)
                    .Replace("{{PRIVACY_URL}}", $"{baseUrl}/Privacy")
                    .Replace("{{LOGO_URL}}", $"{baseUrl}/img/logo_black.png")
                    .Replace("{{YEAR}}", DateTime.Now.Year.ToString());

                await SendEmailAsync(email, subject, emailBody, SmtpProviderType.Customer, isHtml: true);
                _logger.LogInformation("Password reset email ({Lang}) sent to {Email}", lang, email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending password reset email to {Email}", email);
                throw;
            }
        }

        public async Task SendEmailVerificationAsync(string email, string verificationUrl, string languageCode)
        {
            try
            {
                var lang = languageCode.ToLower().Contains("pl") ? "PL" : "EN";
                var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "https://kokomija.pl";
                
                var template = await LoadEmailTemplate($"EmailVerification_{lang}");
                
                var subject = lang == "PL" 
                    ? "✉️ Potwierdź swój adres email - Kokomija"
                    : "✉️ Verify Your Email - Kokomija";

                var emailBody = template
                    .Replace("{{VERIFICATION_URL}}", verificationUrl)
                    .Replace("{{WEBSITE_URL}}", baseUrl)
                    .Replace("{{PRIVACY_URL}}", $"{baseUrl}/Privacy")
                    .Replace("{{LOGO_URL}}", $"{baseUrl}/img/logo_black.png")
                    .Replace("{{YEAR}}", DateTime.Now.Year.ToString());

                await SendEmailAsync(email, subject, emailBody, SmtpProviderType.Customer, isHtml: true);
                _logger.LogInformation("Email verification ({Lang}) sent to {Email}", lang, email);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email verification to {Email}", email);
                throw;
            }
        }

        public async Task SendDeveloperEarningsSummaryAsync(string period, decimal amount)
        {
            try
            {
                var developerEmail = _configuration["Email:DeveloperSmtp:FromEmail"] ?? "notrespond@kokomija.com";
                var subject = $"💰 Developer Earnings Summary - {period}";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #10b981;'>💰 Earnings Summary</h2>
                        <p><strong>Period:</strong> {period}</p>
                        <p><strong>Total Earnings:</strong> {amount:N2} PLN</p>
                        <hr style='border: 1px solid #e2e8f0;'>
                        <p style='color: #64748b; font-size: 12px;'>This is an automated message from Kokomija system.</p>
                    </div>";

                await SendEmailAsync(developerEmail, subject, body, SmtpProviderType.Developer, isHtml: true);
                _logger.LogInformation("Developer earnings summary sent for period {Period}", period);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending developer earnings summary");
            }
        }

        public async Task SendCommissionChangeAlertAsync(decimal oldRate, decimal newRate)
        {
            try
            {
                var developerEmail = _configuration["Email:DeveloperSmtp:FromEmail"] ?? "notrespond@kokomija.com";
                var subject = "⚠️ Commission Rate Changed - Kokomija";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #f59e0b;'>⚠️ Commission Rate Alert</h2>
                        <p>The commission rate has been changed:</p>
                        <p><strong>Previous Rate:</strong> {oldRate:P2}</p>
                        <p><strong>New Rate:</strong> {newRate:P2}</p>
                        <hr style='border: 1px solid #e2e8f0;'>
                        <p style='color: #64748b; font-size: 12px;'>Changed at: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>
                    </div>";

                await SendEmailAsync(developerEmail, subject, body, SmtpProviderType.Developer, isHtml: true);
                _logger.LogInformation("Commission change alert sent: {OldRate} -> {NewRate}", oldRate, newRate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending commission change alert");
            }
        }

        public async Task SendDeveloperAlertAsync(string subject, string message)
        {
            try
            {
                var developerEmail = _configuration["Email:DeveloperSmtp:FromEmail"] ?? "notrespond@kokomija.com";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #ef4444;'>🚨 Kokomija Alert</h2>
                        <div style='background-color: #fef2f2; padding: 20px; border-radius: 8px; border-left: 4px solid #ef4444;'>
                            {message}
                        </div>
                        <hr style='border: 1px solid #e2e8f0;'>
                        <p style='color: #64748b; font-size: 12px;'>Alert generated at: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>
                    </div>";

                await SendEmailAsync(developerEmail, subject, body, SmtpProviderType.Developer, isHtml: true);
                _logger.LogInformation("Developer alert sent: {Subject}", subject);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending developer alert: {Subject}", subject);
            }
        }

        public async Task SendPayoutFailureNotificationAsync(string adminEmail, string payoutId, string errorMessage)
        {
            try
            {
                var subject = $"❌ Payout Failed - {payoutId}";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #ef4444;'>❌ Payout Failed</h2>
                        <p><strong>Payout ID:</strong> {payoutId}</p>
                        <p><strong>Error:</strong> {errorMessage}</p>
                        <hr style='border: 1px solid #e2e8f0;'>
                        <p style='color: #64748b; font-size: 12px;'>Failure time: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>
                    </div>";

                await SendEmailAsync(adminEmail, subject, body, SmtpProviderType.Developer, isHtml: true);
                _logger.LogInformation("Payout failure notification sent for {PayoutId}", payoutId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending payout failure notification for {PayoutId}", payoutId);
            }
        }

        public async Task SendPayoutSuccessNotificationAsync(string adminEmail, string payoutId, decimal amount)
        {
            try
            {
                var subject = $"✅ Payout Successful - {payoutId}";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <h2 style='color: #10b981;'>✅ Payout Successful</h2>
                        <p><strong>Payout ID:</strong> {payoutId}</p>
                        <p><strong>Amount:</strong> {amount:N2} PLN</p>
                        <hr style='border: 1px solid #e2e8f0;'>
                        <p style='color: #64748b; font-size: 12px;'>Processed at: {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</p>
                    </div>";

                await SendEmailAsync(adminEmail, subject, body, SmtpProviderType.Developer, isHtml: true);
                _logger.LogInformation("Payout success notification sent for {PayoutId}", payoutId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending payout success notification for {PayoutId}", payoutId);
            }
        }

        public async Task SendHealthCheckEmailAsync()
        {
            try
            {
                var developerEmail = _configuration["Email:HealthCheck:RecipientEmail"] ?? "notrespond@kokomija.com";
                var subject = "✅ Kokomija Email System Health Check";
                var body = $@"
                    <div style='font-family: Arial, sans-serif; max-width: 600px; margin: 0 auto;'>
                        <div style='background: linear-gradient(135deg, #10b981 0%, #059669 100%); padding: 30px; text-align: center; border-radius: 8px 8px 0 0;'>
                            <h1 style='color: white; margin: 0;'>✅ System Health Check</h1>
                        </div>
                        <div style='padding: 30px; background-color: #f8fafc;'>
                            <h2 style='color: #1e293b;'>Email System Status: Operational</h2>
                            <table style='width: 100%; border-collapse: collapse;'>
                                <tr>
                                    <td style='padding: 10px; border-bottom: 1px solid #e2e8f0;'><strong>Check Time:</strong></td>
                                    <td style='padding: 10px; border-bottom: 1px solid #e2e8f0;'>{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} UTC</td>
                                </tr>
                                <tr>
                                    <td style='padding: 10px; border-bottom: 1px solid #e2e8f0;'><strong>Customer SMTP:</strong></td>
                                    <td style='padding: 10px; border-bottom: 1px solid #e2e8f0;'>✅ Connected</td>
                                </tr>
                                <tr>
                                    <td style='padding: 10px; border-bottom: 1px solid #e2e8f0;'><strong>Developer SMTP:</strong></td>
                                    <td style='padding: 10px; border-bottom: 1px solid #e2e8f0;'>✅ Connected</td>
                                </tr>
                                <tr>
                                    <td style='padding: 10px;'><strong>Next Check:</strong></td>
                                    <td style='padding: 10px;'>In 30 days</td>
                                </tr>
                            </table>
                        </div>
                        <div style='padding: 20px; text-align: center; background-color: #e2e8f0; border-radius: 0 0 8px 8px;'>
                            <p style='margin: 0; color: #64748b; font-size: 12px;'>
                                This is an automated health check from the Kokomija email system.
                            </p>
                        </div>
                    </div>";

                await SendEmailAsync(developerEmail, subject, body, SmtpProviderType.Developer, isHtml: true);
                _logger.LogInformation("Health check email sent successfully at {Time}", DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending health check email");
                throw;
            }
        }

        private class SmtpSettings
        {
            public string Host { get; set; } = string.Empty;
            public int Port { get; set; }
            public bool EnableSsl { get; set; }
            public string Username { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
            public string FromEmail { get; set; } = string.Empty;
            public string FromName { get; set; } = string.Empty;
            public int Timeout { get; set; }
        }
    }
}
