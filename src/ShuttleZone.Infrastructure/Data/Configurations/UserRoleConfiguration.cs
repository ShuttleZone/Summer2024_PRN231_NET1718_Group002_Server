using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(ur => ur.RoleId);
        builder.HasKey(ur => ur.UserId);

        builder.HasData(new UserRole
        {
            UserId = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216"),
            RoleId = Guid.Parse("8f42b74b-a7a2-4cd8-b449-5255ff317516")
        },
        new UserRole
        {
            UserId = Guid.Parse("26a7cc4e-3f9b-4923-809e-2f9b771d994f"),
            RoleId = Guid.Parse("8f42b74b-a7a2-4cd8-b449-5255ff317516")
        });
    }
}