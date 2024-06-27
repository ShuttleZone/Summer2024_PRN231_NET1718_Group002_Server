using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ShuttleZone.Api.Services;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.SignalRHub;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Data;
using ShuttleZone.Infrastructure.Helpers;

var builder = WebApplication.CreateBuilder(args);
ApplicationEnvironment.SetEnvironment(builder.Environment.EnvironmentName);
DataAccessHelper.Initialize(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationSettings(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
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
builder.Services.AddODataControllers();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddDALServices();
builder.Services.AddAppCors(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUser, CurrentUser>();
builder.Services.AddSignalR();

builder.Services.AddIdentity<User, Role>(options =>
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
    
builder.Services.AddAuthentication(options =>   
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
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!)),
        ClockSkew = new TimeSpan(0,0,5)
    };
});

builder.Services.AddVNPaySettings(builder.Configuration);
builder.Services.AddEmailSettings(builder.Configuration);
// Register IHttpClientFactory
builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        option =>
        {
            option.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        }
    );
}
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowReactApp");
app.MapControllers();
app.MapHub<NotificationHub>("/notificationhub");
app.EnsureMigrations();

app.Run();
