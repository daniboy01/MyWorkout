using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;
using MyWorkout.Dal.Entities;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class EditModel : PageModel
    {
        private readonly WorkoutPlanService workoutPlanService;
        private readonly ExerciseService exerciseService;

        public EditModel( WorkoutPlanService workoutPlanService, ExerciseService exerciseService )
        {
            this.workoutPlanService = workoutPlanService;
            this.exerciseService = exerciseService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public WorkoutPlan WorkoutPlan  { get; set; }
        public SelectList Exercises { get; set; }
        [BindProperty]
        public int[] SelectedExercises { get; set; }


        public async void OnGet()
        {
            WorkoutPlan = await workoutPlanService.GetByIdAsync(Id);
            Exercises = new SelectList(exerciseService.GetAllExerciseAsync(), nameof(ExerciseDto.Id), nameof(ExerciseDto.Title));
        }

        public IActionResult OnPost()
        {
            WorkoutPlan.Id = Id;
            workoutPlanService.EditWorkout(WorkoutPlan, SelectedExercises);
            return RedirectToPage("/WorkoutPlans/Index");
        }
    }
}
