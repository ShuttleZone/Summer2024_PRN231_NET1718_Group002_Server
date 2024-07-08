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
            .IsRequired(false);
        // builder.HasData(
        //     new Reservation
        //     {
        //         Id = Guid.Parse("2f14472c-f027-402e-adb3-cb73a7222a58"),
        //         BookingDate = DateTime.Now,
        //         TotalHours = 2,
        //         TotalPrice = 300.000,
        //         ReservationStatusEnum = 0,
        //         Note = "Nothing",
        //         CustomerId = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
        //         ContestId = Guid.Empty,
        //         CreatedBy = "System",
        //         Created = DateTime.Now
        //     }
        //     ,
        //     new Reservation
        //     {
        //         Id = Guid.Parse("46899e94-6776-444b-a8ea-498d1a2ae477"),
        //         BookingDate = DateTime.Now,
        //         TotalHours = 1,
        //         TotalPrice = 150.000,
        //         ReservationStatusEnum = 0,
        //         Note = "Nothing 1",
        //         CustomerId = Guid.Parse("26a7cc4e-3f9b-4923-809e-2f9b771d994f"),
        //         // ContestId = Guid.Parse("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
        //         CreatedBy = "System",
        //         Created = DateTime.Now
        //     }
        //     ,
        //     new Reservation
        //     {
        //         Id = Guid.Parse("fb4122ed-2399-4cdf-b0ce-51622893043c"),
        //         BookingDate = DateTime.Now,
        //         TotalHours = 3,
        //         TotalPrice = 900.000,
        //         ReservationStatusEnum = 0,
        //         Note = "Nothing 2",
        //         // ContestId = Guid.Parse("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
        //         CustomerId = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
        //         CreatedBy = "System",
        //         Created = DateTime.Now
        //     }
        // );
    }
}