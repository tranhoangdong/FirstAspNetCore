using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eShopSolution.Data.Entities;
using eShopSolution.Application;

namespace eShopSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryTranslationController : ControllerBase
    {
        private readonly ICategoryTranslationService _categoryTranslationService;

        public CategoryTranslationController(ICategoryTranslationService categoryTranslationService)
        {
            _categoryTranslationService = categoryTranslationService;
        }

        [HttpGet("GetAllCategoryTranslations")]
        public async Task<IActionResult> GetAllCategoryTranslations()
        {
            var categoryTranslations = await _categoryTranslationService.GetAllCategoryTranslations();
            return Ok(categoryTranslations);
        }

        [HttpGet("GetCategoryTranslationById/{id}")]
        public async Task<IActionResult> GetCategoryTranslationById(int id)
        {
            var categoryTranslation = await _categoryTranslationService.GetCategoryTranslationById(id);
            if (categoryTranslation == null)
            {
                return NotFound();
            }
            return Ok(categoryTranslation);
        }

        [HttpPut("EditCategoryTranslation/{id}")]
        public async Task<IActionResult> EditCategoryTranslation(int id, [FromBody] CategoryTranslation categoryTranslation)
        {
            if (id != categoryTranslation.Id)
            {
                return BadRequest();
            }

            var existingCategoryTranslation = await _categoryTranslationService.GetCategoryTranslationById(id);
            if (existingCategoryTranslation == null)
            {
                return NotFound();
            }

            await _categoryTranslationService.UpdateCategoryTranslation(categoryTranslation);
            return NoContent();
        }

        [HttpDelete("DeleteCategoryTranslation/{id}")]
        public async Task<IActionResult> DeleteCategoryTranslation(int id)
        {
            var categoryTranslationToDelete = await _categoryTranslationService.GetCategoryTranslationById(id);
            if (categoryTranslationToDelete == null)
            {
                return NotFound();
            }

            await _categoryTranslationService.DeleteCategoryTranslation(id);
            return NoContent();
        }
    }
}
