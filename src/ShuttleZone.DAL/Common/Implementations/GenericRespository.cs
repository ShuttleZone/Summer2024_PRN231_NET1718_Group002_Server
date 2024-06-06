using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ShuttleZone.DAL.Common.Interfaces;
using ShuttleZone.Infrastructure.Data.Interfaces;

namespace ShuttleZone.DAL.Common.Implementations;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly IApplicationDbContext _context;
    private readonly IReadOnlyApplicationDbContext _readOnlyContext;
    private readonly DbSet<T> _entities;
    private readonly IQueryable<T> _readOnlyEntities;

    public GenericRepository(IApplicationDbContext context, IReadOnlyApplicationDbContext readOnlyContext)
    {
        _context = context;
        _readOnlyContext = readOnlyContext;
        _entities = _context.CreateSet<T>();
        _readOnlyEntities = _readOnlyContext.CreateSet<T>();
    }

    public void Add(T entity)
    {
        _entities.Add(entity);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _entities.AddAsync(entity, cancellationToken);
    }

    public void AddMany(IEnumerable<T> entities)
    {
        _entities.AddRange(entities);
    }

    public async Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        await _entities.AddRangeAsync(entities, cancellationToken);
    }

    public long Count(Expression<Func<T, bool>> predicate)
    {
        return _readOnlyEntities.Count(predicate);
    }

    public async Task<long> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _readOnlyEntities.LongCountAsync(predicate, cancellationToken);
    }

    public void DeleteMany(Expression<Func<T, bool>> predicate)
    {
        _entities.RemoveRange(_entities.Where(predicate));
    }

    public bool Exists(Expression<Func<T, bool>> predicate)
    {
        return _readOnlyEntities.Any(predicate);
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _readOnlyEntities.AnyAsync(predicate, cancellationToken);
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _readOnlyEntities.Where(predicate);
    }

    public T? Get(Expression<Func<T, bool>> predicate)
    {
        return _readOnlyEntities.FirstOrDefault(predicate);
    }

    public IQueryable<T> GetAll()
    {
        return _readOnlyEntities;
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await _readOnlyEntities.FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public void Update(T entity)
    {
        _entities.Update(entity);
    }

    public void UpdateMany(IEnumerable<T> entities)
    {
        _entities.UpdateRange(entities);
    }

    public void UpdateMany(Expression<Func<T, bool>> predicate)
    {
        _entities.UpdateRange(_entities.Where(predicate));
    }
}
