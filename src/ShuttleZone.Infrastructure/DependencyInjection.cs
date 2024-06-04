using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Infrastructure.Data;

namespace ShuttleZone.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();
        var autoRegisterableTypes = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(t => t.GetTypes())
            .Where(t => t.GetCustomAttributes<AutoRegisterAttribute>().Any())
            .Where(t => t.IsClass && !t.IsAbstract);
        foreach (var registerableType in autoRegisterableTypes)
        {
            var interfaceType = typeof(DependencyInjection).Assembly
                .GetTypes()
                .Where(t => t.IsInterface && t.IsAssignableFrom(registerableType));
            var attribute = registerableType.GetCustomAttribute<AutoRegisterAttribute>() as AutoRegisterAttribute;
            var lifeTime = attribute?.ServiceLifetime ?? ServiceLifetime.Scoped;
            foreach (var iType in interfaceType)
                services.Add(new ServiceDescriptor(iType, registerableType, lifeTime));
        }

        return services;
    }
}
