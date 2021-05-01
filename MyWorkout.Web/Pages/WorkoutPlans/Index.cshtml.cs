using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyWorkout.Dal;
using MyWorkout.Dal.Entities;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class IndexModel : PageModel
    {
        public IReadOnlyCollection<Exercise> Exercises { get; set; }
        public IReadOnlyCollection<WorkoutPlan> WorkoutPlans { get; set; }
        public IReadOnlyCollection<Category> Categories { get; set; }

        public void OnGet([FromServices] MyWorkoutDbContext dbcontext)
        {
            Exercises = dbcontext.Exercises.ToList();
            WorkoutPlans = dbcontext.WorkoutPlans.ToList();
            Categories = dbcontext.Categories.ToList();
        }
    }
}
