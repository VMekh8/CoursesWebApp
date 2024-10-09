using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApp.Infrastructure.Services;

public class LessonService(DBCoursesContext context) : IRepository<LessonEntity>, IReadOnlyRepository<LessonEntity>
{
    public async Task CreateAsync(LessonEntity entity)
    {
        await context.Lessons.AddAsync(entity);

        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(LessonEntity entity)
    {
        await context.Lessons
            .Where(l => l.Id == entity.Id)
            .ExecuteUpdateAsync(e => e
                .SetProperty(u => u.Title, entity.Title)
                .SetProperty(u => u.LessonText, entity.LessonText)
                .SetProperty(u => u.VideoURL, entity.VideoURL)
                .SetProperty(u => u.Course, entity.Course)
            );

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        await context.Lessons
            .Where(l => l.Id == id)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<LessonEntity>> GetValuesAsync()
    {
        return await context.Lessons
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<LessonEntity?> GetByIdAsync(long id)
    {
        return await context.Lessons
            .Include(l => l.Course)
            .FirstOrDefaultAsync(l => l.Id == id);
    }
}