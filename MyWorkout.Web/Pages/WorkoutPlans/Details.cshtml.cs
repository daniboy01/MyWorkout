using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWorkout.Bll.Services;
using MyWorkout.Dal.Entities;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class DetailsModel : PageModel
    {
        public WorkoutPlanService WorkoutPlanService { get; set; }

        public DetailsModel(WorkoutPlanService workoutPlanService)
        {
            WorkoutPlanService = workoutPlanService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; }

        public async Task<IActionResult> OnGet()
        {
            WorkoutPlan = await WorkoutPlanService.GetByIdAsync(Id);

            return Page();
        }
    }
}
