using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Blog;

/// <summary> Blog author. </summary>
public class Author : NamedEntity
{
    [InverseProperty(nameof(BlogPost.BlogPostAuthor))]
    public ICollection<BlogPost> Posts { get; set; } = new HashSet<BlogPost>();

    /// <summary> Author ocupation. </summary>
    public string? Ocupation { get; set; }

    /// <summary> Description. </summary>
    public string? About { get; set; }
}
