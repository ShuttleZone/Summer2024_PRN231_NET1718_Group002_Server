using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ReservationConfiguration : IDatabaseModelMapper<Reservation>
{
    public void Map(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.ReservationId);
        builder.HasOne(r => r.Customer)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .IsRequired();
    }
}