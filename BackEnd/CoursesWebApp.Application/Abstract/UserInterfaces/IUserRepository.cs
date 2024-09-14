namespace CoursesWebApp.Application.Abstract.UserInterfaces
{
    public interface IUserRepository<T> where T : class
    {
        Task<T> RegisterUserAsync(T user);
        Task<T> LoginAsync(string email, string password);
        Task LogoutAsync();
    }
}

