using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using MVC_Day2.Models;
using System.ComponentModel.DataAnnotations;

namespace MVC_Day2.ViewModels
{
    [ModelMetadataType(typeof(CourseMetaData))]
    
    public partial class AddCoursewithDeptListViewModel
    {

        public int Id { get; set; }
        //[MaxLength(20)]
        //[MinLength(2, ErrorMessage = "Name Must Be More Than 2 Char")]
        //[Unique]
        //[Display(Name = "Course Name")]
        public string Name { get; set; }

        //[Range(50, 100)]
        public int Degree { get; set; }

        //[Remote("CheckMinDegree", "Course", AdditionalFields = "Degree", ErrorMessage = "MinDegree must be less than degree")]
        public int MinDegree { get; set; }

        //[Remote("CheckHours", "Course", ErrorMessage ="Hours divided by 3")]
        public int Hours { get; set; }
        //[NotAllowZero(ErrorMessage = "Please Select Department")]
        //[Display(Name= "Department")]
        public int DepartmentId { get; set; }
        public List<Department>? DeptList { get; set; }
    }
}
