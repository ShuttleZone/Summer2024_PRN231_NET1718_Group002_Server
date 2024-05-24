using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ShuttleZone.Application.Common.Interfaces;

namespace ShuttleZone.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddOdataControllers(this IServiceCollection services)
    {
        services
            .AddControllers()
            .AddOData(opt => 
                opt
                .AddRouteComponents("odata", GetEdmModel())
                .EnableQueryFeatures());

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

        return builder.GetEdmModel();
    }
}
