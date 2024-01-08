using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Blog;
using Microsoft.AspNetCore.Identity;

namespace DoctorFactory.Domain.Entities.Identity;

/// <summary> Identity user. </summary>
public class User : IdentityUser
{
    public const string Administrator = "Admin";

    public const string DefaultAdminPassword = "AdPAss_123";

    [InverseProperty(nameof(BlogPost.BlogPostAuthor))]
    public ICollection<BlogPost>? Posts { get; set; } = new HashSet<BlogPost>();

    [InverseProperty(nameof(Course.Course.Instructor))]
    public ICollection<Course.Course>? Courses { get; set; } = new HashSet<Course.Course>();

    /// <summary> Author ocupation. </summary>
    public string? Ocupation { get; set; }

    /// <summary> Description. </summary>
    public string? About { get; set; }
}
