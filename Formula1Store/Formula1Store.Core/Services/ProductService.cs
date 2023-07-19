using Formula1Store.Core.Contracts;
using Formula1Store.Core.Repositories;
using Formula1Store.Domain.Enums;
using Formula1Store.Domain.Models;
using Formula1Store.Core.Models.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Formula1Store.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public ProductService(IRepository _repo,
            ILogger<ProductService> _logger)
        {
            this.repo = _repo;
            logger = _logger;
        }

        public async Task<int> Create(ProductModel model)
        {
            var product = new Product() 
            { 
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                CategoryId = model.CategoryId
            };

            try
            {
                await repo.AddAsync(product);
                await repo.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(nameof(Create), ex);
                throw new ApplicationException("Database failed to save info", ex);
            }

            return product.Id;
        }

        public async Task<IEnumerable<ProductCategoryModel>> AllCategories()
        {
            return await repo.AllReadonly<Category>()
                .OrderBy(c => c.Name)
                .Select(c => new ProductCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNames()
        {
            return await repo.AllReadonly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<AllProductsQueryModel> GetAllAsync(string? category = null, int currentPage = 1, string? searchTerm = null, ProductSorting sorting = ProductSorting.LowestPrice, int productsPerPage = 6)
        {
            var result = new AllProductsQueryModel();
            var products = repo.AllReadonly<Product>()
                .Where(p => p.IsActive);


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
                .Select(p => new ProductServiceModel()
                {
                    Id = p.Id,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Name = p.Name
                })
                .ToListAsync();

            result.TotalProductsCount = await products.CountAsync();

            return result;
        }

        public async Task<ProductDetailsModel> ProductDetails(int id)
        {
            return await repo.AllReadonly<Product>()
                .Where(p => p.Id == id)
                .Select (p => new ProductDetailsModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    Category = p.Category.Name
                })
                .FirstAsync();         
        }

        public async Task<bool> Exists(int id)
        {
            return await repo.AllReadonly<Product>()
                .AnyAsync(h => h.Id == id && h.IsActive);
        }

        public async Task Edit(int productId, ProductModel model)
        {
            var product = await repo.GetByIdAsync<Product>(productId);

            product.Name = model.Name;
            product.Description = model.Description;
            product.ImageUrl = model.ImageUrl;
            product.Price = model.Price;
            product.CategoryId = model.CategoryId;

            await repo.SaveChangesAsync();
        }

        public async Task Delete(int productId)
        {
            var product = await repo.GetByIdAsync<Product>(productId);
            product.IsActive = false;

            await repo.SaveChangesAsync();
        }

        public async Task<int> GetProductCategoryId(int productId)
        {
            return (await repo.GetByIdAsync<Product>(productId)).CategoryId;
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await repo.AllReadonly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<ProductHomeModel>> LastThreeProducts()
        {
            return await repo.AllReadonly<Product>()
               .Where(p => p.IsActive)
               .OrderByDescending(p => p.Id)
               .Select(p => new ProductHomeModel()
               {
                   Id = p.Id,
                   Name = p.Name,
                   ImageUrl = p.ImageUrl,
                   Price = p.Price
               })
               .Take(3)
               .ToListAsync();
        }
    }
}