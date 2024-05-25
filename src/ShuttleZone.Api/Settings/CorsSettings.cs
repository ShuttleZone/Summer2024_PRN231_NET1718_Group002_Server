using ShuttleZone.Common.Attributes;

namespace ShuttleZone.Api.Settings;

/// <summary>
/// Represents the CORS settings.
/// </summary>
/// <remarks>
/// This class is used to store the CORS settings.
/// </remarks>
[ApplicationSetting]
public class CorsSettings
{
    public CorsPolicy[] Policies { get; init; } = new CorsPolicy[] { };
}

public class CorsPolicy
{
    public required string Name { get; init; }
    public string[] AllowedOrigins { get; init; } = Array.Empty<string>();
    public string[] AllowedMethods { get; init; } = Array.Empty<string>();
    public string[] AllowedHeaders { get; init; } = Array.Empty<string>();
    public bool AllowCredentials { get; init; }
}
