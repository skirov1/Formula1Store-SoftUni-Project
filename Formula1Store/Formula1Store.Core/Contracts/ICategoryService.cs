using Formula1Store.Core.Models.Category;

namespace Formula1Store.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
    }
}