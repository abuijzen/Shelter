using System.Collections.Generic;
using System.Linq;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace Shelter.Mvc
{
  public interface IShelterDataAccess
  {
    IEnumerable<Shared.Shelter> GetAllShelters();
    IEnumerable<Shared.Shelter> GetAllSheltersFull();
    Shared.Shelter GetShelterById(int id);
    IEnumerable<Animal> GetAnimals(int shelterId);
    Animal GetAnimalByShelterAndId(int shelterId, int animalId);
    Animal CheckIfUnique(int shelterId, string animalName);
  }

  public class ShelterDataAccess : IShelterDataAccess
  {
    private ShelterContext _context;

    public ShelterDataAccess(ShelterContext context)
    {
      _context = context;
    }

    public IEnumerable<Shared.Shelter> GetAllShelters()
    {
      return _context.Shelters;
    }

    public IEnumerable<Shared.Shelter> GetAllSheltersFull()
    {
      return _context.Shelters
        .Include(shelter => shelter.Animals)
        .Include(shelter => shelter.Managers);
    }

    public Animal GetAnimalByShelterAndId(int shelterId, int animalId)
    {
      return _context.Animals
        .FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);
    }

    public IEnumerable<Animal> GetAnimals(int shelterId)
    {
      return _context.Shelters
        .Include(shelter => shelter.Animals)
        .FirstOrDefault(x => x.Id == shelterId)?.Animals;
    }

    public Shared.Shelter GetShelterById(int id)
    {
      return _context.Shelters.FirstOrDefault(x => x.Id == id);
    }


    public Animal CheckIfUnique(int shelterId, string animalName)
    {
      //zoek shelter op id
      var shelter = this.GetShelterByIdWithAnimals(shelterId);
      //als er geen shelter gevonden wordt
      if (shelter == default(Shelter.Shared.Shelter))
      {
        return default(Animal);
      }
      else
      {
        //vraag een lijst op waarbij dieren dezelfde naam hebben
        var animals = shelter.Animals.Where(x => x.Name == animalName).ToList();

        //boolean, is er een dier met dezelfde naam? =1
        if (animals.Count > 1)
        {
          throw new Exception("Multiple animals with the same name");
        }
        else if (animals.Count == 1)
        {
          Animal animal = GetAnimalById(animals);
          return animal;
        }
        return default(Animal);
      }

    }

    // Needs to be virtual as we're going to mock this
    public virtual Animal GetAnimalById(List<Animal> animals)
    {
      return _context.Animals.FirstOrDefault(x => x.Id == animals.FirstOrDefault().Id);
    }

    // Needs to be virtual as we're going to mock this

    public virtual Shared.Shelter GetShelterByIdWithAnimals(int id)
    {
      return _context.Shelters.Include(x => x.Animals).FirstOrDefault(x => x.Id == id);
    }
  }
}