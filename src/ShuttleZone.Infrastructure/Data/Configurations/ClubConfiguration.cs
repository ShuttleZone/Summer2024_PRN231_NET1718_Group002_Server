using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ClubConfiguration : IDatabaseModelMapper<Club>
{
    public void Map(EntityTypeBuilder<Club> builder)
    {
        builder.ToTable(nameof(Club));
        builder.HasKey(c => c.ClubId);
        builder.Property(c => c.Created).ValueGeneratedOnAdd();
        builder.Property(c => c.LastModified).ValueGeneratedOnUpdate();
        builder.HasOne(c => c.Owner)
            .WithMany(c => c.Clubs)
            .HasForeignKey(c => c.OwnerId)
            .IsRequired(false);
    }
}