using System.Reflection;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ShuttleZone.Api.Settings;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses.Contest;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddODataControllers(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddOData(opt => 
                opt
                // may not need this route component
                .AddRouteComponents("odata", GetEdmModel())
                .EnableQueryFeatures());

        return services;
    }

    public static IServiceCollection AddAppCors(this IServiceCollection services, IConfiguration configuration)
    {
        var corsSettings = configuration.GetSection(nameof(CorsSettings)).Get<CorsSettings>();
        ArgumentNullException.ThrowIfNull(corsSettings, nameof(CorsSettings));
        services.AddCors(options => {
            foreach (var policy in corsSettings.Policies) {
                options.AddPolicy(
                    policy.Name, builder => {
                        builder.WithOrigins(policy.AllowedOrigins)
                            .WithMethods(policy.AllowedMethods)
                            .WithHeaders(policy.AllowedHeaders);
                        if (policy.AllowCredentials)
                            builder.AllowCredentials();
                    }
                );
            }
        });
        return services;
    }

    public static IServiceCollection AddApplicationSettings(this IServiceCollection services, IConfiguration configuration)
    {
        var settings = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(t => t.GetCustomAttributes<ApplicationSettingAttribute>().Any());
        foreach (var setting in settings) {
            var section = configuration.GetSection(setting.Name).Get(setting);
            ArgumentNullException.ThrowIfNull(section, nameof(section));
            services.AddSingleton(setting, section);
        }

        return services;
    }

    public static IApplicationBuilder EnsureMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        dbContext.Migrate();

        return app;
    }

    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        
        // may not need to add this
        // TODO: Add OData models

        return builder.GetEdmModel();
    }
}
