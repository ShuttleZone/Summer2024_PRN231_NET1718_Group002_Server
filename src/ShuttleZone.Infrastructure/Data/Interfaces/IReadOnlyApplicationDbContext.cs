namespace ShuttleZone.Infrastructure.Data.Interfaces;

public interface IReadOnlyApplicationDbContext
{
    IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class;
}
