using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Annotations;

public class DateOfBirth : ValidationAttribute
{

    public override bool IsValid(object value)
    {
        if (value == null) return false;

        DateTime date = Convert.ToDateTime(value);
        return date.Date < DateTime.Now.Date;
    }
}