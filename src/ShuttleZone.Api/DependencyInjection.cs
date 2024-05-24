using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

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

    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();

        // TODO: Add OData models

        return builder.GetEdmModel();
    }
}
