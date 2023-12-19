using System.ComponentModel.DataAnnotations;

namespace Medana.API.Entities;

public class Patient
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Required]
    public string Sex { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    [MaxLength(13)]
    public string CNP { get; set; }
    [MaxLength(100)]
    public string Email { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    [Required]
    public string Occupation { get; set; }
}
