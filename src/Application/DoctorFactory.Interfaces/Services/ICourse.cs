using DoctorFactory.Domain.Entities.Course;

namespace DoctorFactory.Interfaces.Services;

/// <summary> Course methods. </summary>
public interface ICourse
{
    /// <summary> Get all course categories. </summary>
    /// <returns> An IEnumerable of <see cref="CourseCategory"/></returns> 
    IEnumerable<CourseCategory> GetCourseCategories();
}
