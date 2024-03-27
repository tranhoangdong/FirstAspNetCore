using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application
{
    public interface ICategoryTranslationService
    {
        Task<List<CategoryTranslation>> GetAllCategoryTranslations();
        Task<CategoryTranslation> GetCategoryTranslationById(int id);
        Task CreateCategoryTranslation(CategoryTranslation categoryTranslation);
        Task UpdateCategoryTranslation(CategoryTranslation categoryTranslation);
        Task DeleteCategoryTranslation(int id);
    }
}
