using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ShuttleZone.Common.Attributes;

namespace ShuttleZone.DAL.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddDALServices(this IServiceCollection services)
    {
        var autoRegisterableTypes = AppDomain
            .CurrentDomain
            .GetAssemblies()
            .SelectMany(t => t.GetTypes())
            .Where(t => t.GetCustomAttributes<AutoRegisterAttribute>().Any())
            .Where(t => t.IsInterface);
        foreach (var registerableType in autoRegisterableTypes)
        {
            var implementationType = typeof(DependencyInjection).Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .FirstOrDefault(x => x.GetInterfaces().Contains(registerableType));
            var attribute = registerableType.GetCustomAttribute<AutoRegisterAttribute>() as AutoRegisterAttribute;
            var lifeTime = attribute?.ServiceLifetime ?? ServiceLifetime.Scoped;
            if (implementationType != null)
                services.Add(new ServiceDescriptor(registerableType, implementationType, lifeTime));
        }

        return services;
    }
}
