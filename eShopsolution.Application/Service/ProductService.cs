using eShopsolution.Data.EF;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly EShopDbContext _eShopDbContext;

        public ProductService(EShopDbContext eShopDbContext)
        {
            _eShopDbContext = eShopDbContext;
        }

        public List<Product> GetAllProducts()
        {
            return _eShopDbContext.Products.ToList();
        }
        public Product GetProductbyID(int productId)
        {
            return _eShopDbContext.Products.FirstOrDefault(x => x.ID == productId);
        }
        public void AddProduct(Product product)
        {
            _eShopDbContext.Products.Add(product);
            _eShopDbContext.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            var productDTO = _eShopDbContext.Products.Find(product.ID);
                if(productDTO != null)
                {
                productDTO.ID = product.ID;
                productDTO.Name = product.Name;
                productDTO.Price = product.Price;
                productDTO.Stock = product.Stock;
                _eShopDbContext.SaveChanges();
            }
            
        }
        public void DeleteProduct(int productId) 
        {
            var product = _eShopDbContext.Products.FirstOrDefault(x => x.ID == productId);
            {
                if (product != null)
                    _eShopDbContext.Products.Remove(product);
                _eShopDbContext.SaveChanges();
            }
        }

        public IEnumerable<Product> GetPagedProducts(int pageNumber, int pageSize)
        {
            return _eShopDbContext.Products
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
        public int GetTotalProducts()
        {
            return _eShopDbContext.Products.Count();
        }
    }

}
