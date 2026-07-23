using epariona_curso04_tarea02.Domain.Common;
using epariona_curso04_tarea02.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace epariona_curso04_tarea02.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("Curso04Db"));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        return services;
    }
}
