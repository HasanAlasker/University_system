using Task1.Enums;

namespace Task1.Models;

public class EnrollmentModel
{
    // add student & course Id's as foriegn keys
    public Guid Id { set; get; }
    public string FullName { set; get; }
    public decimal Grade { set; get; }
    public string Status { set; get; }
    public DateTime EnrollmentDate { set; get; }
}
