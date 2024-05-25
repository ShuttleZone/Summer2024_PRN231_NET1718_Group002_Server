using Microsoft.EntityFrameworkCore;
using ShuttleZone.Application.Common.Interfaces;
using System.Linq.Expressions;

namespace ShuttleZone.Application.Common.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public GenericRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual DbSet<T> Entities => DbContext.Set<T>();

        public DbContext DbContext { get; }
        public void Add(T entity)
        {
            DbContext.Add(entity);
        }


        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await DbContext.AddAsync(entity, cancellationToken);
        }

        public void AddMany(IEnumerable<T> entities)
        {
            DbContext.AddRange(entities);
        }

        public async Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
        {
            await DbContext.AddRangeAsync(entities, cancellationToken);
        }

        public long Count(Expression<Func<T, bool>> predicate)
        {
            return Entities.AsQueryable().LongCount(predicate);
        }

        public async Task<long> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => Count(predicate), cancellationToken);
        }

        public void DeleteMany(Expression<Func<T, bool>> predicate)
        {
            var entitiesToDelete = Entities.AsQueryable().Where(predicate).ToList();
            foreach (var entity in entitiesToDelete)
            {
                Entities.Remove(entity);
            }
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return Entities.AsQueryable().Any(predicate);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => Exists(predicate), cancellationToken);
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Entities.AsQueryable().Where(predicate);
        }

        public T? Get(Expression<Func<T, bool>> predicate)
        {
            return Entities.AsQueryable().FirstOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return Entities.AsQueryable();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.Run(() => Get(predicate), cancellationToken);
        }

       
    }
}
