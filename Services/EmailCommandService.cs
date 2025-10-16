using Kokomija.Data.Abstract;
using Kokomija.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Kokomija.Services
{
    public interface IEmailCommandService
    {
        Task<bool> ProcessEmailCommandAsync(string senderEmail, string subject, string body);
        Task<EmailCommand?> ParseEmailCommandAsync(string senderEmail, string subject, string body);
        Task<bool> ExecuteCommandAsync(int commandId);
        Task<bool> IsAuthorizedSenderAsync(string email);
    }

    public class EmailCommandService : IEmailCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISiteControlService _siteControlService;
        private readonly IAdminCommissionService _commissionService;
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailCommandService> _logger;

        public EmailCommandService(
            IUnitOfWork unitOfWork,
            ISiteControlService siteControlService,
            IAdminCommissionService commissionService,
            IEmailService emailService,
            ILogger<EmailCommandService> logger)
        {
            _unitOfWork = unitOfWork;
            _siteControlService = siteControlService;
            _commissionService = commissionService;
            _emailService = emailService;
            _logger = logger;
        }

        /// <summary>
        /// Process incoming email command
        /// </summary>
        public async Task<bool> ProcessEmailCommandAsync(string senderEmail, string subject, string body)
        {
            try
            {
                var command = await ParseEmailCommandAsync(senderEmail, subject, body);
                if (command == null)
                {
                    _logger.LogWarning("Failed to parse email command from {Sender}", senderEmail);
                    return false;
                }

                await _unitOfWork.EmailCommands.AddAsync(command);
                await _unitOfWork.SaveChangesAsync();

                // Execute command if authorized
                if (command.IsAuthorized)
                {
                    return await ExecuteCommandAsync(command.Id);
                }
                else
                {
                    // Send authorization email
                    await SendAuthorizationEmailAsync(command);
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing email command from {Sender}", senderEmail);
                return false;
            }
        }

        /// <summary>
        /// Parse email to extract command
        /// </summary>
        public async Task<EmailCommand?> ParseEmailCommandAsync(string senderEmail, string subject, string body)
        {
            var isAuthorized = await IsAuthorizedSenderAsync(senderEmail);
            
            var command = new EmailCommand
            {
                SenderEmail = senderEmail,
                Subject = subject,
                Body = body,
                IsAuthorized = isAuthorized,
                ReceivedAt = DateTime.UtcNow,
                Status = "pending"
            };

            // Parse command type from subject or body
            var normalizedSubject = subject?.ToLower() ?? "";
            var normalizedBody = body?.ToLower() ?? "";

            // Command: Change commission rate
            if (normalizedSubject.Contains("change rate") || normalizedSubject.Contains("zmień stawkę") ||
                normalizedBody.Contains("change commission") || normalizedBody.Contains("zmień prowizję"))
            {
                command.CommandType = "change_rate";
                var newRate = ExtractCommissionRate(body ?? string.Empty);
                if (newRate.HasValue)
                {
                    command.CommandParameters = JsonSerializer.Serialize(new { rate = newRate.Value });
                }
            }
            // Command: Close site
            else if (normalizedSubject.Contains("close site") || normalizedSubject.Contains("zamknij stronę") ||
                     normalizedSubject.Contains("emergency") || normalizedSubject.Contains("awaria"))
            {
                command.CommandType = "close_site";
                var reason = ExtractClosureReason(body ?? string.Empty) ?? "Emergency closure via email";
                command.CommandParameters = JsonSerializer.Serialize(new { reason = reason });
            }
            // Command: Reopen site
            else if (normalizedSubject.Contains("reopen") || normalizedSubject.Contains("otwórz stronę") ||
                     normalizedSubject.Contains("open site") || normalizedSubject.Contains("resume"))
            {
                command.CommandType = "reopen_site";
                var password = ExtractPassword(body ?? string.Empty);
                command.CommandParameters = JsonSerializer.Serialize(new { password = password });
            }
            // Command: Confirm reopen (from daily email)
            else if (normalizedSubject.Contains("confirm") || normalizedSubject.Contains("potwierdzam"))
            {
                command.CommandType = "confirm_reopen";
            }
            else
            {
                _logger.LogWarning("Unknown command type in email from {Sender}: {Subject}", senderEmail, subject);
                return null;
            }

            return command;
        }

        /// <summary>
        /// Execute a parsed command
        /// </summary>
        public async Task<bool> ExecuteCommandAsync(int commandId)
        {
            try
            {
                var command = await _unitOfWork.EmailCommands.GetByIdAsync(commandId);
                if (command == null)
                {
                    _logger.LogError("Command {CommandId} not found", commandId);
                    return false;
                }

                if (!command.IsAuthorized)
                {
                    command.Status = "rejected";
                    command.ErrorMessage = "Sender not authorized";
                    await _unitOfWork.SaveChangesAsync();
                    return false;
                }

                if (command.IsExecuted)
                {
                    _logger.LogWarning("Command {CommandId} already executed", commandId);
                    return false;
                }

                bool success = false;
                string result = "";

                switch (command.CommandType)
                {
                    case "change_rate":
                        (success, result) = await ExecuteChangeRateCommandAsync(command);
                        break;

                    case "close_site":
                        (success, result) = await ExecuteCloseSiteCommandAsync(command);
                        break;

                    case "reopen_site":
                        (success, result) = await ExecuteReopenSiteCommandAsync(command);
                        break;

                    case "confirm_reopen":
                        (success, result) = await ExecuteConfirmReopenCommandAsync(command);
                        break;

                    default:
                        result = $"Unknown command type: {command.CommandType}";
                        break;
                }

                command.IsExecuted = success;
                command.ExecutedAt = DateTime.UtcNow;
                command.Status = success ? "executed" : "failed";
                command.ExecutionResult = result;

                if (!success && string.IsNullOrEmpty(command.ErrorMessage))
                {
                    command.ErrorMessage = result;
                }

                await _unitOfWork.SaveChangesAsync();

                // Send confirmation email
                await SendExecutionConfirmationEmailAsync(command, success, result);

                return success;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error executing command {CommandId}", commandId);
                return false;
            }
        }

        /// <summary>
        /// Check if sender is authorized (super admin)
        /// </summary>
        public async Task<bool> IsAuthorizedSenderAsync(string email)
        {
            var superAdminEmail = await GetSuperAdminEmailAsync();
            return email.Equals(superAdminEmail, StringComparison.OrdinalIgnoreCase);
        }

        private async Task<(bool success, string result)> ExecuteChangeRateCommandAsync(EmailCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(command.CommandParameters))
                {
                    return (false, "No rate specified");
                }

                var parameters = JsonSerializer.Deserialize<Dictionary<string, decimal>>(command.CommandParameters);
                if (parameters == null || !parameters.TryGetValue("rate", out decimal newRate))
                {
                    return (false, "Invalid rate parameter");
                }

                if (newRate < 0 || newRate > 1)
                {
                    return (false, "Rate must be between 0 and 1 (0% to 100%)");
                }

                var success = await _commissionService.UpdateCommissionRateAsync(newRate, command.SenderEmail);
                if (success)
                {
                    _logger.LogInformation("Commission rate changed to {Rate}% via email command by {Sender}",
                        newRate * 100, command.SenderEmail);
                    return (true, $"Commission rate updated to {newRate * 100}%");
                }
                else
                {
                    return (false, "Failed to update commission rate");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        private async Task<(bool success, string result)> ExecuteCloseSiteCommandAsync(EmailCommand command)
        {
            try
            {
                var parameters = string.IsNullOrEmpty(command.CommandParameters)
                    ? null
                    : JsonSerializer.Deserialize<Dictionary<string, string>>(command.CommandParameters);

                var reason = parameters?.GetValueOrDefault("reason") ?? "Emergency closure via email";

                var success = await _siteControlService.CloseSiteAsync(reason, command.SenderEmail);
                if (success)
                {
                    _logger.LogCritical("Site closed via email command by {Sender}. Reason: {Reason}",
                        command.SenderEmail, reason);
                    return (true, "Site closed successfully. Scheduled to reopen in 30 days.");
                }
                else
                {
                    return (false, "Failed to close site (may already be closed)");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        private async Task<(bool success, string result)> ExecuteReopenSiteCommandAsync(EmailCommand command)
        {
            try
            {
                var parameters = string.IsNullOrEmpty(command.CommandParameters)
                    ? null
                    : JsonSerializer.Deserialize<Dictionary<string, string>>(command.CommandParameters);

                var password = parameters?.GetValueOrDefault("password");

                // Verify password if provided
                if (!string.IsNullOrEmpty(password))
                {
                    var passwordValid = await _siteControlService.VerifyEmergencyPasswordAsync(password);
                    if (!passwordValid)
                    {
                        return (false, "Invalid emergency password");
                    }
                }

                var success = await _siteControlService.ReopenSiteAsync(command.SenderEmail, "email");
                if (success)
                {
                    _logger.LogInformation("Site reopened via email command by {Sender}", command.SenderEmail);
                    return (true, "Site reopened successfully");
                }
                else
                {
                    return (false, "Failed to reopen site (may not be closed)");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        private async Task<(bool success, string result)> ExecuteConfirmReopenCommandAsync(EmailCommand command)
        {
            var success = await _siteControlService.ReopenSiteAsync(command.SenderEmail, "email_confirmation");
            if (success)
            {
                return (true, "Site reopened via confirmation");
            }
            else
            {
                return (false, "Failed to reopen site");
            }
        }

        private async Task SendAuthorizationEmailAsync(EmailCommand command)
        {
            var token = Guid.NewGuid().ToString("N");
            command.AuthorizationToken = token;
            command.TokenExpiresAt = DateTime.UtcNow.AddHours(24);
            await _unitOfWork.SaveChangesAsync();

            var authUrl = $"YOUR_APP_URL/admin/email-command/authorize?token={token}";

            var emailBody = $@"
                <h2>Kokomija - Autoryzacja komendy email</h2>
                <p>Otrzymaliśmy komendę od nieautoryzowanego adresu email.</p>
                <p>Od: <strong>{command.SenderEmail}</strong></p>
                <p>Komenda: <strong>{command.CommandType}</strong></p>
                <p>Otrzymana: <strong>{command.ReceivedAt:dd.MM.yyyy HH:mm}</strong></p>
                
                <p>Jeśli to Ty, kliknij poniższy link aby autoryzować:</p>
                <p><a href=""{authUrl}"">Autoryzuj komendę</a></p>
                
                <p>Link wygasa za 24 godziny.</p>
            ";

            var superAdminEmail = await GetSuperAdminEmailAsync();
            await _emailService.SendEmailAsync(superAdminEmail, "Kokomija - Autoryzacja komendy", emailBody, isHtml: true);
        }

        private async Task SendExecutionConfirmationEmailAsync(EmailCommand command, bool success, string result)
        {
            var statusEmoji = success ? "✅" : "❌";
            var statusText = success ? "Wykonana pomyślnie" : "Nie powiodła się";

            var emailBody = $@"
                <h2>{statusEmoji} Kokomija - Wynik wykonania komendy</h2>
                <p>Komenda: <strong>{command.CommandType}</strong></p>
                <p>Status: <strong>{statusText}</strong></p>
                <p>Wynik: <strong>{result}</strong></p>
                <p>Wykonana: <strong>{DateTime.UtcNow:dd.MM.yyyy HH:mm}</strong></p>
            ";

            await _emailService.SendEmailAsync(command.SenderEmail, $"{statusEmoji} Kokomija - Komenda {statusText}", emailBody, isHtml: true);
        }

        private async Task<string> GetSuperAdminEmailAsync()
        {
            var allSettings = await _unitOfWork.SiteSettings.GetAllAsync();
            var setting = allSettings.FirstOrDefault(s => s.Key == "SuperAdminEmail");

            return setting?.Value ?? "admin@kokomija.com";
        }

        private decimal? ExtractCommissionRate(string text)
        {
            // Try to extract percentage like "2%" or "0.02" or "2.5%"
            var match = Regex.Match(text, @"(\d+\.?\d*)\s*%");
            if (match.Success && decimal.TryParse(match.Groups[1].Value, out decimal percentage))
            {
                return percentage / 100; // Convert to decimal (2% = 0.02)
            }

            // Try decimal format like "0.02"
            match = Regex.Match(text, @"(0\.\d+)");
            if (match.Success && decimal.TryParse(match.Groups[1].Value, out decimal rate))
            {
                return rate;
            }

            return null;
        }

        private string? ExtractClosureReason(string text)
        {
            // Try to extract reason after keywords
            var match = Regex.Match(text, @"reason:\s*(.+?)(?:\n|$)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            match = Regex.Match(text, @"powód:\s*(.+?)(?:\n|$)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value.Trim();
            }

            return null;
        }

        private string? ExtractPassword(string text)
        {
            // Try to extract password
            var match = Regex.Match(text, @"password:\s*(\S+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            match = Regex.Match(text, @"hasło:\s*(\S+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }

            return null;
        }
    }
}
