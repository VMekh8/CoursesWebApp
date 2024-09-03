using CoursesWebApp.Domain.Entities.ValueObjects.Abstract;

namespace CoursesWebApp.Domain.Entities.ValueObjects
{
    public class User : ValueObject
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

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return FirstName;
            yield return LastName;
            yield return Age;
        }
    }
}
