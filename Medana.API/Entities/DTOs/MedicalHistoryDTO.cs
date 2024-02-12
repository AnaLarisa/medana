using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities.DTOs;

[NotMapped]
public class MedicalHistoryDTO
{
    [Required(ErrorMessage = "Medical conditions are required.")]
    public IList<string>? MedicalConditions { get; set; }
    public IList<ConsultationDTO> Consultations { get; set; }
    public IList<MedicationDTO> MedicationAndDosages { get; set; }
    public IList<string>? Allergies { get; set; }
    public IList<string>? SurgicalHistory { get; set; }
    public IList<string>? ImmunizationHistory { get; set; }
    public string? FamilyMedicalHistory { get; set; }
}
