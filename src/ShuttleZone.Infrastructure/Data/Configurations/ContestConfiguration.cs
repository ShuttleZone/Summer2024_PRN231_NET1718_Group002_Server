using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ContestConfiguration :IEntityTypeConfiguration<Contest>
{
    public void Configure(EntityTypeBuilder<Contest> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.Participants)
            .WithMany(c => c.Contests)
            .UsingEntity<UserContest>();

        builder.HasOne(c => c.Reservation)
            .WithOne(c => c.Contest)
            .HasForeignKey<Reservation>(c => c.Id)
            .IsRequired(false);
    }
}