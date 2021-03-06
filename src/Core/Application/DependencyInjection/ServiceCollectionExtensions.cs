using ServerApp.Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ServerApp.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<IRequestValidator>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}