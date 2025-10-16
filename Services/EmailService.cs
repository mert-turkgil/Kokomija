using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Hosting;

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

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _logger = logger;
            _environment = environment;
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
