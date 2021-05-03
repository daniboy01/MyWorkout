using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Bll.Dto
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? WorkoutPlanId { get; set; }
    }
}
