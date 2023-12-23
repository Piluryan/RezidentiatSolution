using Microsoft.AspNetCore.Identity;

namespace DoctorFactory.Domain.Entities.Identity;

/// <summary> Identity roles. </summary>
public class Role : IdentityRole
{
    public const string Adinistrators = "Administrators";

    public const string Users = "Users";
}
