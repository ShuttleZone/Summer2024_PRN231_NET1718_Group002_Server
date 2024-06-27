using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role));
        builder.HasMany(r => r.Roles)
            .WithOne(r => r.Role)
            .HasForeignKey(r => r.RoleId)
            .IsRequired();

        builder.HasData(new Role
        {            
            Id = Guid.Parse("814A5AC8-3E60-4108-9365-07DFA9A69578"),
            Name = SystemRole.Customer.ToString(),
            NormalizedName = SystemRole.Customer.ToString().ToUpper(),
        },
        new Role
        {
            Id = Guid.Parse("436BD7CF-8A5F-4314-B8E6-AC71601FD20C"),
            Name = SystemRole.Staff.ToString(),
            NormalizedName = SystemRole.Staff.ToString().ToUpper(),
        },
        new Role
        {
            Id = Guid.Parse("F1D65B6B-96DD-492B-BBBD-6A06CA59EB4F"),
            Name = SystemRole.Manager.ToString(),
            NormalizedName = SystemRole.Manager.ToString().ToUpper(),
        },
        new Role
        {
            Id = Guid.Parse("EEF861B3-DA8B-4D8D-AB86-E7D0EB9E0F05"),
            Name = SystemRole.SuperAdmin.ToString(),
            NormalizedName = SystemRole.SuperAdmin.ToString().ToUpper(),
        });
    }
}