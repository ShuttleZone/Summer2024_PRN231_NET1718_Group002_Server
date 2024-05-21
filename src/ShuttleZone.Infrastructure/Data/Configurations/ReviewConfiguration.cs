using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable(nameof(Review));
        builder.HasKey(r => r.Id);
        builder.HasOne(r => r.Reviewer)
            .WithMany(r => r.Reviews)
            .HasForeignKey(r => r.ReviewerId)
            .IsRequired();

        builder.HasOne(r => r.Club)
            .WithMany(r => r.Reviews)
            .HasForeignKey(r => r.Id)
            .IsRequired();
    }
}   