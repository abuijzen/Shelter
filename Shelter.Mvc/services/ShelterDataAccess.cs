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
        IEnumerable<Dog> GetDogs(int shelterId);
        Animal GetAnimalByShelterAndId(int shelterId, int animalId);
        void DeleteAnimalByshelterIdAndId(int shelterId, int animalId);
        void CreateCat(Cat cat);
        void CreateRabbit(Rabbit rabbit);
        void CreateDog(Dog dog);
        void CreateShelter(Shared.Shelter shelter);
        void UpdateAnimal(int shelterId, int animalId, Animal animal);
        void UpdateDog(int animalId, int shelterId, Dog dog);
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

        public IEnumerable<Dog> GetDogs(int shelterId)
        {
            return _context.Dogs
            .Where(x => x.ShelterId == shelterId).ToList();
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
            var newCat = new Cat();

            newCat.Name = cat.Name;
            newCat.Race = cat.Race;
            newCat.DateOfBirth = cat.DateOfBirth;
            newCat.IsFertile = cat.IsFertile;
            newCat.IsKidFriendly = cat.IsKidFriendly;
            newCat.IsAnimalFriendly = cat.IsAnimalFriendly;
            newCat.IsSpeciesFriendly = cat.IsSpeciesFriendly;
            newCat.Since = cat.Since;
            newCat.Bio = cat.Bio;
            newCat.Allergies = cat.Allergies;
            newCat.ShelterId = cat.ShelterId;
            newCat.Clawed = cat.Clawed;
            _context.Animals

            .Add(newCat);
            _context.SaveChanges();
        }
        public void CreateRabbit(Rabbit rabbit)
        {
            var newRabbit = new Rabbit();

            newRabbit.Name = rabbit.Name;
            newRabbit.Race = rabbit.Race;
            newRabbit.DateOfBirth = rabbit.DateOfBirth;
            newRabbit.IsFertile = rabbit.IsFertile;
            newRabbit.IsKidFriendly = rabbit.IsKidFriendly;
            newRabbit.IsAnimalFriendly = rabbit.IsAnimalFriendly;
            newRabbit.IsSpeciesFriendly = rabbit.IsSpeciesFriendly;
            newRabbit.Since = rabbit.Since;
            newRabbit.Bio = rabbit.Bio;
            newRabbit.Allergies = rabbit.Allergies;
            newRabbit.ShelterId = rabbit.ShelterId;
            newRabbit.Size = rabbit.Size;

            _context.Animals
            .Add(newRabbit);
            _context.SaveChanges();
        }

        public void CreateDog(Dog dog)
        {
            var newDog = new Dog();

            newDog.Name = dog.Name;
            newDog.Race = dog.Race;
            newDog.DateOfBirth = dog.DateOfBirth;
            newDog.IsFertile = dog.IsFertile;
            newDog.IsKidFriendly = dog.IsKidFriendly;
            newDog.IsAnimalFriendly = dog.IsAnimalFriendly;
            newDog.IsSpeciesFriendly = dog.IsSpeciesFriendly;
            newDog.Since = dog.Since;
            newDog.Bio = dog.Bio;
            newDog.Allergies = dog.Allergies;
            newDog.ShelterId = dog.ShelterId;
            newDog.Barker = dog.Barker;

            _context.Animals
            .Add(newDog);
            _context.SaveChanges();
        }

        public void CreateShelter(Shared.Shelter shelter)
        {
            /*Shared.Shelter schrijven we omdat het programma niet het onderscheid kan maken met namespace en klasse*/
            var newShelter = new Shared.Shelter();

            newShelter.Name = shelter.Name;
            newShelter.ImageUrl = shelter.ImageUrl;
            newShelter.Address = shelter.Address;
            newShelter.TelephoneNumber = shelter.TelephoneNumber;
            newShelter.EmailAdress = shelter.EmailAdress;

            _context.Shelters
            .Add(newShelter);
            _context.SaveChanges();
        }

        public void UpdateAnimal(int shelterId, int animalId, Shared.Animal animal)
        {
            var existingAnimal = _context.Animals
                .FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);

            existingAnimal.Name = animal.Name;
            existingAnimal.Race = animal.Race;
            existingAnimal.DateOfBirth = animal.DateOfBirth;
            existingAnimal.IsFertile = animal.IsFertile;
            existingAnimal.IsKidFriendly = animal.IsKidFriendly;
            existingAnimal.IsAnimalFriendly = animal.IsAnimalFriendly;
            existingAnimal.IsSpeciesFriendly = animal.IsSpeciesFriendly;
            existingAnimal.Since = animal.Since;
            existingAnimal.Bio = animal.Bio;
            existingAnimal.Allergies = animal.Allergies;
            existingAnimal.ShelterId = animal.ShelterId;

            _context.Update(existingAnimal);
            _context.SaveChanges();
        }

        public void UpdateDog(int animalId, int shelterId, Dog dog)
        {
            var existingDog = _context.Dogs
            .FirstOrDefault(x => x.Id == animalId && x.ShelterId == shelterId);

            existingDog.Name = dog.Name;
            existingDog.Race = dog.Race;
            existingDog.DateOfBirth = dog.DateOfBirth;
            existingDog.IsFertile = dog.IsFertile;
            existingDog.IsKidFriendly = dog.IsKidFriendly;
            existingDog.IsAnimalFriendly = dog.IsAnimalFriendly;
            existingDog.IsSpeciesFriendly = dog.IsSpeciesFriendly;
            existingDog.Since = dog.Since;
            existingDog.Bio = dog.Bio;
            existingDog.Allergies = dog.Allergies;
            existingDog.Barker = dog.Barker;

            _context.Update(existingDog);
            _context.SaveChanges();
        }
    }
}