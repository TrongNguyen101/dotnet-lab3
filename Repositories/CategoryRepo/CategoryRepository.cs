using BusinessObject.DataTransfer;
using BusinessObject.Models;
using DataAccess.CategoryDataAccess;

namespace Repositories.CatgoryRepo
{
    public class CatgoryRepoRepository : ICatgoryRepository
    {
        public List<CategoryDTO> MapToListDto(List<Category> categories)
        {
            return categories.Select(x => new CategoryDTO
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
            }).ToList();
        }
        public async Task<List<CategoryDTO>> GetAsync()
        {
            var categories = await CategoryDAO.GetInstance().GetCategoryAsync();
            return MapToListDto(categories);
        }
    }
}