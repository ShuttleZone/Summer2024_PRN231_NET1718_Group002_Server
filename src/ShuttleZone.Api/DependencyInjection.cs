using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
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
using ShuttleZone.Domain.WebResponses.Club;
using ShuttleZone.Domain.WebResponses.Contest;
using ShuttleZone.Common.Settings;
using ShuttleZone.Domain.WebRequests;
using ShuttleZone.Domain.Enums;
using ShuttleZone.Domain.WebResponses.Package;
using ShuttleZone.Domain.WebResponses.ReservationDetails;
using ShuttleZone.Domain.WebResponses.Reservations;
using ShuttleZone.Domain.WebResponses.ShuttleZoneUser;
using ShuttleZone.Domain.WebResponses.UserContests;
using ShuttleZone.Domain.WebResponses.Notifications;


namespace ShuttleZone.Api.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddODataControllers(this IServiceCollection services)
    {
        const string routePrefix = "api";
        services
            .AddControllers()
            .AddOData(opt =>
            {
                opt
                    .AddRouteComponents(routePrefix, GetEdmModel())
                    .EnableQueryFeatures();
            })
            .AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
            });

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
        builder.EntityType<DtoOpenDateInWeek>();

        #endregion

        builder.EntitySet<ClubRequestDetailReponse>(GetControllerShortName<ClubRequestsController>());
        builder.EntityType<OpenDateInWeekResponse>();

        #region Court Models

        builder.EntitySet<DtoCourtResponse>(GetControllerShortName<CourtsController>());
        builder.EntityType<DtoReservationDetail>();
        builder.EntityType<CreateCourtRequest>();
        builder.EnumType<CourtType>();
        builder.EnumType<CourtStatus>();
      
        #endregion

        builder.EntitySet<DtoContestResponse>(GetControllerShortName<ContestsController>());
        builder.EntityType<UserContestDto>().HasKey(cr => new{cr.ContestId, cr.ParticipantsId});
        // builder.EntityType<ContestStatusEnum>();

        #region Reservation Models
        builder.EntityType<DtoReservationDetail>();
        builder.EntitySet<ReservationDetailsResponse>(GetControllerShortName<ReservationDetailsController>());
        builder.EntitySet<ReservationResponse>(GetControllerShortName<ReservationController>());
        #endregion

        #region User Models

        builder.EntitySet<DtoUserProfile>(GetControllerShortName<UsersController>());

        #endregion

        #region Packages

        builder.EntitySet<PackageResponseDto>(GetControllerShortName<PackageController>());


        #endregion

        #region Contest Models
        builder.EntitySet<ContestResponse>("ContestDetail");
        builder.EntityType<UserContestResponse>().HasKey(cr => new { cr.ContestId, cr.ParticipantsId });

        #endregion

        #region Notification
        builder.EntitySet<NotificationResponse>(GetControllerShortName<NotificationController>());

        #endregion

        builder.EntitySet<DtoReviewResponse>(GetControllerShortName<ReviewsController>());

        builder.EnableLowerCamelCase();

        return builder.GetEdmModel();
    }

    private static string GetControllerShortName<TController>() where TController : BaseApiController
    {
        return typeof(TController).Name.Replace("Controller", string.Empty);
    }

    public static IServiceCollection AddVNPaySettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<VNPaySettings>(configuration.GetSection(nameof(VNPaySettings)));
        return services;
    }

    public static IServiceCollection AddEmailSettings(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection(nameof(EmailSettings)));
        return services;
    }

    private class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm";


        public override TimeOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return TimeOnly.ParseExact(reader.GetString()!, TimeFormat);
        }

        public override void Write(Utf8JsonWriter writer, TimeOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(TimeFormat));
        }
    }
}
