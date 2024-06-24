using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public interface IStudentService
    {

        List<Product> SearchProductByProductName(string ProductName);
    }
}
