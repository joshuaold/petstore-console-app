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
            var pets = await petstoreService.GetPetsByStatus("available");

            var groupedPetsByCategory = pets.GroupBy(pet => pet.Category == null ? "no-category" : pet.Category.Name.ToLower())
                .OrderBy(x => x.Key);

            foreach (var category in groupedPetsByCategory)
            {
                Console.WriteLine($"{category.Key}\r\n**********");
                
                var petsInCurrentCategory =  category.Select(x => x) // flattens out the grouping and
                    .OrderByDescending(pet => pet.Name); // orders by name in descending order

                foreach (var pet in petsInCurrentCategory)
                {
                    Console.WriteLine(pet.Name);
                }

                Console.WriteLine($"\r\n\n\n");
            }

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
