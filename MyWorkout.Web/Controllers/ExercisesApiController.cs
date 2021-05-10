using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWorkout.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkout.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesApiController : ControllerBase
    {
        public WorkoutPlanService WorkoutPlanService { get; }

        public ExercisesApiController(WorkoutPlanService workoutPlanService)
        {
            WorkoutPlanService = workoutPlanService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercisesFromWorkout(int id)
        {
            var workout = await WorkoutPlanService.GetByIdAsync(id);

            if(workout == null)
            {
                return NotFound();
            }

            var exercises = await WorkoutPlanService.GetExercisesFromWorkoutPlan(id);

            return Ok(exercises);
        }
    }
}
