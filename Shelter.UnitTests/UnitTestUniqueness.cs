using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shelter.mvc;
using Shelter.shared;

namespace Shelter.UnitTests
{
    public class UnitTestUniqueness
    {
        //mock data acces, een nul opbject doorgeven
        private Mock<ShelterDataAccess> _dataAccess = new Mock<ShelterDataAccess>(MockBehavior.Strict, new object[] { null })
        {
            CallBase = true 
        };

        [Test]
        public void Unique_NoAnimalsExistInShelter()
        {
            _dataAccess.Setup(x => x.GetShelterByIdWithAnimals(12)).Returns(new shared.Shelter()
            {
                Animals = new List<Animal>()
            });
            var result = _dataAccess.Object.CheckIfUnique(12, "Name");
            Assert.IsNull(result); 
            // null == default(Animal)
        }

        [Test]
        public void Unique_AnotherAnimalsExistInShelterButDifferentName()
        {
            _dataAccess.Setup(x => x.GetShelterByIdWithAnimals(12)).Returns(new shared.Shelter()
            {
                Animals = new List<Animal> {
          new Animal {
            Name = "abcd"
          }
        }
            });
            var result = _dataAccess.Object.CheckIfUnique(12, "abcdef");
            Assert.IsNull(result);
        }
    }
}