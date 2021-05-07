
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Dal.Entities
{
    public class WorkoutExercise
    {
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int WorkoutPlanId { get; set; }
        public WorkoutPlan WorkoutPlan { get; set; }
    }
}
