using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Lesson quiz. </summary>
public class Quiz : Entity
{
    [InverseProperty(nameof(Lesson.Quizzes))]
    public Lesson Lesson { get; set; } = null!;

    /// <summary> Quiz question. </summary>
    public required string Question { get; set; }

    /// <summary> Answers. </summary>
    public required ICollection<QuizAnswer> Answers { get; set; } = new HashSet<QuizAnswer>();
}
