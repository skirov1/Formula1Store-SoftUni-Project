using Formula1Store.Core.Contracts;
using Formula1Store.Core.Repositories;
using Formula1Store.Core.Services;
using Formula1Store.Domain.Models;
using Formula1Store.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Formula1Store.UnitTests
{
    public class CartServiceTests
    {
        private IRepository repo;
        private ILogger<ProductService> logger;
        private ICartService cartService;
        private Formula1StoreDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<Formula1StoreDbContext>()
                .UseInMemoryDatabase("Formula1StoreDB")
                .Options;

            context = new Formula1StoreDbContext(contextOptions);

            context.Database.EnsureDeletedAsync();
            context.Database.EnsureCreatedAsync();
        }

        [Test]
        public async Task TestAddToCart()
        {
            var repo = new Repository(context);
            cartService = new CartService(repo);

            var user = new User()
            {
                Id = "7a920421-bb01-4902-9cc4-6fc612e8af09",
                FirstName = "Petar",
                LastName = "Petrov",
                UserName = "pepi123",
                NormalizedUserName = "PEPI",
                Email = "petar@email.com",
                NormalizedEmail = "PETAR@EMAIL.COM"
            };
            await repo.AddAsync(user);
            var product = new Product()
            {
                Id = 10,
                CategoryId = 1,
                Description = "Test product description",
                ImageUrl = "",
                IsActive = true,
                Name = "Test product",
                Price = 26.5M,
            };
            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            await cartService.AddToCart("7a920421-bb01-4902-9cc4-6fc612e8af09", 1);
            Assert.That(1, Is.EqualTo(repo.AllReadonly<ShoppingCart>().Count()));
            Assert.That(1, Is.EqualTo(repo.AllReadonly<ShoppingCartItem>().Count()));
        }

        [Test]
        public async Task TestGetOrCreateCart()
        {
            var repo = new Repository(context);
            cartService = new CartService(repo);

            var user = new User()
            {
                Id = "7a920421-bb01-4902-9cc4-6fc612e8af09",
                FirstName = "Petar",
                LastName = "Petrov",
                UserName = "pepi123",
                NormalizedUserName = "PEPI",
                Email = "petar@email.com",
                NormalizedEmail = "PETAR@EMAIL.COM"
            };
            await repo.AddAsync(user);

            await repo.SaveChangesAsync();

            await cartService.GetOrCreateCart("7a920421-bb01-4902-9cc4-6fc612e8af09");
            Assert.That(1, Is.EqualTo(repo.AllReadonly<ShoppingCart>().Count()));
        }
    }
}
