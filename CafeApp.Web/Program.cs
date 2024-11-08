using CafeApp.Domain.Common;
using CafeApp.Domain.Interfaces;
using CafeApp.Hubs;
using CafeApp.Infrastructure.SqlServer;
using CafeApp.Shared;
using CafeApp.Shared.Layouts;
using CafeApp.Web.Components;
using CafeApp.Web.Util;
using Serilog;
namespace CafeApp.Web;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.AddServiceDefaults();
        builder.Services.AddSingleton(new ServerOptions { Url = builder.Configuration.GetValue<string>("ServerUrl") });
        builder.Services.AddSingleton<IAuth, AuthService>();
        builder.Services.AddSignalR();
        builder.Services.AddSingleton<IPlatform, PlatformService>();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Logging.AddConsole();
        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration)
            .Enrich.FromLogContext()
            .CreateLogger();
        builder.Logging.ClearProviders();
        builder.Logging.AddSerilog(logger);
        var log = new LoggerConfiguration()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
        
        // Add services to the container.
        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents(x=>x.DetailedErrors=true);
        builder.Services.RegisterServerDb(builder.Configuration.GetConnectionString("cafeDb"));
        builder.Services.RegisterAppServices();
        var app = builder.Build();

        app.MapDefaultEndpoints();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //app.UseHsts();
        }
        if (builder.Configuration.GetValue<bool>("ShowEndPoints"))
        {
            app.UseSwagger();
            app.UseSwaggerUI();

        }
       

        app.MapControllers();
        app.UseHttpsRedirection();
        
        app.UseStaticFiles();
        app.UseAntiforgery();
        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
            .AddAdditionalAssemblies(typeof(AdminLayout).Assembly);
        app.MapHub<TableHub>("/TableHub");

        app.Run();
    }
}
