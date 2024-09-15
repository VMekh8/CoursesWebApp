using CoursesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesWebApp.Infrastructure.Persistence.Configuration;

public class EnrollmentConfiguration : IEntityTypeConfiguration<EnrollmentEntity>
{
    public void Configure(EntityTypeBuilder<EnrollmentEntity> builder)
    {
        builder.HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey("StudentId");

        builder.HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey("CourseId");
    }
}