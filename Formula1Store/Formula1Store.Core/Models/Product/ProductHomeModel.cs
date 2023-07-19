using Formula1Store.Core.Contracts;

namespace Formula1Store.Core.Models.Product
{
    public class ProductHomeModel : IProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public decimal Price { get; set; }

    }
}