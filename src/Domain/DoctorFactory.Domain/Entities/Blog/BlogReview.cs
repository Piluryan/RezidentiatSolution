using DoctorFactory.Domain.Entities.Base;

namespace DoctorFactory.Domain.Entities.Blog;

/// <summary> Blog post review. </summary>
public class BlogReview : Review
{
    /// <summary> Blog post. </summary> 
    public required BlogPost Post { get; set; }
}
