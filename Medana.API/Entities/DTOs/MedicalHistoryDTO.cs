using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities.DTOs;

[NotMapped]
public class MedicalHistoryDTO
{
    [Required(ErrorMessage = "Medical conditions are required.")]
    public List<string> MedicalConditions { get; set; }
    public List<ConsultationDTO> Consultations { get; set; }
    public List<MedicationDTO> MedicationAndDosages { get; set; }
    public List<string> Allergies { get; set; }
    public List<string> SurgicalHistory { get; set; }
    public List<string> ImmunizationHistory { get; set; }
    public string FamilyMedicalHistory { get; set; }
}
