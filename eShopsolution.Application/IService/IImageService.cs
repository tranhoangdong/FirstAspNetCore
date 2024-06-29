using eShopSolution.Data.Entities;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
   public interface IImageService
    {
        Task<Image> SaveImageAsync(IFormFile file, string name, int productId);
        Task<Image> GetImageByIdAsync(int id);
        Task<IEnumerable<Image>> GetImagesByProductIdAsync(int productId);
        Task<Image> UpdateImageAsync(int id, IFormFile file, string name, int productId);
        Task<bool> DeleteImageAsync(int id);
    }
}
