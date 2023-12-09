namespace DoctorFactory.Domain.Entities.Base;

/// <summary> Named entity. </summary>
public abstract class NamedEntity : Entity
{
    /// <summary> Name / title. </summary>
    public required string Name { get; set; }
}
