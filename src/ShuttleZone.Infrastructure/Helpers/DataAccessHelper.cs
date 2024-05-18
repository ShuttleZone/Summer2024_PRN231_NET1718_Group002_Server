using Microsoft.Extensions.Configuration;
using ShuttleZone.Common.Constants;

namespace ShuttleZone.Infrastructure.Helpers;

public static class DataAccessHelper
{
    public static string GetConnectionString(string connectionName = "DefaultConnection")
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{ApplicationEnvironment.GetEnvironment()}.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = config.GetConnectionString(connectionName);
        ArgumentNullException.ThrowIfNull(connectionString, nameof(connectionString));

        return connectionString;
    }
}
