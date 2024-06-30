using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using eShopSolution.Application.IService;
using eShopsolution.Data.EF;
using eShopSolution.Application.Dtos;

namespace eShopSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly EShopDbContext _eShopDbContext;

        public ProductController(IProductService productService, EShopDbContext eShopDbContext)
        {
            _productService = productService;
            _eShopDbContext = eShopDbContext;
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
        public async Task<IActionResult> EditProduct(int id, [FromBody] ProductDTO productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Product data is null");
            }

            bool isUpdated = await _productService.UpdateProductAsync(id, productDto);

            if (!isUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
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
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDto)
        {
           if (productDto == null) { return BadRequest() ; }
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Stock = productDto.Stock,
            };
           var createProduct = await _productService.AddProductAsync(product);
            return Ok(createProduct);
            

        }
        [HttpGet("GetProductImage")]
        public async Task<IActionResult> GetProductImage([FromQuery] string language ="a" )
        {

            var productImages = await _productService.GetProductImageAsync();
            if (productImages == null)
            {
                return null;
            }
            return Ok(productImages);
           
        }
    }
}


