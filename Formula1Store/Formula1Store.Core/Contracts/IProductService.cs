using Formula1Store.Domain.Enums;
using Formula1Store.Domain.Models;
using Formula1Store.Core.Models.Product;

namespace Formula1Store.Core.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductHomeModel>> LastThreeProducts();

        Task<AllProductsQueryModel> GetAllAsync(string? category = null,
            int currentPage = 1,
            string? searchTerm = null,
            ProductSorting sorting = ProductSorting.LowestPrice,
            int productsPerPage = 6);

        Task<IEnumerable<ProductCategoryModel>> AllCategories();

        Task<bool> CategoryExists(int categoryId);

        Task<int> Create(ProductModel model);

        Task<IEnumerable<string>> AllCategoriesNames();

        Task<ProductDetailsModel> ProductDetails(int id);

        Task<bool> Exists(int id);

        Task<int> GetProductCategoryId(int productId);

        Task Edit(int productId, ProductModel model);

        Task Delete(int productId);
    }
}