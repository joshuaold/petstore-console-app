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

            // the below should ideally be inside a method within a class that handles pet-related commands (like an endpoint inside a controller in Web API projects)
            // but by putting it here, hopefully it is much easier to read/review structure/architecture
            var petstoreService = serviceProvider.GetService<IPetstoreService>();
            var pets = await petstoreService.GetPetsByStatus("available");

            var groupedPetsByCategory = pets.GroupBy(pet => pet.Category == null ? "no-category" : pet.Category.Name.ToLower()) // if a pet doesn't have a category, we assign them one
                .OrderBy(x => x.Key); // orders the categories in ascending order

            // for loops would make this much faster but it's not that readable hence why we use a foreach
            foreach (var category in groupedPetsByCategory)
            {
                Console.WriteLine($"{category.Key}\r\n**********");
                
                var petsInCurrentCategory =  category.Select(x => x) // flattens out the grouping so that we are left with the list of pets in the current category
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
