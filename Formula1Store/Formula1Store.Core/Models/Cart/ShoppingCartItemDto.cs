using System.ComponentModel.DataAnnotations;
using static Formula1Store.Domain.Common.DataConstants.Product;
using static Formula1Store.Domain.Common.DataConstants.Category;

namespace Formula1Store.Core.Models.Cart
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int Quantity { get; set; }

        public int ShoppingCartId { get; set; }

        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string ProductName { get; set; } = null!;

        [StringLength(CategoryNameMaxLength)]
        public string ProductCategory { get; set; } = null!;
    }
}