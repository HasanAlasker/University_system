using System.ComponentModel.DataAnnotations;
using Task1.Enums;

namespace Task1.Models;

public class StudentModel
{
    public int Id { set; get; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string FullName { set; get; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { set; get; }

    [Required]
    [Range(18, 60)]
    public int Age { set; get; }

    [Required]
    [RegularExpression("Male|Female")]
    public Gender StudentGender { set; get; }

    [Required]
    [StringLength(15, MinimumLength = 10)]
    public string PhoneNumber { set; get; }

    [StringLength(200)]
    public string? Address { set; get; }

    [Required]
    [StringLength(100)]
    public string Department { set; get; }

    [Required]
    public DateTime EnrollmentDate { set; get; }
}
