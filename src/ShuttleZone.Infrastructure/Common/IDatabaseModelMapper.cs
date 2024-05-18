using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShuttleZone.Infrastructure.Common;

public interface IDatabaseModelMapper<TEntity> where TEntity : class
{
    void Map(EntityTypeBuilder<TEntity> builder);
}
