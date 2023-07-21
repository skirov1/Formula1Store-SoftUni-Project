using Formula1Store.Core.Contracts;
using Formula1Store.Core.Models.Cart;
using Formula1Store.Core.Repositories;
using Formula1Store.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1Store.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;

        public CartService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task AddToCart(string? userId, int productId)
        {
            var cart = await repo.All<ShoppingCart>()
                .Where(sc => sc.CustomerId == userId && sc.IsActive)
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                cart = new ShoppingCart(userId);
                await repo.AddAsync(cart);
            }

            var product = await repo.All<Product>()
                .Include(p => p.Category)
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();

            cart.AddItem(product, 1);

            await repo.SaveChangesAsync();
        }

        public async Task<ShoppingCartDto> CreateCartForUser(string? userId)
        {
            var cart = new ShoppingCart(userId);
            await repo.AddAsync<ShoppingCart>(cart);

            await repo.SaveChangesAsync();

            return await repo.All<ShoppingCart>()
                .Where(sc => sc.CustomerId == userId && sc.IsActive)
                .Select(sc => new ShoppingCartDto()
                {
                    CustomerId = sc.CustomerId,
                    CartItems = sc.CartProducts.Select(p => new ShoppingCartItemDto()
                    {
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        ProductName = p.ProductName,
                        Quantity = p.Quantity,
                        ShoppingCartId = p.ShoppingCart.Id
                    }).ToList()
                })
                .FirstAsync();
        }

        public async Task<ShoppingCartDto> GetOrCreateCart(string? userId)
        {
            var cart = await repo.All<ShoppingCart>()
                .Include(sc => sc.CartProducts)
                .Where(sc => sc.CustomerId == userId && sc.IsActive)
                .Select(sc => new ShoppingCartDto()
                {
                    CustomerId = sc.CustomerId,
                    CartItems = sc.CartProducts.Select(p => new ShoppingCartItemDto()
                    {
                        Id = p.Id,
                        ImageUrl = p.ImageUrl,
                        Price = p.Price,
                        ProductName = p.ProductName,
                        Quantity = p.Quantity,
                        ShoppingCartId = p.ShoppingCart.Id
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (cart == null)
            {
                return await CreateCartForUser(userId);
            }

            return cart;
        }

        public async Task UpdateQuantity(Dictionary<int, int> productAndQuantity)
        {
            var cartItems = await repo.All<ShoppingCartItem>()
                .Where(x => productAndQuantity.Keys
                .Any(p => p == x.Id)).Include(x => x.ShoppingCart)
                .ToListAsync();

            foreach (var item in cartItems)
            {
                foreach (var p in productAndQuantity)
                {
                    if (p.Key == item.Id)
                    {
                        item.SetQuantity(p.Value);
                    }
                }

                item.ShoppingCart.RemoveEmptyItems();
            }

            await repo.SaveChangesAsync();
        }
    }
}