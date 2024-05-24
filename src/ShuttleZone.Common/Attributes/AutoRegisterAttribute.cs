using Microsoft.Extensions.DependencyInjection;

namespace ShuttleZone.Common.Attributes;

public class AutoRegisterAttribute : Attribute
{
    public ServiceLifetime ServiceLifetime { get; }

    public AutoRegisterAttribute(ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
    {
        ServiceLifetime = serviceLifetime;
    }
}
