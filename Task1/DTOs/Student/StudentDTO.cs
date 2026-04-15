using MediatR;
using Task1.Enums;

namespace Task1.DTOs.Student
{
    public record StudentRequest(
     string FullName,
     string Email,
     int Age,
     Gender StudentGender,
     string PhoneNumber,
     string? Address,
     string Department,
     DateTime EnrollmentDate
    ) : IRequest<StudentResponse>;
    
    public record StudentResponse(
     string FullName,
     string Email,
     int Age,
     Gender StudentGender,
     string PhoneNumber,
     string? Address,
     string Department,
     DateTime EnrollmentDate
    );
}