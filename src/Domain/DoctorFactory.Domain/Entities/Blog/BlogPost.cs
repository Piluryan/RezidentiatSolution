using DoctorFactory.Domain.Entities.Base;
using DoctorFactory.Domain.Entities.Identity;

namespace DoctorFactory.Domain.Entities.Blog;

/// <summary> Blog post. </summary>
public class BlogPost : Entity
{
    /// <summary> Category. </summary>
    public required BlogCategory Category { get; set; }

    /// <summary> Post author. </summary>
    public required User BlogPostAuthor { get; set; }

    /// <summary> Post title. </summary>
    public required string Title { get; set; }

    /// <summary> Creation date. </summary>
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

    /// <summary> Update date. </summary>
    public DateTimeOffset? DateUpdate { get; set; }

    /// <summary> Post main image. </summary>
    public required string MainImage { get; set; }

    /// <summary> Post content. </summary>
    public required string Content { get; set; }

    /// <summary> Tags. </summary>
    public ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();

    /// <summary>Post reviews. </summary>
    public ICollection<BlogReview>? Reviews { get; set; } = new HashSet<BlogReview>();

    /// <summary> Is blog post deleted. </summary>
    public bool IsDeleted { get; set; }
}
