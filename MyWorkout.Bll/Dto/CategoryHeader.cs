﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Bll.Dto
{
    public class CategoryHeader
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
