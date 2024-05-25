using Microsoft.EntityFrameworkCore;

namespace ShuttleZone.DAL.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TEntity> CreateSet<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
    void Migrate();
}
