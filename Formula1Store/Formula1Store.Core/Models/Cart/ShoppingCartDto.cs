namespace Formula1Store.Core.Models.Cart
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }

        public string CustomerId { get; set; }

        public List<ShoppingCartItemDto> CartItems { get; set; } = new List<ShoppingCartItemDto>();
    }
}