using ServerApp.Infrastructure.Multitenancy;
using Microsoft.Extensions.DependencyInjection;

namespace ServerApp.Infrastructure.Common.Extensions;

public static class HealthCheckExtensions
{
    internal static IServiceCollection AddHealthCheckExtension(this IServiceCollection services)
    {
        services.AddHealthChecks().AddCheck<TenantHealthCheck>("Tenant");
        return services;
    }
}