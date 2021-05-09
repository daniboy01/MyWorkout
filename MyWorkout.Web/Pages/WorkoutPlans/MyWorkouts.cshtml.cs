using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class MyWorkoutsModel : PageModel
    {
        private readonly WorkoutPlanService workoutPlanService;

        public MyWorkoutsModel( WorkoutPlanService workoutPlanService )
        {
            this.workoutPlanService = workoutPlanService;
        }

        public IEnumerable<WorkoutPlanDto> MyWorkouts { get; set; }

        public void OnGet()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            MyWorkouts = workoutPlanService.GetUsersWorkouts(userId);
        }
    }
}
