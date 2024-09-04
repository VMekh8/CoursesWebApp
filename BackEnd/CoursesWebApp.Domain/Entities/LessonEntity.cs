using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class LessonEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string LessonText { get; private set; } = string.Empty;
        public string VideoURL { get; private set; } = string.Empty;
        public CourseEntity? Course { get; set; }

        private LessonEntity(string Title, string LessonText, string VideoURL)
        {
            this.Title = Title;
            this.LessonText = LessonText;
            this.VideoURL = VideoURL;
        }

        public static Result<LessonEntity> Create(string Title, string LessonText, string VideoURL)
        {
            if (string.IsNullOrEmpty(Title) || Title.Length > 200)
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