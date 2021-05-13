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
using MyWorkout.Web.Helpers;
using MyWorkout.Web.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class AddWorkoutModel : PageModel
    {
        private readonly WorkoutPlanService workoutPlanService;
        private readonly ExerciseService exerciseService;
        private readonly IConfiguration config;
        private readonly IWebHostEnvironment env;
        private readonly SubsrciptionService subsrciptionService;
        private readonly long fileSizeLimit;
        private List<string> permittedExtensions;

        public AddWorkoutModel( WorkoutPlanService workoutPlanService, 
            ExerciseService exerciseService, 
            IConfiguration config, 
            IWebHostEnvironment env,
            SubsrciptionService subsrciptionService)
        {
            this.workoutPlanService = workoutPlanService;
            this.exerciseService = exerciseService;
            this.config = config;
            this.env = env;
            this.subsrciptionService = subsrciptionService;
            this.fileSizeLimit = config.GetValue<long>("FileSizeLimit");
            this.permittedExtensions = config.GetSection("PemittedExtensions").Get<List<string>>();
        }

        [BindProperty]
        public WorkoutPlanDto WorkoutPlan { get; set; }
      
        [BindProperty]
        public ExerciseDto ExerciseDto { get; set; }
        [BindProperty]
        public IFormFile CoverImage { get; set; }

        public IEnumerable<ExerciseDto> Exercises { get; set; }
        public void OnGet()
        {
            Exercises = exerciseService.GetAllExerciseAsync();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            WorkoutPlan.Title = new HtmlSanitizer().Sanitize(WorkoutPlan.Title);
            WorkoutPlan.Description = new HtmlSanitizer().Sanitize(WorkoutPlan.Description);

           

            var fileName = CoverImage.FileName;
            var ext = Path.GetExtension(fileName).ToLowerInvariant();

            if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
            {

                ModelState.AddModelError("CoverImage", "Extension not permitted!");

                return Page();
            }

            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var workout = await workoutPlanService.AddNewWorkoutAsync(WorkoutPlan, userId);

            if (CoverImage != null && CoverImage.Length > 0)
            {
                var filePath = Path.Combine(this.env.WebRootPath, $"images/workoutPlan_covers/{workout.Id}{ext}");
                using var image = Image.Load(CoverImage.OpenReadStream());
                image.Mutate(x => x.Resize(230, 350));
                image.Save(filePath);
            }

            await subsrciptionService.NotifySubscriptedUsers(
                    $"New workout has been uploaded by {User.FindFirstValue(ClaimTypes.Name)}",
                    $"Checkout <a href='localhost:44361/WorkoutPlans/Details?Id={workout.Id}'>clicking here</a>."
                );

            return new RedirectToPageResult("/WorkoutPlans/Index");
        }

    }
}
