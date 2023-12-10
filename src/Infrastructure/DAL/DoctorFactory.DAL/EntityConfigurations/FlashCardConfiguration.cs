using DoctorFactory.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorFactory.DAL.EntityConfigurations;

/// <summary> Flash card configuration. </summary>
internal class FlashCardConfiguration : IEntityTypeConfiguration<Flashcard>
{
    public void Configure(EntityTypeBuilder<Flashcard> builder)
    {
        builder.HasOne(f => f.Lesson)
            .WithMany(l => l.Flashcards)
            .HasForeignKey(f => f.LessonId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
