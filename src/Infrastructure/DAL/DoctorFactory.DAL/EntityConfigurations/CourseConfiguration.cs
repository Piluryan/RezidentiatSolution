using DoctorFactory.Domain.Entities.Course;
using DoctorFactory.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorFactory.DAL.EntityConfigurations;

/// <summary> Course configuration. </summary>
internal class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(x => x.ShortDescription).HasMaxLength(255);
        builder.Property(x => x.Description).HasMaxLength(255);
        builder.Property(x => x.SkillLevel).HasDefaultValue(SkillLevel.Beginner);
        builder.Property(x => x.Enrolled).HasDefaultValue(0);
        builder.Property(x => x.Price).HasDefaultValue(0.00m).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Discount).HasDefaultValue(0);
        builder.HasOne(x => x.Category).WithMany(x => x.Courses).HasForeignKey("CategoryId");

        builder.HasMany(x => x.Instructors).WithMany(x => x.Courses)
            .UsingEntity<Dictionary<string, object>>("CourseInstructor",
                x => x.HasOne<Instructor>().WithMany().HasForeignKey("InstructorId").OnDelete(DeleteBehavior.Cascade),
                x => x.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.Cascade));
    }
}
