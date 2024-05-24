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

        // builder.HasData(new Transaction
        // {
        //     Id = Guid.Parse("4f4699f3-3fa5-4a0b-abff-589cc829fd7f"),
        //     PaymentMethod = 0,
        //     TransactionStatus = 0,
        //     CreatedBy = "System",
        //     Created = DateTime.Now,
        //     Amount = 300.000,
        //     ReservationId = Guid.Parse("2f14472c-f027-402e-adb3-cb73a7222a58")
        // },
        // new Transaction
        // {
        //     Id = Guid.Parse("38b5d7cb-b080-4bef-bbae-cc377f273bab"),
        //     PaymentMethod = 0,
        //     TransactionStatus = 0,
        //     CreatedBy = "System",
        //     Created = DateTime.Now,
        //     Amount = 600.000,
        //     ReservationId = Guid.Parse("46899e94-6776-444b-a8ea-498d1a2ae477")
        // },
        // new Transaction
        // {
        //     Id = Guid.Parse("48936f97-17b6-4772-b672-4d6b4028cd15"),
        //     PaymentMethod = 0,
        //     TransactionStatus = 0,
        //     CreatedBy = "System",
        //     Created = DateTime.Now,
        //     Amount = 900.000,
        //     ReservationId = Guid.Parse("fb4122ed-2399-4cdf-b0ce-51622893043c")
        // });
    }
}