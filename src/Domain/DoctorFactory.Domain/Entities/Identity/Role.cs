using Microsoft.AspNetCore.Identity;

namespace DoctorFactory.Domain.Entities.Identity;

internal class Role : IdentityRole
{
    public const string Adinistrators = "Administrators";

    public const string Users = "Users";
}
