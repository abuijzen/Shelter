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
			var managers = new Manager()
			{
				FirstName = "Johan",
				LastName = "Janssen",
			};

			var shelter = new Shelter()
			{
				Name = "Dierenasiel",
				ImageUrl = "image",
				Address = "Dierenasielstraat 2",
				TelephoneNumber = "045673456",
				EmailAdress = "info@dierenasiel.be",

				Animals = new List<Animal> {
						new Cat(1, "Felix", "Britse Korthaar", new DateTime(2005, 10, 09), false, true, true, true, new DateTime(2007, 10, 09), "meow I'm a cat", "catnip", true),
						new Cat(Name = "Picasso", Race = "Ragdoll", DateOfBirth = new DateTime(2010, 03, 10), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2011, 08, 10), Bio = "Mieeeuw", Allergies = "dogs"),
						new Rabbit{Name = "Ior", Race="Hollander", DateOfBirth= new DateTime(2017, 12, 25), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 09, 10), Bio="Ior is een cutiepie", Allergies="none", Size="small"},
					}
			};
			shelter.Managers.Add(managers);
			_context.Shelters.Add(shelter);

			_context.SaveChanges();
		}
	}
}