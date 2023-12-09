using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Course category. </summary>
public class CourseCategory : NamedEntity
{
    /// <summary> Parent  </summary> 
    public CourseCategory? Parent { get; set; }

    /// <summary> Logo img. </summary>
    public string? Img { get; set; }

    [InverseProperty(nameof(Course.Category))]
    public ICollection<Course> Courses { get; set; } = new HashSet<Course>();
}
