using Core.Interfaces.Services;
using Core.PetAggregate;
using FakeItEasy;
using Petstore.ConsoleApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Unit.Tests
{
    public class PetCommandsTests
    {
        [Theory]
        [ClassData(typeof(PetstoreTestData))]
        public async void LogPetstorePetsDescendingOrderLastItem(Pet petOne, Pet petTwo, Pet petThree, string firstPetToDisplay)
        {
            // Arrange
            var service = A.Fake<IPetstoreService>();
            var pets = A.CollectionOfDummy<Pet>(3).ToList();
            pets.AddRange(new List<Pet> { petOne, petTwo, petThree });


            A.CallTo(() => service.GetPetsByStatus("")).
                Returns(Task.FromResult(pets.AsEnumerable()));

            var commands = new PetCommands(service);

            // Fact
            await commands.LogPetstorePets("");

            // Assert
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            Console.WriteLine(firstPetToDisplay);
            Assert.Equal(firstPetToDisplay, stringWriter.ToString().Replace("\r\n", ""));
        }
    }
}
