using System.ComponentModel.DataAnnotations;
using Task1.Enums;

namespace Task1.Models;

public class CourseModel
{
    public int Id { set; get; }

    [Required]
    [MaxLength(20)]
    public string CourseCode { set; get; }

    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string CourseName { set; get; }

    [MaxLength(500)]
    public string? Description { set; get; }

    [Required]
    [Range(1, 6)]
    public int Credits { set; get; }

    [Required]
    [Range(1, 100)]
    public int Capacity { set; get; }

    [Required]
    [MaxLength(100)]
    public string Department { set; get; }

    [Required]
    public DateTime StartDate { set; get; }

    [Required]
    public DateTime EndDate { set; get; }

    [Required]
    public int TeacherId { get; set; }

    public TeacherModel? Teacher { set; get; }
}
