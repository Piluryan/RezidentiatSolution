using System.Security.Claims;
using DoctorFactory.DAL.Context;
using DoctorFactory.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DoctorFactory.Services.Data;

/// <summary> Database initializer. </summary>
public class RezitentiatDbInitializer
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly RezidentDatabase _db;
    private readonly ILogger<RezitentiatDbInitializer> _logger;

    /// <summary> Database initializer. </summary>
    public RezitentiatDbInitializer(
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        RezidentDatabase db,
        ILogger<RezitentiatDbInitializer> logger)
    {
        _userManager = userManager;
        _roleManager = roleManager;
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

        //await SeedIdentityAsync().ConfigureAwait(false);

        //await SeedTestDataAsync().ConfigureAwait(false);
         
        _logger.LogInformation("Database initialization completed.");
    }

    //------------------------------------------------------------------------------//

    #region Seed identity.

    /// <summary> Seeds the identity system with default roles and an administrator user. </summary>
    private async Task SeedIdentityAsync()
    {
        await EnsureRoleCreatedAsync(Role.Adinistrators);
        await EnsureRoleCreatedAsync(Role.Users);

        await CreateDefaultAdministratorAsync();
    }

    /// <summary> Ensures that the specified role is created if it doesn't exist. </summary>
    /// <param name="roleName">The name of the role.</param>
    private async Task EnsureRoleCreatedAsync(string roleName)
    {
        if (!await _roleManager.RoleExistsAsync(roleName))
        {
            await _roleManager.CreateAsync(new Role { Name = roleName });
            _logger.LogInformation("Role: {role} created!", roleName);
        }
        else
        {
            _logger.LogInformation("Role: {role} already exists!", roleName);
        }
    }

    /// <summary> Creates the default administrator user if it doesn't already exist. </summary>
    private async Task CreateDefaultAdministratorAsync()
    {
        const string administratorUserName = User.Administrator;

        if (await _userManager.FindByNameAsync(administratorUserName) is null)
        {
            _logger.LogInformation("Creating administrator.");

            var admin = new User { UserName = administratorUserName, Ocupation = "Test admin user", About = "Test about"};

            var creationResult = await _userManager.CreateAsync(admin, User.DefaultAdminPassword);

            if (creationResult.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, Role.Adinistrators);

                _logger.LogInformation("Administrator created successfully.");
            }
            else LogCreationFailure(creationResult.Errors);
        }
    }

    /// <summary> Logs errors that occur during administrator creation. </summary>
    /// <param name="errors">The collection of identity errors.</param>
    private void LogCreationFailure(IEnumerable<IdentityError> errors)
    {
        _logger.LogCritical("Error on administrator creation!");

        foreach (var identityError in errors)
        {
            _logger.LogCritical(identityError.Description);
        }

        throw new InvalidOperationException($"Error on admin creation {string.Join(",", errors.Select(e => e.Description))}");
    }
    
    #endregion
    
    #region Seed test data.

    /// <summary> Seed database with data. </summary>
    private async Task SeedTestDataAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        
        new TestData(users[0]);

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

    #endregion
}
