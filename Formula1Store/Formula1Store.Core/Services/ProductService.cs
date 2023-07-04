using Formula1Store.Core.Contracts;
using Formula1Store.Core.Repositories;
using Formula1Store.Domain.Enums;
using Formula1Store.Domain.Models;
using Formula1Store.Infrastructure.Data;
using Formula1Store.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace Formula1Store.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        public ProductService(IRepository _repo)
        {
            this.repo = _repo;
        }

        public async Task<AllProductsQueryModel> GetAllAsync(string? category = null, int currentPage = 1, string? searchTerm = null, ProductSorting sorting = ProductSorting.LowestPrice, int productsPerPage = 5)
        {
            var result = new AllProductsQueryModel();
            var products = repo.AllReadonly<Product>();


            if (string.IsNullOrEmpty(searchTerm) == false)
            {
                searchTerm = $"%{searchTerm.ToLower()}%";

                products = products
                    .Where(p => EF.Functions.Like(p.Name.ToLower(), searchTerm) ||
                                EF.Functions.Like(p.Description.ToLower(), searchTerm));
            }

            if (string.IsNullOrEmpty(category) == false)
            {
                products = products
                    .Where(p => p.Category.Name == category);
            }

            switch (sorting)
            {
                case ProductSorting.LowestPrice:
                    products = products.OrderBy(p => p.Price);
                    break;
                case ProductSorting.HighestPrice:
                    products = products.OrderByDescending(p => p.Price);
                    break;
            }

            result.Products = await products
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage)
                .Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Name = p.Name,
                    Description = p.Description,
                    Category = p.Category.Name
                })
                .ToListAsync();

            result.TotalProductsCount = await products.CountAsync();

            return result;
        }

    }
}
