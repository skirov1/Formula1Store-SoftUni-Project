using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Formula1Store.Domain.Enums;
using Formula1Store.Domain.Models;

namespace Formula1Store.ViewModels.Product
{
    public class AllProductsQueryModel
    {
        public const int ProductsPerPage = 5;

        public string? Category { get; set; }

        public string? SearchTerm { get; set; }

        public ProductSorting Sorting { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int TotalProductsCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = Enumerable.Empty<string>();

        public IEnumerable<ProductViewModel> Products { get; set; } = Enumerable.Empty<ProductViewModel>();
    }
}