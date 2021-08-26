using AmmBot.Core;
using AmmBot.Core.Interfaces;
using AmmBot.HelloProvider;
using AmmBot.HelloProvider.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AmmBot.Service
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var token = hostContext.Configuration.GetSection("VkBot").GetSection("Token").Value;
                    
                    services.Configure<VkBotOptions>(hostContext.Configuration.GetSection("VkBot"));

                    services.AddSingleton<IHelloUserStrategy, AmmHelloUserStrategy>();
                    services.AddSingleton<IVkBot>(x => new VkBot(token));

                    services.AddHostedService<VkBotService>();
                })
                .UseConsoleLifetime()
                .UseWindowsService(options => {
                    options.ServiceName = "VK AMM Bot";
                });
    }
}