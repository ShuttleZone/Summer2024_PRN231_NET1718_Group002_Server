using System.Linq.Expressions;

namespace ShuttleZone.Application.Common.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Add(T entity);
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void AddMany(IEnumerable<T> entities);
    Task AddManyAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);
    
    void Update(T entity);
    void UpdateMany(IEnumerable<T> entities);
    void UpdateMany(Expression<Func<T, bool>> predicate);
    
    void DeleteMany(Expression<Func<T, bool>> predicate);
    
    IQueryable<T> GetAll();
    T? Get(Expression<Func<T, bool>> predicate);
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    
    long Count(Expression<Func<T, bool>> predicate);
    Task<long> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    
    bool Exists(Expression<Func<T, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}