using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application
{
    public interface IStudentService
    {
       
        List<Product> SearchProductByProductName(string ProductName);
    }
}
