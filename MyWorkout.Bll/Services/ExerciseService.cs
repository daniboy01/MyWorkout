using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ExerciseService
    {
        public MyWorkoutDbContext DbContext { get; }
        public ExerciseService( MyWorkoutDbContext dbContext )
        {
            DbContext = dbContext;
        }

        public List<ExerciseDto> GetAllExerciseAsync()
        {
            var exercises =  DbContext.Exercises.Select(e => new ExerciseDto 
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description
            }
            ).ToList();

            return exercises;
        }
    }
}
