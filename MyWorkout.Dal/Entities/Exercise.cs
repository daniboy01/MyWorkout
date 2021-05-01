
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Dal.Entities
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? WorkoutPlanId { get; set; }


        public virtual WorkoutPlan WorkoutPlan { get; set; }
    }
}
