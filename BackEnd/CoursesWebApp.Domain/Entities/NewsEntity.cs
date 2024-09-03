using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities
{
    public class NewsEntity : Entity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageURL { get; set; }

        private NewsEntity(string Title, string Description, string ImageURL)
        {
            this.Title = Title;
            this.Description = Description;
            this.ImageURL = ImageURL;
        }

        public static Result<NewsEntity> Create(string title, string desc, string url)
        {
            
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(desc))
                return Result.Failure<NewsEntity>("News title and description must be filled");

            if (string.IsNullOrEmpty(url))
                return Result.Failure<NewsEntity>("Image Url can`t be empty");

            title.Trim();
            desc.Trim();
            url.Trim();

            if (title.Length > 200)
                return Result.Failure<NewsEntity>("Title can`t be longer, than 200 symbol`s");

            if (desc.Length > 1000)
                return Result.Failure<NewsEntity>("Description can`t be longer, than 1000 symbol`s");

            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
                return Result.Failure<NewsEntity>("Invalid URL format");

            var news = new NewsEntity(
                Title: title,
                Description: desc,
                ImageURL: url
                );

            return Result.Success(news);

        }

    }
}
