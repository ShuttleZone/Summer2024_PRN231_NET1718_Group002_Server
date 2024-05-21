using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ClubImageConfiguration : IDatabaseModelMapper<ClubImage>
{
    public void Map(EntityTypeBuilder<ClubImage> builder)
    {
        builder.HasKey(ci => ci.Id);
        builder.HasOne(ci => ci.Club)
            .WithMany(ci => ci.ClubImages)
            .HasForeignKey(ci => ci.ClubId)
            .IsRequired(false);
    }
}