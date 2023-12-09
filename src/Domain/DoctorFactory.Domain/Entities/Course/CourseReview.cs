using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Course review. </summary>
public class CourseReview : Review
{
    [InverseProperty(nameof(Course.Reviews))]
    public Course Course { get; set; } = null!;
}
