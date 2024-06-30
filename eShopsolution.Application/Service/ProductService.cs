using eShopsolution.Data.EF;

using eShopSolution.Application.Dtos;
using eShopSolution.Application.IService;
using eShopSolution.Data.Entities;

using Microsoft.AspNetCore.Mvc;
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
        public async Task<Product> AddProductAsync(Product product)
        {
            _eShopDbContext.Products.Add(product);
           await  _eShopDbContext.SaveChangesAsync();
            return product;
        }
        public async Task<bool> UpdateProductAsync(int id, ProductDTO productDto)
        {
            var existingProduct = await _eShopDbContext.Products.FindAsync(id);
            if (existingProduct == null)
            {
                return false;
            }

            existingProduct.Name = productDto.Name;
            existingProduct.Price = productDto.Price;
            existingProduct.Stock = productDto.Stock;

            _eShopDbContext.Products.Update(existingProduct);
            await _eShopDbContext.SaveChangesAsync();

            return true;
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

        public async Task<List<ProductDTO>> GetProductImageAsync()
        {
            var products = await _eShopDbContext.Products
                .Include(p => p.Images)
                .ToListAsync();

            var productDTOs = products.Select(p => new ProductDTO
            {
                
                Name = p.Name,
                Price = p.Price,
                Stock = p.Stock,
                Images = p.Images.Select(i => new ImageDTO
                {
                    ID = i.ID,
                    Name = i.Name,
                    ProductId = i.ProductId,
                    ContentType = i.ContentType
                }).ToList()
            }).ToList();

            return productDTOs;
        }

    }

}
