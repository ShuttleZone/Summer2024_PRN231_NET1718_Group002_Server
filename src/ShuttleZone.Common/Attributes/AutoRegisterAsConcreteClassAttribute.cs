using Microsoft.Extensions.DependencyInjection;

namespace ShuttleZone.Common.Attributes;

public class AutoRegisterAsConcreteClassAttribute : AutoRegisterAttribute
{
    public AutoRegisterAsConcreteClassAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) : base(serviceLifetime)
    {
    }
}
