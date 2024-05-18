using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;

namespace ShuttleZone.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext, IReadOnlyApplicationDbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

		// var modelMappers = AppDomain.CurrentDomain.GetAssemblies()
		// 	.SelectMany(a => a.GetTypes())
		// 	.Where(t => t.IsClass && !t.IsAbstract && t.IsAssignableTo(typeof(IDatabaseModelMapper<>)));
		//
  //       modelMappers
  //           .ToList()
  //           .ForEach(modelMapper =>
  //           {
  //               var instance = Activator.CreateInstance(modelMapper) as IDatabaseModelMapper;
  //               instance?.Map(builder);
  //           });
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        if (optionsBuilder.IsConfigured) return;
    }
}
