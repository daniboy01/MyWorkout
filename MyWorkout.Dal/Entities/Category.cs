
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyWorkout.Dal.Entities
{
    public partial class Category
    {
        public Category()
        {
            ChildCategories = new HashSet<Category>();
        }

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
    }
}
