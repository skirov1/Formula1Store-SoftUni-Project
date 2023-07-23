namespace Formula1Store.Core.Models.Order
{
    public class OrderServiceModel
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = null!;

        public string OrderDate { get; set; } = null!;
    }
}