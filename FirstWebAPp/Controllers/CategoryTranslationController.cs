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
        public IActionResult GetAllCategoryTranslations()
        {
            var categoryTranslations = _categoryTranslationService.GetAllCategoryTranslations();
            return Ok(categoryTranslations);
        }

        [HttpGet("GetCategoryTranslationById/{id}")]
        public IActionResult GetCategoryTranslationById(int id)
        {
            var categoryTranslation = _categoryTranslationService.GetCategoryTranslationById(id);
            if (categoryTranslation == null)
            {
                return NotFound();
            }
            return Ok(categoryTranslation);
        }

        [HttpPut("EditCategoryTranslation/{id}")]
        public IActionResult EditCategoryTranslation(int id, [FromBody] CategoryTranslation categoryTranslation)
        {
            if (id != categoryTranslation.Id)
            {
                return BadRequest();
            }

            var existingCategoryTranslation = _categoryTranslationService.GetCategoryTranslationById(id);
            if (existingCategoryTranslation == null)
            {
                return NotFound();
            }

            _categoryTranslationService.UpdateCategoryTranslation(categoryTranslation);
            return NoContent();
        }

        [HttpDelete("DeleteCategoryTranslation/{id}")]
        public IActionResult DeleteCategoryTranslation(int id)
        {
            var categoryTranslationToDelete = _categoryTranslationService.GetCategoryTranslationById(id);
            if (categoryTranslationToDelete == null)
            {
                return NotFound();
            }

            _categoryTranslationService.DeleteCategoryTranslation(id);
            return NoContent();
        }
    }
}
