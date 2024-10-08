﻿using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApp.Infrastructure.Services;

public class CourseService(DBCoursesContext context)
    : IRepository<CourseEntity>, IReadOnlyRepository<CourseEntity>
{
    public async Task CreateAsync(CourseEntity entity)
    {
        await context.Courses.AddAsync(entity);

        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CourseEntity entity)
    {
        await context.Courses
            .Where(c => c.Id == entity.Id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(u => u.Title, entity.Title)
                .SetProperty(u => u.Description, entity.Description)
                .SetProperty(u => u.ImageURL, entity.ImageURL)
                .SetProperty(u => u.Price, entity.Price)
            );

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        await context.Courses
            .Where(c => c.Id == id)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<CourseEntity>> GetValuesAsync()
    {
        return await context.Courses
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CourseEntity?> GetByIdAsync(long id)
    {
        return await context.Courses
            .Include(c => c.Lessons)
            .Include(c => c.Enrollments)
            .Include(c => c.Teachers)
            .FirstOrDefaultAsync(u => u.Id == id);
    }
}
