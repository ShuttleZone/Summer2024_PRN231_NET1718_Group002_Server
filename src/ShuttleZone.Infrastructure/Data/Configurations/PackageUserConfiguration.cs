using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations
{
    public class PackageUserConfiguration : IEntityTypeConfiguration<PackageUser>
    {
        public void Configure(EntityTypeBuilder<PackageUser> builder)
        {
            
        }
    }
}