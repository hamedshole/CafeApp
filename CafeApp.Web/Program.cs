using CafeApp.Web.Components;
using CafeApp.Infrastructure.SqlServer;
using CafeApp.Domain.Interfaces;
using CafeApp.Web.Util;
using CafeApp.Shared;
using CafeApp.Shared.Layouts;
using CafeApp.Hubs;
using CafeApp.Shared.Util;
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
            app.UseHsts();
        }

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
