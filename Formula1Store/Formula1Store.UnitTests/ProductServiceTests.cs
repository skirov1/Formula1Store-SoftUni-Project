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
        public async Task TestCreateProduct()
        {
            var repo = new Repository(context);
            var initialProductCount = repo.AllReadonly<Product>().Count();

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

            Assert.That(initialProductCount + 1, Is.EqualTo(repo.AllReadonly<Product>().Count()));
        }
    }
}
