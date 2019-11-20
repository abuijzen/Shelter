using System.Collections.Generic;
using System.Linq;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;

namespace Shelter.MVC
{
  public interface IShelterDataAccess
  {
    IEnumerable<Shared.Shelter> GetAllShelters();
    IEnumerable<Shared.Shelter> GetAllSheltersFull();
    Shared.Shelter GetShelterById(int id);

    IEnumerable<Animal> GetAnimals(int shelterId);
    Animal GetAnimalByShelterAndId(int shelterId, int animalId);
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
        .Include(shelter => shelter.Animals).ThenInclude(animal => animal.AnimalType)
        .Include(shelter => shelter.Owner);
    }

    public Animal GetAnimalByShelterAndId(int shelterId, int animalId)
    {
      return _context.Animals
        .Include(animal => animal.AnimalType)
        .FirstOrDefault(x => x.ShelterId == shelterId && x.Id == shelterId);
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
  }
}