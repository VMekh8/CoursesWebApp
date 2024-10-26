namespace CoursesWebApp.API.DTO.Responce.StudentDTO;

public record StudentResponce(
    long StudentId,
    string Firsname,
    string Lastname, 
    decimal Age,
    string? ImageURl,
    List<long> EnrollmentsId
    );