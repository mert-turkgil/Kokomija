using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels.Cart
{
    public class CartAddRequest
    {
        [Required]
        public int ProductId { get; set; }

        public int? ColorId { get; set; }

        public int? SizeId { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
        public int Quantity { get; set; } = 1;
    }
}
