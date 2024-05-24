namespace ShuttleZone.DAL.Common.Interfaces;

public interface IReadOnlyApplicationDbContext
{
    IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class;
}
