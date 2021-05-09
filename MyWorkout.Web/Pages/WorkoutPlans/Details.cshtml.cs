using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;
using MyWorkout.Dal.Entities;

namespace MyWorkout.Web.Pages.WorkoutPlans
{
    public class DetailsModel : PageModel
    {
        public WorkoutPlanService WorkoutPlanService { get; }
        public CommentService CommentService { get; }


        public DetailsModel(WorkoutPlanService workoutPlanService, CommentService commentService)
        {
            WorkoutPlanService = workoutPlanService;
            CommentService = commentService;

        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CommentDto NewComment { get; set; }

        public WorkoutPlan WorkoutPlan { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<ExerciseDto> Exercises { get; set; }
        public String UserName { get; set; }

        public async Task<IActionResult> OnGet()
        {
            WorkoutPlan = await WorkoutPlanService.GetByIdAsync(Id);
            Comments = await CommentService.GetComments(Id);
            Exercises = await WorkoutPlanService.GetExercisesFromWorkoutPlan(Id);
            NewComment = new CommentDto { WorkoutId = Id };
            UserName = WorkoutPlanService.GetUserNameFromWorkout(Id);


            return Page();
        }

        public IActionResult OnPostCreateComment()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    NewComment.UserId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                    WorkoutPlanService.CreateNewComment(NewComment);
                    return RedirectToPage("/WorkoutPlans/Details", new { Id = NewComment.WorkoutId });
                }
                catch( Exception ex)
                {
                    ModelState.AddModelError("", "Hiba a comment létrehozásakor");
                }
            }
            return Page();
        }
    }
}
