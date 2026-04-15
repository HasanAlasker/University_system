using Microsoft.VisualBasic;
using Task1.Enums;

namespace Task1.Models;

public class EnrollmentModel
{
    public Guid Id { set; get; }
    public string FullName { set; get; }

    // add student & course Id's as foregin keys
    public decimal Grade { set; get; }
    public string Status { set; get; }
    public DateAndTime EnrollmentDate { set; get; }
}
