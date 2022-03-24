using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petstore.ConsoleApp
{
    public class PetCommands
    {
        private IPetstoreService _petstoreService;

        public PetCommands(IPetstoreService petstoreService)
        {
            _petstoreService = petstoreService;
        }

        /// <summary>
        /// To create a unit test for this, we could just return groupedPetsByCategory and unit test the return value
        /// But in doing so, I don't think it is really unit testing the method
        /// If we do it, it looks more like we are unit testing the LINQ method which doesn't seem like it's an appropriate unit test for the application
        /// We could move the foreach loop into a different method though but I opted not to because of the explanation above
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task LogPetstorePets(string status)
        {
            var pets = await _petstoreService.GetPetsByStatus(status);

            var groupedPetsByCategory = pets.GroupBy(pet => pet.Category == null ? "no-category" : pet.Category.Name.ToLower()) // if a pet doesn't have a category, we assign them one
                .OrderBy(x => x.Key); // orders the categories in ascending order

            // for loops would make this much faster but it's not that readable hence why we use a foreach
            foreach (var category in groupedPetsByCategory)
            {
                Console.WriteLine($"{category.Key}\r\n**********");

                var petsInCurrentCategory = category.Select(x => x) // flattens out the grouping so that we are left with the list of pets in the current category
                    .OrderByDescending(pet => pet.Name); // orders by name in descending order

                foreach (var pet in petsInCurrentCategory)
                {
                    Console.WriteLine(pet.Name);
                }

                Console.WriteLine($"\r\n\n");
            }
        }
    }
}
