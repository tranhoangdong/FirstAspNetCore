using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eShopSolution.Data.Entities;
using System;
using eShopSolution.Application;

namespace eShopSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("GetCategoryByIdCuaThangDong/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
      
        [HttpPut("EditCategory/{id}")]
        public async Task<IActionResult> EditCategory(int id, [FromBody] Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var existingCategory = await _categoryService.GetCategoryById(id);
            if (existingCategory == null)
            {
                return NotFound();
            }

            await _categoryService.UpdateCategory(category);
            return NoContent();
        }
        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var categoryToDelete = await _categoryService.GetCategoryById(id);
            if (categoryToDelete == null)
            {
                return NotFound();
            }

            await _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
