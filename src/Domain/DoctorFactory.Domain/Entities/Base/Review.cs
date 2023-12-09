namespace DoctorFactory.Domain.Entities.Base;

/// <summary> Review. </summary>
public abstract class Review : NamedEntity
{
    /// <summary> Review rate. </summary>
    public required int Rate { get; set; }

    /// <summary> Author of the review. </summary>
    public required int AuthorId { get; set; }

    /// <summary> Review content/message. </summary>
    public required string Content { get; set; }

    /// <summary> Creation date. </summary>
    public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;

    /// <summary> Is review deleted or no. </summary>
    public bool IsDeleted { get; set; }
}
