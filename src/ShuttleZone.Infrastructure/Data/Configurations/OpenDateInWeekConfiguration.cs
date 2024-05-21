using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class OpenDateInWeekConfiguration : IEntityTypeConfiguration<OpenDateInWeek>
{
    public void Configure(EntityTypeBuilder<OpenDateInWeek> builder)
    {
        builder.HasKey(odiw => odiw.Id);
        builder.HasOne(odiw => odiw.Club)
            .WithMany(odiw => odiw.OpenDateInWeeks)
            .HasForeignKey(odiw => odiw.ClubId)
            .IsRequired();
    }
    
}