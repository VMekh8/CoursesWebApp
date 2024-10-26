namespace CoursesWebApp.API.DTO.Responce.NewsDTO;

public record NewsResponce(
    long NewsId,
    string Title,
    string Description,
    string ImageURL
    );