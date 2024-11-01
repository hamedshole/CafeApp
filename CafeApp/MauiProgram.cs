using CafeApp.Infrastructure.LocalDb;
using Microsoft.Extensions.Logging;
using CafeApp.Shared;
using CafeApp.Shared.Util;
using Microsoft.Extensions.Configuration;
using CafeApp.Domain.Interfaces;
using CafeApp.Util;
namespace CafeApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
           var stream=FileSystem.Current.OpenAppPackageFileAsync("appsettings.json").Result;
          
            var configurationBuilder = new ConfigurationBuilder()
             .SetBasePath(AppContext.BaseDirectory)
             .AddJsonStream(stream);

            IConfiguration configuration = configurationBuilder.Build();
            builder.Configuration.AddConfiguration(configuration);
            builder.Services.AddScoped<IAuth, AuthService>();
            builder.Services.AddSingleton(new ServerOptions { Url = builder.Configuration.GetValue<string>("ServerUrl") });
            builder.Services.RegisterLocalDb("cafeDb");
            builder.Services.RegisterAppServices();

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
