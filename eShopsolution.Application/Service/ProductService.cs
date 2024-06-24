using eShopsolution.Data.EF;
using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application.Service
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
            return _context.Products.Find(id);
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
                productInDb.Description = product.Description;
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

        public List<Product> GetProductByCategory(int categoryId)
        {
            return _context.Products.Where(x => x.CategoryId == categoryId).ToList();


        }
        public List<Product> SearchProductByProductName(string ProductName)
        {
            return _context.Products.Where(x => x.ProductName == ProductName).ToList();


        }

        public ProductDto GetProductDetailDtoByProductId(int productId)
        {
            //  var testProduct = _context.Products.Include(x=>x.Category).Where(x => x.Id == productId).FirstOrDefault();
            var product = _context.Products.Include(x => x.Category).Where(x => x.Id == productId)
                .Select(x => new ProductDto
                {
                    CategoryId = x.CategoryId.Value,
                    Id = x.Id,
                    ProductName = x.ProductName,
                    Status = x.Category.Status,
                }).FirstOrDefault();
            //  var category = _context.Categories.Where(x => x.Id == product.CategoryId).FirstOrDefault();
            //var result = new ProductDto
            //{
            //    CategoryId = product.CategoryId,
            //    Id = product.Id,
            //    Status = category.Status,
            //    ProductName = product.ProductName
            //};
            return product;

        }
    }
}
