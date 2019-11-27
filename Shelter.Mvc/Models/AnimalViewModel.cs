using System.Collections.Generic;
using System;
using Shelter.Mvc.Models;
using Shelter.Shared;


namespace Shelter.Mvc.Models
{
	public class AnimalViewModel
	{
		public List<Animal> Animals { get; set; }

		private static bool _isInitialized = false;

		//private static IEnumerable<Animal> _animal = null;
		private static Shelter.Shared.Shelter _shelter = null;

		private static void Initialize()
		{
			if (!_isInitialized)
			{
				var shelter = new Shelter.Shared.Shelter()
				{
					Animals = new List<Animal> {
						new Cat(1, "Felix", "Britse Korthaar", new DateTime(2005, 10, 09), false, true, true, true, new DateTime(2007, 10, 09), "meow I'm a cat", "catnip", true),
						new Cat(2, "Picasso", "Ragdoll", new DateTime(2010, 03, 10), false, true, true, true, new DateTime(2011, 08, 10), "Mieeeuw", "dogs", true),
						new Rabbit(2, "Ior", "Hollander", new DateTime(2017, 12, 25), false, true, true, true, new DateTime(2018, 09, 10), "Ior is een cutiepie", "nothing", "small"),
					}
				};

				_shelter = shelter;
				_isInitialized = true;
			};
		}

		public static Shared.Shelter Shelter
		{
			get
			{
				Initialize();
				return _shelter;
			}
		}

		/*public static IEnumerable<Animal> Animals
		{
			get
			{
				Initialize();
				return _animal;
			}
		}*/
	}
}
