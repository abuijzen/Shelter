using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using Shelter.Mvc;
using Shelter.shared;

namespace Shelter.UnitTests
{
  public class UnitTestUniqueness
  {
    // we're going to mock the data-access; we need to pass a null object. Feel free to "break" this code.
    private Mock<ShelterDataAccess> _dataAccess = new Mock<ShelterDataAccess>(MockBehavior.Strict, new object[] { null })
    {
      CallBase = true // basically means "unless you explicitly mock the method, use the regular method of the class itself.
    };

    [Test]
    public void Unique_NoAnimalsExistInShelter()
    {
      _dataAccess.Setup(x => x.GetShelterByIdWithAnimals(12)).Returns(new shared.Shelter()
      {
        Animals = new List<Animal>()
      });
      var result = _dataAccess.Object.CheckIfUnique(12, "Name");
      Assert.IsNull(result); // null == default(Animal); in practice for all objects "null" is the default value. However, it's still useful to test for default b/c for primitives (int, double, ...) this not true.
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

    // Enough examples ;-). Other unit tests you should write are ...
    // - what if an animal exists with the same name?
    // - what if an animal exists in another shelter with the same name?
    // - ...
  }
}