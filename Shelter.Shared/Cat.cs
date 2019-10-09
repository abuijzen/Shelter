using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	class Cat : Animals
	{
		/*public Cat() : base()
		{

		}*/

		public Cat(int id,
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
							bool clawed) /*extra toegevoegde data */

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