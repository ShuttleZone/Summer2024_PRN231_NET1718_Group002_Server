using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ReservationDetailConfiguration : IDatabaseModelMapper<ReservationDetail>
{
    public void Map(EntityTypeBuilder<ReservationDetail> builder)
    {
        builder.HasKey(rd => rd.Reservation.ReservationId);
        builder.HasOne(rd => rd.Reservation)
            .WithMany(rd => rd.ReservationDetails)
            .HasForeignKey(rd => rd.ReservationId)
            .IsRequired();

        builder.HasOne(rd => rd.Court)
            .WithMany(rd => rd.ReservationDetails)
            .HasForeignKey(rd => rd.CourtId)
            .IsRequired(false);

    }
}