using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using eShopSolution.Application.IService;
using eShopsolution.Data.EF;
using Microsoft.AspNetCore.Http;

namespace eShopSolution.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile file, [FromForm] string name, [FromForm] int productId)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            var image = await _imageService.SaveImageAsync(file, name, productId);
            return Ok(new { image.ID, image.Name });
        }
       

        [HttpGet("GetImage/{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _imageService.GetImageByIdAsync(id);
            if (image == null)
                return NotFound();

            //return /*File(image.Data, image.ContentType, image.Name);*/
            return Ok(new { image.ID, image.ProductId });
        }

        [HttpGet("product/{productId}")]
        public async Task<IActionResult> GetImagesByProductId(int productId)
        {
            var images = await _imageService.GetImagesByProductIdAsync(productId);
            return Ok(images);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImage(int id, IFormFile file, [FromForm] string name, [FromForm] int productId)
        {
            var image = await _imageService.UpdateImageAsync(id, file, name, productId);
            if (image == null)
                return NotFound();

            return Ok(new { image.ID, image.Name });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var result = await _imageService.DeleteImageAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }



    }
}

