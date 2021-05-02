using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWorkout.Bll.Dto;
using MyWorkout.Dal;

namespace MyWorkout.Bll.Services
{
    public class CommentService
    {
        public MyWorkoutDbContext DbContext { get; }

        public CommentService( MyWorkoutDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<CommentDto>> GetComments(int workoutId, int count = 5)
        {
            var comments = await DbContext.Comments.Where(c => c.WorkoutPlanId == workoutId).Select(c => 
            new CommentDto
            {
                Id = c.Id,
                Text = c.Text,
                UserName = c.User.DisplayName,
                UserId = c.UserID,
                WorkoutName = c.WorkoutPlan.Title,
                WorkoutId = c.WorkoutPlanId,
                CreatedAt = c.CreatedAt
            }).Take(count).ToListAsync();

            return comments;
        }
    }
}
