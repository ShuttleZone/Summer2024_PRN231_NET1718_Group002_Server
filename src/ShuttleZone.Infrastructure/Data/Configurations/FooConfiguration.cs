using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShuttleZone.Domain.Entities;

namespace ShuttleZone.Infrastructure.Data.Configurations;

public class FooConfiguration : IEntityTypeConfiguration<Foo>
{
    public void Configure(EntityTypeBuilder<Foo> builder)
    {
        builder.ToTable(nameof(Foo));
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();
        builder.Property(e => e.Name)
            .IsRequired();
    }
}
