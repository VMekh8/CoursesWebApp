using CoursesWebApp.Domain.Constants;
using CoursesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesWebApp.Infrastructure.Persistence.Configuration;

public class TeacherConfiguration : IEntityTypeConfiguration<TeacherEntity>
{
    public void Configure(EntityTypeBuilder<TeacherEntity> builder)
    {
        builder.HasKey(t => t.Id);

        builder.ComplexProperty(t => t.UserProp, u =>
        {
            u.Property(user => user.FirstName)
                .HasColumnName("Firstname")
                .HasMaxLength(AppConstant.USER_MAX_VALUE)
                .IsRequired();

            u.Property(user => user.LastName)
                .HasColumnName("Lastname")
                .HasMaxLength(AppConstant.USER_MAX_VALUE)
                .IsRequired();

            u.Property(user => user.Age)
                .HasColumnName("Age")
                .IsRequired();
        });

        builder.Property(t => t.AboutTeacher)
            .IsRequired();

        builder.Property(t => t.Email)
            .IsRequired();

        builder.Property(t => t.ImageURL)
            .IsRequired();

        builder.Property(t => t.PasswordHash)
            .IsRequired();

        builder.HasMany(t => t.Courses)
            .WithMany(c => c.Teachers)
            .UsingEntity<Dictionary<string, object>>
            ("Teachers_on_Course",
                j => j.HasOne<CourseEntity>().WithMany().HasForeignKey("CourseId"),
                i => i.HasOne<TeacherEntity>().WithMany().HasForeignKey("TeacherId"));
    }
}