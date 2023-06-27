using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Formula1Store.Domain.Common.DataConstants.Product;

namespace Formula1Store.Domain.Models
{
    public class ShoppingCartItem 
    {
        public ShoppingCartItem(int productId, string productName, decimal price, string imageUrl, int quantity)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.ImageUrl = imageUrl;
            this.Quantity = quantity;
        }
        public ShoppingCartItem()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public int CartId { get; set; }

        [ForeignKey(nameof(CartId))]
        public ShoppingCart ShoppingCart { get; set; }

        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string ProductName { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public void AddQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
    }
}