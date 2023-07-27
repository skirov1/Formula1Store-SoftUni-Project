using Formula1Store.Core.Contracts;
using Formula1Store.Core.Repositories;
using Formula1Store.Core.Services;
using Formula1Store.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace Formula1Store.UnitTests
{
    public class CategoryServiceTests
    {
        private IRepository repo;
        private ILogger<ProductService> logger;
        private ICategoryService categoryService;
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
        public async Task TestGetAllCategories()
        {
            var repo = new Repository(context);
            categoryService = new CategoryService(repo, logger);

            var products = await categoryService.GetAll();

            var loggerMock = new Mock<ILogger<ProductService>>();
            logger = loggerMock.Object;

            Assert.That(4, Is.EqualTo(products.Count()));
        }

        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }
    }
}
