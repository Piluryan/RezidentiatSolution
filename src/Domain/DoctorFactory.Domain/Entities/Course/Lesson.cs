using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Lesson of course. </summary>
public class Lesson : NamedEntity
{
    [InverseProperty(nameof(Course.Content))]
    public Course Course { get; set; } = null!;

    /// <summary> Duration. </summary>
    public double Duration { get; set; }

    /// <summary> Lesson content. </summary>
    public required ICollection<LessonContent> Content { get; set; } = new HashSet<LessonContent>();

    /// <summary> Lesson quizzes. </summary>
    public ICollection<Quiz>? Quizzes { get; set; } = new HashSet<Quiz>();

    /// <summary> Flashcards. </summary>
    public ICollection<Flashcard>? Flashcards { get; set; } = new HashSet<Flashcard>();

    /// <summary> Is avaible lesson or not. </summary>
    public bool IsAvaible { get; set; }
}
