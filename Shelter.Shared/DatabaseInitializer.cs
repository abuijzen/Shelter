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
			var shelter = new Shelter()
			{
				Id = 1,
				Name = "Dierenasiel",
				ImageUrl = "image",
				Address = "Dierenasielstraat 2",
				TelephoneNumber = "045673456",
				EmailAdress = "info@dierenasiel.be",

				Managers = new List<Manager> { new Manager("Johan", "Janssen") },

				Animals = new List<Animal> {
						new Cat(1, "Felix", "Britse Korthaar", new DateTime(2005, 10, 09), false, true, true, true, new DateTime(2007, 10, 09), "meow I'm a cat", "catnip", true),
						new Cat(2, "Picasso", "Ragdoll", new DateTime(2010, 03, 10), false, true, true, true, new DateTime(2011, 08, 10), "Mieeeuw", "dogs", true),
						new Rabbit(3, "Ior", "Hollander", new DateTime(2017, 12, 25), false, true, true, true, new DateTime(2018, 09, 10), "Ior is een cutiepie", "nothing", "small"),
					}
			};
			_context.Shelters.Add(shelter);

			_context.SaveChanges();
		}
	}
}