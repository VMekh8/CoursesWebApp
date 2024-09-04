using CoursesWebApp.Domain.Entities.ValueObjects;
using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class TeacherEntity : Entity
    {
        public User UserProp { get; set; }
        public string AboutTeacher {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public List<CourseEntity> Courses { get; set; }

        private TeacherEntity(User UserProp, string AboutTeacher, string Email, string PasswordHash, string ImageURL)
        {
            this.UserProp = UserProp;
            this.AboutTeacher = AboutTeacher;
            this.Email = Email;
            this.PasswordHash = PasswordHash;
            this.ImageURL = ImageURL;
        }

        public static Result<TeacherEntity> Create(User user, string about, string email, string passwordHash, string imageURL)
        {
            if (user is null)
                return Result.Failure<TeacherEntity>("User property`s cannot be null");

            if (string.IsNullOrEmpty(about) || about.Length > 200)
                return Result.Failure<TeacherEntity>("About Teacher field error");

            if (string.IsNullOrWhiteSpace(email))
                return Result.Failure<TeacherEntity>("Teacher Email field error");

            if (string.IsNullOrEmpty(passwordHash))
                return Result.Failure<TeacherEntity>("Password field cannot be empty");

            if (Uri.IsWellFormedUriString(imageURL, UriKind.Absolute))
                return Result.Failure<TeacherEntity>("Teacher Image Url invalid format");

            return new TeacherEntity(
                UserProp: user,
                AboutTeacher: about,
                Email: email,
                PasswordHash: passwordHash,
                ImageURL: imageURL
                );
        }

    }
}