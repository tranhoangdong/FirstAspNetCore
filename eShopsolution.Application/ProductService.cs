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

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var productInDb = _context.Products.Find(product.Id);
            if (productInDb != null)
            {
     
                productInDb.Price = product.Price;
                productInDb.OriginalPrice = product.OriginalPrice;
                productInDb.Stock = product.Stock;
                productInDb.ViewCount = product.ViewCount;
                productInDb.DateCreated = product.DateCreated;
                productInDb.IsFeatured = product.IsFeatured;
                productInDb.Descreption = product.Descreption;
                productInDb.CategoryId = product.CategoryId;
                


                _context.SaveChanges();
            }
        }


        public void DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return _context.Products.Where(x => x.CategoryId == categoryId).ToList();


        }
    }
}
