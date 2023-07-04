using Formula1Store.Domain.Enums;
using Formula1Store.Domain.Models;
using Formula1Store.ViewModels.Product;

namespace Formula1Store.Core.Contracts
{
    public interface IProductService
    {
        Task<AllProductsQueryModel> GetAllAsync(string? category = null,
            int currentPage = 1,
            string? searchTerm = null,
            ProductSorting sorting = ProductSorting.LowestPrice,
            int productsPerPage = 5);
    }
}