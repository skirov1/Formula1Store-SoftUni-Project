using Formula1Store.Core.Models.Order;

namespace Formula1Store.Core.Contracts
{
    public interface IOrderService
    {
        Task<OrdersViewModel> AllOrders(string? userId);

        Task CreateOrder(string? customerId,
                                      int? cartId,
                                      string fullName,
                                      string phoneNumber,
                                      string deliveryAddress);
    }
}
