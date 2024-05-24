using System.Reflection;

namespace ShuttleZone.Common.Extensions;

public static class MethodInfoExtensions
{
    public static MethodInfo IfNotNull(this MethodInfo? method)
    {
        ArgumentNullException.ThrowIfNull(method, nameof(method));
        return method;
    }
}
