using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

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
        builder.HasData(new Club
        {
            Id = Guid.Parse("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
            ClubName = "Fitness Club A",
            ClubAddress = "123 Main St",
            ClubPhone = "555-1234",
            ClubDescription = "A premier fitness club.",
            ClubStatusEnum = ClubStatusEnum.Open,
            OpenTime = TimeOnly.Parse("06:00:00"),
            CloseTime = TimeOnly.Parse("22:00:00"),
            MinDuration = 1.5,
            OwnerId = Guid.Parse("40e8ca6a-06c0-4deb-8bec-c3919817b8cf"),
            Created = DateTime.Now,
            CreatedBy = "Admin",
            LastModified = DateTime.Now,
            LastModifiedBy = "Admin"
        },
        new Club
        {
            Id = Guid.Parse("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
            ClubName = "Yoga Center B",
            ClubAddress = "456 Elm St",
            ClubPhone = "555-5678",
            ClubDescription = "A relaxing yoga center.",
            ClubStatusEnum = ClubStatusEnum.Open,
            OpenTime = TimeOnly.Parse("05:00:00"),
            CloseTime = TimeOnly.Parse("20:00:00"),
            MinDuration = 1,
            OwnerId = Guid.Parse("626d577c-5966-4993-afb8-72e672d16649"),
            Created = DateTime.Now,
            CreatedBy = "Admin",
            LastModified = DateTime.Now,
            LastModifiedBy = "Admin"
        }, 
        new Club
        {
            Id = Guid.Parse("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
            ClubName = "Dance Studio C",
            ClubAddress = "789 Oak St",
            ClubPhone = "555-9012",
            ClubDescription = "A vibrant dance studio.",
            ClubStatusEnum = ClubStatusEnum.Open,
            OpenTime = TimeOnly.Parse("08:00:00"),
            CloseTime = TimeOnly.Parse("21:00:00"),
            MinDuration = 2,
            OwnerId = Guid.Parse("40e8ca6a-06c0-4deb-8bec-c3919817b8cf"),
            Created = DateTime.Now,
            CreatedBy = "Admin",
            LastModified = DateTime.Now,
            LastModifiedBy = "Admin"
        });
    }
}