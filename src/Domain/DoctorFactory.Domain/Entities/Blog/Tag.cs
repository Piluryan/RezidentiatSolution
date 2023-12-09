using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Blog;

/// <summary> Tag. </summary>
public class Tag : NamedEntity
{
    /// <summary> Blog posts of tag. </summary>
    public ICollection<BlogPost> Posts { get; set; } = new HashSet<BlogPost>();
}
