using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Bll.Specifications
{
    public class WorkoutPlanSpecification : PagerSpecification
    {
        public int? CategoryId { get; set; }
        public PlanOrder Order { get; set; } = PlanOrder.TitleAscending;

        public enum PlanOrder
        {
            TitleAscending,
            TitleDescending
        }
    }

    
}
