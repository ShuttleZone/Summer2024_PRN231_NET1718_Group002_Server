using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
{
    public void Configure(EntityTypeBuilder<Maintenance> builder)
    {
        builder.HasKey(m => m.Id);
        builder.HasOne(m => m.Court)
            .WithMany(m => m.Maintenances)
            .HasForeignKey(m => m.CourtId)
            .IsRequired();
        builder.HasData(new Maintenance
        {
            Id = Guid.Parse("2d3476e2-526b-4a65-89f8-9561981c947e"),
            CourtId = Guid.Parse("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
            Reason = "Out of service",
            StartTime = DateTime.Now,
            EndTime = DateTime.Today,
            CreatedBy = "Admin",
            Created = DateTime.Now,
        },
        new Maintenance
        {
            Id = Guid.Parse("02d759bf-9408-452f-b920-359df87a0fac"),
            CourtId = Guid.Parse("ac15834d-74a2-463c-81ce-22400a1048f9"),
            Reason = "Out of service 2",
            StartTime = DateTime.Now,
            EndTime = DateTime.Today,
            CreatedBy = "Admin",
            Created = DateTime.Now,
        });
    }
}