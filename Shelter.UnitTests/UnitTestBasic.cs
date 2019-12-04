using NUnit.Framework;
using Shelter.Mvc.Controllers;
using Moq;
using Shelter.Mvc;
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

    // These tests can be run using dotnet test




	/* testen of je alle shelters kan opvragen en of de inhoud volledig hetzelfde is*/
    [Test]
    public void Test_GetAll()
    {
	
      var shelters = new List<Shelter.Shared.Shelter>();

      _mockedDataAccess.Setup(x => x.GetAllShelters()).Returns(shelters);
      // uncomment the next line, run the test, read the exception message.
      // mockedDataAccess.Setup(x => x.GetAllBreweriesFull()).Returns(breweries);

      var result = _controller.GetAllShelters();

      // uncomment this obviously wrong line, see what happens
      // Assert.IsInstanceOf(typeof(NotFoundResult), result);

      Assert.IsInstanceOf(typeof(OkObjectResult), result);
      Assert.AreEqual(((OkObjectResult)result).Value, shelters);
    }
/* 
    [Test]
    public void Test_GetOneHappyFlow()
    {
      var shelter = new Shelter.Shared.Shelter()
      {
        Name = "abc"
      };
      _mockedDataAccess.Setup(x => x.GetShelterById(2)).Returns(shelter);

      var result = _controller.GetShelter(2);

      Assert.IsInstanceOf(typeof(OkObjectResult), result);
      Assert.AreEqual(((OkObjectResult)result).Value, shelter);
    }

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