using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities;

public class Patient
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public virtual PersonalInformation PersonalInformation { get; set; }

    public virtual MedicalHistory MedicalHistory { get; set; }
    
    public InsuranceInformation InsuranceInformation { get; set; }
}
