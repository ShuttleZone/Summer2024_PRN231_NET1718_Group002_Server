using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using ShuttleZone.Application.Extensions;
using ShuttleZone.Common.Attributes;

namespace ShuttleZone.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
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
        
        // AutoMapper
        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddAllProfiles();
        });
        services.AddSingleton(autoMapperConfig.CreateMapper());

        return services;
    }
}
