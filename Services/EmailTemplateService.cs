using Kokomija.Data;
using Microsoft.EntityFrameworkCore;

namespace Kokomija.Services
{
    /// <summary>
    /// Email template service for loading and processing localized email templates
    /// </summary>
    public class EmailTemplateService : IEmailTemplateService
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<EmailTemplateService> _logger;
        private readonly ApplicationDbContext _context;
        
        // Email translations dictionary (Polish and English)
        private static readonly Dictionary<string, Dictionary<string, string>> _translations = new()
        {
            // Polish translations
            ["pl"] = new Dictionary<string, string>
            {
                // Order Receipt
                ["OrderReceipt_Subject"] = "Potwierdzenie zamówienia #{0} - Kokomija",
                ["OrderReceipt_Title"] = "Dziękujemy za zamówienie!",
                ["OrderReceipt_Subtitle"] = "Twoje zamówienie zostało pomyślnie przyjęte",
                ["OrderReceipt_OrderNumber"] = "Numer zamówienia",
                ["OrderReceipt_OrderDate"] = "Data zamówienia",
                ["OrderReceipt_TotalAmount"] = "Suma",
                ["OrderReceipt_Subtotal"] = "Suma częściowa",
                ["OrderReceipt_Shipping"] = "Wysyłka",
                ["OrderReceipt_Tax"] = "VAT",
                ["OrderReceipt_Discount"] = "Rabat",
                ["OrderReceipt_OrderedProducts"] = "Zamówione produkty",
                ["OrderReceipt_ShippingInfo"] = "Informacje o wysyłce",
                ["OrderReceipt_ShippingAddress"] = "Adres dostawy",
                ["OrderReceipt_DeliveryTime"] = "Czas dostawy: 2-5 dni roboczych",
                ["OrderReceipt_WhatsNext"] = "Co dalej?",
                ["OrderReceipt_Step1"] = "Przygotujemy Twoje zamówienie",
                ["OrderReceipt_Step2"] = "Wyślemy email z numerem przesyłki",
                ["OrderReceipt_Step3"] = "Otrzymasz paczkę w ciągu 2-5 dni",
                ["OrderReceipt_TrackOrder"] = "Śledź zamówienie",
                ["OrderReceipt_NeedHelp"] = "Potrzebujesz pomocy?",
                ["OrderReceipt_ContactUs"] = "Skontaktuj się z nami",
                ["OrderReceipt_ThankYou"] = "Dziękujemy za zakupy w Kokomija!",
                ["OrderReceipt_AllRights"] = "Wszelkie prawa zastrzeżone",
                ["OrderReceipt_Home"] = "Strona główna",
                ["OrderReceipt_Privacy"] = "Polityka prywatności",
                ["OrderReceipt_Contact"] = "Kontakt",
                
                // Password Reset
                ["PasswordReset_Subject"] = "Resetowanie hasła - Kokomija",
                ["PasswordReset_Title"] = "Zresetuj swoje hasło",
                ["PasswordReset_Subtitle"] = "Otrzymaliśmy prośbę o zresetowanie hasła",
                ["PasswordReset_Instructions"] = "Kliknij poniższy przycisk, aby utworzyć nowe hasło:",
                ["PasswordReset_Button"] = "Zresetuj hasło",
                ["PasswordReset_LinkExpiry"] = "Ten link wygaśnie za 24 godziny",
                ["PasswordReset_IgnoreNotice"] = "Jeśli nie prosiłeś o resetowanie hasła, zignoruj tę wiadomość",
                ["PasswordReset_SecurityNotice"] = "Ze względów bezpieczeństwa nigdy nie udostępniaj tego linku",
                
                // Email Verification  
                ["EmailVerification_Subject"] = "Potwierdź swój adres email - Kokomija",
                ["EmailVerification_Title"] = "Witamy w Kokomija!",
                ["EmailVerification_Subtitle"] = "Potwierdź swój adres email, aby aktywować konto",
                ["EmailVerification_Instructions"] = "Kliknij poniższy przycisk, aby potwierdzić adres email:",
                ["EmailVerification_Button"] = "Potwierdź email",
                ["EmailVerification_Benefits_Title"] = "Co zyskasz jako członek?",
                ["EmailVerification_Benefit1"] = "Ekskluzywne promocje i rabaty",
                ["EmailVerification_Benefit2"] = "Śledzenie zamówień i historia zakupów",
                ["EmailVerification_Benefit3"] = "Szybsze finalizowanie zamówień",
                ["EmailVerification_Benefit4"] = "Wcześniejszy dostęp do nowości",
                ["EmailVerification_LinkExpiry"] = "Ten link wygaśnie za 24 godziny",
                ["EmailVerification_IgnoreNotice"] = "Jeśli nie zakładałeś konta, zignoruj tę wiadomość",
                
                // Common
                ["Common_Currency"] = "PLN",
                ["Common_Quantity"] = "Ilość",
                ["Common_Size"] = "Rozmiar",
                ["Common_Color"] = "Kolor",
                ["Common_Price"] = "Cena"
            },
            
            // English translations
            ["en"] = new Dictionary<string, string>
            {
                // Order Receipt
                ["OrderReceipt_Subject"] = "Order Confirmation #{0} - Kokomija",
                ["OrderReceipt_Title"] = "Thank you for your order!",
                ["OrderReceipt_Subtitle"] = "Your order has been successfully placed",
                ["OrderReceipt_OrderNumber"] = "Order Number",
                ["OrderReceipt_OrderDate"] = "Order Date",
                ["OrderReceipt_TotalAmount"] = "Total",
                ["OrderReceipt_Subtotal"] = "Subtotal",
                ["OrderReceipt_Shipping"] = "Shipping",
                ["OrderReceipt_Tax"] = "Tax",
                ["OrderReceipt_Discount"] = "Discount",
                ["OrderReceipt_OrderedProducts"] = "Ordered Products",
                ["OrderReceipt_ShippingInfo"] = "Shipping Information",
                ["OrderReceipt_ShippingAddress"] = "Delivery Address",
                ["OrderReceipt_DeliveryTime"] = "Delivery time: 2-5 business days",
                ["OrderReceipt_WhatsNext"] = "What's Next?",
                ["OrderReceipt_Step1"] = "We'll prepare your order",
                ["OrderReceipt_Step2"] = "We'll send you a tracking number",
                ["OrderReceipt_Step3"] = "You'll receive your package in 2-5 days",
                ["OrderReceipt_TrackOrder"] = "Track Order",
                ["OrderReceipt_NeedHelp"] = "Need Help?",
                ["OrderReceipt_ContactUs"] = "Contact Us",
                ["OrderReceipt_ThankYou"] = "Thank you for shopping at Kokomija!",
                ["OrderReceipt_AllRights"] = "All rights reserved",
                ["OrderReceipt_Home"] = "Home",
                ["OrderReceipt_Privacy"] = "Privacy Policy",
                ["OrderReceipt_Contact"] = "Contact",
                
                // Password Reset
                ["PasswordReset_Subject"] = "Password Reset - Kokomija",
                ["PasswordReset_Title"] = "Reset Your Password",
                ["PasswordReset_Subtitle"] = "We received a request to reset your password",
                ["PasswordReset_Instructions"] = "Click the button below to create a new password:",
                ["PasswordReset_Button"] = "Reset Password",
                ["PasswordReset_LinkExpiry"] = "This link will expire in 24 hours",
                ["PasswordReset_IgnoreNotice"] = "If you didn't request a password reset, please ignore this email",
                ["PasswordReset_SecurityNotice"] = "For security reasons, never share this link",
                
                // Email Verification
                ["EmailVerification_Subject"] = "Verify Your Email - Kokomija",
                ["EmailVerification_Title"] = "Welcome to Kokomija!",
                ["EmailVerification_Subtitle"] = "Verify your email address to activate your account",
                ["EmailVerification_Instructions"] = "Click the button below to verify your email:",
                ["EmailVerification_Button"] = "Verify Email",
                ["EmailVerification_Benefits_Title"] = "What you'll get as a member?",
                ["EmailVerification_Benefit1"] = "Exclusive promotions and discounts",
                ["EmailVerification_Benefit2"] = "Order tracking and purchase history",
                ["EmailVerification_Benefit3"] = "Faster checkout experience",
                ["EmailVerification_Benefit4"] = "Early access to new arrivals",
                ["EmailVerification_LinkExpiry"] = "This link will expire in 24 hours",
                ["EmailVerification_IgnoreNotice"] = "If you didn't create an account, please ignore this email",
                
                // Common
                ["Common_Currency"] = "PLN",
                ["Common_Quantity"] = "Qty",
                ["Common_Size"] = "Size",
                ["Common_Color"] = "Color",
                ["Common_Price"] = "Price"
            }
        };

