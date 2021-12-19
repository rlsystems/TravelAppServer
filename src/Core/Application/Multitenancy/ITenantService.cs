using ServerApp.Application.Common.Interfaces;
using ServerApp.Shared.DTOs.Multitenancy;

namespace ServerApp.Application.Multitenancy;

public interface ITenantService : IScopedService
{
    public string GetDatabaseProvider();

    public string GetConnectionString();

    public TenantDto GetCurrentTenant();

    public void SetCurrentTenant(string tenant);
}