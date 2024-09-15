using CoursesWebApp.Domain.Constants;
using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class CourseEntity : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<LessonEntity> Lessons { get; set; } = [];
        public List<TeacherEntity> Teachers { get; set; } = [];
        public List<EnrollmentEntity> Enrollments { get; set; } = [];


        private CourseEntity(string Title, string Description, string ImageURL, decimal Price)
        {
            this.Title = Title;
            this.Description = Description;
            this.ImageURL = ImageURL;
            this.Price = Price;
        }

        public static Result<CourseEntity> Create(string Title, string Description, string ImageURL, decimal Price)
        {
            if (string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Description))
                return Result.Failure<CourseEntity>("Title and Description cannot be empty");

            if (Title.Length > AppConstant.TITLE_MAX_VALUE || Description.Length > AppConstant.DESCRIPTION_MAX_VALUE)
                return Result.Failure<CourseEntity>("the title or description fields have exceeded the character limit");

            if (Price < 0)
                return Result.Failure<CourseEntity>("Price for course cannot be less, than 0");

            if (Uri.IsWellFormedUriString(ImageURL, UriKind.Absolute))
                return Result.Failure<CourseEntity>("Image url invalid format");

            return new CourseEntity(
                Title: Title,
                Description: Description,
                ImageURL: ImageURL,
                Price: Price
                );
        }

    }
}