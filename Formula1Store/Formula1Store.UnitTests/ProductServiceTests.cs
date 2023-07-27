using Formula1Store.Core.Contracts;
using Formula1Store.Core.Models.Product;
using Formula1Store.Core.Repositories;
using Formula1Store.Core.Services;
using Formula1Store.Domain.Models;
using Formula1Store.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Formula1Store.UnitTests
{
    public class ProductServiceTests
    {
        private IRepository repo;
        private ILogger<ProductService> logger;
        private IProductService productService;
        private Formula1StoreDbContext context;

        [SetUp]
        public void Setup()
        {
            var contextOptions = new DbContextOptionsBuilder<Formula1StoreDbContext>()
                .UseInMemoryDatabase("Formula1StoreDB")
                .Options;

            context = new Formula1StoreDbContext(contextOptions);

            context.Database.EnsureDeletedAsync();
            context.Database.EnsureCreatedAsync();
        }

        [Test]
        public async Task TestLastThreeProducts()
        {
            var repo = new Repository(context);
            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;

            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product() { Id = 11, Name = "Test product 1", Description = "Test product 1 description", ImageUrl = "", Price = 50, CategoryId = 1, IsActive = true },
                new Product() { Id = 12, Name = "Test product 2", Description = "Test product 2 description", ImageUrl = "", Price = 50, CategoryId = 2, IsActive = true },
                new Product() { Id = 13, Name = "Test product 3", Description = "Test product 3 description", ImageUrl = "", Price = 50, CategoryId = 3, IsActive = true },
                new Product() { Id = 14, Name = "Test product 4", Description = "Test product 4 description", ImageUrl = "", Price = 50, CategoryId = 4, IsActive = true }
            });

            await repo.SaveChangesAsync();
            var lastThreeProducts = await productService.LastThreeProducts();

            Assert.That(3, Is.EqualTo(lastThreeProducts.Count()));
            Assert.That(lastThreeProducts.Any(h => h.Id == 11), Is.False);
        }

        [Test]
        public async Task TestGetAll()
        {
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            var products = await productService.GetAllAsync();
            var initialProductsCount = products.TotalProductsCount;

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product(){ Id = 10, Name = "Test product 1", Description = "Test product 1 descrption", ImageUrl = "", Price = 12.50m, CategoryId = 2, IsActive = true,},
                new Product(){ Id = 11, Name = "Test product 2", Description = "Test product 2 descrption", ImageUrl = "", Price = 12.50m, CategoryId = 2, IsActive = true,},
                new Product(){ Id = 12, Name = "Test product 3", Description = "Test product 3 descrption", ImageUrl = "", Price = 12.50m, CategoryId = 2, IsActive = true,},
                new Product(){ Id = 13, Name = "Test product 4", Description = "Test product 4 descrption", ImageUrl = "", Price = 12.50m, CategoryId = 2, IsActive = false,},
            });

            await repo.SaveChangesAsync();

            products = await productService.GetAllAsync();

            Assert.That(initialProductsCount + 3, Is.EqualTo(products.TotalProductsCount));
        }

        [Test]
        public async Task TestAllCategories()
        {
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            var categories = await productService.AllCategories();
            var initialCategoriesCount = categories.Count();

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;

            await repo.AddRangeAsync(new List<Category>()
            {
                new (){ Id = 10, Name = "Socks"},
                new (){ Id = 11, Name = "Gloves"}
            });
            await repo.SaveChangesAsync();
            categories = await productService.AllCategories();

            Assert.That(initialCategoriesCount + 2, Is.EqualTo(categories.Count()));
        }

        [Test]
        public async Task TestCategoryExists()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Category>()
            {
                new (){ Id = 10, Name = "Socks"},
                new (){ Id = 11, Name = "Gloves"}
            });
            await repo.SaveChangesAsync();


            Assert.That(true, Is.EqualTo(await productService.CategoryExists(10)));
            Assert.That(true, Is.EqualTo(await productService.CategoryExists(11)));
            Assert.That(false, Is.EqualTo(await productService.CategoryExists(12)));
        }  

        [Test]
        public async Task TestCreateProduct()
        {
            var repo = new Repository(context);
            var initialProductsCount = repo.AllReadonly<Product>().Count();

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;

            productService = new ProductService(repo, logger);
            var model = new ProductModel()
            {
                Id = 1,
                Name = "Test product 1",
                Description = "Test product 1 description",
                ImageUrl = "",
                Price = 22.50m,
                CategoryId = 1,
            };

            await productService.Create(model);

            Assert.That(initialProductsCount + 1, Is.EqualTo(repo.AllReadonly<Product>().Count()));
        }

        [Test]
        public async Task TestAllCategoriesNames()
        {
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            var categories = await productService.AllCategoriesNames();
            var initialCategoriesCount = categories.Count();

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;

            await repo.AddRangeAsync(new List<Category>()
            {
                new (){ Id = 10, Name = "Socks"},
                new (){ Id = 11, Name = "Gloves"}
            });
            await repo.SaveChangesAsync();
            categories = await productService.AllCategoriesNames();

            Assert.That(initialCategoriesCount + 2, Is.EqualTo(categories.Count()));
        }

        [Test]
        public async Task TestProductDetails()
        {
            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product() { Id = 11, Name = "Test product 1", Description = "Test product 1 description", ImageUrl = "", Price = 50, CategoryId = 1, IsActive = true },
                new Product() { Id = 12, Name = "Test product 2", Description = "Test product 2 description", ImageUrl = "", Price = 50, CategoryId = 2, IsActive = true },
                new Product() { Id = 13, Name = "Test product 3", Description = "Test product 3 description", ImageUrl = "", Price = 50, CategoryId = 3, IsActive = false }
            });
            await repo.SaveChangesAsync();

            var productDetailsModel = new ProductDetailsModel()
            {
                Id = 11,
                Name = "Test product 1",
                Description = "Test product 1 description",
                ImageUrl = "",
                Category = "T-Shirt",
                Price = 50
            };

            Assert.That(productDetailsModel.Id, Is.EqualTo(productService.ProductDetails(11).Id));
        }

        [Test]
        public async Task TestExists()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Product>()
            {
               new Product() { Id = 11, Name = "Test product 1", Description = "Test product 1 description", ImageUrl = "", Price = 50, CategoryId = 1, IsActive = true },
                new Product() { Id = 13, Name = "Test product 3", Description = "Test product 3 description", ImageUrl = "", Price = 50, CategoryId = 3, IsActive = false }
            });

            await repo.SaveChangesAsync();

            Assert.That(true, Is.EqualTo(await productService.Exists(11)));
            Assert.That(false, Is.EqualTo(await productService.Exists(13)));
            Assert.That(false, Is.EqualTo(await productService.Exists(15)));
        }

        [Test]
        public async Task TestGetProductCategoryId()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            await repo.AddRangeAsync(new List<Category>()
            {
                new (){ Id = 10, Name = "Socks"},
                new (){ Id = 11, Name = "Gloves"}
            });

            await repo.AddRangeAsync(new List<Product>()
            {
                new Product() { Id = 11, Name = "Test product 1", Description = "Test product 1 description", ImageUrl = "", Price = 50, CategoryId = 10, IsActive = true },
                new Product() { Id = 13, Name = "Test product 3", Description = "Test product 3 description", ImageUrl = "", Price = 50, CategoryId = 11, IsActive = false }
            });
            await repo.SaveChangesAsync();


            Assert.That(10, Is.EqualTo(await productService.GetProductCategoryId(11)));
            Assert.That(11, Is.EqualTo(await productService.GetProductCategoryId(13)));
        }

        [Test]
        public async Task TestEdit()
        {

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;
            var repo = new Repository(context);
            productService = new ProductService(repo, logger);

            var product = new Product()
            {
                Id = 10,
                Name = "Test product 1",
                Description = "Test product 1 description",
                ImageUrl = "",
                Price = 22.50m,
                CategoryId = 1,
                IsActive = true
            };

            await repo.AddAsync(product);
            await repo.SaveChangesAsync();

            var productModel = new ProductModel()
            {
                Id = 10,
                Name = "Test Edit product",
                Description = "Test Edit product description",
                ImageUrl = "",
                Price = 77.50m,
                CategoryId = 1,
            };
            await productService.Edit(1, productModel);
            var editedModel = await repo.GetByIdAsync<Product>(10);

            Assert.That(product.Name, Is.EqualTo(editedModel.Name));
            Assert.That(product.Description, Is.EqualTo(editedModel.Description));
            Assert.That(product.Price, Is.EqualTo(editedModel.Price));
            Assert.That(product.CategoryId, Is.EqualTo(editedModel.CategoryId));
        }

        [Test]
        public async Task TestDelete()
        {
            var repo = new Repository(context);
            var initialProductsCount = repo.AllReadonly<Product>().Count();
            productService = new ProductService(repo, logger);

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;

            var productCollection = new List<Product>()
            {
                new Product() { Id = 11, Name = "Test product 1", Description = "Test product 1 description", ImageUrl = "", Price = 50, CategoryId = 10, IsActive = true },
                new Product() { Id = 13, Name = "Test product 3", Description = "Test product 3 description", ImageUrl = "", Price = 50, CategoryId = 11, IsActive = true }
            };
            await repo.AddRangeAsync(productCollection);
            await repo.SaveChangesAsync();

            await productService.Delete(13);

            Assert.That(initialProductsCount + 1, Is.EqualTo(repo.AllReadonly<Product>().Where(x => x.IsActive).Count()));
        }
    }
}
