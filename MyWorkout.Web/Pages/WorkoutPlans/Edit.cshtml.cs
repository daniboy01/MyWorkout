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
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;
        private readonly long fileSizeLimit;
        private List<string> permittedExtensions;

        public EditModel( WorkoutPlanService workoutPlanService, ExerciseService exerciseService, CategoryService categoryService, IConfiguration config, IWebHostEnvironment env)
        {
            this.workoutPlanService = workoutPlanService;
            this.exerciseService = exerciseService;
            this.categoryService = categoryService;
            this.config = config;
            this.env = env;
            this.fileSizeLimit = config.GetValue<long>("FileSizeLimit");
            this.permittedExtensions = config.GetSection("PemittedExtensions").Get<List<string>>();
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
        [BindProperty]
        public IFormFile CoverImage { get; set; }


        public async Task<IActionResult> OnGet()
        {
            WorkoutPlan = await workoutPlanService.GetByIdAsync(Id);
            Exercises = new SelectList(exerciseService.GetAllExerciseAsync(), nameof(ExerciseDto.Id), nameof(ExerciseDto.Title));
            Categories = new SelectList(await categoryService.GetCategories(), nameof(Category.Id), nameof(Category.Name));
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var fileName = CoverImage.FileName;
            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            if(string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {

                ModelState.AddModelError("CoverImage", "Extension not permitted!");

                return Page();
            }



            WorkoutPlan.Id = Id;
            var workoutId = workoutPlanService.EditWorkout(WorkoutPlan, SelectedExercises, SelectedCategory);

            if(CoverImage != null && CoverImage.Length > 0)
            {
                var filePath = Path.Combine( this.env.WebRootPath, $"images/workoutPlan_covers/{workoutId}{ext}");
                using(var stream = System.IO.File.Create(filePath))
                {
                    await CoverImage.CopyToAsync(stream);
                }
            }

            return RedirectToPage("/WorkoutPlans/Index");
        }
    }
}
