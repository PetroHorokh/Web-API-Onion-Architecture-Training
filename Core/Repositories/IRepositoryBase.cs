using System.Linq.Expressions;

namespace Core.Repositories;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> GetAllAsync(
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes);
    Task<IEnumerable<T>> GetByConditionAsync(
        Expression<Func<T, bool>> expression,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
}