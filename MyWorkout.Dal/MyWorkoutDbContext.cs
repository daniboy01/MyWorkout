using Microsoft.EntityFrameworkCore;
using MyWorkout.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Dal
{
    public class MyWorkoutDbContext : DbContext
    {
        public MyWorkoutDbContext( DbContextOptions options ) : base( options )
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
    }
}
