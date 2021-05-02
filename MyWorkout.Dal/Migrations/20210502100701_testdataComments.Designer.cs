﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyWorkout.Dal;

namespace MyWorkout.Dal.Migrations
{
    [DbContext(typeof(MyWorkoutDbContext))]
    [Migration("20210502100701_testdataComments")]
    partial class testdataComments
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyWorkout.Dal.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Street Workout"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Gym Workout"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Cross-fitt"
                        });
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 138, DateTimeKind.Unspecified).AddTicks(6486), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "Ez aztán durva edzés terv",
                            UserID = 1,
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(755), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "Ez aztán durva edzés terv",
                            UserID = 2,
                            WorkoutPlanId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(797), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "Ez aztán durva edzés terv",
                            UserID = 3,
                            WorkoutPlanId = 3
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(806), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "Ez aztán durva edzés terv",
                            UserID = 3,
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(812), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "Ez aztán durva edzés terv",
                            UserID = 2,
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTimeOffset(new DateTime(2021, 5, 2, 12, 7, 1, 142, DateTimeKind.Unspecified).AddTicks(818), new TimeSpan(0, 2, 0, 0, 0)),
                            Text = "Ez aztán durva edzés terv",
                            UserID = 1,
                            WorkoutPlanId = 1
                        });
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkoutPlanId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutPlanId");

                    b.ToTable("Exercises");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "karhajlítás nyújtás mint a suliban",
                            Title = "fekvőtámasz",
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "karhajlítás nyújtás korláton mint a suliban",
                            Title = "tolódzkodás",
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "lábak hajlanak, nyúlnak",
                            Title = "guggolás",
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 4,
                            Description = "karhajlítás függeszkedve",
                            Title = "húzódzkodás",
                            WorkoutPlanId = 1
                        },
                        new
                        {
                            Id = 5,
                            Description = "fekvenyomás egyenes padon",
                            Title = "fekvenyomás",
                            WorkoutPlanId = 2
                        },
                        new
                        {
                            Id = 6,
                            Description = "fekvenyomás ferdepadon padon rúddal",
                            Title = "fekvenyomás ferdepadon",
                            WorkoutPlanId = 2
                        },
                        new
                        {
                            Id = 7,
                            Description = "olimpiai szakítás földről",
                            Title = "snatch",
                            WorkoutPlanId = 3
                        },
                        new
                        {
                            Id = 8,
                            Description = "traktor gumi görgetése",
                            Title = "gumi görgetés",
                            WorkoutPlanId = 3
                        });
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayName = "Megverj Elek",
                            Email = "megverjelek@example.com"
                        },
                        new
                        {
                            Id = 2,
                            DisplayName = "Egyip Tomi",
                            Email = "egyiptomi@example.com"
                        },
                        new
                        {
                            Id = 3,
                            DisplayName = "Fütty Imre",
                            Email = "füttyimre@example.com"
                        });
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.WorkoutPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkoutPlans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Title = "Own Weight Challenge"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Title = "Weight Challenge"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                            Title = "Ultimate bodyshock"
                        });
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.Address", b =>
                {
                    b.HasOne("MyWorkout.Dal.Entities.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("MyWorkout.Dal.Entities.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.Category", b =>
                {
                    b.HasOne("MyWorkout.Dal.Entities.Category", "ParentCategory")
                        .WithMany("ChildCategories")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.Comment", b =>
                {
                    b.HasOne("MyWorkout.Dal.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyWorkout.Dal.Entities.WorkoutPlan", "WorkoutPlan")
                        .WithMany("Comments")
                        .HasForeignKey("WorkoutPlanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.Exercise", b =>
                {
                    b.HasOne("MyWorkout.Dal.Entities.WorkoutPlan", "WorkoutPlan")
                        .WithMany("Exercises")
                        .HasForeignKey("WorkoutPlanId");
                });

            modelBuilder.Entity("MyWorkout.Dal.Entities.WorkoutPlan", b =>
                {
                    b.HasOne("MyWorkout.Dal.Entities.Category", "Category")
                        .WithMany("WorkoutPlans")
                        .HasForeignKey("CategoryId");

                    b.HasOne("MyWorkout.Dal.Entities.User", "User")
                        .WithMany("WorkoutPlans")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
