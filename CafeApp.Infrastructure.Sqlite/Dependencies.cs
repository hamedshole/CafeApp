using CafeApp.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Infrastructure.Sqlite
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterInfrastructureSqlite(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<CafeDbContext>(opt => opt.UseSqlite(connectionString));
            return services;

        }
    }
}
