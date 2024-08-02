using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Day2.Models
{
    public class CourseMetaData
    {
        [MaxLength(20)]
        [MinLength(2, ErrorMessage = "Name Must Be More Than 2 Char")]
        [Unique]
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        [Range(50, 100)]
        public int Degree { get; set; }

        [Remote("CheckMinDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than degree")]
        public int MinDegree { get; set; }

        [Remote("CheckHours", "Course", ErrorMessage = "Hours divided by 3")]
        public int Hours { get; set; }
        [NotAllowZero(ErrorMessage ="Please Select Department")]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
    }
}
