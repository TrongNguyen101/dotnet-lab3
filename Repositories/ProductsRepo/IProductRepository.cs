using BusinessObject.DataTransfer;

namespace Repositories.ProductsRepo
{
    public interface IProductsRepository
    {
        Task<List<ProductsDTO>> GetAllProducts();
        Task<ProductsDTO> GetProduct(int id);
        Task AddProduct(ProductsDTO productsDTO);
        Task UpdateProduct(int id, ProductUpdateDTO productsDTO);
        Task<Boolean> DeleteProduct(int id);
    }
}