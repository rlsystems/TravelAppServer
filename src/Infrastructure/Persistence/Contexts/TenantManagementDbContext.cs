using ServerApp.Domain.Multitenancy;
using Microsoft.EntityFrameworkCore;

namespace ServerApp.Infrastructure.Persistence.Contexts;

public class TenantManagementDbContext : DbContext
{
    public TenantManagementDbContext(DbContextOptions<TenantManagementDbContext> options)
    : base(options)
    {
    }

    public DbSet<Tenant> Tenants { get; set; }
}