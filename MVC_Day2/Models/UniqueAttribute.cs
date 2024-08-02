using MVC_Day2.ViewModels;
using System.ComponentModel.DataAnnotations;
namespace MVC_Day2.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            string name = value.ToString();

            AddCoursewithDeptListViewModel crsFromReq = (AddCoursewithDeptListViewModel)validationContext.ObjectInstance;
            ITIContext context = new ITIContext();
            Course crsFromDB = context.Courses.FirstOrDefault(c => c.Name == name && c.DepartmentId == crsFromReq.DepartmentId);

            
            if (crsFromDB == null) 
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult($"This Name {name} already exist");
            }
            
        }
    }
}
