using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	public class Dog : Animals
	{
		public Dog() : base()
		{

		}

		public Dog(int id,
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
							bool barker) /*extra toegevoegde data */

					: base(id,
							name,
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

	}
}