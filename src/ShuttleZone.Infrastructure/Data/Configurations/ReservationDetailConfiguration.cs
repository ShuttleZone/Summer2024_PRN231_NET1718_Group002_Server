using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ReservationDetailConfiguration : IEntityTypeConfiguration<ReservationDetail>
{
    public void Configure(EntityTypeBuilder<ReservationDetail> builder)
    {
        builder.HasKey(rd => rd.Id);
        builder.HasOne(rd => rd.Reservation)
            .WithMany(rd => rd.ReservationDetails);

        builder.HasOne(rd => rd.Court)
            .WithMany(rd => rd.ReservationDetails)
            .HasForeignKey(rd => rd.CourtId)
            .IsRequired(false);

    }
}