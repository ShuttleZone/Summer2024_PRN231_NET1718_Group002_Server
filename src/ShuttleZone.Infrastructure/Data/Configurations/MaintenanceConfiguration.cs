using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasOne(m => m.Court)
            .WithMany(m => m.Maintenances)
            .HasForeignKey(m => m.CourtId)
            .IsRequired();
    }
}