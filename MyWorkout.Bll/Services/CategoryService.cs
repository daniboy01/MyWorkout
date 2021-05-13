using Microsoft.EntityFrameworkCore;
using MyWorkout.Bll.Dto;
using MyWorkout.Dal;
using MyWorkout.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkout.Bll.Services
{
    public class CategoryService
    {
        public MyWorkoutDbContext DbContext { get; }
        public CategoryService(MyWorkoutDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<CategoryHeader>> GetCategories()
        {
            var categories = await DbContext.Categories.Select(c => new CategoryHeader
            {
                Id = c.Id,
                Name = c.Name
            }
            ).ToListAsync();

            return categories;
        }

        public async Task AddOrUpdateCategory(CategoryHeader categoryHeader)
        {

            if(categoryHeader.Id == 0)
            {
                Category newCategory = new Category
                {
                    Name = categoryHeader.Name,
                    ParentCategoryId = categoryHeader.ParentCategoryId,
                };

                await DbContext.AddAsync(newCategory);
                await DbContext.SaveChangesAsync();
            }
            else
            {
                var category = DbContext.Categories.Single(c => c.Id == categoryHeader.Id);

                category.Name = categoryHeader.Name;
                category.ParentCategoryId = categoryHeader.ParentCategoryId;

                await DbContext.SaveChangesAsync();

            }
        }

        public async Task DeleteCategory( int categoryId)
        {
            DbContext.Categories.Remove(new Category { Id = categoryId });

            await DbContext.SaveChangesAsync();

        }
    }
}
