using CoursesWebApp.Domain.Entities.ValueObjects;
using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class StudentEntity : Entity
    {
        public User UserProp { get; private set; }
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public string? ImageURL { get; private set; } = string.Empty;
        public List<EnrollmentEntity> Enrollments { get; set; } = [];

        private StudentEntity(User UserProp, string Email, string PasswordHash, string? ImageURL)
        {
            this.UserProp = UserProp;   
            this.Email = Email;
            this.PasswordHash = PasswordHash;
            this.ImageURL = ImageURL;
        }

        public static Result<StudentEntity> Create(User user, string email, string pass, string? imageUrl)
        {
            if (user is null) 
                return Result.Failure<StudentEntity>("User param`s cannot be null");

            if (string.IsNullOrWhiteSpace(user.FirstName) || string.IsNullOrWhiteSpace(user.LastName))
                return Result.Failure<StudentEntity>("Firstname and lastname fields cannot be null");

            if (user.FirstName.Length > 150 || user.LastName.Length > 150)
                return Result.Failure<StudentEntity>("Length of Firstname and Lastname fields cannot exceed, than 150 characters");

            if (user.Age < 0) 
                return Result.Failure<StudentEntity>("User`s age cannot be less than 0");

            if (Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
                return Result.Failure<StudentEntity>("Invalid URL format");

            user.FirstName.Trim();
            user.LastName.Trim();
            email.Trim();

            return new StudentEntity(
                UserProp: user,
                Email: email,
                PasswordHash: pass,
                ImageURL: imageUrl
                );

        }

    }
}
