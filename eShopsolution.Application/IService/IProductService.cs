using eShopSolution.Application.Dtos;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
   public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductbyID(int productId);
        public void DeleteProduct(int productId);
        Task<bool> UpdateProductAsync(int id, ProductDTO productDto);
        public IEnumerable<Product> GetPagedProducts(int pageNumber, int pageSize);
        public int GetTotalProducts();
        Task<Product> AddProductAsync(Product product);
        Task<List<ProductDTO>> GetProductImageAsync();
    }
}
