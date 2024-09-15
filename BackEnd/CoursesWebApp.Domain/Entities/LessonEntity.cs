using CoursesWebApp.Domain.Constants;
using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class LessonEntity : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string LessonText { get; set; } = string.Empty;
        public string VideoURL { get; set; } = string.Empty;
        public CourseEntity? Course { get; set; }

        private LessonEntity() {}

        private LessonEntity(string Title, string LessonText, string VideoURL)
        {
            this.Title = Title;
            this.LessonText = LessonText;
            this.VideoURL = VideoURL;
        }

        public static Result<LessonEntity> Create(string Title, string LessonText, string VideoURL)
        {
            if (string.IsNullOrEmpty(Title) || Title.Length > AppConstant.TITLE_MAX_VALUE)  
                return Result.Failure<LessonEntity>("Title cannot be empty or exceed more than 200 characters");

            if (string.IsNullOrEmpty(LessonText))
                return Result.Failure<LessonEntity>("Lesson`s text cannot be empty");

            if (Uri.IsWellFormedUriString(VideoURL, UriKind.Absolute))
                return Result.Failure<LessonEntity>("Invalid URL format for video");

            return new LessonEntity(
                Title: Title,
                LessonText: LessonText,
                VideoURL: VideoURL
                );
        }

    }
}