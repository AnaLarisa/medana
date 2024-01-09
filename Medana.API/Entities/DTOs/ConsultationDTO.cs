using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities.DTOs;

[NotMapped]
public class ConsultationDTO
{
    [Required(ErrorMessage = "Consultation date is required.")]
    [DataType(DataType.DateTime)]
    public DateTime ConsultationDate { get; set; }

    [Required(ErrorMessage = "Symptoms and complaints are required.")]
    public string Symptoms { get; set; }
    public string Diagnosis { get; set; }
    public string TreatmentPlan { get; set; }
    public string Notes { get; set; }
    public string Prescriptions { get; set; }

    [Range(0, 240, ErrorMessage = "Invalid blood pressure value.")]
    public int BloodPressure { get; set; }

    [Range(0, 300, ErrorMessage = "Invalid heart rate value.")]
    public int HeartRate { get; set; }

    [Range(0, 40, ErrorMessage = "Invalid respiratory rate value.")]
    public int RespiratoryRate { get; set; }

    [Range(35.0, 42.0, ErrorMessage = "Invalid temperature value.")]
    public double Temperature { get; set; }
}
