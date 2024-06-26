using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations
{
    public class PackageUserConfiguration : IEntityTypeConfiguration<PackageUser>
    {
        public void Configure(EntityTypeBuilder<PackageUser> builder)
        {
            builder.HasKey(p => new { p.PackageId, p.UserId });
            
            builder.HasOne(pu => pu.Package)
                .WithMany(uc => uc.PackageUser)
                .HasForeignKey(uc => uc.PackageId);
        
            builder.HasOne(uc => uc.User)
                .WithMany(uc => uc.PackageUsers)
                .HasForeignKey(uc => uc.UserId);
        }
    }
}