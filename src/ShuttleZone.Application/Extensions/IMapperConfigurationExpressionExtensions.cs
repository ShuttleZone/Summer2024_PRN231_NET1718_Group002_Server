using AutoMapper;

namespace ShuttleZone.Application.Extensions;

public static class IMapperConfugrationExpressionExtensions
{
    public static void AddAllProfiles(this IMapperConfigurationExpression configuration)
    {
        var profiles = typeof(IMapperConfugrationExpressionExtensions).Assembly
            .GetTypes()
            .Where(t => t.IsAssignableTo(typeof(Profile)))
            .Select(t => Activator.CreateInstance(t) as Profile);
        configuration.AddProfiles(profiles);
    }
}
