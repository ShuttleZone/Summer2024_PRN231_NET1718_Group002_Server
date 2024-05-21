using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class CourtConfiguaration : IDatabaseModelMapper<Court>
{
    public void Map(EntityTypeBuilder<Court> builder)
    {
        builder.HasKey(c => c.CourtId);
        builder.HasOne(c => c.Club)
            .WithMany(c => c.Courts)
            .HasForeignKey(c => c.ClubId)
            .IsRequired();
    }
}