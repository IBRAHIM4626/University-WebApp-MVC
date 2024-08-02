using Microsoft.EntityFrameworkCore;

namespace MVC_Day2.Models
{
    public class ITIContext : DbContext
    {
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Trainee> Trainees { get; set; }
        public virtual DbSet<CrsResult> CrsResult { get; set; }

        public ITIContext():base() 
        {

        }
        //constructor options[DI]
        public ITIContext(DbContextOptions<ITIContext> options):base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-C1CAPQ0\\SQLEXPRESS;Initial Catalog=DotNet_Q3;Integrated Security=True;Encrypt=False;Trust Server Certificate=False");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "SD", ManagerName = "Ebrahim"/*, Instructors= new Instructor {Id=1, CrsId=1, Name="Ahmed", and so on}*/ },
                new Department { Id = 2, Name = "HR", ManagerName = "Fatma" },
                new Department { Id = 3, Name = "Finance", ManagerName = "Ahmed" },
                new Department { Id = 4, Name = "Marketing", ManagerName = "Sara" },
                new Department { Id = 5, Name = "IT", ManagerName = "Mohamed" }
            );
            
            // Seed data for Courses
            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Name = "C# Programming", Degree = 100, MinDegree = 50, Hours = 30, DepartmentId = 1 },
                new Course { Id = 2, Name = "Database Management", Degree = 100, MinDegree = 50, Hours = 30, DepartmentId = 1 },
                new Course { Id = 3, Name = "Organizational Behavior", Degree = 100, MinDegree = 50, Hours = 30, DepartmentId = 2 },
                new Course { Id = 4, Name = "Financial Accounting", Degree = 100, MinDegree = 50, Hours = 30, DepartmentId = 3 },
                new Course { Id = 5, Name = "Marketing Strategy", Degree = 100, MinDegree = 50, Hours = 30, DepartmentId = 4 },
                new Course { Id = 6, Name = "Network Security", Degree = 100, MinDegree = 50, Hours = 30, DepartmentId = 5 }
            );

            // Seed data for Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "John Doe", ImageUrl = "1.jpg", Salary = 50000, Address = "123 Main St", DepartmentId = 1, CrsId = 1 },
                new Instructor { Id = 2, Name = "Jane Smith", ImageUrl = "2.png", Salary = 55000, Address = "456 Elm St", DepartmentId = 1, CrsId = 2 },
                new Instructor { Id = 3, Name = "Mary Johnson", ImageUrl = "3.jpg", Salary = 52000, Address = "789 Pine St", DepartmentId = 2, CrsId = 3 },
                new Instructor { Id = 4, Name = "James Williams", ImageUrl = "4.jpg", Salary = 60000, Address = "321 Oak St", DepartmentId = 3, CrsId = 4 },
                new Instructor { Id = 5, Name = "Patricia Brown", ImageUrl = "5.jpeg", Salary = 58000, Address = "654 Maple St", DepartmentId = 4, CrsId = 5 },
                new Instructor { Id = 6, Name = "Robert Jones", ImageUrl = "6.jpeg", Salary = 61000, Address = "987 Birch St", DepartmentId = 5, CrsId = 6 }
            );

            // Seed data for Trainees
            modelBuilder.Entity<Trainee>().HasData(
                new Trainee { Id = 1, Name = "Alice Brown", ImageUrl = "alice.jpg", Address = "12 Cedar St", Grade = 90, DepartmentId = 1 },
                new Trainee { Id = 2, Name = "Bob White", ImageUrl = "bob.jpg", Address = "34 Maple St", Grade = 85, DepartmentId = 1 },
                new Trainee { Id = 3, Name = "Charlie Green", ImageUrl = "charlie.jpg", Address = "56 Oak St", Grade = 88, DepartmentId = 2 },
                new Trainee { Id = 4, Name = "Dana Black", ImageUrl = "dana.jpg", Address = "78 Pine St", Grade = 92, DepartmentId = 3 },
                new Trainee { Id = 5, Name = "Eve Blue", ImageUrl = "eve.jpg", Address = "90 Birch St", Grade = 95, DepartmentId = 4 },
                new Trainee { Id = 6, Name = "Frank Red", ImageUrl = "frank.jpeg", Address = "123 Cedar St", Grade = 80, DepartmentId = 5 }
            );

            // Seed data for CrsResults
            modelBuilder.Entity<CrsResult>().HasData(
                new CrsResult { Id = 1, Degree = 85, TraineeId = 1, CourseId = 1 },
                new CrsResult { Id = 2, Degree = 90, TraineeId = 2, CourseId = 2 },
                new CrsResult { Id = 3, Degree = 88, TraineeId = 3, CourseId = 3 },
                new CrsResult { Id = 4, Degree = 92, TraineeId = 4, CourseId = 4 },
                new CrsResult { Id = 5, Degree = 95, TraineeId = 5, CourseId = 5 },
                new CrsResult { Id = 6, Degree = 80, TraineeId = 6, CourseId = 6 },
                new CrsResult { Id = 7, Degree = 45, TraineeId = 1, CourseId = 2 },
                new CrsResult { Id = 8, Degree = 55, TraineeId = 2, CourseId = 3 },
                new CrsResult { Id = 9, Degree = 70, TraineeId = 3, CourseId = 4 },
                new CrsResult { Id = 10, Degree = 35, TraineeId = 4, CourseId = 5 }

            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
