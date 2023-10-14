
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorECommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _productService.GetProductsAsync();
            if (result == null)
            {
                return NotFound("There are no products.");
            }
            return Ok(result);
        }
        [HttpGet("/{id}")]
        public async Task<ActionResult<Product>> GetProductById(int id)
        {
            var result = await _productService.GetProductAsync(id);
            if (result == null)
            {
                return NotFound("Product not found!");
            }
            return Ok(result);
        }
    }
}
