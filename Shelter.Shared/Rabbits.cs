using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	public class Rabbit : Animal
	{
		public Rabbit() : base()
		{

		}

		public Rabbit(int id,
							string name,
							string race,
							DateTime dateOfBirth,
							bool isFertile,
							bool isKidFriendly,
							bool isAnimalFriendly,
							bool isSpeciesFriendly,
							DateTime since,
							string bio,
							string allergies,
							string size) /*extra toegevoegde data */
			: base(id, name,
							race,
							dateOfBirth,
							isFertile,
							isKidFriendly,
							isAnimalFriendly,
							isSpeciesFriendly,
							since,
							bio,
							allergies)
		{

		}
		public string size { get; set; }
	}
}