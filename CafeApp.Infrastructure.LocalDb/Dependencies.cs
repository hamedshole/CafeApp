using CafeApp.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Infrastructure.LocalDb
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterLocalDb(this IServiceCollection services,string dbName)
        {
            var sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{dbName}.db");
            services.AddDbContext<CafeDbContext>(opt=>opt.UseSqlite($"Data Source={sqlitePath}"));
            services.RegisterInfrastructure($"Data Source={sqlitePath}");
            return services;
        }
    }
}
