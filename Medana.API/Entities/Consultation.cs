using Medana.API.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities;

public class Consultation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Consultation date is required.")]
    [DataType(DataType.DateTime)]
    public DateTime ConsultationDate { get; set; }

    [Required(ErrorMessage = "Symptoms and complaints are required.")]
    public string Symptoms { get; set; }

    public string Diagnosis { get; set; }

    public string TreatmentPlan { get; set; }

    public string Notes { get; set; }
    public string Prescriptions { get; set; }
    public int BloodPressure { get; set; }
    public int HeartRate { get; set; }
    public int RespiratoryRate { get; set; }
    public double Temperature { get; set; }

    [Required]
    [CNP]
    public string PatientCNP { get; set; }
}
