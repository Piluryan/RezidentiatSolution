using DoctorFactory.Domain.Entities.Course;

namespace DoctorFactory.Domain.Entities.Base;

/// <summary> Flashcard. </summary>
public class Flashcard : NamedEntity
{
    /// <summary> Lesson id. </summary>
    public required int LessonId { get; set; }

    /// <summary> Lesson. </summary> 
    public required Lesson Lesson { get; set; }

    /// <summary> Category. </summary>
    public CourseCategory CourseCategory { get; set; } = null!;

    /// <summary> Question. </summary>
    public required string Question { get; set; }

    /// <summary> Answer. </summary>
    public required string Answer { get; set; }
}
