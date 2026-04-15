using Task1.Enums;

namespace Task1.Models;

public class TeacherModel
{
    public Guid Id { set; get; }
    public string FullName { set; get; }
    public string Email { set; get; }
    public string Specialization { set; get; }
    public string PhoneNumber { set; get; }
    public string Department { set; get; }
    public DateTime HireDate { set; get; }
    public int Salary { set; get; }
}