        public EmailTemplateService(
            IWebHostEnvironment environment,
            ILogger<EmailTemplateService> logger,
            ApplicationDbContext context)
        {
            _environment = environment;
            _logger = logger;
            _context = context;
        }

        public async Task<string> GetLocalizedTemplateAsync(string templateName, string languageCode)
        {
            try
            {
                // Normalize language code to lowercase
                var lang = languageCode.ToLower();
                if (lang.Contains("-"))
                {
                    lang = lang.Split('-')[0]; // "pl-PL" -> "pl"
                }
                
                // Only Polish and English are supported, default to English
                if (lang != "pl")
                {
                    lang = "en";
                }

                // Try to load language-specific template first
                var templatePath = Path.Combine(_environment.ContentRootPath, "Views", "EmailTemplates", $"{templateName}_{lang.ToUpper()}.html");
                
                if (!File.Exists(templatePath))
                {
                    // Fallback to base template
                    templatePath = Path.Combine(_environment.ContentRootPath, "Views", "EmailTemplates", $"{templateName}.html");
                }

                if (!File.Exists(templatePath))
                {
                    _logger.LogError("Email template not found: {TemplateName} for language {Language}", templateName, languageCode);
                    throw new FileNotFoundException($"Email template not found: {templateName}");
                }

                var template = await File.ReadAllTextAsync(templatePath);
                _logger.LogInformation("Loaded email template: {TemplateName} for language {Language}", templateName, lang);
                
                return template;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading email template: {TemplateName}", templateName);
                throw;
            }
        }

