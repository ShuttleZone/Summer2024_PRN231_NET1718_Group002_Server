using System.Reflection;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ShuttleZone.Api.Controllers;
using ShuttleZone.Api.Settings;
using ShuttleZone.Common.Attributes;
using ShuttleZone.Domain.WebResponses;
using ShuttleZone.Domain.WebResponses.Court;
using ShuttleZone.Infrastructure.Data.Interfaces;
using ShuttleZone.Api.Controllers.BaseControllers;
using ShuttleZone.Domain.WebResponses.Contest;

namespace ShuttleZone.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddODataControllers(this IServiceCollection services)
    {
        const string routePrefix = "api";
        services
            .AddControllers()
            .AddOData(opt => 
                opt
                .AddRouteComponents(routePrefix, GetEdmModel())
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
        
        // TODO: Add OData models
        #region Club Models

        builder.EntitySet<DtoClubResponse>(GetControllerShortName<ClubsController>());
        builder.EntityType<DtoReviewResponse>();
        builder.EntityType<DtoClubImageResponse>();

        #endregion

        #region Court Models

        builder.EntitySet<DtoCourtResponse>(GetControllerShortName<CourtsController>());

        #endregion

        builder.EntitySet<DtoContestResponse>(GetControllerShortName<ContestsController>());
        builder.EntityType<UserContestDto>();
        
        

        builder.EnableLowerCamelCase();

        return builder.GetEdmModel();
    }

    private static string GetControllerShortName<TController>() where TController : BaseApiController
    {
        return typeof(TController).Name.Replace("Controller", string.Empty);
    }
}
