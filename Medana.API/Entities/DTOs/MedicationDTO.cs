using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities.DTOs;

[NotMapped]
public class MedicationDTO
{
    public string MedicationName { get; set; }
    public string Dosage { get; set; }
    public string Frequency { get; set; }
}
