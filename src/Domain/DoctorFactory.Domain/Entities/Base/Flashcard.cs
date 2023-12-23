using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Course;

namespace DoctorFactory.Domain.Entities.Base;

/// <summary> Flashcard. </summary>
public class Flashcard : NamedEntity
{
    /// <summary> Lesson. </summary>
    [InverseProperty(nameof(Lesson.Flashcards))]
    public required Lesson Lesson { get; set; }

    /// <summary> Question. </summary>
    public required string Question { get; set; }

    /// <summary> Answer. </summary>
    public required string Answer { get; set; }
}
