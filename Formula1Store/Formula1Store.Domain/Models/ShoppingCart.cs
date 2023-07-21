using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Formula1Store.Domain.Models
{
    public class ShoppingCart
    {
        public ShoppingCart(string customerId)
        {
            this.CustomerId = customerId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; } = null!;

        [ForeignKey(nameof(CustomerId))]
        public User Customer { get; set; }

        public List<ShoppingCartItem> CartProducts { get; set; } = new List<ShoppingCartItem>();

        public bool IsActive { get; set; } = true;

        public void AddItem(Product product, int quantity = 1)
        {
            if (!CartProducts.Any(i => i.ProductName == product.Name))
            {
                CartProducts.Add(new ShoppingCartItem(product.Id, product.Name, product.Price, product.ImageUrl, quantity));
                return;
            }

            var duplicateProducts = CartProducts.First(i => i.ProductId == product.Id);
            duplicateProducts.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            CartProducts.RemoveAll(i => i.Quantity == 0);
        }
    }
}