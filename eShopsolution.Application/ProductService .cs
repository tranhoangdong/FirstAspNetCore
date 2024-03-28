using eShopsolution.Data.EF;

using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
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

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
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

        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
