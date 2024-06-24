using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using eShopSolution.Application.IService;

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
        public IActionResult EditProduct(int id, [FromBody] Product product)
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

            _productService.UpdateProduct(product);
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

           _productService.DeleteProduct(id);
            return NoContent();
        }
        [HttpGet("GetProductByCategory/{categoryId}")]
        public IActionResult GetProductByCategory(int categoryId)
        {
            var products = _productService.GetAllProducts().Where(p => p.CategoryId == categoryId);
            return Ok(products);
        }


        [HttpGet("SearchProductByProductName/{ProductName}")]
        public IActionResult SearchProductByProductName(string ProductName)
        {
            var products = _productService.GetAllProducts()
                                  .Where(p => p.ProductName.Contains(ProductName));

            return Ok(products);
        }

        [HttpGet("GetProductDetailDtoByProductId/{Id}")]
        public IActionResult GetProductDetailDtoByProductId(int id)
        {
            var product = _productService.GetProductDetailDtoByProductId(id);
            return Ok(product);


        }

    }
}
