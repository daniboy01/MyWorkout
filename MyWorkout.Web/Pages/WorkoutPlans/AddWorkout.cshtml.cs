using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class AddWorkoutModel : PageModel
    {
        private readonly WorkoutPlanService workoutPlanService;

        public AddWorkoutModel( WorkoutPlanService workoutPlanService )
        {
            this.workoutPlanService = workoutPlanService;
        }

        public void OnGet()
        {

        }

        [BindProperty]
        public WorkoutPlanDto WorkoutPlan { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await workoutPlanService.AddNewWorkoutAsync(WorkoutPlan);
            return new RedirectToPageResult("/WorkoutPlans/Index");
        }
    }
}
