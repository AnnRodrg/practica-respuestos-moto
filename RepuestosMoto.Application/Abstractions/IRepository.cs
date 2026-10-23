using System.Linq.Expressions;

namespace RepuestosMoto.Application.Abstractions;

public interface IRepository<TEntity> where TEntity : class
{

    // CRUD operations 
    Task<TEntity?> GetByIdAsync(object[] keyValues, CancellationToken ct = default);
    Task<IReadOnlyList<TEntity>> ListAsync(int skip = 0, int take = 50, CancellationToken ct = default);
    Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default);
    Task AddAsync(TEntity entity, CancellationToken ct = default);
    void Update(TEntity entity);
    void Remove(TEntity entity);
}
