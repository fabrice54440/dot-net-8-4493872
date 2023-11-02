using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace App;

class Program
{
    static void Main(string[] args)
    {
        var builder = Host.CreateDefaultBuilder();

        builder.ConfigureLogging(logging =>
        {
            logging.AddSimpleConsole(options =>
            {
                options.IncludeScopes = true;
                options.ColorBehavior = LoggerColorBehavior.Enabled;
                options.TimestampFormat = "hh:mm:ss ";
            });
        });
        builder.ConfigureAppConfiguration((context, configuration) =>
        {
            var env = context.HostingEnvironment.EnvironmentName;
            configuration
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true);
        });
        builder.ConfigureServices((context, services) =>
        {
            services.AddSingleton<IMessageProvider, IncMessageService>();
            services.AddHostedService<AppService>();
        });
        using var host = builder.Build();

        host.Run();
    }
}
