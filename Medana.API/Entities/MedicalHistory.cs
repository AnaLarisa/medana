using Medana.API.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Medana.API.Entities;

public class MedicalHistory
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public IList<Consultation> Consultations { get; set; }

    public IList<Medication> MedicationAndDosages { get; set; }

    [NotMapped]
    public IList<string>? Allergies { get; set; }
    [Column("Allergies")]
    public string? AllergiesJson
    {
        get => Allergies != null ? JsonSerializer.Serialize(Allergies) : null;
        set => Allergies = value != null ? JsonSerializer.Deserialize<IList<string>>(value) : null;
    }

    [NotMapped]
    public IList<string>? SurgicalHistory { get; set; }

    [Column("SurgicalHistory")]
    public string? SurgicalHistoryJson
    {
        get => SurgicalHistory != null ? JsonSerializer.Serialize(SurgicalHistory) : null;
        set => SurgicalHistory = value != null ? JsonSerializer.Deserialize<IList<string>>(value) : null;
    }

    [NotMapped]
    public IList<string>? ImmunizationHistory { get; set; }

    [Column("ImmunizationHistory")]
    public string? ImmunizationHistoryJson
    {
        get => ImmunizationHistory != null ? JsonSerializer.Serialize(ImmunizationHistory) : null;
        set => ImmunizationHistory = value != null ? JsonSerializer.Deserialize<IList<string>>(value) : null;
    }

    [NotMapped]
    public IList<string>? MedicalConditions { get; set; }

    [Column("MedicalConditions")]
    public string? MedicalConditionsJson
    {
        get => MedicalConditions != null ? JsonSerializer.Serialize(MedicalConditions) : null;
        set => MedicalConditions = value != null ? JsonSerializer.Deserialize<IList<string>>(value) : null;
    }

    public string? FamilyMedicalHistory { get; set; }


    [Required]
    [CNP]
    public string CNP { get; set; }

    [NotMapped]
    public Patient Patient { get; set; } = null!;
}