        public async Task<string> GetUserLanguageAsync(string? userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return "en"; // Default to English for anonymous users
            }

            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    return "en";
                }

                // Check if user's country is Poland
                var country = user.DefaultCountry?.ToLower();
                if (country == "poland" || country == "polska" || country == "pl")
                {
                    return "pl";
                }

                return "en";
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error getting user language for {UserId}, defaulting to English", userId);
                return "en";
            }
        }

        public async Task<string> GetUserLanguageByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return "en";
            }

            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    // Check if it looks like a Polish email provider
                    var lowerEmail = email.ToLower();
                    if (lowerEmail.EndsWith(".pl") || 
                        lowerEmail.Contains("@wp.pl") || 
                        lowerEmail.Contains("@onet.pl") ||
                        lowerEmail.Contains("@interia.pl") ||
                        lowerEmail.Contains("@o2.pl"))
                    {
                        return "pl";
                    }
                    return "en";
                }

                return await GetUserLanguageAsync(user.Id);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error getting user language for email {Email}, defaulting to English", email);
                return "en";
            }
        }

        public string ReplaceVariables(string template, Dictionary<string, string> variables)
        {
            foreach (var kvp in variables)
            {
                template = template.Replace($"{{{{{kvp.Key}}}}}", kvp.Value);
            }

            return template;
        }

        public string GetLocalizedSubject(string subjectKey, string languageCode, params object[] parameters)
        {
            var lang = languageCode.ToLower();
            if (lang.Contains("-"))
            {
                lang = lang.Split('-')[0];
            }
            
            if (lang != "pl")
            {
                lang = "en";
            }

            if (_translations.TryGetValue(lang, out var langDict) && 
                langDict.TryGetValue(subjectKey, out var subject))
            {
                if (parameters.Length > 0)
                {
                    return string.Format(subject, parameters);
                }
                return subject;
            }

            // Fallback to key name
            _logger.LogWarning("Translation not found for key: {Key} in language: {Language}", subjectKey, lang);
            return subjectKey;
        }

        /// <summary>
        /// Gets a translation by key and language code
        /// </summary>
        public static string GetTranslation(string key, string languageCode)
        {
            var lang = languageCode.ToLower();
            if (lang.Contains("-"))
            {
                lang = lang.Split('-')[0];
            }
            
            if (lang != "pl")
            {
                lang = "en";
            }

            if (_translations.TryGetValue(lang, out var langDict) && 
                langDict.TryGetValue(key, out var value))
            {
                return value;
            }

            return key;
        }
    }
}
