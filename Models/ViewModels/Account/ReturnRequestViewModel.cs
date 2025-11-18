using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels.Account
{
    public class ReturnRequestViewModel
    {
        [Required]
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a reason for return")]
        public string Reason { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide details about the return")]
        [StringLength(1000, ErrorMessage = "Details cannot exceed 1000 characters")]
        [MinLength(20, ErrorMessage = "Please provide at least 20 characters of detail")]
        public string Details { get; set; } = string.Empty;

        public List<int> SelectedItemIds { get; set; } = new List<int>();

        // For display purposes
        public IEnumerable<OrderItemViewModel> OrderItems { get; set; } = new List<OrderItemViewModel>();
    }

    public class ReturnReason
    {
        public static readonly List<string> Reasons = new()
        {
            "Defective or damaged item",
            "Wrong item received",
            "Item doesn't match description",
            "Wrong size ordered",
            "No longer needed",
            "Quality not as expected",
            "Other"
        };
    }
}
