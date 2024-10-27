using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Shared
{
    public static class Dependencies
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {
            services.AddMudServices();
            return services;

        }
    }
}
