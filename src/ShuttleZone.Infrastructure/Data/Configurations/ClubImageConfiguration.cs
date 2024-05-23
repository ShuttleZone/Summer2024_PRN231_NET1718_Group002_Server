using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ClubImageConfiguration : IEntityTypeConfiguration<ClubImage>
{
    public void Configure(EntityTypeBuilder<ClubImage> builder)
    {
        builder.HasKey(ci => ci.Id);
        builder.HasOne(ci => ci.Club)
            .WithMany(ci => ci.ClubImages)
            .HasForeignKey(ci => ci.ClubId)
            .IsRequired(false);
    }
}