using Task1.Enums;

namespace Task1.Models;

public class StudentModel
{
    public Guid Id { set; get; }
    public string FullName { set; get; }

    public string Email { set; get; }
    public int Age { set; get; }
    public Gender StudentGender { set; get; }
    public string PhoneNumber { set; get; }
    public string? Address { set; get; }
    public string Department { set; get; }
    public DateTime EnrollmentDate {set; get;}
}
