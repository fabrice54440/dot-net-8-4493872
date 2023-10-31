using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace App;

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureAppConfiguration((context, configuration) =>
        {
            var env = context.HostingEnvironment.EnvironmentName;
            configuration
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
        });
        builder.ConfigureServices((context, services) =>
        {
            services.AddHostedService(_ => new AppService(
            context.Configuration.GetValue("options:msg", "ok") ?? "ok"
        ));
        });
        using var host = builder.Build();

        host.Run();
    }
}
