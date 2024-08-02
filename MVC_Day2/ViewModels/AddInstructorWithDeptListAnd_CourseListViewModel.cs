using MVC_Day2.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day2.ViewModels
{
    public class AddInstructorWithDeptListAnd_CourseListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Salary { get; set; }
        public string? Address { get; set; }
        public int DepartmentId { get; set; }
        public List<Department> DeptList { get; set; }
        public int CrsId { get; set; }
        public List<Course> CourseList { get; set; }
    }
}
