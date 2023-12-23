using DoctorFactory.DAL.EntityConfigurations;
using DoctorFactory.Domain.Entities.Blog;
using DoctorFactory.Domain.Entities.Course;
using DoctorFactory.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DoctorFactory.DAL.Context;

public class RezidentDatabase : IdentityDbContext<User, Role, string>
{
    public RezidentDatabase(DbContextOptions<RezidentDatabase> options) : base(options) { }

    //------------------------------------------------------------------------------//

    #region DbSets.

    #region Blog DbSets.

    public DbSet<BlogCategory> BlogCategories { get; set; }
    public DbSet<BlogReview> BlogReviews { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Tag> Tags { get; set; }

    #endregion

    #region Course DbSets.

    public DbSet<CourseCategory> CourseCategories { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseRequirement> CourseRequirements { get; set; }
    public DbSet<CourseReview> CourseReviews { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<CourseGoal> CourseGoals { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonContent> LessonContents { get; set; }
    public DbSet<Quiz> Quizzes { get; set; }

    #endregion

    #endregion

    //------------------------------------------------------------------------------//

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogCategoryConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogPostConfiguration).Assembly);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.EnableSensitiveDataLogging();
}
