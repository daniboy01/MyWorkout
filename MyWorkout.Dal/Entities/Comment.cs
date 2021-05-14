using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyWorkout.Dal.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int UserID { get; set; }
        public int WorkoutPlanId { get; set; }
        public DateTimeOffset CreatedAt { get; set; }


        public User User { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }
    }
}
