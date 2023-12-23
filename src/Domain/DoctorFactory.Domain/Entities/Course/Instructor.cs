using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Course instructor. </summary>
public class Instructor : NamedEntity
{
    public ICollection<Course>? Courses { get; set; } = new HashSet<Course>();

    /// <summary> Author ocupation. </summary>
    public string? Ocupation { get; set; }

    /// <summary> Description. </summary>
    public string? About { get; set; }
}
