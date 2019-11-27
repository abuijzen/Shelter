using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Shelter.Shared
{
	public interface IDatabaseInitializer
	{
		void Initialize();
	}

	public class DatabaseInitializer : IDatabaseInitializer
	{
		private ShelterContext _context;
		private ILogger<DatabaseInitializer> _logger;
		public DatabaseInitializer(ShelterContext context, ILogger<DatabaseInitializer> logger)
		{
			_context = context;
			_logger = logger;
		}
		public void Initialize()
		{
			try
			{
				if (_context.Database.EnsureCreated())
				{
					AddData();
				}
			}
			catch (Exception ex)
			{
				_logger.LogCritical(ex, "Error occurred while creating database");

			}
		}

		private void AddData()
		{
			/*var managers = new Manager()
			{
				FirstName = "Johan",
				LastName = "Janssen",
			};*/

			var shelter1 = new Shelter()
			{
				Name = "Canina",
				ImageUrl = "canina",
				Address = "Kievitstraat 40",
				TelephoneNumber = "036771291",
				EmailAdress = "/",
			
				Animals = new List<Animal> {
						new Cat{Name = "Felix", Race = "Britse Korthaar", DateOfBirth = new DateTime(2005, 10, 10), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "Felix is een iets schuwere kat die een baasje nodig heeft met veel geduld.", Allergies = "catnip", Clawed = true},
						new Cat{Name = "Picasso", Race = "Ragdoll", DateOfBirth = new DateTime(2005, 03, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "Picasso is een kat die samen met Binky geplaatst dient te worden.", Allergies = "dogs", Clawed = true},
						new Rabbit{Name = "Ior", Race="Hollander", DateOfBirth= new DateTime(2017, 12, 25), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 09, 10), Bio="Ior is een kindvriendelijk konijn die graag bij andere konijntjes gezet wordt indien mogelijk.", Allergies="none", Size="groot"},
						new Cat{Name = "Minoes", Race = "Europese Korthaar", DateOfBirth = new DateTime(2010, 10, 09), IsFertile = true, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 10, 09), Bio = "Minoes is een sociale en lieve kitten die net van een nestje komt.", Allergies = "geen", Clawed = true},
						new Cat{Name = "Binky", Race = "Europese Korthaar", DateOfBirth = new DateTime(2016, 11, 13), IsFertile = true, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2018, 12, 09), Bio = "Binky is een kat die samen met Picasso geplaatst dient te worden.", Allergies = "geen", Clawed = true},
						new Dog{Name = "Mopsie", Race="Mopshond", DateOfBirth= new DateTime(2017, 12, 25), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 09, 10), Bio="Mopsie is een gezonde mopshond gered uit de broodfok", Allergies="Chocolade", Barker=false},
				},
				Managers = new List<Manager> {
						new Manager{FirstName = "Johan",LastName = "Janssen",},
				},
				Administrators = new List<Administrator> {
						new Administrator{FirstName = "Johan",LastName = "Janssen",},
				},
				Caretakers = new List<Caretaker> {
						new Caretaker{FirstName = "Johan",LastName = "Janssen",},
				}
			};
			
			_context.Shelters.Add(shelter);

			_context.SaveChanges();
		}
	}
}