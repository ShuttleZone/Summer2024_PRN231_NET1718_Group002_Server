using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ContestConfiguration :IDatabaseModelMapper<Contest>
{
    public void Map(EntityTypeBuilder<Contest> builder)
    {
        builder.HasKey(c => c.ContestId);
        builder.HasMany(c => c.UserContests)
            .WithOne(c => c.Contest)
            .HasForeignKey(c => c.ContestId)
            .IsRequired(false);

        builder.HasOne(c => c.Reservation)
            .WithOne(c => c.Contest)
            .HasForeignKey<Reservation>(c => c.ReservationId)
            .IsRequired(false);
    }
}