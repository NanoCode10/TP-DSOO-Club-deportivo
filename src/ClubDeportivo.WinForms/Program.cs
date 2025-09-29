using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Windows.Forms;
using ClubDeportivo.Data;

namespace ClubDeportivo.WinForms;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        using var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(cfg =>
            {
                cfg.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                   .AddJsonFile("appsettings.Development.json", optional: true)
                   .AddEnvironmentVariables();
            })
            .ConfigureServices((ctx, services) =>
            {
                var cs = ctx.Configuration.GetConnectionString("Default")
                         ?? throw new InvalidOperationException("Missing ConnectionStrings:Default");
                services.AddDbContext<ClubContext>(opt =>
                    opt.UseMySql(cs, ServerVersion.AutoDetect(cs)));

                // Forms (Bocetos: login -> menú) :contentReference[oaicite:6]{index=6}
                services.AddTransient<Forms.FrmLogin>();
                services.AddTransient<Forms.FrmMenuPrincipal>();
            })
            .ConfigureLogging(lb => lb.AddConsole())
            .Build();

        var login = host.Services.GetRequiredService<Forms.FrmLogin>();
        Application.Run(login);
    }
}
