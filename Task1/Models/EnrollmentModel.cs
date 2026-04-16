using System.ComponentModel.DataAnnotations;
using Task1.Enums;

namespace Task1.Models;

public class EnrollmentModel
{
    // add student & course Id's as foriegn keys
    public int Id { set; get; }

    [Range(0, 100)]
    public decimal? Grade { set; get; }

    [Required]
    [RegularExpression("Active|Completed|Dropped")]
    public string Status { set; get; }

    [Required]
    public DateTime EnrollmentDate { set; get; }

    [Required]
    public int StudentId { set; get; }
    public StudentModel? Student { set; get; }

    [Required]
    public int CourseId { set; get; }
    public CourseModel? Course { set; get; }
}
