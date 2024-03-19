﻿using eShopSolution.Data.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShopSolution.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task CreateCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
