using BusinessObject.DataContext;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.CategoryDataAccess
{
    public class CategoryDAO
    {
        private StoreContext context;
        public CategoryDAO() => context = new StoreContext(); 
        private static volatile CategoryDAO instance;
        private static readonly object lockInstance = new object();
        public static CategoryDAO GetInstance()
        {
            if (instance == null)
            {
                lock (lockInstance)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                }
            }
            return instance;
        }

        public async Task<List<Category>> GetCategoryAsync()
        {
            var listCategory = new List<Category>();
            try
            {
                listCategory = await context.Categories.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            return listCategory;
        }
    }
}