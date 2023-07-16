namespace Formula1Store.Core.Models.Product
{
    public class ProductDetailsModel : ProductServiceModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;
    }
}