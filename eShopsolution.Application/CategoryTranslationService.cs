using eShopsolution.Data.EF;

using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
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

        public async Task<List<CategoryTranslation>> GetAllCategoryTranslations()
        {
            return await _context.CategoryTranslations.ToListAsync();
        }

        public async Task<CategoryTranslation> GetCategoryTranslationById(int id)
        {
            return await _context.CategoryTranslations.FindAsync(id);
        }

        public async Task CreateCategoryTranslation(CategoryTranslation categoryTranslation)
        {
            _context.CategoryTranslations.Add(categoryTranslation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryTranslation(CategoryTranslation categoryTranslation)
        {
            var translationInDb = await _context.CategoryTranslations.FindAsync(categoryTranslation.Id);
            if (translationInDb != null)
            {
                translationInDb.Name = categoryTranslation.Name;
                translationInDb.SeoDescription = categoryTranslation.SeoDescription;
                translationInDb.SeoTitle = categoryTranslation.SeoTitle;
                translationInDb.LanguageId = categoryTranslation.LanguageId;
                translationInDb.SeoAlias = categoryTranslation.SeoAlias;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteCategoryTranslation(int id)
        {
            var translation = await _context.CategoryTranslations.FindAsync(id);
            if (translation != null)
            {
                _context.CategoryTranslations.Remove(translation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
