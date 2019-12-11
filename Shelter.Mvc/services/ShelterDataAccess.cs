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
		void UpdateAnimal(Animal animal);
		Task<Animal> FindByIdAsync(int id);
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

		/*public Animal UpdateAnimal(int shelterId, int animalId)
		{
			/*var animal = _context.Animals.FirstOrDefault(x => x.ShelterId == shelterId && x.Id == animalId);

			if (animal == null)
			{
				throw new KeyNotFoundException("Animal not found.");
			}

			animal.Name = animal.Name;
			animal.IsFertile = animal.IsFertile;
			animal.IsKidFriendly = animal.IsKidFriendly;
			animal.IsAnimalFriendly = animal.IsAnimalFriendly;
			animal.IsSpeciesFriendly = animal.IsSpeciesFriendly;
			animal.Bio = animal.Bio;
			animal.Allergies = animal.Allergies;
			animal.ShelterId = animal.ShelterId;

			_context.SaveChanges();

			return animal;
		}*/


		public void UpdateAnimal(Animal animal)
		{
			_context.Animals.Update(animal);
		}

		public async Task<Animal> FindByIdAsync(int id)
		{
			return await _context.Animals.FindAsync(id);
		}
	}
}