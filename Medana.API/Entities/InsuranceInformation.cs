using Medana.API.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medana.API.Entities;

public class InsuranceInformation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string InsuranceProvider { get; set; }

    public string InsurancePolicyNumber { get; set; }


    [Required]
    [CNP]
    public string CNP { get; set; }

    [NotMapped]
    public Patient Patient { get; set; } = null!;
}

