﻿namespace CoursesWebApp.Application.Abstract.CRUD
{
    public interface IRepository<T> where T : class, IReadOnlyRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(long id);
    }
}
