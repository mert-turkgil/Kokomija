namespace Kokomija.Services
{
    /// <summary>
    /// SMTP provider types for dual email configuration
    /// </summary>
    public enum SmtpProviderType
    {
        /// <summary>
        /// Customer-facing emails (orders, password reset, verification)
        /// </summary>
        Customer,
        
        /// <summary>
        /// Developer-exclusive emails (commissions, alerts, health checks)
        /// PROTECTED - any modification attempt triggers alert
        /// </summary>
        Developer
    }

    /// <summary>
    /// Email template service interface for localized email operations
    /// </summary>
    public interface IEmailTemplateService
    {
        /// <summary>
        /// Gets a localized email template based on template name and language
        /// </summary>
        /// <param name="templateName">Base name of the template (e.g., "OrderReceipt")</param>
        /// <param name="languageCode">Two-letter language code (e.g., "pl", "en")</param>
        /// <returns>HTML template content</returns>
        Task<string> GetLocalizedTemplateAsync(string templateName, string languageCode);
        
        /// <summary>
        /// Gets the user's preferred language based on their profile or defaults to English
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns>Two-letter language code</returns>
        Task<string> GetUserLanguageAsync(string? userId);
        
        /// <summary>
        /// Gets language preference for a user by email (for non-authenticated users)
        /// </summary>
        /// <param name="email">User email</param>
        /// <returns>Two-letter language code</returns>
        Task<string> GetUserLanguageByEmailAsync(string email);
        
        /// <summary>
        /// Replaces template placeholders with actual values
        /// </summary>
        /// <param name="template">HTML template with {{PLACEHOLDER}} markers</param>
        /// <param name="variables">Dictionary of placeholder names and values</param>
        /// <returns>Processed template</returns>
        string ReplaceVariables(string template, Dictionary<string, string> variables);
        
        /// <summary>
        /// Gets the localized email subject line
        /// </summary>
        /// <param name="subjectKey">Subject key (e.g., "OrderReceipt_Subject")</param>
        /// <param name="languageCode">Two-letter language code</param>
        /// <param name="parameters">Optional parameters to format into the subject</param>
        /// <returns>Localized subject line</returns>
        string GetLocalizedSubject(string subjectKey, string languageCode, params object[] parameters);
    }
}
