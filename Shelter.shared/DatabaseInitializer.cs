using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Shelter.shared;
using System.Threading.Tasks;

namespace Shelter.shared
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
			var shelter1 = new Shelter()
			{
				Name = "Canina",
				ImageUrl = "canina",
				Address = "Kievitstraat 40",
				TelephoneNumber = "036771291",
				EmailAdress = "/",

				/*Animals = new List<Animal> {
					new Cat{Name = "Felix", Race = "Britse Korthaar", DateOfBirth = new DateTime(2005, 10, 10), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "Felix is een iets schuwere kat die een baasje nodig heeft met veel geduld.", Allergies = "catnip", ShelterId = 1, Clawed = true},
					new Cat{Name = "Picasso", Race = "Ragdoll", DateOfBirth = new DateTime(2005, 03, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "Picasso is een kat die samen met Binky geplaatst dient te worden.", Allergies = "dogs", ShelterId = 1, Clawed = true},
					new Rabbit{Name = "Ior", Race="Hollander", DateOfBirth= new DateTime(2017, 12, 25), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 09, 10), Bio="Ior is een kindvriendelijk konijn die graag bij andere konijntjes gezet wordt indien mogelijk.", Allergies="none", ShelterId = 1, Size="groot"},
					new Cat{Name = "Minoes", Race = "Europese Korthaar", DateOfBirth = new DateTime(2010, 10, 09), IsFertile = true, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 10, 09), Bio = "Minoes is een sociale en lieve kitten die net van een nestje komt.", Allergies = "geen", ShelterId = 1, Clawed = true},
					new Cat{Name = "Binky", Race = "Europese Korthaar", DateOfBirth = new DateTime(2016, 11, 13), IsFertile = true, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2018, 12, 09), Bio = "Binky is een kat die samen met Picasso geplaatst dient te worden.", Allergies = "geen", ShelterId = 1, Clawed = true},
					new Dog{Name = "Mopsie", Race="Mopshond", DateOfBirth= new DateTime(2017, 12, 25), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 09, 10), Bio="Mopsie is een gezonde mopshond gered uit de broodfok", Allergies="Chocolade", ShelterId = 1, Barker=false},
				},*/
				Managers = new List<Manager> {
					new Manager{FirstName = "Kristien",LastName = "Akkermans",},
					new Manager{FirstName = "Jonas",LastName = "Vandersteen",},
					new Manager{FirstName = "Thomas",LastName = "Van Ostaeyen",},
				},
				Administrators = new List<Administrator> {
					new Administrator{FirstName = "Annelies",LastName = "Metsers",},
					new Administrator{FirstName = "Mieke",LastName = "Mertens",},
				},
				Caretakers = new List<Caretaker> {
					new Caretaker{FirstName = "Eva",LastName = "De Winter",},
					new Caretaker{FirstName = "Kim",LastName = "Van de Moortele",},
					new Caretaker{FirstName = "Arne",LastName = "Bogaert",},
					new Caretaker{FirstName = "Karel",LastName = "Gevaerts",},
					new Caretaker{FirstName = "Daniel",LastName = "Verstappen",},
				}
			};

			var shelter2 = new Shelter()
			{
				Name = "Veeweyde vzw",
				ImageUrl = "image",
				Address = "Toekomststraat 4",
				TelephoneNumber = "014658626",
				EmailAdress = "veeweyde.weelde@skynet.be",

				/*Animals = new List<Animal> {
					new Cat{Name = "Ludo", Race = "Europeese korthaar", DateOfBirth = new DateTime(2015, 12, 10), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = false, Since = new DateTime(2018, 02, 21), Bio = "Ludo is een lievertje maar niet voor andere dieren.", Allergies = "geen", ShelterId = 2, Clawed = true},
					new Dog{Name = "Puk", Race = "Franse Bulldog", DateOfBirth = new DateTime(2018, 09, 19), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 05, 20), Bio = "Puk is een echte ronkende franse buldog, door gezondheidsproblemen is hij bij ons beland", Allergies = "Kip", ShelterId = 2, Barker = true},
					new Cat{Name = "Moesti", Race = "Europeese korthaar", DateOfBirth = new DateTime(2014, 03, 02), IsFertile = false, IsKidFriendly = false, IsAnimalFriendly = true, IsSpeciesFriendly =true, Since = new DateTime(2016, 07, 17), Bio = "Moesti is een echte dierenvriend van kleine kinderen houden ze niet", Allergies = "geen", ShelterId = 2, Clawed = true},
					new Dog{Name = "Marcel", Race = "Teckel", DateOfBirth = new DateTime(2009, 10, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 09, 20), Bio = "Marcel is een oude gek, op zijn oude dag heeft hij nog veel liefde voor tennisballen", Allergies = "geen", ShelterId = 2, Barker = false},
					new Rabbit{Name = "Olaf", Race="Rijnlander", DateOfBirth= new DateTime(2017, 10, 15), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 10, 17), Bio="Olaf is een vinnig beestje, perfect voor jonge gezinnen", Allergies="geen", ShelterId = 2, Size="groot"},
					new Rabbit{Name = "Garret", Race="Franse Hangoor", DateOfBirth= new DateTime(2015, 08, 20), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =false, IsSpeciesFriendly=false, Since=new DateTime(2019, 10, 11), Bio="Garret houd van kinderen en mensen, van andere dieren gaat hij lopen.", Allergies="geen", ShelterId = 2, Size="groot"},
					new Dog{Name = "Astrix", Race = "Mastino Napoletano", DateOfBirth = new DateTime(2017, 02, 12), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = true, Since = new DateTime(2018, 10, 22), Bio = "Astrix is een grote jongen die veel liefde geeft", Allergies = "geen", ShelterId = 2, Barker = true},
					new Dog{Name = "Rock", Race = "Staffordshire Bull Terrier", DateOfBirth = new DateTime(2016, 09, 19), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2017, 11, 09), Bio = "Rock is een grote dikke vriend van iedereen", Allergies = "kip", ShelterId = 2, Barker = true},
				},*/
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


			var shelter3 = new Shelter()
			{
				Name = "kat-lijn vzw",
				ImageUrl = "https://www.dierendonatie.be/wp-content/uploads/2019/01/29570550_2080399628857532_4696137069563272630_n.jpg",
				Address = "Houwaartstraat 15, 3210 Lubbeek",
				TelephoneNumber = "0468 56 93 72",
				EmailAdress = "info@kat-lijn.be",

				/*Animals = new List<Animal> {
					new Cat{Name = "Wolf", Race = "Bombay ", DateOfBirth = new DateTime(2003, 07, 22), IsFertile = true, IsKidFriendly = false, IsAnimalFriendly = false, IsSpeciesFriendly = false, Since = new DateTime(2004, 12, 01), Bio = "Een kat met de nodige kattenstreken.", Allergies = "geen", ShelterId = 3, Clawed = true},
					new Cat{Name = "Pom pom", Race = "Bengaalse tijgerkat", DateOfBirth = new DateTime(2007, 03, 29), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2010, 01, 15), Bio = "Een lieverd, begroet iedereen met een kopstootje.", Allergies = "geen", ShelterId = 3, Clawed = true},
					new Rabbit{Name = "Nijntje", Race="Kleurdwerg", DateOfBirth= new DateTime(2018, 04, 05), IsFertile =true, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=false, Since=new DateTime(2018, 08, 06), Bio="Nijntje, lief klein konijntje.", Allergies="wortels", ShelterId = 2, Size="small"},
					new Rabbit{Name = "Sneeuwtje", Race="Amerikaanse konijn", DateOfBirth= new DateTime(2019, 08, 01), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=false, Since=new DateTime(2019, 10, 30), Bio="Een witte konijn met een hoge aaibaarheidsfactor.", Allergies="rinitis", ShelterId = 3, Size="small"},
					new Dog{Name = "Mimi", Race = "Pommeriaan", DateOfBirth = new DateTime(2002, 11, 01), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = false, IsSpeciesFriendly = false, Since = new DateTime(2018, 02, 27), Bio = "Mimi is bang voor veel dingen maar overwint haar angsten voor haar baasjes.", Allergies = "geen", ShelterId = 3, Barker = true},
					new Dog{Name = "Elisabeth III", Race = "Bobtail", DateOfBirth = new DateTime(2019, 10, 30), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2019, 11, 28), Bio = "Een jong meisje met klasse, dat is Elisabeth III", Allergies = "kip", ShelterId = 3, Barker = true},
				},*/
				Managers = new List<Manager> {
					new Manager{FirstName = "Lodewijk",LastName = "Vander Boshen",},
					new Manager{FirstName = "Emiel",LastName = "Waeters",},
				},
				Administrators = new List<Administrator> {
					new Administrator{FirstName = "Els",LastName = "Aarendel",},
					new Administrator{FirstName = "Anna",LastName = "Christofson",},
					new Administrator{FirstName = "Paul",LastName = "D'haeg",},
				},
				Caretakers = new List<Caretaker> {
					new Caretaker{FirstName = "Jo-Anne",LastName = "De Haeghen",},
					new Caretaker{FirstName = "Roos",LastName = "Groenenlandt",},
					new Caretaker{FirstName = "Eugene",LastName = "Craps",},
				}
			};

			_context.Shelters.Add(shelter1);
			_context.Shelters.Add(shelter2);
			_context.Shelters.Add(shelter3);

			_context.SaveChanges();
		}
	}
}