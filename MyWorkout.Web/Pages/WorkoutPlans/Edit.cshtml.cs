using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public SelectList Exercises { get; set; }
        [BindProperty]
        public int[] SelectedExercises { get; set; }
        [BindProperty]
        public int SelectedCategory { get; set; }
        public SelectList Categories { get; set; }



        public async Task<IActionResult> OnGet()
        {
            WorkoutPlan = await workoutPlanService.GetByIdAsync(Id);
            Exercises = new SelectList(exerciseService.GetAllExerciseAsync(), nameof(ExerciseDto.Id), nameof(ExerciseDto.Title));
            Categories = new SelectList(await categoryService.GetCategories(), nameof(Category.Id), nameof(Category.Name));
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            

            WorkoutPlan.Id = Id;
            workoutPlanService.EditWorkout(WorkoutPlan, SelectedExercises, SelectedCategory);

            return RedirectToPage("/WorkoutPlans/Index");
        }
    }
}
