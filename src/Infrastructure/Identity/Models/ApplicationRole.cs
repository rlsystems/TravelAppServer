using ServerApp.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace ServerApp.Infrastructure.Identity.Models;

public class ApplicationRole : IdentityRole, IIdentityTenant
{
    public string Description { get; set; }
    public string Tenant { get; set; }

    public ApplicationRole()
    : base()
    {
    }

    public ApplicationRole(string roleName, string tenant, string description = null)
    : base(roleName)
    {
        Description = description;
        NormalizedName = roleName.ToUpper();
        Tenant = tenant;
    }
}