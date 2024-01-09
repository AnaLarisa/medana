using Medana.API.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities;

public class PersonalInformation
{
    [Key]
    [ForeignKey("Patient")]
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Date of birth is required.")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Sex is required.")]
    public string Sex { get; set; }

    public int Age
    {
        get
        {
            DateTime currentDate = DateTime.Now;
            int age = currentDate.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }
        private set { }
    }

    [Required]
    public string Address { get; set; }

    [Required]
    [CNP]
    public string CNP { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }

    [Required]
    public string Occupation { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
}
