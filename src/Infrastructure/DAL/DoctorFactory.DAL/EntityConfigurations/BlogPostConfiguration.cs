using DoctorFactory.Domain.Entities.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorFactory.DAL.EntityConfigurations;

/// <summary> Blog post configuration. </summary>
internal class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.HasMany(x => x.Tags).WithMany(x => x.Posts)
            .UsingEntity<Dictionary<string, object>>("BlogPostTag",
                x => x.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.Cascade),
                x => x.HasOne<BlogPost>().WithMany().HasForeignKey("BlogPostId").OnDelete(DeleteBehavior.Cascade));

        builder.HasOne(x => x.BlogPostAuthor).WithMany(x => x.Posts).OnDelete(DeleteBehavior.Cascade);
    }
}
