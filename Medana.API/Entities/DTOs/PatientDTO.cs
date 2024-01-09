using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities.DTOs;

[NotMapped]
public class PatientDTO
{
    [Required]
    public PersonalInformationDTO PersonalInformation { get; set; }
    public MedicalHistoryDTO MedicalHistory { get; set; }
    public InsuranceInformationDTO InsuranceInformation { get; set; }
}