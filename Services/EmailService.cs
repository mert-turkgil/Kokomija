using System.Net;
using System.Net.Mail;

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
    }

    /// <summary>
    /// SMTP Email Service implementation
    /// Configured via appsettings.json (Development/Production)
    /// </summary>
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IConfiguration configuration, ILogger<EmailService> logger)
        {
            _configuration = configuration;
            _logger = logger;
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
