namespace Formula1Store.Core.Contracts
{
    public interface IOrderService
    {
        Task CreateOrder(string? customerId,
                                      int? cartId,
                                      string fullName,
                                      string phoneNumber,
                                      string deliveryAddress);
    }
}
