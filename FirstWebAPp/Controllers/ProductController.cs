using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eShopSolution.Data.Entities;
using eShopSolution.Application;
using System;

namespace eShopSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPut("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            var existingProduct = _productService.GetProductById(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            await _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var productToDelete = _productService.GetProductById(id);
            if (productToDelete == null)
            {
                return NotFound();
            }

            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
