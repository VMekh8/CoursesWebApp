using CoursesWebApp.Domain.Entities.ValueObjects;
using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class StudentEntity : Entity
    {
        public User UserProp { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? ImageURL { get; set; } = string.Empty;
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
