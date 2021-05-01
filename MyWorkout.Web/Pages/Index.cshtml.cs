using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyWorkout.Dal;
using MyWorkout.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkout.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


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
