using eShopsolution.Data.EF;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Service
{
    public class ImageService : IImageService
    {
        private readonly EShopDbContext _eShopDbContext;

        public ImageService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }
        public async Task<Image> SaveImageAsync(IFormFile file, string name, int productId)
        {
            byte[] fileData;
            using (var stream = new System.IO.MemoryStream())
            {
                await file.CopyToAsync(stream);
                fileData = stream.ToArray();
            }

            var image = new Image
            {
                ProductId = productId,
                Name = name,
                ContentType = file.ContentType,
                Data = fileData
            };

            _eShopDbContext.Images.Add(image);
            await _eShopDbContext.SaveChangesAsync();

            return image;
        }
        public async Task<Image> GetImageByIdAsync(int id)
        {
            return await _eShopDbContext.Images.FindAsync(id);
        }
        public async Task<IEnumerable<Image>> GetImagesByProductIdAsync(int productId)
        {
            return _eShopDbContext.Images.Where(img => img.ProductId == productId).ToList();
        }
        public async Task<Image> UpdateImageAsync(int id, IFormFile file, string name, int productId)
        {
            var existingImage = await _eShopDbContext.Images.FindAsync(id);
            if (existingImage == null)
                return null;

            if (file != null && file.Length > 0)
            {
                using (var stream = new System.IO.MemoryStream())
                {
                    await file.CopyToAsync(stream);
                    existingImage.Data = stream.ToArray();
                    existingImage.ContentType = file.ContentType;
                }
            }

            existingImage.Name = name;
            existingImage.ProductId = productId;

            await _eShopDbContext.SaveChangesAsync();

            return existingImage;
        }
        public async Task<bool> DeleteImageAsync(int id)
        {
            var image = await _eShopDbContext.Images.FindAsync(id);
            if (image == null)
                return false;

            _eShopDbContext.Images.Remove(image);
            await _eShopDbContext.SaveChangesAsync();

            return true;
        }
    }

}
