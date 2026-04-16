using System.ComponentModel.DataAnnotations;
using Task1.Enums;

namespace Task1.Models;

public class TeacherModel
{
    public int Id { set; get; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string FullName { set; get; }

    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { set; get; }

    [Required]
    [MaxLength(100)]
    public string Specialization { set; get; }

    [Required]
    [StringLength(15, MinimumLength = 10)]
    public string PhoneNumber { set; get; }

    [Required]
    [MaxLength(100)]
    public string Department { set; get; }

    [Required]
    //must not be in the future
    public DateTime HireDate { set; get; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Salary { set; get; }
}
