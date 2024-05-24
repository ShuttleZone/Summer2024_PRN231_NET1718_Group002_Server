using ShuttleZone.Common.Attributes;

namespace ShuttleZone.Application.Common.Interfaces;

[AutoRegister]
public interface IReadOnlyApplicationDbContext
{
    IQueryable<TEntity> CreateReadOnlySet<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
