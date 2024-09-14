using CoursesWebApp.Domain.Constants;
using CoursesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesWebApp.Infrastructure.Persistence.Configuration;

public class StudentConfiguration : IEntityTypeConfiguration<StudentEntity>
{
    public void Configure(EntityTypeBuilder<StudentEntity> builder)
    {
        builder.HasKey(s => s.Id);

        builder.ComplexProperty(s => s.UserProp, u =>
        {
            u.Property(user => user.FirstName)
                .HasColumnName("Firstname")
                .IsRequired()
                .HasMaxLength(AppConstant.USER_MAX_VALUE);


            u.Property(user => user.LastName)
                .HasColumnName("Lastname")
                .IsRequired()
                .HasMaxLength(AppConstant.USER_MAX_VALUE);


            u.Property(user => user.Age)
                .HasColumnName("Age")
                .IsRequired();

        });

        builder.Property(s => s.Email)
            .IsRequired();

        builder.Property(s => s.PasswordHash)
            .IsRequired();

        builder.Property(s => s.ImageURL)
            .IsRequired();

    }
}