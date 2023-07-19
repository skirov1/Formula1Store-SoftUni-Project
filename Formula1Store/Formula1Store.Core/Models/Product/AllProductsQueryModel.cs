using Formula1Store.Domain.Enums;


namespace Formula1Store.Core.Models.Product
{
    public class AllProductsQueryModel
    {
        public const int ProductsPerPage = 6;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public ProductSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<ProductServiceModel> Products { get; set; } = Enumerable.Empty<ProductServiceModel>();
    }
}