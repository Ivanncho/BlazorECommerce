﻿
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
        [HttpGet("{id}")]
        public async Task<ServiceResponse<Product>> GetProductById(int id)
        {
            var result = await _productService.GetProductAsync(id);
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product){
            var result = await _productService.CreateProduct(product);
            if(result == null){
                return BadRequest("Product is invalid.");
            }
            return Ok(result);
        }
        [HttpGet("category/{categoryUrl}")]
        public async Task<ActionResult<List<Product>>> GetProductByCategory(string categoryUrl){
            var result = await _productService.GetProductsByCategory(categoryUrl);
            return Ok(result);
        }
    }
}
