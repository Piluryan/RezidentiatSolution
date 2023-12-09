using System.ComponentModel.DataAnnotations.Schema;
using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Quiz answer. </summary>
public class QuizAnswer : Entity
{
    [InverseProperty(nameof(Quiz.Answers))]
    public required Quiz Quiz { get; set; }

    /// <summary> Answer. </summary>
    public required string Answer { get; set; }

    /// <summary> Is right or no answer. </summary>
    public bool IsRight { get; set; }
}
