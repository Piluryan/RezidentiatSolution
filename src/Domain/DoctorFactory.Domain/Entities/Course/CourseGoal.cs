using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Course goal. </summary>
public class CourseGoal : Entity
{
    /// <summary> Course. </summary>
    [InverseProperty(nameof(Course.Goals))]
    public required Course Course { get; set; }

    /// <summary> Content of goal. </summary>
    public required string Content { get; set; }
}
