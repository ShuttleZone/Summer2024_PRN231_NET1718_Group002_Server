using ShuttleZone.Common.Attributes;

namespace ShuttleZone.Application.Common.Interfaces;

[AutoRegister]
public interface IApplicationDbContext
{
    IQueryable<TEntity> CreateSet<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
    void Migrate();
}
