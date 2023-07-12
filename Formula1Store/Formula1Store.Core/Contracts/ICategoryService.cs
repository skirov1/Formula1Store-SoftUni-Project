using Formula1Store.ViewModels.Category;

namespace Formula1Store.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAll();
    }
}