using DoctorFactory.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DoctorFactory.Services.Data;

/// <summary> Database initializer. </summary>
public class RezitentiatDbInitializer
{
    private readonly RezidentDatabase _db;
    private readonly ILogger<RezitentiatDbInitializer> _logger;

    /// <summary> Database initializer. </summary>
    public RezitentiatDbInitializer(RezidentDatabase db, ILogger<RezitentiatDbInitializer> logger)
    {
        _db = db;
        _logger = logger;
    }

    //------------------------------------------------------------------------------//

    /// <summary> Initialize database. </summary>
    public async Task InitializeAsync()
    {
        _logger.LogInformation("Initializing database...");

        //await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);

        #region Migrations.

        var applied_migration = await _db.Database.GetAppliedMigrationsAsync().ConfigureAwait(false);
        if (applied_migration.Any())
        {
            foreach (var migration in applied_migration)
                _logger.LogInformation("Migration applyed {migration}", migration);
        }

        var pending_migrations = await _db.Database.GetPendingMigrationsAsync().ConfigureAwait(false);
        if (pending_migrations.Any())
        {
            foreach (var migration in pending_migrations)
                _logger.LogInformation("Applying migration {migration}", migration);
        }

        await _db.Database.MigrateAsync().ConfigureAwait(false);

        #endregion

        await SeedTestDataAsync().ConfigureAwait(false);

        _logger.LogInformation("Database initialization completed.");
    }

    //------------------------------------------------------------------------------//

    /// <summary> Seed database with data. </summary>
    private async Task SeedTestDataAsync()
    {
        await SeedCoursesAsync().ConfigureAwait(false);

        await SeedBlogPostsAsync().ConfigureAwait(false);
    }

    /// <summary> Seed courses. </summary>
    private async Task SeedCoursesAsync()
    {
        await using var transactionAsync = await _db.Database.BeginTransactionAsync().ConfigureAwait(false);

        try
        {
            _logger.LogInformation("Initializing Courses...");

            // await _db.Database.ExecuteSqlRawAsync("DELETE FROM dbo.Courses");

            await _db.Courses.AddRangeAsync(TestData.Courses);

            await _db.SaveChangesAsync();

            await _db.Database.CommitTransactionAsync();

            _logger.LogInformation("Saved Courses...");
        }
        catch (Exception)
        {
            await transactionAsync.RollbackAsync().ConfigureAwait(false);

            throw;
        }
    }

    /// <summary> Seed blog posts. </summary>
    private async Task SeedBlogPostsAsync()
    {
        await using var transactionAsync = await _db.Database.BeginTransactionAsync().ConfigureAwait(false);

        try
        {
            _logger.LogInformation("Initializing BlogPosts...");

            // await _db.Database.ExecuteSqlRawAsync("DELETE FROM dbo.BlogPosts");

            await _db.BlogPosts.AddRangeAsync(TestData.BlogPosts);

            await _db.SaveChangesAsync();

            await _db.Database.CommitTransactionAsync();

            _logger.LogInformation("Saved BlogPosts...");
        }
        catch (Exception)
        {
            await transactionAsync.RollbackAsync().ConfigureAwait(false);

            throw;
        }
    }
}
