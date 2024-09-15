using CoursesWebApp.Domain.Constants;
using CoursesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesWebApp.Infrastructure.Persistence.Configuration;

public class LessonConfiguration : IEntityTypeConfiguration<LessonEntity>
{
    public void Configure(EntityTypeBuilder<LessonEntity> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Title)
            .HasMaxLength(AppConstant.TITLE_MAX_VALUE)
            .IsRequired();

        builder.Property(l => l.LessonText)
            .IsRequired();

        builder.Property(l => l.VideoURL)
            .IsRequired();

        builder.HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey("CourseId");
    }
}