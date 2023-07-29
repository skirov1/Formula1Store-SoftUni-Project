using Formula1Store.Core.Contracts;
using Formula1Store.Core.Repositories;
using Formula1Store.Core.Services;
using Formula1Store.Domain.Models;
using Formula1Store.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Formula1Store.UnitTests
{
    public class OrderServiceTests
    {
        private IRepository repo;
        private IOrderService orderService;
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
        public async Task TestGetAllOrders()
        {
            var repo = new Repository(context);
            orderService = new OrderService(repo);

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

            await repo.AddRangeAsync(new List<Order>()
            {
                new Order("7a920421-bb01-4902-9cc4-6fc612e8af09")
                {
                    CustomerId = "7a920421-bb01-4902-9cc4-6fc612e8af09",
                    OrderNumber = "043d78f4-940b-4174-b470-3ca8af84834f",
                    UserFullName = "Simeon Kirov",
                    UserPhoneNumber = "1234567890",
                    DeliveryAddress = "Sofia"
                },
            });

            await repo.SaveChangesAsync();

            var orderCollection = await orderService.AllOrders("7a920421-bb01-4902-9cc4-6fc612e8af09");

            Assert.That(1, Is.EqualTo(orderCollection.Orders.Count()));
        }

        [Test]
        public async Task TestCreateOrder()
        {
            var repo = new Repository(context);
            orderService = new OrderService(repo);

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

            var cart = new ShoppingCart("")
            {
                CustomerId = "7a920421-bb01-4902-9cc4-6fc612e8af09",
                CartProducts = new List<ShoppingCartItem>(),
                Id = 10,
                IsActive = true
            };

            await repo.AddAsync(user);
            await repo.AddAsync(cart);
            await repo.SaveChangesAsync();

           
            int cartId = 10;
            var fullName = "Simeon Kirov";
            var phoneNumber = "1234567890";
            var deliveryAddress = "Sofia";

            await orderService.CreateOrder(user.Id, cartId, fullName, phoneNumber, deliveryAddress);

            Assert.That(1, Is.EqualTo(repo.AllReadonly<Order>().Count()));
        }
    }
}