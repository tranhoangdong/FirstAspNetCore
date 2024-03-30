using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
