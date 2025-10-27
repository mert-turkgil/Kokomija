using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(200, ErrorMessage = "Subject cannot be longer than 200 characters")]
        [Display(Name = "Subject")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required")]
        [StringLength(2000, ErrorMessage = "Message cannot be longer than 2000 characters")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 characters")]
        [Display(Name = "Message")]
        public string Message { get; set; } = string.Empty;

        // Meta data for SEO
        public string MetaTitle { get; set; } = "Contact Us - Kokomija";
        public string MetaDescription { get; set; } = "Get in touch with Kokomija. Contact us for any questions about our products, orders, or services.";
        public string MetaKeywords { get; set; } = "contact, customer service, support, kokomija";
        public string CanonicalUrl { get; set; } = "/Home/Contact";
    }
}
