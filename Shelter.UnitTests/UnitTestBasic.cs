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

			var shelters = new List<Shelter.shared.Shelter>();

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
			var shelters = new List<Shelter.shared.Shelter>();
			_mockedDataAccess.Setup(x => x.GetAllSheltersFull()).Returns(shelters);

			var result = _controller.GetAllSheltersFull();

			//vergelijk of de inhoud van de shelter gelijk is aan de data die effectief in shelters zit
			Assert.IsInstanceOf(typeof(OkObjectResult), result);
			Assert.AreEqual(((OkObjectResult)result).Value, shelters);
		}
	}
}