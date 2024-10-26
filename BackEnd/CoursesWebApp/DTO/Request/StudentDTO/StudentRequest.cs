using CoursesWebApp.Domain.Entities;

namespace CoursesWebApp.API.DTO.Request.StudentDTO;

public record StudentRequest(
    string Firsname,
    string Lastname,
    decimal Age,
    string? ImageURl,
    List<EnrollmentEntity> Enrollments 
    );