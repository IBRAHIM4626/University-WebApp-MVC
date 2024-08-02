using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day2.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string? Address { get; set; }
        public int Grade { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public virtual ICollection<CrsResult>? CrsResults { get; set; }
    }
}
