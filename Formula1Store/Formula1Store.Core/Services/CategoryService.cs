using Formula1Store.Core.Contracts;
using Formula1Store.Core.Repositories;
using Formula1Store.Domain.Models;
using Formula1Store.ViewModels.Category;
using Microsoft.EntityFrameworkCore;

namespace Formula1Store.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;

        public CategoryService(IRepository _repo)
        {
            this.repo = _repo;
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
