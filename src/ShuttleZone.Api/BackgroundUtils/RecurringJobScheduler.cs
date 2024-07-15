using Hangfire;
using ShuttleZone.Application.Services.Expiration;

namespace ShuttleZone.Api.DependencyInjection.BackgroundUtils;

public abstract class RecurringJobScheduler
{
    public static void ScheduleJob()
    {
        RecurringJob.AddOrUpdate<IExpirationService>(
            service => service.ValidatePackageUser(),Cron.Daily);
    }
}