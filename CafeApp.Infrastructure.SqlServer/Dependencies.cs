using CafeApp.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CafeApp.Infrastructure.SqlServer
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterInfrastructureSqlServer(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<CafeDbContext>(opt => opt.UseSqlServer(connectionString));
            return services;

        }
    }
}
