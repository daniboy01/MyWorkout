using MyWorkout.Bll.Dto;
using MyWorkout.Dal;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<ExerciseDto>> GetAllExerciseAsync()
        {
            var exercise = DbContext.Exercises.
        }
    }
}
