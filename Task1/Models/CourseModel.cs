using Task1.Enums;

namespace Task1.Models;

public class CourseModel
{
    public Guid Id { set; get; }
    public string CourseCode { set; get; }
    public string CourseName { set; get; }
    public string? Description { set; get; }
    public string Specialization { set; get; }
    public int Credits { set; get; }
    public int Capacity { set; get; }
    public string Department { set; get; }
    public DateTime StartDate { set; get; }
    public DateTime EndDate { set; get; }
     
    // Add teacher id as foreign key
}
