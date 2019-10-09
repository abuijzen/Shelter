using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	class Animals
	{
		public Animals()
		{

		}

		public Animals(int id,
						string name,
							string race,
							DateTime dateOfBirth,
							bool isFertile,
							bool isKidFriendly,
							bool isAnimalFriendly,
							bool isSpeciesFriendly,
							DateTime since,
							string bio,
							string allergies)
		{
			Id = id;
			Name = name;
			Race = race;
			DateOfBirth = dateOfBirth;
			IsFertile = isFertile;
			IsKidFriendly = isKidFriendly;
			IsAnimalFriendly = isAnimalFriendly;
			IsSpeciesFriendly = isSpeciesFriendly;
			Since = since;
			Bio = bio;
			Allergies = allergies;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Race { get; set; }
		public DateTime DateOfBirth { get; set; }
		public bool IsFertile { get; set; }
		public bool IsKidFriendly { get; set; }
		public bool IsAnimalFriendly { get; set; }
		public bool IsSpeciesFriendly { get; set; }
		public DateTime Since { get; set; }

		public string Bio { get; set; }

		public string Allergies { get; set; }


	}
}
