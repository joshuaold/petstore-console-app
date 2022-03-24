/*using Services;*/
using Core.Interfaces.Services;
using Infrastructure.Connections;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Petstore.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ServiceProvider serviceProvider = ConfigureServices(); // not the best/cleanest way to do this but it is a simple way to implement Dependency Injection
            var petstoreService = serviceProvider.GetService<IPetstoreService>();

            PetCommands petCommands = new PetCommands(petstoreService);
            await petCommands.LogPetstorePets("available");

            Console.ReadLine();
        }

        private static ServiceProvider ConfigureServices()
        {
            var serviceProvider = new ServiceCollection()
            .AddTransient<IPetstoreService, PetstoreService>()
            .AddSingleton<IHTTPConnection, HTTPConnection>()
            .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
