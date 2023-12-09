using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Course requirement. </summary>
public class CourseRequirement : Entity
{
    [InverseProperty(nameof(Course.Requirements))]
    public Course Course { get; set; } = null!;

    /// <summary> Content of requirement. </summary>
    public required string Content { get; set; }
}
