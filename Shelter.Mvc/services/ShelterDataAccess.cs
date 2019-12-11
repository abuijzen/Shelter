using System.Collections.Generic;
using System.Linq;
using Shelter.Shared;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Shelter.Mvc
{
    public interface IShelterDataAccess
    {
        IEnumerable<Shared.Shelter> GetAllShelters();
        IEnumerable<Shared.Shelter> GetAllSheltersFull();
        Shared.Shelter GetShelterById(int id);
        IEnumerable<Animal> GetAnimals(int shelterId);
        Animal GetAnimalByShelterAndId(int shelterId, int animalId);
        void DeleteAnimalByshelterIdAndId(int shelterId, int animalId);
        void CreateCat(Cat cat);
        void CreateRabbit(Rabbit rabbit);
        void CreateDog(Dog dog);
        void CreateShelter(Shared.Shelter shelter);
        void UpdateAnimal(int shelterId, int animalId);
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

        public void DeleteAnimalByshelterIdAndId(int shelterId, int animalId)
        {
            var animal = _context.Animals
            .FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);

            _context.Animals
            .Remove(animal);
            _context.SaveChanges();
        }

        public void CreateCat(Cat cat)
        {
            _context.Animals
            .Add(cat);
            _context.SaveChanges();
        }
        public void CreateRabbit(Rabbit rabbit)
        {
            _context.Animals
            .Add(rabbit);
            _context.SaveChanges();
        }

        public void CreateDog(Dog dog)
        {
            _context.Animals
            .Add(dog);
            _context.SaveChanges();
        }

        public void CreateShelter(Shared.Shelter shelter)
        {
            _context.Shelters
            .Add(shelter);
            _context.SaveChanges();
        }

        public void UpdateAnimal(int shelterId, int animalId)
        {
            var animal = _context.Animals
         .FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);

            _context.Animals
            .Update(animal);
            _context.SaveChanges();
        }
    }
}