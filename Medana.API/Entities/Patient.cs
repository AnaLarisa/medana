using Medana.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Medana.API.Entities;

public class Patient
{
    [Key]
    [Required]
    [CNP]
    [IsUnique(typeof(ApplicationDbContext))]
    public string CNP { get; set; }

    [Required]
    public PersonalInformation PersonalInformation { get; set; } = new();

    [Required]
    public MedicalHistory MedicalHistory { get; set; } = new();

    [Required]
    public InsuranceInformation InsuranceInformation { get; set; } = new();
}
