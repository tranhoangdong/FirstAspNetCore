using eShopsolution.Data.EF;

using eShopSolution.Data.EF;
using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application
{
    public class StudentService : IStudentService
    {
        private readonly EShopDbContext _context;

        public StudentService(EShopDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public List<Product> SearchProductByProductName(string ProductName)
        {
            throw new System.NotImplementedException();
        }
    }
}
