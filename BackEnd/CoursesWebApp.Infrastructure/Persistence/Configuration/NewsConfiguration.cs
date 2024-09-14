
using CoursesWebApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoursesWebApp.Infrastructure.Persistence.Configuration
{
    public class NewsConfiguration : IEntityTypeConfiguration<NewsEntity>
    {
        public void Configure(EntityTypeBuilder<NewsEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Title)
                .IsRequired();

            builder.Property(e => e.Description)
                .IsRequired();

            builder.Property(e => e.ImageURL)
                .IsRequired();

        }
    }
}
