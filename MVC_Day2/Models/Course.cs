using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day2.Models
{
    [ModelMetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
        public int Id { get; set; }
        //[MaxLength(20)]
        //[MinLength(2, ErrorMessage = "Name Must Be More Than 2 Char")]
        //[Unique]
        public string Name { get; set; }
        public int Degree { get; set; }
        //[Remote("CheckMinDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than degree")]
        public int MinDegree { get; set; }
        //[Remote("CheckHours", "Course", ErrorMessage = "Hours divided by 3")]
        public int Hours { get; set; }
        //[NotAllowZero(ErrorMessage = "Please Select Department")]
        //[ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

        public virtual ICollection<Instructor>? Instructors { get; set; }
        public virtual ICollection<CrsResult>? CrsResults { get; set; }
    }
}
