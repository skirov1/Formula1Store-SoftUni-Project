using Formula1Store.Core.Contracts;
using Formula1Store.Core.Models.Category;
using Formula1Store.Core.Repositories;
using Formula1Store.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Formula1Store.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        private readonly ILogger logger;

        public CategoryService(IRepository _repo, ILogger _logger)
        {
            this.repo = _repo;
            this.logger = _logger;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            return await repo.AllReadonly<Category>()
               .Select(c => new CategoryViewModel()
               {
                   Id = c.Id,
                   Name = c.Name
               }).
               ToListAsync();
        }
    }
}
