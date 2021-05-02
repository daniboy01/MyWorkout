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
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Exercise>().HasData(
                    //street workout gyakorlatok
                    new Exercise
                    {
                        Id = 1,
                        Title = "fekvőtámasz",
                        Description = "karhajlítás nyújtás mint a suliban",
                        WorkoutPlanId = 1,
                        WorkoutPlan = null
                    },
                    new Exercise
                    {
                        Id = 2,
                        Title = "tolódzkodás",
                        Description = "karhajlítás nyújtás korláton mint a suliban",
                        WorkoutPlanId = 1,
                        WorkoutPlan = null
                    },
                    new Exercise
                    {
                        Id = 3,
                        Title = "guggolás",
                        Description = "lábak hajlanak, nyúlnak",
                        WorkoutPlanId = 1,
                        WorkoutPlan = null
                    },
                    new Exercise
                    {
                        Id = 4,
                        Title = "húzódzkodás",
                        Description = "karhajlítás függeszkedve",
                        WorkoutPlanId = 1,
                        WorkoutPlan = null
                    },
                    //kondis gyakorlatok
                    new Exercise
                    {
                        Id = 5,
                        Title = "fekvenyomás",
                        Description = "fekvenyomás egyenes padon",
                        WorkoutPlanId = 2,
                        WorkoutPlan = null
                    },
                     new Exercise
                     {
                         Id = 6,
                         Title = "fekvenyomás ferdepadon",
                         Description = "fekvenyomás ferdepadon padon rúddal",
                         WorkoutPlanId = 2,
                         WorkoutPlan = null
                     },

                     //cross-fitt gyakorlatok
                    new Exercise
                    {
                        Id = 7,
                        Title = "snatch",
                        Description = "olimpiai szakítás földről",
                        WorkoutPlanId = 3,
                        WorkoutPlan = null
                    },
                     new Exercise
                     {
                         Id = 8,
                         Title = "gumi görgetés",
                         Description = "traktor gumi görgetése",
                         WorkoutPlanId = 3,
                         WorkoutPlan = null
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
                        UserId = null,
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
                        UserId = null,
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
                        UserId = null,
                        CategoryId = 3,
                    }
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
                    },
                    new User
                    {
                        Id = 3,
                        DisplayName = "Fütty Imre",
                        Email = "füttyimre@example.com",
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
                        Id = 3,
                        Text = "Ez aztán durva edzés terv",
                        UserID = 3,
                        WorkoutPlanId = 3,
                        CreatedAt = DateTimeOffset.Now,
                    },
                    new Comment
                    {
                        Id = 4,
                        Text = "Ez aztán durva edzés terv",
                        UserID = 3,
                        WorkoutPlanId = 1,
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
        }
    }

    
}
