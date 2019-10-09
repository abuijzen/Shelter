using System;
using System.Collections.Generic;

namespace Shelter.Shared
{
	class Dog: Animals
	{
		public Dog() : base()
		{

		}

		public Dog(int id,
                            string name,
                            string race,
                            DateTime dateOfBirth,
                            bool isFertile,
                            string kidFriendly,
                            string animalFriendly,
                            string speciesFriendly,
                            DateTime since,
                            string bio,
                            string allergies,
							bool barker) /*extra toegevoegde data */
					
					: base(	id,
							name,
							race,
							dateOfBirth,
							isFertile,
							kidFriendly,
							animalFriendly,
							speciesFriendly,
							since,
							bio,
							allergies)
		{

		}

	}
}