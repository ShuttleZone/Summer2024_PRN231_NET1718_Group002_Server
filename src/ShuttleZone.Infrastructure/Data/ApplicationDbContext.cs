using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Common.Constants;
using ShuttleZone.Infrastructure.Helpers;

namespace ShuttleZone.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<User, Role,
    Guid, IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
    IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>, IApplicationDbContext, IReadOnlyApplicationDbContext
{
    
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer(DataAccessHelper.GetConnectionString());
        if (ApplicationEnvironment.IsDevelopment())
            optionsBuilder.EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .LogTo(Console.WriteLine);
    }

    public IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>();
    }

    public IQueryable<TEntity> CreateReadOnlySet<TEntity>() where TEntity : class
    {
        return base.Set<TEntity>().AsNoTracking();
    }

    public void Migrate()
    {
        if (base.Database.GetPendingMigrations().Any())
            base.Database.Migrate();
    }
}
