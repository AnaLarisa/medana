using Medana.API.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities.DTOs;

[NotMapped]
public class PersonalInformationDTO
{
    [Required(ErrorMessage = "First name is required.")]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required.")]
    public string LastName { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; } = new();
    public int Age { get; set; }

    [Required(ErrorMessage = "Sex is required.")]
    public string Sex { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "CNP is required.")]
    [CNP]
    public string CNP { get; set; }

    [Phone(ErrorMessage = "Invalid phone number.")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Occupation is required.")]
    public string Occupation { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }
}
