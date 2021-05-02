using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Bll.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string  UserName { get; set; }
        public int UserId { get; set; }
        public string WorkoutName { get; set; }
        public int WorkoutId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
