using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));
        builder.HasKey(u => u.Id);
        builder.HasMany(u => u.Roles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

        builder.HasMany(u => u.UserContests)
            .WithOne(u => u.User)
            .HasForeignKey(u => u.UserId)
            .IsRequired(false);

    }
}