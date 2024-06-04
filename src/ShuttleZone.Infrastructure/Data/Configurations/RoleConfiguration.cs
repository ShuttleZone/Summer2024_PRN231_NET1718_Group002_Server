using Microsoft.AspNetCore.Identity;
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
            Id = Guid.NewGuid(),
            Name = SystemRole.Customer.ToString(),
            NormalizedName = SystemRole.Customer.ToString().ToUpper(),
        },
        new Role
        {           
            Id = Guid.NewGuid(),
            Name = SystemRole.Staff.ToString(),
            NormalizedName = SystemRole.Staff.ToString().ToUpper(),
        },
        new Role
        {
            Id = Guid.NewGuid(),
            Name = SystemRole.Manager.ToString(),
            NormalizedName = SystemRole.Manager.ToString().ToUpper(),
        },
        new Role
        {
            Id = Guid.NewGuid(),
            Name = SystemRole.SuperAdmin.ToString(),
            NormalizedName = SystemRole.SuperAdmin.ToString().ToUpper(),
        });
    }
}