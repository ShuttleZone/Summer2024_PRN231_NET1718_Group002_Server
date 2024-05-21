using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Infrastructure.Common;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class OpenDateInWeekConfiguration : IDatabaseModelMapper<OpenDateInWeek>
{
    public void Map(EntityTypeBuilder<OpenDateInWeek> builder)
    {
        builder.HasKey(odiw => odiw.Id);
        builder.HasOne(odiw => odiw.Club)
            .WithMany(odiw => odiw.OpenDateInWeeks)
            .HasForeignKey(odiw => odiw.ClubId)
            .IsRequired();
    }
}