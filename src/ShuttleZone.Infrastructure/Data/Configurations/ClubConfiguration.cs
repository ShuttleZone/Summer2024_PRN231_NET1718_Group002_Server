using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class ClubConfiguration : IEntityTypeConfiguration<Club>
{
    public void Configure(EntityTypeBuilder<Club> builder)
    {
        builder.ToTable(nameof(Club));
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Created).ValueGeneratedOnAdd();
        builder.Property(c => c.LastModified).ValueGeneratedOnUpdate();
        builder.HasOne(c => c.Owner)
            .WithMany(c => c.Clubs)
            .HasForeignKey(c => c.OwnerId)
            .IsRequired(false);
    }
}