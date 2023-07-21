namespace Formula1Store.Core.Models.Cart
{
    public class IndexViewModel
    {
        public ShoppingCartDto UserCart { get; set; }

        public decimal TotalPrice()
        {
            return Math.Round(UserCart.CartItems.Sum(x => x.Price * x.Quantity), 2);
        }
    }
}