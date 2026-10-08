using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using RepuestosMoto.Application.Abstractions;
using RepuestosMoto.Infrastructure.Persistence;

namespace RepuestosMoto.Infrastructure.Repositories;

public sealed class EfRepository<TEntity>(RepuestosMotoDbContext db) : IRepository<TEntity> where TEntity : class
{
    public async Task<TEntity?> GetByIdAsync(object[] keyValues, CancellationToken ct = default)
        => await db.Set<TEntity>().FindAsync(keyValues, ct);

    public async Task<IReadOnlyList<TEntity>> ListAsync(int skip = 0, int take = 50, CancellationToken ct = default)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(skip);
        if (take < 1 || take > 200) throw new ArgumentOutOfRangeException(nameof(take), "Use 1..200.");
        return await db.Set<TEntity>().AsNoTracking().Skip(skip).Take(take).ToListAsync(ct);
    }

    public async Task<IReadOnlyList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken ct = default)
        => await db.Set<TEntity>().AsNoTracking().Where(predicate).ToListAsync(ct);

    public async Task AddAsync(TEntity entity, CancellationToken ct = default) => await db.Set<TEntity>().AddAsync(entity, ct);
    public void Update(TEntity entity) => db.Set<TEntity>().Update(entity);
    public void Remove(TEntity entity) => db.Set<TEntity>().Remove(entity);
}
