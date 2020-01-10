using System.Collections.Generic;
using System.Linq;
using Shelter.shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace Shelter.mvc
{
    public interface IShelterDataAccess
    {
        IEnumerable<shared.Shelter> GetAllShelters();
        IEnumerable<shared.Shelter> GetAllSheltersFull();
        shared.Shelter GetShelterById(int id);
        IEnumerable<Animal> GetAnimals(int shelterId);
        Animal GetAnimalByShelterAndId(int shelterId, int animalId);
        Animal CheckIfUnique(int shelterId, string animalName);
        void DeleteAnimalByshelterIdAndId(int shelterId, int animalId);
        void CreateCat(Cat cat);
        void CreateRabbit(Rabbit rabbit);
        void CreateDog(Dog dog);
        void CreateShelter(shared.Shelter shelter);
        void UpdateAnimal(int shelterId, int animalId, Animal animal);
    }

    public class ShelterDataAccess : IShelterDataAccess
    {
        private ShelterContext _context;

        public ShelterDataAccess(ShelterContext context)
        {
            _context = context;
        }

        public IEnumerable<shared.Shelter> GetAllShelters()
        {
            return _context.Shelters;
        }

        public IEnumerable<shared.Shelter> GetAllSheltersFull()
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

        public shared.Shelter GetShelterById(int id)
        {
            return _context.Shelters.FirstOrDefault(x => x.Id == id);
        }


        public Animal CheckIfUnique(int shelterId, string animalName)
        {
            //zoek shelter op id
            var shelter = this.GetShelterByIdWithAnimals(shelterId);
            //als er geen shelter gevonden wordt
            if (shelter == default(Shelter.shared.Shelter))
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

        public virtual shared.Shelter GetShelterByIdWithAnimals(int id)
        {
            return _context.Shelters.Include(x => x.Animals).FirstOrDefault(x => x.Id == id);
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

        public void CreateShelter(shared.Shelter shelter)
        {
            _context.Shelters
            .Add(shelter);
            _context.SaveChanges();
        }

        public void UpdateAnimal(int shelterId, int animalId, shared.Animal animal)
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
    }
}