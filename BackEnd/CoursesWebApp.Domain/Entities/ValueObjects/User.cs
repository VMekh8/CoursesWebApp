using CSharpFunctionalExtensions;

namespace CoursesWebApp.Domain.Entities.ValueObjects
{
    public class User : Abstract.ValueObject
    {
        public string FirstName { get; private set;} = string.Empty;
        public string LastName { get; private set;} = string.Empty;
        public int Age { get; private set; } = int.MinValue;

        public User(string FirstName, string LastName, int Age)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Age = Age;
        }

        public static Result<User> Create(string name, string surname, int age)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                return Result.Failure<User>("The Firstname and Lastname fields can`t be empty!");

            if (age < 0)
                return Result.Failure<User>("A person`s age can`t be less than 0");

            if (name.Length > 150 || surname.Length > 150)
                return Result.Failure<User>("Length of Firstname and Lastname fields cannot exceed, than 150 characters");

            return new User(name, surname, age);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return Age;
        }
    }
}
