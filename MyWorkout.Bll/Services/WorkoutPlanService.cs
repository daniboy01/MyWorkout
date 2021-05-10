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
        private readonly ExerciseService exerciseService;

        public MyWorkoutDbContext DbContext { get; }

        public WorkoutPlanService( MyWorkoutDbContext dbContext, ExerciseService exerciseService )
        {
            DbContext = dbContext;
            this.exerciseService = exerciseService;
        }

        public async Task<WorkoutPlan> GetByIdAsync(int id)
        {
            var entity = await DbContext.WorkoutPlans.Include(w => w.WorkoutExercise).Where(w => w.Id == id).FirstAsync();

            return entity;
        }

        public IEnumerable<WorkoutPlanDto> GetUsersWorkouts(int userId)
        {
            var usersWorkouts = DbContext.WorkoutPlans.Where(w => w.UserId == userId).Select(w => new WorkoutPlanDto
            {
                Id = w.Id,
                Title = w.Title,
                Description = w.Description,
                UserId = userId,
                CategoryId = w.CategoryId,
                UserName = w.User.UserName,
                CategoryName = w.Category.Name
            }).ToList();
            return usersWorkouts;
        }

        public string GetUserNameFromWorkout(int id)
        {
            var workout = DbContext.WorkoutPlans.Where(w => w.Id == id).First();
            var userName = DbContext.Users.Where(u => u.Id == workout.UserId).First().UserName;
            if(userName == null)
            {
                userName = "user";
            }
            return userName;
        }

        public async Task<List<ExerciseDto>> GetExercisesFromWorkoutPlan(int workoutId)
        {
            //TODO ne mindet töltsem be, szűrni kell
            var allExercise = DbContext.Exercises.ToList();

            var workout = await DbContext.WorkoutPlans.FirstAsync(w => w.Id == workoutId);

            var exerciseLIst = workout.WorkoutExercise;

            var exercises = workout.WorkoutExercise.Select(e => new ExerciseDto
            {
                Id = e.ExerciseId,
                Title = e.Exercise.Title,
                Description = e.Exercise.Description,
                WorkoutPlanId = workoutId
            }).ToList();

            return exercises;
        }

        public CommentDto CreateNewComment(CommentDto newComment)
        {
            var workout = DbContext.WorkoutPlans.Where(w => w.Id == newComment.WorkoutId).FirstOrDefault();
            var commentToSave = new Comment
            {
                Text = newComment.Text,
                UserID = newComment.UserId,
                WorkoutPlanId = newComment.WorkoutId,
                CreatedAt = DateTime.Now,

            };
            //workout.Comments.Add(commentToSave);
            commentToSave.WorkoutPlan = workout;

            DbContext.Comments.Add(commentToSave);
            DbContext.SaveChanges();

            newComment.Id = commentToSave.Id;
            return newComment;
        }

        public WorkoutPlanDto EditWorkout(WorkoutPlan workoutPlan, int[] selectedExercises, int categoryId)
        {
            WorkoutPlan workoutPlantoEdit = DbContext.WorkoutPlans.Where(w => w.Id == workoutPlan.Id).FirstOrDefault();
            var exercises = DbContext.Exercises.Where(e => selectedExercises.Contains(e.Id));

            if(selectedExercises.Length != 0)
            {
                foreach (var exercise in exercises)
                {
                    exercise.WorkoutExercise.Add(new WorkoutExercise
                    {
                        Exercise = exercise,
                        ExerciseId = exercise.Id,
                        WorkoutPlan = workoutPlantoEdit,
                        WorkoutPlanId = workoutPlantoEdit.Id
                    });
                }
            }

            workoutPlantoEdit.Title = workoutPlan.Title;
            workoutPlantoEdit.Description = workoutPlan.Description;
            workoutPlantoEdit.CategoryId = categoryId;

            DbContext.SaveChanges();

            return new WorkoutPlanDto
            {
                Id = workoutPlantoEdit.Id,
                Title = workoutPlantoEdit.Title,
                Description = workoutPlantoEdit.Description,
                UserId = workoutPlantoEdit.UserId,
                CategoryId = workoutPlantoEdit.CategoryId,
                UserName = workoutPlantoEdit.User.UserName,
                CategoryName = workoutPlantoEdit.Category.Name
            };

        }

        public  PagedResult<WorkoutPlanDto> GetWorkouts( WorkoutPlanSpecification specification = null )
        {
            specification ??= new WorkoutPlanSpecification();

            if (specification.PageSize <= 0)
                specification.PageSize = 50;
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

        public async Task<WorkoutPlanDto> AddNewWorkoutAsync(WorkoutPlanDto dto, int userId)
        {
            var workoutToSave = new WorkoutPlan
            {
                Title = dto.Title,
                Description = dto.Description,
            };

            var user = DbContext.Users.Where(u => u.Id == userId).FirstOrDefault();

            workoutToSave.User = user;
            workoutToSave.UserId = user.Id;
            await DbContext.WorkoutPlans.AddAsync(workoutToSave);
            DbContext.SaveChanges();

            dto.Id = workoutToSave.Id;

            return dto;
        }
    }
}
