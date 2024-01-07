using System.ComponentModel.DataAnnotations;

namespace Medana.API.Entities;

public class MedicalHistory
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Medical conditions are required.")]
    public IList<string> MedicalConditions { get; set; }

    public IList<Consultation> Consultations { get; set; }

    public IList<Medication> MedicationAndDosages { get; set; }

    public IList<string> Allergies { get; set; }

    public IList<string> SurgicalHistory { get; set; }

    public IList<string> ImmunizationHistory { get; set; }

    public string FamilyMedicalHistory { get; set; }
}

