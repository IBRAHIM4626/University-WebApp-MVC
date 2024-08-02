namespace MVC_Day2.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public virtual ICollection<Instructor>? Instructors { get; set; }
        public virtual ICollection<Course>? Courses { get; set; }
        public virtual ICollection<Trainee>? Trainees { get; set; }

    }
}
