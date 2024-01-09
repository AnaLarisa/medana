using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Medana.API.Entities.DTOs;

[NotMapped]
public class MedicationDTO
{
    public string MedicationName;
    public string Dosage;
    public string Frequency;
}
