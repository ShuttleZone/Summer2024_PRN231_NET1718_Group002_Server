using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Hangfire;
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
using ShuttleZone.Domain.WebResponses.Wallets;
using ShuttleZone.Api.Middlewares;
using Microsoft.OpenApi.Models;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Net.payOS;
using ShuttleZone.Domain.WebResponses.Transactions;

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
        //builder.EntityType<UserContestDto>().HasKey(cr => new{cr.ContestId, cr.ParticipantsId});
        //builder.EntityType<ReservationDto>();
       

        #region Reservation Models
        builder.EntityType<DtoReservationDetail>();
        builder.EntitySet<ReservationDetailsResponse>(GetControllerShortName<ReservationDetailsController>());
        builder.EnumType<ReservationStatusEnum>();
        builder.EntitySet<ReservationResponse>(GetControllerShortName<ReservationController>());
        #endregion

        #region User Models

        builder.EntitySet<DtoUserProfile>(GetControllerShortName<UsersController>());

        #endregion

        #region Packages

        var set = builder.EntitySet<PackageResponseDto>(GetControllerShortName<PackageController>());
        set.EntityType.HasKey(p => p.Id);
        // builder.EntityType<PackageResponseDto>().HasKey(p => p.Id);


        #endregion

        #region Contest Models
        builder.EntitySet<ContestResponse>("ContestDetail");
        builder.EntityType<UserContestResponse>().HasKey(cr => new { cr.ContestId, cr.ParticipantsId });


        #endregion

        #region Notification
        builder.EntitySet<NotificationResponse>(GetControllerShortName<NotificationController>());

        #endregion

        builder.EntitySet<DtoReviewResponse>(GetControllerShortName<ReviewsController>());
        #region Wallet

        builder.EntitySet<WalletResponse>(GetControllerShortName<WalletController>());
        builder.EntitySet<TransactionResponse>(GetControllerShortName<TransactionsController>());
        #endregion

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

    public static IServiceCollection AddGlobalExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<GlobalExceptionHandlerMiddleware>();
        services.AddProblemDetails();
        return services;
    }

    public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });

        return services;
    }

    public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            /// <summary>
            /// nhi: 21/6/2024 update for email confirmation.
            /// </summary>
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
        })
        .AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();    

        return services;
    }

    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(options =>   
        {
            options.DefaultAuthenticateScheme = 
            options.DefaultChallengeScheme = 
            options.DefaultForbidScheme = 
            options.DefaultScheme = 
            options.DefaultSignInScheme = 
            options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    System.Text.Encoding.UTF8.GetBytes(configuration["JWT:SigningKey"]!)),
                ClockSkew = new TimeSpan(0,0,5)
            };

            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = context.Request.Query["access_token"];

                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) &&
                        path.StartsWithSegments("/hubs"))
                    {
                        context.Token = accessToken;
                    }

                    return Task.CompletedTask;
                }
            };
        });

        return services;
    }

    public static IServiceCollection AddPayOS(this IServiceCollection services, IConfiguration configuration)
    {
        PayOS payOS = new PayOS(configuration["Environment:PAYOS_CLIENT_ID"] ?? throw new Exception("Cannot find environment"),
            configuration["Environment:PAYOS_API_KEY"] ?? throw new Exception("Cannot find environment"),
            configuration["Environment:PAYOS_CHECKSUM_KEY"] ?? throw new Exception("Cannot find environment"));
        services.AddSingleton(payOS);

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

    public static IServiceCollection AddHangfire(this IServiceCollection services, IConfiguration configuration)
    {
        //client
        services.AddHangfire(opt => opt.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnection")));
            // .UseSqlServerStorage("Server=(local);uid=sa;pwd=@dmin123;Database=ShuttleZone_BackgroundJob;Trusted_Connection=false;TrustServerCertificate=True"));
        
        // server 
        services.AddHangfireServer();
        return services;
    }
}
