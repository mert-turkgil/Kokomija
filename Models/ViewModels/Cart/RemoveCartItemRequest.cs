using System.ComponentModel.DataAnnotations;

namespace Kokomija.Models.ViewModels.Cart
{
    public class RemoveCartItemRequest
    {
        [Required]
        public int ProductId { get; set; }

        public int? ColorId { get; set; }

        public int? SizeId { get; set; }
    }
}
