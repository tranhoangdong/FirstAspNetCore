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
        public void UpdateProduct(Product product);
        public void DeleteProduct(int productId);
        public IEnumerable<Product> GetPagedProducts(int pageNumber, int pageSize);
        public int GetTotalProducts();
    }
}
