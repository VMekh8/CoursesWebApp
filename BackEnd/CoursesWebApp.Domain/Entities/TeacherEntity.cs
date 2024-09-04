using CoursesWebApp.Domain.Entities.ValueObjects;
using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class TeacherEntity : Entity
    {
        public User UserProp { get; set; }
        public string AboutTeacher {  get; set; } = string.Empty;
        public List<CourseEntity> Courses { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;


    }
}