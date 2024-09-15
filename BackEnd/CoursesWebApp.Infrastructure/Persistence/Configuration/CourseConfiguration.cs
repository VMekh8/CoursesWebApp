using CoursesWebApp.Domain.Constants;
using CoursesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesWebApp.Infrastructure.Persistence.Configuration;

public class CourseConfiguration : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Title)
            .HasMaxLength(AppConstant.TITLE_MAX_VALUE)
            .IsRequired();

        builder.Property(c => c.Description)
            .HasMaxLength(AppConstant.DESCRIPTION_MAX_VALUE)
            .IsRequired();

        builder.Property(c => c.ImageURL)
            .IsRequired();

        builder.Property(c => c.Price)
            .IsRequired();

        builder.Property(c => c.Price)
            .IsRequired();

        builder.HasMany(c => c.Enrollments)
            .WithOne(e => e.Course)
            .HasForeignKey("CourseId");

    }
}