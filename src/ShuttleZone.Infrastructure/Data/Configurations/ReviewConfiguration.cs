using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ReviewConfiguration : IDatabaseModelMapper<Review>
{
    public void Map(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable(nameof(Review));
        builder.HasKey(r => r.ReviewId);
        builder.HasOne(r => r.Reviewer)
            .WithMany(r => r.Reviews)
            .HasForeignKey(r => r.ReviewerId)
            .IsRequired();

        builder.HasOne(r => r.Club)
            .WithMany(r => r.Reviews)
            .HasForeignKey(r => r.ReviewId)
            .IsRequired();
    }
}   