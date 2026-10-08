namespace RepuestosMoto.Application.Abstractions;

public interface IUnitOfWork
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}
