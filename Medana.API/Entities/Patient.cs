using System.ComponentModel.DataAnnotations;

namespace Medana.API.Entities;

public class Patient
{
    [Key]
    public int Id { get; set; }

    [Required]
    public  PersonalInformation PersonalInformation { get; set; }

    public MedicalHistory MedicalHistory { get; set; }

    public InsuranceInformation InsuranceInformation { get; set; }
}
