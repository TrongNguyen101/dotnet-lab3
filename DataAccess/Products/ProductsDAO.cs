using BusinessObject.DataContext;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ProductsDataAccess
{
    public class ProductsDAO
    {
        private StoreContext context;
        public ProductsDAO() => context = new StoreContext();
        private static volatile ProductsDAO instance;
        private static readonly object lockInstance = new object();
        public static ProductsDAO GetInstance()
        {
            if (instance == null)
            {
                lock (lockInstance)
                {
                    if (instance == null)
                    {
                        instance = new ProductsDAO();
                    }
                }
            }
            return instance;
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            var products = new List<Products>();
            try
            {
                products = await context.Products.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return products;
        }

        public async Task<Products> GetProductById(int id)
        {
            Products product;
            try
            {
                product = await context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return product;
        }

        public async Task SaveProductAsync(Products product)
        {
            try
            {
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateProductAsync(Products product)
        {
            try
            {
                context.Update(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteProductAsync(Products product)
        {
            try
            {
                context.Remove(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}