using Microsoft.EntityFrameworkCore;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Specifications;
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

        public async Task<List<ExerciseDto>> GetExercisesFromWorkoutPlan(int workoutId)
        {
            var workout = await DbContext.WorkoutPlans.FirstAsync(w => w.Id == workoutId);
            var exercises = workout.Exercises.Select(e => new ExerciseDto
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                WorkoutPlanId = e.WorkoutPlanId
            }).ToList();

            return exercises;
        }

        public  PagedResult<WorkoutPlanDto> GetWorkouts( WorkoutPlanSpecification specification = null )
        {
            specification ??= new WorkoutPlanSpecification();

            if (specification.PageSize <= 0)
                specification.PageSize = 10;
            if (specification.PageNumber <= 0)
                specification.PageNumber = 1;

            IQueryable<WorkoutPlan> query = DbContext.WorkoutPlans;

            int allResultsCount = query.Count();

            query = query
                .Skip( (specification.PageNumber - 1) * specification.PageSize )
                .Take( specification.PageSize );

            if( specification.CategoryId != null)
            {
                query = query.Where(w => w.CategoryId == specification.CategoryId);
            }

            switch (specification.Order)
            {
                case WorkoutPlanSpecification.PlanOrder.TitleAscending:
                    query = query.OrderBy(w => w.Title);
                    break;
                case WorkoutPlanSpecification.PlanOrder.TitleDescending:
                    query = query.OrderByDescending(w => w.Title);
                    break;
            }
                

            var workouts = query
                .Select(w => new WorkoutPlanDto
                {
                    Id = w.Id,
                    Title = w.Title,
                    Description = w.Description,
                    UserId = w.UserId,
                    CategoryId = w.CategoryId,
                    UserName = w.User.DisplayName,
                    CategoryName = w.Category.Name
                }).ToList();

            return new PagedResult<WorkoutPlanDto>
            {
                AllResultsCount = allResultsCount,
                PageNumber = specification.PageNumber,
                PageSize = specification.PageSize,
                Results = workouts
            };
        }

        public async Task<WorkoutPlanDto> AddNewWorkoutAsync(WorkoutPlanDto dto)
        {
            var workoutToSave = new WorkoutPlan
            {
                Title = dto.Title,
                Description = dto.Description,
            };

            await DbContext.WorkoutPlans.AddAsync(workoutToSave);
            DbContext.SaveChanges();

            dto.Id = workoutToSave.Id;

            return dto;
        }
    }
}
