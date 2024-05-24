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
            .HasForeignKey(r => r.ClubId)
            .IsRequired();

        builder.HasData(new Review
        {
            Id = Guid.Parse("83196436-d386-48b4-bfac-d5b08d8cf604"),
            Rating = 0,
            Comment = "Good",
            ReviewerId = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
            ClubId = Guid.Parse("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
            CreatedBy = "John doe",
            Created = DateTime.Now,
        },
        new Review
        {
            Id = Guid.Parse("c5ee94c7-6fee-4af0-b4b3-07b17fd87325"),
            Rating = 0,
            Comment = "Bad",
            ReviewerId = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
            ClubId = Guid.Parse("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
            CreatedBy = "John doe",
            Created = DateTime.Now,
        },
        new Review
        {
            Id = Guid.Parse("fde0842b-3182-432a-b567-1c4aad77bac9"),
            Rating = 0,
            Comment = "Fair Well",
            ReviewerId = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
            ClubId = Guid.Parse("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
            CreatedBy = "John doe",
            Created = DateTime.Now,
        });
    }
}   