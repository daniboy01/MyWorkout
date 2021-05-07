using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
        public int ChoosenExerciseId { get; set; }

        public IEnumerable<ExerciseDto> Exercises { get; set; }

        public void OnGet()
        {
            Exercises = exerciseService.GetAllExerciseAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            await workoutPlanService.AddNewWorkoutAsync(WorkoutPlan);
            return new RedirectToPageResult("/WorkoutPlans/Index");
        }

        public void AddToWorkout(int id)
        {
            //var exercises = HttpContext.Session.Get<List<ExerciseModel>>("Execises");
            //if (exercises == null)
            //    exercises = new List<ExerciseModel>();

            var exercise = new ExerciseModel
            {
                Id = id
            };
        }
    }
}
