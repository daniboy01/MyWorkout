using Microsoft.EntityFrameworkCore;
using MyWorkout.Dal;
using MyWorkout.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkout.Bll.Services
{
    public class WorkoutPlanService
    {
        public MyWorkoutDbContext DbContext { get; }

        public WorkoutPlanService( MyWorkoutDbContext dbContext )
        {
            DbContext = dbContext;
        }

        public async Task<WorkoutPlan> GetByIdAsync(int id)
        {
            var entity = await DbContext.WorkoutPlans.Include(w => w.Exercises).Where(w => w.Id == id).FirstAsync();

            return entity;
        }
    }
}
