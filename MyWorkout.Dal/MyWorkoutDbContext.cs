using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWorkout.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkout.Dal
{
    public class MyWorkoutDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public MyWorkoutDbContext( DbContextOptions options ) : base( options )
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating( modelbuilder );

            modelbuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.ExerciseId, we.WorkoutPlanId });
            modelbuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.WorkoutPlan)
                .WithMany(w => w.WorkoutExercise)
                .HasForeignKey(we => we.WorkoutPlanId);
            modelbuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(w => w.WorkoutExercise)
                .HasForeignKey(we => we.ExerciseId);


            modelbuilder.Entity<Exercise>().HasData(
                    //street workout gyakorlatok
                    new Exercise
                    {
                        Id = 1,
                        Title = "fekvőtámasz",
                        Description = "karhajlítás nyújtás mint a suliban",
                    },
                    new Exercise
                    {
                        Id = 2,
                        Title = "tolódzkodás",
                        Description = "karhajlítás nyújtás korláton mint a suliban",
                    },
                    new Exercise
                    {
                        Id = 3,
                        Title = "guggolás",
                        Description = "lábak hajlanak, nyúlnak",
                    },
                    new Exercise
                    {
                        Id = 4,
                        Title = "húzódzkodás",
                        Description = "karhajlítás függeszkedve",
                    },
                    //kondis gyakorlatok
                    new Exercise
                    {
                        Id = 5,
                        Title = "fekvenyomás",
                        Description = "fekvenyomás egyenes padon",
                    },
                     new Exercise
                     {
                         Id = 6,
                         Title = "fekvenyomás ferdepadon",
                         Description = "fekvenyomás ferdepadon padon rúddal",
                     },

                     //cross-fitt gyakorlatok
                    new Exercise
                    {
                        Id = 7,
                        Title = "snatch",
                        Description = "olimpiai szakítás földről",
                    },
                     new Exercise
                     {
                         Id = 8,
                         Title = "gumi görgetés",
                         Description = "traktor gumi görgetése",
                     }
                );

            modelbuilder.Entity<WorkoutPlan>().HasData(
                    new WorkoutPlan
                    {
                        Id = 1,
                        Title = "Own Weight Challenge",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                        "when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic " +
                        "typesetting, remaining essentially unchanged. It was popularised in the 1960s with " +
                        "the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        UserId = 1,
                        CategoryId = 1,
                    },
                    new WorkoutPlan
                    {
                        Id = 2,
                        Title = "Weight Challenge",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                        "when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic " +
                        "typesetting, remaining essentially unchanged. It was popularised in the 1960s with " +
                        "the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        UserId = 1,
                        CategoryId = 2,
                    },
                    new WorkoutPlan
                    {
                        Id = 3,
                        Title = "Ultimate bodyshock",
                        Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, " +
                        "when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic " +
                        "typesetting, remaining essentially unchanged. It was popularised in the 1960s with " +
                        "the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                        UserId = 1,
                        CategoryId = 3,
                    }
                );

            modelbuilder.Entity<WorkoutExercise>().HasData(
                new WorkoutExercise { ExerciseId = 1, WorkoutPlanId = 1 },
                new WorkoutExercise { ExerciseId = 2, WorkoutPlanId = 2 },
                new WorkoutExercise { ExerciseId = 4, WorkoutPlanId = 3 },
                new WorkoutExercise { ExerciseId = 5, WorkoutPlanId = 1 },
                new WorkoutExercise { ExerciseId = 6, WorkoutPlanId = 2 },
                new WorkoutExercise { ExerciseId = 7, WorkoutPlanId = 3 },
                new WorkoutExercise { ExerciseId = 8, WorkoutPlanId = 1 },
                new WorkoutExercise { ExerciseId = 1, WorkoutPlanId = 2 },
                new WorkoutExercise { ExerciseId = 2, WorkoutPlanId = 3 },
                new WorkoutExercise { ExerciseId = 3, WorkoutPlanId = 1 },
                new WorkoutExercise { ExerciseId = 4, WorkoutPlanId = 2 },
                new WorkoutExercise { ExerciseId = 5, WorkoutPlanId = 3 }
                );

            modelbuilder.Entity<Category>().HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Street Workout",
                        ParentCategory = null,
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Gym Workout",
                        ParentCategory = null,
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Cross-fitt",
                        ParentCategory = null,
                    }
                );

            modelbuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        DisplayName = "Megverj Elek",
                        Email = "megverjelek@example.com",
                        AddressId = null
                    },
                    new User
                    {
                        Id = 2,
                        DisplayName = "Egyip Tomi",
                        Email = "egyiptomi@example.com",
                        AddressId = null
                    }
                );


            modelbuilder.Entity<Comment>().HasData(
                    new Comment
                    {
                        Id = 1,
                        Text = "Ez aztán durva edzés terv",
                        UserID = 1,
                        WorkoutPlanId = 1,
                        CreatedAt = DateTimeOffset.Now,
                    },
                    new Comment
                    {
                        Id = 2,
                        Text = "Ez aztán durva edzés terv",
                        UserID = 2,
                        WorkoutPlanId = 2,
                        CreatedAt = DateTimeOffset.Now,
                    },
                    new Comment
                    {
                        Id = 5,
                        Text = "Ez aztán durva edzés terv",
                        UserID = 2,
                        WorkoutPlanId = 1,
                        CreatedAt = DateTimeOffset.Now,
                    },
                    new Comment
                    {
                        Id = 6,
                        Text = "Ez aztán durva edzés terv",
                        UserID = 1,
                        WorkoutPlanId = 1,
                        CreatedAt = DateTimeOffset.Now,
                    }

                );

            modelbuilder.Entity<User>(entity =>
                {
                    entity.ToTable("Users");
                    entity.Property(e => e.DisplayName).IsRequired().HasMaxLength(100);
                }
            );
        }
    }

    
}
