using Formula1Store.Core.Contracts;
using Formula1Store.Core.Models.Order;
using Formula1Store.Core.Repositories;
using Formula1Store.Domain.Enums;
using Formula1Store.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Formula1Store.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repo;

        public OrderService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<OrdersViewModel> AllOrders(string? userId)
        {
            var result = new OrdersViewModel();
            var user = await repo.GetByIdAsync<User>(userId);

            var orders = await repo.AllReadonly<Order>()
                .Where(o => o.CustomerId == userId)
                .Select(o => new OrderServiceModel()
                {
                    OrderId = o.Id,
                    OrderNumber = o.OrderNumber,
                    OrderDate = o.OrderDate.ToString()
                })
                .OrderByDescending(x => x.OrderId)
                .ToListAsync();
            result.Orders.AddRange(orders);

            return result;
        }

        public async Task CreateOrder(string? customerId, int? cartId, string fullName, string phoneNumber, string deliveryAddress)
        {
            var cart = new ShoppingCart("");

            if (customerId != null && cartId != null)
            {
                cart = await repo.All<ShoppingCart>()
                    .Include(sc => sc.CartProducts)
                    .Where(sc => sc.CustomerId == customerId && sc.IsActive)
                    .FirstAsync();

                await repo.AddAsync(new Order(customerId)
                {
                    Products = cart.CartProducts,
                    DeliveryAddress = deliveryAddress,
                    UserFullName = fullName,
                    UserPhoneNumber = phoneNumber,
                    OrderNumber = Guid.NewGuid().ToString()
                });
                cart.IsActive = false;

                await repo.SaveChangesAsync();
            }
        }
    }
}
