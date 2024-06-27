using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using eShopSolution.Application.IService;
using eShopsolution.Data.EF;

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
        public IActionResult GetProduct(int id)
        {
            var product = _productService.GetProductbyID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPut("EditProduct/{id}")]
        public IActionResult EditProduct(int id, [FromBody] Product product)
        {
            if (id != product.ID)
            {
                return BadRequest();
            }
            var existingProduct = _productService.GetProductbyID(id);
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
            var productToDelete = _productService.GetProductbyID(id);
            if (productToDelete == null)
            {
                return NotFound();
            }

            _productService.DeleteProduct(id);
            return NoContent();
        }
        [HttpGet("GetProductByName/{name}")]
        public IActionResult GetProductbyName(string name)
        {
           var products = _productService.GetAllProducts().Where(x => x.Name.Contains(name));
            return Ok(products);
        }
        // phân trang 
        [HttpGet("paged")]
        public IActionResult GetPagedProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than zero.");
            }

            var products = _productService.GetPagedProducts(pageNumber, pageSize);
            var totalProducts = _productService.GetTotalProducts();

            var response = new
            {
                TotalCount = totalProducts,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Products = products
            };

            return Ok(response);
        }

    }
}

