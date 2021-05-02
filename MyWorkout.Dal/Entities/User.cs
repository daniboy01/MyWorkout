using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Dal.Entities
{
    public class User : IdentityUser<int>
    {
        public string DisplayName { get; set; }
        public int? AddressId { get; set; }

        public virtual ICollection<WorkoutPlan> WorkoutPlans { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual Address Address { get; set; }
    }
}
