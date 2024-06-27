using System.Linq.Expressions;

namespace ShuttleZone.DAL.Common.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Add(T entity);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void AddMany(IEnumerable<T> entities);
    Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    void Update(T entity);

    IQueryable<T> GetAll();
    Task<IQueryable<T>> GetAllAsync();
    IQueryable<T> GetAllAsNoTracking();
    T? Get(Expression<Func<T, bool>> predicate);
    T? GetAsNoTracking(Expression<Func<T, bool>> predicate);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T?> GetAsyncAsNoTracking(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    IQueryable<T> FindAsNoTracking(Expression<Func<T, bool>> predicate);

    long Count(Expression<Func<T, bool>> predicate);
    Task<long> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);

    bool Exists(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}
