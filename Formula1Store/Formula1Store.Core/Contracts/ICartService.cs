using Formula1Store.Core.Models.Cart;

namespace Formula1Store.Core.Contracts
{
    public interface ICartService
    {
        Task AddToCart(string? userId, int productId);

        Task<ShoppingCartDto> GetOrCreateCart(string? userId);

        Task<ShoppingCartDto> CreateCartForUser(string? userId);

        Task UpdateQuantity(Dictionary<int, int> productAndQuantity);
    }
}
