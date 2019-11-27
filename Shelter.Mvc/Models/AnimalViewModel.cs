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
						new Cat{Name = "Felix", Race = "Britse Korthaar", DateOfBirth = new DateTime(2005, 10, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "meow I'm a cat", Allergies = "catnip", Clawed = true},
						new Cat{Name = "Picasso", Race = "Ragdoll", DateOfBirth = new DateTime(2005, 10, 09), IsFertile = false, IsKidFriendly = true, IsAnimalFriendly = true, IsSpeciesFriendly = true, Since = new DateTime(2007, 10, 09), Bio = "Mieeeuw", Allergies = "dogs", Clawed = true},
						new Rabbit{Name = "Ior", Race="Hollander", DateOfBirth= new DateTime(2017, 12, 25), IsFertile =false, IsKidFriendly= true, IsAnimalFriendly =true, IsSpeciesFriendly=true, Since=new DateTime(2018, 09, 10), Bio="Ior is een cutiepie", Allergies="none", Size="small"},
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
