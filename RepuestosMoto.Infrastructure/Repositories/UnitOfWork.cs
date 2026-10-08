using Microsoft.Extensions.DependencyInjection;
using RepuestosMoto.Application.Abstractions;
using RepuestosMoto.Infrastructure.Persistence;

namespace RepuestosMoto.Infrastructure.Repositories;

public sealed class UnitOfWork(RepuestosMotoDbContext db, IServiceProvider services) : IUnitOfWork
{
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        => services.GetRequiredService<IRepository<TEntity>>();
    public Task<int> SaveChangesAsync(CancellationToken ct = default) => db.SaveChangesAsync(ct);
}
