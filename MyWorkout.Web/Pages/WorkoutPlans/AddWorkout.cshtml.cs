using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;
using MyWorkout.Web.Helpers;
using MyWorkout.Web.Models;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class AddWorkoutModel : PageModel
    {
        private readonly WorkoutPlanService workoutPlanService;
        private readonly ExerciseService exerciseService;

        public AddWorkoutModel( WorkoutPlanService workoutPlanService, ExerciseService exerciseService )
        {
            this.workoutPlanService = workoutPlanService;
            this.exerciseService = exerciseService;
        }

        [BindProperty]
        public WorkoutPlanDto WorkoutPlan { get; set; }
      
        [BindProperty]
        public ExerciseDto ExerciseDto { get; set; }

        public IEnumerable<ExerciseDto> Exercises { get; set; }
        public void OnGet()
        {
            Exercises = exerciseService.GetAllExerciseAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await workoutPlanService.AddNewWorkoutAsync(WorkoutPlan, userId);
            return new RedirectToPageResult("/WorkoutPlans/Index");
        }

    }
}
