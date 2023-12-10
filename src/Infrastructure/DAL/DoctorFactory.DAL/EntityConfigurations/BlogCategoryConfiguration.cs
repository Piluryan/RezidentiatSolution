using DoctorFactory.Domain.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorFactory.DAL.EntityConfigurations;

/// <summary> Blog category configuration. </summary>
internal class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
{
    public void Configure(EntityTypeBuilder<BlogCategory> builder)
    {
        builder.HasIndex(c => c.Name).IsUnique();
    }
}
