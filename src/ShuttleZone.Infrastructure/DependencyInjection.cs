using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Infrastructure.Data;

namespace ShuttleZone.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        services.AddScoped<IReadOnlyApplicationDbContext, ApplicationDbContext>();


        return services;
    }
}
