using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Ganss.XSS;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;
using MyWorkout.Dal.Entities;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class EditModel : PageModel
    {
        private readonly WorkoutPlanService workoutPlanService;
        private readonly ExerciseService exerciseService;
        private readonly CategoryService categoryService;


        public EditModel( WorkoutPlanService workoutPlanService, ExerciseService exerciseService, CategoryService categoryService)
        {
            this.workoutPlanService = workoutPlanService;
            this.exerciseService = exerciseService;
            this.categoryService = categoryService;
           
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public WorkoutPlan WorkoutPlan  { get; set; }
        public IEnumerable<SelectListItem> Exercises { get; set; }
        [BindProperty]
        public int[] SelectedExercises { get; set; }
        [BindProperty]
        public int SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }



        public async Task<IActionResult> OnGet()
        {
            WorkoutPlan = await workoutPlanService.GetByIdAsync(Id);
            var userClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(userClaim != null)
            {
                var userId = int.Parse(userClaim);
                if (WorkoutPlan.Id != userId)
                    return RedirectToPage("/WorkoutPlans/Index");
            }

            

            Exercises =exerciseService.GetAllExerciseItemAsync();
            Categories = await categoryService.GetCategoryItems();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                WorkoutPlan.Id = Id;
                workoutPlanService.EditWorkout(WorkoutPlan, SelectedExercises, SelectedCategory);

                return RedirectToPage("/WorkoutPlans/Details", new { id = Id });
            }
            return RedirectToPage("/WorkoutPlans/Details", new { id = Id });

        }
    }
}
