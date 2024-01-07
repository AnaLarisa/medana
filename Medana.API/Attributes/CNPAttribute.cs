using System.ComponentModel.DataAnnotations;

namespace Medana.API.Attributes;


[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
public class CNPAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            // If the CNP is optional and can be null, consider it valid
            return ValidationResult.Success;
        }

        if (value is not string cnp)
        {
            return new ValidationResult("Invalid CNP format.");
        }

        // check length to be 13
        if (cnp.Length != 13 || !long.TryParse(cnp, out _))
        {
            return new ValidationResult("Invalid CNP format.");
        }

        // check birthdate
        int year = int.Parse(cnp.Substring(1, 2));
        int month = int.Parse(cnp.Substring(3, 2));
        int day = int.Parse(cnp.Substring(5, 2));

        DateTime birthdate = new DateTime(year, month, day);
        if (birthdate > DateTime.Now || !IsValidDate(year, month, day))
        {
            return new ValidationResult("Invalid CNP - invalid birthdate segment.");
        }

        // Check gender segment (1 or 2 for male, 3 or 4 for female)
        int genderDigit = int.Parse(cnp[0].ToString());
        if (genderDigit < 1 || (genderDigit > 4 && genderDigit % 2 != 0))
        {
            return new ValidationResult("Invalid CNP - invalid gender segment.");
        }

        // Check county segment
        int countyCode = int.Parse(cnp.Substring(7, 2));
        if (countyCode < 1 || countyCode > 52)
        {
            return new ValidationResult("Invalid CNP - invalid county segment.");
        }

        // Check control digit
        int[] weights = { 2, 7, 9, 1, 4, 6, 3, 5, 8, 2, 7, 9 };
        int sum = weights.Zip(cnp.Take(12).Select(digit => int.Parse(digit.ToString())), (w, d) => w * d).Sum();
        int controlDigit = sum % 11;
        if (controlDigit == 10)
        {
            controlDigit = 1;
        }

        if (controlDigit != int.Parse(cnp[12].ToString()))
        {
            return new ValidationResult("Invalid CNP - invalid control digit.");
        }

        return ValidationResult.Success;
    }

    private static bool IsValidDate(int year, int month, int day)
    {
        try
        {
            new DateTime(year, month, day);
            return true;
        }
        catch (ArgumentOutOfRangeException)
        {
            return false;
        }
    }
}
