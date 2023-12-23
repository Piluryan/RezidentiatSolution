using Microsoft.AspNetCore.Identity;

namespace DoctorFactory.Domain.Entities.Identity;

/// <summary> Identity user. </summary>
public class User : IdentityUser
{
    public const string Administrator = "Admin";

    public const string DefaultAdminPassword = "AdPAss_123";
}
