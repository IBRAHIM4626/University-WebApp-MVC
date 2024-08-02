using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day2.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department? Department { get; set; }

        [ForeignKey("Course")]
        public int CrsId { get; set; }
        public virtual Course? Course { get; set; }
    }
}
