using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Blog;

/// <summary> Blog category. </summary> 
public class BlogCategory : NamedEntity
{
    /// <summary> Parent id. </summary>
    public int? ParentId { get; set; }

    /// <summary> Blog category parent. </summary>
    public BlogCategory? Parent { get; set; }

    /// <summary> Blog posts of category. </summary>
    public ICollection<BlogPost> Posts { get; set; } = new HashSet<BlogPost>();
}
