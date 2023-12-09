using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Lesson content. </summary>
public class LessonContent : NamedEntity
{
    /// <summary> Lesson. </summary>
    [InverseProperty(nameof(Lesson.Content))]
    public Lesson Lesson { get; set; } = null!;

    /// <summary> Video. </summary>
    public string? Video { get; set; }

    /// <summary> Text. </summary>
    public string Text { get; set; } = null!;
}
