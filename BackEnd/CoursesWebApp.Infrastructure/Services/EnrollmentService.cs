using CoursesWebApp.Application.Abstract.Enrollment;
using CoursesWebApp.Domain.Entities;
using CoursesWebApp.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApp.Infrastructure.Services;

public class EnrollmentService(DBCoursesContext context) : IEnrollmentRepository
{
    public async Task<EnrollmentEntity> AddNewEnrollmentAsync(EnrollmentEntity enrollment)
    {
        await context.Enrollments.AddAsync(enrollment);

        await context.SaveChangesAsync();

        return enrollment;
    }

    public async Task<EnrollmentEntity> DeleteEnrollment(long id)
    {
        await context.Enrollments
            .Where(e => e.Id == id)
            .ExecuteDeleteAsync();

        await context.SaveChangesAsync();

        return await context.Enrollments.FirstAsync(e => e.Id == id);
    }
}