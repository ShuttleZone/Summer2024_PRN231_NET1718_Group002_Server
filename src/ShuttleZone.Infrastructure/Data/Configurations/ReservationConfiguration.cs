using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
{
    public void Configure(EntityTypeBuilder<Reservation> builder)
    {
        builder.HasKey(r => r.Id);
        builder.HasOne(r => r.Customer)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .IsRequired();
    }
}