using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role));
        builder.HasKey(r => r.Id);
        builder.HasMany(r => r.Roles)
            .WithOne(r => r.Role)
            .HasForeignKey(r => r.RoleId)
            .IsRequired();
    }
}