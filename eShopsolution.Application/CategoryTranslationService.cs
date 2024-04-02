using eShopsolution.Data.EF;

using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Application
{
    public class CategoryTranslationService : ICategoryTranslationService
    {
        private readonly EShopDbContext _context;

        public CategoryTranslationService(EShopDbContext context)
        {
            _context = context;
        }


        public List<CategoryTranslation> GetAllCategoryTranslations()
        {
            return _context.CategoryTranslations.ToList();
        }

        public CategoryTranslation GetCategoryTranslationById(int id)
        {
            return _context.CategoryTranslations.Find(id);
        }

        public void CreateCategoryTranslation(CategoryTranslation categoryTranslation)
        {
            _context.CategoryTranslations.Add(categoryTranslation);
            _context.SaveChanges();
        }

        public void UpdateCategoryTranslation(CategoryTranslation categoryTranslation)
        {
            var translationInDb = _context.CategoryTranslations.Find(categoryTranslation.Id);
            if (translationInDb != null)
            {
                translationInDb.Name = categoryTranslation.Name;
                translationInDb.SeoDescription = categoryTranslation.SeoDescription;
                translationInDb.SeoTitle = categoryTranslation.SeoTitle;
                translationInDb.LanguageId = categoryTranslation.LanguageId;
                translationInDb.SeoAlias = categoryTranslation.SeoAlias;

               _context.SaveChanges();
            }
        }

        public void DeleteCategoryTranslation(int id)
        {
            var translation = _context.CategoryTranslations.Find(id);
            if (translation != null)
            {
                _context.CategoryTranslations.Remove(translation);
                _context.SaveChanges();
            }
        }

    }
}
