using Microsoft.Extensions.Configuration;

namespace ShuttleZone.Infrastructure.Helpers;

public static class DataAccessHelper
{
    private static IConfiguration? _configuration;

    public static void Initialize(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static string GetConnectionString(string connectionName = "DefaultConnection")
    {
        ArgumentNullException.ThrowIfNull(_configuration, nameof(_configuration));
        var connectionString = _configuration.GetConnectionString(connectionName);
        ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

        return connectionString;
    }
}
