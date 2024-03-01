using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities.DTOs;

[NotMapped]
public class InsuranceInformationDTO
{
    public string InsuranceProvider { get; set; }
    public string InsurancePolicyNumber { get; set; }
}
