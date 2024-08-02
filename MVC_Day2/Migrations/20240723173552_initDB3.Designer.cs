﻿// <auto-generated />
using MVC_Day2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_Day2.Migrations
{
    [DbContext(typeof(ITIContext))]
    [Migration("20240723173552_initDB3")]
    partial class initDB3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_Day2.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<int>("MinDegree")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Degree = 100,
                            DepartmentId = 1,
                            Hours = 30,
                            MinDegree = 50,
                            Name = "C# Programming"
                        },
                        new
                        {
                            Id = 2,
                            Degree = 100,
                            DepartmentId = 1,
                            Hours = 30,
                            MinDegree = 50,
                            Name = "Database Management"
                        },
                        new
                        {
                            Id = 3,
                            Degree = 100,
                            DepartmentId = 2,
                            Hours = 30,
                            MinDegree = 50,
                            Name = "Organizational Behavior"
                        },
                        new
                        {
                            Id = 4,
                            Degree = 100,
                            DepartmentId = 3,
                            Hours = 30,
                            MinDegree = 50,
                            Name = "Financial Accounting"
                        },
                        new
                        {
                            Id = 5,
                            Degree = 100,
                            DepartmentId = 4,
                            Hours = 30,
                            MinDegree = 50,
                            Name = "Marketing Strategy"
                        },
                        new
                        {
                            Id = 6,
                            Degree = 100,
                            DepartmentId = 5,
                            Hours = 30,
                            MinDegree = 50,
                            Name = "Network Security"
                        });
                });

            modelBuilder.Entity("MVC_Day2.Models.CrsResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("Degree")
                        .HasColumnType("int");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TraineeId");

                    b.ToTable("CrsResult");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            Degree = 85,
                            TraineeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            Degree = 90,
                            TraineeId = 2
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 3,
                            Degree = 88,
                            TraineeId = 3
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 4,
                            Degree = 92,
                            TraineeId = 4
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 5,
                            Degree = 95,
                            TraineeId = 5
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 6,
                            Degree = 80,
                            TraineeId = 6
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 2,
                            Degree = 45,
                            TraineeId = 1
                        },
                        new
                        {
                            Id = 8,
                            CourseId = 3,
                            Degree = 55,
                            TraineeId = 2
                        },
                        new
                        {
                            Id = 9,
                            CourseId = 4,
                            Degree = 70,
                            TraineeId = 3
                        },
                        new
                        {
                            Id = 10,
                            CourseId = 5,
                            Degree = 35,
                            TraineeId = 4
                        });
                });

            modelBuilder.Entity("MVC_Day2.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ManagerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ManagerName = "Ebrahim",
                            Name = "SD"
                        },
                        new
                        {
                            Id = 2,
                            ManagerName = "Fatma",
                            Name = "HR"
                        },
                        new
                        {
                            Id = 3,
                            ManagerName = "Ahmed",
                            Name = "Finance"
                        },
                        new
                        {
                            Id = 4,
                            ManagerName = "Sara",
                            Name = "Marketing"
                        },
                        new
                        {
                            Id = 5,
                            ManagerName = "Mohamed",
                            Name = "IT"
                        });
                });

            modelBuilder.Entity("MVC_Day2.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CrsId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CrsId");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            CrsId = 1,
                            DepartmentId = 1,
                            ImageUrl = "1.jpg",
                            Name = "John Doe",
                            Salary = 50000
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            CrsId = 2,
                            DepartmentId = 1,
                            ImageUrl = "2.png",
                            Name = "Jane Smith",
                            Salary = 55000
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Pine St",
                            CrsId = 3,
                            DepartmentId = 2,
                            ImageUrl = "3.jpg",
                            Name = "Mary Johnson",
                            Salary = 52000
                        },
                        new
                        {
                            Id = 4,
                            Address = "321 Oak St",
                            CrsId = 4,
                            DepartmentId = 3,
                            ImageUrl = "4.jpg",
                            Name = "James Williams",
                            Salary = 60000
                        },
                        new
                        {
                            Id = 5,
                            Address = "654 Maple St",
                            CrsId = 5,
                            DepartmentId = 4,
                            ImageUrl = "5.jpeg",
                            Name = "Patricia Brown",
                            Salary = 58000
                        },
                        new
                        {
                            Id = 6,
                            Address = "987 Birch St",
                            CrsId = 6,
                            DepartmentId = 5,
                            ImageUrl = "6.jpeg",
                            Name = "Robert Jones",
                            Salary = 61000
                        });
                });

            modelBuilder.Entity("MVC_Day2.Models.Trainee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Trainees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "12 Cedar St",
                            DepartmentId = 1,
                            Grade = 90,
                            ImageUrl = "alice.jpg",
                            Name = "Alice Brown"
                        },
                        new
                        {
                            Id = 2,
                            Address = "34 Maple St",
                            DepartmentId = 1,
                            Grade = 85,
                            ImageUrl = "bob.jpg",
                            Name = "Bob White"
                        },
                        new
                        {
                            Id = 3,
                            Address = "56 Oak St",
                            DepartmentId = 2,
                            Grade = 88,
                            ImageUrl = "charlie.jpg",
                            Name = "Charlie Green"
                        },
                        new
                        {
                            Id = 4,
                            Address = "78 Pine St",
                            DepartmentId = 3,
                            Grade = 92,
                            ImageUrl = "dana.jpg",
                            Name = "Dana Black"
                        },
                        new
                        {
                            Id = 5,
                            Address = "90 Birch St",
                            DepartmentId = 4,
                            Grade = 95,
                            ImageUrl = "eve.jpg",
                            Name = "Eve Blue"
                        },
                        new
                        {
                            Id = 6,
                            Address = "123 Cedar St",
                            DepartmentId = 5,
                            Grade = 80,
                            ImageUrl = "frank.jpeg",
                            Name = "Frank Red"
                        });
                });

            modelBuilder.Entity("MVC_Day2.Models.Course", b =>
                {
                    b.HasOne("MVC_Day2.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC_Day2.Models.CrsResult", b =>
                {
                    b.HasOne("MVC_Day2.Models.Course", "Course")
                        .WithMany("CrsResults")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Day2.Models.Trainee", "Trainee")
                        .WithMany("CrsResults")
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("MVC_Day2.Models.Instructor", b =>
                {
                    b.HasOne("MVC_Day2.Models.Course", "Course")
                        .WithMany("Instructors")
                        .HasForeignKey("CrsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_Day2.Models.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC_Day2.Models.Trainee", b =>
                {
                    b.HasOne("MVC_Day2.Models.Department", "Department")
                        .WithMany("Trainees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("MVC_Day2.Models.Course", b =>
                {
                    b.Navigation("CrsResults");

                    b.Navigation("Instructors");
                });

            modelBuilder.Entity("MVC_Day2.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Instructors");

                    b.Navigation("Trainees");
                });

            modelBuilder.Entity("MVC_Day2.Models.Trainee", b =>
                {
                    b.Navigation("CrsResults");
                });
#pragma warning restore 612, 618
        }
    }
}
