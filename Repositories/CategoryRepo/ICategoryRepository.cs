using BusinessObject.DataTransfer;

namespace Repositories.CatgoryRepo
{
    public interface ICatgoryRepository
    {
        Task<List<CategoryDTO>> GetAsync();
    }
}