using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class TransactionConfiguaration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasOne(t => t.Reservation)
            .WithMany(t => t.Transactions)
            .HasForeignKey(r => r.ReservationId)
            .IsRequired(false);
    }
}