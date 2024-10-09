using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApp.Infrastructure.Services;

public class TeacherService(DBCoursesContext context) : IRepository<TeacherEntity>, IReadOnlyRepository<TeacherEntity>
{
    public async Task CreateAsync(TeacherEntity entity)
    {
        await context.Teachers.AddAsync(entity);

        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TeacherEntity entity)
    {
        await context.Teachers
            .Where(t => t.Id == entity.Id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(u => u.UserProp.FirstName, entity.UserProp.FirstName)
                    .SetProperty(u => u.UserProp.LastName, entity.UserProp.LastName)
                    .SetProperty(u => u.UserProp.Age, entity.UserProp.Age)
                    .SetProperty(u => u.AboutTeacher, entity.AboutTeacher)
                    .SetProperty(u => u.Email, entity.Email)
                    .SetProperty(u => u.PasswordHash, entity.PasswordHash)
                    .SetProperty(u => u.ImageURL, entity.ImageURL)
                    .SetProperty(u => u.Courses, entity.Courses));

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
         await context.Teachers
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();

         await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<TeacherEntity>> GetValuesAsync()
    {
        return await context.Teachers
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<TeacherEntity?> GetByIdAsync(long id)
    {
        return await context.Teachers
            .Include(t => t.Courses)
            .FirstOrDefaultAsync(t => t.Id == id);

    }
}