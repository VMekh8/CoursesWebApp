using CoursesWebApp.Application.Abstract.CRUD;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApp.Infrastructure.Services;

public class StudentService(DBCoursesContext context) : IRepository<StudentEntity>, IReadOnlyRepository<StudentEntity>
{
    public async Task CreateAsync(StudentEntity entity)
    {
        await context.Students.AddAsync(entity);

        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(StudentEntity entity)
    {
        await context.Students
            .Where(e => e.Id == entity.Id)
            .ExecuteUpdateAsync(s => s
                .SetProperty(u => u.Email, entity.Email)
                .SetProperty(u => u.PasswordHash, entity.PasswordHash)
                .SetProperty(u => u.UserProp.FirstName, entity.UserProp.FirstName)
                .SetProperty(u => u.UserProp.LastName, entity.UserProp.LastName)
                .SetProperty(u => u.UserProp.Age, entity.UserProp.Age)
                .SetProperty(u => u.ImageURL, entity.ImageURL));

        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        await context.Students
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<StudentEntity>> GetValuesAsync() =>
        await context.Students
            .AsNoTracking()
            .ToListAsync();
    

    public async Task<StudentEntity?> GetByIdAsync(long id) =>
        await context.Students
            .Where(e => e.Id == id)
            .AsNoTracking()
            .Include(s => s.Enrollments)
            .FirstOrDefaultAsync();
}