using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Dal.Entities
{
    public class WorkoutPlan
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? UserId { get; set; }


        public virtual User User { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
