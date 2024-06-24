using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Application.IService
{
    public interface ICategoryTranslationService
    {
        List<CategoryTranslation> GetAllCategoryTranslations();
        CategoryTranslation GetCategoryTranslationById(int id);
        void CreateCategoryTranslation(CategoryTranslation categoryTranslation);
        void UpdateCategoryTranslation(CategoryTranslation categoryTranslation);
        void DeleteCategoryTranslation(int id);
    }
}
