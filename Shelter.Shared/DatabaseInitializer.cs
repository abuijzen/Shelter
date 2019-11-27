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

			var shelter = new Shelter()
			{
				Name = "Dierenasiel",
				ImageUrl = "image",
				Address = "Dierenasielstraat 2",
				TelephoneNumber = "045673456",
				EmailAdress = "info@dierenasiel.be",
			
				Animals = new List<Animal> {
						new Cat{Name = "Felix", Race = "Britse Korthaar", DateOfBirth = new DateTime(2005, 10, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "meow I'm a cat", Allergies = "catnip", Clawed = true},
						new Cat{Name = "Picasso", Race = "Ragdoll", DateOfBirth = new DateTime(2005, 10, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "Mieeeuw", Allergies = "dogs", Clawed = true},
						new Rabbit{Name = "Ior", Race="Hollander", DateOfBirth= new DateTime(2017, 12, 25), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 09, 10), Bio="Ior is een cutiepie", Allergies="none", Size="small"},
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
			var shelter2 = new Shelter()
			{
				Name = "Veeweyde vzw",
				ImageUrl = "image",
				Address = "Toekomststraat 4",
				TelephoneNumber = "014658626",
				EmailAdress = "veeweyde.weelde@skynet.be",
			
				Animals = new List<Animal> {
						new Cat{Name = "Ludo", Race = "Europeese korthaar", DateOfBirth = new DateTime(2015, 12, 10), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = false, Since = new DateTime(2018, 02, 21), Bio = "Ludo is een lievertje maar niet voor andere dieren.", Allergies = "geen", Clawed = true},
						new Dog{Name = "Puk", Race = "Franse Bulldog", DateOfBirth = new DateTime(2018, 09, 19), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 05, 20), Bio = "Puk is een echte ronkende franse buldog, door gezondheidsproblemen is hij bij ons beland", Allergies = "Kip", Barker = true},
						new Cat{Name = "Moesti", Race = "Europeese korthaar", DateOfBirth = new DateTime(2014, 03, 02), IsFertile = false, IsKidFriendly = false, IsAnimalFriendly = true, IsSpeciesFriendly =true, Since = new DateTime(2016, 07, 17), Bio = "Moesti is een echte dierenvriend van kleine kinderen houden ze niet", Allergies = "geen", Clawed = true},
						new Dog{Name = "Marcel", Race = "Teckel", DateOfBirth = new DateTime(2009, 10, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 09, 20), Bio = "Marcel is een oude gek, op zijn oude dag heeft hij nog veel liefde voor tennisballen", Allergies = "geen", Barker = false},
						new Rabbit{Name = "Olaf", Race="Rijnlander", DateOfBirth= new DateTime(2017, 10, 15), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 10, 17), Bio="Olaf is een vinnig beestje, perfect voor jonge gezinnen", Allergies="geen", Size="groot"},
						new Rabbit{Name = "Garret", Race="Franse Hangoor", DateOfBirth= new DateTime(2015, 08, 20), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =false, IsSpeciesFriendly=false, Since=new DateTime(2019, 10, 11), Bio="Garret houd van kinderen en mensen, van andere dieren gaat hij lopen.", Allergies="geen", Size="groot"},
						new Dog{Name = "Astrix", Race = "Mastino Napoletano", DateOfBirth = new DateTime(2017, 02, 12), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = true, Since = new DateTime(2018, 10, 22), Bio = "Astrix is een grote jongen die veel liefde geeft", Allergies = "geen", Barker = true},
						new Dog{Name = "Rock", Race = "Staffordshire Bull Terrier", DateOfBirth = new DateTime(2016, 09, 19), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2017, 11, 09), Bio = "Rock is een grote dikke vriend van iedereen", Allergies = "kip", Barker = true},
				},
				Managers = new List<Manager> {
						new Manager{FirstName = "Marie",LastName = "Veeweyde",},
				},
				Administrators = new List<Administrator> {
						new Administrator{FirstName = "Karel",LastName = "Hoefkens",},
						new Administrator{FirstName = "Lies",LastName = "Ravens",},
				},
				Caretakers = new List<Caretaker> {
						new Caretaker{FirstName = "Nina",LastName = "Meas",},
						new Caretaker{FirstName = "Jonas",LastName = "Donnas",},
						new Caretaker{FirstName = "Koen",LastName = "Rogge",},
				}
			};
			
			_context.Shelters.Add(shelter);
			_context.Shelters.Add(shelter2);
			_context.SaveChanges();
		}
	}
}