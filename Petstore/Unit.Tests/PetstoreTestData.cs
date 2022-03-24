using Core.PetAggregate;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Unit.Tests
{
    public class PetstoreTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] 
            {
                new Pet()
                {
                    Name = "Daschund",
                    Category = new Category() { Name = "Dog" }
                },
                new Pet() 
                { 
                    Name = "Pug", 
                    Category = new Category() { Name = "Dog" } 
                },
                new Pet()
                {
                    Name = "Bulldog",
                    Category = new Category() { Name = "Dog" }
                },
                " Pug"
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
