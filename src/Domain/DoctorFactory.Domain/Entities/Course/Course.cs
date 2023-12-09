using DoctorFactory.Domain.Entities.Base;
using DoctorFactory.Domain.Shared;

namespace DoctorFactory.Domain.Entities.Course;

/// <summary> Course. </summary>
public class Course : NamedEntity
{
    /// <summary> Category. </summary>
    public required CourseCategory Category { get; set; }

    /// <summary> Intructor. </summary>
    public ICollection<Instructor>? Instructors { get; set; } = new HashSet<Instructor>();

    /// <summary> Short description. </summary>
    public required string ShortDescription { get; set; }

    /// <summary> Description. </summary>
    public required string Description { get; set; }

    /// <summary> Image. </summary>
    public required string Image { get; set; }

    /// <summary> Skill level. </summary>
    public required SkillLevel SkillLevel { get; set; }

    /// <summary> Presentation video. </summary>
    public string? PresentationVideo { get; set; }

    /// <summary> Creation date. </summary>
    public required DateTimeOffset DateCreation { get; set; } = DateTimeOffset.Now;

    /// <summary> Date of course update. </summary>
    public DateTimeOffset? DateUpdate { get; set; }

    /// <summary> Enrolled count. </summary>
    public int Enrolled { get; set; }

    /// <summary> Price. </summary>
    public decimal Price { get; set; }

    /// <summary> Discount. </summary>
    public int Discount { get; set; }

    /// <summary> Is deleted. </summary>
    public bool IsDeleted { get; set; }

    /// <summary> Countent of course. </summary> 
    public required ICollection<Lesson> Content { get; set; } = new HashSet<Lesson>();

    /// <summary> Goals / achievements. </summary>
    public virtual required ICollection<CourseGoal> Goals { get; set; } = new HashSet<CourseGoal>();

    /// <summary> Requirements. </summary>
    public virtual ICollection<CourseRequirement>? Requirements { get; set; } = new HashSet<CourseRequirement>();

    /// <summary> Reviews. </summary> 
    public virtual ICollection<CourseReview>? Reviews { get; set; } = new HashSet<CourseReview>();
}
