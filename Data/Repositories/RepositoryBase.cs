using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories;

public class RepositoryBase<T>(DbContext context) : IRepositoryBase<T> where T : class
{
    protected readonly DbContext Context = context;

    public async Task<IEnumerable<T>> GetAllAsync(
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes)
    {
        var query = Context
            .Set<T>()
            .AsQueryable();

        return await includes
            .Aggregate(query, (current, next) => current.Include(next))
            .ToListAsync(cancellationToken);
    }


    public async Task<IEnumerable<T>> GetByConditionAsync(
        Expression<Func<T, bool>> expression,
        CancellationToken cancellationToken = default,
        params Expression<Func<T, object>>[] includes)
    {
        var query = Context
            .Set<T>()
            .Where(expression)
            .AsQueryable();

        return await includes
            .Aggregate(query, (current, next) => current.Include(next))
            .ToListAsync(cancellationToken);
    }

    public void Create(T entity) => Context.Set<T>().Add(entity);
    public void Update(T entity) => Context.Set<T>().Update(entity);
    public void Delete(T entity) => Context.Set<T>().Remove(entity);
}