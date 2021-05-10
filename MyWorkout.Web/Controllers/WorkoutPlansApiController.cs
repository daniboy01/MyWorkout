using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWorkout.Bll.Dto;
using MyWorkout.Bll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkout.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutPlansApiController : ControllerBase
    {
        public WorkoutPlanService WorkoutPlanService { get; }

        public WorkoutPlansApiController(WorkoutPlanService workoutPlanService)
        {
            WorkoutPlanService = workoutPlanService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(WorkoutPlanService.GetWorkouts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var workout =  await WorkoutPlanService.GetByIdAsync(id);

            if(workout == null)
            {
                return NotFound();
            }

            return Ok(workout);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Post([FromBody] WorkoutPlanDto dto, int id)
        {
            if(dto == null)
            {
                return BadRequest();
            }

            var newWorkout = await WorkoutPlanService.AddNewWorkoutAsync(dto, id);

            return Ok(newWorkout);

        }

        [HttpPost]
        public IActionResult PostCommet([FromBody] CommentDto dto)
        {
            var newComment = WorkoutPlanService.CreateNewComment(dto);

            if(newComment == null || String.IsNullOrEmpty(newComment.Id.ToString()))
            {
                return BadRequest();
            }

            return Ok(newComment);
        }


    }
}
