using ServerApp.Application.Common.Interfaces;
using ServerApp.Application.Wrapper;
using ServerApp.Shared.DTOs.Multitenancy;

namespace ServerApp.Application.Multitenancy;

public interface ITenantManager : ITransientService
{
    public Task<Result<TenantDto>> GetByKeyAsync(string key);

    public Task<Result<List<TenantDto>>> GetAllAsync();

    public Task<Result<object>> CreateTenantAsync(CreateTenantRequest request);

    Task<Result<object>> UpgradeSubscriptionAsync(UpgradeSubscriptionRequest request);

    Task<Result<object>> DeactivateTenantAsync(string tenant);

    Task<Result<object>> ActivateTenantAsync(string tenant);
}