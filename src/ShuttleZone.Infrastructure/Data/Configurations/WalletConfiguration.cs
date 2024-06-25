using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations
{
    public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable(nameof(Wallet));

            builder
            .HasOne(u => u.User)
            .WithOne(w => w.Wallet)
            .HasForeignKey<Wallet>(w => w.UserId);

       
        }
    }
}
