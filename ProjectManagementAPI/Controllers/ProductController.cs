using System.Text.Json;
using BusinessObject.DataTransfer;
using Microsoft.AspNetCore.Mvc;
using Repositories.ProductsRepo;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductsDTO>>> GetAllProducts()
        {
            var products = await productsRepository.GetAllProducts();
            return Ok(JsonSerializer.Serialize(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductsDTO>> GetProduct(int id)
        {
            var product = await productsRepository.GetProduct(id);
            return Ok(JsonSerializer.Serialize(product));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductsDTO product)
        {
            await productsRepository.AddProduct(product);
            return Created();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductUpdateDTO product)
        {
            var _product = await productsRepository.GetProduct(id);
            if (_product != null)
            {
                await productsRepository.UpdateProduct(id, product);
                return NoContent();
            }
            return NotFound("Customer is not exist");
        }

                [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            Boolean isDelete = await productsRepository.DeleteProduct(id);
            if (isDelete == true)
            {
                return Ok("Delete customer successfully");
            }
            return NotFound("Customer is not exist");
        }
    }
}