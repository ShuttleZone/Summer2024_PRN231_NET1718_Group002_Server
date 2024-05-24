using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class CourtConfiguaration : IEntityTypeConfiguration<Court>
{
    public void Configure(EntityTypeBuilder<Court> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.Club)
            .WithMany(c => c.Courts)
            .HasForeignKey(c => c.ClubId)
            .IsRequired();
    }
}