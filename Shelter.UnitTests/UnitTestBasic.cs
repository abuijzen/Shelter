using NUnit.Framework;
using Shelter.mvc.Controllers;
using Moq;
using Shelter.mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Shelter.UnitTests
{
    public class Tests
    {
        private Mock<IShelterDataAccess> _mockedDataAccess;
        private Mock<ILogger<ApiController>> _mockedLogger;
        private ApiController _controller;

        [SetUp]
        public void Setup()
        {
            _mockedDataAccess = new Mock<IShelterDataAccess>(MockBehavior.Strict);
            _mockedLogger = new Mock<ILogger<ApiController>>(MockBehavior.Strict);
            _controller = new ApiController(_mockedLogger.Object, _mockedDataAccess.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _mockedDataAccess.VerifyAll();
            _mockedLogger.VerifyAll();
        }


        /* testen of je alle shelters kan opvragen en teruggeven*/
        //+ checken of de inhoud volledig hetzelfde is van beide
        [Test]
        public void Test_GetAll()
        {

            var shelters = new List<Shelter.Shared.Shelter>();

            _mockedDataAccess.Setup(x => x.GetAllShelters()).Returns(shelters);

            var result = _controller.GetAllShelters();

            // uncomment this obviously wrong line, see what happens
            // Assert.IsInstanceOf(typeof(NotFoundResult), result);

            Assert.IsInstanceOf(typeof(OkObjectResult), result);
            Assert.AreEqual(((OkObjectResult)result).Value, shelters);
        }


        [Test]
        public void Test_GetAllAnimals()
        {
            //vraag alle shelters op en geef te terug
            var shelters = new List<Shelter.Shared.Shelter>();
            _mockedDataAccess.Setup(x => x.GetAllSheltersFull()).Returns(shelters);

            var result = _controller.GetAllSheltersFull();

            //vergelijk of de inhoud van de shelter gelijk is aan de data die effectief in shelters zit
            Assert.IsInstanceOf(typeof(OkObjectResult), result);
            Assert.AreEqual(((OkObjectResult)result).Value, shelters);
        }


        /* Check of combinatie dier-type (hond, kat of konijn) en naam binnen één shelter uniek is. */
        /* momenteel = alle dieren checken en kijken of de inhoud die teruggegeven wordt ook klopt */
        /* 
            [Test]
            public void Test_checkUnique()
            {
              //vraag alle shelters op en geef te terug
             var shelters = new List<Shelter.Shared.Shelter>();

              _mockedDataAccess.Setup(x => x.CheckIfUnique()).Returns(shelters);

              var result = _controller.CheckIfUnique();

              Assert.IsInstanceOf(typeof(OkObjectResult), result);
              Assert.AreEqual(((OkObjectResult)result).Value, shelters);
            }


        */

        /* 
            [Test]
            public void Test_CheckIfUnique()
            {
              var shelter = new Shelter.Shared.Shelter()
              {
                Name = "abc"
              };
              _mockedDataAccess.Setup(x => x.CheckIfUnique(2)).Returns(shelter);

              var result = _controller.CheckIfUnique(2);

              Assert.IsInstanceOf(typeof(OkObjectResult), result);
              Assert.AreEqual(((OkObjectResult)result).Value, shelter);
            }

            */
        /* 
            [Test]
            public void Test_GetOneNotFound()
            {
              _mockedDataAccess.Setup(x => x.GetShelterById(2)).Returns(default(Shelter.Shared.Shelter));
              var result = _controller.GetShelter(2);
              Assert.IsInstanceOf(typeof(NotFoundResult), result);
            }

          */
    }
}