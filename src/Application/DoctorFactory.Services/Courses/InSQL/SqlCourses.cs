using DoctorFactory.DAL.Context;
using DoctorFactory.Domain.Entities.Course;
using DoctorFactory.Interfaces.Services;

namespace DoctorFactory.Services.Courses.InSQL;

/// <inheritdoc cref="ICourse"/>
internal class SqlCourses : ICourse
{
    private readonly RezidentDatabase _db;

    public SqlCourses(RezidentDatabase db) => _db = db;
    
    public IEnumerable<CourseCategory> GetCourseCategories()
    {
        var categories = _db.CourseCategories.ToList();

        return categories;
    }
}
