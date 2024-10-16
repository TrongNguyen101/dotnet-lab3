using BusinessObject.DataTransfer;
using BusinessObject.Models;
using DataAccess.ProductsDataAccess;

namespace Repositories.ProductsRepo
{
    public class ProductRepository : IProductsRepository
    {
        public List<ProductsDTO> MapToListDto(List<Products> products)
        {
            return products.Select(x => new ProductsDTO
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                UnitsInStock = x.UnitsInStock,
                UnitPrice = x.UnitPrice,
                CategoryId = x.CategoryId,
            }).ToList();
        }

        public ProductsDTO MapToDto(Products products)
        {
            return new ProductsDTO
            {
                ProductId = products.ProductId,
                ProductName = products.ProductName,
                UnitsInStock = products.UnitsInStock,
                UnitPrice = products.UnitPrice,
                CategoryId = products.CategoryId,
            };
        }

        public Task AddProduct(ProductsDTO productDTO)
        {
            Products product = new Products
            {
                ProductId = productDTO.ProductId,
                ProductName = productDTO.ProductName,
                UnitsInStock = productDTO.UnitsInStock,
                UnitPrice = productDTO.UnitPrice,
                CategoryId = productDTO.CategoryId,
            };
            return ProductsDAO.GetInstance().SaveProductAsync(product);
        }

        public async Task<Boolean> DeleteProduct(int id)
        {
            var product = await ProductsDAO.GetInstance().GetProductById(id);
            if (product != null)
            {
                await ProductsDAO.GetInstance().DeleteProductAsync(product);
                return true;
            }
            return false;
        }

        public async Task<List<ProductsDTO>> GetAllProducts()
        {
            var products = await ProductsDAO.GetInstance().GetProductsAsync();
            return MapToListDto(products);
        }

        public async Task<ProductsDTO> GetProduct(int id)
        {
            var product = await ProductsDAO.GetInstance().GetProductById(id);
            return MapToDto(product);
        }

        public async Task UpdateProduct(int id, ProductUpdateDTO productDTO)
        {
            var product = await ProductsDAO.GetInstance().GetProductById(id);
            product.ProductName = productDTO.ProductName;
            product.UnitPrice = productDTO.UnitPrice;
            product.UnitsInStock = productDTO.UnitsInStock;
            product.CategoryId = productDTO.CategoryId;
            await ProductsDAO.GetInstance().UpdateProductAsync(product);
        }
    }
}