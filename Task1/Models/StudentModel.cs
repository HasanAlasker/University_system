using System.ComponentModel.DataAnnotations;
using Task1.Enums;
using Task1.Validation;

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
    [NotInFuture]
    public DateTime EnrollmentDate { set; get; }
}
