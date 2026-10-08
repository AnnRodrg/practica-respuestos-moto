using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepuestosMoto.Application.Abstractions;
using RepuestosMoto.Infrastructure.Persistence;
using RepuestosMoto.Infrastructure.Repositories;

namespace RepuestosMoto.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var connection = config.GetConnectionString("RepuestosMotoDB")
            ?? Environment.GetEnvironmentVariable("REPUESTOSMOTO_CONNECTION")
            ?? throw new InvalidOperationException("Configure REPUESTOSMOTO_CONNECTION.");
        services.AddDbContext<RepuestosMotoDbContext>(options => options.UseSqlServer(connection));
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
