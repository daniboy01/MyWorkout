using Microsoft.EntityFrameworkCore;
using MyWorkout.Bll.Dto;
using MyWorkout.Dal;
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
        public CategoryService( MyWorkoutDbContext dbContext)
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
        
    }
}
