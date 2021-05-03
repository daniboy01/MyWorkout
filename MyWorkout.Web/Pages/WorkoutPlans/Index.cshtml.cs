using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;
using MyWorkout.Bll.Specifications;
using MyWorkout.Dal;
using MyWorkout.Dal.Entities;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class IndexModel : PageModel
    {
        public WorkoutPlanService WorkoutPlanService { get; }

        public IndexModel( WorkoutPlanService workoutPlanService )
        {
            WorkoutPlanService = workoutPlanService;
        }

        [BindProperty(SupportsGet = true)]
        public WorkoutPlanSpecification Specification { get; set; }
        public PagedResult<WorkoutPlanDto> WorkoutPlans { get; set; }

        public void OnGet()
        {
            WorkoutPlans = WorkoutPlanService.GetWorkouts(Specification);
        }
    }
}
