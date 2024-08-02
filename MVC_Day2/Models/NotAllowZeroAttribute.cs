using System.ComponentModel.DataAnnotations;

namespace MVC_Day2.Models
{
    public class NotAllowZeroAttribute:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            int val = int.Parse(value.ToString());
            if (val > 0)
                return true;
            return false;
        }
    }
}
