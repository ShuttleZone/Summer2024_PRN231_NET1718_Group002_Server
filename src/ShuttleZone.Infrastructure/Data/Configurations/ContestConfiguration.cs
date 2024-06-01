using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ContestConfiguration :IEntityTypeConfiguration<Contest>
{
    public void Configure(EntityTypeBuilder<Contest> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.Reservation)
            .WithOne(c => c.Contest)
            .HasForeignKey<Reservation>(c => c.ContestId)
            .IsRequired(false);

        builder.HasData(
            new Contest
            {
                Id = Guid.Parse("851e80b3-c3d3-4f1d-b5d8-462cab592b84"),
                ContestDate = DateTime.Today,
                MaxPlayer = 8,
                Policy = "Follow the rules",
                ContestStatus = ContestStatusEnum.Closed,
                Created = DateTime.Now,
                CreatedBy = "John Doe",
            }
            ,
            new Contest
            {
                Id = Guid.Parse("3d6e11e2-8914-495b-b3d7-798960a5fe91"),
                ContestDate = DateTime.Today,
                MaxPlayer = 10,
                Policy = "No cheating allowed",
                ContestStatus = ContestStatusEnum.Open,
                Created = DateTime.Now,
                CreatedBy = "Jane Smith"
            }
        );
        
    }
}