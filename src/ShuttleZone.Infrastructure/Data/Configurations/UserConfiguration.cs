using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;
using ShuttleZone.Domain.Enums;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    Guid id1 = Guid.Parse("a37b04c6-bd58-48e7-8bab-1bbb207f6216");
    Guid id2 = Guid.Parse("26a7cc4e-3f9b-4923-809e-2f9b771d994f");
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasMany(u => u.Roles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

        builder.HasOne(u => u.Club)
                .WithMany(c => c.Staffs)
                .HasForeignKey(u => u.ClubId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(u => u.Wallet)
                .WithOne(w => w.User)
                .HasForeignKey<User>(u => u.WalletId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(u => u.Clubs)
                            .WithOne(c => c.Owner)
                .HasForeignKey(u => u.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(new User
        {
            Id = id1,
            Fullname = "John Doe",
            Gender = 1,
            UserStatusEnum = UserStatusEnum.Active,
            UserName = "john.doe",
            NormalizedUserName = "JOHN.DOE",
            Email = "john.doe@example.com",
            NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
            EmailConfirmed = false,
            PasswordHash = "hashedpassword1",
            SecurityStamp = "stamp1",
            ConcurrencyStamp = "concurrency1",
            PhoneNumber = "1234567890",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = true,
            LockoutEnabled = true,
            AccessFailedCount = 0
        },
        new User
        {
            Id = id2,
            Fullname = "Jane Smith",
            Gender = 1,
            UserStatusEnum = UserStatusEnum.Active,
            UserName = "jane.smith",
            NormalizedUserName = "JANE.SMITH",
            Email = "jane.smith@example.com",
            NormalizedEmail = "JANE.SMITH@EXAMPLE.COM",
            EmailConfirmed = false,
            PasswordHash = "hashedpassword1",
            SecurityStamp = "stamp1",
            ConcurrencyStamp = "concurrency1",
            PhoneNumber = "1234567890",
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = true,
            LockoutEnabled = true,
            AccessFailedCount = 0
        },
            new User
            {
                Id = Guid.Parse("40e8ca6a-06c0-4deb-8bec-c3919817b8cf"),
                Fullname = "Owner Club 1",
                Gender = 2,
                UserStatusEnum = UserStatusEnum.Active,
                UserName = "owner.club.1",
                NormalizedUserName = "OWNER.CLUB.1",
                Email = "owner.club.1@example.com",
                NormalizedEmail = "OWNER.CLUB.1@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = "hashedpassword2",
                SecurityStamp = "stamp2",
                ConcurrencyStamp = "concurrency2",
                PhoneNumber = "0987654321",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new User
            {
                Id = Guid.Parse("626d577c-5966-4993-afb8-72e672d16649"),
                Fullname = "Owner Club 2",
                Gender = 2,
                UserStatusEnum = UserStatusEnum.Deactivate,
                UserName = "owner.club.2",
                NormalizedUserName = "OWNER.CLUB.2",
                Email = "owner.club.2@example.com",
                NormalizedEmail = "OWNER.CLUB.2@EXAMPLE.COM",
                EmailConfirmed = true,
                PasswordHash = "hashedpassword2",
                SecurityStamp = "stamp2",
                ConcurrencyStamp = "concurrency2",
                PhoneNumber = "0987654321",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = true,
                LockoutEnabled = true,
                AccessFailedCount = 0
            });


    }
}