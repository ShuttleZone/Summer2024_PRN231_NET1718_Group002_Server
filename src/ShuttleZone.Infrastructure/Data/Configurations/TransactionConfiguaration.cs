using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class TransactionConfiguaration : IDatabaseModelMapper<Transaction>
{
    public void Map(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.TransactionId);
        builder.HasOne(t => t.Reservation)
            .WithMany(t => t.Transactions)
            .HasForeignKey(r => r.ReservationId)
            .IsRequired(false);
    }
}