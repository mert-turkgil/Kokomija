using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels.Cart
{
    public class UpdateCartItemRequest
    {
        [Required]
        public int ProductId { get; set; }

        public int? ColorId { get; set; }

        public int? SizeId { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Quantity must be between 0 and 100")]
        public int Quantity { get; set; }
    }
}
