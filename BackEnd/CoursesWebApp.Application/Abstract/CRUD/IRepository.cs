﻿namespace CoursesWebApp.Application.Abstract.CRUD
{
    public interface IRepository<in T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);
    }
}
