using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class MaintainanceConfiguration : IDatabaseModelMapper<Maintenance>
{
    public void Map(EntityTypeBuilder<Maintenance> builder)
    {
        builder.HasKey(m => m.MaintenanceId);
        builder.HasOne(m => m.Court)
            .WithMany(m => m.Maintenances)
            .HasForeignKey(m => m.CourtId)
            .IsRequired();
    }
}