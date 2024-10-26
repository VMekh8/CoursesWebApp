namespace CoursesWebApp.API.DTO.Request.NewsDTO;

public record NewsRequest(
    string Title,
    string Description,
    string ImageURl
    );