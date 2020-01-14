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
        //objecten maken die het gedrag van de echte objecten simuleert = mocking
        //mock data acces, een nul opbject doorgeven
        private Mock<ShelterDataAccess> _dataAccess = new Mock<ShelterDataAccess>(MockBehavior.Strict, new object[] { null })
        {
            CallBase = true 
        };

        [Test]
        public void Unique_NoAnimalsExistInShelter()
        {
            //vraag shelter op via id, en krijg de lijst met dieren
            _dataAccess.Setup(x => x.GetShelterByIdWithAnimals(2)).Returns(new shared.Shelter()
            {
                //krijg de lijst met dieren
                Animals = new List<Animal>()
            });

            //kijk of id 2, name "Marcel", geen 2x voorkomt
            var result = _dataAccess.Object.CheckIfUnique(2, "Marcel");
            Assert.IsNull(result); 
            // null == default(Animal)
        }

        [Test]
        public void Unique_AnotherAnimalsExistInShelterButDifferentName()
        {
            //vraag shelter op met id 2
            _dataAccess.Setup(x => x.GetShelterByIdWithAnimals(12)).Returns(new shared.Shelter()
            {
                //krijg de lijst met alle animals, voeg er eentje aan toe met naam 'feli'
                Animals = new List<Animal> {
          new Animal {
            Name = "Feli"
          }
        }
            });
            //kijk of 2, felix al bestaat
            //als je hier Feli typt, zal de test falen
            var result = _dataAccess.Object.CheckIfUnique(12, "Felix");
            Assert.IsNull(result);
        }
    }
}