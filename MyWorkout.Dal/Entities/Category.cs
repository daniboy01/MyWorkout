
using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }

        public virtual Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
    }
}
