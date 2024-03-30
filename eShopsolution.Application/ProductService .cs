using eShopsolution.Data.EF;

using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application
{
    public class ProductService : IProductService
    {
        private readonly EShopDbContext _context;

        public ProductService(EShopDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return  _context.Products.Find(id);
        }

        public async Task CreateProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            var productInDb = await _context.Products.FindAsync(product.Id);
            if (productInDb != null)
            {
     
                productInDb.Price = product.Price;
                productInDb.OriginalPrice = product.OriginalPrice;
                productInDb.Stock = product.Stock;
                productInDb.ViewCount = product.ViewCount;
                productInDb.DateCreated = product.DateCreated;
                productInDb.IsFeatured = product.IsFeatured;

                await _context.SaveChangesAsync();
            }
        }

        public DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
