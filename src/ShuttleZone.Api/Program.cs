using Hangfire;
using ShuttleZone.Api.DependencyInjection.BackgroundUtils;
using ShuttleZone.Api.Services;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Application.SignalRHub;
using ShuttleZone.Infrastructure.Helpers;

var builder = WebApplication.CreateBuilder(args);
ApplicationEnvironment.SetEnvironment(builder.Environment.EnvironmentName);
DataAccessHelper.Initialize(builder.Configuration);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddApplicationSettings(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwaggerGen();
builder.Services.AddODataControllers();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddDALServices();
builder.Services.AddAppCors(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUser, CurrentUser>();
builder.Services.AddSignalR();
builder.Services.AddCustomIdentity();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddPayOS(builder.Configuration);
builder.Services.AddHangfire(builder.Configuration);
// Register IHttpClientFactory
builder.Services.AddHttpClient();
builder.Services.AddGlobalExceptionHandler();

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
app.UseHangfireDashboard();
app.MapHangfireDashboard("/hangfire");
app.MapHub<NotificationHub>("/hubs/notification").AllowAnonymous(); 
app.UseExceptionHandler();
app.EnsureMigrations();
RecurringJobScheduler.ScheduleJob();
app.Run();
