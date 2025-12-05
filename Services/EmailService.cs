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
        Task SendEmailWithAttachmentAsync(string to, string subject, string body, string attachmentPath, bool isHtml = true);
        Task SendBulkEmailAsync(List<string> recipients, string subject, string body, bool isHtml = true);
        Task<bool> SendOrderConfirmationAsync(string to, OrderEmailData orderData);
        Task<string> LoadEmailTemplate(string templateName);
        
        // Return Request emails
        Task SendReturnRequestConfirmationAsync(string userId, int returnRequestId);
        Task SendNewReturnRequestNotificationToAdminsAsync(int returnRequestId);
        Task SendReturnApprovedEmailAsync(string userId, int returnRequestId, string? customMessage);
        Task SendReturnRejectedEmailAsync(string userId, int returnRequestId, string? customMessage);
        
        // Developer earnings emails
        Task SendDeveloperEarningsSummaryAsync(string period, decimal amount);
        Task SendCommissionChangeAlertAsync(decimal oldRate, decimal newRate);
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

        private SmtpSettings GetSmtpSettings()
        {
            var settings = new SmtpSettings
            {
                Host = _configuration["Email:Smtp:Host"] ?? throw new InvalidOperationException("SMTP Host not configured"),
                Port = _configuration.GetValue<int>("Email:Smtp:Port"),
                EnableSsl = _configuration.GetValue<bool>("Email:Smtp:EnableSsl", true),
                Username = _configuration["Email:Smtp:Username"] ?? throw new InvalidOperationException("SMTP Username not configured"),
                Password = _configuration["Email:Smtp:Password"] ?? throw new InvalidOperationException("SMTP Password not configured"),
                FromEmail = _configuration["Email:Smtp:FromEmail"] ?? throw new InvalidOperationException("From Email not configured"),
                FromName = _configuration["Email:Smtp:FromName"] ?? "Kokomija",
                Timeout = _configuration.GetValue<int>("Email:Smtp:Timeout", 30000)
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

        public async Task SendDeveloperEarningsSummaryAsync(string period, decimal amount)
        {
            try
            {
                var rootEmail = _configuration["EmailSettings:SmtpUsername"];
                if (string.IsNullOrEmpty(rootEmail))
                    return;

                var subject = $"Developer Earnings Summary - {period}";
                var body = $@"
                    <h2>💰 Developer Earnings Summary</h2>
                    <p>Here is your earnings summary for <strong>{period}</strong>:</p>
                    <div style='background-color: #d4edda; padding: 20px; border: 2px solid #28a745; border-radius: 5px; text-align: center;'>
                        <div style='font-size: 36px; font-weight: bold; color: #28a745;'>{amount:C}</div>
                        <p style='margin-top: 10px; color: #6c757d;'>Total Developer Commission</p>
                    </div>
                    <p>This amount represents your commission from platform transactions during this period.</p>";

                await SendEmailAsync(rootEmail, subject, body, true);
                _logger.LogInformation("Developer earnings summary sent for period {Period}, amount {Amount}", period, amount);
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
                var rootEmail = _configuration["EmailSettings:SmtpUsername"];
                if (string.IsNullOrEmpty(rootEmail))
                    return;

                var subject = "⚠️ Commission Rate Change Detected";
                var change = newRate - oldRate;
                var changeSign = change > 0 ? "+" : "";
                var body = $@"
                    <h2>⚠️ Commission Rate Change Alert</h2>
                    <p>A change in the Stripe commission rate has been detected:</p>
                    <div style='background-color: #f8d7da; padding: 15px; border-left: 4px solid #dc3545;'>
                        <strong>Previous Rate:</strong> {oldRate}%<br>
                        <strong>New Rate:</strong> {newRate}%<br>
                        <strong>Change:</strong> {changeSign}{change}%<br>
                        <strong>Time:</strong> {DateTime.UtcNow:yyyy-MM-dd HH:mm} UTC
                    </div>
                    <p>Please review this change and update your commission settings if necessary.</p>";

                await SendEmailAsync(rootEmail, subject, body, true);
                _logger.LogInformation("Commission change alert sent: {OldRate}% -> {NewRate}%", oldRate, newRate);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending commission change alert");
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
