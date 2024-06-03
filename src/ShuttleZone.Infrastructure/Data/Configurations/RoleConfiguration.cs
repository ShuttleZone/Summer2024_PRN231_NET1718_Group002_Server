using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // List<IdentityRole> identityRoles = new List<IdentityRole>
        // {
        //     new IdentityRole
        //     {
        //         Name = "Admin",
        //         NormalizedName = "ADMIN"
        //     },
        //     new IdentityRole
        //     {
        //         Name = "Customer",
        //         NormalizedName = "CUSTOMER"
        //     },
        //     new IdentityRole
        //     {
        //         Name = "Club Owner",
        //         NormalizedName = "CLUB OWNER"
        //     },
        //     new IdentityRole
        //     {
        //         Name = "Staff",
        //         NormalizedName = "STAFF"
        //     }
        //     
        // };
        
        builder.ToTable(nameof(Role));
        builder.HasKey(r => r.Id);
        builder.HasMany(r => r.Roles)
            .WithOne(r => r.Role)
            .HasForeignKey(r => r.RoleId)
            .IsRequired();

        builder.HasData(new Role
        {
            Id = Guid.Parse("8f42b74b-a7a2-4cd8-b449-5255ff317516"),
            Name = "Customer",
            ConcurrencyStamp = "",
            NormalizedName = "CUSTOMER",
        },
        new Role
        {
            Id = Guid.Parse("80d75090-a1aa-48cb-b3ba-233067001594"),
            Name = "Staff",
            ConcurrencyStamp = "",
            NormalizedName = "STAFF",
        },
        new Role
        {
            Id = Guid.Parse("f221a993-f8ff-40e4-a92f-2552ce67373d"),
            Name = "Owner",
            ConcurrencyStamp = "",
            NormalizedName = "OWNER",
        });
    }
}