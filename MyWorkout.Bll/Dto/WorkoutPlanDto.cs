using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyWorkout.Bll.Dto
{
    public class WorkoutPlanDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int? UserId { get; set; }
        public int? CategoryId { get; set; }
        public string UserName { get; set; }
        public string CategoryName { get; set; }

    }
}
