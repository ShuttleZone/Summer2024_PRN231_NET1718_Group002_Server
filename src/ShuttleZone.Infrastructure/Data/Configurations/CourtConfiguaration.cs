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

        builder.HasData(new Court
            {
                Id = Guid.Parse("e47d75fe-d045-4149-9b14-0cff4a752893"),
                Name = "Court 1",
                ClubId = Guid.Parse("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                CreatedBy = "Club Owner 1",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("76041fef-7c1b-4f62-ac5a-f372d1b3052f"),
                Name = "Court 2",
                ClubId = Guid.Parse("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                CreatedBy = "Club Owner 1",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("79943c0e-ac30-4f0c-b1a3-f178f8a4669a"),
                Name = "Court 3",
                ClubId = Guid.Parse("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                CreatedBy = "Club Owner 1",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("472b9b48-30d2-4f3e-a01f-527db703525b"),
                Name = "Court 4",
                ClubId = Guid.Parse("8a20240f-c00e-4d1d-9928-7bfc309ff6ce"),
                CreatedBy = "Club Owner 1",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            //Club 2
            new Court
            {
                Id = Guid.Parse("ac15834d-74a2-463c-81ce-22400a1048f9"),
                Name = "Court 1",
                ClubId = Guid.Parse("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                CreatedBy = "Club Owner 2",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("a3b5853b-f556-4a52-a1cf-4a3fb81db29a"),
                Name = "Court 2",
                ClubId = Guid.Parse("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                CreatedBy = "Club Owner 2",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("94a75cc3-7553-4281-b527-107f6f4369c5"),
                Name = "Court 3",
                ClubId = Guid.Parse("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                CreatedBy = "Club Owner 2",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("aa35cace-23a6-4ab8-98a4-6de2d1e32343"),
                Name = "Court 4",
                ClubId = Guid.Parse("6eeed43c-ec69-49ab-8177-b20d1c7a7603"),
                CreatedBy = "Club Owner 2",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            
            //Club 3
            new Court
            {
                Id = Guid.Parse("0190f7af-7f12-4a65-98b8-d034ae7be529"),
                Name = "Court 1",
                ClubId = Guid.Parse("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                CreatedBy = "Club Owner 3",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("abdd9e0b-de08-422b-894d-64f22365c583"),
                Name = "Court 2",
                ClubId = Guid.Parse("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                CreatedBy = "Club Owner 3",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("6699976f-f3ca-42a0-9948-41fae24efa03"),
                Name = "Court 3",
                ClubId = Guid.Parse("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                CreatedBy = "Club Owner 3",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            },
            new Court
            {
                Id = Guid.Parse("189df8e4-c3e1-48b4-b765-56f89f1f7d9e"),
                Name = "Court 4",
                ClubId = Guid.Parse("50d33a54-9a35-4058-b548-dbc5e35d05aa"),
                CreatedBy = "Club Owner 3",
                Created = DateTime.Now,
                LastModified = DateTime.Now,
                LastModifiedBy = "Admin",
                Price = 100
            });
    }
}
