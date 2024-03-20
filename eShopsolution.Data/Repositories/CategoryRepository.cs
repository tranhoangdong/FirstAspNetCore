using eShopsolution.Data.EF;

using eShopSolution.Data.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eShopSolution.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EShopDbContext _context;

        public CategoryRepository(EShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
