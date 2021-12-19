using ServerApp.Application.Multitenancy;
using ServerApp.Domain.Constants;
using ServerApp.Infrastructure.Identity.Permissions;
using ServerApp.Shared.DTOs.Multitenancy;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ServerApp.Host.Controllers.Multitenancy;

[ApiController]
[Route("api/[controller]")]
public class TenantsController : ControllerBase
{
    private readonly ITenantManager _tenantService;

    public TenantsController(ITenantManager tenantService)
    {
        _tenantService = tenantService;
    }

    [HttpGet("{key}")]
    [MustHavePermission(RootPermissions.Tenants.View)]
    [SwaggerOperation(Summary = "Get Tenant Details.")]
    public async Task<IActionResult> GetAsync(string key)
    {
        var tenant = await _tenantService.GetByKeyAsync(key);
        return Ok(tenant);
    }

    [HttpGet]
    [MustHavePermission(RootPermissions.Tenants.ListAll)]
    [SwaggerOperation(Summary = "Get all the available Tenants.")]
    public async Task<IActionResult> GetAllAsync()
    {
        var tenants = await _tenantService.GetAllAsync();
        return Ok(tenants);
    }

    [HttpPost]
    [MustHavePermission(RootPermissions.Tenants.Create)]
    [SwaggerOperation(Summary = "Create a new Tenant.")]
    public async Task<IActionResult> CreateAsync(CreateTenantRequest request)
    {
        var tenant = await _tenantService.CreateTenantAsync(request);
        return Ok(tenant);
    }

    [HttpPost("upgrade")]
    [MustHavePermission(RootPermissions.Tenants.UpgradeSubscription)]
    [SwaggerOperation(Summary = "Upgrade Subscription of Tenant.")]
    public async Task<IActionResult> UpgradeSubscriptionAsync(UpgradeSubscriptionRequest request)
    {
        return Ok(await _tenantService.UpgradeSubscriptionAsync(request));
    }

    [HttpPost("{id}/deactivate")]
    [MustHavePermission(RootPermissions.Tenants.Update)]
    [SwaggerOperation(Summary = "Deactivate Tenant.")]
    public async Task<IActionResult> DeactivateTenantAsync(string id)
    {
        return Ok(await _tenantService.DeactivateTenantAsync(id));
    }

    [HttpPost("{id}/activate")]
    [MustHavePermission(RootPermissions.Tenants.Update)]
    [SwaggerOperation(Summary = "Activate Tenant.")]
    public async Task<IActionResult> ActivateTenantAsync(string id)
    {
        return Ok(await _tenantService.ActivateTenantAsync(id));
    }
}