using Microsoft.Extensions.DependencyInjection;
using ShuttleZone.Infrastructure.Data;
using ShuttleZone.Infrastructure.Data.Interfaces;

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
